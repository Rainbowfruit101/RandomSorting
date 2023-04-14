namespace ConsoleEnvironment.Sorting.Impls;

public class InsertionSorting<T> : ISorting<T>
{
    private readonly Func<T, T, bool> _isGreater;

    public InsertionSorting(Func<T, T, bool> isGreater)
    {
        _isGreater = isGreater;
    }

    public IList<T> Run(IList<T> source)
    {
        var result = source.ToArray();
        
        for (int step = 1; step < result.Length; step++) {
            var key = result[step];
            int j = step - 1;
            
            while (j >= 0 && _isGreater(result[j], key)) {
                result[j + 1] = result[j];
                j -= 1;
            }
            
            result[j + 1] = key;
        }

        return result;
    }
}