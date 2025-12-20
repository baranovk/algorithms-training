using System.Collections;
using AlgorithmsTraining.Trees;
using static AlgorithmsTraining.Lists.LinkedListsUtils;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class ConvertSortedListToBinarySearchTreeTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void ConvertSortedListToBinarySearchTree_Tests(int[] listValues, List<int?> expectedResult)
        {
            var list = BuildListFromArray(listValues);
            var root = ConvertSortedListToBinarySearchTree.SortedListToBST(list);

            var crawler = new BreadthFirstTreeCrawler<TreeNode>(root);
            var values = new List<int?>();

            foreach (var node in crawler)
            {
                values.Add(node?.val);
            }

            Assert.That(values, Is.EquivalentTo(expectedResult));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new int[] { -10, -3, 0, 5, 9 },
                new List<int?> { 0, -3, 9, -10, null, 5 }
            );
        }
    }
}
