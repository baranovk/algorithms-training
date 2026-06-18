namespace AlgorithmsTraining.Lists
{
    /*
     * 147. Insertion Sort List

       Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.

       The steps of the insertion sort algorithm:
       
           Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
           At each iteration, insertion sort removes one element from the input data, finds the location it belongs
           within the sorted list and inserts it there.
           It repeats until no input elements remain.
       
       The following is a graphical example of the insertion sort algorithm. The partially sorted list (black) initially contains
       only the first element in the list. One element (red) is removed from the input data and inserted in-place into the sorted
       list with each iteration.

       Constraints:

        [1] The number of nodes in the list is in the range [1, 5000].
        [2] -5000 <= Node.val <= 5000

        Runtime
        4 ms
        Beats 93.33%

        Memory
        46.50 MB
        Beats 71.11%
     */
    public static class InsertionSortList
    {
        private const int MIN_VALUE = -5000;

        public static ListNode Solution(ListNode head)
        {
            if (null == head?.next) { return head; }

            var lastSorted = head;
            var next = head.next;
            head = new ListNode(MIN_VALUE - 1, head);

            do 
            {
                var current = next;
                next = next.next;

                if (current.val >= lastSorted.val)
                {
                    lastSorted = current;
                }
                else
                {
                    ListNode pointer = head, prev = null;

                    while (current.val > pointer.val)
                    {
                        prev = pointer;
                        pointer = pointer.next;
                    }

                    // ASSERT: current.val <= pointer.val, prev != null
                    prev.next = current;
                    current.next = pointer;
                    lastSorted.next = next;
                }

            } while (next != null);

            return head.next;
        }
    }
}
