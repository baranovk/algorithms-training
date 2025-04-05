using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class SetMatrixZeroesTests
{
    [Test]
    public void SetMatrixZeroes_Should_SetZeroes_0()
    {
        var matrix = new int[][]
        {
            [1,1,1], 
            [1,0,1], 
            [1,1,1]
        };

        SetMatrixZeroes.SetZeroes(matrix);
        var expected = new int[][] { [1, 0, 1], [0, 0, 0], [1, 0, 1] };

        Assert.That(MatrixesAreEqual(matrix, expected), Is.True);
    }

    [Test]
    public void SetMatrixZeroes_Should_SetZeroes_1()
    {
        var matrix = new int[][]
        {
            [0,1,2,0], [3,4,5,2], [1,3,1,5]
        };

        SetMatrixZeroes.SetZeroes(matrix);
        var expected = new int[][] { [0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0] };

        Assert.That(MatrixesAreEqual(matrix, expected), Is.True);
    }

    [Test]
    public void SetMatrixZeroes_Should_SetZeroes_2()
    {
        var matrix = new int[][]
        {
            [1,  2,  3,  4], 
            [5,  0,  7,  8], 
            [0,  10, 11, 12], 
            [13, 14, 15, 0]
        };

        SetMatrixZeroes.SetZeroes(matrix);

        var expected = new int[][] 
        {
            [0,0,3,0],
            [0,0,0,0],
            [0,0,0,0],
            [0,0,0,0]
        };

        Assert.That(MatrixesAreEqual(matrix, expected), Is.True);
    }

    [Test]
    public void SetMatrixZeroes_Should_SetZeroes_3()
    {
        var matrix = new int[][]
        {
            [1,0,3]
        };

        SetMatrixZeroes.SetZeroes(matrix);

        var expected = new int[][]
        {
            [0,0,0]
        };

        Assert.That(MatrixesAreEqual(matrix, expected), Is.True);
    }
}
