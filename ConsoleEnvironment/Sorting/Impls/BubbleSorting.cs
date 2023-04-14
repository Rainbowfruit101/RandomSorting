namespace ConsoleEnvironment.Sorting.Impls;

public class BubbleSorting<T> : ISorting<T>
{
    private readonly Func<T, T, bool> _isGreater;

    public BubbleSorting(Func<T,T, bool> isGreater)
    {
        _isGreater = isGreater;
    }
    
    public IList<T> Run(IList<T> source)
    {
        var result = source.ToArray();

        for (var i = 0; i < result.Length; i++)
        {
            for (var j = i + 1; j < result.Length; j++)
            {
                if (_isGreater(result[i], result[j]))
                {
                    result.Swap(i, j);
                }
            }
        }

        return result;
    }
}