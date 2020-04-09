using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Translator.Models;

namespace TranslatorTests
{
    [TestClass]
    public class FillInDictionaryTest
    {
        [TestMethod]
        public void Filling_in_identical_dictionary()
        {
            Dictionary<string, string> dictionary = Dictionary.FillInDictionary("../../../../Translator/dictionary.txt");
            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>
            {
                { "cat", "кот" },
                { "day", "день" },
                { "good morning", "доброе утро" },
            };

            CollectionAssert.AreEquivalent(expectedDictionary, dictionary);
        }
    }

    [TestClass]
    public class IsItEnglisTests
    {
        [TestMethod]
        public void English_word_returns_true()
        {
            Assert.IsTrue(Dictionary.IsItEnglish("english word"));
        }

        [TestMethod]
        public void Not_English_word_returns_false()
        {
            Assert.IsFalse(Dictionary.IsItEnglish("слово"));
            Assert.IsFalse(Dictionary.IsItEnglish("1234"));
        }
    }

    [TestClass]
    public class TranslateWordTests
    {
        Dictionary<string, string> dictionary = Dictionary.FillInDictionary("../../../../Translator/dictionary.txt");

        [TestMethod]
        public void Returns_translation_of_English_word_recorded_in_dictionary()
        {

            string translation = Dictionary.TranslateFromEnglishToRussian("cat", dictionary);
            Assert.AreEqual("кот", translation);

        }

        [TestMethod]
        public void Returns_translation_of_Russian_word_recorded_in_dictionary()
        {
            string translation = Dictionary.TranslateFromRussianToEnglish("день", dictionary);
            Assert.AreEqual("day", translation);

        }

        [TestMethod]
        public void Returns_translation_of_Russian_and_English_words_recorded_in_dictionary()
        {
            string translation = "";
            Dictionary.TranslateWord("cat", ref translation, dictionary);
            Assert.AreEqual("кот", translation);

            Dictionary.TranslateWord("день", ref translation, dictionary);
            Assert.AreEqual("day", translation);

        }
    }
}
