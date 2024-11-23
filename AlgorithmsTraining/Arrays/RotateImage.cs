namespace AlgorithmsTraining.Arrays;

public static class RotateImage
{
    /*
     * 48. Rotate Image https://leetcode.com/problems/rotate-image/description/
     * 
     * Runtime
       0ms
       Beats 100.00%

       Memory
       45.62MB
       Beats 72.41%
     */
    public static void Solution(int[][] matrix)
    {
        int buffer, innerIndex = -1, dimension = matrix.Length;

        for (var i = 0; i < dimension; i++)
        {
            for (var j = ++innerIndex; j < dimension; j++)
            {
                buffer = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = buffer;
            }
        }

        for (var i = 0; i < dimension; i++)
        {
            for (int x = 0, y = dimension - 1; x < y; x++, y--)
            {
                buffer = matrix[i][x];
                matrix[i][x] = matrix[i][y];
                matrix[i][y] = buffer;
            }
        }
    }
}
