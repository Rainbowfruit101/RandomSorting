namespace ConsoleEnvironment.Sorting;

public interface ISorting<T>
{
    IList<T> Run(IList<T> source);
}