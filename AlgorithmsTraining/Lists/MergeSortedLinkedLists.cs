namespace AlgorithmsTraining.Lists
{
    /*
     * 23. Merge k Sorted Lists
        
        You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

        Merge all the linked-lists into one sorted linked-list and return it.

        Example 1:

        Input: lists = [[1,4,5],[1,3,4],[2,6]]
        Output: [1,1,2,3,4,4,5,6]
        Explanation: The linked-lists are:
        [
          1->4->5,
          1->3->4,
          2->6
        ]
        merging them into one sorted linked list:
        1->1->2->3->4->4->5->6
        
        Example 2:
        
        Input: lists = []
        Output: []
        
        Example 3:
        
        Input: lists = [[]]
        Output: []
        
        Constraints:
        
            [1] k == lists.length
            [2] 0 <= k <= 10^4
            [3] 0 <= lists[i].length <= 500
            [4] -10^4 <= lists[i][j] <= 10^4
            [5] lists[i] is sorted in ascending order.
            [6] The sum of lists[i].length will not exceed 10^4.

        Runtime
        90 ms
        Beats 19.56%

        Memory
        49.20 MB
        Beats 83.96%
     */
    public static class MergeSortedLinkedLists
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (0 == lists.Length) { return null; }

            ListNode head = null, current = null;

            while (true)
            {
                var merged = true;
                int min = int.MaxValue, indexOfMin = -1;

                for (var i = 0; i < lists.Length; i++)
                {
                    merged &= lists[i] == null;

                    if (null != lists[i] && lists[i].val <= min)
                    {
                        min = lists[i].val;
                        indexOfMin = i;
                    }
                }

                if (merged) { break; }

                head ??= lists[indexOfMin];

                if (current == null)
                {
                    current = head;
                }
                else
                {
                    current.next = lists[indexOfMin];
                    current = current.next;
                }

                lists[indexOfMin] = lists[indexOfMin].next;
            }

            return head;
        }
    }
}
