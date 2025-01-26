namespace AlgorithmsTraining.Arrays;

/*
 * 56. Merge Intervals
 * 
 * Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

   Example 1:

   Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
   Output: [[1,6],[8,10],[15,18]]
   Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

   Example 2:

   Input: intervals = [[1,4],[4,5]]
   Output: [[1,5]]
   Explanation: Intervals [1,4] and [4,5] are considered overlapping.

   Constraints:

    - 1 <= intervals.length <= 10^4
    - intervals[i].length == 2
    - 0 <= start_i <= end_i <= 10^4

    Runtime
    6ms
    Beats 52.02%

    Memory
    56.30MB
    Beats 36.67%
 */
public static class MergeIntervals
{
    public static int[][] Merge(int[][] intervals)
    {
        if (1 == intervals.Length) return intervals;

        Array.Sort(intervals, (x, y) => CompareIntervals(x, y));
        
        var result = new List<int[]>();
        var intervalStart = intervals[0][0];
        var intervalEnd = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] > intervalEnd)
            {
                result.Add([intervalStart, intervalEnd]);
                intervalStart = intervals[i][0];
                intervalEnd = intervals[i][1];
            }
            else
            {
                intervalEnd = Math.Max(intervalEnd, intervals[i][1]);
            }
        }

        result.Add(new int[] { intervalStart, intervalEnd });
        return result.ToArray();
    }

    private static int CompareIntervals(int[] x, int[] y)
    {
        if (x[0] == y[0] && x[1] == y[1]) { return 0; }
        if (y[0] >= x[1]) { return -1; }
        if (x[0] >= y[1]) { return 1; }
        if (x[0] == y[0]) { return x[1] > y[1] ? 1 : -1; }
        if (x[0] < y[0]) { return -1; } else { return 1; }
    }
}
