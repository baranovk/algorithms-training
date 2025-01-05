using AlgorithmsTraining.Arrays;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Arrays;

internal class MergeIntervalsTests
{
    [Test]
    public void MergeIntervals_Should_MergeIntervals()
    {
        var intervals = new int[][]
        {
            new int[] { 1, 4 },
            new int[] { 4, 5 }
        };

        var result = MergeIntervals.Merge(intervals);

        Assert.That(result.GetLength(0), Is.EqualTo(1));
        Assert.That(ArraysAreEqual(result[0], new int[] { 1, 5 }), Is.True);

        intervals = ReadFromResources("AlgorithmsTraining.Tests.Arrays.Resources.merge-intervals-testcase-001.txt")
            .Split("\r\n")
            .Select(s => s.Split(','))
            .Select(arr => arr.Select(s => Convert.ToInt32(s)).ToArray())
            .ToArray();

        result = MergeIntervals.Merge(intervals);
        Assert.That(result.GetLength(0), Is.EqualTo(10_000));

        intervals = new int[][]
        {
            new int[] { 1, 3 },
            new int[] { 2, 6 },
            new int[] { 8, 10 },
            new int[] { 15, 18 }
        };

        result = MergeIntervals.Merge(intervals);

        Assert.That(result.GetLength(0), Is.EqualTo(3));
        Assert.That(result.Any(r => ArraysAreEqual(r, new int[] { 1, 6 })), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, new int[] { 8, 10 })), Is.True);
        Assert.That(result.Any(r => ArraysAreEqual(r, new int[] { 15, 18 })), Is.True);
    }
}
