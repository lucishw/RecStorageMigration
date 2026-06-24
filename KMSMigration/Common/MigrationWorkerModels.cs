using System;

namespace Common
{
    public class MigrationWorkerSettings
    {
        public int WorkerId { get; set; }
        public string SelectCondition { get; set; }
        public string TopCount { get; set; }
        public string BatchIntervalSeconds { get; set; }
        public string SuccessMarkValue { get; set; }
        public TimeSpan WeekdayStartTime { get; set; }
        public TimeSpan WeekdayEndTime { get; set; }
        public TimeSpan WeekendStartTime { get; set; }
        public TimeSpan WeekendEndTime { get; set; }

        public string SourceDBIP { get; set; }
        public string SourceDBNM { get; set; }
        public string SourceDBID { get; set; }
        public string SourceDBPW { get; set; }
        public string SourceTableName { get; set; }
        public string SourceMarkTableName { get; set; }
        public string SourceYearDB { get; set; }
        public string SourceMarkField { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CheckTrustDBServer { get; set; }

        public string I360HttpFullPathField { get; set; }
        public string I360IISPath { get; set; }
        public string I360NetBiosPath { get; set; }
        public string AudiologPath { get; set; }
        public string AudiologPathAddField { get; set; }
        public string TargetPath { get; set; }
        public string BackupPath { get; set; }
        public string TempRootPath { get; set; }

        public string KMSServerIP { get; set; }
        public string KMSDomain { get; set; }
        public string KMSServerID { get; set; }
        public string KMSServerPW { get; set; }
        public string KMSAuthIP { get; set; }
        public string KMSAuthPort { get; set; }
        public string KMSKeyValue { get; set; }
        public int KMSFileSize { get; set; }

        public string CheckTelNoEncrypt { get; set; }

        public int GetTopCount()
        {
            int count;

            if (!Int32.TryParse(TopCount, out count) || count <= 0)
                return 5000;

            return count;
        }

        public int GetBatchIntervalSeconds()
        {
            int seconds;

            if (!Int32.TryParse(BatchIntervalSeconds, out seconds) || seconds < 0)
                return 0;

            return seconds;
        }

        public string GetSuccessMarkValue()
        {
            if (String.IsNullOrWhiteSpace(SuccessMarkValue))
                return "1";

            return SuccessMarkValue.Trim();
        }
    }

    public class MigrationWorkerProgressEventArgs : EventArgs
    {
        public int WorkerId { get; set; }
        public string StatusText { get; set; }
        public string CurrentDate { get; set; }
        public int BatchCount { get; set; }
        public int ProcessedCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public bool IsRunning { get; set; }
    }

    public class MigrationWorkerLogEventArgs : EventArgs
    {
        public int WorkerId { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
    }

    public class MigrationWorkerSummary
    {
        public int WorkerId { get; set; }
        public string LastDate { get; set; }
        public int ProcessedCount { get; set; }
        public int SuccessCount { get; set; }
        public int MissingFileCount { get; set; }
        public int SmallFileCount { get; set; }
        public int AlreadyEncryptedCount { get; set; }
        public int FailureCount { get; set; }
        public bool Cancelled { get; set; }
        public string Message { get; set; }
    }
}
