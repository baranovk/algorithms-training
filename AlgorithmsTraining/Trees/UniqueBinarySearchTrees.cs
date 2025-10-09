namespace AlgorithmsTraining.Trees;

public static class UniqueBinarySearchTrees
{
    /*
     * 96. Unique Binary Search Trees

       Given an integer n, return the number of structurally unique BST's (binary search trees) which has 
       exactly n nodes of unique values from 1 to n.

       Example 1:

       Input: n = 3
       Output: 5

       Example 2:

       Input: n = 1
       Output: 1

    Constraints:

       [1] 1 <= n <= 19

    Runtime
    4 ms
    Beats 10.22%

    Memory
    30.09 MB
    Beats 6.57%
     */
    public static int NumTrees(int n)
    {
        return BuildTrees(1, n, []);
    }

    private static int BuildTrees(int start, int end, Dictionary<(int, int), int> memo)
    {
        if (memo.TryGetValue((start, end), out var treesCount)) { return treesCount; }
        if (start > end) return 0;

        for (int i = start; i <= end; i++)
        {
            var leftTreesCount = BuildTrees(start, i - 1, memo);
            var rightTreesCount = BuildTrees(i + 1, end, memo);

            treesCount += (0 == leftTreesCount ? 1 : leftTreesCount) * (0 == rightTreesCount ? 1 : rightTreesCount);
        }

        memo.Add((start, end), treesCount);
        return treesCount;
    }
}
