using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class Search2DMatrixTests
{
    [TestCaseSource(nameof(TestCases))]
    public bool Search2DMatrix_Tests(int[][] matrix, int target) => Search2DMatrix.SearchMatrix(matrix, target);

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData([new int[][] { [1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60] }, 3]).Returns(true);
        yield return new TestCaseData([new int[][] { [1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60] }, 13]).Returns(false);
    }
}
