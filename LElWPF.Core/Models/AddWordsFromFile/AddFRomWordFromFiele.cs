using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace LElWPF.Core.Models.AddWordsFromFile
{
    static class AddFRomWordFromFiele
    {
        internal static void AddListWordFromFile(string FullPathtoFail, string tableName, string fullPathToDB)
        {
            System.Text.StringBuilder exseption = new StringBuilder();
            List<WordS> values = new List<WordS>();
            StreamReader sr = new StreamReader(FullPathtoFail);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                if (s != string.Empty)
                {
                    values.Add(new WordS(s, sr.ReadLine()));
                }
            }
            sr.Close();
            string path = fullPathToDB;
            using (SqliteConnection db = new SqliteConnection($"Filename={path}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand($"SELECT eng, engt, rus   FROM {tableName}", db);
                try
                {
#pragma warning disable S1481 // Unused local variables should be removed
                    SqliteDataReader query = selectCommand.ExecuteReader();
#pragma warning restore S1481 // Unused local variables should be removed
                }
                catch (Exception )
                {
                    var delTableCmd = db.CreateCommand();
                    delTableCmd.CommandText = $"DROP TABLE IF EXISTS '{tableName}'";
                    delTableCmd.ExecuteNonQuery();
                    var createTableCmd = db.CreateCommand();
                    createTableCmd.CommandText = $"CREATE TABLE '{tableName}'(" +
                            "'id'	INTEGER NOT NULL UNIQUE ," +
                            "'eng'  VARCHAR(50) NOT NULL UNIQ" +
                            "UE," +
                            "'engt'  VARCHAR(50)," +
                            "'rus'  VARCHAR(100) NOT NULL," +
                            "PRIMARY KEY('id' AUTOINCREMENT))";
                    createTableCmd.ExecuteNonQuery();
                }

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
                            exseption.Append($"не удалось добавить {values[i].Eng}\n");
                        }
                    }
                    transaction.Commit();
                }
                db.Close();
                MessageBox.Show("Added word\n" + exseption);
            }
        }
    }
}