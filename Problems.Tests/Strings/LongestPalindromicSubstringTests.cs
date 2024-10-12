using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Strings;

namespace Problems.Tests.Strings
{
    [TestClass]
    public class LongestPalindromicSubstringTests
    {
        [TestMethod]
        public void TestIfStringPalindromic()
        {
            var s = "aaaa";
            Assert.IsTrue(LongestPalindromicSubstring.IsPalindrom(s, 0, s.Length - 1));

            s = "abba";
            Assert.IsTrue(LongestPalindromicSubstring.IsPalindrom(s, 0, s.Length - 1));

            s = "abbc";
            Assert.IsFalse(LongestPalindromicSubstring.IsPalindrom(s, 0, s.Length - 1));

            s = "abcdedcba";
            Assert.IsTrue(LongestPalindromicSubstring.IsPalindrom(s, 0, s.Length - 1));
        }

        [TestMethod]
        public void TestLongestPalindrom()
        {
            var s = "aaaa";
            Assert.AreEqual("aaaa", LongestPalindromicSubstring.LongestPalindrome(s));

            s = "ac";
            Assert.AreEqual("a", LongestPalindromicSubstring.LongestPalindrome(s));

            s = "abba";
            Assert.AreEqual("abba", LongestPalindromicSubstring.LongestPalindrome(s));

            s = "erbbacca";
            Assert.AreEqual("acca", LongestPalindromicSubstring.LongestPalindrome(s));

            s = "erbbagca";
            Assert.AreEqual("bb", LongestPalindromicSubstring.LongestPalindrome(s));

            s = "erbabagca";
            Assert.AreEqual("bab", LongestPalindromicSubstring.LongestPalindrome(s));

            s = "erbbagcadedac";
            Assert.AreEqual("cadedac", LongestPalindromicSubstring.LongestPalindrome(s));
        }

        [TestMethod]
        public void TestLongestPalindrom_1()
        {
            var s = "aaaa";
            Assert.AreEqual("aaaa", LongestPalindromicSubstring.LongestPalindrome_1(s));

            s = "ac";
            Assert.AreEqual("a", LongestPalindromicSubstring.LongestPalindrome_1(s));

            s = "abba";
            Assert.AreEqual("abba", LongestPalindromicSubstring.LongestPalindrome_1(s));

            s = "erbbacca";
            Assert.AreEqual("acca", LongestPalindromicSubstring.LongestPalindrome_1(s));

            s = "erbbagca";
            Assert.AreEqual("bb", LongestPalindromicSubstring.LongestPalindrome_1(s));

            s = "erbabagca";
            Assert.AreEqual("bab", LongestPalindromicSubstring.LongestPalindrome_1(s));

            s = "erbbagcadedac";
            Assert.AreEqual("cadedac", LongestPalindromicSubstring.LongestPalindrome_1(s));
        }
    }
}
