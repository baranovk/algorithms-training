using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmsTraining.Numbers
{
    /*
     * Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target.
     * Return the sum of the three integers. You may assume that each input would have exactly one solution.
     
        Example 1:

        Input: nums = [-1, 2, 1, -4], target = 1
        Output: 2
        Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

        Constraints:

        3 <= nums.length <= 10^3

        -10^3 <= nums[i] <= 10^3

        -10^4 <= target <= 10^4
     */
    public class _3SumClosest
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            if (3 > nums.Length) throw new ArgumentOutOfRangeException("nums.Length");

            Array.Sort(nums);
            var result = 0;
            var minDifference = int.MaxValue;

            // target = 1
            // { -4, -1, 1, 2 }
            for (var i = 0; i < nums.Length - 2; i++)
            {
                if(0 < i && nums[i] == nums[i-1]) continue;

                var reminder = target - nums[i];
                // nums[i] = -1
                // reminder = 1 - (-1) = 2
                var closestSum = TwoSumClosest(nums, reminder, i + 1) + nums[i]; // 3 + (-1) = 2
                var difference = Math.Abs(target - closestSum); // 1 - (2) = 1

                if (difference < minDifference)
                {
                    minDifference = difference; // minDiff = 1
                    result = closestSum; // result = 2
                }
            }

            return result;
        }

        private static int TwoSumClosest(int[] nums, int target, int startIndex)
        {
            if (startIndex >= nums.Length - 1) throw new ArgumentOutOfRangeException("startIndex");

            // target = 80
            // { 4, 8, 16, 32, 64, 128 }
            var left = startIndex;
            var right = nums.Length - 1;
            var result = nums[left] + nums[right];
            var minDifference = Math.Abs(target - result);

            while (1 < right - left)
            {
                var stepLeftSum = nums[left + 1] + nums[right];
                var stepRightSum = nums[right - 1] + nums[left];
                var diffLeft = Math.Abs(target - stepLeftSum);
                var diffRight = Math.Abs(target - stepRightSum);

                // 32  + 64 - ?
                // left = 16
                // right = 64
                // 32 + 64 = 96 dl = 16
                // 16 + 32 = 48 dr = 32
                // r = 80
                if (diffLeft < diffRight)
                {
                    if (minDifference > diffLeft)
                    {
                        minDifference = diffLeft;
                        result = stepLeftSum;
                    }

                    left++;
                }
                else
                {
                    if (minDifference > diffRight)
                    {
                        minDifference = diffRight;
                        result = stepRightSum;
                    }

                    right--;
                }
            }

            return result;
        }

        private static int TwoSumClosest_1(int[] nums, int target, int startIndex)
        {
            if(startIndex >= nums.Length - 1) throw new ArgumentOutOfRangeException("startIndex");

            var result = 0;
            var minDifference = int.MaxValue;

            // target = 2
            // { 1, 2 }

            for (var i = startIndex; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j <= nums.Length - 1; j++)
                {
                    var sum = nums[i] + nums[j]; // 1 + 2 = 3
                    var difference = Math.Abs(target - sum); // 2 - 3 = -1

                    if (difference < minDifference)
                    {
                        minDifference = difference; // minDiff = -1
                        result = sum; // result = 3
                    }
                }

                if (target < nums[i]) return result;
            }

            return result;
        }
    }
}
