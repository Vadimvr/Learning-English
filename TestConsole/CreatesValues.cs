using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class CreatesValues
    {
        public CreatesValues() { }
        public static Values CredeData(string stringFromDB, string path)
        {
            string id = "";
            string rus = "";
            string eng = "";
            int temp = 0;
            for (int i = 0; i < stringFromDB.Length; i++)
            {
                if(stringFromDB[i] == '\t' && id == "")
                {
                    id = stringFromDB.Substring(temp, i);
                    temp = i+1;
                }
                else if(stringFromDB[i] == '\t' && rus == "")
                {
                    rus = stringFromDB.Substring(temp, i-temp);
                    temp = i+1;
                }
                else if (stringFromDB[i] == '\t' && eng == "")
                {
                    eng = stringFromDB.Substring(temp, i - temp);
                    temp = i + 1;
                    break;
                }
            }
         
            return new Values(rus,eng, stringFromDB[temp..], new PathToMultimedia(id, path));
        }
    }
}
