using System.Collections;

namespace AlgorithmsTraining.Trees;

public class DepthFirstTreeCrawler : IEnumerable<TreeNode>
{
    public DepthFirstTreeCrawler(TreeNode root)
    {
        Root = root;
    }

    protected TreeNode Root { get; private set; }

    public IEnumerator<TreeNode> GetEnumerator()
    {
        var stack = new Stack<TreeNode>();
        var current = Root;

        do
        {
            yield return current;

            if (null == current)
            {
                current = stack.Pop();
            }
            else if (null != current.left)
            {
                stack.Push(current.right);
                current = current.left;
            }
            else if (null != current.right)
            {
                current = current.right;
            }
            else
            {
                current = stack.Pop();
            }
        }
        while (0 < stack.Count);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
