using System.Collections;
using AlgorithmsTraining.Trees;
using static AlgorithmsTraining.Tests.Utility;

namespace AlgorithmsTraining.Tests.Trees;

internal class UniqueBinarySearchTreesIITests
{
    [TestCaseSource(nameof(TestCases))]
    public void UniqueBinarySearchTreesIITests_Tests(int n, object[][] expectedResult)
    {
        int matchCount = 0;
        var results = UniqueBinarySearchTreesII.GenerateTrees(n);

        foreach (var root in results)
        {
            var crawler = new BreadthFirstTreeCrawler<TreeNode>(root);
            var values = new List<object>();

            foreach (var node in crawler)
            {
                values.Add(node?.val);
            }

            for (var i = 0; i < expectedResult.Length; i++) 
            {
                if (ArraysAreEqual(expectedResult[i].ToList(), values))
                {
                    matchCount++;
                    break;
                }
            }
        }
        
        Assert.That(matchCount, Is.EqualTo(expectedResult.Length));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            3,
            new object[][] 
            { 
                [1, null, 2, null, 3, null, null], 
                [1, null, 3, 2, null, null, null], 
                [2, 1, 3, null, null, null, null], 
                [3, 1, null, null, 2, null, null], 
                [3, 2, null, 1, null, null, null] 
            }
        );
    }
}
