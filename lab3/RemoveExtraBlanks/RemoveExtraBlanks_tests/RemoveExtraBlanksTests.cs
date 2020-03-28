using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanks_tests
{
    [TestClass]
    public class CheckParseArgs_tests
    {
        [TestMethod]
        public void ParseArgs_NilArgs_Test()
        {
            string[] str = { };
            string parameter = "";
            bool result = RemoveExtraBlanks.Program.ParseArgs(str, ref parameter, ref parameter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ParseArgs_ThreeArgs_Test()
        {
            string[] str = { "input.txt", "output.txt", "smth" }; ;
            string parameter = "";
            bool result = RemoveExtraBlanks.Program.ParseArgs(str, ref parameter, ref parameter);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ParseArgs_TwoArgs_Test()
        {
            string[] str = { "input.txt", "output.txt"}; ;
            string parameter = "";
            bool result = RemoveExtraBlanks.Program.ParseArgs(str, ref parameter, ref parameter);
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class CheckRemoveExtraSpaces_tests
    {
        [TestMethod]
        public void RemoveRepetitiveSpaces_StringWitExtraSpaces_Test()
        {
            string str = " string    with    extra spaces ";
            string expectedStr = " string with extra spaces ";
            string resultStr = RemoveExtraBlanks.Program.RemoveRepetitiveSpaces(str);
            Assert.AreEqual(expectedStr, resultStr);
        }

    }

    [TestClass]
    public class RemoveExtraBlanksInLine_tests
    {
        [TestMethod]
        public void RemoveExtraBlanksInLine_StringWitExtraSpaces_Test()
        {
            string str = "   string    with    extra spaces";
            string expectedStr = "string with extra spaces";
            RemoveExtraBlanks.Program.RemoveExtraBlanksInLine(ref str);
            Assert.AreEqual(expectedStr, str);
        }

    }

}
