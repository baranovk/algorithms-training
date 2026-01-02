namespace AlgorithmsTraining.Arrays
{
    /*
     * 120. Triangle
     * 
     * Given a triangle array, return the minimum path sum from top to bottom.

      For each step, you may move to an adjacent number of the row below. More formally, if you 
      are on index i on the current row, you may move to either index i or index i + 1 on the next row.

      Example 1:
      
      Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
      Output: 11
      Explanation: The triangle looks like:
         2
        3 4
       6 5 7
      4 1 8 3
      The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).
      
      Example 2:
      
      Input: triangle = [[-10]]
      Output: -10
      
      Constraints:
      
       [1] 1 <= triangle.length <= 200
       [2] triangle[0].length == 1
       [3] triangle[i].length == triangle[i - 1].length + 1
       [4] -10^4 <= triangle[i][j] <= 10^4

       Runtime
       5 ms
       Beats 33.93%

       Memory
       44.26 MB
       Beats 59.29%
     */
    public static class Triangle
    {
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            var minTotal = triangle[0][0];

            for (int i = 1; i < triangle.Count; i++)
            {
                minTotal = int.MaxValue;

                for (int j = 0; j < triangle[i].Count; j++)
                {
                    triangle[i][j] = triangle[i][j] + 
                        (0 == j 
                            ? triangle[i - 1][j] 
                            : j == triangle[i - 1].Count
                                ? triangle[i - 1][j - 1] 
                                : Math.Min(triangle[i - 1][j - 1], triangle[i - 1][j]));

                    minTotal = Math.Min(minTotal, triangle[i][j]);
                }
            }

            return minTotal;
        }
    }
}
