using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class SumRootToLeafNumbersTests
    {
        [TestCaseSource(nameof(TestCases))]
        public int SumRootToLeafNumbers_Tests(object[] treeDescription)
        {
            return SumRootToLeafNumbers.SumNumbers(TreeUtils.BuildBinaryTree(treeDescription));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData([new object[] { 1 }]).Returns(1);
            yield return new TestCaseData([new object[] { 1, 2, 3 }]).Returns(25);
            yield return new TestCaseData([new object[] { 1, 2, 3, 4, null }]).Returns(137);
            yield return new TestCaseData([new object[] { 1, 2, 3, 4, 5, null, null, 6, 7 }]).Returns(2631);
            yield return new TestCaseData([new object[] { 4, 9, 0, 5, 1 }]).Returns(1026);
        }
    }
}
