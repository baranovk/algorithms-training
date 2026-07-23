using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings
{
    internal class RegularExpressionMatchingTests
    {
        [TestCaseSource(nameof(TestCases))]
        public bool RegularExpressionMatching_Tests(string s, string p) => RegularExpressionMatching.IsMatch(s, p);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(["a", "a"]).Returns(true);
            yield return new TestCaseData(["aa", "a*"]).Returns(true);
            yield return new TestCaseData(["aacbde", "a*cb*de"]).Returns(true);
            yield return new TestCaseData(["aacbde", "aacbd."]).Returns(true);
            yield return new TestCaseData(["aacbde", "aac*bde"]).Returns(true);
            yield return new TestCaseData(["aacbde", "a.cbd."]).Returns(true);
            yield return new TestCaseData(["aacbde", "a.cbd."]).Returns(true);
            yield return new TestCaseData(["aacbde", "a..bd*e"]).Returns(true);
            yield return new TestCaseData(["aacbde", "a..b*d*e"]).Returns(true);
            yield return new TestCaseData(["aaabde", "a*bde"]).Returns(true);
            yield return new TestCaseData(["aaabde", "a*.de"]).Returns(true);
            yield return new TestCaseData(["aab", "c*a*b"]).Returns(true);
            yield return new TestCaseData(["ab", ".*"]).Returns(true);
            yield return new TestCaseData(["aaa", "a*a"]).Returns(true);
            yield return new TestCaseData(["aaa", "ab*a*c*a"]).Returns(true);
            yield return new TestCaseData(["a", "ab*"]).Returns(true);
            yield return new TestCaseData(["ba", ".*a*a"]).Returns(true);
            yield return new TestCaseData(["a", "a*a"]).Returns(true);
            yield return new TestCaseData(["a", ".*"]).Returns(true);
            yield return new TestCaseData(["ab", ".*.."]).Returns(true);

            yield return new TestCaseData(["a", "b"]).Returns(false);
            yield return new TestCaseData(["aa", "a"]).Returns(false);
            yield return new TestCaseData(["aa", "ab"]).Returns(false);
            yield return new TestCaseData(["ab", ".*c"]).Returns(false);
            yield return new TestCaseData(["aac", "a*b"]).Returns(false);
            yield return new TestCaseData(["aacb", "a*b"]).Returns(false);
            yield return new TestCaseData(["aacbde", "a*b*"]).Returns(false);
            yield return new TestCaseData(["aacbde", "a*de"]).Returns(false);
            yield return new TestCaseData(["aacbde", "a*c*dp"]).Returns(false);
        }
    }
}
