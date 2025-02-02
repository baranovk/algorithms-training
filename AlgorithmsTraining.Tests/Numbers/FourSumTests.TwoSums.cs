using AlgorithmsTraining.Numbers;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Numbers;

internal partial class FourSumTests
{
    [Test]
    public void FourSum_Should_FindTwoSumSets_0()
    {
        int[] nums = [1, 0, -1, 0, -2, 2];
        var sum = 0;

        var result = _4Sum.FindTwoSumSets(nums, sum, BuildHistogram(nums)).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result.Any(r => ArraysAreEqual(r, [1, -1])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [0, 0])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [-2, 2])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindTwoSumSets_1()
    {
        int[] nums = [1, 0, 7, 0, 1, 7];
        var sum = 8;

        var result = _4Sum.FindTwoSumSets(nums, sum, BuildHistogram(nums)).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqual(r, [1, 7])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindTwoSumSets_2()
    {
        int[] nums = [1, 3, 7, 2, 1, 6, 7];
        var sum = 8;

        var result = _4Sum.FindTwoSumSets(nums, sum, BuildHistogram(nums)).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqual(r, [1, 7])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [2, 6])), Is.True);

        sum = 9;

        result = _4Sum.FindTwoSumSets(nums, sum, BuildHistogram(nums)).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqual(r, [7, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [3, 6])), Is.True);
    }
}
