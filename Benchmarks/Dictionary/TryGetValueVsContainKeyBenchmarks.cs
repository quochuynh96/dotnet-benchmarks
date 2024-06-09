using BenchmarkDotNet.Attributes;

namespace dotnet_benchmarks.Benchmarks.Dictionary;

[MemoryDiagnoser]
public class TryGetValueVsContainKeyBenchmarks
{
    private const int _SIZE = 1000000;
    private const int ResultIndex = _SIZE - 100;
    
    private readonly Dictionary<Guid, int> _dictionary = new Dictionary<Guid, int>();
    private readonly Guid _key = Guid.NewGuid();
    
    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(2024);
        for (int i = 0; i < _SIZE; i++)
        {
            if (i == ResultIndex)
            {
                _dictionary.Add(_key, random.Next());
                continue;
            }
            _dictionary.Add(Guid.NewGuid(), random.Next());
        }
    }
    
    [Benchmark]
    public void TryGetValueTest()
    {
        _dictionary.TryGetValue(_key, out _);
    }
    
    [Benchmark]
    public void ContainsKeyTest()
    {
        if (_dictionary.ContainsKey(_key))
        {
            _ = _dictionary[_key];
        }
    }
}