using System.Collections;
using AlgorithmsTraining.Arrays;

namespace AlgorithmsTraining.Tests.Arrays
{
    internal class MedianOfTwoSortedArraysTests
    {
        [TestCaseSource(nameof(TestCases))]
        public double MedianOfTwoSortedArrays_Tests(int[] nums1, int[] nums2) => MedianOfTwoSortedArrays.FindMedianSortedArrays(nums1, nums2);

        private static IEnumerable TestCases()
        {
            yield return new TestCaseData([new int[] { }, new int[] { 1, 2 }]).Returns(1.5);
            yield return new TestCaseData([new int[] { 1, 2 }, new int[] { }]).Returns(1.5);
            yield return new TestCaseData([new int[] { 1, 3 }, new int[] { 2 }]).Returns(2);
            yield return new TestCaseData([new int[] { 1, 2 }, new int[] { 3, 4 }]).Returns(2.5);
            yield return new TestCaseData([new int[] { 3, 4 }, new int[] { 1, 2 }]).Returns(2.5);
            yield return new TestCaseData([new int[] { 1, 3, 5 }, new int[] { 2, 4 }]).Returns(3);
        }
    }
}
