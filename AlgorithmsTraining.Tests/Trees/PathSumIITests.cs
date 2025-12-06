using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees;

internal class PathSumIITests
{
    [TestCaseSource(nameof(TestCases))]
    public void PathSumIITests_Tests(object[] treeDescription, int targetSum, List<List<int>> expectedResult)
    {
        var root = TreeUtils.BuildBinaryTree(treeDescription);
        var result = PathSumII.PathSum(root, targetSum);

        for (var i = 0; i < expectedResult.Count; i++)
        {
            Assert.That(result[i], Is.EquivalentTo(expectedResult[i]));
        }
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new object[] { 1, 2, 3, null, null, null, null },
            5,
            new List<List<int>>()
        );

        yield return new TestCaseData(
            new object[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 },
            22,
            new List<List<int>> { new() { 5, 4, 11, 2 }, new() { 5, 8, 4, 5 } }
        );
    }
}
