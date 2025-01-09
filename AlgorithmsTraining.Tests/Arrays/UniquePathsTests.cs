using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class UniquePathsTests
{
    [TestCaseSource(nameof(TestCases))]
    public int Solution_Should_CountUniquePaths(int m, int n)
    {
        return UniquePaths.Solution(m, n);
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(3, 7).Returns(28);
        yield return new TestCaseData(3, 2).Returns(3);
    }
}
