using System;
using System.Linq;

namespace PasswordStrength
{
    public class Program
    {
        public static bool IsStringConsistsOfDigitsOrEnglishCharacters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!(((password[i] >= 'A') && (password[i] <= 'Z')) || ((password[i] >= 'a') && (password[i] <= 'z')) || char.IsDigit(password[i])))
                {
                    return false;
                }
            }
            return true;
        }

        public static int ConsideringTheNumberOfDigits(string password)
        {
            int passwordStrength = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    passwordStrength++;
                }
            }
            passwordStrength = 4 * passwordStrength;
            return passwordStrength;
        }

        public static int ConsideringTheNumberOfUppercaseCharacters(string password)
        {
            int passwordStrength = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 'A') && (password[i] <= 'Z'))
                {
                    passwordStrength++;
                }                     
            }
            if (passwordStrength != 0)
            {
                passwordStrength = (password.Length - passwordStrength) * 2;
            }
            return passwordStrength;
        }

        public static int ConsideringTheNumberOfLowercaseCharacters(string password)
        {
            int passwordStrength = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 'a') && (password[i] <= 'z'))
                {
                    passwordStrength++;
                }
            }
            if (passwordStrength != 0)
            {
                passwordStrength = (password.Length - passwordStrength) * 2;
            }
            return passwordStrength;
        }

        public static int ConsideringIfThePasswordConsistsOfLettersOnly(string password)
        {
            int passwordStrength = 0;
            bool onlyLetters = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (!((password[i] >= 'A') && (password[i] <= 'Z') || (password[i] >= 'a') && (password[i] <= 'z')))
                {
                    onlyLetters = false;
                }
            }
            if (onlyLetters)
            {
                passwordStrength -= password.Length;
            }
            return passwordStrength;
        }

        public static int ConsideringIfThePasswordConsistsOfDigitsOnly(string password)
        {
            int passwordStrength = 0;
            bool onlyDigits = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsDigit(password[i]))
                {
                    onlyDigits = false;
                }
            }
            if (onlyDigits)
            {
                passwordStrength -= password.Length;
            }            
            return passwordStrength;
        }

        public static int ConsideringTheNumberOfRepeatedCharacters(string password)
        {
            int passwordStrength = 0;
            int count;
            string passworWdithoutRepetition = new string(password.Distinct().ToArray()); 
            for (int i = 0; i < passworWdithoutRepetition.Length; i++)
            {
                count = 0;
                for (int j = 0; j < password.Length; j++)
                {
                    if (passworWdithoutRepetition[i] == password[j])
                    {
                        count++;
                    }
                }
                if (count != 1)
                {
                    passwordStrength += count;
                }
            }
            return passwordStrength;
        }

        public static int GetPasswordStrength(string password)
        {
            int passwordStrength = 0;
            passwordStrength = 4 * password.Length;
            
            passwordStrength += ConsideringTheNumberOfDigits(password);
            
            passwordStrength += ConsideringTheNumberOfUppercaseCharacters(password);
            
            passwordStrength += ConsideringTheNumberOfLowercaseCharacters(password);
            
            passwordStrength += ConsideringIfThePasswordConsistsOfLettersOnly(password);
            
            passwordStrength += ConsideringIfThePasswordConsistsOfDigitsOnly(password);
            
            passwordStrength -= ConsideringTheNumberOfRepeatedCharacters(password);
            
            return passwordStrength;
        }

        public static bool ParseArgs(string[] args, ref string password)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Incorrect number of arguments!");
                System.Console.WriteLine("Usage PasswordStrength.exe <input string>");
                return false;
            }
            password = args[0];
            return true;
        }

        static int Main(string[] args)
        {
            string password = "";
            if (!ParseArgs(args, ref password))
            {
                return 1;
            }
  
            if (!IsStringConsistsOfDigitsOrEnglishCharacters(password))
            {
                System.Console.WriteLine("Password can consist only of English characters and numbers");
                return 1;
            }

            int passwordStrength;
            passwordStrength = GetPasswordStrength(password);
            System.Console.WriteLine(passwordStrength);
            return 0;
        }

    }
}
