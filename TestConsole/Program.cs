
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Start");
            ListValues listValues = new ListValues(@"D:\Test\data.db");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(listValues.r);
            }
            Console.WriteLine(listValues.ToString());
            Console.WriteLine("End");
        }
    }
}
