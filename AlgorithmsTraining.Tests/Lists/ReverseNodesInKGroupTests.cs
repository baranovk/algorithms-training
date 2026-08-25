using System.Collections;
using AlgorithmsTraining.Lists;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Lists
{
    internal class ReverseNodesInKGroupTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void ReverseNodesInKGroup_Tests(int[] values, int k, int[] expected)
        {
            var head = ReverseNodesInKGroup.ReverseKGroup(BuildList(values), k);
            Assert.That(ListIsMatch(head, expected), Is.True);
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(new int[] { 1 }, 1, new int[] { 1 });
            yield return new TestCaseData(new int[] { 1, 2, 3 }, 3, new int[] { 3, 2, 1 });
            yield return new TestCaseData(new int[] { 1, 2, 3 }, 2, new int[] { 2, 1, 3 });
            yield return new TestCaseData(new int[] { 1, 2, 3, 4 }, 3, new int[] { 3, 2, 1, 4 });
            yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 3, new int[] { 3, 2, 1, 6, 5, 4 });
            yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 5, new int[] { 5, 4, 3, 2, 1, 6 });
            yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 4, new int[] { 4, 3, 2, 1, 5, 6 });
            yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 2, new int[] { 2, 1, 4, 3, 6, 5 });
        }
    }
}
