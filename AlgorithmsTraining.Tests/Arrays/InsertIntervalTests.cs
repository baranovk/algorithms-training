using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class InsertIntervalTests
{
    [Test]
    public void InsertInterval_Should_InsertInterval_0()
    {
        var intervals = new int[][]
        {
            [4, 5],
            [6, 9]
        };

        int[] newInterval = [1, 3];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length + 1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 3]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [4, 5]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(2), [6, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_0_1()
    {
        var intervals = new int[][]
        {
            [1, 3],
            [4, 5]
        };

        int[] newInterval = [6, 9];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length + 1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 3]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [4, 5]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(2), [6, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_1()
    {
        var intervals = new int[][]
        {
            [1, 3],
            [6, 9]
        };

        int[] newInterval = [4, 5];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length + 1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 3]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [4, 5]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(2), [6, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_2()
    {
        var intervals = new int[][]
        {
            [1, 3],
            [6, 9]
        };

        int[] newInterval = [2, 5];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(2));
        Assert.That(result.Any(r => ArraysAreEqual(r, [1, 5])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [6, 9])), Is.True);

        intervals =
        [
            [1,2],[3,5],[6,7],[8,10],[12,16]
        ];

        newInterval = [4, 8];

        result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(3));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 2]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [3, 10]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(2), [12, 16]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_3()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [7, 9]
        };

        int[] newInterval = [2, 5];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 6]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [7, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_4()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [7, 9]
        };

        int[] newInterval = [1, 6];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 6]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [7, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_5()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [7, 10]
        };

        int[] newInterval = [8, 9];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 6]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [7, 10]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_6()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [7, 9]
        };

        int[] newInterval = [8, 9];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 6]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [7, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_7()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [8, 9]
        };

        int[] newInterval = [5, 7];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 7]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [8, 9]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_8()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [8, 10]
        };

        int[] newInterval = [5, 9];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 10]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_9()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [7, 9],
            [10, 13]
        };

        int[] newInterval = [2, 11];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 13]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_10()
    {
        var intervals = new int[][]
        {
            [1, 6],
            [7, 9],
            [10, 13]
        };

        int[] newInterval = [8, 11];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(2));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 6]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [7, 13]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_11()
    {
        var intervals = new int[][]
        {
            [1, 5]
        };

        int[] newInterval = [2, 7];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [1, 7]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_12()
    {
        var intervals = new int[][]
        {
            [1, 5]
        };

        int[] newInterval = [0, 3];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [0, 5]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_13()
    {
        var intervals = new int[][]
        {
            [2,3], [5,7]
        };

        int[] newInterval = [0, 6];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(1));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [0, 7]), Is.True);
    }

    [Test]
    public void InsertInterval_Should_InsertInterval_14()
    {
        var intervals = new int[][]
        {
            [0,5], [9,12]
        };

        int[] newInterval = [7, 16];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(2));
        Assert.That(ArraysAreEqual(result.ElementAt(0), [0, 5]), Is.True);
        Assert.That(ArraysAreEqual(result.ElementAt(1), [7, 16]), Is.True);
    }
}


