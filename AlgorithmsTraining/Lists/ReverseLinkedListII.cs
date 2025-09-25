namespace AlgorithmsTraining.Lists;

/*
 * 92. Reverse Linked List II

  Given the head of a singly linked list and two integers left and right where left <= right, 
  reverse the nodes of the list from position left to position right, and return the reversed list.

  Example 1:
  
  Input: head = [1,2,3,4,5], left = 2, right = 4
  Output: [1,4,3,2,5]
  
  Example 2:
  
  Input: head = [5], left = 1, right = 1
  Output: [5]

  Constraints:

   [1] The number of nodes in the list is n.
   [2] 1 <= n <= 500
   [3] -500 <= Node.val <= 500
   [4] 1 <= left <= right <= n

 
   Follow up: Could you do it in one pass?

   Runtime
   0 ms
   Beats 100.00%

   Memory
   42.31 MB
   Beats 9.15%
 */

public static class ReverseLinkedListII
{
    public static ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (null == head.next || left == right) { return head; }

        var index = 1;
        var nodes = new Stack<ListNode>();
        ListNode current = head, prev = null;

        while (true)
        {
            if (left <= index && index < right)
            {
                nodes.Push(current);
            }
            else if (index == right)
            {
                nodes.Push(current);
                head = Revert(head, prev, nodes);
                break;
            }
            else
            {
                prev = current;
            }

            current = current.next;
            index++;
        }

        return head;
    }

    private static ListNode Revert(ListNode head, ListNode prev, Stack<ListNode> nodes)
    {
        var next = nodes.Peek().next;

        if (null == prev)
        {
            head = nodes.Pop();
            prev = head;
        }

        var current = prev;

        while(0 < nodes.Count)
        {
            current.next = nodes.Pop();
            current = current.next;
        }

        current.next = next;
        return head;
    }
}
