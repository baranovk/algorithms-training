using System.Collections;

namespace AlgorithmsTraining.Trees;

public class BreadthFirstTreeCrawler<T> : IEnumerable<BinaryTreeNode<T>> where T : BinaryTreeNode<T>
{
    public BreadthFirstTreeCrawler(BinaryTreeNode<T> root)
    {
        Root = root;
    }

    protected BinaryTreeNode<T> Root { get; private set; }

    public IEnumerator<BinaryTreeNode<T>> GetEnumerator()
    {
        var queue = new Queue<BinaryTreeNode<T>>();
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
