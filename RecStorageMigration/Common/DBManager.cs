using System;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    class DBManager : IDisposable
    {
        private SqlConnection mssqlConnection;
        LogManager _Log = new LogManager();

        public DBManager()
        {
            mssqlConnection = new SqlConnection();
            _Log.CreateLogFile();
        }

        public void MssqlConnect(String connectionString)
        {
            mssqlConnection.ConnectionString = connectionString;
            mssqlConnection.Open();
        }

        public bool MssqlConnect(String mssqlserver, String mssqlDBName, String mssqlID, String mssqlPasswd, String enableTrustDB)
        {
            try
            {
                if (mssqlConnection.State == ConnectionState.Open)
                {
                    mssqlConnection.Dispose();
                }

                String connectionString;

                connectionString = "";
                connectionString = connectionString + "Server= " + mssqlserver + ";";
                connectionString = connectionString + "DataBase= " + mssqlDBName + ";";
                connectionString = connectionString + "UID= " + mssqlID + ";";
                connectionString = connectionString + "PWD= " + mssqlPasswd;

                if( enableTrustDB == "1" )
                    connectionString = connectionString + ";" + "Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=False;Connection Timeout=3";

                mssqlConnection.ConnectionString = connectionString;
                mssqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                _Log.LogMessage(ex.Message);
                return false;
            }
        }

        public void DisConnectDB()
        {
            if (mssqlConnection != null && mssqlConnection.State == ConnectionState.Open)
            {
                mssqlConnection.Close();
            }

            if (mssqlConnection != null)
            {
                mssqlConnection.Dispose();
                mssqlConnection = null;
            }
        }

        public void Dispose()
        {
            DisConnectDB();
        }

        public int InsertSql(String mssqlQuery)
        {
            try
            {
                SqlCommand mssqlCommand = new SqlCommand(mssqlQuery, mssqlConnection);
                return mssqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _Log.LogMessage(ex.Message);
                return -1;
            }
        }

        public int UpdateSql(String mssqlQuery)
        {
            try
            {
                SqlCommand mssqlCommand = new SqlCommand(mssqlQuery, mssqlConnection);
                return mssqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {                
                _Log.LogMessage(ex.Message);
                return -1;
            }
        }

        public int DeleteSql(String mssqlQuery)
        {
            try
            {
                SqlCommand mssqlCommand = new SqlCommand(mssqlQuery, mssqlConnection);
                return mssqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _Log.LogMessage(ex.Message);
                return -1;
            }
        }

        public int SelectSql(String mssqlQuery)
        {
            try
            {
                SqlCommand mssqlCommand = new SqlCommand(mssqlQuery, mssqlConnection);
                return Convert.ToInt32(mssqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                _Log.LogMessage(ex.Message);
                return -1;
            }
        }

        public SqlDataReader SelectSqlDataReader(String mssqlQuery)
        {
            SqlCommand mssqlCommand = new SqlCommand(mssqlQuery, mssqlConnection);
            return mssqlCommand.ExecuteReader();
        }

        public bool SelectSqlDataSet(DataSet dataset, String table, String mssqlQuery)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                adapter.SelectCommand = new SqlCommand(mssqlQuery, mssqlConnection);
                adapter.Fill(dataset, table);
                adapter.Dispose();
                return true;
            }
            catch (Exception)
            {
                adapter.Dispose();
                return false;
            }            
        }
    }
}
