namespace AlgorithmsTraining.Lists
{
    /*
     * 142. Linked List Cycle II
     * 
     * Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.

        There is a cycle in a linked list if there is some node in the list that can be reached again by continuously
        following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is
        connected to (0-indexed). It is -1 if there is no cycle. Note that pos is not passed as a parameter.

        Do not modify the linked list.

        Example 1:

        Input: head = [3,2,0,-4], pos = 1
        Output: tail connects to node index 1
        Explanation: There is a cycle in the linked list, where tail connects to the second node.
        
        Example 2:

        Input: head = [1,2], pos = 0
        Output: tail connects to node index 0
        Explanation: There is a cycle in the linked list, where tail connects to the first node.
        
        Example 3:

        Input: head = [1], pos = -1
        Output: no cycle
        Explanation: There is no cycle in the linked list.
        
        Constraints:
        
        [1] The number of the nodes in the list is in the range [0, 104].
        [2] -10^5 <= Node.val <= 10^5
        [3] pos is -1 or a valid index in the linked-list.

        Runtime
        101 ms
        Beats 15.80%

        Memory
        47.52 MB
        Beats 86.27%
     */
    public static class LinkedListCycleII
    {
        public static ListNode DetectCycle(ListNode head)
        {
            if (null == head || null == head.next) { return null; }

            var mask = 1 << 17;
            ListNode current = head, cycleStart;

            while (true)
            {
                if (null == current.next) { cycleStart = null; break; }
                if (current.next.val >= 0 && (current.next.val & mask) > 0)  { cycleStart = current.next; break; }
                if (current.next.val < 0  && (current.next.val & mask) == 0) { cycleStart = current.next; break; }

                current.val ^= mask;
                current = current.next;
            }

            current = head;

            while (true)
            {
                if (current != null) { current.val ^= mask; }
                if (current == cycleStart) { break; }
                current = current.next;
            }

            return cycleStart;
        }
    }
}
