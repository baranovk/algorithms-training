namespace AlgorithmsTraining.Arrays;

/*
 * 46. Permutations

   Given an array nums of distinct integers, return all the possible
   You can return the answer in any order.

   Example 1:
   
   Input: nums = [1,2,3]
   Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
   
   Example 2:
   
   Input: nums = [0,1]
   Output: [[0,1],[1,0]]
   
   Example 3:
   
   Input: nums = [1]
   Output: [[1]]

   Constraints:

   [1] 1 <= nums.length <= 6
   [2] -10 <= nums[i] <= 10
   [3] All the integers of nums are unique.

   Runtime
   2 ms
   Beats 38.59%

   Memory
   47.91 MB
   Beats 23.87%
*/
public static class Permutations
{
    public static IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        PermuteStep(0, nums, new Queue<int>(nums), result);
        return result;
    }

    private static void PermuteStep(int index, int[] nums, Queue<int> numsQueue, IList<IList<int>> result)
    {
        for (var i = 0; i < numsQueue.Count; i++)
        {
            var num = numsQueue.Dequeue();
            nums[index] = num;

            if (0 == numsQueue.Count)
            {
                result.Add(new List<int>(nums));
            }
            else
            {
                PermuteStep(index + 1, nums, numsQueue, result);
            }

            numsQueue.Enqueue(num);
        }
    }
}
