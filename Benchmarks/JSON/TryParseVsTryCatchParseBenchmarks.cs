using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.JSON;

[MemoryDiagnoser]
public class TryParseVsTryCatchParseBenchmarks
{
    [Params("123", "abc")]
    public string Input { get; set; }

    [Benchmark]
    public void TryParse()
    {
        if(int.TryParse(Input, out int result))
        {
        }    
    }

    [Benchmark]
    public void TryCatchParse()
    {
        try
        {
            int.Parse(Input);
        }
        catch
        {
        }
    }
}
