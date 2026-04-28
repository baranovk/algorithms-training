using System.Collections;
using AlgorithmsTraining.Lists;

namespace AlgorithmsTraining.Tests.Lists
{
    internal class CopyListWithRandomPointerTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void CopyListWithRandomPointer_Tests(int?[][] list)
        {
            var nodelist = GenerateList(list);
            var result = CopyListWithRandomPointer.CopyRandomList(nodelist);
            ValidateResult(nodelist, result);
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                [new int?[][] { [7, null], [13, 0], [11, 4], [10, 2], [1, 0] }]
            );

            yield return new TestCaseData(
                [new int?[][] { [1, 1], [2, 1] }]
            );

            yield return new TestCaseData(
                [new int?[][] { [3, null], [3, 0], [3, null] }]
            );
        }

        private static CopyListWithRandomPointer.Node GenerateList(int?[][] list)
        {
            var dict = new Dictionary<int, CopyListWithRandomPointer.Node>();
            CopyListWithRandomPointer.Node head, prev;
            prev = head = CloneNode(list, 0, dict);

            for (int i = 1; i < list.Length; i++)
            {
                var current = CloneNode(list, i, dict);
                prev.next = current;
                prev = current;
            }

            return head;
        }

        private static CopyListWithRandomPointer.Node CloneNode(int?[][] list,
            int index, Dictionary<int, CopyListWithRandomPointer.Node> dict)
        {
            var item = list[index];
            var current = GetOrAdd(list, index, dict);

            if (item[1] != null)
            {
                current.random = GetOrAdd(list, item[1]!.Value, dict);
            }

            return current;
        }

        private static CopyListWithRandomPointer.Node GetOrAdd(
            int?[][] list, int index, Dictionary<int, CopyListWithRandomPointer.Node> dict)
        {
            if (!dict.TryGetValue(index, out var existing))
            {
                dict.Add(index, new CopyListWithRandomPointer.Node(list[index][0].Value));
                return dict[index];
            }

            return existing;
        }

        private static void ValidateResult(CopyListWithRandomPointer.Node expected, CopyListWithRandomPointer.Node clone)
        {
            do 
            {
                Assert.That(clone, Is.Not.EqualTo(expected));
                
                if (expected.random != null && clone.random != null)
                {
                    Assert.That(clone.random, Is.Not.EqualTo(expected.random));
                    Assert.That(clone.random?.val, Is.EqualTo(expected.random?.val));
                }

                expected = expected.next;
                clone = clone.next;
            }
            while (clone != null && expected != null);
        }
    }
}
