using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class UniquePathsIITests
{
    [TestCaseSource(nameof(TestCases))]
    public int Solution_Should_CountUniquePaths(int[][] obstacleGrid)
    {
        return UniquePathsII.UniquePathsWithObstacles(obstacleGrid);
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData([new int[][] { [0, 0, 0, 1], [0, 0, 1, 0], [0, 0, 0, 0] }]).Returns(3);
        yield return new TestCaseData([new int[][] { [0, 0, 0], [0, 1, 0], [0, 0, 0] }]).Returns(2);
        yield return new TestCaseData([new int[][] { [0, 1], [0, 0] }]).Returns(1);
        yield return new TestCaseData([new int[][] { [0] }]).Returns(1);
    }
}
