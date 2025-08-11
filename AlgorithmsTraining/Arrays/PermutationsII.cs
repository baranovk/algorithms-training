using System.Diagnostics.CodeAnalysis;

namespace AlgorithmsTraining.Arrays;

/*
 * 47. Permutations II
 * 
 * Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

   Example 1:
   
   Input: nums = [1,1,2]
   
   Output:
   [[1,1,2],
    [1,2,1],
    [2,1,1]]
   
   Example 2:
   
   Input: nums = [1,2,3]
   Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
   
   Constraints:

   [1] 1 <= nums.length <= 8
   [2] -10 <= nums[i] <= 10

   Runtime
   182 ms
   Beats 5.15%

   Memory
   60.15 MB
   Beats 8.82%
 */

public static class PermutationsII
{
    public static IList<IList<int>> PermuteUnique(int[] nums)
    {
        var results = Permute(nums);
        return results.Distinct(new PermutationsComparer()).ToList();
    }

    private static IList<IList<int>> Permute(int[] nums)
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

    private class PermutationsComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int>? x, IList<int>? y)
        {
            if (null == x && null == y) return true;
            if (null != x && null == y) return false;
            if (null == x && null != y) return false;
            if (x!.Count != y!.Count) return false;
            if (GetHashCode(x) != GetHashCode(y)) return false;

            return true;
        }

        public int GetHashCode([DisallowNull] IList<int> obj) => obj.Aggregate(0, (total, next) => HashCode.Combine(total, next));
    }
}
