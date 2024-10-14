
using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists
{
    
    public class SwapPairsTests
    {
        [Test]
        public void BasicTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            head = SwapPairs.DoSwapPairs(head);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 2);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 1), 1);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 2), 4);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 3), 3);
        }

        [Test]
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

        [Test]
        public void TestOne()
        {
            var head = new ListNode(1);
            head = SwapPairs.DoSwapPairs(head);
            Assert.AreEqual(ListUtils.GetNodeValue(head, 0), 1);
        }
    }
}
