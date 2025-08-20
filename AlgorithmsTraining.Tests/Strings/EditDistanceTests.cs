using System.Collections;
using AlgorithmsTraining.Strings;

namespace AlgorithmsTraining.Tests.Strings;

internal class EditDistanceTests
{
    [TestCaseSource(nameof(TestCases))]
    public int Solution_Should_CalculateMinDistance(string word1, string word2)
    {
        return EditDistance.MinDistance(word1, word2);
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData("a", "a").Returns(0);
        yield return new TestCaseData("a", "ab").Returns(1);
        yield return new TestCaseData("aba", "ab").Returns(1);
        yield return new TestCaseData("ab", "abc").Returns(1);
        yield return new TestCaseData("bb", "abbat").Returns(3);
        yield return new TestCaseData("horse", "ros").Returns(3);
        yield return new TestCaseData("intention", "execution").Returns(5);
        yield return new TestCaseData("b", "").Returns(1);
        yield return new TestCaseData("bbb", "").Returns(3);
        yield return new TestCaseData("sea", "ate").Returns(3);
    }
}
