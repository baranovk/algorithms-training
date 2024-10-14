using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists
{
    internal static class ListUtils
    {
        public static int GetNodeValue(ListNode head, int index)
        {
            if (0 == index) return head.val;
            var innerIndex = 0;

            while (null != head.next)
            {
                head = head.next;
                innerIndex++;

                if (index == innerIndex) return head.val;
            }

            return -1;
        }
    }
}
