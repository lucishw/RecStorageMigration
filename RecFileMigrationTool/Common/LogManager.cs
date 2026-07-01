using System;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace Common
{
    public class LogManager
    {        
        private string logFileName;
        private string logFilePath;
        private string logFileFullPath;
        private int logFileRetentionPeriod;
        private string logFilePrefix;

        /// <summary>Log 파일 이름</summary>
        public string LogFileName
        {
            get { return logFileName; }
            set { logFileName = value; }
        }

        /// <summary>Log 파일 경로</summary>
        public string LogFilePath
        {
            get { return logFilePath; }
            set { logFilePath = value; }
        }

        /// <summary>Log 파일 보존 기간</summary>
        public int LogFileRetentionPeriod
        {
            get { return logFileRetentionPeriod; }
            set { logFileRetentionPeriod = value; }
        }

        /// <summary>Log 파일 이름 앞에 붙일 접두어</summary>
        public string LogFilePrefix
        {
            get { return logFilePrefix; }
            set { logFilePrefix = value; }
        }

        /// <summary>새로운 LogManager 개체 인스턴스를 초기화 합니다.</summary>
        public LogManager()
        {
            logFileName = Process.GetCurrentProcess().ProcessName;
            logFilePath = Directory.GetCurrentDirectory() + @"\log";
            logFileRetentionPeriod = 30;
            logFilePrefix = "";
        }

        /// <summary>Log파일를 생성합니다.</summary>
        public void CreateLogFile()
        {
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }

            if (logFilePrefix == "")
                logFileFullPath = logFilePath + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + logFileName + ".log";
            else
                logFileFullPath = logFilePath + @"\" + logFilePrefix + "_" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + logFileName + ".log";

            if (!File.Exists(logFileFullPath))
            {
                using (StreamWriter sw = File.CreateText(logFileFullPath)) {}
            }
        }

        public void DeleteLogFile()
        {
            try
            {
                if (Directory.Exists(logFilePath))
                {
                    foreach (string file in Directory.GetFiles(logFilePath, "*.log", SearchOption.TopDirectoryOnly))
                    {
                        FileInfo fi = new FileInfo(file);
                        DateTime logDate;
                        string fileName;
                        fileName = fi.Name;
                        if (!TryGetLogDate(fileName, out logDate))
                            continue;

                        if (DateTime.Now.AddDays(-logFileRetentionPeriod).Date > logDate)
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        private bool TryGetLogDate(string fileName, out DateTime logDate)
        {
            string[] fileNameParts = fileName.Split('_');

            foreach (string fileNamePart in fileNameParts)
            {
                if (fileNamePart.Length < 10)
                    continue;

                if (DateTime.TryParseExact(fileNamePart.Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out logDate))
                    return true;
            }

            logDate = DateTime.MinValue;
            return false;
        }

        private static readonly object LogLock = new object();
        public void LogMessage(string logMessage)
        {
            // 스레드 안전성을 위한 동기화 잠금 (Lock) 추가
            lock (LogLock)
            {
                try
                {
                    // 이 라인은 메모리 손상 때문에 오류가 난 것일 가능성이 높음
                    using (StreamWriter sw = File.AppendText(logFileFullPath))
                    {
                        sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] : "));
                        sw.WriteLine(logMessage);
                    }
                }
                catch (Exception ex)
                {
                    // 파일 접근 실패나 다른 예외 발생 시 처리
                    // 이 부분은 FatalExecutionEngineError를 막지 못합니다.
                     Console.WriteLine($"로그 기록 중 예외 발생: {ex.Message}");
                }
            }
        }
        /*
        /// <summary>Log를 생성합니다.</summary>
        /// <param name="logMessage">Log Message</param>
        public void LogMessage(string logMessage)
        {
            using (StreamWriter sw = File.AppendText(logFileFullPath))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] : "));
                sw.WriteLine(logMessage);
            }
        }
        */
    }
}
