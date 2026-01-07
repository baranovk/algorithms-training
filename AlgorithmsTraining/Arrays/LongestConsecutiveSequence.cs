namespace AlgorithmsTraining.Arrays
{
    /*
     * 128. Longest Consecutive Sequence
    
       Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
       You must write an algorithm that runs in O(n) time.

       Example 1:
       
       Input: nums = [100,4,200,1,3,2]
       Output: 4
       Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
       
       Example 2:
       
       Input: nums = [0,3,7,2,5,8,4,6,0,1]
       Output: 9
       
       Example 3:
       
       Input: nums = [1,0,1,2]
       Output: 3
       
       Constraints:
       
           [1] 0 <= nums.length <= 10^5
           [2] -10^9 <= nums[i] <= 10^9

       Runtime
       32 ms
       Beats 94.07%

       Memory
       75.40 MB
       Beats 12.82%
     */
    public static class LongestConsecutiveSequence
    {
        public static int LongestConsecutive_0(int[] nums)
        {
            var set = new HashSet<int>(nums.Length);
            int longest = 0, current = 0, minIndex = 0, maxIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
                minIndex = Math.Min(minIndex, nums[i]);
                maxIndex = Math.Max(maxIndex, nums[i]);
            }

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (set.Contains(i))
                {
                    current++;
                }
                else if (0 < current)
                {
                    longest = Math.Max(current, longest);
                    current = 0;
                }
            }

            return Math.Max(current, longest);
        }

        public static int LongestConsecutive(int[] nums)
        {
            var dict = new Dictionary<int, int>(nums.Length);
            int longest = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                if (dict.ContainsKey(nums[i])) { continue; }

                dict.Add(nums[i], 1);
                int left = nums[i]; 
                int right = nums[i]; 

                if (dict.ContainsKey(nums[i] + 1))
                {
                    right = nums[i] + dict[nums[i] + 1];
                    dict[nums[i]] += dict[right];
                }
                
                if (dict.ContainsKey(nums[i] - 1))
                {
                    left = nums[i] - dict[nums[i] - 1];
                    dict[nums[i]] += dict[left];
                }

                dict[left] = dict[right] = dict[nums[i]];
                longest = Math.Max(longest, dict[nums[i]]);
            }
            
            return longest;
        }
    }
}
