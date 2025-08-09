using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class PermutationsTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Permutations_Tests(int[] nums, IList<IList<int>> expectedResult)
    {
        var result = Permutations.Permute(nums);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new int[] { 1, 2, 3 }, 
            new List<IList<int>> { 
                new List<int> { 1, 2, 3 }, new List<int> { 1, 3, 2 }, 
                new List<int> { 2, 1, 3 }, new List<int> { 2, 3, 1 }, 
                new List<int> { 3, 1, 2 }, new List<int> { 3, 2, 1 } 
            }
        );

        yield return new TestCaseData(
            new int[] { 1, 2, 3, 4 },
            new List<IList<int>> {
                new List<int> { 1, 2, 3, 4 }, new List<int> { 1, 2, 4, 3 },
                new List<int> { 1, 3, 4, 2 }, new List<int> { 1, 3, 2, 4 },
                new List<int> { 1, 4, 3, 2 }, new List<int> { 1, 4, 2, 3 },

                new List<int> { 2, 1, 3, 4 }, new List<int> { 2, 1, 4, 3 },
                new List<int> { 2, 3, 1, 4 }, new List<int> { 2, 3, 4, 1 },
                new List<int> { 2, 4, 1, 3 }, new List<int> { 2, 4, 3, 1 },

                new List<int> { 3, 1, 2, 4 }, new List<int> { 3, 1, 4, 2 },
                new List<int> { 3, 2, 1, 4 }, new List<int> { 3, 2, 4, 1 },
                new List<int> { 3, 4, 1, 2 }, new List<int> { 3, 4, 2, 1 },

                new List<int> { 4, 1, 2, 3 }, new List<int> { 4, 1, 3, 2 },
                new List<int> { 4, 2, 1, 3 }, new List<int> { 4, 2, 3, 1 },
                new List<int> { 4, 3, 1, 2 }, new List<int> { 4, 3, 2, 1 }
            }
        );

        yield return new TestCaseData(
            new int[] { 0, 1 },
            new List<IList<int>> {
                new List<int> { 0, 1 }, new List<int> { 1, 0 }
            }
        );

        yield return new TestCaseData(
            new int[] { 1 },
            new List<IList<int>> {
                new List<int> { 1 }
            }
        );
    }
}
