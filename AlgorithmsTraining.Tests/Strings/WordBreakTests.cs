using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings
{
    internal class WordBreakTests
    {
        [TestCaseSource(nameof(TestCases))]
        public bool WordBreakTests_Tests(string s, IList<string> wordDict) => WordBreak.Solution(s, wordDict);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData("ab", new List<string> { "a", "b" }).Returns(true);
            yield return new TestCaseData("leetcode", new List<string> { "leet", "code" }).Returns(true);
            yield return new TestCaseData("applepenapple", new List<string> { "apple", "pen" }).Returns(true);
            yield return new TestCaseData("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }).Returns(false);

            yield return new TestCaseData(
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
                new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }
            ).Returns(false);
        }
    }
}
