using System.Diagnostics;

namespace AlgorithmsTraining.Trees
{
    [DebuggerDisplay("val = {val}")]
    public class TreeNode : BinaryTreeNode<TreeNode>
    {
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
