using System;

namespace PrintArgs
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                System.Console.WriteLine("Number of arguments: " + args.Length);
                System.Console.Write("Arguments: " + String.Join(" ", args));
            }
            else
            {
                System.Console.WriteLine("No parameters were specified!");
                return 1;
            }
            return 0;
        }
    }
}
