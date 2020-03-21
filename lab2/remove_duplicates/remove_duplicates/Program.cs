using System;
using System.Linq;

namespace remove_duplicates
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Incorrect number of arguments!");
                System.Console.WriteLine("Usage remove_duplicates.exe <input string>");
                return 1;
            }
            string inputString = args[0];
            inputString = new string(inputString.Distinct().ToArray());
            System.Console.WriteLine(inputString);
            return 0;
        }
    }
}
