using BenchmarkDotNet.Running;
using BenchMarksDatabase.Benchmarks;

BenchmarkRunner.Run<InsertBenchmarks>();
BenchmarkRunner.Run<QueryBenchmarks>();