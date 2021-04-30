using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LElWPF.Core.Models.db
{

    class ReceivingDataFromSQlite
    {

        string PathDB { get; set; }
        string NameDB { get; set; }
        public ReceivingDataFromSQlite(string path, string nameDB)
        {
            PathDB = path;
            NameDB = nameDB;
        }
        public void СreationNewTable(string nameTable)
        {
            try
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    var delTableCmd = db.CreateCommand();
                    delTableCmd.CommandText = $"DROP TABLE IF EXISTS '{nameTable}'";
                    delTableCmd.ExecuteNonQuery();
                    
                    var createTableCmd = db.CreateCommand();
                    createTableCmd.CommandText = $"CREATE TABLE '{nameTable}'(" +
                            "'id' INTEGER NOT NULL UNIQUE ," +
                            "'eng' VARCHAR(50) NOT NULL UNIQUE," +
                            "'engt' VARCHAR(50)," +
                            "'rus' VARCHAR(100) NOT NULL," +
                            "PRIMARY KEY('id' AUTOINCREMENT))";
                    createTableCmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("nanana");
            }
        }

        public void DeleteTable(string nameTable)
        {
            try
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    var delTableCmd = db.CreateCommand();
                    delTableCmd.CommandText = $"DROP TABLE IF EXISTS '{nameTable}'";
                    delTableCmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                Console.WriteLine("nanana");
            }
        }

        public List<string> GetTablesNames()
        {
            List<string> list = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(" SELECT name  FROM sqlite_master WHERE type = 'table'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    if (query.GetString(0) == "sqlite_sequence")
                        continue;
                    list.Add(query.GetString(0));
                }
                db.Close();
                return list;
            }
        }
        public void AddValueInTable(List<Values> values, string tableName)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {

                    var insertCmd = db.CreateCommand();
                    for (int i = 0; i < values.Count; i++)
                    {
                        insertCmd.CommandText = $"INSERT INTO [{tableName}] ([eng], [engt], [rus])"
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

        public List<Values> GetAllValuesFromTable(string nameTable)
        {
            List<Values> values = new List<Values>();
            try
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    SqliteCommand selectCommand = new SqliteCommand($"SELECT eng, engt, rus   FROM {nameTable}", db);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        values.Add(new Values(query.GetString(0), query.GetString(1), query.GetString(2), PathDB));
                    }
                    db.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
            return values;
        }

        public  ObservableCollection<TableInDB> GetTheWholeDB(ReceivingDataFromSQlite сreationTableInDB)
        {
            ObservableCollection<TableInDB> temp = new ObservableCollection<TableInDB>();
            foreach (string item in GetTablesNames())
            {
                temp.Add(new TableInDB(item, GetAllValuesFromTable(item), PathDB,NameDB, сreationTableInDB));
            }
            return temp;
        }
        
    }
}