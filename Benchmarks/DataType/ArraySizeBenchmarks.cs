using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.DataType;

[WarmupCount(0)]
[IterationCount(1)]
[InvocationCount(1)]
[MemoryDiagnoser]
public class ArraySizeBenchmarks
{
    [Benchmark]
    public void Bool()
    {
        var x = new bool[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void Int()
    {
        var x = new int[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void Float()
    {
        var x = new float[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void Long()
    {
        var x = new long[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void Decimal()
    {
        var x = new decimal[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void String()
    {
        var x = new string[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void Struct()
    {
        var x = new PersonStruct[System.Array.MaxLength / 2];
    }

    [Benchmark]
    public void Class()
    {
        var x = new PersonClass[System.Array.MaxLength / 2];
    }

    private struct PersonStruct
    {
        public int Int { get; set; }

        public decimal Decimal { get; set; }
    }

    private class PersonClass
    {
        public int Int { get; set; }

        public decimal Decimal { get; set; }
    }
}
