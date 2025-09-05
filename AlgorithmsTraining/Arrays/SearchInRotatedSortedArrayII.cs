namespace AlgorithmsTraining.Arrays;

/*
 * 81. Search in Rotated Sorted Array II

   There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).

   Before being passed to your function, nums is rotated at an unknown pivot index k (0 <= k < nums.length) 
   such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
   For example, [0,1,2,4,4,4,5,6,6,7] might be rotated at pivot index 5 and become [4,5,6,6,7,0,1,2,4,4].
   
   Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.
   
   You must decrease the overall operation steps as much as possible.

   Example 1:
   
   Input: nums = [2,5,6,0,0,1,2], target = 0
   Output: true
   
   Example 2:
   
   Input: nums = [2,5,6,0,0,1,2], target = 3
   Output: false

   Constraints:

    [1] 1 <= nums.length <= 5000
    [2] -10^4 <= nums[i] <= 10^4
    [3] nums is guaranteed to be rotated at some pivot.
    [4] -10^4 <= target <= 10^4

    Follow up: This problem is similar to Search in Rotated Sorted Array, but nums may contain duplicates. 
    Would this affect the runtime complexity? How and why?

    Runtime
    1 ms
    Beats 11.11%

    Memory
    45.70 MB
    Beats 57.78%
 */
public static class SearchInRotatedSortedArrayII
{
    public static bool Search(int[] nums, int target)
    {
        if (1 == nums.Length) { return nums[0] == target; }

        var pivot = 0;
        while (pivot < nums.Length - 1 && nums[pivot] <= nums[pivot + 1]) { pivot++; }
        if (pivot == nums.Length - 1) { return SearchInRange(nums, target); }

        return target >= nums[0] && target <= nums[pivot] 
            ? SearchInRange(nums.AsSpan(0, pivot + 1), target)
            : SearchInRange(nums.AsSpan(pivot + 1, nums.Length - pivot - 1), target);
    }

    public static bool SearchInRange(Span<int> nums, int target)
    {
        int i = 0, j = nums.Length - 1;
        while (i < j && nums[i + 1] == nums[i]) { i++; }
        while (i < j && nums[j - 1] == nums[j]) { j--; }

        if ((i == j) || 2 == (j - i + 1)) { return (target == nums[i] || target == nums[j]); }
        
        nums = nums.Slice(i, j - i + 1);
        var middleIndex = nums.Length / 2;

        return SearchInRange(nums[..(middleIndex + 1)], target)
            || SearchInRange(nums[(middleIndex + 1)..], target);
    }
}
