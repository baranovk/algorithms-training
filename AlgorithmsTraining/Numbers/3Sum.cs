using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace AlgorithmsTraining.Numbers
{
    /*
     Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
     Find all unique triplets in the array which gives the sum of zero.

        Example:

        Given array nums = [-1, 0, 1, 2, -1, -4],

        A solution set is:
        [
          [-1, 0, 1],
          [-1, -1, 2]
        ]

     */
    public class _3Sum
    {
        public static IList<IList<int>> ThreeSum(int[] nums, int sum)
        {
            var threeSets = new List<IList<int>>();
            var processed = new HashSet<int>();
            var histogram = new Dictionary<int, int>();
            
            foreach (var t in nums)
            {
                if (!histogram.TryAdd(t, 1)) { histogram[t]++; }
            }

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (processed.Contains(nums[i])) continue;

                threeSets.AddRange(
                    BuildTwoSumSets(nums, sum - nums[i], i + 1, histogram, processed)
                        .Select(s => { s.Add(nums[i]); return s; })
                );

                processed.Add(nums[i]);
            }

            return threeSets;
        }

        public static List<IList<int>> BuildTwoSumSets(int[] nums, int sum, int startIndex, Dictionary<int, int> histogram, HashSet<int> processed)
        {
            var sets = new List<IList<int>>();
            var alreadyIncludedInSets = new HashSet<int>();

            for (var i = startIndex; i <= nums.Length - 1; i++)
            {
                if (alreadyIncludedInSets.Contains(nums[i]) || processed.Contains(nums[i])) continue;

                var useCurNumberCount = histogram[nums[i]];
                useCurNumberCount--;
                var reminder = sum - nums[i];

                if (!histogram.ContainsKey(reminder) || alreadyIncludedInSets.Contains(reminder)) continue;

                if (nums[i] != reminder || 0 < useCurNumberCount)
                {
                    if (!processed.Contains(reminder))
                    {
                        sets.Add([nums[i], reminder]);
                    }

                    alreadyIncludedInSets.Add(reminder);
                }

                if (!alreadyIncludedInSets.Contains(nums[i]))
                {
                    alreadyIncludedInSets.Add(nums[i]);
                }
            }

            return sets;
        }

        public static IList<IList<int>> ThreeSum_1(int[] nums, int sum)
        {
            var threeSets = new List<IList<int>>();
            var processed = new Dictionary<int, bool>();

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (processed.ContainsKey(nums[i])) continue;

                var reminder = sum - nums[i];
                var twoSets = TwoSum(nums, reminder, i + 1, nums.Length - 1, processed);

                foreach (var set in twoSets)
                {
                    //if(set.Any(n => processed.ContainsKey(n))) continue;

                    set.Add(nums[i]);

                    threeSets.Add(set);
                }

                processed.Add(nums[i], true);
            }

            return threeSets;
        }

        public static IList<IList<int>> ThreeSumAlt(int[] nums, int sum)
        {
            // sum = 3
            // 1  4  1  -2  5  1  0  => {1, 4, -2 }, {-2, 5, 0}, {1, 1, 1}

            // sum = 3
            // 1  2  4  2  -2  3  5  0  => { 1, 4, -2 }, { 2, -2, 3 }, { -2, 5, 0 }, { 1, 2, 0 }
            var threeSets = new List<IList<int>>();
            //var dict = nums.ToDictionary(t => t, t => 0);
            //var dict = nums.ToDictionary(t => t, t => false);
            var dict = new Dictionary<int, bool>();

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (dict.ContainsKey(nums[i])) continue;

                var reminder = sum - nums[i];
                var twoSets = TwoSum(nums, reminder, i + 1, nums.Length - 1);

                foreach (var set in twoSets)
                {
                    if (set.Any(n => dict.ContainsKey(n))) continue;

                    set.Add(nums[i]);

                    threeSets.Add(set);
                }

                dict.Add(nums[i], true);
            }

            return threeSets;
        }
        
        public static IList<IList<int>> TwoSum(int[] nums, int sum, int startIndex, int endIndex, Dictionary<int, bool> processed)
        {
            var sets = new List<IList<int>>();
            var dict = new Dictionary<int, int>();

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (0 == dict[nums[i]] || processed.ContainsKey(nums[i])) continue;
                dict[nums[i]]--;
                var reminder = sum - nums[i];

                if (dict.ContainsKey(reminder) && 0 < dict[reminder])
                {
                    if (!processed.ContainsKey(reminder))
                    {
                        sets.Add(new List<int> {nums[i], reminder});
                    }

                    dict[reminder] = 0;
                }

                dict[nums[i]] = 0;
            }

            return sets;
        }

        public static IList<IList<int>> TwoSum(int[] nums, int sum, int startIndex, int endIndex)
        {
            var sets = new List<IList<int>>();
            var dict = new Dictionary<int, int>();

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }

            // sum = 2
            // 4 2 2 1 3
            // sum = 2
            // 1 1 1 1 1
            // 1, 4, 1, -2, 5, 1, 0
            // [1] = 2
            // [4] = 1
            // [-2] = 1
            // [5] = 1
            // [0] = 1
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (0 == dict[nums[i]]) continue;
                dict[nums[i]]--;
                var reminder = sum - nums[i];

                if (dict.ContainsKey(reminder) && 0 < dict[reminder])
                {
                    sets.Add(new List<int>{ nums[i], reminder });
                    dict[reminder] = 0;
                }

                dict[nums[i]] = 0;
            }

            return sets;
        }
    }
}
