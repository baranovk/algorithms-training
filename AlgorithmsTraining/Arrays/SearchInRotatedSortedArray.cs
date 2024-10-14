﻿using System;

namespace AlgorithmsTraining.Arrays
{
    public static class SearchInRotatedSortedArray
    {
        /*
         * 33. Search in Rotated Sorted Array
         * https://leetcode.com/problems/search-in-rotated-sorted-array/
         *
         * There is an integer array nums sorted in ascending order (with distinct values).

           Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) 
           such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 

           For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

           Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, 
           or -1 if it is not in nums.

           You must write an algorithm with O(log n) runtime complexity.
         */
        public static int Search(int[] nums, int target)
        {
            return SearchInRange(nums, target, 0, nums.Length - 1);
        }

        public static int SearchInRange(int[] nums, int target, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex) return nums[leftIndex] == target ? leftIndex : -1;
            if (nums[leftIndex] < nums[rightIndex] && (target > nums[rightIndex] || target < nums[leftIndex])) return -1;

            if (2 == rightIndex - leftIndex + 1)
            {
                if (target == nums[leftIndex]) return leftIndex;
                if (target == nums[rightIndex]) return rightIndex;
                return -1;
            }

            var middleIndex = (rightIndex + leftIndex) / 2;

            return Math.Max(
                SearchInRange(nums, target, leftIndex, middleIndex),
                SearchInRange(nums, target, middleIndex + 1, rightIndex)
            );
        }
    }
}