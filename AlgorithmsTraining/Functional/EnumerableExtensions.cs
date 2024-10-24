namespace AlgorithmsTraining.Functional;

public static class EnumerableExtensions
{
    public static TState Aggregate<TState, TItem>(
		this IEnumerable<TItem> items, 
		TState seed, 
		Func<TState, TItem, TState> func,
		Func<TState, bool>? stopEnumeration = null)
    {
		TState result = seed;

        foreach (var item in items)
        {
            result = func(result, item);
            if (null != stopEnumeration && stopEnumeration(result)) return result;
        }

        return result;
    }
}
