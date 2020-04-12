using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    [TestClass]
    public class IsStringConsistsOfDigitsOrEnglishCharactersTests
    {
        [TestMethod]
        public void Not_english_character_or_digit()
        {
            bool result = PasswordStrength.Program.IsStringConsistsOfDigitsOrEnglishCharacters("abc1á");
            Assert.IsFalse(result);
            result = PasswordStrength.Program.IsStringConsistsOfDigitsOrEnglishCharacters("ab c");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void String_consists_of_digits_and_english_characters()
        {
            bool result = PasswordStrength.Program.IsStringConsistsOfDigitsOrEnglishCharacters("abc1");
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfDigitsTests
    {
        [TestMethod]
        public void Number_of_digits_is_multiplied_by_four()
        {
            int expected = 12;
            int result = PasswordStrength.Program.ConsideringTheNumberOfDigits("ab12d4");
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfUppercaseCharactersTests
    {
        [TestMethod]
        public void String_consists_of_one_uppercase_character()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfUppercaseCharacters("P");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_of_one_lowercase_character()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfUppercaseCharacters("p");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Ñalculat_value_considering_the_number_of_letters_in_uppercase()
        {
            int expected = 10;
            int result = PasswordStrength.Program.ConsideringTheNumberOfUppercaseCharacters("PaSSword");
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfLowercaseCharactersTests
    {
        public void String_consists_of_one_uppercase_character()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfLowercaseCharacters("P");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_of_one_lowercase_character()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfLowercaseCharacters("p");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Ñalculat_value_considering_the_number_of_letters_in_lowercase()
        {
            int expected = 6;
            int result = PasswordStrength.Program.ConsideringTheNumberOfLowercaseCharacters("PaSSword");
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringIfThePasswordConsistsOfLettersOnlyTests
    {
        [TestMethod]
        public void String_consists_not_only_of_letters_the_password_strength_is_not_changed()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfLettersOnly("PaSSword1");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_only_of_letters_the_password_strength_is_changed()
        {
            int expected = -8;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfLettersOnly("PaSSword");
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringIfThePasswordConsistsOfDigitsOnlyTests
    {
        [TestMethod]
        public void String_consists_not_only_of_digits_the_password_strength_is_not_changed()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfDigitsOnly("Password123");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_consists_only_of_digits_the_password_strength_is_changed()
        {
            int expected = -3;
            int result = PasswordStrength.Program.ConsideringIfThePasswordConsistsOfDigitsOnly("123");
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class ConsideringTheNumberOfRepeatedCharactersTests
    {
        [TestMethod]
        public void String_without_duplicate_characters_the_password_strength_is_not_changed()
        {
            int expected = 0;
            int result = PasswordStrength.Program.ConsideringTheNumberOfRepeatedCharacters("Pas123");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void String_with_duplicate_characters_the_password_strength_is_changed()
        {
            int expected = 5;
            int result = PasswordStrength.Program.ConsideringTheNumberOfRepeatedCharacters("Passs123a");
            Assert.AreEqual(expected, result);
        }
    }
}
