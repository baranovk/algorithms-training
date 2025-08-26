namespace AlgorithmsTraining.Arrays;

/*
 * 74. Search a 2D Matrix
 * 
 * You are given an m x n integer matrix matrix with the following two properties:

    Each row is sorted in non-decreasing order.
    The first integer of each row is greater than the last integer of the previous row.

   Given an integer target, return true if target is in matrix or false otherwise.
   
   You must write a solution in O(log(m * n)) time complexity.

   Example 1:

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    Output: true

   Example 2:

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
    Output: false

   Constraints:

    [1] m == matrix.length
    [2] n == matrix[i].length
    [3] 1 <= m, n <= 100
    [4] -104 <= matrix[i][j], target <= 104

    Runtime
    0 ms
    Beats 100.00%

    Memory
    44.52 MB
    Beats 40.34%
 */
public static class Search2DMatrix
{
    private const int MaxItems = 10_000;

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        if (target < matrix[0][0] || target > matrix[^1][^1])
        {
            return false;
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            if (target >= matrix[i][0] && target <= matrix[i][^1])
            {
                return 0 <= Array.BinarySearch(matrix[i], target);
            }
        }

        return false;
    }

    public static bool SearchMatrix_1(int[][] matrix, int target)
    {
        if (target < matrix[0][0] || target > matrix[^1][^1])
        {
            return false;
        }

        var rigthLength = ((MaxItems + 1) / 8) + ((0 == (MaxItems + 1) % 8) ? 0 : 1);
        var leftLength = (MaxItems / 8) + ((0 == (MaxItems) % 8) ? 0 : 1);
        var maskRight = new int[rigthLength];
        var maskLeft = new int[leftLength];

        for (int i = 0; i < matrix.Length; i++) 
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (0 <= matrix[i][j])
                {
                    SetBit(maskRight, matrix[i][j]);
                }
                else
                {
                    SetBit(maskLeft, Math.Abs(matrix[i][j]));
                }
            }
        }

        return 0 <= target ? IsBitSet(maskRight, target) : IsBitSet(maskLeft, Math.Abs(target));
    }

    private static void SetBit(int[] mask, int index)
    {
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        mask[byteIndex] |= (1 << bitIndex);
    }

    private static bool IsBitSet(int[] mask, int index)
    {
        var byteIndex = index / 8;
        var bitIndex = index % 8;
        return 0 < (mask[byteIndex] & (1 << bitIndex));
    }
}
