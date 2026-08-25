namespace AlgorithmsTraining.Lists
{
    /*
     * 25. Reverse Nodes in k-Group
     * 
     * Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.
       k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes
       is not a multiple of k then left-out nodes, in the end, should remain as it is.
       You may not alter the values in the list's nodes, only nodes themselves may be changed.

       Example 1:

       Input: head = [1,2,3,4,5], k = 2
       Output: [2,1,4,3,5]
       
       Example 2:
       
       Input: head = [1,2,3,4,5], k = 3
       Output: [3,2,1,4,5]
       
       Constraints:
       
         [1] The number of nodes in the list is n.
         [2] 1 <= k <= n <= 5000
         [3] 0 <= Node.val <= 1000
       
       Follow-up: Can you solve the problem in O(1) extra memory space?

        Runtime
        0 ms
        Beats 100.00%

        Memory
        47.35 MB
        Beats 26.69%
            */
    public static class ReverseNodesInKGroup
    {
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            var counter = 1;
            var fakeHead = new ListNode(-1, head);
            ListNode currentHead = fakeHead, current = head.next, klast = head;

            reverse_group:

            while (null != current)
            {
                // memo next current
                var nextCurrent = current.next;

                // move current
                current.next = currentHead.next;
                currentHead.next = current;
                klast.next = nextCurrent;
                current = nextCurrent;
                
                if (++counter == k)
                {
                    currentHead = klast;
                    klast = current;
                    current = current?.next;
                    counter = 1;
                }
            }

            if (1 < counter)
            {
                klast = currentHead.next;
                current = klast.next;
                k = counter;
                counter = 1;
                goto reverse_group;
            }

            return fakeHead.next;
        }
    }
}
