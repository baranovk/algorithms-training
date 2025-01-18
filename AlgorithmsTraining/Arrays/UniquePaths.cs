using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
    public static int Solution(int m, int n)
    {
        /*
         * arr_0[m][n] to one dimensional array arr_1[m * n]
         * arr_0[i][j] == arr_1[i * n + j]
         */
        var flagsCount = n * m;
        Span<int> memo = stackalloc int[0 == flagsCount % 32 ? flagsCount / 32 : 1 + flagsCount / 32];
        int pathsCount = default;
        GoFrom(m - 1, n - 1, n, memo, ref pathsCount);
        return pathsCount;
    }

    private static void GoFrom(int i, int j, int columns, Span<int> memo, ref int pathsCount)
    {
        // finish !!!
        if (0 == i && 0 == j) { pathsCount++; return; }

        // try go up and try go left
        if (i > 0)
        {
            if (TryMarkAsVisited(i - 1, j, columns, memo))
            {
                GoFrom(i - 1, j, columns, memo, ref pathsCount);
            }
            else
            {
                pathsCount += i - 1 > 0 ? 1 : 0;
                pathsCount += j > 0 ? 1 : 0;
            }
        }

        if (j > 0)
        {
            if (TryMarkAsVisited(i, j - 1, columns, memo))
            {
                GoFrom(i, j - 1, columns, memo, ref pathsCount);
            }
            else
            {
                pathsCount += i > 0 ? 1 : 0;
                pathsCount += j - 1 > 0 ? 1 : 0;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryMarkAsVisited(int i, int j, int columns, Span<int> memo)
    {
        if (0 == i && 0 == j) { return true; }

        var index = i * columns + j;
        var intIndex = index / 32;
        var offset = index % 32;
        var @int = memo[intIndex];
        var canMark = (@int & (1 << offset)) != (1 << offset);

        if (canMark)
        {
            memo[intIndex] = memo[intIndex] | (1 << offset);
            return true;
        }

        return false;
    }
}
