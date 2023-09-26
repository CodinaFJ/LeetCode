```

BenchmarkDotNet v0.13.8, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i5-10500H CPU 2.50GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.203
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2


```
| Method                                            | Mean       | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
| MergeAlternately                                  | 1,541.3 ns | 19.45 ns | 16.24 ns | 1.8597 |   11672 B |
| MergeAlternately_DoubleLoopComparison_NoMax_NoLen |   235.1 ns |  4.55 ns |  4.03 ns | 0.1183 |     744 B |
| MergeAlternately_DoubleLoopComparison_NoMax       |   217.2 ns |  4.39 ns |  7.57 ns | 0.1185 |     744 B |
| MergeAlternately_OneComparison_NoMathMax          |   233.1 ns |  2.71 ns |  2.40 ns | 0.1185 |     744 B |
| MergeAlternately_OneComparison_MathMax            |   234.9 ns |  1.57 ns |  1.47 ns | 0.1183 |     744 B |
