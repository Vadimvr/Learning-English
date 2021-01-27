using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LElWPF.Core.Models
{
    class ListValues
    {
        Random rnd = new Random();
        List<Values> Data;
        
        public ListValues(string path, string dbName)
        {
            Data = new List<Values>();
            
            CreadeData(path, dbName);
        }
        void CreadeData(string path, string dbName)
        {
            StreamReader sr = new StreamReader(path + dbName, Encoding.UTF8);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Data.Add(CreatesValues.CredeData(s, path));
            }
            sr.Close();
        }
        public Values GetRandomValues()
        {
            return Data[rnd.Next(0, Data.Count)];
        }

        
    }
}

