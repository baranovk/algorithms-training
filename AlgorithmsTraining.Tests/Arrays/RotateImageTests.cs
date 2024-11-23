using System;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class RotateImageTests
{
    [Test]
    public void RotateImageSolution_Should_RotateMatrix()
    {
        var matrix = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        RotateImage.Solution(matrix);

        var expected = new int[][]
        {
            new int[] { 7, 4, 1 },
            new int[] { 8, 5, 2 },
            new int[] { 9, 6, 3 }
        };

        Assert.That(ArraysAreEqual(matrix, expected), Is.True);
    }

    private static bool ArraysAreEqual(int[][] arr1, int[][] arr2)
    {
        if (arr1.Length != arr2.Length) { return false; }

        for (var i = 0; i < arr1.Length; i++)
        {
            for (var j = 0; j < arr1.Length; j++)
            {
                if (arr1[i][j] != arr2[i][j]) { return false; }
            }
        }

        return true;
    }
}
