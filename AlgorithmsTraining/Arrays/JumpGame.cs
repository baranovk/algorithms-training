namespace AlgorithmsTraining.Arrays;

/*
 
You are given an integer array nums. You are initially positioned at the array's first index, 
and each element in the array represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, 
which makes it impossible to reach the last index.

Constraints:

    1 <= nums.length <= 10^4
    0 <= nums[i] <= 10^5
*/
public class JumpGame
{
    private readonly HashSet<int> _memo_true = new();
    private readonly HashSet<int> _memo_false = new();

    public bool CanJump(int[] nums) => (1 == nums.Length && 0 <= nums[0]) || CanJumpInner(new Span<int>(nums));

    private bool CanJumpInner(Span<int> nums)
    {
        if (_memo_true.Contains(nums.Length - 1)) return true;
        if (_memo_false.Contains(nums.Length - 1)) return false;

        for (var i = nums.Length - 2; i >= 0; --i) 
        {
            if ((i + nums[i] >= nums.Length - 1) && (0 == i || CanJumpInner(nums[..(i + 1)])))
            {
                _memo_true.Add(nums.Length - 1);
                return true; 
            }
            else
            {
                _memo_false.Add(i);
            }
        }

        return false;
    }
}
