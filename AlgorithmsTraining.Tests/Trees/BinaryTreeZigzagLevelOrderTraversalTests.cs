using System.Collections;
using AlgorithmsTraining.Trees;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class BinaryTreeZigzagLevelOrderTraversalTests
    {

        [TestCaseSource(nameof(TestCases))]
        public void BinaryTreeZigzagLevelOrderTraversalTests_Tests(object[] treeDescription, List<List<int>> expectedResult)
        {
            var root = TreeUtils.BuildBinaryTree(treeDescription);
            var result = BinaryTreeZigzagLevelOrderTraversal.ZigzagLevelOrder(root);

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.That(ArraysAreEqual(expectedResult[i], result[i]), Is.True);
            }
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new object[] { 3, 9, 20, null, null, 15, 7 },
                new List<List<int>> { new() { 3 }, new() { 20, 9 }, new() { 15, 7 } }
            );

            yield return new TestCaseData(
                new object[] { 1, 2, 3, 4, null, null, 5 },
                new List<List<int>> { new() { 1 }, new() { 3, 2 }, new() { 4, 5 } }
            );

            yield return new TestCaseData(
                new object[] { 1, 2, 3, 4, 5 },
                new List<List<int>> { new() { 1 }, new() { 3, 2 }, new() { 4, 5 } }
            );
        }
    }
}
