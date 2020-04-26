using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Translator;

namespace TranslatorTests
{
    [TestClass]
    public class FillInDictionaryTest
    {
        Translator.Dictionary dictionary = new Translator.Dictionary("../../../testDictionary.txt");

        [TestMethod]
        public void Filling_in_identical_dictionary()
        {
            Dictionary<string, string> testDictionary = new Dictionary<string, string>();
            testDictionary = dictionary.FillInDictionary("../../../testDictionary.txt");

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>
            {
                { "cat", "кот" },
                { "day", "день" },
                { "good morning", "доброе утро" },
            };

            CollectionAssert.AreEquivalent(expectedDictionary, testDictionary);
        }
    }

    [TestClass]
    public class TranslateWordTest
    {
        Translator.Dictionary dictionary = new Translator.Dictionary("../../../testDictionary.txt");

        [TestMethod]
        public void Returns_translation_of_English_word_recorded_in_dictionary()
        {
            string translation = dictionary.TranslateWord("cat");
            Assert.AreEqual("кот", translation);
        }

        [TestMethod]
        public void Returns_translation_of_Russian_word_recorded_in_dictionary()
        {
            string translation = dictionary.TranslateWord("день");
            Assert.AreEqual("day", translation);
        }

        [TestMethod]
        public void Returns_null_if_word_is_not_recorded_in_dictionary()
        {
            string translation = dictionary.TranslateWord("unknown word");
            Assert.AreEqual(null, translation);
        }
    }
}
