namespace AlgorithmsTraining.Trees;

/*
 *  113. Path Sum II

    Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node 
    values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

    A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.

    Example 1:

    Input: root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
    Output: [[5,4,11,2],[5,8,4,5]]
    Explanation: There are two paths whose sum equals targetSum:
    5 + 4 + 11 + 2 = 22
    5 + 8 + 4 + 5 = 22
    
    Example 2:

    Input: root = [1,2,3], targetSum = 5
    Output: []
    
    Example 3:
    
    Input: root = [1,2], targetSum = 0
    Output: []

    Constraints:

    [1] The number of nodes in the tree is in the range [0, 5000].
    [2] -1000 <= Node.val <= 1000
    [3] -1000 <= targetSum <= 1000

    Runtime
    1ms
    Beats 44.62%

    Memory
    48.90 MB
    Beats 96.81%
 */
public static class PathSumII
{
    public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var results = new List<IList<int>>();
        if (null == root) { return results; }
        var stackPath = new Stack<TreeNode>();

        Traverse(root, stackPath, targetSum, 0, results);

        return results;
    }

    private static void Traverse(
        TreeNode root, 
        Stack<TreeNode> pathStack, 
        int targetSum, 
        int currentSum,
        IList<IList<int>> results)
    {
        pathStack.Push(root);
        currentSum += root.val;

        if (null == root.left && null == root.right && currentSum == targetSum)
        {
            var path = CopyPathFrom(pathStack);
            results.Add(path);
        }

        if (null != root.left)
        {
            Traverse(root.left, pathStack, targetSum, currentSum, results);
        }

        if (null != root.right)
        {
            Traverse(root.right, pathStack, targetSum, currentSum, results);
        }

        pathStack.Pop();
    }

    private static List<int> CopyPathFrom(Stack<TreeNode> stack)
    {
        List<int> path = new(stack.Count);
        var enumerator = stack.GetEnumerator();

        while (enumerator.MoveNext())
        {
            path.Add(enumerator.Current.val);
        }

        path.Reverse();
        return path;
    }
}
