using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks;

[MemoryDiagnoser]
public class ArrayFirstLastBenchmarks
{
    private const int _SIZE = 1_000_000;
    private readonly int[] _array = new int[_SIZE];

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);
        for (int i = 0; i < _SIZE; i++)
        {
            _array[1] = random.Next();
        }
    }
    
    [Benchmark]
    public void FirstUsingLinq()
    {
        _ = _array.First();
    }
    
    [Benchmark]
    public void FirstUsingIndex()
    {
        _ = _array[0];
    }
    
    [Benchmark]
    public void LastUsingLinq()
    {
        _ = _array.Last();
    }
    
    [Benchmark]
    public void LastUsingIndex()
    {
        _ = _array[^1];
    }
}