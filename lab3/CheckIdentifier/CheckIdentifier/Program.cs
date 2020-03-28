using System;

namespace CheckIdentifier
{
    public static class Program
    {
        public static bool ParseArgs(string[] args, ref string inputParameter)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("no");
                System.Console.WriteLine("Incorrect number of arguments!");
                System.Console.WriteLine("Usage CheckIdentifier.exe <input string>");
                return false;
            }
            inputParameter = args[0];
            return true;
        }

        public static bool IsCharacterEnglishLetter(char character)
        {
            if ((character >= 'A') && (character <= 'Z') || (character >= 'a') && (character <= 'z'))
            {
                return true;
            }
            return false;
        }

        public static bool IsStringConsistsOfDigitsOrEnglishLetters(string inputParameter)
        {
            for (int i = 0; i < inputParameter.Length; i++)
            {
                if (!(IsCharacterEnglishLetter(inputParameter[i]) || char.IsDigit(inputParameter[i])))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckIdentifier(string inputParameter)
        {
            if (inputParameter == "")
            {
                System.Console.WriteLine("no");
                System.Console.WriteLine("The identifier can't be an empty string");
                return false;
            }
            if (!IsCharacterEnglishLetter(inputParameter[0]))
            {
                System.Console.WriteLine("no");
                System.Console.WriteLine("The identifier must begin with a letter");
                return false;
            }
            if (!IsStringConsistsOfDigitsOrEnglishLetters(inputParameter.Substring(1)))
            {
                System.Console.WriteLine("no");
                System.Console.WriteLine("The first character may be followed by letters and/or digits.");
                return false;
            }
            System.Console.WriteLine("yes");
            return true;
        }

        public static int Main(string[] args)
        {
            string inputParameter = "";
            if (!ParseArgs(args, ref inputParameter))
            {
                return 1;
            }
            CheckIdentifier(inputParameter);

            return 0;
        }
    }
}
