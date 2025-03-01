namespace AlgorithmsTraining;

public static class Utility
{
    public static Dictionary<T, int> BuildHistogram<T>(this T[] nums, IEqualityComparer<T>? comparer = null) where T : notnull
        => nums.Aggregate(new Dictionary<T, int>(comparer),
            (accDict, num) => { accDict[num] = accDict.TryGetValue(num, out var count) ? count + 1 : 1; return accDict; });
}
