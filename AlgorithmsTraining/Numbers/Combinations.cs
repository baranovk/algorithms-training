namespace AlgorithmsTraining.Numbers;

/*
 * 61. Rotate List
 * 
 * Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].

   You may return the answer in any order.

   Example 1:

   Input: n = 4, k = 2
   Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
   Explanation: There are 4 choose 2 = 6 total combinations.
   Note that combinations are unordered, i.e., [1,2] and [2,1] are considered to be the same combination.
   
   Example 2:
   
   Input: n = 1, k = 1
   Output: [[1]]
   Explanation: There is 1 choose 1 = 1 total combination.

   Constraints:

    [1] 1 <= n <= 20
    [2] 1 <= k <= n

    Runtime
    140 ms
    Beats 8.00%

    Memory
    102.17 MB
    Beats 6.20%
 */
public static class Combinations
{
    public static IList<IList<int>> Combine(int n, int k)
    {
        var accumulator = new List<IList<int>>();
        BuildCombinations(Enumerable.Range(1, n).ToArray().AsSpan(), k, Enumerable.Repeat(0, k).ToList(), accumulator);
        return accumulator;
    }

    private static void BuildCombinations(Span<int> range, int combinationLength, IList<int> currentCombination, IList<IList<int>> accumulator)
    {
        for (int i = 0; i <= range.Length - combinationLength; i++)
        {
            currentCombination[currentCombination.Count - combinationLength] = range[i];

            if (combinationLength - 1 > 0)
            {
                BuildCombinations(range[(i + 1)..], combinationLength - 1, currentCombination, accumulator);
            }
            else
            {
                accumulator.Add(currentCombination.Select(_ => _).ToList());
            }
        }
    }
}
