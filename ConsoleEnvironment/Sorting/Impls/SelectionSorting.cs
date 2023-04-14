namespace ConsoleEnvironment.Sorting.Impls;

public class SelectionSorting<T> : ISorting<T>
{
    private readonly Func<T, T, bool> _isGreater;

    public SelectionSorting(Func<T, T, bool> isGreater)
    {
        _isGreater = isGreater;
    }

    public IList<T> Run(IList<T> source)
    {
        var result = source.ToArray();

        for (var i = 0; i < result.Length - 1; i++)
        {
            var min = i;

            for (var j = i + 1; j < result.Length; j++)
            {
                if (_isGreater(result[min], result[j]))
                {
                    min = j;
                }
            }

            result.Swap(i, min);
        }
        
        return result;
    }
}