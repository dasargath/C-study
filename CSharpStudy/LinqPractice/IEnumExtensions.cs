namespace LinqPractice;

public static class IEnumExtensions
{
    
    public static IEnumerable<T> Top<T, TKey>(this IEnumerable<T> source, int percent, Func<T,TKey> keySelector)
    {
        if (percent < 1 || percent > 100)
        {
            throw new ArgumentException("Процент должен быть между 1 и 100.", nameof(percent));
        }

        int count = source.Count();
        if (count == 0)
        {
            return Enumerable.Empty<T>();
        }
        
        int topCount = (int)Math.Ceiling(count * ((double)percent / 100.0));
        
        return source.OrderByDescending(keySelector).Take(topCount);
    }

    public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int percent)
    {
        return source.Top(percent, element => element);
    }
}
