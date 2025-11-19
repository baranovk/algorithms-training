namespace AlgorithmsTraining.Trees;

/*
 * 103. Binary Tree Zigzag Level Order Traversal
 * 
 * Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
 * (i.e., from left to right, then right to left for the next level and alternate between).

   Example 1:

   Input: root = [3,9,20,null,null,15,7]
   Output: [[3],[20,9],[15,7]]
   
   Example 2:
   
   Input: root = [1]
   Output: [[1]]
   
   Example 3:
   
   Input: root = []
   Output: []

   Constraints:

    [1] The number of nodes in the tree is in the range [0, 2000].
    [2] -100 <= Node.val <= 100

 * Runtime
   0 ms
   Beats 100.00%

   Memory
   47.00 MB
   Beats 68.22%
 */
public static class BinaryTreeZigzagLevelOrderTraversal
{
    public static IList<IList<int>> ZigzagLevelOrder_1(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (null == root) { return result; }

        var level = 0;
        var stack = new Stack<TreeNode>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (((0 < level % 2) && 0 < stack.Count) || ((0 == level % 2) && 0 < queue.Count))
        {
            var levelNodes = new List<int>();

            if (0 < level % 2) 
            {
                while (0 < stack.Count)
                {
                    var current = stack.Pop();
                    levelNodes.Add(current.val);
                    if (null != current.left) { queue.Enqueue(current.left); }
                    if (null != current.right) { queue.Enqueue(current.right); }
                }
            }
            else
            {
                while (0 < queue.Count)
                {
                    var current = queue.Dequeue();
                    levelNodes.Add(current.val);
                    if (null != current.left) { stack.Push(current.left); }
                    if (null != current.right) { stack.Push(current.right); }
                }
            }

            level++;
            result.Add(levelNodes);
        }

        return result;
    }

    public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (null == root) { return result; }

        var currentLevel = -1;
        var currentLevelStack = new Stack<TreeNode>();
        var nextLevelStack = new Stack<TreeNode>();
        currentLevelStack.Push(root);

        while (currentLevelStack.Count > 0)
        {
            currentLevel++;
            var level = new List<int>();

            while (0 < currentLevelStack.Count)
            {
                var current = currentLevelStack.Pop();

                level.Add(current.val);

                if (0 == currentLevel % 2)
                {
                    if (null != current.left) { nextLevelStack.Push(current.left); }
                    if (null != current.right) { nextLevelStack.Push(current.right); }
                }
                else
                {
                    if (null != current.right) { nextLevelStack.Push(current.right); }
                    if (null != current.left) { nextLevelStack.Push(current.left); }
                }
            }

            result.Add(level);
            (currentLevelStack, nextLevelStack) = (nextLevelStack, currentLevelStack);
        }

        return result;
    }
}
