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
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [-2, -1, 1, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [-2, 0, 0, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [-1, 0, 0, 1])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_1()
    {
        int[] nums = [2, 2, 2, 2, 2];
        int target = 8;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 2, 2])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_2()
    {
        int[] nums = [1, 2, 3, 4, 3, 2, 1];
        int target = 10;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 3, 4])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 3, 3])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_3()
    {
        int[] nums = [0, 0, 0, 4, 3, 2, 1];
        int target = 10;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 3, 4])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_4()
    {
        int[] nums = [3, 2, 1, 0, 0, 0, 2, 2, 2, 2, 2];
        int target = 8;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1, 2, 3, 2])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 2, 2])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_5()
    {
        int[] nums = [3, 2, 1, 0, -1, 0, 2, 2, 2, 2, 2];
        int target = 5;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(4));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [3, 2, 1, -1])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 2, -1])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 2, 1, 0])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [2, 3, 0, 0])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_6()
    {
        int[] nums = [5, 5, 3, 5, 1, -5, 1, -2];
        int target = 4;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [3, 5, 1, -5])), Is.True);
    }

    [Test]
    public void FourSum_Should_FindFourSum_10()
    {
        int[] nums = [1000000000, 1000000000, 1000000000, 999999999];
        int target = -294967297;

        var result = _4Sum.Solution(nums, target).Select(r => r.ToArray()).ToArray();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.Any(r => ArraysAreEqualWithoutOrder(r, [1000000000, 999999999, 1000000000, 1000000000])), Is.True);
    }
}
