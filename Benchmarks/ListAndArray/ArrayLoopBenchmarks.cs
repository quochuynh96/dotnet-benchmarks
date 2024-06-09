using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.ListAndArray;

[MemoryDiagnoser]
public class ArrayLoopBenchmarks
{
    private const int Size = 1_000_000;
    private static readonly string[] _array = new string[Size];

    static ArrayLoopBenchmarks()
    {
        var random = new Random(2024);

        for (int i = 0; i < Size; i++)
        {
            _array[i] = random.Next().ToString();
        }
    }

    [Benchmark]
    public string For()
    {
        var array = _array;
        var result = string.Empty;

        for (int i = 0; i < array.Length; i++)
        {
            result = array[i];
        }

        return result;
    }

    [Benchmark]
    public string Foreach()
    {
        var array = _array;
        var result = string.Empty;

        foreach (var item in array)
        {
            result = item;
        }

        return result;
    }

    [Benchmark]
    public string ForEachMethod()
    {
        var array = _array;
        var result = string.Empty;

        System.Array.ForEach(array, item => result = item);

        return result;
    }

    [Benchmark]
    public string While()
    {
        var array = _array;
        var result = string.Empty;
        var i = 0;

        while (i < array.Length)
        {
            result = array[i];
            i++;
        }

        return result;
    }

    [Benchmark]
    public string DoWhile()
    {
        var array = _array;
        var result = string.Empty;
        var i = 0;

        do
        {
            result = array[i];
            i++;
        }
        while (i < array.Length);

        return result;
    }

    [Benchmark]
    public string GoTo()
    {
        var array = _array;
        var result = string.Empty;
        var i = 0;

    Start:
        if (i < array.Length)
        {
            result = array[i];
            i++;
            goto Start;
        }

        return result;
    }

    [Benchmark]
    public string Span()
    {
        var result = string.Empty;
        var span = _array.AsSpan();

        for (int i = 0; i < span.Length; i++)
        {
            result = span[i];
        }

        return result;
    }
}
