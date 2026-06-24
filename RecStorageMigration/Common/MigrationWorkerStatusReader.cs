using System;
using System.Data;
using System.Text;

namespace Common
{
    public class MigrationWorkerStatusReader
    {
        public string ReadStatus(MigrationWorkerSettings settings)
        {
            using (DBManager dbManager = new DBManager())
            using (DataSet dataSet = new DataSet())
            {
                if (!dbManager.MssqlConnect(settings.SourceDBIP, settings.SourceDBNM, settings.SourceDBID, settings.SourceDBPW, settings.CheckTrustDBServer))
                    return "DB 연결 실패";

                string query = BuildStatusQuery(settings);

                if (!dbManager.SelectSqlDataSet(dataSet, "Status", query))
                    return "상태 조회 실패\r\n" + query;

                return BuildStatusMessage(settings, dataSet.Tables["Status"]);
            }
        }

        private string BuildStatusQuery(MigrationWorkerSettings settings)
        {
            StringBuilder query = new StringBuilder();

            query.Append("Select ");
            query.Append("IsNull(Convert(varchar(50), ");
            query.Append(settings.SourceMarkField);
            query.Append("), '') As MarkValue, Count(*) As Cnt ");
            query.Append("From ");
            query.Append(settings.SourceTableName);
            query.Append(" with (nolock) ");
            query.Append("Where Date >= '");
            query.Append(EscapeSql(settings.FromDate));
            query.Append("' And Date <= '");
            query.Append(EscapeSql(settings.ToDate));
            query.Append("' ");

            if (!String.IsNullOrWhiteSpace(settings.SelectCondition))
            {
                query.Append("And ");
                query.Append(settings.SelectCondition);
                query.Append(" ");
            }

            query.Append("Group By ");
            query.Append(settings.SourceMarkField);
            query.Append(" Order By MarkValue");

            return query.ToString();
        }

        private string BuildStatusMessage(MigrationWorkerSettings settings, DataTable table)
        {
            StringBuilder message = new StringBuilder();
            int totalCount = 0;

            message.AppendLine("Worker " + settings.WorkerId + " 처리 현황");
            message.AppendLine("기간: " + settings.FromDate + " ~ " + settings.ToDate);
            message.AppendLine("조건: " + (String.IsNullOrWhiteSpace(settings.SelectCondition) ? "(없음)" : settings.SelectCondition));
            message.AppendLine("");

            foreach (DataRow row in table.Rows)
            {
                string markValue = row["MarkValue"].ToString();
                int count = Convert.ToInt32(row["Cnt"]);

                totalCount += count;

                if (markValue == "")
                    markValue = "(미처리)";

                message.AppendLine(markValue + " : " + count.ToString("#,##0") + "건");
            }

            message.AppendLine("");
            message.AppendLine("전체: " + totalCount.ToString("#,##0") + "건");

            return message.ToString();
        }

        private string EscapeSql(string value)
        {
            if (value == null)
                return "";

            return value.Replace("'", "''");
        }
    }
}
