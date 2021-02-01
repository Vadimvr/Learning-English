using System;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        private static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Note: This sample requires the database to be created before running.

                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
            
                var blog =from i in db.Blogs 
                          where i.BlogId == 5  
                          select i;


                foreach (var item in db.Blogs)
                {
                    Console.WriteLine(item.BlogId);
                }
                // Update
                Console.WriteLine("Updating the blog and adding a post");
                //blog.Url = "https://devblogs.microsoft.com/dotnet";
                //blog.Posts.Add(
                //    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                //db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
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


//Console.OutputEncoding = Encoding.UTF8;
//ListValues values = new ListValues(@"D:\test\", "data.db");


//var connectionStringBuilder = new SqliteConnectionStringBuilder();
//connectionStringBuilder.DataSource = @"D:\test\test.db";

//using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
//{

//    connection.Open();
//    var delTableCmd = connection.CreateCommand();
//    delTableCmd.CommandText = "DROP TABLE IF EXISTS 'Values1'";
//    delTableCmd.ExecuteNonQuery();

//    var createTableCmd = connection.CreateCommand();
//    createTableCmd.CommandText = "CREATE TABLE 'Values1'(" +
//            "'id'	INTEGER NOT NULL UNIQUE ," +
//            "'eng'  VARCHAR(50) NOT NULL UNIQUE," +
//            "'engt'  VARCHAR(50)," +
//            "'rus'  VARCHAR(100) NOT NULL," +
//            "'paths'  VARCHAR(50)," +
//            "'pathi'   VARCHAR(50)," +
//            "PRIMARY KEY('id' AUTOINCREMENT))";
//    createTableCmd.ExecuteNonQuery();


//    using (var transaction = connection.BeginTransaction())
//    {

//        //values.Data.Count Values v = values.Data[i];
//        for (int i = 0; i < values.Data.Count; i++)
//        {
//            var insertCmd = connection.CreateCommand();
//            insertCmd.CommandText = "INSERT INTO [Values1] ([eng], [engt], [rus],[paths],[pathi])"
//                + $"VALUES('{values.Data[i].Eng}', '{values.Data[i].EngTranscription}', '{values.Data[i].Rus}', '{values.Data[i].Song}', '{values.Data[i].Img}')";
//            try
//            {
//                insertCmd.ExecuteNonQuery();
//            }
//            catch (Microsoft.Data.Sqlite.SqliteException)
//            {

//                Console.WriteLine($"не удалось добавить {values.Data[i].Eng}");
//            }

//        }
//        transaction.Commit();
//    }
//    var selectCmd = connection.CreateCommand();
//    selectCmd.CommandText = "SELECT COUNT(*) FROM Values1";
//    Console.WriteLine(selectCmd.ExecuteScalar());
//    selectCmd.CommandText = "SELECT eng,rus FROM Values1 WHERE id= 20";
//    Console.WriteLine(selectCmd.ExecuteScalar());



//    selectCmd.CommandText = "SELECT COUNT(*) FROM Values1";
//    Console.WriteLine(selectCmd.ExecuteScalar());
//    connection.Close();