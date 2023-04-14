using ConsoleEnvironment.Models;

namespace ConsoleEnvironment;

public static class Generator
{
    public static IList<T> GenerateArray<T>(MyRange lengthRange, Func<Random, T> producer)
    {
        var result = new List<T>();
        var random = new Random();
        var length = random.Next(lengthRange.Min, lengthRange.Max);

        while (length > 0)
        {
            result.Add(producer.Invoke(random));
            length -= 1;
        }

        return result;
    }
}