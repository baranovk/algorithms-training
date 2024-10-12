using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Trees
{
    public static class TreeUtils
    {
        public static TreeNode BuildBinaryTree(object[] values)
        {
            if (!values.Any() || null == values[0]) return null;

            Array.Reverse(values);
            var stack = new Stack<object>(values);
            var root = new TreeNode(Convert.ToInt32(stack.Pop()));

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (stack.Any())
            {
                var left = stack.Pop();
                var right = stack.Any() ? stack.Pop() : null;

                var current = queue.Dequeue();

                current.left = null == left ? null : new TreeNode(Convert.ToInt32(left));
                current.right = null == right ? null : new TreeNode(Convert.ToInt32(right));

                if (null != current.left) queue.Enqueue(current.left);
                if (null != current.right) queue.Enqueue(current.right);
            }

            return root;
        }

        public static TreeNodeExt BuildBinaryTreeExt(object[] values)
        {
            if (!values.Any() || null == values[0]) return null;

            Array.Reverse(values);
            var stack = new Stack<object>(values);

            var currentLevel = 0;
            var root = new TreeNodeExt(Convert.ToInt32(stack.Pop()), level: currentLevel);
            var queue = new Queue<TreeNodeExt>();
            queue.Enqueue(root);

            var processedValuesCount = 1;
            var nextLevelThreshold = 1;

            while (stack.Any())
            {
                var left = stack.Pop();
                var right = stack.Any() ? stack.Pop() : null;
                processedValuesCount += 2;

                if (processedValuesCount > nextLevelThreshold)
                {
                    nextLevelThreshold += (int)Math.Pow(2, ++currentLevel);
                }

                var current = queue.Dequeue();

                current.left = null == left ? null : new TreeNodeExt(Convert.ToInt32(left), current, level: currentLevel);
                current.right = null == right ? null : new TreeNodeExt(Convert.ToInt32(right), current, level: currentLevel);

                if (null != current.left) queue.Enqueue(current.left);
                if (null != current.right) queue.Enqueue(current.right);
            }

            return root;
        }

        public static TreeNode First(TreeNode root, Func<TreeNode, bool> predicate)
        {
            if (null == root) return null;
            if (predicate(root)) return root;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var current = queue.Dequeue();

                if (null != current.left && predicate(current.left))
                {
                    return current.left;
                }
                else if (null != current.left)
                {
                    queue.Enqueue(current.left);
                }

                if (null != current.right && predicate(current.right))
                {
                    return current.right;
                }
                else if (null != current.right)
                {
                    queue.Enqueue(current.right);
                }
            }

            return null;
        }

        public static TreeNodeExt First(TreeNodeExt root, Func<TreeNodeExt, bool> predicate)
        {
            if (null == root) return null;
            if (predicate(root)) return root;

            var queue = new Queue<TreeNodeExt>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var current = queue.Dequeue();

                if (null != current.left && predicate(current.left))
                {
                    return current.left;
                }
                else if(null != current.left)
                {
                    queue.Enqueue(current.left);
                }

                if (null != current.right && predicate(current.right))
                {
                    return current.right;
                }
                else if (null != current.right)
                {
                    queue.Enqueue(current.right);
                }
            }

            return null;
        } 
    }
}
