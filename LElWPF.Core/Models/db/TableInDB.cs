using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LElWPF.Core.Models.db
{
    class TableInDB
    {
        public string NameTable { get; set; }
        public ObservableCollection<Values> Values { get; set; }

         string Path { get; set; }
        string Name { get; set; }
        ReceivingDataFromSQlite СreationTable { get; set; }
        public TableInDB(string nameTable, List<Values> values, string path, string name, ReceivingDataFromSQlite сreationTableInDB)
        {
            Path = path;
            Name = name;
            NameTable = nameTable;
            Values = new ObservableCollection<Values>(values);
            СreationTable = сreationTableInDB;
        }
        public void SeveTable()
        {
            СreationTable.СreationNewTable(NameTable);
            СreationTable.AddValueInTable(new List<Values>(Values), NameTable);
        }
        public void DeleteTable()
        {
            СreationTable.DeleteTable(NameTable);
        }
        

    }
}
