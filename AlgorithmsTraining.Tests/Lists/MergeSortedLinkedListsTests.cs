using System.Collections;
using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists
{
    internal class MergeSortedLinkedListsTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void MergeSortedLinkedLists_Tests(int[][] values, int[] expected)
        {
            var head = MergeSortedLinkedLists.MergeKLists(BuildList(values));
            Assert.That(IsExpected(head, expected), Is.True);
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(new int[][] { [1, 4, 5], [1, 3, 4], [2, 6] }, new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
            yield return new TestCaseData(new int[][] { [1, 3, 4], [1, 4, 5], [2, 6] }, new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
            yield return new TestCaseData(new int[][] { [], [1, 4, 5], [2, 6] }, new int[] { 1, 2, 4, 5, 6 });
            yield return new TestCaseData(new int[][] { [1, 1, 1], [2, 2, 2], [3, 3, 3] }, new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 });
            yield return new TestCaseData(new int[][] { [] }, null);
        }

        private static ListNode[] BuildList(int[][] values)
        {
            var nodeList = new ListNode[values.GetLength(0)];
            var nodeIndex = -1;

            for (int i = 0; i < values.GetLength(0); i++)
            {
                var stack = new Stack<ListNode>();

                for (int j = 0; j < values[i].GetLength(0); j++)
                {
                    stack.Push(new ListNode(values[i][j]));
                }

                ListNode prev = null;

                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    current.next = prev;
                    prev = current;
                }

                nodeList[++nodeIndex] = prev;
            }

            return nodeList;
        }

        private static bool IsExpected(ListNode head, int[] expected)
        {
            if (null == head && null == expected) { return true; }

            var current = head;

            for (int i = 0; i < expected.Length; i++)
            {
                if (current.val != expected[i]) { return false; }
                current = current.next;
            }

            return true;
        }
    }
}
