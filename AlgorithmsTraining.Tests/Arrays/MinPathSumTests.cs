using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class MinPathSumTests
{
    [TestCaseSource(nameof(TestCases))]
    public int MinPathSum_Tests(int[][] grid) => MinimumPathSum.MinPathSum(grid);

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData([new int[][] { [1, 3, 1], [1, 5, 1], [4, 2, 1] }]).Returns(7);
        yield return new TestCaseData([new int[][] { [1, 2, 3], [4, 5, 6] }]).Returns(12);
    }
}
