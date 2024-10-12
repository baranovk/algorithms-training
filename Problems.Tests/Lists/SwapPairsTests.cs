using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Lists;

namespace Problems.Tests.Lists
{
    [TestClass]
    public class SwapPairsTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            head = SwapPairs.DoSwapPairs(head);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 2);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 1);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 3);
        }

        [TestMethod]
        public void TestFive()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            head = SwapPairs.DoSwapPairs(head);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 2);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 1);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 3);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 4), 5);
        }

        [TestMethod]
        public void TestOne()
        {
            var head = new ListNode(1);
            head = SwapPairs.DoSwapPairs(head);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 1);
        }
    }
}
