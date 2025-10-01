using System.Collections;

namespace AlgorithmsTraining.Trees;

public class BreadthFirstTreeCrawler : IEnumerable<TreeNode>
{
    public BreadthFirstTreeCrawler(TreeNode root)
    {
        Root = root;
    }

    protected TreeNode Root { get; private set; }

    public IEnumerator<TreeNode> GetEnumerator()
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (0 < queue.Count)
        {
            var current = queue.Dequeue();

            if (null != current)
            {
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }

            yield return current;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
