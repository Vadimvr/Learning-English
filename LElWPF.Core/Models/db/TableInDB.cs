using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models.db
{
    class TableInDB
    {
        public string NameTable { get; set; }
        public List<Values> Values { get; set; }

         string Path { get; set; }
        string Name { get; set; }
        СreationTableInDB СreationTable { get; set; }
        public TableInDB(string nameTable, List<Values> values, string path, string name, СreationTableInDB сreationTableInDB)
        {
            Path = path;
            Name = name;
            NameTable = nameTable;
            Values = values;
            СreationTable = сreationTableInDB;
        }
        public void SeveTable()
        {
            СreationTable.СreationTable(NameTable);
        }
       
    }
}
