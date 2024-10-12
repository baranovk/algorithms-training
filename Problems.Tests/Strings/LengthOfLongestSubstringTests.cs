using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Strings;

namespace Problems.Tests.Strings
{
    [TestClass]
    public class LengthOfLongestSubstringTests
    {
        [TestMethod]
        public void TestNoRepeats()
        {
            var s = "1234";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 4);
        }

        [TestMethod]
        public void TestString_1()
        {
            var s = "abcdfbwxa";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 7);
        }

        [TestMethod]
        public void TestString_2()
        {
            var s = "abcddfbwxa";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 6);
        }

        [TestMethod]
        public void TestString_3()
        {
            var s = "abcdfbwxkk";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 7);
        }

        [TestMethod]
        public void TestString_4()
        {
            var s = "aaa";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 1);
        }

        [TestMethod]
        public void TestString_5()
        {
            var s = "aabcde";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 5);
        }

        [TestMethod]
        public void TestString_6()
        {
            var s = "xyaabcde";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 5);
        }

        [TestMethod]
        public void TestString_7()
        {
            var s = "xyabcbdeau";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 6);
        }

        [TestMethod]
        public void TestString_8()
        {
            var s = "xatracdbevmb";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 9);
        }

        [TestMethod]
        public void TestString_9()
        {
            var s = "avdbrtyajhxcbqu";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 11);
        }

        [TestMethod]
        public void TestString_10()
        {
            var s = "abcabcbb";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 3);
        }

        [TestMethod]
        public void TestString_11()
        {
            var s = "abbbcab";
            var length = LengthOfLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.AreEqual(length, 3);
        }
    }
}
