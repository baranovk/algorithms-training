using System.Collections;
using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists
{
    internal class LinkedListCycleIITests
    {
        [TestCaseSource(nameof(TestCases))]
        public void LinkedListCycleII_Tests(List<int> values, int pos, int? val)
        {
           Assert.That(val, Is.EqualTo(LinkedListCycleII.DetectCycle(BuildList(values, pos))?.val));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(new List<int> { 3, 2, 0, -4 }, 1, 2);
            yield return new TestCaseData(new List<int> { 1, 2 }, 0, 1);
            yield return new TestCaseData(new List<int> { 1 }, -1, null);
        }

        private static ListNode BuildList(List<int> values, int pos)
        {
            ListNode head, tail;
            head = tail = new ListNode(values[0]);
            var cycleStart = 0 == pos ? tail : null;

            for (var i = 1; i < values.Count; i++)
            {
                var node = new ListNode(values[i]);
                tail.next = node;
                tail = node;
                cycleStart = i == pos ? node : cycleStart;
            }

            tail.next = cycleStart;
            return head;
        }
    }
}
