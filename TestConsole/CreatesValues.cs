using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    internal class CreatesValues
    {
        public CreatesValues() { }
        public static Values CredeData(string stringFromDB, string path)
        {
            string id = "";
            string rus = "";
            string eng = "";
            string engT = "";
            int temp = 0;
            for (int i = 0; i < stringFromDB.Length; i++)
            {
                if (stringFromDB[i] == '\t' && eng == "")
                {
                    eng = stringFromDB.Substring(temp, i);
                    temp = i + 1;
                }
                else if (stringFromDB[i] == '\t' && engT == "")
                {
                    engT = stringFromDB.Substring(temp, i - temp);
                    temp = i + 1; break;
                }
            }
            return new Values(stringFromDB[temp..].Trim(), eng, engT);
        }
    }
}
