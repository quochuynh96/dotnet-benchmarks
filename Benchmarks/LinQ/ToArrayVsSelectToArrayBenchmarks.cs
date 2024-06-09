using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.LinQ;

[MemoryDiagnoser]
public class ToArrayVsSelectToArrayBenchmarks
{
    private const int SIZE = 1_000_000;
    private static readonly int[] _array = new int[SIZE];

    static ToArrayVsSelectToArrayBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < SIZE; i++)
        {
            _array[i] = random.Next();
        }
    }

    [Benchmark]
    public void Loop()
    {
        var newArray = new int[SIZE];

        for (int i = 0; i < SIZE; i++)
        {
            newArray[i] = _array[i];
        }
    }

    [Benchmark]
    public void LinqSelectToArray()
    {
        var newArray = _array.Select(x => x).ToArray();
    }

    [Benchmark]
    public void LinqToArray()
    {
        var newArray = _array.ToArray();
    }
}
