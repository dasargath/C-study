namespace LinqPractice;

public static class IEnumExtensions
{
    public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int percent)
    {
        if (percent < 1 || percent > 100)
        {
            throw new ArgumentException("Процент должен быть между 1 и 100. ", nameof(percent));
        }

        int count = source.Count();
        int topCount = (int)Math.Ceiling(count*(percent/100.0));
        
        return source.OrderByDescending(item => item).Take(topCount);
    }

    public static IEnumerable<T> Top<T, Tkey>(this IEnumerable<T> source, int percent, Func<T, Tkey> keySelector)
    {
        if (percent < 1 || percent > 100)
        {
            throw new ArgumentException("Процент должен быть между 1 и 100. ", nameof(percent));
        }

        int count = source.Count();
        int topCount = (int)Math.Ceiling(count*(percent/100.0));
        
        return source.OrderByDescending(keySelector).Take(topCount);
    }
}