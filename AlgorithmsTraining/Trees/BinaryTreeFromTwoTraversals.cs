namespace AlgorithmsTraining.Trees;

/*
 * 105. Construct Binary Tree from Preorder and Inorder Traversal
 * 
   Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary 
   tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

   Example 1:
   Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
   Output: [3,9,20,null,null,15,7]
   
   Example 2:
   
   Input: preorder = [-1], inorder = [-1]
   Output: [-1]

   Constraints:

    [1] 1 <= preorder.length <= 3000
    [2] inorder.length == preorder.length
    [3] -3000 <= preorder[i], inorder[i] <= 3000
    [4] preorder and inorder consist of unique values.
    [5] Each value of inorder also appears in preorder.
    [6] preorder is guaranteed to be the preorder traversal of the tree.
    [7] inorder is guaranteed to be the inorder traversal of the tree.

    Runtime
    14 ms
    Beats 34.47%

    Memory
    45.04 MB
    Beats 28.06%
 */
public static class BinaryTreeFromTwoTraversals
{
    public static TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (0 == preorder.Length) { return null; }
        if (1 == preorder.Length) { return new TreeNode(preorder[0]); }
        return BuldTreeInternal(preorder.AsSpan(0), inorder.AsSpan(0));
    }

    private static TreeNode BuldTreeInternal(Span<int> preorder, Span<int> inorder)
    {
        var root = new TreeNode(preorder[0]);
        if (1 == preorder.Length) { return root;  }

        int inorderRootIndex, nodesCount;

        for (inorderRootIndex = 0, nodesCount = 0; 
             inorderRootIndex < inorder.Length && inorder[inorderRootIndex] != preorder[0]; 
             inorderRootIndex++, nodesCount++);

        root.left = 0 < inorderRootIndex ? BuldTreeInternal(preorder.Slice(1, nodesCount), inorder[..nodesCount]) : null;
        root.right = inorderRootIndex + 1 < inorder.Length ? BuldTreeInternal(preorder[(nodesCount + 1)..], inorder[(nodesCount + 1)..]) : null;

        return root;
    }
}
