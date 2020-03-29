using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    [TestClass]
    public class CheckParseArgsTests
    {
        [TestMethod]
        public void Incorrect_number_of_args()
        {
            string[] str = { "password", "password" };
            string password = "";
            bool result = PasswordStrength.Program.ParseArgs(str, ref password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Correct_number_of_args()
        {
            string[] str = { "password" };
            string password = "";
            bool result = PasswordStrength.Program.ParseArgs(str, ref password);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class IsStringConsistsOfDigitsOrEnglishCharactersTests
    {
        [TestMethod]
        public void Russian_letter_is_not_english_character_or_digit()
        {
            string str = "abc1á";
            bool result = PasswordStrength.Program.IsStringConsistsOfDigitsOrEnglishCharacters(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Space_letter_is_not_english_character_or_digit()
        {
            string str = "ab c";
            bool result = PasswordStrength.Program.IsStringConsistsOfDigitsOrEnglishCharacters(str);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void String_consists_of_digits_and_english_characters()
        {
            string str = "abc1";
            bool result = PasswordStrength.Program.IsStringConsistsOfDigitsOrEnglishCharacters(str);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfDigitsTests
    {
        [TestMethod]
        public void Number_of_digits_is_multiplied_by_four()
        {
            string str = "ab12d4";
            int expected = 12;
            int result = PasswordStrength.Program.ConsideringTheNumberOfDigits(str);
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfUppercaseCharactersTests
    {
        [TestMethod]
        public void String_consists_of_one_uppercase_character()
        {
            string str = "P";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfUppercaseCharacters(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_of_one_lowercase_character()
        {
            string str = "p";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfUppercaseCharacters(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Ñalculat_value_considering_the_number_of_letters_in_uppercase()
        {
            string str = "PaSSword";
            int expected = 10;
            int result = PasswordStrength.Program.ConsideringTheNumberOfUppercaseCharacters(str);
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfLowercaseCharactersTests
    {
        public void String_consists_of_one_uppercase_character()
        {
            string str = "P";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfLowercaseCharacters(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_of_one_lowercase_character()
        {
            string str = "p";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfLowercaseCharacters(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Ñalculat_value_considering_the_number_of_letters_in_lowercase()
        {
            string str = "PaSSword";
            int expected = 6;
            int result = PasswordStrength.Program.ConsideringTheNumberOfLowercaseCharacters(str);
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringIfThePasswordConsistsOfLettersOnlyTests
    {
        [TestMethod]
        public void String_consists_not_only_of_letters_the_password_strength_is_not_changed()
        {
            string str = "PaSSword1";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfLettersOnly(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_only_of_letters_the_password_strength_is_changed()
        {
            string str = "PaSSword";
            int expected = -8;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfLettersOnly(str);
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringIfThePasswordConsistsOfDigitsOnlyTests
    {
        [TestMethod]
        public void String_consists_not_only_of_digits_the_password_strength_is_not_changed()
        {
            string str = "Password123";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfDigitsOnly(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_only_of_digits_the_password_strength_is_changed()
        {
            string str = "123";
            int expected = -3;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfDigitsOnly(str);
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfRepeatedCharactersTests
    {
        [TestMethod]
        public void String_without_duplicate_characters_the_password_strength_is_not_changed()
        {
            string str = "Pas123";
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfRepeatedCharacters(str);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_with_duplicate_characters_the_password_strength_is_changed()
        {
            string str = "Passs123a";
            int expected = 5;
            int result = PasswordStrength.Program.ConsideringTheNumberOfRepeatedCharacters(str);
            Assert.AreEqual(expected, result);
        }
    }
}
