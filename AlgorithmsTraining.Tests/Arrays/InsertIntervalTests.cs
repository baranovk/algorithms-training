using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class InsertIntervalTests
{
    [Test]
    public void InsertInterval_Should_InsertInterval()
    {
        var intervals = new int[][]
        {
            [1, 3],
            [6, 9]
        };

        int[] newInterval = [2, 5];

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length + 1));
        Assert.That(result.Any(r => ArraysAreEqual(r, [1, 5])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [6, 9])), Is.True);

        intervals =
        [
            [1,2],[3,5],[6,7],[8,10],[12,16]
        ];

        newInterval = [4, 8];

        result = InsertInterval.Insert(intervals, newInterval);

        Assert.That(result.GetLength(0), Is.EqualTo(intervals.Length + 1));
        Assert.That(ArraysAreEqual(result[0], [1, 2]), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [3, 10])), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, [12, 16])), Is.True);
    }
}
