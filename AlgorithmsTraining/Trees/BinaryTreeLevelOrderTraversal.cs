namespace AlgorithmsTraining.Trees;

/*
 * 102. Binary Tree Level Order Traversal
 * 
 * Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

   Example 1:
   
   Input: root = [3,9,20,null,null,15,7]
   Output: [[3],[9,20],[15,7]]
   
   Example 2:
   
   Input: root = [1]
   Output: [[1]]
   
   Example 3:
   
   Input: root = []
   Output: []

   Constraints:

    [1] The number of nodes in the tree is in the range [0, 2000].
    [2] -1000 <= Node.val <= 1000

    Runtime
    0ms
    Beats 100.00%

    Memory
    48.60 MB
    Beats 50.89%
 */
public static class BinaryTreeLevelOrderTraversal
{
    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (null == root) { return result; }

        var stub = new TreeNode();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(stub);

        while (queue.Count > 0)
        {
            var level = new List<int>();

            while (true)
            {
                var current = queue.Dequeue();

                if (current == stub)
                {
                    break;
                }

                level.Add(current.val);

                if (null != current.left) { queue.Enqueue(current.left); }
                if (null != current.right) { queue.Enqueue(current.right); }
            }

            result.Add(level);

            if (queue.Count > 0)
            {
                queue.Enqueue(stub);
            }
        }

        return result;
    }
}
