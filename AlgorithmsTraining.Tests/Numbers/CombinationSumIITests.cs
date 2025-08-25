using AlgorithmsTraining.Numbers;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Numbers;

internal class CombinationSumIITests
{
    [Test]
    public void CombinationSumIITests_Should_FindCombinations_0()
    {
        int[] candidates = [2, 5, 2, 1, 2];
        int target = 5;

        var result = CombinationSumII.Solution(candidates, target);

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [5])), Is.True);
    }

    [Test]
    public void CombinationSumIITests_Should_FindCombinations_1()
    {
        int[] candidates = [10, 1, 2, 7, 6, 1, 5];
        int target = 8;

        var result = CombinationSumII.Solution(candidates, target);

        Assert.That(result.Count, Is.EqualTo(4));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 1, 6])), Is.True); 
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 5])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 7])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 6])), Is.True);
    }
}
