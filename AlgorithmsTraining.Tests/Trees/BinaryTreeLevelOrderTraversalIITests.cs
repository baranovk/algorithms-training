using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class BinaryTreeLevelOrderTraversalIITests
    {
        [TestCaseSource(nameof(TestCases))]
        public void BinaryTreeLevelOrderTraversalII_Tests(object[] treeDescription, List<List<int>> expectedResult)
        {
            var root = TreeUtils.BuildBinaryTree(treeDescription);
            var result = BinaryTreeLevelOrderTraversalII.LevelOrderBottom(root);

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.That(result[i], Is.EquivalentTo(expectedResult[i]));
            }
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new object[] { 3, 9, 20, null, null, 15, 7 },
                new List<List<int>> { new() { 15, 7 }, new() { 9, 20 }, new() { 3 } }
            );
        }
    }
}
