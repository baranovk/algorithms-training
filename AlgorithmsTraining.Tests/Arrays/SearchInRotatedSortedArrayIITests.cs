using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class SearchInRotatedSortedArrayIITests
{
    [TestCaseSource(nameof(TestCases))]
    public bool SearchInRotatedSortedArrayII_Tests(int[] nums, int target) => SearchInRotatedSortedArrayII.Search(nums, target);

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData([new int[] { 1, 3 }, 1]).Returns(true);
        yield return new TestCaseData([new int[] { 5 }, 5]).Returns(true);
        yield return new TestCaseData([new int[] { 5 }, 2]).Returns(false);
        yield return new TestCaseData([new int[] { 1, 1, 1 }, 1]).Returns(true);
        yield return new TestCaseData([new int[] { 1, 1, 1, 0, 0 }, 1]).Returns(true);
        yield return new TestCaseData([new int[] { 3, 4, 5, 0, 1 }, 5]).Returns(true);
        yield return new TestCaseData([new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0]).Returns(true);
        yield return new TestCaseData([new int[] { 2, 5, 6, 0, 0, 1, 2 }, 3]).Returns(false);
    }
}
