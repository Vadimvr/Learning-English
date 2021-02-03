using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models.db
{
    class TableInDB
    {
        public string NameTable { get; set; }
        public List<Values> Values { get; set; }
        public TableInDB(string nameTable, List<Values> values)
        {
            NameTable = nameTable;
            Values = values;
        }
    }
}
