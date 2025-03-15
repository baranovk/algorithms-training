using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class SpiralMatrixTests
{
    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_0()
    {
        var matrix = new int[][]
        {
            [1]
        };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_1()
    {
        var matrix = new int[][]
         {
            new int[] { 1, 2, 3 }
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1, 2, 3 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_2()
    {
        var matrix = new int[][]
         {
            new int[] { 1, 2 },
            new int[] { 3, 4 }
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1, 2, 4, 3 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_3()
    {
        var matrix = new int[][]
         {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_4()
    {
        var matrix = new int[][]
         {
            new int[] { 1, 2, 3, 4 },
            new int[] { 5, 6, 7, 8 },
            new int[] { 9, 10, 11, 12 },
            new int[] { 13, 14, 15, 16 },
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_5()
    {
        var matrix = new int[][]
         {
            new int[] { 1, 2, 3, 4 },
            new int[] { 5, 6, 7, 8 }
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1, 2, 3, 4, 8, 7, 6, 5 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_6()
    {
        var matrix = new int[][]
         {
            new int[] { 1, 2, 3, 4 },
            new int[] { 5, 6, 7, 8 },
            new int[] { 9, 10, 11, 12 }
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixSolution_Should_ReturnCorrectOneDimensionalList_7()
    {
        var matrix = new int[][]
         {
            new int[] { 7 },
            new int[] { 9 },
            new int[] { 6 }
         };

        var result = SpiralMatrix.SpiralOrder(matrix);
        var expected = new int[] { 7, 9, 6 };

        Assert.That(ArraysAreEqual(result, expected), Is.True);
    }
}
