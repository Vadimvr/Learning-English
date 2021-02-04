using Microsoft.Data.Sqlite;
using System;
namespace LElWPF.Core.Models.db
{
    class RandomValueFromTable
    {
        Random rnd = new Random();
        public SqliteConnectionStringBuilder connectionStringBuilder { get; set; }
        string PathDB { get; set; }
        string NameDB { get; set; }
        string NameTable{ get; set; }
        public int SatrtIndex { get; set; } = 1;
        public int EndIndex { get; set; }
        public RandomValueFromTable(string path, string dbname)
        {
            PathDB = path;
            NameDB = dbname;
            ReceivingDataFromSQlite receivingDataFromSQlite = new ReceivingDataFromSQlite(PathDB, NameDB);
            NameTable = receivingDataFromSQlite.GetTablesNames()[0];
            connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = PathDB + NameDB;
            GetCountDB();
        }
        void GetCountDB(string tablename = "Values1")
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand($"SELECT COUNT(*) FROM {NameTable}", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                query.Read();
                int x = 0;
                int.TryParse(query.GetString(0).ToString(), out x);
                EndIndex = x;
                db.Close(); 
            }
        }

        public Values GetRandomValues(string tablename = "Values1")
        {
            //int random = rnd.Next(SatrtIndex, EndIndex); 

            int random = SatrtIndex++;
            try
            {
                Values values;
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    SqliteCommand selectCommand = new SqliteCommand($"SELECT eng, engt, rus   FROM {NameTable} WHERE id={random}", connection);
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
