using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

public class SortColorsTests
{
    [Test]
    public void Solution_Should_SortColors()
    {
        var colors = new[] { 2, 0, 2, 1, 1, 0 };
        SortColors.Solution(colors);
        Assert.That(ArraysAreEqual(colors, new int[] { 0, 0, 1, 1, 2, 2 }), Is.True);

        colors = new[] { 2, 0, 1 };
        SortColors.Solution(colors);
        Assert.That(ArraysAreEqual(colors, new int[] { 0, 1, 2 }), Is.True);
    }
}
