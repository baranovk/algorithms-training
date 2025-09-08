using System.Collections;
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers;

internal class GrayCodeTests
{
    [TestCaseSource(nameof(TestCases))]
    public void GrayCode_Tests(int n, IList<int> expectedResult)
    {
        var result = GrayCode.Solution(n);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            1,
            new List<int> { 0, 1 }
        );

        yield return new TestCaseData(
            2,
            new List<int> { 0, 1, 3, 2 }
        );

        yield return new TestCaseData(
            3,
            new List<int> { 0, 1, 3, 2, 6, 7, 5, 4 }
        );

        yield return new TestCaseData(
            4,
            new List<int> { 0, 1, 3, 2, 6, 7, 5, 4, 12, 13, 15, 14, 10, 11, 9, 8 }
        );
    }
}
