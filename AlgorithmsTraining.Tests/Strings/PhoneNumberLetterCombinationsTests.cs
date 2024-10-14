using System;

using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings
{
    
    public class PhoneNumberLetterCombinationsTests
    {
        [Test]
        public void TestExceptions()
        {
            var digits = "10";
            var combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 0);

            digits = "1";
            combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 0);

            digits = "";
            combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 0);
        }

        [Test]
        public void TestTwoNumbers()
        {
            var digits = "23";
            var combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 9);
            Assert.IsTrue(combinations.Contains("ad"));
            Assert.IsTrue(combinations.Contains("ae"));
            Assert.IsTrue(combinations.Contains("af"));
            Assert.IsTrue(combinations.Contains("bd"));
            Assert.IsTrue(combinations.Contains("be"));
            Assert.IsTrue(combinations.Contains("bf"));
            Assert.IsTrue(combinations.Contains("cd"));
            Assert.IsTrue(combinations.Contains("ce"));
            Assert.IsTrue(combinations.Contains("cf"));

            digits = "1203";
            combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 9);
            Assert.IsTrue(combinations.Contains("ad"));
            Assert.IsTrue(combinations.Contains("ae"));
            Assert.IsTrue(combinations.Contains("af"));
            Assert.IsTrue(combinations.Contains("bd"));
            Assert.IsTrue(combinations.Contains("be"));
            Assert.IsTrue(combinations.Contains("bf"));
            Assert.IsTrue(combinations.Contains("cd"));
            Assert.IsTrue(combinations.Contains("ce"));
            Assert.IsTrue(combinations.Contains("cf"));
        }

        [Test]
        public void TestThreeNumbers()
        {
            var digits = "234";
            var combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 27);
            Assert.IsTrue(combinations.Contains("adg"));
            Assert.IsTrue(combinations.Contains("adh"));
            Assert.IsTrue(combinations.Contains("adi"));
            Assert.IsTrue(combinations.Contains("aeg"));
            Assert.IsTrue(combinations.Contains("aeh"));
            Assert.IsTrue(combinations.Contains("aei"));
            Assert.IsTrue(combinations.Contains("afg"));
            Assert.IsTrue(combinations.Contains("afh"));
            Assert.IsTrue(combinations.Contains("afi"));
            Assert.IsTrue(combinations.Contains("bdg"));
            Assert.IsTrue(combinations.Contains("bdh"));
            Assert.IsTrue(combinations.Contains("bdi"));
            Assert.IsTrue(combinations.Contains("beg"));
            Assert.IsTrue(combinations.Contains("beh"));
            Assert.IsTrue(combinations.Contains("bei"));
            Assert.IsTrue(combinations.Contains("bfg"));
            Assert.IsTrue(combinations.Contains("bfh"));
            Assert.IsTrue(combinations.Contains("bfi"));
            Assert.IsTrue(combinations.Contains("cdg"));
            Assert.IsTrue(combinations.Contains("cdh"));
            Assert.IsTrue(combinations.Contains("cdi"));
            Assert.IsTrue(combinations.Contains("ceg"));
            Assert.IsTrue(combinations.Contains("ceh"));
            Assert.IsTrue(combinations.Contains("cei"));
            Assert.IsTrue(combinations.Contains("cfg"));
            Assert.IsTrue(combinations.Contains("cfh"));
            Assert.IsTrue(combinations.Contains("cfi"));

            digits = "120340";
            combinations = PhoneNumberLetterCombinations.LetterCombinations(digits);
            Assert.AreEqual(combinations.Count, 27);
            Assert.IsTrue(combinations.Contains("adg"));
            Assert.IsTrue(combinations.Contains("adh"));
            Assert.IsTrue(combinations.Contains("adi"));
            Assert.IsTrue(combinations.Contains("aeg"));
            Assert.IsTrue(combinations.Contains("aeh"));
            Assert.IsTrue(combinations.Contains("aei"));
            Assert.IsTrue(combinations.Contains("afg"));
            Assert.IsTrue(combinations.Contains("afh"));
            Assert.IsTrue(combinations.Contains("afi"));
            Assert.IsTrue(combinations.Contains("bdg"));
            Assert.IsTrue(combinations.Contains("bdh"));
            Assert.IsTrue(combinations.Contains("bdi"));
            Assert.IsTrue(combinations.Contains("beg"));
            Assert.IsTrue(combinations.Contains("beh"));
            Assert.IsTrue(combinations.Contains("bei"));
            Assert.IsTrue(combinations.Contains("bfg"));
            Assert.IsTrue(combinations.Contains("bfh"));
            Assert.IsTrue(combinations.Contains("bfi"));
            Assert.IsTrue(combinations.Contains("cdg"));
            Assert.IsTrue(combinations.Contains("cdh"));
            Assert.IsTrue(combinations.Contains("cdi"));
            Assert.IsTrue(combinations.Contains("ceg"));
            Assert.IsTrue(combinations.Contains("ceh"));
            Assert.IsTrue(combinations.Contains("cei"));
            Assert.IsTrue(combinations.Contains("cfg"));
            Assert.IsTrue(combinations.Contains("cfh"));
            Assert.IsTrue(combinations.Contains("cfi"));
        }
    }
}
