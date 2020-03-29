using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    [TestClass]
    public class ParseArgsTests
    {
        [TestMethod]
        public void Invalid_number_of_args()
        {
            string[] str = { "hello", "world" };
            string inputParameter = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref inputParameter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Correct_number_of_args()
        {
            string[] str = { "hello" };
            string inputParameter = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref inputParameter);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class IsCharacterEnglishLetterTests
    {
        [TestMethod]
        public void Digit_not_english_letter()
        {
            char digit = '1';
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter(digit);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Russian_letter_not_english_letter()
        {
            char letter = 'è';
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter(letter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void English_letter()
        {
            char letter = 'a';
            bool result = CheckIdentifier.Program.IsCharacterEnglishLetter(letter);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class IsStringConsistsOfDigitsOrEnglishLettersTests
    {
        [TestMethod]
        public void Empty_string_does_not_contain_inappropriate_characters()
        {
            string str = "";
            bool result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters(str);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Space_is_an_inappropriate_symbol()
        {
            string str = "not identifier";
            bool result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Special_characteris_an_inappropriate_symbol()
        {
            string str = "not*identifier";
            bool result = CheckIdentifier.Program.IsStringConsistsOfDigitsOrEnglishLetters(str);
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void Empty_string_can_not_be_identifier()
        {
            string str = "";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void String_starting_with_a_digit_can_not_be_identifier()
        {
            string str = "1abc";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void String_with_special_character_can_not_be_identifier()
        {
            string str = "ab&c";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Ñorrect_string_can_be_an_identifier()
        {
            string str = "abc123";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.IsTrue(result);
        }
    }
}
