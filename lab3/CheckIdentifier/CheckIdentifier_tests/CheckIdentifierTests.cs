using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifier_tests
{
    [TestClass]
    public class CheckParseArgs_tests
    {
        [TestMethod]
        public void ParseArgs_NilArgs_Test()
        {
            string[] str = { };
            string inputParameter = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref inputParameter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ParseArgs_TwoArgs_Test()
        {
            string[] str = { "hello", "world" };
            string inputParameter = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref inputParameter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ParseArgs_OneArgs_Test()
        {
            string[] str = { "hello" };
            string inputParameter = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref inputParameter);
            Assert.IsTrue(result);
        }

    }

    [TestClass]
    public class CheckIsCharacterEnglishLetter_tests
    {

        [TestMethod]
        public void IsCharacterEnglishLetter_Number_Test()
        {
            char number = '1';
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter(number);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCharacterEnglishLetter_RussianLetter_Test()
        {
            char letter = 'è';
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter(letter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCharacterEnglishLetter_EnglishLetter_Test()
        {
            char letter = 'a';
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter(letter);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class CheckIsStringConsistsOfNumbersOrEnglishLetters_tests
    {

        [TestMethod]
        public void IsStringConsistsOfNumbersOrEnglishLetters_EmptyString_Test()
        {
            string str = "";
            bool result = CheckIdentifier.Program.IsStringConsistsOfNumbersOrEnglishLetters(str);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStringConsistsOfNumbersOrEnglishLetters_StringWithSpace_Test()
        {
            string str = "not identifier";
            bool result = CheckIdentifier.Program.IsStringConsistsOfNumbersOrEnglishLetters(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStringConsistsOfNumbersOrEnglishLetters_StringWithSpecialCharacter_Test()
        {
            string str = "not*identifier";
            bool result = CheckIdentifier.Program.IsStringConsistsOfNumbersOrEnglishLetters(str);
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class CheckCheckIdentifier_tests
    {
        [TestMethod]
        public void CheckIdentifier_EmptyString_Test()
        {
            string str = "";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIdentifier_StringStartingWithDigit_Test()
        {
            string str = "1abc";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIdentifier_StringWithSpecialCharacter_Test()
        {
            string str = "ab&c";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIdentifier_CorrectString_Test()
        {
            string str = "abc123";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsTrue(result);
        }
    }
}
