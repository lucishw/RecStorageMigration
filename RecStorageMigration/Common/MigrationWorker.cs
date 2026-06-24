using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Common
{
    public class MigrationWorker
    {
        private const string RuntimeOutMessage = "Runtime 범위 외 중지";
        private readonly SqlAccount _sqlAccount;
        private readonly LogManager _workerLog;
        private readonly LogManager _workerErrLog;
        private MigrationWorkerSettings _settings;
        private string _tempFolder;

        public event EventHandler<MigrationWorkerProgressEventArgs> ProgressChanged;
        public event EventHandler<MigrationWorkerLogEventArgs> LogCreated;

        public MigrationWorker()
        {
            _sqlAccount = new SqlAccount();
            _workerLog = new LogManager();
            _workerErrLog = new LogManager();
        }

        public MigrationWorkerSummary Run(MigrationWorkerSettings settings, CancellationToken cancelToken)
        {
            _settings = settings;
            _tempFolder = Path.Combine(settings.TempRootPath, "worker_" + settings.WorkerId + "_" + Guid.NewGuid().ToString("N"));

            MigrationWorkerSummary summary = new MigrationWorkerSummary();
            summary.WorkerId = settings.WorkerId;

            try
            {
                InitWorkerLog();

                // 작업자별 임시 폴더를 분리하여 같은 파일명의 동시 처리 충돌을 방지합니다.
                Directory.CreateDirectory(_tempFolder);

                DateTime workDate = DateTime.ParseExact(settings.FromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(settings.ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                RaiseProgress("작업 시작", settings.FromDate + " ~ " + settings.ToDate, 0, summary, true);

                while (workDate <= toDate)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        summary.Cancelled = true;
                        break;
                    }

                    summary.LastDate = workDate.ToString("yyyy-MM-dd");
                    RaiseProgress("작업 시작", summary.LastDate, 0, summary, true);

                    while (!cancelToken.IsCancellationRequested)
                    {
                        if (!IsCurrentTimeInSchedule())
                        {
                            MarkRuntimeOut(summary);
                            return summary;
                        }

                        int selectedCount = RunBatch(workDate, summary, cancelToken);
                        if (selectedCount == 0)
                            break;

                        if (!WaitForNextBatch(workDate, summary, cancelToken))
                        {
                            if (summary.Message == RuntimeOutMessage)
                                return summary;

                            break;
                        }
                    }

                    workDate = workDate.AddDays(1);
                }

                if (summary.Cancelled)
                    summary.Message = "Worker stopped";
                else if (String.IsNullOrWhiteSpace(summary.Message))
                    summary.Message = "Worker completed";

                return summary;
            }
            catch (Exception ex)
            {
                summary.Message = ex.Message;
                summary.FailureCount++;
                WriteLog("[Error__] [Worker] " + ex.Message, true);
                return summary;
            }
            finally
            {
                TryDeleteTempFolder();
                string finalStatus = summary.Cancelled ? "중지됨" : summary.Message;
                if (String.IsNullOrWhiteSpace(finalStatus))
                    finalStatus = "완료";

                RaiseProgress(finalStatus, summary.LastDate, 0, summary, false);
            }
        }

        private int RunBatch(DateTime workDate, MigrationWorkerSummary summary, CancellationToken cancelToken)
        {
            using (DBManager sourceDb = new DBManager())
            using (DataSet dataSet = new DataSet())
            {
                RaiseProgress("DB 연결 중", workDate.ToString("yyyy-MM-dd"), 0, summary, true);

                if (!sourceDb.MssqlConnect(_settings.SourceDBIP, _settings.SourceDBNM, _settings.SourceDBID, _settings.SourceDBPW, _settings.CheckTrustDBServer))
                {
                    WriteLog("[Failure] [DBCon__] Worker " + _settings.WorkerId + " Source - DBIP : " + _settings.SourceDBIP + ", DBNM : " + _settings.SourceDBNM, true);
                    summary.FailureCount++;
                    return 0;
                }

                string query = BuildSelectQuery(workDate);
                RaiseProgress("조회 중", workDate.ToString("yyyy-MM-dd"), 0, summary, true);
                WriteLog("[Info___] [Worker] Worker " + _settings.WorkerId + " Query - " + query, false);

                if (!sourceDb.SelectSqlDataSet(dataSet, "Source", query))
                {
                    WriteLog("[Failure] [Conditi] Worker " + _settings.WorkerId + " Query - " + query, true);
                    summary.FailureCount++;
                    return 0;
                }

                if (!dataSet.Tables.Contains("Source"))
                    return 0;

                DataTable sourceTable = dataSet.Tables["Source"];
                int selectedCount = sourceTable.Rows.Count;

                RaiseProgress(selectedCount.ToString("#,##0") + "건 조회", workDate.ToString("yyyy-MM-dd"), selectedCount, summary, true);
                WriteLog("[Info___] [Worker] Worker " + _settings.WorkerId + " Query Count - " + selectedCount + " 건", false);

                foreach (DataRow row in sourceTable.Rows)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        summary.Cancelled = true;
                        break;
                    }

                    string fileName = GetRowValue(row, "FileName");
                    RaiseProgress("파일 복사 중.. " + fileName, workDate.ToString("yyyy-MM-dd"), selectedCount, summary, true);
                    ProcessRow(sourceDb, row, summary);
                    RaiseProgress("처리 중", workDate.ToString("yyyy-MM-dd"), selectedCount, summary, true);
                }

                return selectedCount;
            }
        }

        private bool WaitForNextBatch(DateTime workDate, MigrationWorkerSummary summary, CancellationToken cancelToken)
        {
            int intervalSeconds = _settings.GetBatchIntervalSeconds();
            if (intervalSeconds <= 0)
                return !cancelToken.IsCancellationRequested;

            WriteLog("[Info___] [Worker] Worker " + _settings.WorkerId + " next batch wait - " + intervalSeconds + " sec", false);

            for (int remainingSeconds = intervalSeconds; remainingSeconds > 0; remainingSeconds--)
            {
                if (!IsCurrentTimeInSchedule())
                {
                    MarkRuntimeOut(summary);
                    return false;
                }

                RaiseProgress("Interval 대기 중.. " + remainingSeconds, workDate.ToString("yyyy-MM-dd"), 0, summary, true);

                bool cancelled = cancelToken.WaitHandle.WaitOne(1000);
                if (cancelled)
                {
                    summary.Cancelled = true;
                    return false;
                }
            }

            return !cancelToken.IsCancellationRequested;
        }

        private void MarkRuntimeOut(MigrationWorkerSummary summary)
        {
            summary.Message = RuntimeOutMessage;
            WriteLog("[Info___] [Worker] Worker " + _settings.WorkerId + " stopped outside runtime schedule", false);
            RaiseProgress(summary.Message, summary.LastDate, 0, summary, true);
        }

        private bool IsCurrentTimeInSchedule()
        {
            TimeSpan startTime;
            TimeSpan endTime;

            GetRuntimeForDate(DateTime.Now, out startTime, out endTime);
            return IsTimeInRuntime(DateTime.Now.TimeOfDay, startTime, endTime);
        }

        private void GetRuntimeForDate(DateTime date, out TimeSpan startTime, out TimeSpan endTime)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                startTime = _settings.WeekendStartTime;
                endTime = _settings.WeekendEndTime;
            }
            else
            {
                startTime = _settings.WeekdayStartTime;
                endTime = _settings.WeekdayEndTime;
            }
        }

        private bool IsTimeInRuntime(TimeSpan currentTime, TimeSpan startTime, TimeSpan endTime)
        {
            // [00:00 ~ 00:00]
            if (startTime == endTime)
                return true;

            // [18:00 ~ 19:00]
            if (startTime < endTime)
                return currentTime >= startTime && currentTime < endTime;

            // [22:00 ~ 04:00]
            if (currentTime >= startTime)
                return true;

            return currentTime < endTime;
        }

        private void InitWorkerLog()
        {
            string workerPrefix = "worker_" + _settings.WorkerId;

            _workerLog.LogFilePrefix = workerPrefix;
            _workerLog.CreateLogFile();

            _workerErrLog.LogFilePrefix = workerPrefix;
            _workerErrLog.LogFileName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + "Err";
            _workerErrLog.CreateLogFile();
        }

        private string BuildSelectQuery(DateTime workDate)
        {
            StringBuilder query = new StringBuilder();
            List<string> fields = new List<string>();

            // I360/Audiolog 설정에 따라 실제 조회에 필요한 경로 보조 필드만 추가합니다.
            fields.Add("FileName");
            fields.Add("ServerName");
            fields.Add("Date");
            fields.Add("Started");
            fields.Add("DialedNumber");
            fields.Add("CallerNumber");

            AddField(fields, _settings.I360HttpFullPathField);
            AddField(fields, _settings.AudiologPathAddField);

            query.Append("Select Top ");
            query.Append(_settings.GetTopCount());
            query.Append(" ");
            query.Append(String.Join(", ", fields.ToArray()));
            query.Append(" From ");
            query.Append(_settings.SourceTableName);
            query.Append(" with (nolock) Where Date = '");
            query.Append(workDate.ToString("yyyy-MM-dd"));
            query.Append("' ");

            if (!String.IsNullOrWhiteSpace(_settings.SelectCondition))
            {
                query.Append("And ");
                query.Append(_settings.SelectCondition);
                query.Append(" ");
            }

            query.Append("And (");
            query.Append(_settings.SourceMarkField);
            query.Append(" is null or ");
            query.Append(_settings.SourceMarkField);
            query.Append(" = '')");

            return query.ToString();
        }

        private void AddField(List<string> fields, string fieldName)
        {
            if (String.IsNullOrWhiteSpace(fieldName))
                return;

            if (!fields.Contains(fieldName))
                fields.Add(fieldName);
        }

        private void ProcessRow(DBManager sourceDb, DataRow row, MigrationWorkerSummary summary)
        {
            string fileName = GetRowValue(row, "FileName");
            string serverName = GetRowValue(row, "ServerName");
            string dialedNumber = GetRowValue(row, "DialedNumber");
            string callerNumber = GetRowValue(row, "CallerNumber");

            summary.ProcessedCount++;

            try
            {
                // Source 파일 선조회 대신 파일 크기 확인과 복사 단계의 예외로 파일 없음 상태를 판단합니다.
                string recDate = Convert.ToDateTime(row["Date"]).ToString("yyyy-MM-dd");
                string sourceFile = BuildSourceFile(row, fileName, serverName, recDate);
                string targetFile = BuildTargetFile(sourceFile);
                string targetFolder = Path.GetDirectoryName(targetFile);

                long sourceFileSize = GetFileSize(sourceFile);
                if (sourceFileSize <= 1024)
                {
                    summary.FailureCount++;
                    MarkRow(sourceDb, row, "6", dialedNumber, callerNumber);
                    WriteLog("[Failure] [Size___] Worker " + _settings.WorkerId + " 1KB 이하 파일(6) - " + sourceFile, true);
                    return;
                }

                CreateDirectory(targetFolder);

                if (!CopyToTarget(sourceFile, targetFile))
                {
                    summary.FailureCount++;
                    MarkRow(sourceDb, row, "5", dialedNumber, callerNumber);
                    WriteLog("[Failure] [FileCopy] Worker " + _settings.WorkerId + " copy failed(5) - " + sourceFile + " >>> " + targetFile, true);
                    return;
                }

                summary.SuccessCount++;
                MarkRow(sourceDb, row, _settings.GetSuccessMarkValue(), dialedNumber, callerNumber);
                WriteLog("[Success] [FileCopy] Worker " + _settings.WorkerId + " copy success(" + _settings.GetSuccessMarkValue() + ") - " + sourceFile + " >>> " + targetFile, false);
            }
            catch (FileNotFoundException ex)
            {
                summary.MissingFileCount++;
                MarkRow(sourceDb, row, "2", dialedNumber, callerNumber);
                WriteLog("[Failure] [Exists_] Worker " + _settings.WorkerId + " 녹취 파일 없음(2) - " + fileName + " / " + ex.FileName, true);
            }
            catch (DirectoryNotFoundException ex)
            {
                summary.MissingFileCount++;
                MarkRow(sourceDb, row, "2", dialedNumber, callerNumber);
                WriteLog("[Failure] [Exists_] Worker " + _settings.WorkerId + " 녹취 폴더 없음(2) - " + fileName + " / " + ex.Message, true);
            }
            catch (Exception ex)
            {
                summary.FailureCount++;
                MarkRow(sourceDb, row, "5", dialedNumber, callerNumber);
                WriteLog("[Error__] [Worker] Worker " + _settings.WorkerId + " " + fileName + " - " + ex.Message, true);
            }
        }

        private string BuildSourceFile(DataRow row, string fileName, string serverName, string recDate)
        {
            if (!String.IsNullOrWhiteSpace(_settings.I360HttpFullPathField))
            {
                string sourceFile = GetRowValue(row, _settings.I360HttpFullPathField).Trim();
                return sourceFile.Replace(_settings.I360IISPath, _settings.I360NetBiosPath).Replace("/", @"\");
            }

            string audiologPathAdd = "";
            if (!String.IsNullOrWhiteSpace(_settings.AudiologPathAddField))
                audiologPathAdd = GetRowValue(row, _settings.AudiologPathAddField).Replace(@"\", "").Trim();

            if (audiologPathAdd != "")
            {
                return _settings.AudiologPath + @"\" + audiologPathAdd + @"\" + serverName.Replace(@"\", "") + @"\" +
                       fileName.Substring(11, 5) + fileName.Substring(8, 3) + @"\" + recDate.Replace("-", "") + @"\" + fileName;
            }

            return _settings.AudiologPath + @"\" + serverName.Replace(@"\", "") + @"\" +
                   fileName.Substring(11, 5) + fileName.Substring(8, 3) + @"\" + recDate.Replace("-", "") + @"\" + fileName;
        }

        private string BuildTargetFile(string sourceFile)
        {
            if (!String.IsNullOrWhiteSpace(_settings.I360HttpFullPathField))
                return sourceFile.Replace(_settings.I360NetBiosPath, _settings.TargetPath);

            return sourceFile.Replace(_settings.AudiologPath, _settings.TargetPath);
        }

        private long GetFileSize(string sourceFile)
        {
            FileInfo fileInfo = new FileInfo(sourceFile);
            return fileInfo.Length;
        }

        private bool CopyToTarget(string sourceFile, string targetFile)
        {
            string tempSource = Path.Combine(_tempFolder, Guid.NewGuid().ToString("N") + "_" + Path.GetFileName(sourceFile));

            try
            {
                // 원본을 작업자 임시 폴더로 복사한 뒤 최종 TargetPath에 기록합니다.
                File.Copy(sourceFile, tempSource, true);
                File.Copy(tempSource, targetFile, true);
                return true;
            }
            finally
            {
                TryDeleteFile(tempSource);
            }
        }

        private void CreateDirectory(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        private void MarkRow(DBManager dbManager, DataRow row, string markValue, string dialedNumber, string callerNumber)
        {
            try
            {
                // 처리 결과는 재시작 안정성을 위해 Row 단위로 즉시 원본 DB에 반영합니다.
                string fileName = GetRowValue(row, "FileName");
                string serverName = GetRowValue(row, "ServerName");
                string recDate = Convert.ToDateTime(row["Date"]).ToString("yyyy-MM-dd");
                string year = recDate.Substring(0, 4);

                StringBuilder query = new StringBuilder();

                if (String.IsNullOrWhiteSpace(_settings.SourceYearDB))
                    query.Append("Update " + _settings.SourceDBNM + ".dbo." + _settings.SourceMarkTableName);
                else
                    query.Append("Update " + _settings.SourceYearDB + year + ".dbo." + _settings.SourceMarkTableName);

                query.Append(" Set ");
                query.Append(_settings.SourceMarkField);
                query.Append(" = '");
                query.Append(EscapeSql(markValue));
                query.Append("'");
                query.Append(", ETL_DT = GETDATE()");

                if (_settings.CheckTelNoEncrypt == "1")
                {
                    query.Append(", DialedNumber = '");
                    query.Append(EscapeSql(_sqlAccount.AES256ENC(dialedNumber)));
                    query.Append("'");
                    query.Append(", CallerNumber = '");
                    query.Append(EscapeSql(_sqlAccount.AES256ENC(callerNumber)));
                    query.Append("'");
                }

                query.Append(" Where FileName = '");
                query.Append(EscapeSql(fileName));
                query.Append("' And ServerName = '");
                query.Append(EscapeSql(serverName));
                query.Append("'");

                int result = dbManager.UpdateSql(query.ToString());
                if (result == 1)
                    WriteLog("[Success] [Marking] Worker " + _settings.WorkerId + " " + fileName + " / " + serverName, false);
                else
                    WriteLog("[Failure] [Marking] Worker " + _settings.WorkerId + " " + query, true);
            }
            catch (Exception ex)
            {
                WriteLog("[Error__] [Marking] Worker " + _settings.WorkerId + " - " + ex.Message, true);
            }
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value)
                return row[fieldName].ToString();

            return "";
        }

        private string EscapeSql(string value)
        {
            if (value == null)
                return "";

            return value.Replace("'", "''");
        }

        private void TryDeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch
            {
            }
        }

        private void TryDeleteTempFolder()
        {
            try
            {
                if (Directory.Exists(_tempFolder))
                    Directory.Delete(_tempFolder, true);
            }
            catch
            {
            }
        }

        private void RaiseProgress(string statusText, string currentDate, int batchCount, MigrationWorkerSummary summary, bool isRunning)
        {
            EventHandler<MigrationWorkerProgressEventArgs> handler = ProgressChanged;
            if (handler == null)
                return;

            MigrationWorkerProgressEventArgs args = new MigrationWorkerProgressEventArgs();
            args.WorkerId = _settings.WorkerId;
            args.StatusText = statusText;
            args.CurrentDate = currentDate;
            args.BatchCount = batchCount;
            args.ProcessedCount = summary.ProcessedCount;
            args.SuccessCount = summary.SuccessCount;
            args.FailureCount = summary.FailureCount + summary.MissingFileCount + summary.SmallFileCount + summary.AlreadyEncryptedCount;
            args.IsRunning = isRunning;

            handler(this, args);
        }

        private void WriteLog(string message, bool isError)
        {
            _workerLog.LogMessage(message);

            if (isError)
                _workerErrLog.LogMessage(message);

            EventHandler<MigrationWorkerLogEventArgs> handler = LogCreated;
            if (handler == null)
                return;

            MigrationWorkerLogEventArgs args = new MigrationWorkerLogEventArgs();
            args.WorkerId = _settings.WorkerId;
            args.Message = message;
            args.IsError = isError;

            handler(this, args);
        }
    }
}
