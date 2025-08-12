using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTraining.Arrays;

/*
 * 64. Minimum Path Sum

   Given a m x n grid filled with non-negative numbers, find a path from top left to bottom 
   right, which minimizes the sum of all numbers along its path.
   Note: You can only move either down or right at any point in time.

   Example 1:

   Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
   Output: 7
   Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.

   Example 2:

   Input: grid = [[1,2,3],[4,5,6]]
   Output: 12

   Constraints:

   [1] m == grid.length
   [2] n == grid[i].length
   [3] 1 <= m, n <= 200
   [4] 0 <= grid[i][j] <= 200

   Runtime
   2 ms
   Beats 59.23%

   Memory
   46.48 MB
   Beats 87.02%
 */
public static class MinimumPathSum
{
    public static int MinPathSum(int[][] grid)
    {
        var height = grid.Length;
        var width = grid[0].Length;

        var memo = new bool[height][];

        for (int i = 0; i < height; i++)
        {
            memo[i] = new bool[width];
        }

        return CalcMinPathSum(0, 0, grid, memo);
    }

    private static int CalcMinPathSum(int x, int y, int[][] grid, bool[][] memo)
    {
        if (memo[y][x]) { return grid[y][x]; }

        var goRightMinSum = x < grid[0].Length - 1 ? CalcMinPathSum(x + 1, y, grid, memo) : int.MaxValue;
        var goDownMinSum = y < grid.Length - 1 ? CalcMinPathSum(x, y + 1, grid, memo) : int.MaxValue;

        memo[y][x] = true;
        grid[y][x] = grid[y][x] += x == grid[0].Length - 1 && y == grid.Length - 1 ? 0 : Math.Min(goRightMinSum, goDownMinSum);
        return grid[y][x];
    }
}
