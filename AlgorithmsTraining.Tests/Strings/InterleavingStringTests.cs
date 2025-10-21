using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings;

internal class InterleavingStringTests
{
    [TestCaseSource(nameof(TestCases))]
    public bool InterleavingString_Tests(string s1, string s2, string s3)
    {
        return InterleavingString.IsInterleave(s1, s2, s3);
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData("ab", "cd", "abcd").Returns(true);
        yield return new TestCaseData("ab", "cd", "cdab").Returns(true);
        yield return new TestCaseData("ab", "cd", "acbd").Returns(true);
        yield return new TestCaseData("ab", "cd", "cadb").Returns(true);
        yield return new TestCaseData("ab", "cd", "acdb").Returns(true);
        yield return new TestCaseData("ab", "cd", "cabd").Returns(true);
        yield return new TestCaseData("ab", "cd", "abdc").Returns(false);

        yield return new TestCaseData("abc", "de", "abcde").Returns(true);
        yield return new TestCaseData("abc", "de", "adbce").Returns(true);
        yield return new TestCaseData("abc", "de", "adebc").Returns(true);
        yield return new TestCaseData("abc", "de", "deabc").Returns(true);

        yield return new TestCaseData("", "", "").Returns(true);
        yield return new TestCaseData("", "b", "b").Returns(true);
        yield return new TestCaseData("a", "b", "a").Returns(false);

        yield return new TestCaseData(
            "ababbb",
            "baaaba",
            "abababababbb"
        ).Returns(false);

        //yield return new TestCaseData(
        //    "abababababababababababababababababababababababababababababababababababababababababababababababababbb",
        //    "babababababababababababababababababababababababababababababababababababababababababababababababaaaba",
        //    "abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb"
        //).Returns(false);
    }
}
