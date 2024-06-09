using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks;

[MemoryDiagnoser]
public class StopwatchBenchmarks
{
    [Benchmark]
    public TimeSpan StartNew()
    {
        var watch = Stopwatch.StartNew();

        DoWork();

        return watch.Elapsed;
    }

    [Benchmark]
    public TimeSpan GetTimestamp()
    {
        var start = Stopwatch.GetTimestamp();

        DoWork();

        return Stopwatch.GetElapsedTime(start);
    }

    private void DoWork()
    {

    }
}
