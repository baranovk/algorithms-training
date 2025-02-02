using AlgorithmsTraining.Numbers;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Numbers;

internal partial class FourSumTests
{
    [Test]
    public void FourSum_Should_FindThreeSumSets_0()
    {
        int[] nums = [1, 0, -1, 0, -2, 2];
        var sum = 0;

        var result = _4Sum.FindThreeSumSets(nums, sum, BuildHistogram(nums), []).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [0, -1, 1])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [-2, 2, 0])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindThreeSumSets_1()
    {
        int[] nums = [1, 0, -1, 0, -2, 2, -1, 0];
        //int[] nums = [-8, -6, 2, 6, 4];
        var sum = 0;

        var result = _4Sum.FindThreeSumSets(nums, sum, BuildHistogram(nums), []).Select(r => r.ToArray()).ToArray();

        // -2 2 0   0 -2  2
        Assert.That(result.Count, Is.EqualTo(4));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 0, -1])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [-1, 2, -1])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [0, -2, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [0, 0, 0])), Is.True);
    }
}
