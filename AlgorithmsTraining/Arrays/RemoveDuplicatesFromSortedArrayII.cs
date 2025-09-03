namespace AlgorithmsTraining.Arrays;

/*
 * 80. Remove Duplicates from Sorted Array II

   Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique 
   element appears at most twice. The relative order of the elements should be kept the same.

   Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in 
   the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

   Return k after placing the final result in the first k slots of nums.
   
   Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

   Example 1:

   Input: nums = [1,1,1,2,2,3]
   Output: 5, nums = [1,1,2,2,3,_]
   Explanation: Your function should return k = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively.
   It does not matter what you leave beyond the returned k (hence they are underscores).
   
   Example 2:
   
   Input: nums = [0,0,1,1,1,1,2,3,3]
   Output: 7, nums = [0,0,1,1,2,3,3,_,_]
   Explanation: Your function should return k = 7, with the first seven elements of nums being 0, 0, 1, 1, 2, 3 and 3 respectively.
   It does not matter what you leave beyond the returned k (hence they are underscores).

   Constraints:

    [1] 1 <= nums.length <= 3 * 10^4
    [2] -10^4 <= nums[i] <= 10^4
    [3] nums is sorted in non-decreasing order.

    Runtime
    253 ms
    Beats 5.25%

    Memory
    52.92 MB
    Beats 55.18%
 */

public static class RemoveDuplicatesFromSortedArrayII
{
    public static int RemoveDuplicates(int[] nums)
    {
        if (1 == nums.Length) return 1;

        int i = 0, j = 1, rightBoundary = nums.Length - 1;

        while (j <= rightBoundary)
        {
            if (nums[i] < nums[j] || j == rightBoundary)
            {
                var shiftLength = nums[i] < nums[j] ? Math.Max(0, j - i - 2) : Math.Max(0, j - i - 1);
                ShiftArrayLeft(new Span<int>(nums, j - shiftLength, rightBoundary + 1 - (j - shiftLength)), shiftLength, shiftLength);
                rightBoundary -= shiftLength;
                i = j - shiftLength; 
                j = Math.Min(i + 1, rightBoundary);
                if (j == rightBoundary) { break; }
            }
            else { j++; }
        }

        return rightBoundary + 1;
    }

    private static void ShiftArrayLeft(Span<int> nums, int start, int length)
    {
        if (0 == length) return;
        for (int i = start; i < nums.Length; nums[i - length] = nums[i], i++);
    }
}
