namespace AlgorithmsTraining.Arrays;

/*
 * 73. Set Matrix Zeroes
 * https://leetcode.com/problems/set-matrix-zeroes/description/
 * 
 * Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

   You must do it in place.

   Constraints:

    m == matrix.length
    n == matrix[0].length
    1 <= m, n <= 200
    -2^31 <= matrix[i][j] <= 2^31 - 1

    Follow up:

    A straightforward solution using O(mn) space is probably a bad idea.
    A simple improvement uses O(m + n) space, but still not the best solution.
    Could you devise a constant space solution?

    Runtime
    1ms
    Beats 100.00%

    Memory
    53.16MB
    Beats 77.37%
 */
public static class SetMatrixZeroes
{
    public static void SetZeroes(int[][] matrix)
    {
        bool zeroRow = 0 == matrix[0][0], zeroColumn = 0 == matrix[0][0];
        for (int i = 0; i < matrix.Length; zeroColumn |= 0 == matrix[i][0], i++) ;
        for (int i = 0; i < matrix[0].Length; zeroRow |= 0 == matrix[0][i], i++) ;

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (0 == matrix[i][j]) { matrix[i][0] = 0; matrix[0][j] = 0; }
            }
        }

        // rows
        for (int i = 1; i < matrix.Length; i++)
        {
            if (0 != matrix[i][0]) { continue; }
            for (int j = 1; j < matrix[i].Length; matrix[i][j] = 0, j++) ;
        }

        // columns
        for (int j = 1; j < matrix[0].Length; j++)
        {
            if (0 != matrix[0][j]) { continue; }
            for (int i = 1; i < matrix.Length; matrix[i][j] = 0, i++) ;
        }

        for (int i = 0; zeroColumn && i < matrix.Length; matrix[i][0] = 0, i++) ;
        for (int i = 0; zeroRow && i < matrix[0].Length; matrix[0][i] = 0, i++) ;
    }
}
