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
        CreatesValues createsListValues;
        public ListValues(string path)
        {
            Data = new List<Values>();
            createsListValues = new CreatesValues();
            CreadeData(path);
        }
        void CreadeData(string path)
        {
            StreamReader sr = File.OpenText(path);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Data.Add(CreatesValues.CredeData(s, path));
            }
        }
        public Values GetRandomValues()
        {
            return Data[rnd.Next(0, Data.Count)];
        }
    }
}
