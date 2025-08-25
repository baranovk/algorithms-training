using System.Diagnostics.CodeAnalysis;

namespace AlgorithmsTraining.Numbers;

/*
 * 40. Combination Sum II

Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates
where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.
Note: The solution set must not contain duplicate combinations.

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
  [1,1,6],
  [1,2,5],
  [1,7],
  [2,6]
]

Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
  [1,2,2],
  [5]
]

Constraints:

  [1] 1 <= candidates.length <= 100
  [2] 1 <= candidates[i] <= 50
  [3] 1 <= target <= 30

Runtime
6 ms
Beats 55.79%

Memory
48.02 MB
Beats 15.75%
 */
public static class CombinationSumII
{
    public static IList<IList<int>> Solution(int[] candidates, int target)
    {
        Array.Sort(candidates);
        var combinations = new List<IList<int>>();
        FindCombinations(combinations, candidates.AsSpan(), target, new Stack<int>(), 0, []);
        return combinations;
    }

    private static void FindCombinations(IList<IList<int>> accumulator, Span<int> slice, int target, 
        Stack<int> combination, int hash, HashSet<int> memo)
    {
        for (int i = 0; i < slice.Length && slice[i] <= target; i++)
        {
            combination.Push(slice[i]);
            
            if (slice[i] == target)
            {
                var finishHash = HashCode.Combine(hash, slice[i]);
                if (!memo.Contains(finishHash))
                {
                    memo.Add(finishHash);
                    accumulator.Add([.. combination]);
                }
            }
            else if (i + 1 < slice.Length && target - slice[i] >= slice[i])
            {
                FindCombinations(accumulator, slice[(i + 1)..], target - slice[i], combination, HashCode.Combine(hash, slice[i]), memo);
                while (i + 1 < slice.Length && slice[i] == slice[i + 1]) { i++; }
            }

            combination.Pop();
        }
    }

    private class ListsComparer : IEqualityComparer<IList<int>>
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
