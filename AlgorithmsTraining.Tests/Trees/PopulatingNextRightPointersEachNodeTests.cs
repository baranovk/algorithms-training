using System.Collections;
using AlgorithmsTraining.Trees;

namespace AlgorithmsTraining.Tests.Trees
{
    internal class PopulatingNextRightPointersEachNodeTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void PopulatingNextRightPointersEachNode_Tests(object[] treeDescription, object[] expectedResult)
        {
            var root = TreeUtils.BuildBinaryTree(treeDescription, val => new Node(Convert.ToInt32(val)));
            PopulatingNextRightPointersEachNode.Connect(root);

            var crawler = new BreadthFirstTreeCrawler<Node>(root);
            var values = new List<object>();

            foreach (Node node in crawler)
            {
                values.Add(node?.val);

                if (null != node && null == node.next)
                {
                    values.Add(null);
                }
            }

            Assert.That(values, Is.EquivalentTo(expectedResult));
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                new object[] { 2, 1, 3 },
                new object[] { 2, null, 1, 3, null, null, null, null, null }
            );
        }
    }
}
