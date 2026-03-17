using System.Collections;
using AlgorithmsTraining.Grapths;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Graphs
{
    internal class CloneGraphTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void CloneGraph_Tests(int[][] adjacencyList)
        {
            var node = GraphUtils.BuildGraph(adjacencyList, 1);
            var result = CloneGraph.Solution(node);
            var adjacencyListRebuilt = GraphUtils.BuildConnectedGraphAdjacencyList(result);
            Assert.That(MatrixesAreEqualWithoutOrder(adjacencyListRebuilt, adjacencyList), Is.True);
        }

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData(
                [new int[][] {
                    [1, 2],
                    [1, 3],
                    [1, 4]
                }]
            );

            yield return new TestCaseData(
                [new int[][] {
                    [1, 2],
                    [1, 4],
                    [2, 4],
                    [2, 3],
                    [3, 4]
                }]
            );

            yield return new TestCaseData(
                [new int[][] {
                    [1, 2],
                    [1, 4],
                    [4, 3]
                }]
            );

            yield return new TestCaseData(
                [new int[][] {
                    [1, 2],
                    [1, 4],
                    [2, 3],
                    [3, 4],
                    [3, 5],
                    [5, 6]
                }]
            );

            yield return new TestCaseData(
                [new int[][] {
                    [1, 2],
                    [2, 3],
                    [3, 4],
                    [4, 5],
                    [5, 6]
                }]
            );

            yield return new TestCaseData(
                [new int[][] {
                    [1,2],
                    [1,4],
                    [2,3],
                    [3,4]
                }]
            );
        }
    }
}
