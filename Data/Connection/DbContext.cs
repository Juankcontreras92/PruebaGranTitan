using Business;
using System;
using System.Data.SqlClient;

namespace Data.Connection
{
    public class DbContextApi
    {
        private static string _connectionString = string.Empty;
        public static string GetConnectionString()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                _connectionString = ConfigReader.GetAppSettingValue("dbConnectionString");
            return _connectionString;
        }
        public static SqlConnection CreateConnection()
        {
            SqlConnection DbConnection1 = new SqlConnection(GetConnectionString());
            DbConnection1.Open();
            int i = 0;
            while (DbConnection1.State != System.Data.ConnectionState.Open)
            {
                if (i < 10)
                {
                    System.Threading.Thread.Sleep(1500);
                    try
                    {
                        DbConnection1.Open();
                    }
                    catch
                    {
                    }
                    i++;
                }
                else break;
            }
            if (DbConnection1.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("DbConnection1.State != ConnectionState.Open");
            }
            return DbConnection1;
        }

    }
}
