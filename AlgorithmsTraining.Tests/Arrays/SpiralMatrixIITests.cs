using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class SpiralMatrixIITests
{
    [Test]
    public void SpiralMatrixIISolution_Should_ReturnCorrectOneDimensionalList()
    {
        var result = SpiralMatrixII.GenerateMatrix(1);
        var expected = new int[][] { [1] };

        Assert.That(MatrixesAreEqual(result, expected), Is.True);
    }

    [Test]
    public void SpiralMatrixIISolution_Test_0()
    {
        var result = SpiralMatrixII.GenerateMatrix(3);
        var expected = new int[][] { [1, 2, 3], [8, 9, 4], [7, 6, 5] };

        Assert.That(MatrixesAreEqual(result, expected), Is.True);
    }
}
