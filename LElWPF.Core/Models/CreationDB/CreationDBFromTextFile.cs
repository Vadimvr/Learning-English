using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models.CreationDB
{
    class CreationDBFromTextFile
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                ListValues values = new ListValues(@"D:\test\", "data.db");


                SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = @"D:\test\test.db";

                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {

                    connection.Open();
                    //var delTableCmd = connection.CreateCommand();
                    //delTableCmd.CommandText = "DROP TABLE IF EXISTS 'Values1'";
                    //delTableCmd.ExecuteNonQuery();

                    //var createTableCmd = connection.CreateCommand();
                    //createTableCmd.CommandText = "CREATE TABLE 'Values1'(" +
                    //        "'id'	INTEGER NOT NULL UNIQUE ," +
                    //        "'eng'  VARCHAR(50) NOT NULL UNIQUE," +
                    //        "'engt'  VARCHAR(50)," +
                    //        "'rus'  VARCHAR(100) NOT NULL," +
                    //        "PRIMARY KEY('id' AUTOINCREMENT))";
                    //createTableCmd.ExecuteNonQuery();


                    //using (var transaction = connection.BeginTransaction())
                    //{

                    //    //values.Data.Count Values v = values.Data[i];
                    //    for (int i = 0; i < values.Data.Count; i++)
                    //    {
                    //        var insertCmd = connection.CreateCommand();
                    //        insertCmd.CommandText = "INSERT INTO [Values1] ([eng], [engt], [rus])"
                    //            + $"VALUES('{values.Data[i].Eng}', '{values.Data[i].EngTranscription}', '{values.Data[i].Rus}')";
                    //        try
                    //        {
                    //            insertCmd.ExecuteNonQuery();
                    //        }
                    //        catch (Microsoft.Data.Sqlite.SqliteException)
                    //        {

                    //            Console.WriteLine($"не удалось добавить {values.Data[i].Eng}");
                    //        }

                    //    }
                    //    transaction.Commit();
                    //}
                    //var selectCmd = connection.CreateCommand();
                    //selectCmd.CommandText = "SELECT COUNT(*) FROM Values1";
                    //int x = 0;
                    //int.TryParse(selectCmd.ExecuteScalar().ToString(),out x);
                    //Console.WriteLine(selectCmd.ExecuteScalar());
                    //selectCmd.CommandText = "SELECT eng,rus FROM Values1 WHERE id= 20";
                    //Console.WriteLine(selectCmd.ExecuteScalar());
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = ".table";


                    //Console.WriteLine(selectCmd.ExecuteScalar());

                    //selectCmd.CommandText = "SELECT COUNT(*) FROM Values1";
                    //Console.WriteLine(selectCmd.ExecuteScalar());


                    var eng = connection.CreateCommand();
                    eng.CommandText = $"SELECT eng FROM Values1 WHERE id={2}";
                    var rus = connection.CreateCommand();
                    rus.CommandText = $"SELECT rus FROM Values1 WHERE id={2}";
                    var engt = connection.CreateCommand();
                    engt.CommandText = $"SELECT engt FROM Values1 WHERE id={2}";

                    Console.WriteLine(eng.ExecuteScalar().ToString()
                                    + engt.ExecuteScalar() + rus.ExecuteScalar()); connection.Close();
                    Console.WriteLine("end");
                    Console.ReadKey();

                }
            }
        }
    }
    //CREATE TABLE "Values" (
    //	"id"	INTEGER NOT NULL UNIQUE,
    //	"EnglishWord"	TEXT NOT NULL UNIQUE,
    //	"EngTranscription"	TEXT,
    //	"RusWord"	TEXT NOT NULL,
    //	"PathSong"	TEXT,
    //	"PathImg"	TEXT,
    //    PRIMARY KEY("id" AUTOINCREMENT)
    //);


    //var createTableCmd = connection.CreateCommand();
    //createTableCmd.CommandText = "CREATE TABLE 'Values1'(" +
    //        "'id'	INTEGER NOT NULL UNIQUE ," +
    //        "'EnglishWord'  TEXT NOT NULL UNIQUE," +
    //        "'EngTranscription'  TEXT," +
    //        "'RusWord'  TEXT NOT NULL," +
    //        "'PathSong'  TEXT," +
    //        "'PathImg'   TEXT," +
    //        "PRIMARY KEY('id' AUTOINCREMENT))";
    //createTableCmd.ExecuteNonQuery();
}

