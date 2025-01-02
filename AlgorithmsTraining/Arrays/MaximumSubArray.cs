namespace AlgorithmsTraining.Arrays;

/*
 * Given an integer array nums, find the subarray with the largest sum, and return its sum.

   Example 1:
   
   Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
   Output: 6
   Explanation: The subarray [4,-1,2,1] has the largest sum 6.
   
   Example 2:
   
   Input: nums = [1]
   Output: 1
   Explanation: The subarray [1] has the largest sum 1.
   
   Example 3:
   
   Input: nums = [5,4,-1,7,8]
   Output: 23
   Explanation: The subarray [5,4,-1,7,8] has the largest sum 23

   Constraints:

   1 <= nums.length <= 10^5
   -10^4 <= nums[i] <= 10^4

   Follow up: If you have figured out the O(n) solution, try coding another solution using 
   the divide and conquer approach, which is more subtle.

   Runtime
   2ms
   Beats19.02%

   Memory
   63.72MB
   Beats7.56%
 */
public static class MaximumSubArray
{
    public static int Solution(int[] nums)
    {
        if (1 == nums.Length) { return nums[0]; }

        int maxSum = int.MinValue, maxElement = nums[0];

        for (int i = 0, accumulator = 0; i < nums.Length; maxElement = maxElement >= nums[i] ? maxElement : nums[i], i++)
        {
            if (0 > nums[i])
            {
                accumulator = 0 > accumulator + nums[i] ? 0 : accumulator + nums[i];
            }
            else
            {
                accumulator += nums[i];
                maxSum = Math.Max(maxSum, accumulator);
            }
        }

        return Math.Max(maxElement, maxSum);
    }

    public static int Solution6(int[] nums)
    {
        if (1 == nums.Length) { return nums[0]; }
        
        int maxSum = int.MinValue, maxElement = nums[0], reducedLength = default;
        Span<int> reduced = stackalloc int[nums.Length];

        // reduce
        for (
            int i = 1, previous = nums[0], accumulator = nums[0]; 
            i < nums.Length;
            maxElement = maxElement >= nums[i] ? maxElement : nums[i],
            previous = nums[i], 
            i++)
        {
            if ((0 >= previous && 0 < nums[i]) || (0 < previous && 0 >= nums[i]))
            {
                reduced[reducedLength++] = accumulator;
                accumulator = 0;
            }

            accumulator += nums[i];
            if (i == nums.Length - 1) { reduced[reducedLength++] = accumulator; }
        }

        for (int i = 0, accumulator = 0; i < reducedLength; i++)
        {
            if (0 > reduced[i])
            {
                accumulator = 0 > accumulator + reduced[i] ? 0 : accumulator + reduced[i];
            }
            else
            {
                accumulator += reduced[i];
                maxSum = Math.Max(maxSum, accumulator);
            }
        }

        return Math.Max(maxElement, maxSum);
    }

    public static int Solution5(int[] nums)
    {
        if (1 == nums.Length) { return nums[0]; }

        int maxSum = nums[0], maxElement = nums[0], extremumsCount = 0;
        Span<int> sumsMemo = stackalloc int[nums.Length];
        Span<int> extremums = stackalloc int[nums.Length];
        sumsMemo[0] = nums[0];

        if (0 <= nums[0])
        {
            extremums[extremumsCount++] = 0;
        }

        for (
            int i = 1, accumulator = nums[0];
            i < nums.Length;
            maxSum = maxSum >= nums[i] ? maxSum : nums[i],
            maxElement = maxElement >= nums[i] ? maxElement : nums[i],
            sumsMemo[i] = accumulator += nums[i], 
            i++
        )
        {
            if (nums[i - 1] <= 0 && nums[i] > 0) { extremums[extremumsCount++] = i; }
        }

        var maxSumFinal = int.MinValue;

        for (var i = 0; i < extremumsCount; i++)
        {
            var extremumIndex = extremums[i];
            maxSum = sumsMemo[extremumIndex];

            for (var j = extremumIndex; j < nums.Length; j++)
            {
                var rangeSum = sumsMemo[j] - (0 == extremumIndex ? 0 : sumsMemo[extremumIndex - 1]);
                maxSum = maxSum >= rangeSum ? maxSum : rangeSum;
            }

            maxSumFinal = Math.Max(maxSumFinal, maxSum);
        }

        return Math.Max(maxElement, maxSumFinal);
    }

    public static int Solution4(int[] nums)
    {
        if (1 == nums.Length) { return nums[0]; }

        // заполнение sumMemo суммами, посчитанными на предыдущем шаге
        int maxSum = int.MinValue, minSum = int.MaxValue, maxSumSingle = nums[0];
        Span<int> sumsMemo = stackalloc int[nums.Length];
        Span<int> extremums = stackalloc int[2];

        for (
            int i = 1, accumulator = nums[0];
            i < nums.Length;
            sumsMemo[i] = accumulator += nums[i],
            maxSumSingle = maxSumSingle >= nums[i] ? maxSumSingle : nums[i],
            extremums[0] = maxSum >= sumsMemo[i] ? extremums[0] : i,
            extremums[1] = minSum <= sumsMemo[i] ? extremums[1] : i,
            maxSum = maxSum >= sumsMemo[i] ? maxSum : sumsMemo[i],
            minSum = minSum <= sumsMemo[i] ? minSum : sumsMemo[i],
            i++
        ) ;

        for (int i = 0; i < extremums.Length; i++)
        {
            var max = sumsMemo[extremums[i]];
            var extremumMemo = sumsMemo[extremums[i]];

            for (int j = 0, accumulator = 0; j < extremums[i]; j++)
            {
                accumulator += nums[j];
                max = extremumMemo - accumulator > max ? extremumMemo - accumulator : max;
            }

            extremums[i] = max;
        }

        int maxFinal = default;

        for (int i = 0; i < extremums.Length; i++)
        {
            maxFinal = Math.Max(maxFinal, Math.Max(extremums[i], maxSumSingle));
        }

        return maxFinal;
    }

    public static int Solution3(int[] nums)
    {
        // заполнение sumMemo суммами, посчитанными на предыдущем шаге
        var maxSum = int.MinValue;
        Span<int> sumsMemo = stackalloc int[nums.Length];

        for (
            int i = 0, accumulator = 0;
            i < nums.Length;
            maxSum = maxSum >= nums[i] ? maxSum : nums[i], sumsMemo[i] = accumulator += nums[i], i++
        ) ;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (i > 0 && sumsMemo[i - 1] >= 0) continue;

            for (var j = i; j < nums.Length; j++)
            {
                var sum_i_j = sumsMemo[j] - (0 == i ? 0 : sumsMemo[i - 1]);
                maxSum = maxSum >= sum_i_j ? maxSum : sum_i_j;
            }
        }

        return maxSum;
    }

    public static int Solution2(int[] nums)
    {
        // заполнение sumMemo суммами, посчитанными на предыдущем шаге
        int maxSum = int.MinValue, maxSumSingle = nums[0], indexOfMax = -1;
        Span<int> sumsMemo = stackalloc int[nums.Length];

        for (
            int i = 1, accumulator = nums[0];
            i < nums.Length;
            sumsMemo[i] = accumulator += nums[i],
            maxSumSingle = maxSumSingle >= nums[i] ? maxSumSingle : nums[i],
            indexOfMax = maxSum >= sumsMemo[i] ? indexOfMax : i,
            maxSum = maxSum >= sumsMemo[i] ? maxSum : sumsMemo[i],
            i++
        ) ;

        var maxMemo = maxSum;

        for (int i = 0, accumulator = 0; i < indexOfMax; i++)
        {
            accumulator += nums[i];
            maxSum = maxMemo - accumulator > maxSum ? maxMemo - accumulator : maxSum;
        }

        return Math.Max(maxSum, maxSumSingle);
    }

    public static int Solution1(int[] nums)
    {
        // заполнение sumMemo суммами, посчитанными на предыдущем шаге
        var maxSum = int.MinValue;
        Span<int> sumsMemo = stackalloc int[nums.Length];

        for (
            int i = 0, accumulator = 0; 
            i < nums.Length;
            maxSum = maxSum >= nums[i] ? maxSum : nums[i], sumsMemo[i] = accumulator += nums[i], i++
        );

        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i; j < nums.Length; j++)
            {
                var sum_i_j = sumsMemo[j] - (0 == i ? 0 : sumsMemo[i - 1]);
                maxSum = maxSum >= sum_i_j ? maxSum : sum_i_j;
            }
        }

        return maxSum;
    }
}
