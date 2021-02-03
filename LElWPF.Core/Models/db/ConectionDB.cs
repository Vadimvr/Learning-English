using Microsoft.Data.Sqlite;
using System;
namespace LElWPF.Core.Models.db
{
    class ConectionDB
    {
        Random rnd = new Random();
        public SqliteConnectionStringBuilder connectionStringBuilder { get; set; }
        string PathDB { get; set; }
        string NameDB { get; set; }
        public int SatrtIndex { get; set; } = 1;
        public int EndIndex { get; set; }
        public ConectionDB(string path, string dbname)
        {
            PathDB = path;
            NameDB = dbname;
            connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = PathDB + NameDB;
            //connectionStringBuilder.DataSource = @"D:\test\test.db";
            GetCountDB();
        }
        void GetCountDB()
        {
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT COUNT(*) FROM Values1";
                int x = 0;
                int.TryParse(selectCmd.ExecuteScalar().ToString(), out x);
                connection.Close();
                EndIndex = x;
            }
        }
        public Values GetRandomValues()
        {
            
            //int random = rnd.Next(SatrtIndex, EndIndex); 

            int random = SatrtIndex++;


            try
            {
                Values values;
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    SqliteCommand selectCommand = new SqliteCommand($"SELECT eng, engt, rus   FROM Values1 WHERE id={random}", connection);

                    SqliteDataReader query = selectCommand.ExecuteReader();

                    query.Read();
                    values = new Values(query.GetString(0), query.GetString(1), query.GetString(2), PathDB);

                    connection.Close();
                }
                return values;
            }
            catch
            {
                SatrtIndex = 1;
                return new Values("err", "errr", "errr", PathDB);
            }

        }

    }
}
