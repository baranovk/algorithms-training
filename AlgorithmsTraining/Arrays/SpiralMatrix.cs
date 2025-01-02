using Microsoft.Diagnostics.Runtime.Utilities;

namespace AlgorithmsTraining.Arrays;

public static class SpiralMatrix
{
    /*
     * Runtime
       0ms
       Beats 100.00%

       Memory
       45.97MB
       Beats 11.18%
     */
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        // height = matrix.Length
        // width = matrix[0].Length
        var result = new int[matrix.Length * matrix[0].Length];
        var resultIndex = -1;

        for(int xmin = 0, xmax = matrix[0].Length - 1, ymin = 0, ymax = matrix.Length - 1;
            xmin <= xmax && ymin <= ymax;
            xmin++, xmax--, ymin++, ymax--)
        {
            for (var i = xmin; i <= xmax; i++) { result[++resultIndex] = matrix[ymin][i]; }
            for (var i = ymin + 1; i <= ymax; i++) { result[++resultIndex] = matrix[i][xmax]; }
            for (var i = xmax - 1; i >= xmin && ymin < ymax; i--) { result[++resultIndex] = matrix[ymax][i]; }
            for (var i = ymax - 1; i > ymin && xmin < xmax; i--) { result[++resultIndex] = matrix[i][xmin]; }
        }

        return result;
    }
}
