using BenchmarkDotNet.Running;
using dotnet_benchmarks.Benchmarks.LinQ;

var summary = BenchmarkRunner.Run<SelectManyVsTwoLoopBenchmarks>();