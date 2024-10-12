using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Lists
{
    public class LinkedLists
    {
        /*
         * Given a linked list, remove the n-th node from the end of list and return its head.
         *
         * Given linked list: 1->2->3->4->5, and n = 2.
         * After removing the second node from the end, the linked list becomes 1->2->3->5.
         */
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode prevNode = null;
            var nodeToRemove = head;
            var nodeToRemoveIndex = 1;
            var currentNodeIndex = 1;
            var currentNode = head;

            // 1 
            while (null != currentNode.next)
            {
                currentNode = currentNode.next;
                currentNodeIndex++;

                if (currentNodeIndex - nodeToRemoveIndex > n - 1)
                {
                    prevNode = nodeToRemove;
                    nodeToRemove = nodeToRemove.next;
                    nodeToRemoveIndex++;
                }
            }

            if (currentNodeIndex - nodeToRemoveIndex == n - 1)
            {
                // nodeToRemove is head
                if (nodeToRemove == head) return head.next;

                // nodeToRemove is not head
                prevNode.next = nodeToRemove.next;
                return head;
            }

            return null;
        }
    }
}
