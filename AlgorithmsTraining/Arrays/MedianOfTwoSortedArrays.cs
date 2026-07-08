namespace AlgorithmsTraining.Arrays
{
    /*
     * 4. Median of Two Sorted Arrays
     * 
     * Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

       The overall run time complexity should be O(log (m+n)).
       
       Example 1:
       
       Input: nums1 = [1,3], nums2 = [2]
       Output: 2.00000
       Explanation: merged array = [1,2,3] and median is 2.
       
       Example 2:
       
       Input: nums1 = [1,2], nums2 = [3,4]
       Output: 2.50000
       Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
       
       Constraints:
       
        [1] nums1.length == m
        [2] nums2.length == n
        [3] 0 <= m <= 1000
        [4] 0 <= n <= 1000
        [5] 1 <= m + n <= 2000
        [6] -10^6 <= nums1[i], nums2[i] <= 10^6

        Runtime
        1 ms
        Beats 76.37%

        Memory
        55.74 MB
        Beats 54.40%
     */
    public static class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var merge = new int[1 + (nums1.Length + nums2.Length) / 2];
            int i = 0, j = 0;

            for (int k = 0; k < merge.Length; k++)
            {
                merge[k] = j == nums2.Length || (i < nums1.Length && nums1[i] <= nums2[j]) ? nums1[i++] : nums2[j++];
            }

            return 0 == (nums1.Length + nums2.Length) % 2
                ? (double)(merge[^1] + merge[^2]) / 2 : merge[^1];
        }
    }
}
