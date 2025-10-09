using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees;

internal class UniqueBinarySearchTreesTests
{
    [TestCaseSource(nameof(TestCases))]
    public int UniqueBinarySearchTreesTests_Tests(int n)
    {
        return UniqueBinarySearchTrees.NumTrees(n);
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(3).Returns(5);
        //yield return new TestCaseData(19).Returns(5);
    }
}
