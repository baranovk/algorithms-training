using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays;

internal class MergeSortedArrayTests
{
    [TestCaseSource(nameof(TestCases))]
    public void MergeSortedArray_Tests(int[] nums1, int m, int[] nums2, int[] expectedResult)
    {
        MergeSortedArray.Merge(nums1, m, nums2, nums2.Length);
        Assert.That(nums1, Is.EquivalentTo(expectedResult));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(
            new int[] { 1 },
            1,
            new int[] { },
            new int[] { 1 }
        );

        yield return new TestCaseData(
            new int[] { 0 },
            0,
            new int[] { 1 },
            new int[] { 1 }
        );

        yield return new TestCaseData(
            new int[] { 1, 2, 3 },
            3,
            new int[] { },
            new int[] { 1, 2, 3 }
        );

        yield return new TestCaseData(
            new int[] { 1, 2, 3, 0, 0, 0 },
            3,
            new int[] { 2, 5, 6 },
            new int[] { 1, 2, 2, 3, 5, 6 }
        );

        yield return new TestCaseData(
            new int[] { 1, 2, 3, 5, 7, 0, 0, 0, 0 },
            5,
            new int[] { 2, 5, 8, 9 },
            new int[] { 1, 2, 2, 3, 5, 5, 7, 8, 9 }
        );
    }
}
