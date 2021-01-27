
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            ListValues listValues = new ListValues(@"D:\Test\data.db");
            listValues.PrintList();

            Console.WriteLine("End");
        }
    }
}
