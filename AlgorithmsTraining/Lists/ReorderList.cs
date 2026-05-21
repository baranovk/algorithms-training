namespace AlgorithmsTraining.Lists
{
    /*
     * 143. Reorder List

       You are given the head of a singly linked-list. The list can be represented as:

       L0 → L1 → … → Ln - 1 → Ln
       
       Reorder the list to be on the following form:
       
       L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
       
       You may not modify the values in the list's nodes. Only nodes themselves may be changed.

       Example 1:

       Input: head = [1,2,3,4]
       Output: [1,4,2,3]

       Example 2:

       Input: head = [1,2,3,4,5]
       Output: [1,5,2,4,3]

       Runtime
       2 ms
       Beats 13.19%

       Memory
       50.10 MB
       Beats 22.98%
     */
    public static class ReorderList
    {
        private const int MAX_NODES = 5 * 10_000;

        public static void Solution(ListNode head)
        {
            if (head == null) return;
            var list = new ListNode[MAX_NODES];
            var nodesCount = 0;

            var current = head.next;

            while (current != null)
            {
                list[nodesCount++] = current;
                current = current.next;
            }

            current = head;
            int i = 0, j = nodesCount - 1;

            while (i < j)
            {
                current.next = list[j--];
                current.next.next = list[i++];
                current = current.next.next;
            }

            if (i == j)
            {
                current.next = list[i];
                current = current.next;
            }

            current.next = null;
        }
    }
}
