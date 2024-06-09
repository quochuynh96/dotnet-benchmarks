using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.LinQ;

[MemoryDiagnoser]
public class SelectManyVsTwoLoopBenchmarks
{
    private const int Size = 1000;
    private readonly List<ParentClass> _parents = [];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < Size; i++)
        {
            _parents.Add(new ParentClass
            {
                Childrens =
                [
                    new ChildClass
                    {
                        Name = Guid.NewGuid().ToString()
                    },

                    new ChildClass
                    {
                        Name = Guid.NewGuid().ToString()
                    }
                ]
            });
        }
    }

    [Benchmark]
    public void SelectManyTest()
    {
        _ = _parents.SelectMany(x => x.Childrens).ToList();
    }

    [Benchmark]
    public void TwoLoopTest()
    {
        var result = new List<ChildClass>();
        foreach (var parent in _parents)
        {
            foreach (var child in parent.Childrens)
            {
                result.Add(child);
            }
        }
    }

    public class ParentClass
    {
        public List<ChildClass> Childrens { get; set; }
    }

    public class ChildClass
    {
        public string Name { get; set; }
    }
}