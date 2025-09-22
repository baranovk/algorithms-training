namespace AlgorithmsTraining.Arrays;

/*
 * 90. Subsets II

   Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
   The solution set must not contain duplicate subsets. Return the solution in any order.

   Example 1:
   
   Input: nums = [1,2,2]
   Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]
   
   Example 2:
   
   Input: nums = [0]
   Output: [[],[0]]
   
   Constraints:
   
     [1] 1 <= nums.length <= 10
     [2] -10 <= nums[i] <= 10

   Runtime
   4 ms
   Beats 18.01%

   Memory
   47.66 MB
   Beats 27.42%
 */
public static class SubsetsII
{
    public static IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var results = new List<IList<int>> { new List<int>() };

        if (0 == nums.Length) { return results; }
        if (1 == nums.Length) { results.Add(nums); return results; }

        Array.Sort(nums);
        Descent(nums.AsSpan(), new LinkedList<int>(), results);
        return results;
    }

    private static void Descent(Span<int> nums, LinkedList<int> subset, IList<IList<int>> results)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            subset.AddLast(nums[i]);
            results.Add(new List<int>(subset));

            if (i < nums.Length - 1)
            {
                Descent(nums[(i + 1)..], subset, results);
                while (i + 1 < nums.Length && nums[i] == nums[i + 1]) { i++; }
            }
                
            subset.RemoveLast();
        }
    }
}
