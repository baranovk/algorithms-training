namespace AlgorithmsTraining.Trees
{
    /*
     * 106. Construct Binary Tree from Inorder and Postorder Traversal

       Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree and postorder 
       is the postorder traversal of the same tree, construct and return the binary tree.

       Example 1:

       Input: inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
       Output: [3,9,20,null,null,15,7]
       
       Example 2:
       
       Input: inorder = [-1], postorder = [-1]
       Output: [-1]

       Constraints:

       [1] 1 <= inorder.length <= 3000
       [2] postorder.length == inorder.length
       [3] -3000 <= inorder[i], postorder[i] <= 3000
       [4] inorder and postorder consist of unique values.
       [5] Each value of postorder also appears in inorder.
       [6] inorder is guaranteed to be the inorder traversal of the tree.
       [7] postorder is guaranteed to be the postorder traversal of the tree.

       Runtime
       14 ms
       Beats 17.87%

       Memory
       45.14 MB
       Beats 18.84%
     */
    public static class BinaryTreeFromTwoTraversalsII
    {
        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (0 == inorder.Length) { return null; }
            if (1 == inorder.Length) { return new TreeNode(inorder[0]); }
            return BuldTreeInternal(postorder.AsSpan(0), inorder.AsSpan(0));
        }

        private static TreeNode BuldTreeInternal(Span<int> postorder, Span<int> inorder)
        {
            // inorder:   1   2   3
            // postorder: 1   3   2
            var root = new TreeNode(postorder[^1]);
            if (1 == postorder.Length) { return root; }

            int inorderRootIndex, nodesCount;

            for (inorderRootIndex = 0, nodesCount = 0;
                 inorderRootIndex < inorder.Length && inorder[inorderRootIndex] != root.val;
                 inorderRootIndex++, nodesCount++) ;

            root.left = 0 < inorderRootIndex ? BuldTreeInternal(postorder[..nodesCount], inorder[..nodesCount]) : null;
            root.right = inorderRootIndex + 1 < inorder.Length 
                ? BuldTreeInternal(postorder.Slice(nodesCount, postorder.Length - nodesCount - 1), inorder[(nodesCount + 1)..]) 
                : null;

            return root;
        }
    }
}
