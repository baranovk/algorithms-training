namespace AlgorithmsTraining.Lists;

/*
 * 61. Rotate List
 * 
  Given the head of a linked list, rotate the list to the right by k places.
  
  Example 1:
  
  Input: head = [1,2,3,4,5], k = 2
  Output: [4,5,1,2,3]

  Example 2:

  Input: head = [0,1,2], k = 4
  Output: [2,0,1]

  Constraints:

   [1] The number of nodes in the list is in the range [0, 500].
   [2] -100 <= Node.val <= 100
   [3] 0 <= k <= 2 * 109

   Runtime
   4 ms
   Beats 4.33%
   
   Memory
   43.49 MB
   Beats 11.27%
 */
public static class RotateList
{
    public static ListNode RotateRight(ListNode head, int k)
    {
        if (null == head || null == head.next || 0 == k) { return head; }

        var stack = new Stack<ListNode>();
        var queue = new Queue<ListNode>();

        var current = head;
        while (null != current) { stack.Push(current); current = current.next; }

        k = k % stack.Count;
        if (0 == k) { return head; }

        while (stack.Count > 0) { queue.Enqueue(stack.Pop()); }

        while (0 < k--)
        {
            var tail = queue.Dequeue();
            tail.next = head;
            head = tail;
            queue.Enqueue(head);
            queue.Peek().next = null;
        }

        return head;
    }
}
