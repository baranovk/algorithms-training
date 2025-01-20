using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Tracing.Analysis.GC;

namespace AlgorithmsTraining.Arrays;

/*
 * 62. Unique Paths

   There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). 
   The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either 
   down or right at any point in time.

   Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

   The test cases are generated so that the answer will be less than or equal to 2 * 10^9.

   Example 1:

   Input: m = 3, n = 7
   Output: 28

   Example 2:

   Input: m = 3, n = 2
   Output: 3

   Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:

   1. Right -> Down -> Down
   2. Down -> Down -> Right
   3. Down -> Right -> Down

   Constraints:

   1 <= m, n <= 100
 */
public static class UniquePaths
{
    public static int Solution(int m, int n) => (1 == m && 1 == n) ? 1 : CountPathsFrom(m - 1, n - 1, n, stackalloc int[n * m]);

    private static int CountPathsFrom(int i, int j, int columns, Span<int> memo)
    {
        if (0 == i && 0 == j) { return 1; }
        var memoIndex = i * columns + j;

        if (0 == memo[memoIndex])
        {
            memo[memoIndex] = (0 < i ? CountPathsFrom(i - 1, j, columns, memo) : 0)
                + (0 < j ? CountPathsFrom(i, j - 1, columns, memo) : 0);
        }

        return memo[memoIndex];
    }
}
