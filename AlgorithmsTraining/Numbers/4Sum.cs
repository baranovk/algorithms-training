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
        var sets = new List<IList<int>>();
        var processed4Sum = new HashSet<int>();
        var histogram = nums.BuildHistogram();
        var snums = nums.AsSpan();

        for (int i = 0; i < snums.Length - 3; i++)
        {
            histogram[snums[i]]--;
            if (processed4Sum.Contains(snums[i])) { continue; }

            var reminder = target - snums[i];

            var treeSets = FindThreeSumSets(snums.Slice(i + 1, snums.Length - 1 - i), reminder, histogram, processed4Sum);

            foreach (var set in treeSets)
            {
                set.Add(nums[i]);
                sets.Add(set);
            }

            processed4Sum.Add(nums[i]);
        }

        return sets;
    }

    public static IList<IList<int>> FindThreeSumSets(Span<int> nums, int sum, Dictionary<int, int> histogram, HashSet<int> processed4Sum)
    {
        var sets = new List<IList<int>>();
        var processed3Sum = new HashSet<int>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (processed4Sum.Contains(nums[i]) || processed3Sum.Contains(nums[i])) { continue; }
            var reminder = sum - nums[i];

            histogram[nums[i]]--;
            var twoSets = FindTwoSumSets(nums.Slice(i + 1, nums.Length - 1 - i), reminder, histogram, processed3Sum, processed4Sum);

            foreach (var set in twoSets)
            {
                set.Add(nums[i]);
                sets.Add(set);
            }

            histogram[nums[i]]++;
            processed3Sum.Add(nums[i]);
        }

        return sets;
    }

    public static IList<IList<int>> FindTwoSumSets(Span<int> nums, int sum, Dictionary<int, int> histogram,
        HashSet<int> processed3Sum, HashSet<int> processed4Sum)
    {
        var sets = new List<IList<int>>();
        var alreadyInSets = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var reminder = sum - nums[i];

            if (processed3Sum.Contains(nums[i])
                || processed3Sum.Contains(reminder)
                || processed4Sum.Contains(nums[i]) 
                || processed4Sum.Contains(reminder))
            { continue; }

            if (alreadyInSets.Contains(nums[i]) 
                || alreadyInSets.Contains(reminder)
                || !(histogram.TryGetValue(reminder, out var count) && count > (nums[i] == reminder ? 1 : 0)))
            { continue; }

            alreadyInSets.Add(nums[i]);
            alreadyInSets.Add(reminder);
            sets.Add([nums[i], reminder]);
        }

        return sets;
    }
}
