namespace AlgorithmsTraining.Trees;

/*
 * 95. Unique Binary Search Trees II

   Given an integer n, return all the structurally unique BST's (binary search trees), which has exactly n nodes of 
   unique values from 1 to n. Return the answer in any order.

   Example 1:

   Input: n = 3
   Output: [[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]

   Example 2:

   Input: n = 1
   Output: [[1]]

  Constraints:

    [1] 1 <= n <= 8

  Runtime
  80 ms
  Beats 5.71%

  Memory
  60.95 MB
  Beats 7.62%
 */
public static class UniqueBinarySearchTreesII
{
    public static IList<TreeNode> GenerateTrees(int n)
    {
        var trees = new List<TreeNode>();
        var values = Enumerable.Range(1, n).ToArray();
        var permutations = new List<IList<int>>();
        var memo = values.ToDictionary(v => v, _ => new HashSet<int>());

        Permute(0, values, new Queue<int>(values), permutations);

        foreach (var permutation in permutations)
        {
            var root = BuildBinarySearchTree(permutation);
            var hash = ComputeTreeHash(root);

            if (memo[root.val].Contains(hash)) { continue; }

            memo[root.val].Add(hash);
            trees.Add(root);
        }

        return trees;
    }

    private static void Permute(int index, int[] nums, Queue<int> numsQueue, IList<IList<int>> result)
    {
        for (var i = 0; i < numsQueue.Count; i++)
        {
            var num = numsQueue.Dequeue();
            nums[index] = num;

            if (0 == numsQueue.Count)
            {
                result.Add(new List<int>(nums));
            }
            else
            {
                Permute(index + 1, nums, numsQueue, result);
            }

            numsQueue.Enqueue(num);
        }
    }

    private static TreeNode BuildBinarySearchTree(IList<int> values)
    {
        if (0 == values.Count) { return null; }

        var root = new TreeNode(values[0]);

        for (var i = 1; i < values.Count; i++)
        {
            var current = root;
            var node = new TreeNode(values[i]);

            while (true)
            {
                if (node.val <= current.val)
                {
                    if (null == current.left)
                    {
                        current.left = node;
                        break;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                else
                {
                    if (null == current.right)
                    {
                        current.right = node;
                        break;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
            }
        }

        return root;
    }

    private static int ComputeTreeHash(TreeNode root)
    {
        var hash = 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (0 < queue.Count)
        {
            var current = queue.Dequeue();
            hash = HashCode.Combine(hash, current.val);

            if (null != current && null != current.left) { queue.Enqueue(current.left); }
            if (null != current && null != current.right) { queue.Enqueue(current.right); }
        }
        
        return hash;
    }
}
