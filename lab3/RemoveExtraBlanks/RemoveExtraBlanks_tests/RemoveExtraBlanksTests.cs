using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveRepetitiveSpacesTests
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
            str = RemoveExtraBlanks.Program.RemoveExtraBlanksInLine(str);
            Assert.AreEqual(expectedStr, str);
        }
    }
}
