using BenchmarkDotNet.Running;
using dotnet_benchmarks.Benchmarks;

var summary = BenchmarkRunner.Run<ArrayFirstLastBenchmarks>();