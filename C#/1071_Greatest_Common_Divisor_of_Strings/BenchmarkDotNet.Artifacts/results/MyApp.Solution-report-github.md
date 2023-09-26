```

BenchmarkDotNet v0.13.8, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i5-10500H CPU 2.50GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 6.0.203
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2


```
| Method                 | Mean       | Error     | StdDev    | Gen0   | Allocated |
|----------------------- |-----------:|----------:|----------:|-------:|----------:|
| GcdOfStrings_attempt   |   979.8 ns |  16.69 ns |  13.03 ns | 0.2670 |    1680 B |
| GcdOfStrings_recursive | 5,412.6 ns | 107.93 ns | 119.97 ns | 0.0458 |     328 B |
| GcdOfStrings_minMemory |   219.4 ns |   1.50 ns |   1.33 ns | 0.1121 |     704 B |
