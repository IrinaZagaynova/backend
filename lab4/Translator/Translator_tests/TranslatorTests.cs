using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslatorTests
{
    [TestClass]
    public class IsItEnglishTests
    {
        [TestMethod]
        public void English_word_return_true()
        {
            string str = "day";
            bool result = Translator.TranslateData.IsItEnglish(str);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Not_english_word_return_false()
        {
            string str = "אבג";
            bool result = Translator.TranslateData.IsItEnglish(str);
            Assert.IsFalse(result);

            str = "1";
            result = Translator.TranslateData.IsItEnglish(str);
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class IsItRussianTests
    {
        [TestMethod]
        public void Russian_word_return_true()
        {
            string str = "אבג";
            bool result = Translator.TranslateData.IsItRussian(str);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Not_russian_word_return_false()
        {
            string str = "abfj";
            bool result = Translator.TranslateData.IsItRussian(str);
            Assert.IsFalse(result);

            str = "1";
            result = Translator.TranslateData.IsItRussian(str);
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class TranslateEnglishToRussianTests
    {
        [TestMethod]
        public void Translates_the_word_that_is_in_the_dictionary()
        {
            string str = "day";            
            string expectedStr = "הוםü";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateEnglishToRussian(str, ref translatedStr);
            Assert.IsTrue(result);
            Assert.AreEqual(expectedStr, translatedStr);
        }

        [TestMethod]
        public void Translates_the_word_that_is_in_the_dictionary_return_false()
        {
            string str = "word";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateEnglishToRussian(str, ref translatedStr);
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class TranslateRussianToEnglishTests
    {
        [TestMethod]
        public void Translates_the_word_that_is_in_the_dictionary()
        {
            string str = "הוםü";
            string expectedStr = "day";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateRussianToEnglish(str, ref translatedStr);
            Assert.IsTrue(result);
            Assert.AreEqual(expectedStr, translatedStr);
        }

        [TestMethod]
        public void Translates_the_word_that_is_in_the_dictionary_return_false()
        {
            string str = "אבג";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateRussianToEnglish(str, ref translatedStr);
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class TranslateTheWordTests
    {
        [TestMethod]
        public void Translates_the_word_that_is_in_the_dictionary()
        {
            string str = "הוםü";
            string expectedStr = "day";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateTheWord(str, ref translatedStr);
            Assert.IsTrue(result);
            Assert.AreEqual(expectedStr, translatedStr);

            str = "day";
            expectedStr = "הוםü";
            translatedStr = "";
            result = Translator.TranslateData.TranslateEnglishToRussian(str, ref translatedStr);
            Assert.IsTrue(result);
            Assert.AreEqual(expectedStr, translatedStr);
        }

        [TestMethod]
        public void Translates_the_word_that_is_in_the_dictionary_return_false()
        {
            string str = "אבג";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateTheWord(str, ref translatedStr);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Try_to_translate_not_Russian_and_not_English_word_return_false()
        {
            string str = "dayהוםü";
            string translatedStr = "";
            bool result = Translator.TranslateData.TranslateTheWord(str, ref translatedStr);
            Assert.IsFalse(result);
        }
    }
}
