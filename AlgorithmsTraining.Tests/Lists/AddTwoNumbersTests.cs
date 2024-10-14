using System;

using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists
{
    
    public class AddTwoNumbersTests
    {
        [Test]
        public void TestSumsWithEqualSummandsCount()
        {
            // input  1
            //        5
            // output 6
            var l1 = new ListNode(1);
            var l2 = new ListNode(5);

            var sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 6);
            Assert.IsNull(sum.next);

            // input  7
            //        5
            // output 2 - 1
            l1 = new ListNode(7);
            l2 = new ListNode(5);

            sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 2);
            Assert.AreEqual(sum.next.val, 1);
            Assert.IsNull(sum.next.next);

            // input  1 - 2 - 3
            //        7 - 9 - 1
            // output 8 - 1 - 5
            l1 = new ListNode(1, new ListNode(2, new ListNode(3)));
            l2 = new ListNode(7, new ListNode(9, new ListNode(1)));

            sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 8);
            Assert.AreEqual(sum.next.val, 1);
            Assert.AreEqual(sum.next.next.val, 5);
            Assert.IsNull(sum.next.next.next);

            // input  9 - 9 - 9
            //        9 - 9 - 9
            // output 8 - 9 - 9 - 1
            l1 = new ListNode(9, new ListNode(9, new ListNode(9)));
            l2 = new ListNode(9, new ListNode(9, new ListNode(9)));

            sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 8);
            Assert.AreEqual(sum.next.val, 9);
            Assert.AreEqual(sum.next.next.val, 9);
            Assert.AreEqual(sum.next.next.next.val, 1);
            Assert.IsNull(sum.next.next.next.next);
        }

        [Test]
        public void TestSumsWithNotEqualSummandsCount()
        {
            // input  1 - 2
            //        5
            // output 6 - 2
            var l1 = new ListNode(1, new ListNode(2));
            var l2 = new ListNode(5);

            var sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 6);
            Assert.AreEqual(sum.next.val, 2);
            Assert.IsNull(sum.next.next);

            // input  7
            //        5 - 1
            // output 2 - 2
            l1 = new ListNode(7);
            l2 = new ListNode(5, new ListNode(1));

            sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 2);
            Assert.AreEqual(sum.next.val, 2);
            Assert.IsNull(sum.next.next);

            // input  1 - 2 - 3
            //        7 - 9 
            // output 8 - 1 - 4
            l1 = new ListNode(1, new ListNode(2, new ListNode(3)));
            l2 = new ListNode(7, new ListNode(9));

            sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 8);
            Assert.AreEqual(sum.next.val, 1);
            Assert.AreEqual(sum.next.next.val, 4);
            Assert.IsNull(sum.next.next.next);

            // input  9 - 9 - 9
            //        9 - 9 
            // output 8 - 9 - 0 - 1
            l1 = new ListNode(9, new ListNode(9, new ListNode(9)));
            l2 = new ListNode(9, new ListNode(9));

            sum = AddTwoNumbers.DoAddTwoNumbers(l1, l2);
            Assert.AreEqual(sum.val, 8);
            Assert.AreEqual(sum.next.val, 9);
            Assert.AreEqual(sum.next.next.val, 0);
            Assert.AreEqual(sum.next.next.next.val, 1);
            Assert.IsNull(sum.next.next.next.next);
        }
    }
}
