using System.Collections.Generic;

namespace AlgorithmsTraining.Numbers;

public static class _4Sum
{
    /*
     * 18. 4Sum
       
       Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

       - 0 <= a, b, c, d < n
       - a, b, c, and d are distinct.
       - nums[a] + nums[b] + nums[c] + nums[d] == target

        You may return the answer in any order.

        Example 1:

        Input: nums = [1,0,-1,0,-2,2], target = 0
        Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
        
        Example 2:
        
        Input: nums = [2,2,2,2,2], target = 8
        Output: [[2,2,2,2]]
        
        Constraints:
        
          1 <= nums.length <= 200
          -10^9 <= nums[i] <= 10^9
          -10^9 <= target <= 10^9

     */
    public static IList<IList<int>> Solution(int[] nums, int target)
    {
        throw new NotImplementedException();
    }

    public static IList<IList<int>> FindThreeSumSets(Span<int> nums, int sum, Dictionary<int, int> histogram, HashSet<int> processedReminders)
    {
        var sets = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var reminder = sum - nums[i];
            if (processedReminders.Contains(reminder)) { continue; }

            histogram[nums[i]]--;
            var twoSets = FindTwoSumSets(nums.Slice(i + 1, nums.Length - 1 - i), reminder, histogram);

            foreach (var set in twoSets)
            {
                set.Add(nums[i]);
                sets.Add(set);
            }
            
            processedReminders.Add(reminder);
        }

        return sets;
    }

    // каждый ключ в histogram показывает, сколько еще таких ключей осталось в обрабатываемой части массива - nums
    public static IList<IList<int>> FindTwoSumSets(Span<int> nums, int sum, Dictionary<int, int> histogram)
    {
        var sets = new List<IList<int>>();
        var alreadyIncludedInSets = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var reminder = sum - nums[i];

            if (alreadyIncludedInSets.Contains(nums[i]) 
                || alreadyIncludedInSets.Contains(reminder)
                || !(histogram.TryGetValue(reminder, out var count) && count > (nums[i] == reminder ? 1 : 0)))
            { continue; }

            alreadyIncludedInSets.Add(nums[i]);
            alreadyIncludedInSets.Add(reminder);
            sets.Add([nums[i], reminder]);
        }

        return sets;
    }
}
