namespace Problems.Lists
{
    /*
     You are given two non-empty linked lists representing two non-negative integers. The digits are stored 
     in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

     You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        Example:

        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        Explanation: 342 + 465 = 807.
    
    */
    public class AddTwoNumbers
    {
        public static ListNode DoAddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode n;
            var carry = 0;

            var result = n = new ListNode();

            do
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;

                var newVal = sum % 10;
                carry = sum / 10;

                n.next = new ListNode(newVal);
                n = n.next;
                l1 = l1?.next;
                l2 = l2?.next;
            } 
            while (null != l1 || null != l2 || 0 < carry);

            return result.next;
        }
    }
}
