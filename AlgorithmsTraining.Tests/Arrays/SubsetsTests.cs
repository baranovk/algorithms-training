using System.Collections;

namespace AlgorithmsTraining.Tests.Arrays;

internal class SubsetsTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Subsets_Tests(int[] nums, IList<IList<int>> expectedResult)
    {
        var result = Subsets.Solution(nums);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new int[] { 1, 2, 3 },
            new List<IList<int>> {
                new List<int> { }, new List<int> { 1 },
                new List<int> { 2 }, new List<int> { 1, 2 },
                new List<int> { 3 }, new List<int> { 1, 3 },
                new List<int> { 2, 3 }, new List<int> { 1, 2, 3 },
            }
        );

        yield return new TestCaseData(
            new int[] { 0 },
            new List<IList<int>> {
                new List<int> { }, new List<int> {0 }
            }
        );
    }
}
