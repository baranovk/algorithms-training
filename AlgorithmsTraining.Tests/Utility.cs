using System.Reflection;

namespace AlgorithmsTraining.Tests;

internal static class Utility
{
    public static bool MatrixesAreEqual<T>(T[][] arr1, T[][] arr2, IEqualityComparer<T>? comparer = null)
    {
        if (arr1.Length != arr2.Length) { return false; }

        for (var i = 0; i < arr1.Length; i++)
        {
            for (var j = 0; j < arr1.Length; j++)
            {
                if (null == arr1[i][j] || (null != comparer ? !comparer.Equals(arr1[i][j], arr2[i][j]) : !arr1[i][j]!.Equals(arr2[i][j]))) 
                { 
                    return false; 
                }
            }
        }

        return true;
    }

    public static Dictionary<T, int> BuildArrayHistogram<T>(T[] nums, IEqualityComparer<T>? comparer = null) where T: notnull
        => nums.Aggregate(new Dictionary<T, int>(comparer),
            (accDict, num) => { accDict[num] = accDict.TryGetValue(num, out var count) ? count + 1 : 1; return accDict; });

    public static bool ArraysAreEqual<T>(IList<T> arr1, IList<T> arr2, IEqualityComparer<T>? comparer = null)
    {
        if (arr1.Count != arr2.Count) { return false; }

        for (var i = 0; i < arr1.Count; i++)
        {
            if (null == arr1[i] && null == arr2[i]) { continue; }
            if (null == arr1[i] || (null != comparer ? !comparer.Equals(arr1[i], arr2[i]) : !arr1[i]!.Equals(arr2[i]))) { return false; }
        }

        return true;
    }

    public static bool ArraysAreEqualWithoutOrder<T>(IList<T> arr1, IList<T> arr2, IEqualityComparer<T>? comparer = null) where T : notnull
    {
        if (arr1.Count != arr2.Count) { return false; }
        var histogram = BuildArrayHistogram([.. arr2], comparer);

        for (var i = 0; i < arr1.Count; i++)
        {
            if (!histogram.TryGetValue(arr1[i], out var count) || 0 == count) { return false; }
            histogram[arr1[i]] = count - 1;
        }

        return true;
    }

    public static string ReadFromResources(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly!.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream!);
        return reader.ReadToEnd();
    }
}
