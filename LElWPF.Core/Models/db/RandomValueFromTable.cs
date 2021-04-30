using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace LElWPF.Core.Models.db
{
    class RandomValueFromTable
    {
        Random rnd = new Random();
        string PathDB { get; set; }
        string NameDB { get; set; }
        public bool Accidentally { get; set; } = true;
        int random;
        public int Index { get => random; }
        public int PandomInt { get => random; private set => random = value; }
        string nameTable;
        public string NameTable
        {
            get => nameTable;
            set
            {
                nameTable = value;
                GetCountDB();
                //EndIndex = maxEndIndex;
                //StartIndex = 1;
            }
        }
        public ObservableCollection<string> NamesTable { get; set; }

        int startIndex = 1;
        public int StartIndex
        {

            get => startIndex;
            set
            {
                if (value < 1)
                    value = 1;
                if (value > endIndex)
                {
                    if (value <= maxEndIndex)
                    {
                        EndIndex = value;
                    }
                    else
                    {
                        value = maxEndIndex;
                        EndIndex = value;
                    }
                }
                startIndex = value;
            }
        }

        int maxEndIndex;
        public int MaxEndIndex { get => maxEndIndex; }
        int endIndex;
        public int EndIndex
        {
            get => endIndex;
            set
            {
                if (value > maxEndIndex)
                {
                    value = maxEndIndex;
                }

                if (value < startIndex)
                {
                    if (value >= 1)
                    {
                        startIndex = value;
                    }
                    else
                    {
                        value = 1;
                        StartIndex = value;
                    }
                }
                endIndex = value;
            }
        }
        public RandomValueFromTable(string path, string dbname)
        {
            PathDB = path;
            NameDB = dbname;
            ReceivingDataFromSQlite receivingDataFromSQlite = new ReceivingDataFromSQlite(PathDB, NameDB);
            NamesTable = new ObservableCollection<string>(receivingDataFromSQlite.GetTablesNames());
            try
            {
                NameTable = NamesTable[0];
                //  GetCountDB();
                if (maxEndIndex != 0)
                    StartIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Db error");
            }

        }
        public RandomValueFromTable(string nameTAble)
        {
            NameTable = nameTAble;
            GetCountDB();
        }

        void GetCountDB()
        {
            try
            {
                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    SqliteCommand selectCommand = new SqliteCommand($"SELECT COUNT(*) FROM {NameTable}", db);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    query.Read();
                    maxEndIndex = 0;
                    int.TryParse(query.GetString(0).ToString(), out maxEndIndex);
                    if (maxEndIndex != 0)
                    {
                        EndIndex = maxEndIndex;
                    }
                    else
                    {
                        MessageBox.Show("Error in db");
                    }
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        public Values GetRandomValues(string nametable)
        {
            NameTable = nametable;
            StartIndex = 1;
            GetCountDB();
            return GetRandomValues();
        }

        public Values GetRandomValues()
        {
            random = rnd.Next(StartIndex, EndIndex + 1);
            return GetValues(random);
        }
        public Values GetNextValues()
        {
            random = random + 1 <= EndIndex ? random < StartIndex ? StartIndex : random + 1 : StartIndex;
            return GetValues(random);
        }
        Values GetValues(int inex)
        {
            try
            {
                Values values;
                using (SqliteConnection db = new SqliteConnection($"Filename={PathDB + NameDB}"))
                {
                    db.Open();
                    SqliteCommand selectCommand = new SqliteCommand($"SELECT eng, engt, rus   FROM {NameTable} WHERE id={inex}", db);
                    SqliteDataReader query = selectCommand.ExecuteReader();
                    query.Read();
                    values = new Values(query.GetString(0), query.GetString(1), query.GetString(2), PathDB);
                    db.Close();
                }
                return values;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                StartIndex = 1;
                return new Values("", "", ex.Message, PathDB);
            }
        }
    }
}
