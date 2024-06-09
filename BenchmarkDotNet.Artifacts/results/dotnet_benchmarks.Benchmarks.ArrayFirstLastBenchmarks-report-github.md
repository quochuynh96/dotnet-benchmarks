```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M2, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD


```
| Method          | Mean       | Error     | StdDev    | Allocated |
|---------------- |-----------:|----------:|----------:|----------:|
| FirstUsingLinq  | 10.6671 ns | 0.1542 ns | 0.1443 ns |         - |
| FirstUsingIndex |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| LastUsingLinq   | 10.8533 ns | 0.2349 ns | 0.2413 ns |         - |
| LastUsingIndex  |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
