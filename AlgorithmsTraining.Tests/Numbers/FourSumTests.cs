using AlgorithmsTraining.Numbers;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Numbers;

internal partial class FourSumTests
{
    [Test]
    public void FourSum_Should_FindFourSum_0()
    {
        int[] nums = [1, 0, -1, 0, -2, 2];
        int target = 0;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result.Any(r => ArraysAreEqual(r, [-2, -1, 1, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [-2, 0, 0, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [-1, 0, 0, 1])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_1()
    {
        int[] nums = [2, 2, 2, 2, 2];
        int target = 8;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqual(r, [2, 2, 2, 2, 2])), Is.True);
    }

    private static Dictionary<int, int> BuildHistogram(int[] nums)
        => nums.Aggregate(new Dictionary<int, int>(),
            (accDict, num) => { accDict[num] = accDict.TryGetValue(num, out var count) ? count + 1 : 1; return accDict; });
}
