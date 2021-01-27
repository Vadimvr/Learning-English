using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestConsole
{
    class ListValues
    {
        List<Values> Data;
        CreatesValues createsListValues;
        public ListValues(string path)
        {
            Data = new List<Values>();
            createsListValues = new CreatesValues();
            CreadeData(path);
        }
         void CreadeData(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Data.Add(CreatesValues.CredeData(s, path));
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in Data)
            {
               
                s += item.ToString();
            }
            return s;
        }
    }
}
