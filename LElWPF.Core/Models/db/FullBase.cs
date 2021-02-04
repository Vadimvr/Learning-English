using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LElWPF.Core.Models.db
{
    class FullBase: ObservableCollection<TableInDB>
    {
        public ObservableCollection<TableInDB> AllTables { get; set; }
        private ReceivingDataFromSQlite сreationTableInDB;

        string Path { get; set; }
        string Name { get; set; }
        public FullBase(string path,string name)
        {
            Path = path;
            Name = name;
            сreationTableInDB = new ReceivingDataFromSQlite(path, name);
            AllTables = сreationTableInDB.GetTheWholeDB(сreationTableInDB);
        }

        public FullBase(ObservableCollection<TableInDB> creationTable, string path, string name)
        {
            
            AllTables = creationTable;
        }
        public void AddTable(string nameTable)
        {
            bool temp = true;
            for (int i = 0; i < AllTables.Count; i++)
            {
                if (nameTable == null || AllTables[i].NameTable == nameTable || nameTable.Trim() == "")
                {
                    temp = false;
                }
            }
            if (temp)
                AllTables.Add(new TableInDB(nameTable, new List<Values>(), Path,Name, сreationTableInDB));
        }
    }
}
