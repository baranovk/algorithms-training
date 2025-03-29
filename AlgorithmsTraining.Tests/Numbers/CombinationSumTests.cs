using AlgorithmsTraining.Numbers;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Numbers;

internal class CombinationSumTests
{
    [Test]
    public void CombinationSum_Should_FindCombinations_0()
    {
        int[] candidates = [2, 3, 4, 5];
        int target = 7;

        var result = CombinationSum.Solution(candidates, target);

        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 3])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 5])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [3, 4])), Is.True);
    }

    [Test]
    public void CombinationSum_Should_FindCombinations_1()
    {
        int[] candidates = [1, 2, 3, 4, 5];
        int target = 7;

        var result = CombinationSum.Solution(candidates, target);

        Assert.That(result.Count, Is.EqualTo(13));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 4])), Is.True);        // 6
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 2, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 2, 3])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 3, 3])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 5])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 1, 2, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 1, 4])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 1, 1, 3])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 1, 1, 1, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 1, 1, 1, 1, 1])), Is.True);

        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 5])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 3])), Is.True);

        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [3, 4])), Is.True);
    }
}
