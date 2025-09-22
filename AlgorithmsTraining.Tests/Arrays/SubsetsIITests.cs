using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class SubsetsIITests
{
    [TestCaseSource(nameof(TestCases))]
    public void SubsetsII_Tests(int[] nums, IList<IList<int>> expectedResult)
    {
        var result = SubsetsII.SubsetsWithDup(nums);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new int[] { 1, 2, 2, 3 },
            new List<IList<int>> {
                new List<int> { }, new List<int> { 1 },
                new List<int> { 1, 2 }, new List<int> { 1, 2, 2 }, new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 2, 3 }, new List<int> { 1, 3 },
                new List<int> { 2 }, new List<int> { 2, 2 }, new List<int> { 2, 2, 3 }, new List<int> { 2, 3 },
                new List<int> { 3 }
            }
        );

        yield return new TestCaseData(
            new int[] { 1, 2, 2 },
            new List<IList<int>> {
                new List<int> { }, new List<int> { 1 },
                new List<int> { 1, 2 }, new List<int> { 1, 2, 2 },
                new List<int> { 2 }, new List<int> { 2, 2 }
            }
        );

        yield return new TestCaseData(
            new int[] { 0 },
            new List<IList<int>> {
                new List<int> { }, new List<int> { 0 }
            }
        );
    }
}
