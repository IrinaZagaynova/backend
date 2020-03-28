using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class ParseArgsTests
    {
        [TestMethod]
        public void Invalid_number_of_args()
        {
            string[] str = { "input.txt", "output.txt", "smth" }; ;
            string parameter = "";
            bool result = RemoveExtraBlanks.Program.ParseArgs(str, ref parameter, ref parameter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Correct_number_of_args()
        {
            string[] str = { "input.txt", "output.txt"}; ;
            string parameter = "";
            bool result = RemoveExtraBlanks.Program.ParseArgs(str, ref parameter, ref parameter);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class RemoveExtraSpacesTests
    {
        [TestMethod]
        public void Remove_duplicate_spaces_and_tabs()
        {
            string str = " string    with    extra spaces ";
            string expectedStr = " string with extra spaces ";
            string resultStr = RemoveExtraBlanks.Program.RemoveRepetitiveSpaces(str);
            Assert.AreEqual(expectedStr, resultStr);
        }
    }

    [TestClass]
    public class RemoveExtraBlanksInLineTest
    {
        [TestMethod]
        public void Remove_spaces_and_tabs_from_the_beginning_and_end_of_line()
        {
            string str = "   string    with    extra spaces";
            string expectedStr = "string with extra spaces";
            RemoveExtraBlanks.Program.RemoveExtraBlanksInLine(ref str);
            Assert.AreEqual(expectedStr, str);
        }
    }
}
