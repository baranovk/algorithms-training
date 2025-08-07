using System.Runtime.CompilerServices;

namespace AlgorithmsTraining.Arrays;

/*
 * 45. Jump Game II

 * You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

   Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at 
   nums[i], you can jump to any nums[i + j] where:

    0 <= j <= nums[i] and
    i + j < n

   Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

   Example 1:
   
   Input: nums = [2,3,1,1,4]
   Output: 2
   Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
   
   Example 2:
   
   Input: nums = [2,3,0,1,4]
   Output: 2

   Constraints:

    - 1 <= nums.length <= 10^4
    - 0 <= nums[i] <= 1000
    - It's guaranteed that you can reach nums[n - 1].

    Runtime
    688 ms
    Beats 5.10%

    Memory
    50.92 MB
    Beats 5.10%
 */
public static class JumpGameII
{
    private const int MAX_JUMPS = 10_000;
    private const int JUMP_FAILURE_VALUE = 10_000 * 2;

    public static int MinJumps(int[] nums)
    {
        if (1 == nums.Length) { return 0; }

        var minJumps  = MAX_JUMPS;
        MinJumpsInner(new Span<int>(nums), 0, 0, [], ref minJumps);
        return MAX_JUMPS == minJumps ? -1 : minJumps;
    }

    private static int MinJumpsInner(Span<int> nums, int jumpsToThis, int offset, Dictionary<int, int> memo, ref int minJumps)
    {
        if (memo.TryGetValue(offset, out var jumps)) 
        {
            minJumps = Math.Min(jumps + jumpsToThis, minJumps);
            return jumps; 
        }

        if (nums[0] >= nums.Length - 1)
        {
            memo.Add(offset, 1);
            minJumps = Math.Min(jumpsToThis + 1, minJumps);
            return 1;
        }

        int minJumpsFromCurrentOffset = JUMP_FAILURE_VALUE;

        for (var i = nums[0]; i >= 1; i--) 
        {
            minJumpsFromCurrentOffset = Math.Min(
                minJumpsFromCurrentOffset, 
                1 + MinJumpsInner(nums[i..], jumpsToThis + 1, offset + i, memo, ref minJumps)
            );
        }

        memo.Add(offset, minJumpsFromCurrentOffset);
        return minJumpsFromCurrentOffset;
    }
}
