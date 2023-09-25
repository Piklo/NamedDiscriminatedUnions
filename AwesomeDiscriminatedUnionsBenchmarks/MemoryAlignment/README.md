The point of those benchmarks is to check whether there are performance differences caused by misaligned fields.

Results inconclusive. Need more benchmarks or more specific cases.

`dotnet run -c release`

```
// * Summary *

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


| Method                             | Mean     | Error     | StdDev    |
|----------------------------------- |---------:|----------:|----------:|
| MemoryAligned1Int                  | 3.137 ns | 0.0251 ns | 0.0210 ns |
| MemoryMisaligned1Int               | 2.691 ns | 0.0147 ns | 0.0138 ns |
| MemoryAligned2Int                  | 3.833 ns | 0.0214 ns | 0.0200 ns |
| MemoryMisaligned2Int               | 4.240 ns | 0.0475 ns | 0.0444 ns |
| MemoryAligned1IntNoOptimization    | 3.691 ns | 0.0864 ns | 0.0808 ns |
| MemoryMisaligned1IntNoOptimization | 3.423 ns | 0.0483 ns | 0.0428 ns |
| MemoryAligned2IntNoOptimization    | 4.553 ns | 0.0218 ns | 0.0193 ns |
| MemoryMisaligned2IntNoOptimization | 4.811 ns | 0.0586 ns | 0.0520 ns |

// * Hints *
Outliers
  MemoryAlignmentBenchmarks.MemoryAligned1Int: Default                  -> 2 outliers were removed (4.78 ns, 4.86 ns)
  MemoryAlignmentBenchmarks.MemoryMisaligned1IntNoOptimization: Default -> 1 outlier  was  removed (5.43 ns)
  MemoryAlignmentBenchmarks.MemoryAligned2IntNoOptimization: Default    -> 1 outlier  was  removed (6.30 ns)
  MemoryAlignmentBenchmarks.MemoryMisaligned2IntNoOptimization: Default -> 1 outlier  was  removed (6.51 ns)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  1 ns   : 1 Nanosecond (0.000000001 sec)

// ***** BenchmarkRunner: End *****
Run time: 00:03:03 (183.75 sec), executed benchmarks: 8

Global total time: 00:03:22 (202.29 sec), executed benchmarks: 8


// * Detailed results *
MemoryAlignmentBenchmarks.MemoryAligned1Int: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 3.137 ns, StdErr = 0.006 ns (0.19%), N = 13, StdDev = 0.021 ns
Min = 3.120 ns, Q1 = 3.124 ns, Median = 3.128 ns, Q3 = 3.136 ns, Max = 3.193 ns
IQR = 0.012 ns, LowerFence = 3.105 ns, UpperFence = 3.155 ns
ConfidenceInterval = [3.112 ns; 3.162 ns] (CI 99.9%), Margin = 0.025 ns (0.80% of Mean)
Skewness = 1.5, Kurtosis = 4.16, MValue = 2
-------------------- Histogram --------------------
[3.109 ns ; 3.204 ns) | @@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryMisaligned1Int: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 2.691 ns, StdErr = 0.004 ns (0.13%), N = 15, StdDev = 0.014 ns
Min = 2.665 ns, Q1 = 2.685 ns, Median = 2.691 ns, Q3 = 2.698 ns, Max = 2.717 ns
IQR = 0.013 ns, LowerFence = 2.665 ns, UpperFence = 2.718 ns
ConfidenceInterval = [2.677 ns; 2.706 ns] (CI 99.9%), Margin = 0.015 ns (0.55% of Mean)
Skewness = -0.07, Kurtosis = 2.39, MValue = 2
-------------------- Histogram --------------------
[2.661 ns ; 2.724 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryAligned2Int: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 3.833 ns, StdErr = 0.005 ns (0.13%), N = 15, StdDev = 0.020 ns
Min = 3.805 ns, Q1 = 3.818 ns, Median = 3.832 ns, Q3 = 3.850 ns, Max = 3.875 ns
IQR = 0.032 ns, LowerFence = 3.770 ns, UpperFence = 3.898 ns
ConfidenceInterval = [3.812 ns; 3.855 ns] (CI 99.9%), Margin = 0.021 ns (0.56% of Mean)
Skewness = 0.42, Kurtosis = 1.96, MValue = 2
-------------------- Histogram --------------------
[3.795 ns ; 3.885 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryMisaligned2Int: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.240 ns, StdErr = 0.011 ns (0.27%), N = 15, StdDev = 0.044 ns
Min = 4.164 ns, Q1 = 4.202 ns, Median = 4.241 ns, Q3 = 4.273 ns, Max = 4.316 ns
IQR = 0.070 ns, LowerFence = 4.097 ns, UpperFence = 4.378 ns
ConfidenceInterval = [4.192 ns; 4.287 ns] (CI 99.9%), Margin = 0.048 ns (1.12% of Mean)
Skewness = -0.01, Kurtosis = 1.65, MValue = 2
-------------------- Histogram --------------------
[4.140 ns ; 4.320 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryAligned1IntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 3.691 ns, StdErr = 0.021 ns (0.57%), N = 15, StdDev = 0.081 ns
Min = 3.588 ns, Q1 = 3.620 ns, Median = 3.682 ns, Q3 = 3.740 ns, Max = 3.871 ns
IQR = 0.120 ns, LowerFence = 3.440 ns, UpperFence = 3.921 ns
ConfidenceInterval = [3.604 ns; 3.777 ns] (CI 99.9%), Margin = 0.086 ns (2.34% of Mean)
Skewness = 0.67, Kurtosis = 2.33, MValue = 2
-------------------- Histogram --------------------
[3.545 ns ; 3.699 ns) | @@@@@@@@@@
[3.699 ns ; 3.789 ns) | @@@@
[3.789 ns ; 3.915 ns) | @
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryMisaligned1IntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 3.423 ns, StdErr = 0.011 ns (0.33%), N = 14, StdDev = 0.043 ns
Min = 3.381 ns, Q1 = 3.389 ns, Median = 3.397 ns, Q3 = 3.460 ns, Max = 3.503 ns
IQR = 0.071 ns, LowerFence = 3.283 ns, UpperFence = 3.566 ns
ConfidenceInterval = [3.375 ns; 3.471 ns] (CI 99.9%), Margin = 0.048 ns (1.41% of Mean)
Skewness = 0.53, Kurtosis = 1.53, MValue = 2
-------------------- Histogram --------------------
[3.358 ns ; 3.527 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryAligned2IntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.553 ns, StdErr = 0.005 ns (0.11%), N = 14, StdDev = 0.019 ns
Min = 4.533 ns, Q1 = 4.539 ns, Median = 4.546 ns, Q3 = 4.564 ns, Max = 4.591 ns
IQR = 0.025 ns, LowerFence = 4.501 ns, UpperFence = 4.601 ns
ConfidenceInterval = [4.531 ns; 4.575 ns] (CI 99.9%), Margin = 0.022 ns (0.48% of Mean)
Skewness = 0.73, Kurtosis = 1.95, MValue = 2
-------------------- Histogram --------------------
[4.523 ns ; 4.602 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentBenchmarks.MemoryMisaligned2IntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.811 ns, StdErr = 0.014 ns (0.29%), N = 14, StdDev = 0.052 ns
Min = 4.760 ns, Q1 = 4.777 ns, Median = 4.781 ns, Q3 = 4.844 ns, Max = 4.941 ns
IQR = 0.067 ns, LowerFence = 4.676 ns, UpperFence = 4.944 ns
ConfidenceInterval = [4.752 ns; 4.869 ns] (CI 99.9%), Margin = 0.059 ns (1.22% of Mean)
Skewness = 1.1, Kurtosis = 3.18, MValue = 2
-------------------- Histogram --------------------
[4.739 ns ; 4.969 ns) | @@@@@@@@@@@@@@
---------------------------------------------------
```