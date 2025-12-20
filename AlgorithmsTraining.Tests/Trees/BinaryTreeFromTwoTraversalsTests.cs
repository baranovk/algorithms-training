using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class BinaryTreeFromTwoTraversalsTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void BinaryTreeFromTwoTraversals_Tests(int[] preorder, int[] inorder, object[] expectedResult)
        {
            var root = BinaryTreeFromTwoTraversals.BuildTree(preorder, inorder);

            var crawler = new BreadthFirstTreeCrawler<TreeNode>(root);
            var values = new List<object>();

            foreach (var node in crawler)
            {
                values.Add(node?.val);
            }

            Assert.That(values, Is.EquivalentTo(expectedResult));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new int[] { 1, 2 },
                new int[] { 1, 2 },
                new object[] { 1, null, 2, null, null }
            );

            yield return new TestCaseData(
                new int[] { 3, 9 },
                new int[] { 9, 3 },
                new object[] { 3, 9, null, null, null }
            );

            yield return new TestCaseData(
                new int[] { 10, 7, 5, 8, 20, 15, 25 },
                new int[] { 5, 7, 8, 10, 15, 20, 25 },
                new object[] { 10, 7, 20, 5, 8, 15, 25, null, null, null, null, null, null, null, null }
            );

            yield return new TestCaseData(
                new int[] { 2, 1, 3 },
                new int[] { 1, 2, 3 },
                new object[] { 2, 1, 3, null, null, null, null }
            );

            yield return new TestCaseData(
                new int[] { 3, 9, 20, 15, 7 },
                new int[] { 9, 3, 15, 20, 7 },
                new object[] { 3, 9, 20, null, null, 15, 7, null, null, null, null }
            );
        }
    }
}
