using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Translator
{
    public class Dictionary
    {
        Dictionary<string, string> dictionary;
        public Dictionary(string path)
        {
            dictionary = FillInDictionary(path);
        }

        public Dictionary<string, string> FillInDictionary(string path)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            StreamReader dictionaryFile = new StreamReader(path);
            string firstLine, secondLine;

            while (((firstLine = dictionaryFile.ReadLine()) != null) && ((secondLine = dictionaryFile.ReadLine()) != null))
            {
                dictionary.Add(firstLine, secondLine);
            }

            return dictionary;
        }

        bool IsItEnglish(string word)
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

        string TranslateFromEnglishToRussian(string word, Dictionary<string, string> dictionary)
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

        string TranslateFromRussianToEnglish(string word, Dictionary<string, string> dictionary)
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

        public string TranslateWord(string word)
        {
            string translation = null;
            if (IsItEnglish(word))
            {
                translation = TranslateFromEnglishToRussian(word, dictionary);
                return translation;
            }

            translation = TranslateFromRussianToEnglish(word, dictionary);
            return translation;
        }
    }
}
