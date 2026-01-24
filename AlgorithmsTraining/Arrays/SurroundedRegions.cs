namespace AlgorithmsTraining.Arrays
{
    /*
     * 130. Surrounded Regions

       You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:

        [] Connect: A cell is connected to adjacent cells horizontally or vertically.
        [] Region: To form a region connect every 'O' cell.
        [] Surround: The region is surrounded with 'X' cells if you can connect the region with 'X' cells and none of 
           the region cells are on the edge of the board.

        To capture a surrounded region, replace all 'O's with 'X's in-place within the original board. You do not need to return anything.

        Example 1:
        
        Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
        Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
        
        Explanation:
        In the above diagram, the bottom region is not captured because it is on the edge of the board and cannot be surrounded.

        Example 2:
        
        Input: board = [["X"]]
        Output: [["X"]]

        Constraints:

          [1] m == board.length
          [2] n == board[i].length
          [3] 1 <= m, n <= 200
          [4] board[i][j] is 'X' or 'O'.

          Runtime
          1 ms
          Beats 100.00%
          
          Memory
          64.73 MB
          Beats 59.56%
     */
    public static class SurroundedRegions
    {
        private const char InfectStub = 'Y';

        public static void Solve(char[][] board)
        {
            int n = board.Length, m = 0 == board.Length ? 0 : board[0].Length;
            if (9 > n * m) { return; }

            for (int i = 0, ii = n - 1, j = 0; j < m; j++) { TryInfect(i, j, board, n, m); TryInfect(ii, j, board, n, m); }
            for (int j = 0, jj = m - 1, i = 0; i < n; i++) { TryInfect(i, j, board, n, m); TryInfect(i, jj, board, n, m); }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    board[i][j] = InfectStub == board[i][j] ? 'O' : 'X';
                }
            }
        }

        private static void TryInfect(int i, int j, char[][] board, int n, int m)
        {
            if (InfectStub == board[i][j] || 'X' == board[i][j]) { return; }

            board[i][j] = InfectStub;

            if (j + 1 < m - 1) { TryInfect(i, j + 1, board, n, m); }
            if (i - 1 > 0)     { TryInfect(i - 1, j, board, n, m); }
            if (j - 1 > 0)     { TryInfect(i, j - 1, board, n, m); }
            if (i + 1 < n - 1) { TryInfect(i + 1, j, board, n, m); }
        }
    }
}
