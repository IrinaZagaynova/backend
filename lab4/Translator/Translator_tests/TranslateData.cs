using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator
{
    public static class TranslateData
    {
        public static bool IsItEnglish(string word)
        {
            word = word.ToLower();
            foreach (char ch in word)
            {
                if ((ch < 'a' || ch > 'z') && (ch != ' '))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsItRussian(string word)
        {
            word = word.ToLower();
            foreach (char ch in word)
            {
                if ((ch < 'а' || ch > 'я') && (ch != 'ё') && (ch != ' '))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool TranslateEnglishToRussian(string word, ref string translatedWord)
        {
            StreamReader dictionary = new StreamReader("../../../../Dictionary.txt");
            String line;
            while ((line = dictionary.ReadLine()) != null)
            {
                if (word == line)
                {
                    translatedWord = dictionary.ReadLine();
                    return true;
                }
                else
                {
                    line = dictionary.ReadLine();
                }
            }
            dictionary.Close();
            return false;
        }

        public static bool TranslateRussianToEnglish(string word, ref string translatedWord)
        {
            StreamReader dictionary = new StreamReader("../../../../Dictionary.txt");
            String line;
            String previousLine = "";
            while ((line = dictionary.ReadLine()) != null)
            {
                previousLine = line;
                line = dictionary.ReadLine();
                if (word == line)
                {
                    translatedWord = previousLine;
                    return true;
                }
            }
            dictionary.Close();
            return false;
        }

        public static bool TranslateTheWord(string word, ref string translatedWord)
        {
            if (IsItEnglish(word))
            {
                if (!TranslateEnglishToRussian(word, ref translatedWord))
                {
                    return false;
                }
            }
            else if (IsItRussian(word))
            {
                if (!TranslateRussianToEnglish(word, ref translatedWord))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
