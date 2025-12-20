namespace AlgorithmsTraining.Trees
{
    public abstract class BinaryTreeNode<T> where T: BinaryTreeNode<T>
    {
        public int val;
        public T left;
        public T right;
    }
}
