using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Lists;

namespace Problems.Tests.Lists
{
    /// <summary>
    /// Summary description for RemoveFromEndTests
    /// </summary>
    [TestClass]
    public class RemoveFromEndTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = LinkedLists.RemoveNthFromEnd(head, 2);
            Assert.AreEqual(TraverseToEnd(head), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 1);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 2);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 3);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 5);
        }

        [TestMethod]
        public void RemoveHeadTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = LinkedLists.RemoveNthFromEnd(head, 5);
            Assert.AreEqual(TraverseToEnd(head), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 2);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 3);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 5);
        }

        [TestMethod]
        public void RemoveTailTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = LinkedLists.RemoveNthFromEnd(head, 1);
            Assert.AreEqual(TraverseToEnd(head), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 1);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 2);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 3);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 4);
        }

        [TestMethod]
        public void InvalidValuesTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = LinkedLists.RemoveNthFromEnd(head, 6);
            Assert.IsNull(head);
        }

        private int TraverseToEnd(ListNode head)
        {
            if (null == head) return 0;
            var count = 1;

            while (null != head.next)
            {
                head = head.next;
                count++;
            }

            return count;
        }
    }
}
