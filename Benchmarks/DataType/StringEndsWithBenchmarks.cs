using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.DataType;

[MemoryDiagnoser]
public class StringEndsWithBenchmarks
{
    [Params("abc", "/abc", "abc/")]
    public string Input { get; set; }

    [Benchmark]
    public void EndsWithString()
    {
        Input.EndsWith("/");
    }

    [Benchmark]
    public void EndsWithChar()
    {
        Input.EndsWith('/');
    }
}
