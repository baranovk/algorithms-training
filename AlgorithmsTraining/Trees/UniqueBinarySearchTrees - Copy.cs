namespace AlgorithmsTraining.Trees;

public static class UniqueBinarySearchTreesAlt
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
     */
    public static int NumTrees(int n)
    {
        return BuildTrees(1, n, []).Count;
    }

    private static IList<TreeNode> BuildTrees(int start, int end, Dictionary<(int, int), IList<TreeNode>> memo)
    {
        if (memo.TryGetValue((start, end), out var trees)) { return trees; }

        if (start > end) return [null];

        trees = [];

        for (int i = start; i <= end; i++)
        {
            var leftTrees = BuildTrees(start, i - 1, memo);
            var rightTrees = BuildTrees(i + 1, end, memo);

            foreach (var leftTree in leftTrees)
            {
                foreach (var rightTree in rightTrees)
                {
                    var root = new TreeNode(i, leftTree, rightTree);
                    trees.Add(root);
                }
            }
        }

        memo.Add((start, end), trees);
        return trees;
    }
}
