using System.Collections;
using AlgorithmsTraining.Trees;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Trees;

internal class RecoverBinarySearchTreeTests
{
    [TestCaseSource(nameof(TestCases))]
    public void RecoverBinarySearchTreeTests_Tests(object[] treeDescription, object[] expectedResult)
    {
        var root = TreeUtils.BuildBinaryTree(treeDescription);
        RecoverBinarySearchTree.RecoverTree(root);

        var crawler = new BreadthFirstTreeCrawler(root);
        var values = new List<object>();

        foreach (var node in crawler)
        {
            values.Add(node?.val);
        }

        for (var i = 0; i < expectedResult.Length; i++)
        {
            Assert.That(ArraysAreEqual([.. expectedResult], values), Is.True);
        }
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new object[] { 2, 1, null, null, 3, 4 },
            new object[] { 4, 1, null, null, 3, 2, null, null, null }
        );

        yield return new TestCaseData(
            new object[] { 3, null, 2, null, 1 },
            new object[] { 1, null, 2, null, 3, null, null }
        );

        yield return new TestCaseData(
            new object[] { 2, 3, 1 },
            new object[] { 2, 1, 3, null, null, null, null }
        );

        yield return new TestCaseData(
            new object[] { 1, 3, null, null, 2 },
            new object[] { 3, 1, null, null, 2, null, null }
        );

        yield return new TestCaseData(
            new object[] { 3, 1, 4, null, null, 2 },
            new object[] { 2, 1, 4, null, null, 3, null, null, null }
        );

        yield return new TestCaseData(
            new object[] { 8, 6, 10, 4, 9, 7, 11 },
            new object[] { 8, 6, 10, 4, 7, 9, 11, null, null, null, null, null, null, null, null }
        );
    }
}
