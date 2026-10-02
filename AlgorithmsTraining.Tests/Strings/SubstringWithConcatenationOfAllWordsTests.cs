using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings
{
    internal class SubstringWithConcatenationOfAllWordsTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void SubstringWithConcatenationOfAllWordsTests_Tests(string s, string[] words, IList<int> expectedIndexes)
        {
            var indexes = SubstringWithConcatenationOfAllWords.FindSubstring(s, words);
            Assert.That(indexes, Is.EqualTo(expectedIndexes));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData("bafo", new string[] { "fo", "ba" }, new List<int> { 0 });
            yield return new TestCaseData("bafoafoba", new string[] { "fo", "ba" }, new List<int> { 0, 5 });
            yield return new TestCaseData("babababa", new string[] { "fo", "ba" }, new List<int> { });
            yield return new TestCaseData("barfoothefoobarman", new string[] { "foo", "bar" }, new List<int> { 0, 9 });
            yield return new TestCaseData("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }, new List<int> { });
            yield return new TestCaseData("ertwordwordbestword", new string[] { "word", "best", "word" }, new List<int> { 3, 7 });

            yield return new TestCaseData("aaaaaaaaaaaa", new string[] { "aaa", "aaa", "aaa" }, new List<int> { 0, 1, 2, 3 });
            yield return new TestCaseData("aaaacccbbba", new string[] { "aaa", "bbb", "ccc" }, new List<int> { 1 });
            yield return new TestCaseData("aaaaacccbbba", new string[] { "aaa", "bbb", "ccc" }, new List<int> { 2 });
            yield return new TestCaseData("aaaaaacccbbba", new string[] { "aaa", "bbb", "ccc" }, new List<int> { 3 });

            yield return new TestCaseData("aaaaaaccbbbaaaccc", new string[] { "aaa", "bbb", "ccc" }, new List<int> { 8 });
            yield return new TestCaseData("aaaaaaccbbbaaacccabccccaaabbbfd", new string[] { "aaa", "bbb", "ccc" }, new List<int> { 8, 20 });
            yield return new TestCaseData("aaaaa", new string[] { "a", "a", "a" }, new List<int> { 0, 1, 2 });
        }
    }
}
