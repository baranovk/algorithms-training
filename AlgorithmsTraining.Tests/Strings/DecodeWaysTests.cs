using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings;

internal class DecodeWaysTests
{
    [TestCaseSource(nameof(TestCases))]
    public int DecodeWays_Tests(string s) => DecodeWays.NumDecodings(s);

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData("12").Returns(2);
        yield return new TestCaseData("10").Returns(1);
        yield return new TestCaseData("20").Returns(1);
        yield return new TestCaseData("22").Returns(2);
        yield return new TestCaseData("30").Returns(0);
        yield return new TestCaseData("90").Returns(0);
        yield return new TestCaseData("226").Returns(3);
        yield return new TestCaseData("1226").Returns(5);
        yield return new TestCaseData("12265").Returns(5);
        yield return new TestCaseData("12205").Returns(2);
        yield return new TestCaseData("12250").Returns(0);
        yield return new TestCaseData("06").Returns(0);
        yield return new TestCaseData("1201234").Returns(3);
    }
}
