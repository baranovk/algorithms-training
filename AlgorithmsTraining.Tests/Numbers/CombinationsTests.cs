using System.Collections;
using AlgorithmsTraining.Numbers;

namespace AlgorithmsTraining.Tests.Numbers;

internal class CombinationsTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Combinations_Tests(int n, int k, IList<IList<int>> expectedResult)
    {
        var result = Combinations.Combine(n, k);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            4, 2,
            new List<IList<int>> {
                new List<int> { 1,2 }, new List<int> { 1,3 },
                new List<int> { 1, 4 }, new List<int> { 2, 3 },
                new List<int> { 2, 4 }, new List<int> { 3, 4 }
            }
        );

        yield return new TestCaseData(
            5, 3,
            new List<IList<int>> {
                new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 4 }, new List<int> { 1, 2, 5 },
                new List<int> { 1, 3, 4 }, new List<int> { 1, 3, 5 }, new List<int> { 1, 4, 5 },
                new List<int> { 2, 3, 4 }, new List<int> { 2, 3, 5 }, new List<int> { 2, 4, 5 },
                new List<int> { 3, 4, 5 }
            }
        );

        yield return new TestCaseData(
            1, 1,
            new List<IList<int>> {
                new List<int> { 1 }
            }
        );
    }
}
