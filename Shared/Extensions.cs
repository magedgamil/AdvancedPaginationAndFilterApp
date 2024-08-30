using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared;

public static class Extensions
{
    private static Random random = new Random();
    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        if (source == null)
            return;
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        Console.WriteLine();
        foreach (var item in source)
        {
            if (typeof(T).IsValueType)
                Console.Write($" {item} "); // 1, 2, 3
            else
                Console.WriteLine(item);
        }
    }

    public static IEnumerable<T> paginate<T>(this IEnumerable<T> source, int page = 1, int pageSize = 10)
    {
        if (source == null)
            throw new ArgumentNullException($"{nameof(source)}");

        if (page <= 0)
        {
            throw new ArgumentException($"{nameof(page)} must be greater than 0");
        }

        if (pageSize <= 0)
        {
            throw new ArgumentException($"{nameof(pageSize)} must be greater than 0");
        }

        if (!source.Any())
            return [];

        return source.Skip((page - 1) * pageSize).Take(pageSize);

    }
    public static IEnumerable<T> WhereWithPaginate<T>(this IEnumerable<T> source, Func<T, bool> predicate, int page = 1, int pageSize = 10)
    {
        if (source == null)
            throw new ArgumentNullException($"{nameof(source)}");

        if (predicate == null)
            throw new ArgumentNullException($"{nameof(predicate)}");

        var filtered = Enumerable.Where(source, predicate);

        return paginate(filtered, page, pageSize);

    }

}
