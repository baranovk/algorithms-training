using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists;

/*
 * 86. Partition List

   Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

   You should preserve the original relative order of the nodes in each of the two partitions.

   Example 1:

   Input: head = [1,4,3,2,5,2], x = 3
   Output: [1,2,2,4,3,5]

   Example 2:

   Input: head = [2,1], x = 2
   Output: [1,2]

   Constraints:

    [1] The number of nodes in the list is in the range [0, 200].
    [2] -100 <= Node.val <= 100
    [3] -200 <= x <= 200

    Runtime
    0 ms
    Beats 100.00%

    Memory
    42.37 MB
    Beats 91.84%
 */
internal class PartitionList
{
    public static ListNode Partition(ListNode head, int x)
    {
        if (null == head) { return head; }
        ListNode highhead = new(0, head), lowhead = new(0), inode = highhead, jnode = lowhead;

        while (null != inode.next)
        {
            if (inode.next.val < x)
            {
                jnode.next = inode.next;
                jnode = jnode.next;
                inode.next = inode.next.next;
            }
            else
            {
                inode = inode.next;
            }
        }

        jnode.next = highhead.next;
        return lowhead.next;
    }
}
