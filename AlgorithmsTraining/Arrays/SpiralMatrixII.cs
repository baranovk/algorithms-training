namespace AlgorithmsTraining.Arrays;

/*
 * 59. Spiral Matrix II

   Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.

   Example 1:

   Input: n = 3
   Output: [[1,2,3],[8,9,4],[7,6,5]]

   Example 2:

   Input: n = 1
   Output: [[1]]

   Constraints:

   1 <= n <= 20

   Runtime
   0 ms
   Beats 100.00%

   Memory
   40.47 MB
   Beats 12.22%
 */
public static class SpiralMatrixII
{
    public static int[][] GenerateMatrix(int n)
    {
        // height = matrix.Length
        // width = matrix[0].Length
        var matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        var current = 0;

        for (int xmin = 0, xmax = matrix[0].Length - 1, ymin = 0, ymax = matrix.Length - 1;
            xmin <= xmax && ymin <= ymax;
            xmin++, xmax--, ymin++, ymax--)
        {
            for (var i = xmin; i <= xmax; i++) { matrix[ymin][i] = ++current; }
            for (var i = ymin + 1; i <= ymax; i++) { matrix[i][xmax] = ++current; }
            for (var i = xmax - 1; i >= xmin && ymin < ymax; i--) { matrix[ymax][i] = ++current; }
            for (var i = ymax - 1; i > ymin && xmin < xmax; i--) { matrix[i][xmin] = ++current; }
        }

        return matrix;
    }
}
