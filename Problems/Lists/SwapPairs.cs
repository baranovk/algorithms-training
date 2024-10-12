namespace Problems.Lists
{
    public static class SwapPairs
    {
        // [1,2,3,4]
        public static ListNode DoSwapPairs(ListNode head)
        {
            if (null == head) return null;
            if (null == head?.next) return head;
            ListNode newHead = null, prev = null;
            
            do
            {
                head = SwapNodes(head);

                if (null != prev)
                {
                    prev.next = head;
                }

                if (null == newHead)
                {
                    newHead = head;
                }

                prev = head.next;
                head = prev?.next;
            } 
            while (null != head);

            return newHead;
        }

        private static ListNode SwapNodes(ListNode head)
        {
            if (null == head) return null;
            if (null == head.next) return head;

            var next = head.next;
            head.next = next.next;
            next.next = head;
            return next;
        }
    }
}
