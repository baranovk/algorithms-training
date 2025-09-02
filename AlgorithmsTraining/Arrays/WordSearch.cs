namespace AlgorithmsTraining.Arrays;

public static class WordSearch
{
    /*
     * 79. Word Search

       Given an m x n grid of characters board and a string word, return true if word exists in the grid.

       The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally 
       or vertically neighboring. The same letter cell may not be used more than once.

       Example 1:

       Input: board = 
       [
        ["A","B","C","E"],
        ["S","F","C","S"],
        ["A","D","E","E"]
       ], 
       word = "ABCCED"
       Output: true

       Example 2:

       Input: board = 
       [
        ["A","B","C","E"],
        ["S","F","C","S"],
        ["A","D","E","E"]
       ], 
       word = "SEE"
       Output: true

       Example 3:
       Input: board = 
       [
        ["A","B","C","E"],
        ["S","F","C","S"],
        ["A","D","E","E"]
       ], 
       word = "ABCB"
       Output: false

       Constraints:

       [1] m == board.length
       [2] n = board[i].length
       [3] 1 <= m, n <= 6
       [4] 1 <= word.length <= 15
       [5] board and word consists of only lowercase and uppercase English letters.

       Runtime
       381 ms
       Beats 44.25%

       Memory
       60.6 MB
       Beats 5.97%
     */
    public static bool Exist(char[][] board, string word)
    {
        var traverseStack = new Stack<CurrentLetter>();
        byte[,] positionsMemo = new byte[board.Length, board[0].Length];

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (Traverse(board, word, i, j, traverseStack, positionsMemo)) { return true; }
            }
        }

        return false;
    }

    private static bool Traverse(char[][] board, string word, int y, int x, Stack<CurrentLetter> traverseStack, byte[,] positionsMemo)
    {
        traverseStack.Clear();

        var maxY = board.Length - 1;
        var maxX = board[0].Length - 1;

        traverseStack.Push(new CurrentLetter(board[y][x], y: y, x: x, level: 0, FillAvailableDirections(y: y, x: x, maxY, maxX, positionsMemo )));
        positionsMemo[y, x] = 1;

        while (traverseStack.Count > 0)
        {
            var current = traverseStack.Peek();

            if (current.Letter != word[current.Level]) 
            { 
                traverseStack.Pop();
                positionsMemo[current.Position.Y, current.Position.X] = 0;
                continue; 
            }

            if (current.Level == word.Length - 1) { return true; }

            if (current.Directions.HasFlag(Directions.Up)) 
            {
                traverseStack.Push(
                    new CurrentLetter(
                        board[current.Position.Y - 1][current.Position.X], 
                        y: current.Position.Y - 1, 
                        x: current.Position.X, 
                        level: current.Level + 1, 
                        FillAvailableDirections(y: current.Position.Y - 1, x: current.Position.X, maxY, maxX, positionsMemo, Directions.Bottom)
                    )
                );

                current.Directions ^= Directions.Up;
                positionsMemo[current.Position.Y - 1, current.Position.X] = 1;
            }
            else if (current.Directions.HasFlag(Directions.Right))
            {
                traverseStack.Push(
                    new CurrentLetter(
                        board[current.Position.Y][current.Position.X + 1],
                        y: current.Position.Y,
                        x: current.Position.X + 1,
                        level: current.Level + 1,
                        FillAvailableDirections(y: current.Position.Y, x: current.Position.X + 1, maxY, maxX, positionsMemo, Directions.Left)
                    )
                );

                current.Directions ^= Directions.Right;
                positionsMemo[current.Position.Y, current.Position.X + 1] = 1;
            }
            else if (current.Directions.HasFlag(Directions.Bottom))
            {
                traverseStack.Push(
                    new CurrentLetter(
                        board[current.Position.Y + 1][current.Position.X],
                        y: current.Position.Y + 1,
                        x: current.Position.X,
                        level: current.Level + 1,
                        FillAvailableDirections(y: current.Position.Y + 1, x: current.Position.X, maxY, maxX, positionsMemo, Directions.Up)
                    )
                );

                current.Directions ^= Directions.Bottom;
                positionsMemo[current.Position.Y + 1, current.Position.X] = 1;
            }
            else if (current.Directions.HasFlag(Directions.Left))
            {
                traverseStack.Push(
                    new CurrentLetter(
                        board[current.Position.Y][current.Position.X - 1],
                        y: current.Position.Y,
                        x: current.Position.X - 1,
                        level: current.Level + 1,
                        FillAvailableDirections(y: current.Position.Y, x: current.Position.X - 1, maxY, maxX, positionsMemo, Directions.Right)
                    )
                );

                current.Directions ^= Directions.Left;
                positionsMemo[current.Position.Y, current.Position.X - 1] = 1;
            }
            else
            {
                // all directions checked
                positionsMemo[current.Position.Y, current.Position.X] = 0;
                traverseStack.Pop();
            }
        }
        
        return false;
    }

    private struct Position
    {
        public Position(int y, int x)
        {
            Y = y; 
            X = x;
        }

        public int X;
        public int Y;
    }

    private class CurrentLetter
    {
        public CurrentLetter(char letter, int y, int x, int level, Directions directions)
        {
            Letter = letter;
            Position = new(y, x);
            Level = level;
            Directions = directions;
        }

        public char Letter;
        public Position Position;
        public int Level;
        public Directions Directions;
    }

    [Flags]
    private enum Directions
    { 
        None = 0,
        Up = 1,
        Right = 1 << 1,
        Bottom = 1 << 2,
        Left = 1 << 3,
        All = Up | Right | Left | Bottom
    }

    private static Directions FillAvailableDirections(int y, int x, int maxY, int maxX, byte[,] memo, Directions exclude = Directions.None)
    {
        var directions = Directions.None;
        if (y > 0 && 0 == memo[y - 1, x]) { directions |= Directions.Up; }
        if (y >= 0 && y < maxY && 0 == memo[y + 1, x]) { directions |= Directions.Bottom; }
        if (x >= 0 && x < maxX && 0 == memo[y, x + 1]) { directions |= Directions.Right; }
        if (x > 0 && 0 == memo[y, x - 1]) { directions |= Directions.Left; }
        return Directions.None != exclude && exclude == (exclude & directions) ? directions ^ exclude : directions;
    }
}
