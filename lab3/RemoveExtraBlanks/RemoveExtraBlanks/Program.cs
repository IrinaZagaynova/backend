using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static bool ParseArgs(string[] args, ref string inputFileName, ref string outputFileName)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("Incorrect number of arguments!");
                System.Console.WriteLine("Usage RemoveExtraBlanks.exe <input file name> <output file name>");
                return false;
            }
            inputFileName = args[0];
            outputFileName = args[1];
            return true;
        }

        public static string RemoveRepetitiveSpaces(string line)
        {
            bool repetitionOfSpaces = false;
            string newLine = "";
            for (int i = 0; i < line.Length; i++)
            {
                if ((line[i] == ' ') || (line[i] == '\t'))
                {
                    if (!repetitionOfSpaces)
                    {
                        newLine = newLine + line[i];
                    }
                    repetitionOfSpaces = true;
                }
                else
                {
                    newLine = newLine + line[i];
                    repetitionOfSpaces = false;
                }
            }
            return newLine;
        }

        public static void RemoveExtraBlanksInLine(ref string line)
        {
            line = line.Trim();
            line = RemoveRepetitiveSpaces(line);
        }

        public static int Main(string[] args)
        {
            string inputFileName = "";
            string outputFileName = "";

            if (!ParseArgs(args, ref inputFileName, ref outputFileName))
            {
                return 1;
            }

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Failed to open " + inputFileName) ;
                return 1;
            }

            StreamReader inputFile = new StreamReader(inputFileName);
            StreamWriter outputFile = new StreamWriter(outputFileName);

            String line;
            while ((line = inputFile.ReadLine()) != null)
            {
                RemoveExtraBlanksInLine(ref line);
                outputFile.WriteLine(line);
            }

            inputFile.Close();
            outputFile.Close();

            return 0;
        }

    }
}
