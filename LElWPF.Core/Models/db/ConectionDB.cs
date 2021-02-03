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
            string[] temp;
            //int random = rnd.Next(SatrtIndex, EndIndex); 

            int random = SatrtIndex++;
            try
            {
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {

                    connection.Open();

                    var rus = connection.CreateCommand();
                    rus.CommandText = $"SELECT rus FROM Values1 WHERE id={random}";

                    var eng = connection.CreateCommand();
                    eng.CommandText = $"SELECT eng FROM Values1 WHERE id={random}";

                    var engt = connection.CreateCommand();
                    engt.CommandText = $"SELECT engt FROM Values1 WHERE id={random}";

                    temp = new string[]{
                    rus.ExecuteScalar().ToString(),
                    eng.ExecuteScalar().ToString(),
                    engt.ExecuteScalar().ToString()};
                    connection.Close();
                }
                return new Values(temp, PathDB);
            }
            catch
            {
                SatrtIndex = 1;
                return new Values("a", "a", "a", PathDB);
            }

        }

    }
}
