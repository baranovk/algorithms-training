namespace AlgorithmsTraining.Lists
{
    public static class LinkedListsUtils
    {
        public static ListNode BuildListFromArray(int[] arr)
        {
            if (null == arr || 0 == arr.Length) { return null; }

            var head = new ListNode(arr[0]);
            var current = head;

            for (int i = 1; i < arr.Length; i++)
            {
                current.next = new ListNode(arr[i]);
                current = current.next;
            }

            return head;
        }
    }
}
