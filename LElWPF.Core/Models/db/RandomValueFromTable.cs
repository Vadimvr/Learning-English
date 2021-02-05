using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LElWPF.Core.Models.db
{
    class RandomValueFromTable
    {
        Random rnd = new Random();
        string PathDB { get; set; }
        string NameDB { get; set; }
        string nameTable;
        public string NameTable
        {
            get => nameTable;
            set
            {
                nameTable = value;
                GetCountDB();
                StartIndex = 1;
            }
        }
        public ObservableCollection<string> NamesTable { get; set; }

        int startIndex = 1;
        public int StartIndex
        {
            get => startIndex;
            set
            {
                if (value >= 1 && value < EndIndex)
                    startIndex = value;
            }
        } 

        int maxEndIndex;
        int endIndex;
        public int EndIndex
        {
            get => endIndex; set
            {
                if (value > startIndex && value <= maxEndIndex)
                    endIndex = value;
            }
        }
        public RandomValueFromTable(string path, string dbname)
        {
            PathDB = path;
            NameDB = dbname;
            ReceivingDataFromSQlite receivingDataFromSQlite = new ReceivingDataFromSQlite(PathDB, NameDB);
            NamesTable = new ObservableCollection<string>(receivingDataFromSQlite.GetTablesNames());
            NameTable = NamesTable[0];
            GetCountDB();
            StartIndex = 1;
        }
        public RandomValueFromTable(string nameTAble)
        {
            NameTable = nameTAble;
            GetCountDB();
        }

        void GetCountDB()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand($"SELECT COUNT(*) FROM {NameTable}", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                query.Read();
                maxEndIndex = 0;
                int.TryParse(query.GetString(0).ToString(), out maxEndIndex);
                EndIndex = maxEndIndex;
                db.Close();
            }
        }

        public Values GetRandomValues(string nemetable)
        {
            NameTable = nemetable;
            StartIndex = 1;
            GetCountDB();
            return GetRandomValues();
        }

        public Values GetRandomValues()
        {
            try
            {
                int random = rnd.Next(StartIndex, EndIndex);
                Values values;

                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    SqliteCommand selectCommand = new SqliteCommand($"SELECT eng, engt, rus   FROM {NameTable} WHERE id={random}", db);
                    SqliteDataReader query = selectCommand.ExecuteReader();
                    query.Read();
                    values = new Values(query.GetString(0), query.GetString(1), query.GetString(2), PathDB);
                    db.Close();
                }
                return values;
            }
            catch (Exception ex)
            {
                StartIndex = 1;
                return new Values("err", "errr", ex.Message, PathDB);
            }
        }
    }
}
