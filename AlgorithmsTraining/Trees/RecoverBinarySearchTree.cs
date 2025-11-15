namespace AlgorithmsTraining.Trees;

/*
 * 99. Recover Binary Search Tree

   You are given the root of a binary search tree (BST), where the values of exactly two nodes of the tree were swapped 
   by mistake. Recover the tree without changing its structure.

   Example 1:

   Input: root = [1,3,null,null,2]
   Output: [3,1,null,null,2]
   Explanation: 3 cannot be a left child of 1 because 3 > 1. Swapping 1 and 3 makes the BST valid.
   
   Example 2:

   Input: root = [3,1,4,null,null,2]
   Output: [2,1,4,null,null,3]
   Explanation: 2 cannot be in the right subtree of 3 because 2 < 3. Swapping 2 and 3 makes the BST valid.
   
   Constraints:
   
    [1] The number of nodes in the tree is in the range [2, 1000].
    [2] -2^31 <= Node.val <= 2^31 - 1

   Runtime
   3ms
   Beats 11.67%

   Memory
   51.59 MB
   Beats 5.83%
 */
public static class RecoverBinarySearchTree
{
    public static void RecoverTree(TreeNode root)
    {
        var errors = new LinkedList<TreeNode>();
        TraverseTree(root, errors, out _, out _);
        SwapNodeValues(errors.ElementAt(0), errors.ElementAt(1));
    }

    private static void TraverseTree(
        TreeNode root,
        LinkedList<TreeNode> errors,
        out TreeNode subTreeMin,
        out TreeNode subTreeMax)
    {
        TreeNode leftSubTreeMin = root, rightSubtreeMin = root, leftSubTreeMax = root, rightSubtreeMax = root;

        if (null != root.left)
        {
            TraverseTree(root.left, errors, out leftSubTreeMin, out leftSubTreeMax);
        }

        if (null != root.right)
        {
            TraverseTree(root.right, errors, out rightSubtreeMin, out rightSubtreeMax);
        }

        if (((0 < errors.Count) && (4 > errors.Count)) && ((leftSubTreeMax.val > root.val) || (rightSubtreeMin.val < root.val)))
        {
            errors.Clear();
        }

        if (4 > errors.Count && leftSubTreeMax.val > root.val)
        {
            errors.AddFirst(leftSubTreeMax);
            errors.AddLast(root);
        }
        
        if (4 > errors.Count && rightSubtreeMin.val < root.val)
        {
            errors.AddFirst(rightSubtreeMin);
            errors.AddLast(root);
        }

        subTreeMax = Max(root, Max(leftSubTreeMax, rightSubtreeMax));
        subTreeMin = Min(root, Min(leftSubTreeMin, rightSubtreeMin));
    }

    private static TreeNode Min(TreeNode x, TreeNode y) => x.val < y.val ? x : y;

    private static TreeNode Max(TreeNode x, TreeNode y) => x.val > y.val ? x : y;

    private static void SwapNodeValues(TreeNode x, TreeNode y) => (y.val, x.val) = (x.val, y.val);
}
