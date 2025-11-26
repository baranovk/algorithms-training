using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Trees
{
    /*
     * 109. Convert Sorted List to Binary Search Tree
     * 
     * Given the head of a singly linked list where elements are sorted in ascending order, convert it to a binary search tree.
     
     * Example 1:
     * 
     * Input: head = [-10,-3,0,5,9]
       Output: [0,-3,9,-10,null,5]
       Explanation: One possible answer is [0,-3,9,-10,null,5], which represents the shown height balanced BST.
       
       Example 2:
       
       Input: head = []
       Output: []
       
       Constraints:
       
         [1] The number of nodes in head is in the range [0, 2 * 10^4].
         [1] -10^5 <= Node.val <= 10^5

         Runtime
         2ms
         Beats 47.93%

         Memory
         48.72 MB
         Beats 6.61%
     */
    public static class ConvertSortedListToBinarySearchTree
    {
        public static TreeNode SortedListToBST(ListNode head)
        {
            if (null == head) { return null; }
            var values = new int[100_000];

            var current = head;
            var length = 0;

            do
            {
                values[length++] = current.val;
                current = current.next;
            }
            while (null != current);

            return BuildTree(0, length - 1, values);
        }

        private static TreeNode BuildTree(int left, int right, int[] values)
        {
            if (left == right) { return new TreeNode(values[left]); }
            if (left > right) { return null; }

            var middle = (left + right) / 2;

            var root = new TreeNode(values[middle])
            {
                left = BuildTree(left, middle - 1, values),
                right = BuildTree(middle + 1, right, values)
            };

            return root;
        }
    }
}
