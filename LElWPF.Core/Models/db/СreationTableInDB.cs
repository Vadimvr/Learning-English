using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models.db
{

    class СreationTableInDB
    {

        string PathDB { get; set; }
        string NameDB { get; set; }
        public СreationTableInDB(string nameTable, string pathDB)
        {
            PathDB = nameTable;
            NameDB = pathDB;
        }
        public void СreationTable(string nameTable)
        {
            try
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    var createTableCmd = db.CreateCommand();
                    createTableCmd.CommandText = $"CREATE TABLE '{nameTable}'(" +
                            "'id'	INTEGER NOT NULL UNIQUE ," +
                            "'eng'  VARCHAR(50) NOT NULL UNIQUE," +
                            "'engt'  VARCHAR(50)," +
                            "'rus'  VARCHAR(100) NOT NULL," +
                            "PRIMARY KEY('id' AUTOINCREMENT))";
                    createTableCmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {

            }
        }
        public List<string> GetTablesName()
        {
            List<string> list = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(" SELECT name  FROM sqlite_master WHERE type = 'table'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                query = selectCommand.ExecuteReader();


                while (query.Read())
                {
                    list.Add(query.GetString(0));
                }

                db.Close();
                return list;
            }
        }
        public void AddetValues(List<Values> values, string TableName)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    var insertCmd = db.CreateCommand();
                    for (int i = 0; i < values.Count; i++)
                    {
                        insertCmd.CommandText = $"INSERT INTO [{TableName}] ([eng], [engt], [rus])"
                            + $"VALUES('{values[i].Eng}', '{values[i].EngTranscription}', '{values[i].Rus}')";
                        try
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException)
                        {
                            Console.WriteLine($"не удалось добавить {values[i].Eng}");
                        }
                    }
                    transaction.Commit();
                }
                db.Close();
            }
        }
    }
}