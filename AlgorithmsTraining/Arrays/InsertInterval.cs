namespace AlgorithmsTraining.Arrays;

public static class InsertInterval
{
    /*
     * 57. Insert Interval
       
       You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the 
       start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an 
       interval newInterval = [start, end] that represents the start and end of another interval.

       Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals 
       still does not have any overlapping intervals (merge overlapping intervals if necessary).

       Return intervals after the insertion. Note that you don't need to modify intervals in-place. You can make a new array and return it.

       Example 1:

       Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
       Output: [[1,5],[6,9]]

       Example 2:
       
       Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
       Output: [[1,2],[3,10],[12,16]]
       Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

       Constraints:

        - 0 <= intervals.length <= 10^4
        - intervals[i].length == 2
        - 0 <= starti <= endi <= 10^5
        - intervals is sorted by starti in ascending order.
        - newInterval.length == 2
        - 0 <= start <= end <= 10^5

       Runtime
       0ms
       Beats 100.00%

       Memory
       50.71MB
       Beats 38.00%

     */
    public static int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var length = intervals.GetLength(0);
        if (0 == length) return [newInterval];

        int[][] result;

        if (newInterval[0] > intervals[length - 1][1]) 
        {
            result = new int[length + 1][];
            Array.Copy(intervals, result, length);
            result[^1] = newInterval;
            return result;
        }

        if (newInterval[1] < intervals[0][0])
        {
            result = new int[length + 1][];
            Array.Copy(intervals, 0, result, 1, length);
            result[0] = newInterval;
            return result;
        }

        for (int i = 0; i < length; i++)
        {
            if (newInterval[0] > intervals[i][1] && newInterval[1] < intervals[i + 1][0])
            {
                result = new int[length + 1][];
                Array.Copy(intervals, 0, result, 0, i + 1);
                result[i + 1] = newInterval;
                Array.Copy(intervals, i + 1, result, i + 2, length - i - 1);
                return result;
            }
            else if ((newInterval[0] >= intervals[i][0] && newInterval[0] <= intervals[i][1])
                || (newInterval[0] <= intervals[i][0] && newInterval[1] >= intervals[i][0]))
            {
                newInterval = MergeIntervals(intervals, i, newInterval, out var mergedIntervalsCount);
                result = new int[length - (mergedIntervalsCount - 1)][];
                Array.Copy(intervals, 0, result, 0, i);
                result[i] = newInterval;
                Array.Copy(intervals, i + mergedIntervalsCount, result, i + 1, length - (i + mergedIntervalsCount));
                return result;
            }
        }

        return intervals;
    }

    private static int[] MergeIntervals(int[][] intervals, int offset, int[] newInterval, out int mergedIntervalsCount)
    {
        mergedIntervalsCount = 1;
        var intervalStart = Math.Min(intervals[offset][0], newInterval[0]);
        var intervalEnd = Math.Max(intervals[offset][1], newInterval[1]);

        for (int i = offset + 1; i < intervals.GetLength(0) && intervalEnd >= intervals[i][0]; i++)
        {
            intervalEnd = Math.Max(intervals[i][1], intervalEnd);
            mergedIntervalsCount++;
        }

        return [intervalStart, intervalEnd];
    }
}
