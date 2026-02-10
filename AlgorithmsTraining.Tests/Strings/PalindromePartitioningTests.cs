using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings
{
    internal class PalindromePartitioningTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void PalindromePartitioning_Tests(string s, IList<IList<string>> expectedResult)
        {
            var result = PalindromePartitioning.Partition(s);
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                "ccaacabacb",
                new List<IList<string>> {
                    new List<string> { "c","c","a","a","c","a","b","a","c","b"}, new List<string> { "c","c","a","a","c","aba","c","b"}, new List<string> { "c","c","a","a","cabac","b"}, new List<string> { "c","c","a","aca","b","a","c","b"}, new List<string> { "c","c","aa","c","a","b","a","c","b"}, new List<string> { "c","c","aa","c","aba","c","b"}, new List<string> { "c","c","aa","cabac","b"}, new List<string> { "c","caac","a","b","a","c","b"}, new List<string> { "c","caac","aba","c","b"}, new List<string> { "cc","a","a","c","a","b","a","c","b"}, new List<string> { "cc","a","a","c","aba","c","b"}, new List<string> { "cc","a","a","cabac","b"}, new List<string> { "cc","a","aca","b","a","c","b"}, new List<string> { "cc","aa","c","a","b","a","c","b"}, new List<string> { "cc","aa","c","aba","c","b"}, new List<string> { "cc","aa","cabac","b" }
                }
            );

            yield return new TestCaseData(
                "aa",
                new List<IList<string>> {
                    new List<string> { "a", "a" }, new List<string> { "aa" }
                }
            );

            yield return new TestCaseData(
                "aaa",
                new List<IList<string>> {
                    new List<string> { "a", "a", "a" }, new List<string> { "a", "aa" },
                    new List<string> { "aa", "a" }, new List<string> { "aaa" }
                }
            );

            yield return new TestCaseData(
                "aba",
                new List<IList<string>> {
                    new List<string> { "a", "b", "a" }, new List<string> { "aba" }
                }
            );

            yield return new TestCaseData(
                "abba",
                new List<IList<string>> {
                    new List<string> { "a", "b", "b", "a" }, new List<string> { "abba" },
                    new List<string> { "a", "bb", "a" },
                }
            );

            yield return new TestCaseData(
                "aab",
                new List<IList<string>> {
                    new List<string> { "a","a","b" }, new List<string> { "aa","b" }
                }
            );

            yield return new TestCaseData(
                "a",
                new List<IList<string>> {
                    new List<string> { "a" }
                }
            );
        }
    }
}
