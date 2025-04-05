using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class RotateImageTests
{
    [Test]
    public void RotateImageSolution_Should_RotateMatrix()
    {
        var matrix = new int[][]
        {
           [1, 2, 3],
           [ 4, 5, 6 ],
           [ 7, 8, 9]
        };

        RotateImage.Solution(matrix);

        var expected = new int[][]
        {
            [7, 4, 1],
            [8, 5, 2],
            [9, 6, 3]
        };

        Assert.That(MatrixesAreEqual(matrix, expected), Is.True);
    }
}
