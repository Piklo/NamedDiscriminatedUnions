The point of those benchmarks was to better further test how natural alignment affects performance (reading)

`dotnet run -c release -- -m`
```
// * Summary *

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


| Method              | Categories    | Mean          | Error      | StdDev     | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |-------------- |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|----------:|------------:|
| IntBaseline         | construct     |     3.9302 ns |  0.0157 ns |  0.0131 ns |     3.9300 ns |  1.00 |    0.00 |      - |         - |          NA |
| Int0                | construct     |     4.0133 ns |  0.0915 ns |  0.0856 ns |     3.9950 ns |  1.02 |    0.02 |      - |         - |          NA |
| Int1                | construct     |     4.1296 ns |  0.0299 ns |  0.0280 ns |     4.1276 ns |  1.05 |    0.01 |      - |         - |          NA |
| Int2                | construct     |     4.1240 ns |  0.0217 ns |  0.0192 ns |     4.1220 ns |  1.05 |    0.01 |      - |         - |          NA |
| Int3                | construct     |     4.1871 ns |  0.0619 ns |  0.0579 ns |     4.1863 ns |  1.07 |    0.02 |      - |         - |          NA |
| Int4                | construct     |     4.0829 ns |  0.0481 ns |  0.0450 ns |     4.0783 ns |  1.04 |    0.01 |      - |         - |          NA |
|                     |               |               |            |            |               |       |         |        |           |             |
| IntBaselineMany     | constructMany |   784.3025 ns | 10.6228 ns |  9.4168 ns |   780.8976 ns |  1.00 |    0.00 | 1.2779 |    8024 B |        1.00 |
| Int0Many            | constructMany | 4,537.8936 ns | 25.4209 ns | 23.7787 ns | 4,536.7741 ns |  5.79 |    0.07 | 1.2741 |    8024 B |        1.00 |
| Int1Many            | constructMany | 4,552.2814 ns | 29.0054 ns | 27.1317 ns | 4,550.8354 ns |  5.80 |    0.09 | 1.2741 |    8024 B |        1.00 |
| Int2Many            | constructMany | 4,565.9481 ns | 38.6085 ns | 36.1144 ns | 4,565.1489 ns |  5.83 |    0.11 | 1.2741 |    8024 B |        1.00 |
| Int3Many            | constructMany | 4,564.7724 ns | 47.2697 ns | 41.9034 ns | 4,558.4351 ns |  5.82 |    0.09 | 1.2741 |    8024 B |        1.00 |
| Int4Many            | constructMany | 4,538.8728 ns | 18.4346 ns | 17.2437 ns | 4,539.4226 ns |  5.79 |    0.08 | 1.2741 |    8024 B |        1.00 |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadInt0            | read          |     0.0014 ns |  0.0032 ns |  0.0028 ns |     0.0000 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadInt1            | read          |     0.0070 ns |  0.0087 ns |  0.0081 ns |     0.0051 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadInt2            | read          |     0.0002 ns |  0.0006 ns |  0.0005 ns |     0.0000 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadInt3            | read          |     0.0070 ns |  0.0121 ns |  0.0113 ns |     0.0000 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadInt4            | read          |     0.0047 ns |  0.0084 ns |  0.0078 ns |     0.0000 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadIntBaseline     | read          |     0.8055 ns |  0.0167 ns |  0.0148 ns |     0.8055 ns |  1.00 |    0.00 |      - |         - |          NA |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadManyInt0        | readMany      |   358.1960 ns |  1.9931 ns |  1.7668 ns |   358.1074 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadManyInt1        | readMany      |   358.7079 ns |  1.9886 ns |  1.7628 ns |   359.1459 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadManyInt2        | readMany      |   357.8492 ns |  1.0041 ns |  0.8385 ns |   357.7797 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadManyInt3        | readMany      |   357.1627 ns |  1.6708 ns |  1.3044 ns |   357.2382 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadManyInt4        | readMany      |   369.8157 ns |  2.5656 ns |  2.3999 ns |   369.5570 ns |     ? |       ? |      - |         - |           ? |
|                     |               |               |            |            |               |       |         |        |           |             |
| ReadManyIntBaseline | readMany      |   381.3083 ns |  7.4935 ns |  8.0180 ns |   382.5923 ns |  1.00 |    0.00 |      - |         - |          NA |

// * Warnings *
ZeroMeasurement
  MemoryAlignmentReadBenchmarks.ReadInt0: Default -> The method duration is indistinguishable from the empty method duration
  MemoryAlignmentReadBenchmarks.ReadInt1: Default -> The method duration is indistinguishable from the empty method duration
  MemoryAlignmentReadBenchmarks.ReadInt2: Default -> The method duration is indistinguishable from the empty method duration
  MemoryAlignmentReadBenchmarks.ReadInt3: Default -> The method duration is indistinguishable from the empty method duration
  MemoryAlignmentReadBenchmarks.ReadInt4: Default -> The method duration is indistinguishable from the empty method duration
BaselineCustomAnalyzer
  Summary -> A question mark '?' symbol indicates that it was not possible to compute the (Ratio, RatioSD, Alloc Ratio) column(s) because the baseline value is too close to zero.

// * Hints *
HideColumnsAnalyser
  Summary -> Hidden columns: obj, array
Outliers
  MemoryAlignmentReadBenchmarks.IntBaseline: Default     -> 2 outliers were removed (5.56 ns, 5.56 ns)
  MemoryAlignmentReadBenchmarks.Int2: Default            -> 1 outlier  was  removed (5.71 ns)
  MemoryAlignmentReadBenchmarks.IntBaselineMany: Default -> 1 outlier  was  removed (816.86 ns)
  MemoryAlignmentReadBenchmarks.Int3Many: Default        -> 1 outlier  was  removed (4.76 us)
  MemoryAlignmentReadBenchmarks.ReadInt0: Default        -> 1 outlier  was  removed (1.56 ns)
  MemoryAlignmentReadBenchmarks.ReadInt2: Default        -> 1 outlier  was  removed (1.51 ns)
  MemoryAlignmentReadBenchmarks.ReadIntBaseline: Default -> 1 outlier  was  removed (4.78 ns)
  MemoryAlignmentReadBenchmarks.ReadManyInt0: Default    -> 1 outlier  was  removed (369.68 ns)
  MemoryAlignmentReadBenchmarks.ReadManyInt1: Default    -> 1 outlier  was  removed (368.94 ns)
  MemoryAlignmentReadBenchmarks.ReadManyInt2: Default    -> 2 outliers were removed (366.67 ns, 370.19 ns)
  MemoryAlignmentReadBenchmarks.ReadManyInt3: Default    -> 3 outliers were removed (367.99 ns..371.55 ns)

// * Legends *
  Categories  : All categories of the corresponded method, class, and assembly
  Mean        : Arithmetic mean of all measurements
  Error       : Half of 99.9% confidence interval
  StdDev      : Standard deviation of all measurements
  Median      : Value separating the higher half of all measurements (50th percentile)
  Ratio       : Mean of the ratio distribution ([Current]/[Baseline])
  RatioSD     : Standard deviation of the ratio distribution ([Current]/[Baseline])
  Gen0        : GC Generation 0 collects per 1000 operations
  Allocated   : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  Alloc Ratio : Allocated memory ratio distribution ([Current]/[Baseline])
  1 ns        : 1 Nanosecond (0.000000001 sec)

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:10:02 (602.73 sec), executed benchmarks: 24

Global total time: 00:10:22 (622.71 sec), executed benchmarks: 24

// * Detailed results *
MemoryAlignmentReadBenchmarks.IntBaseline: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 3.930 ns, StdErr = 0.004 ns (0.09%), N = 13, StdDev = 0.013 ns
Min = 3.912 ns, Q1 = 3.925 ns, Median = 3.930 ns, Q3 = 3.933 ns, Max = 3.961 ns
IQR = 0.008 ns, LowerFence = 3.913 ns, UpperFence = 3.944 ns
ConfidenceInterval = [3.915 ns; 3.946 ns] (CI 99.9%), Margin = 0.016 ns (0.40% of Mean)
Skewness = 0.72, Kurtosis = 3.13, MValue = 2
-------------------- Histogram --------------------
[3.904 ns ; 3.969 ns) | @@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int0: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.013 ns, StdErr = 0.022 ns (0.55%), N = 15, StdDev = 0.086 ns
Min = 3.876 ns, Q1 = 3.949 ns, Median = 3.995 ns, Q3 = 4.072 ns, Max = 4.198 ns
IQR = 0.123 ns, LowerFence = 3.764 ns, UpperFence = 4.257 ns
ConfidenceInterval = [3.922 ns; 4.105 ns] (CI 99.9%), Margin = 0.091 ns (2.28% of Mean)
Skewness = 0.52, Kurtosis = 2.33, MValue = 2
-------------------- Histogram --------------------
[3.830 ns ; 3.937 ns) | @
[3.937 ns ; 4.028 ns) | @@@@@@@@@
[4.028 ns ; 4.141 ns) | @@@@
[4.141 ns ; 4.244 ns) | @
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int1: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.130 ns, StdErr = 0.007 ns (0.17%), N = 15, StdDev = 0.028 ns
Min = 4.099 ns, Q1 = 4.107 ns, Median = 4.128 ns, Q3 = 4.147 ns, Max = 4.184 ns
IQR = 0.041 ns, LowerFence = 4.046 ns, UpperFence = 4.208 ns
ConfidenceInterval = [4.100 ns; 4.159 ns] (CI 99.9%), Margin = 0.030 ns (0.72% of Mean)
Skewness = 0.53, Kurtosis = 1.88, MValue = 2
-------------------- Histogram --------------------
[4.084 ns ; 4.199 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int2: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.124 ns, StdErr = 0.005 ns (0.12%), N = 14, StdDev = 0.019 ns
Min = 4.099 ns, Q1 = 4.111 ns, Median = 4.122 ns, Q3 = 4.131 ns, Max = 4.165 ns
IQR = 0.020 ns, LowerFence = 4.081 ns, UpperFence = 4.160 ns
ConfidenceInterval = [4.102 ns; 4.146 ns] (CI 99.9%), Margin = 0.022 ns (0.53% of Mean)
Skewness = 0.72, Kurtosis = 2.37, MValue = 2
-------------------- Histogram --------------------
[4.088 ns ; 4.175 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int3: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.187 ns, StdErr = 0.015 ns (0.36%), N = 15, StdDev = 0.058 ns
Min = 4.090 ns, Q1 = 4.162 ns, Median = 4.186 ns, Q3 = 4.225 ns, Max = 4.305 ns
IQR = 0.063 ns, LowerFence = 4.068 ns, UpperFence = 4.320 ns
ConfidenceInterval = [4.125 ns; 4.249 ns] (CI 99.9%), Margin = 0.062 ns (1.48% of Mean)
Skewness = -0.04, Kurtosis = 2.36, MValue = 2
-------------------- Histogram --------------------
[4.060 ns ; 4.144 ns) | @@@
[4.144 ns ; 4.336 ns) | @@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int4: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.083 ns, StdErr = 0.012 ns (0.28%), N = 15, StdDev = 0.045 ns
Min = 4.017 ns, Q1 = 4.054 ns, Median = 4.078 ns, Q3 = 4.113 ns, Max = 4.181 ns
IQR = 0.058 ns, LowerFence = 3.966 ns, UpperFence = 4.200 ns
ConfidenceInterval = [4.035 ns; 4.131 ns] (CI 99.9%), Margin = 0.048 ns (1.18% of Mean)
Skewness = 0.52, Kurtosis = 2.31, MValue = 2
-------------------- Histogram --------------------
[3.993 ns ; 4.106 ns) | @@@@@@@@@@@
[4.106 ns ; 4.205 ns) | @@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.IntBaselineMany: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 784.303 ns, StdErr = 2.517 ns (0.32%), N = 14, StdDev = 9.417 ns
Min = 773.063 ns, Q1 = 779.566 ns, Median = 780.898 ns, Q3 = 788.870 ns, Max = 808.076 ns
IQR = 9.304 ns, LowerFence = 765.611 ns, UpperFence = 802.825 ns
ConfidenceInterval = [773.680 ns; 794.925 ns] (CI 99.9%), Margin = 10.623 ns (1.35% of Mean)
Skewness = 1.07, Kurtosis = 3.36, MValue = 2
-------------------- Histogram --------------------
[770.936 ns ; 813.204 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int0Many: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.538 us, StdErr = 0.006 us (0.14%), N = 15, StdDev = 0.024 us
Min = 4.507 us, Q1 = 4.520 us, Median = 4.537 us, Q3 = 4.546 us, Max = 4.582 us
IQR = 0.026 us, LowerFence = 4.481 us, UpperFence = 4.586 us
ConfidenceInterval = [4.512 us; 4.563 us] (CI 99.9%), Margin = 0.025 us (0.56% of Mean)
Skewness = 0.42, Kurtosis = 2.01, MValue = 2
-------------------- Histogram --------------------
[4.494 us ; 4.583 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int1Many: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.552 us, StdErr = 0.007 us (0.15%), N = 15, StdDev = 0.027 us
Min = 4.515 us, Q1 = 4.531 us, Median = 4.551 us, Q3 = 4.569 us, Max = 4.613 us
IQR = 0.038 us, LowerFence = 4.474 us, UpperFence = 4.626 us
ConfidenceInterval = [4.523 us; 4.581 us] (CI 99.9%), Margin = 0.029 us (0.64% of Mean)
Skewness = 0.49, Kurtosis = 2.36, MValue = 2
-------------------- Histogram --------------------
[4.500 us ; 4.628 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int2Many: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.566 us, StdErr = 0.009 us (0.20%), N = 15, StdDev = 0.036 us
Min = 4.503 us, Q1 = 4.532 us, Median = 4.565 us, Q3 = 4.594 us, Max = 4.619 us
IQR = 0.062 us, LowerFence = 4.439 us, UpperFence = 4.687 us
ConfidenceInterval = [4.527 us; 4.605 us] (CI 99.9%), Margin = 0.039 us (0.85% of Mean)
Skewness = -0.11, Kurtosis = 1.55, MValue = 2
-------------------- Histogram --------------------
[4.501 us ; 4.638 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int3Many: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.565 us, StdErr = 0.011 us (0.25%), N = 14, StdDev = 0.042 us
Min = 4.498 us, Q1 = 4.536 us, Median = 4.558 us, Q3 = 4.598 us, Max = 4.646 us
IQR = 0.062 us, LowerFence = 4.443 us, UpperFence = 4.691 us
ConfidenceInterval = [4.518 us; 4.612 us] (CI 99.9%), Margin = 0.047 us (1.04% of Mean)
Skewness = 0.24, Kurtosis = 1.9, MValue = 2
-------------------- Histogram --------------------
[4.484 us ; 4.668 us) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.Int4Many: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.539 us, StdErr = 0.004 us (0.10%), N = 15, StdDev = 0.017 us
Min = 4.515 us, Q1 = 4.525 us, Median = 4.539 us, Q3 = 4.551 us, Max = 4.575 us
IQR = 0.027 us, LowerFence = 4.485 us, UpperFence = 4.591 us
ConfidenceInterval = [4.520 us; 4.557 us] (CI 99.9%), Margin = 0.018 us (0.41% of Mean)
Skewness = 0.33, Kurtosis = 2.04, MValue = 2
-------------------- Histogram --------------------
[4.506 us ; 4.584 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadInt0: DefaultJob [obj=Aweso(...).Int0 [61]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.001 ns, StdErr = 0.001 ns (54.41%), N = 14, StdDev = 0.003 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.000 ns, Max = 0.008 ns
IQR = 0.000 ns, LowerFence = 0.000 ns, UpperFence = 0.000 ns
ConfidenceInterval = [-0.002 ns; 0.005 ns] (CI 99.9%), Margin = 0.003 ns (229.64% of Mean)
Skewness = 1.4, Kurtosis = 3.23, MValue = 2
-------------------- Histogram --------------------
[-0.002 ns ; 0.002 ns) | @@@@@@@@@@@
[ 0.002 ns ; 0.005 ns) |
[ 0.005 ns ; 0.008 ns) | @@
[ 0.008 ns ; 0.010 ns) | @
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadInt1: DefaultJob [obj=Aweso(...).Int1 [61]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.007 ns, StdErr = 0.002 ns (29.94%), N = 15, StdDev = 0.008 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.005 ns, Q3 = 0.012 ns, Max = 0.027 ns
IQR = 0.012 ns, LowerFence = -0.018 ns, UpperFence = 0.031 ns
ConfidenceInterval = [-0.002 ns; 0.016 ns] (CI 99.9%), Margin = 0.009 ns (123.96% of Mean)
Skewness = 0.96, Kurtosis = 2.96, MValue = 2.2
-------------------- Histogram --------------------
[-0.001 ns ; 0.008 ns) | @@@@@@@@@@
[ 0.008 ns ; 0.019 ns) | @@@@
[ 0.019 ns ; 0.023 ns) |
[ 0.023 ns ; 0.031 ns) | @
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadInt2: DefaultJob [obj=Aweso(...).Int2 [61]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.000 ns, StdErr = 0.000 ns (68.68%), N = 14, StdDev = 0.001 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.000 ns, Max = 0.002 ns
IQR = 0.000 ns, LowerFence = 0.000 ns, UpperFence = 0.000 ns
ConfidenceInterval = [-0.000 ns; 0.001 ns] (CI 99.9%), Margin = 0.001 ns (289.88% of Mean)
Skewness = 1.91, Kurtosis = 4.92, MValue = 2
-------------------- Histogram --------------------
[-0.000 ns ; 0.000 ns) | @@@@@@@@@@@@
[ 0.000 ns ; 0.001 ns) |
[ 0.001 ns ; 0.002 ns) | @@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadInt3: DefaultJob [obj=Aweso(...).Int3 [61]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.007 ns, StdErr = 0.003 ns (41.95%), N = 15, StdDev = 0.011 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.008 ns, Max = 0.032 ns
IQR = 0.008 ns, LowerFence = -0.012 ns, UpperFence = 0.020 ns
ConfidenceInterval = [-0.005 ns; 0.019 ns] (CI 99.9%), Margin = 0.012 ns (173.68% of Mean)
Skewness = 1.31, Kurtosis = 3.15, MValue = 2.22
-------------------- Histogram --------------------
[-0.002 ns ; 0.013 ns) | @@@@@@@@@@@@
[ 0.013 ns ; 0.026 ns) | @
[ 0.026 ns ; 0.038 ns) | @@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadInt4: DefaultJob [obj=Aweso(...).Int4 [61]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.005 ns, StdErr = 0.002 ns (43.40%), N = 15, StdDev = 0.008 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.006 ns, Max = 0.022 ns
IQR = 0.006 ns, LowerFence = -0.010 ns, UpperFence = 0.016 ns
ConfidenceInterval = [-0.004 ns; 0.013 ns] (CI 99.9%), Margin = 0.008 ns (179.70% of Mean)
Skewness = 1.37, Kurtosis = 3.34, MValue = 2.4
-------------------- Histogram --------------------
[-0.000 ns ; 0.008 ns) | @@@@@@@@@@@@
[ 0.008 ns ; 0.018 ns) | @
[ 0.018 ns ; 0.027 ns) | @@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadIntBaseline: DefaultJob [obj=Aweso(...)eline [68]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.805 ns, StdErr = 0.004 ns (0.49%), N = 14, StdDev = 0.015 ns
Min = 0.780 ns, Q1 = 0.795 ns, Median = 0.806 ns, Q3 = 0.814 ns, Max = 0.835 ns
IQR = 0.020 ns, LowerFence = 0.766 ns, UpperFence = 0.844 ns
ConfidenceInterval = [0.789 ns; 0.822 ns] (CI 99.9%), Margin = 0.017 ns (2.07% of Mean)
Skewness = 0.19, Kurtosis = 2.14, MValue = 2
-------------------- Histogram --------------------
[0.780 ns ; 0.802 ns) | @@@@@
[0.802 ns ; 0.838 ns) | @@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadManyInt0: DefaultJob [array=Int0[1000]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 358.196 ns, StdErr = 0.472 ns (0.13%), N = 14, StdDev = 1.767 ns
Min = 355.097 ns, Q1 = 357.173 ns, Median = 358.107 ns, Q3 = 358.988 ns, Max = 361.651 ns
IQR = 1.815 ns, LowerFence = 354.451 ns, UpperFence = 361.710 ns
ConfidenceInterval = [356.203 ns; 360.189 ns] (CI 99.9%), Margin = 1.993 ns (0.56% of Mean)
Skewness = 0.22, Kurtosis = 2.19, MValue = 2
-------------------- Histogram --------------------
[354.135 ns ; 362.613 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadManyInt1: DefaultJob [array=Int1[1000]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 358.708 ns, StdErr = 0.471 ns (0.13%), N = 14, StdDev = 1.763 ns
Min = 355.194 ns, Q1 = 357.701 ns, Median = 359.146 ns, Q3 = 359.460 ns, Max = 362.063 ns
IQR = 1.759 ns, LowerFence = 355.062 ns, UpperFence = 362.099 ns
ConfidenceInterval = [356.719 ns; 360.696 ns] (CI 99.9%), Margin = 1.989 ns (0.55% of Mean)
Skewness = -0.16, Kurtosis = 2.46, MValue = 2
-------------------- Histogram --------------------
[354.990 ns ; 362.161 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadManyInt2: DefaultJob [array=Int2[1000]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 357.849 ns, StdErr = 0.233 ns (0.06%), N = 13, StdDev = 0.838 ns
Min = 356.376 ns, Q1 = 357.304 ns, Median = 357.780 ns, Q3 = 358.464 ns, Max = 359.615 ns
IQR = 1.161 ns, LowerFence = 355.563 ns, UpperFence = 360.205 ns
ConfidenceInterval = [356.845 ns; 358.853 ns] (CI 99.9%), Margin = 1.004 ns (0.28% of Mean)
Skewness = 0.29, Kurtosis = 2.48, MValue = 2
-------------------- Histogram --------------------
[355.908 ns ; 360.083 ns) | @@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadManyInt3: DefaultJob [array=Int3[1000]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 357.163 ns, StdErr = 0.377 ns (0.11%), N = 12, StdDev = 1.304 ns
Min = 355.416 ns, Q1 = 355.876 ns, Median = 357.238 ns, Q3 = 358.122 ns, Max = 358.974 ns
IQR = 2.246 ns, LowerFence = 352.507 ns, UpperFence = 361.491 ns
ConfidenceInterval = [355.492 ns; 358.833 ns] (CI 99.9%), Margin = 1.671 ns (0.47% of Mean)
Skewness = -0.06, Kurtosis = 1.35, MValue = 2
-------------------- Histogram --------------------
[354.669 ns ; 359.722 ns) | @@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadManyInt4: DefaultJob [array=Int4[1000]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 369.816 ns, StdErr = 0.620 ns (0.17%), N = 15, StdDev = 2.400 ns
Min = 365.262 ns, Q1 = 368.434 ns, Median = 369.557 ns, Q3 = 371.216 ns, Max = 374.854 ns
IQR = 2.782 ns, LowerFence = 364.260 ns, UpperFence = 375.390 ns
ConfidenceInterval = [367.250 ns; 372.381 ns] (CI 99.9%), Margin = 2.566 ns (0.69% of Mean)
Skewness = 0.1, Kurtosis = 2.56, MValue = 2
-------------------- Histogram --------------------
[363.984 ns ; 376.131 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentReadBenchmarks.ReadManyIntBaseline: DefaultJob [array=IntBaseline[1000]]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 381.308 ns, StdErr = 1.890 ns (0.50%), N = 18, StdDev = 8.018 ns
Min = 368.190 ns, Q1 = 375.224 ns, Median = 382.592 ns, Q3 = 385.046 ns, Max = 398.289 ns
IQR = 9.822 ns, LowerFence = 360.490 ns, UpperFence = 399.779 ns
ConfidenceInterval = [373.815 ns; 388.802 ns] (CI 99.9%), Margin = 7.494 ns (1.97% of Mean)
Skewness = 0.14, Kurtosis = 2.38, MValue = 2
-------------------- Histogram --------------------
[367.419 ns ; 380.006 ns) | @@@@@@
[380.006 ns ; 388.037 ns) | @@@@@@@@@@
[388.037 ns ; 400.074 ns) | @@
---------------------------------------------------
```