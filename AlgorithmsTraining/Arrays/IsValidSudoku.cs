namespace AlgorithmsTraining.Arrays;

/*
 * 36. Valid Sudoku
 * https://leetcode.com/problems/valid-sudoku/description/
    
   Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

   - Each row must contain the digits 1-9 without repetition.
   - Each column must contain the digits 1-9 without repetition.
   - Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

    Note:

    A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    Only the filled cells need to be validated according to the mentioned rules.

    Example 1:

    Input: board = 

    [["5","3",".",".","7",".",".",".","."]
    ,["6",".",".","1","9","5",".",".","."]
    ,[".","9","8",".",".",".",".","6","."]
    ,["8",".",".",".","6",".",".",".","3"]
    ,["4",".",".","8",".","3",".",".","1"]
    ,["7",".",".",".","2",".",".",".","6"]
    ,[".","6",".",".",".",".","2","8","."]
    ,[".",".",".","4","1","9",".",".","5"]
    ,[".",".",".",".","8",".",".","7","9"]]
    Output: true

    Example 2:
    
    Input: board = 

    [["8","3",".",".","7",".",".",".","."]
    ,["6",".",".","1","9","5",".",".","."]
    ,[".","9","8",".",".",".",".","6","."]
    ,["8",".",".",".","6",".",".",".","3"]
    ,["4",".",".","8",".","3",".",".","1"]
    ,["7",".",".",".","2",".",".",".","6"]
    ,[".","6",".",".",".",".","2","8","."]
    ,[".",".",".","4","1","9",".",".","5"]
    ,[".",".",".",".","8",".",".","7","9"]]

    Output: false

    Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are 
    two 8's in the top left 3x3 sub-box, it is invalid.

    Constraints:

    - board.length == 9
    - board[i].length == 9
    - board[i][j] is a digit 1-9 or '.'.

    Runtime
    2ms
    Beats 87.47%

    Memory
    47.92MB
    Beats 84.11%
 */
public static class IsValidSudoku
{
    const int Size = 9;

    public static bool Solution(char[][] board)
    {
        // ASSERT: board.GetLength(0) - кол-во строк
        Span<byte> row = stackalloc byte[Size + 1];
        Span<byte> column = stackalloc byte[Size + 1];

        for (var i = 0; i < Size; i++, row.Clear(), column.Clear())
        {
            for (var j = 0; j < Size; j++)
            {
                if ('.' != board[i][j])
                {
                    if (1 < ++row[board[i][j] - '0']) { return false; }
                }

                if ('.' != board[j][i])
                {
                    if (1 < ++column[board[j][i] - '0']) { return false; }
                }
            }
        }

        Span<byte> square = stackalloc byte[Size + 1];

        for (int rowbase = 0; rowbase < Size; rowbase += 3)
        {
            for (int colbase = 0; colbase < Size; colbase += 3, square.Clear())
            {
                for (int i = rowbase; i - rowbase < 3; i++)
                {
                    for (int j = colbase; j - colbase < 3; j++)
                    {
                        if ('.' != board[i][j])
                        {
                            if (1 < ++square[board[i][j] - '0']) { return false; }
                        }
                    }
                }
            }
        }

        return true;
    }
}
