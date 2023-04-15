namespace ConsoleEnvironment.Sorting.Impls;

public class ShakerSorting<T> : ISorting<T>
{
    private readonly Func<T, T, bool> _isGreater;

    public ShakerSorting(Func<T, T, bool> isGreater)
    {
        _isGreater = isGreater;
    }

    public IList<T> Run(IList<T> source)
    {
        var result = source.ToArray();
        var left = 0;
        var right = result.Length - 1;

        while (left < right)
        {
            for (var i = left; i < right; i++)
            {
                if (_isGreater(result[i], result[i + 1]))
                    result.Swap(i, i + 1);
            }

            right--;

            for (var i = right; i > left; i--)
            {
                if (_isGreater(result[i - 1], result[i]))
                    result.Swap(i - 1, i);
            }

            left++;
        }

        return result;
    }
}