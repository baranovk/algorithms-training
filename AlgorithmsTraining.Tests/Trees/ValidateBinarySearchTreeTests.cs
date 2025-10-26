using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees;

internal class ValidateBinarySearchTreeTests
{
    [TestCaseSource(nameof(TestCases))]
    public bool ValidateBinarySearchTree_Tests(object[] values)
    {
        return ValidateBinarySearchTree.IsValidBST(TreeUtils.BuildBinaryTree(values));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData([new object[] { 2, 2, 2 }]).Returns(false);
        yield return new TestCaseData([new object[] { 2, 1, 3 }]).Returns(true);
        yield return new TestCaseData([new object[] { 5, 1, 4, null, null, 3, 6 }]).Returns(false);
        yield return new TestCaseData([new object[] { 5, 4, 6, null, null, 3, 7 }]).Returns(false);
        yield return new TestCaseData([new object[] { 45, 42, null, null, 44, 43, null, 41, null }]).Returns(false);
        yield return new TestCaseData([new object[] { 3, 1, 5, 0, 2, 4, 6, null, null, null, 3 }]).Returns(false);
    }
}
