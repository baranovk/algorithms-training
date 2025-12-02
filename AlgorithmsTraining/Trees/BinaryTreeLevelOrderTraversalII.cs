namespace AlgorithmsTraining.Trees
{
    /*
     * 107. Binary Tree Level Order Traversal II

       Given the root of a binary tree, return the bottom-up level order traversal of its nodes' values. 
       (i.e., from left to right, level by level from leaf to root).

       Example 1:
       
       Input: root = [3,9,20,null,null,15,7]
       Output: [[15,7],[9,20],[3]]
       
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
        0 ms
        Beats 100.00%

        Memory
        47.61 MB
        Beats 30.70%
     */
    public static class BinaryTreeLevelOrderTraversalII
    {
        public static IList<IList<int>> LevelOrderBottom(TreeNode root) => LevelOrder(root).Reverse().ToList();

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
}
