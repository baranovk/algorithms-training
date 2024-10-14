using System;

namespace AlgorithmsTraining.Arrays
{
    public static class FirstAndLastPosition
    {
        /*
           34. Find First and Last Position of Element in Sorted Array
           https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

         * Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

           If target is not found in the array, return [-1, -1].

           You must write an algorithm with O(log n) runtime complexity.

           1. Input: nums = [5,7,7,8,8,10], target = 8
              Output: [3,4]

           2. Input: nums = [5,7,7,8,8,10], target = 6
              Output: [-1,-1]

           3. Input: nums = [], target = 0
              Output: [-1,-1]
         */
        public static int[] SearchRange(int[] nums, int target)
        {
            if (0 == nums.Length) return new[] { -1, -1 };
            if (1 == nums.Length) return target == nums[0] ? new[] {0, 0} : new[] {-1, -1};

            int lowIndex, highIndex;

            lowIndex = highIndex = Array.BinarySearch(nums, target);
            if (0 > lowIndex) return new[] {-1, -1};

            var result = new [] {lowIndex, highIndex};

            while (0 <= lowIndex || 0 <= highIndex)
            {
                if (0 <= highIndex)
                {
                    highIndex = Array.BinarySearch(nums, highIndex + 1, nums.Length - highIndex - 1, target);
                    if (0 <= highIndex) result[1] = highIndex;
                }

                if (0 <= lowIndex)
                {
                    lowIndex = Array.BinarySearch(nums, 0, lowIndex, target);
                    if (0 <= lowIndex) result[0] = lowIndex;
                }
            }

            return result;
        }
    }
}
