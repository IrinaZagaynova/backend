using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Models
{
    public class Dictionary
    {
        public static Dictionary<string, string> FillInDictionary(string dictionaryFileName)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            StreamReader dictionaryFile = new StreamReader(dictionaryFileName);
            string firstLine, secondLine;

            while (((firstLine = dictionaryFile.ReadLine()) != null) && ((secondLine = dictionaryFile.ReadLine()) != null))
            {
                dictionary.Add(firstLine, secondLine);
            }

            return dictionary;
        }

        public static bool IsItEnglish(string word)
        {
            foreach (char ch in word)
            {
                if ((ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z') && (ch != ' '))
                {
                    return false;
                }
            }
            return true;
        }

        public static string TranslateFromEnglishToRussian(string word, Dictionary<string, string> dictionary)
        {
            string translation = null;
            foreach (KeyValuePair<string, string> keyValue in dictionary)
            {
                if (keyValue.Key == word)
                {
                    translation = keyValue.Value;
                }
            }
            return translation;
        }

        public static string TranslateFromRussianToEnglish(string word, Dictionary<string, string> dictionary)
        {
            string translation = null;
            foreach (KeyValuePair<string, string> keyValue in dictionary)
            {
                if (keyValue.Value == word)
                {
                    translation = keyValue.Key;
                }
            }
            return translation;
        }

        public static bool TranslateWord(string word, ref string translation, Dictionary<string, string> dictionary)
        {
            if (IsItEnglish(word))
            {
                translation = TranslateFromEnglishToRussian(word, dictionary);
                if (translation == null)
                {
                    return false;
                }
                return true;
            }
            else 
            {
                translation = TranslateFromRussianToEnglish(word, dictionary);
                if (translation == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}