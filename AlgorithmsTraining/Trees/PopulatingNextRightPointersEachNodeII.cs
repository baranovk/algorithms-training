namespace AlgorithmsTraining.Trees
{
    /*
     * 117. Populating Next Right Pointers in Each Node II

       Given a binary tree

       struct Node {
         int val;
         Node *left;
         Node *right;
         Node *next;
       }

       Populate each next pointer to point to its next right node. If there is no next right node, 
       the next pointer should be set to NULL.

       Initially, all next pointers are set to NULL.

       Example 1:

       Input: root = [1,2,3,4,5,null,7]
       Output: [1,#,2,3,#,4,5,7,#]
       Explanation: Given the above binary tree (Figure A), your function should populate each next pointer to point to 
       its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, 
       with '#' signifying the end of each level.

       Example 2:

       Input: root = []
       Output: []
       
       Constraints:
       
         [1] The number of nodes in the tree is in the range [0, 6000].
         [2] -100 <= Node.val <= 100

       Runtime
       100 ms
       Beats 5.37%

       Memory
       46.08 MB
       Beats 29.27%
     */
    public static class PopulatingNextRightPointersEachNodeII
    {
        public static Node Connect(Node root)
        {
            if (null == root) { return root; }

            Node prev = null;
            var stub = new Node();
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            queue.Enqueue(stub);

            while (queue.Count > 0)
            {
                while (true)
                {
                    var current = queue.Dequeue();

                    if (current == stub)
                    {
                        prev = null;
                        break;
                    }

                    if (null != current.left) { queue.Enqueue(current.left); }
                    if (null != current.right) { queue.Enqueue(current.right); }
                    if (null != prev) { prev.next = current; }
                    prev = current;
                }

                if (queue.Count > 0)
                {
                    queue.Enqueue(stub);
                }
            }

            return root;
        }
    }
}
