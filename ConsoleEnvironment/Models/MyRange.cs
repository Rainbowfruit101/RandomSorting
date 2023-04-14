namespace ConsoleEnvironment.Models;

public class MyRange
{
    public int Min { get; }
    public int Max { get; }

    public MyRange(int min, int max)
    {
        Min = min;
        Max = max;
    }
}