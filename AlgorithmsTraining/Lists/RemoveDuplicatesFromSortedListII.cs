namespace AlgorithmsTraining.Lists;

/*
 * 82. Remove Duplicates from Sorted List II

   Given the head of a sorted linked list, delete all nodes that have duplicate numbers, 
   leaving only distinct numbers from the original list. Return the linked list sorted as well.

   Example 1:

   Input: head = [1,2,3,3,4,4,5]
   Output: [1,2,5]

   Example 2:

   Input: head = [1,1,1,2,3]
   Output: [2,3]

   Constraints:

    [1] The number of nodes in the list is in the range [0, 300].
    [2] -100 <= Node.val <= 100
    [3] The list is guaranteed to be sorted in ascending order.

    Runtime
    0 ms
    Beats 100.00%

    Memory
    43.41 MB
    Beats 41.95%
 */
public static class RemoveDuplicatesFromSortedListII
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (null == head || null == head.next) { return head; }
        ListNode prevnode = new(-1, head), inode = head, jnode = head;

        do
        {
            if (jnode.val == jnode.next?.val) { jnode = jnode.next; continue; }

            // ASSERT: (null == jnode.next || jnode.val != jnode.next.val)
            if (inode != jnode)
            {
                head = head == inode ? jnode.next : head;
                prevnode.next = inode = jnode = jnode.next;
            }
            else { prevnode = inode; prevnode.next = inode = jnode = jnode.next;  }
        }
        while (null != jnode);

        return head;
    }
}
