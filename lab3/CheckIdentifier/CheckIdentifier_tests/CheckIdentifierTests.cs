using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    [TestClass]
    public class IsCharacterEnglishLetterTests
    {
        [TestMethod]
        public void Not_english_letter()
        {
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter('1');
            Assert.IsFalse(result);
            result = CheckIdentifier.Program.IsCharacterEnglishLetter('è');
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void English_letter()
        {
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter('b');
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class IsStringConsistsOfDigitsOrEnglishLettersTests
    {
        [TestMethod]
        public void Does_not_contain_inappropriate_characters()
        {

            bool result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters("");
            Assert.IsTrue(result);
            result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters("123");
            Assert.IsTrue(result);
            result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters("word");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contain_inappropriate_characters()
        {
            bool result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters("not identifier");
            Assert.IsFalse(result);
            result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters("not*identifier");
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void Can_not_be_identifier()
        {
            bool result = CheckIdentifier.Program.CheckIdentifier("");
            Assert.IsFalse(result);
            result = CheckIdentifier.Program.CheckIdentifier("1abc");
            Assert.IsFalse(result);
            result = CheckIdentifier.Program.CheckIdentifier("ab&c");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Ñorrect_string_can_be_an_identifier()
        {
            bool result = CheckIdentifier.Program.CheckIdentifier("abc123");
            Assert.IsTrue(result);
        }
    }
}
