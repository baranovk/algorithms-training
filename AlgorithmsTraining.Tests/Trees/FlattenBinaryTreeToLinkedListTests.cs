using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class FlattenBinaryTreeToLinkedListTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void FlattenBinaryTreeToLinkedList_Tests(object[] treeDescription, object[] expectedResult)
        {
            var root = TreeUtils.BuildBinaryTree(treeDescription);
            FlattenBinaryTreeToLinkedList.Flatten(root);

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
                new object[] { 2, 1, 3 },
                new object[] { 2, null, 1, null, 3, null, null }
            );

            yield return new TestCaseData(
                new object[] { 10, 8, 19, 6, 9, 18, 20 },
                new object[] { 10, null, 8, null, 6, null, 9, null, 19, null, 18, null, 20, null, null }
            );

            yield return new TestCaseData(
                new object[] { 10, 8, 19, null, 9, null, 20 },
                new object[] { 10, null, 8, null, 9, null, 19, null, 20, null, null }
            );

            yield return new TestCaseData(
                new object[] { 10, 8, 19, null, null, null, 20 },
                new object[] { 10, null, 8, null, 19, null, 20, null, null }
            );

            yield return new TestCaseData(
                new object[] { 10, 8, null, 6, 9 },
                new object[] { 10, null, 8, null, 6, null, 9, null, null }
            );

            yield return new TestCaseData(
                new object[] { 10, null, 19, 18, 20 },
                new object[] { 10, null, 19, null, 18, null, 20, null, null }
            );

            //    yield return new TestCaseData(
            //        new object[] { 1, 2, 5, 3, 4, null, 6 },
            //        new object[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6, null, null }
            //    );
        }
    }
}
