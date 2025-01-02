using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class JumpGameTests
{
    [Test]
    public void Can_Jump_1()
    {
        var nums = new int[] { 2, 3, 1, 1, 4 };
        Assert.That(new JumpGame().CanJump(nums), Is.True);
    }

    [Test]
    public void Can_Jump_2()
    {
        var nums = new int[] 
        { 
            2, 0, 6, 9, 8, 4, 5, 0, 8, 9, 1, 2, 9, 6, 8, 8, 0, 6, 3, 1, 2, 2, 1, 2, 6, 5, 3, 1, 2, 2, 6, 4, 2, 4, 3, 
            0, 0, 0, 3, 8, 2, 4, 0, 1, 2, 0, 1, 4, 6, 5, 8, 0, 7, 9, 3, 4, 6, 6, 5, 8, 9, 3, 4, 3, 7, 0, 4, 9, 0, 9, 
            8, 4, 3, 0, 7, 7, 1, 9, 1, 9, 4, 9, 0, 1, 9, 5, 7, 7, 1, 5, 8, 2, 8, 2, 6, 8, 2, 2, 7, 5, 1, 7, 9, 6 
        };

        Assert.That(new JumpGame().CanJump(nums), Is.False);
    }

    [Test]
    public void Can_Jump_If_Zero()
    {
        var nums = new int[] { 0 };
        Assert.That(new JumpGame().CanJump(nums), Is.True);

        nums = new int[] { 1 };
        Assert.That(new JumpGame().CanJump(nums), Is.True);
    }

    [Test]
    public void Can_Not_Jump_1()
    {
        var nums = new int[] { 3, 2, 1, 0, 4 };
        Assert.That(new JumpGame().CanJump(nums), Is.False);
    }
}
