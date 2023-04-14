namespace ConsoleEnvironment.Sorting;

public static class ListExt
{
    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        (list[i], list[j]) = (list[j], list[i]);
    }

    public static T ChooseOne<T>(this IList<T> list)
    {
        var random = new Random();
        var n = random.Next(0, list.Count);

        return list[n];
    }
    
    public static void WriteTo<T>(this IList<T> source, TextWriter tw) => tw.WriteLine($"[{string.Join(", ", source)}]");

    public static bool IsSorted<T>(this IList<T> source, Func<T, T, bool> isGreater)
    {
        for (var i = 0; i < source.Count - 1; i++)
        {
            if (isGreater.Invoke(source[i], source[i + 1]))
            {
                return false;
            }
        }

        return true;
    }
}