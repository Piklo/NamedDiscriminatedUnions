The point of those benchmarks was to better further test how natural alignment affects performance

`dotnet run -c release`
```
// * Summary *

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


| Method                                                  | Categories           | Mean      | Error     | StdDev    | Ratio | RatioSD |
|-------------------------------------------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|
| BaselineInt                                             | int                  | 0.2676 ns | 0.0207 ns | 0.0184 ns |  1.00 |    0.00 |
| ExplicitNonOverlappingMisalignedInt                     | int                  | 4.8692 ns | 0.0791 ns | 0.0740 ns | 18.29 |    1.33 |
| ExplicitNonOverlappingAlignedInt                        | int                  | 0.2753 ns | 0.0256 ns | 0.0239 ns |  1.05 |    0.12 |
| ExplicitOverlappingMisalignedInt                        | int                  | 4.9275 ns | 0.0852 ns | 0.0712 ns | 18.68 |    1.12 |
| ExplicitOverlappingAlignedInt                           | int                  | 4.9201 ns | 0.0753 ns | 0.0668 ns | 18.47 |    1.40 |
| ExplicitOverlappingAlignedOptimizedInt                  | int                  | 4.9224 ns | 0.0960 ns | 0.0898 ns | 18.51 |    1.35 |
|                                                         |                      |           |           |           |       |         |
| BaselineIntNoOptimization                               | intNoOptimization    | 6.1523 ns | 0.1485 ns | 0.1982 ns |  1.00 |    0.00 |
| ExplicitNonOverlappingMisalignedIntNoOptimization       | intNoOptimization    | 6.2430 ns | 0.1210 ns | 0.1010 ns |  1.02 |    0.05 |
| ExplicitNonOverlappingAlignedIntNoOptimization          | intNoOptimization    | 6.2100 ns | 0.1318 ns | 0.1354 ns |  1.01 |    0.05 |
| ExplicitOverlappingMisalignedIntNoOptimization          | intNoOptimization    | 6.1224 ns | 0.1313 ns | 0.2045 ns |  1.00 |    0.05 |
| ExplicitOverlappingAlignedIntNoOptimization             | intNoOptimization    | 5.7819 ns | 0.1305 ns | 0.1340 ns |  0.94 |    0.05 |
| ExplicitOverlappingAlignedOptimizedIntNoOptimization    | intNoOptimization    | 5.9398 ns | 0.0994 ns | 0.0930 ns |  0.96 |    0.04 |
|                                                         |                      |           |           |           |       |         |
| BaselineLong                                            | long                 | 0.2600 ns | 0.0167 ns | 0.0156 ns |  1.00 |    0.00 |
| ExplicitNonOverlappingMisalignedLong                    | long                 | 4.8152 ns | 0.0784 ns | 0.0733 ns | 18.59 |    1.16 |
| ExplicitNonOverlappingAlignedLong                       | long                 | 0.2683 ns | 0.0357 ns | 0.0279 ns |  1.06 |    0.13 |
| ExplicitOverlappingMisalignedLong                       | long                 | 4.9148 ns | 0.1037 ns | 0.0919 ns | 19.07 |    1.14 |
| ExplicitOverlappingAlignedLong                          | long                 | 4.8145 ns | 0.1225 ns | 0.1757 ns | 18.89 |    1.38 |
| ExplicitOverlappingAlignedOptimizedLong                 | long                 | 4.8978 ns | 0.0461 ns | 0.0409 ns | 19.01 |    1.14 |
|                                                         |                      |           |           |           |       |         |
| BaselineLongNoOptimization                              | longNoOptimization   | 5.8608 ns | 0.1098 ns | 0.1027 ns |  1.00 |    0.00 |
| ExplicitNonOverlappingMisalignedLongNoOptimization      | longNoOptimization   | 6.1208 ns | 0.1432 ns | 0.1340 ns |  1.04 |    0.03 |
| ExplicitNonOverlappingAlignedLongNoOptimization         | longNoOptimization   | 6.3673 ns | 0.0640 ns | 0.0598 ns |  1.09 |    0.02 |
| ExplicitOverlappingMisalignedLongNoOptimization         | longNoOptimization   | 6.0795 ns | 0.0903 ns | 0.0845 ns |  1.04 |    0.03 |
| ExplicitOverlappingAlignedLongNoOptimization            | longNoOptimization   | 5.9156 ns | 0.1203 ns | 0.1287 ns |  1.01 |    0.03 |
| ExplicitOverlappingAlignedOptimizedLongNoOptimization   | longNoOptimization   | 6.4047 ns | 0.1530 ns | 0.1356 ns |  1.09 |    0.03 |
|                                                         |                      |           |           |           |       |         |
| BaselineString                                          | string               | 1.1358 ns | 0.0262 ns | 0.0232 ns |  1.00 |    0.00 |
| ExplicitNonOverlappingMisalignedString                  | string               | 5.0641 ns | 0.0718 ns | 0.0672 ns |  4.46 |    0.12 |
| ExplicitNonOverlappingAlignedString                     | string               | 1.0752 ns | 0.0322 ns | 0.0286 ns |  0.95 |    0.03 |
| ExplicitOverlappingMisalignedString                     | string               | 4.9483 ns | 0.1264 ns | 0.1504 ns |  4.36 |    0.18 |
| ExplicitOverlappingAlignedString                        | string               | 4.7664 ns | 0.0795 ns | 0.0743 ns |  4.20 |    0.12 |
| ExplicitOverlappingAlignedOptimizedString               | string               | 4.9566 ns | 0.0746 ns | 0.0698 ns |  4.36 |    0.10 |
|                                                         |                      |           |           |           |       |         |
| BaselineStringNoOptimization                            | stringNoOptimization | 6.3850 ns | 0.1503 ns | 0.1608 ns |  1.00 |    0.00 |
| ExplicitNonOverlappingMisalignedStringNoOptimization    | stringNoOptimization | 6.4978 ns | 0.0440 ns | 0.0343 ns |  1.01 |    0.03 |
| ExplicitNonOverlappingAlignedStringNoOptimization       | stringNoOptimization | 6.9146 ns | 0.1415 ns | 0.1323 ns |  1.08 |    0.02 |
| ExplicitOverlappingMisalignedStringNoOptimization       | stringNoOptimization | 6.4931 ns | 0.1579 ns | 0.1689 ns |  1.02 |    0.02 |
| ExplicitOverlappingAlignedStringNoOptimization          | stringNoOptimization | 6.4739 ns | 0.1556 ns | 0.1379 ns |  1.01 |    0.04 |
| ExplicitOverlappingAlignedOptimizedStringNoOptimization | stringNoOptimization | 6.6387 ns | 0.1333 ns | 0.1182 ns |  1.04 |    0.03 |

// * Warnings *
MultimodalDistribution
  MemoryAlignmentOverlappingBenchmarks.BaselineLong: Default                                      -> It seems that the distribution is bimodal (mValue = 3.43)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedString: Default               -> It seems that the distribution can have several modes (mValue = 3)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedStringNoOptimization: Default -> It seems that the distribution is bimodal (mValue = 3.56)

// * Hints *
Outliers
  MemoryAlignmentOverlappingBenchmarks.BaselineInt: Default                                             -> 1 outlier  was  removed (1.84 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedInt: Default                        -> 2 outliers were removed (6.71 ns, 6.82 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedInt: Default                           -> 1 outlier  was  removed (6.67 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedIntNoOptimization: Default       -> 4 outliers were removed (8.22 ns..8.61 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedIntNoOptimization: Default          -> 2 outliers were removed (8.15 ns, 8.29 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedIntNoOptimization: Default          -> 2 outliers were removed (8.32 ns, 9.14 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedIntNoOptimization: Default             -> 2 outliers were removed (7.72 ns, 7.93 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedLong: Default                       -> 3 outliers were removed (1.94 ns..2.00 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedLong: Default                       -> 1 outlier  was  removed (7.18 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedLong: Default                          -> 1 outlier  was  removed (7.07 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedLong: Default                 -> 1 outlier  was  removed, 2 outliers were detected (6.36 ns, 6.80 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedLongNoOptimization: Default            -> 1 outlier  was  removed (7.87 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedLongNoOptimization: Default   -> 1 outlier  was  removed (8.39 ns)
  MemoryAlignmentOverlappingBenchmarks.BaselineString: Default                                          -> 1 outlier  was  removed (2.75 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedString: Default                     -> 1 outlier  was  removed (2.78 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedStringNoOptimization: Default    -> 3 outliers were removed (8.29 ns..8.41 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedStringNoOptimization: Default          -> 1 outlier  was  removed (8.60 ns)
  MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedStringNoOptimization: Default -> 1 outlier  was  removed (8.89 ns)

// * Legends *
  Categories : All categories of the corresponded method, class, and assembly
  Mean       : Arithmetic mean of all measurements
  Error      : Half of 99.9% confidence interval
  StdDev     : Standard deviation of all measurements
  Ratio      : Mean of the ratio distribution ([Current]/[Baseline])
  RatioSD    : Standard deviation of the ratio distribution ([Current]/[Baseline])
  1 ns       : 1 Nanosecond (0.000000001 sec)

// ***** BenchmarkRunner: End *****
Run time: 00:15:35 (935.03 sec), executed benchmarks: 36

Global total time: 00:15:54 (954.33 sec), executed benchmarks: 36

// * Detailed results *
MemoryAlignmentOverlappingBenchmarks.BaselineInt: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.268 ns, StdErr = 0.005 ns (1.84%), N = 14, StdDev = 0.018 ns
Min = 0.244 ns, Q1 = 0.251 ns, Median = 0.270 ns, Q3 = 0.279 ns, Max = 0.307 ns
IQR = 0.028 ns, LowerFence = 0.208 ns, UpperFence = 0.321 ns
ConfidenceInterval = [0.247 ns; 0.288 ns] (CI 99.9%), Margin = 0.021 ns (7.75% of Mean)
Skewness = 0.38, Kurtosis = 2.15, MValue = 2
-------------------- Histogram --------------------
[0.241 ns ; 0.264 ns) | @@@@@@
[0.264 ns ; 0.284 ns) | @@@@@@
[0.284 ns ; 0.308 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedInt: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.869 ns, StdErr = 0.019 ns (0.39%), N = 15, StdDev = 0.074 ns
Min = 4.774 ns, Q1 = 4.813 ns, Median = 4.837 ns, Q3 = 4.926 ns, Max = 5.036 ns
IQR = 0.114 ns, LowerFence = 4.642 ns, UpperFence = 5.097 ns
ConfidenceInterval = [4.790 ns; 4.948 ns] (CI 99.9%), Margin = 0.079 ns (1.63% of Mean)
Skewness = 0.68, Kurtosis = 2.31, MValue = 2
-------------------- Histogram --------------------
[4.764 ns ; 4.877 ns) | @@@@@@@@@
[4.877 ns ; 5.076 ns) | @@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedInt: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.275 ns, StdErr = 0.006 ns (2.25%), N = 15, StdDev = 0.024 ns
Min = 0.228 ns, Q1 = 0.262 ns, Median = 0.275 ns, Q3 = 0.291 ns, Max = 0.315 ns
IQR = 0.029 ns, LowerFence = 0.219 ns, UpperFence = 0.333 ns
ConfidenceInterval = [0.250 ns; 0.301 ns] (CI 99.9%), Margin = 0.026 ns (9.30% of Mean)
Skewness = -0.22, Kurtosis = 2.15, MValue = 2
-------------------- Histogram --------------------
[0.215 ns ; 0.240 ns) | @
[0.240 ns ; 0.268 ns) | @@@@
[0.268 ns ; 0.293 ns) | @@@@@@@
[0.293 ns ; 0.321 ns) | @@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedInt: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.928 ns, StdErr = 0.020 ns (0.40%), N = 13, StdDev = 0.071 ns
Min = 4.811 ns, Q1 = 4.877 ns, Median = 4.942 ns, Q3 = 4.946 ns, Max = 5.069 ns
IQR = 0.069 ns, LowerFence = 4.773 ns, UpperFence = 5.050 ns
ConfidenceInterval = [4.842 ns; 5.013 ns] (CI 99.9%), Margin = 0.085 ns (1.73% of Mean)
Skewness = 0.3, Kurtosis = 2.33, MValue = 2
-------------------- Histogram --------------------
[4.771 ns ; 4.966 ns) | @@@@@@@@@@@
[4.966 ns ; 5.101 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedInt: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.920 ns, StdErr = 0.018 ns (0.36%), N = 14, StdDev = 0.067 ns
Min = 4.844 ns, Q1 = 4.866 ns, Median = 4.913 ns, Q3 = 4.951 ns, Max = 5.050 ns
IQR = 0.084 ns, LowerFence = 4.739 ns, UpperFence = 5.077 ns
ConfidenceInterval = [4.845 ns; 4.995 ns] (CI 99.9%), Margin = 0.075 ns (1.53% of Mean)
Skewness = 0.61, Kurtosis = 2.04, MValue = 2
-------------------- Histogram --------------------
[4.827 ns ; 5.087 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedInt: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.922 ns, StdErr = 0.023 ns (0.47%), N = 15, StdDev = 0.090 ns
Min = 4.763 ns, Q1 = 4.860 ns, Median = 4.940 ns, Q3 = 5.006 ns, Max = 5.050 ns
IQR = 0.146 ns, LowerFence = 4.641 ns, UpperFence = 5.226 ns
ConfidenceInterval = [4.826 ns; 5.018 ns] (CI 99.9%), Margin = 0.096 ns (1.95% of Mean)
Skewness = -0.26, Kurtosis = 1.61, MValue = 2
-------------------- Histogram --------------------
[4.715 ns ; 4.819 ns) | @@
[4.819 ns ; 4.928 ns) | @@@@@
[4.928 ns ; 5.097 ns) | @@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.BaselineIntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.152 ns, StdErr = 0.040 ns (0.64%), N = 25, StdDev = 0.198 ns
Min = 5.756 ns, Q1 = 6.027 ns, Median = 6.161 ns, Q3 = 6.279 ns, Max = 6.534 ns
IQR = 0.253 ns, LowerFence = 5.648 ns, UpperFence = 6.658 ns
ConfidenceInterval = [6.004 ns; 6.301 ns] (CI 99.9%), Margin = 0.148 ns (2.41% of Mean)
Skewness = -0.09, Kurtosis = 2.41, MValue = 2
-------------------- Histogram --------------------
[5.751 ns ; 5.929 ns) | @@@@
[5.929 ns ; 6.197 ns) | @@@@@@@@@@@@
[6.197 ns ; 6.406 ns) | @@@@@@@
[6.406 ns ; 6.623 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedIntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.243 ns, StdErr = 0.028 ns (0.45%), N = 13, StdDev = 0.101 ns
Min = 6.029 ns, Q1 = 6.191 ns, Median = 6.255 ns, Q3 = 6.295 ns, Max = 6.393 ns
IQR = 0.104 ns, LowerFence = 6.036 ns, UpperFence = 6.451 ns
ConfidenceInterval = [6.122 ns; 6.364 ns] (CI 99.9%), Margin = 0.121 ns (1.94% of Mean)
Skewness = -0.39, Kurtosis = 2.3, MValue = 2
-------------------- Histogram --------------------
[5.973 ns ; 6.181 ns) | @@@
[6.181 ns ; 6.450 ns) | @@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedIntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.210 ns, StdErr = 0.033 ns (0.53%), N = 17, StdDev = 0.135 ns
Min = 6.069 ns, Q1 = 6.143 ns, Median = 6.170 ns, Q3 = 6.201 ns, Max = 6.544 ns
IQR = 0.058 ns, LowerFence = 6.056 ns, UpperFence = 6.287 ns
ConfidenceInterval = [6.078 ns; 6.342 ns] (CI 99.9%), Margin = 0.132 ns (2.12% of Mean)
Skewness = 1.27, Kurtosis = 3.38, MValue = 2
-------------------- Histogram --------------------
[6.066 ns ; 6.204 ns) | @@@@@@@@@@@@@
[6.204 ns ; 6.408 ns) | @
[6.408 ns ; 6.546 ns) | @@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedIntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.122 ns, StdErr = 0.036 ns (0.59%), N = 32, StdDev = 0.204 ns
Min = 5.886 ns, Q1 = 5.987 ns, Median = 6.070 ns, Q3 = 6.224 ns, Max = 6.675 ns
IQR = 0.237 ns, LowerFence = 5.631 ns, UpperFence = 6.580 ns
ConfidenceInterval = [5.991 ns; 6.254 ns] (CI 99.9%), Margin = 0.131 ns (2.15% of Mean)
Skewness = 0.94, Kurtosis = 3.01, MValue = 2.53
-------------------- Histogram --------------------
[5.802 ns ; 5.965 ns) | @@@@@@@
[5.965 ns ; 6.134 ns) | @@@@@@@@@@@@@@@
[6.134 ns ; 6.295 ns) | @@
[6.295 ns ; 6.464 ns) | @@@@@@
[6.464 ns ; 6.692 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedIntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.782 ns, StdErr = 0.032 ns (0.56%), N = 17, StdDev = 0.134 ns
Min = 5.616 ns, Q1 = 5.709 ns, Median = 5.750 ns, Q3 = 5.844 ns, Max = 6.133 ns
IQR = 0.134 ns, LowerFence = 5.508 ns, UpperFence = 6.046 ns
ConfidenceInterval = [5.651 ns; 5.912 ns] (CI 99.9%), Margin = 0.130 ns (2.26% of Mean)
Skewness = 0.96, Kurtosis = 3.39, MValue = 2
-------------------- Histogram --------------------
[5.615 ns ; 5.752 ns) | @@@@@@@@@@
[5.752 ns ; 5.923 ns) | @@@@@
[5.923 ns ; 6.201 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedIntNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.940 ns, StdErr = 0.024 ns (0.40%), N = 15, StdDev = 0.093 ns
Min = 5.834 ns, Q1 = 5.874 ns, Median = 5.901 ns, Q3 = 6.007 ns, Max = 6.112 ns
IQR = 0.133 ns, LowerFence = 5.674 ns, UpperFence = 6.208 ns
ConfidenceInterval = [5.840 ns; 6.039 ns] (CI 99.9%), Margin = 0.099 ns (1.67% of Mean)
Skewness = 0.61, Kurtosis = 1.73, MValue = 2
-------------------- Histogram --------------------
[5.811 ns ; 6.137 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.BaselineLong: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.260 ns, StdErr = 0.004 ns (1.55%), N = 15, StdDev = 0.016 ns
Min = 0.235 ns, Q1 = 0.247 ns, Median = 0.259 ns, Q3 = 0.273 ns, Max = 0.285 ns
IQR = 0.026 ns, LowerFence = 0.209 ns, UpperFence = 0.311 ns
ConfidenceInterval = [0.243 ns; 0.277 ns] (CI 99.9%), Margin = 0.017 ns (6.41% of Mean)
Skewness = 0.07, Kurtosis = 1.62, MValue = 3.43
-------------------- Histogram --------------------
[0.227 ns ; 0.246 ns) | @@@
[0.246 ns ; 0.263 ns) | @@@@@@@
[0.263 ns ; 0.270 ns) |
[0.270 ns ; 0.286 ns) | @@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedLong: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.815 ns, StdErr = 0.019 ns (0.39%), N = 15, StdDev = 0.073 ns
Min = 4.686 ns, Q1 = 4.765 ns, Median = 4.815 ns, Q3 = 4.873 ns, Max = 4.921 ns
IQR = 0.108 ns, LowerFence = 4.603 ns, UpperFence = 5.035 ns
ConfidenceInterval = [4.737 ns; 4.894 ns] (CI 99.9%), Margin = 0.078 ns (1.63% of Mean)
Skewness = -0.22, Kurtosis = 1.66, MValue = 2
-------------------- Histogram --------------------
[4.647 ns ; 4.825 ns) | @@@@@@@@
[4.825 ns ; 4.935 ns) | @@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedLong: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.268 ns, StdErr = 0.008 ns (3.00%), N = 12, StdDev = 0.028 ns
Min = 0.228 ns, Q1 = 0.250 ns, Median = 0.264 ns, Q3 = 0.287 ns, Max = 0.318 ns
IQR = 0.037 ns, LowerFence = 0.195 ns, UpperFence = 0.342 ns
ConfidenceInterval = [0.233 ns; 0.304 ns] (CI 99.9%), Margin = 0.036 ns (13.30% of Mean)
Skewness = 0.31, Kurtosis = 1.74, MValue = 2.57
-------------------- Histogram --------------------
[0.212 ns ; 0.237 ns) | @
[0.237 ns ; 0.269 ns) | @@@@@@@
[0.269 ns ; 0.292 ns) | @
[0.292 ns ; 0.324 ns) | @@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedLong: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.915 ns, StdErr = 0.025 ns (0.50%), N = 14, StdDev = 0.092 ns
Min = 4.790 ns, Q1 = 4.841 ns, Median = 4.906 ns, Q3 = 4.974 ns, Max = 5.108 ns
IQR = 0.133 ns, LowerFence = 4.642 ns, UpperFence = 5.173 ns
ConfidenceInterval = [4.811 ns; 5.018 ns] (CI 99.9%), Margin = 0.104 ns (2.11% of Mean)
Skewness = 0.39, Kurtosis = 2.08, MValue = 2
-------------------- Histogram --------------------
[4.780 ns ; 4.931 ns) | @@@@@@@@
[4.931 ns ; 5.158 ns) | @@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedLong: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.815 ns, StdErr = 0.033 ns (0.69%), N = 28, StdDev = 0.176 ns
Min = 4.514 ns, Q1 = 4.684 ns, Median = 4.797 ns, Q3 = 4.917 ns, Max = 5.205 ns
IQR = 0.233 ns, LowerFence = 4.335 ns, UpperFence = 5.266 ns
ConfidenceInterval = [4.692 ns; 4.937 ns] (CI 99.9%), Margin = 0.123 ns (2.54% of Mean)
Skewness = 0.49, Kurtosis = 2.37, MValue = 2
-------------------- Histogram --------------------
[4.500 ns ; 4.653 ns) | @@@
[4.653 ns ; 4.805 ns) | @@@@@@@@@@@@@
[4.805 ns ; 4.973 ns) | @@@@@@@
[4.973 ns ; 5.152 ns) | @@@@
[5.152 ns ; 5.281 ns) | @
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedLong: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.898 ns, StdErr = 0.011 ns (0.22%), N = 14, StdDev = 0.041 ns
Min = 4.801 ns, Q1 = 4.879 ns, Median = 4.901 ns, Q3 = 4.921 ns, Max = 4.965 ns
IQR = 0.042 ns, LowerFence = 4.817 ns, UpperFence = 4.983 ns
ConfidenceInterval = [4.852 ns; 4.944 ns] (CI 99.9%), Margin = 0.046 ns (0.94% of Mean)
Skewness = -0.52, Kurtosis = 3.07, MValue = 2
-------------------- Histogram --------------------
[4.779 ns ; 4.988 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.BaselineLongNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.861 ns, StdErr = 0.027 ns (0.45%), N = 15, StdDev = 0.103 ns
Min = 5.700 ns, Q1 = 5.771 ns, Median = 5.881 ns, Q3 = 5.906 ns, Max = 6.016 ns
IQR = 0.134 ns, LowerFence = 5.570 ns, UpperFence = 6.107 ns
ConfidenceInterval = [5.751 ns; 5.971 ns] (CI 99.9%), Margin = 0.110 ns (1.87% of Mean)
Skewness = -0.2, Kurtosis = 1.69, MValue = 2
-------------------- Histogram --------------------
[5.686 ns ; 5.825 ns) | @@@@@
[5.825 ns ; 6.070 ns) | @@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedLongNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.121 ns, StdErr = 0.035 ns (0.57%), N = 15, StdDev = 0.134 ns
Min = 5.967 ns, Q1 = 6.031 ns, Median = 6.068 ns, Q3 = 6.197 ns, Max = 6.387 ns
IQR = 0.166 ns, LowerFence = 5.782 ns, UpperFence = 6.446 ns
ConfidenceInterval = [5.978 ns; 6.264 ns] (CI 99.9%), Margin = 0.143 ns (2.34% of Mean)
Skewness = 0.83, Kurtosis = 2.15, MValue = 2.2
-------------------- Histogram --------------------
[5.954 ns ; 6.097 ns) | @@@@@@@@@@
[6.097 ns ; 6.265 ns) | @@
[6.265 ns ; 6.408 ns) | @@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedLongNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.367 ns, StdErr = 0.015 ns (0.24%), N = 15, StdDev = 0.060 ns
Min = 6.276 ns, Q1 = 6.337 ns, Median = 6.351 ns, Q3 = 6.407 ns, Max = 6.483 ns
IQR = 0.070 ns, LowerFence = 6.233 ns, UpperFence = 6.511 ns
ConfidenceInterval = [6.303 ns; 6.431 ns] (CI 99.9%), Margin = 0.064 ns (1.00% of Mean)
Skewness = 0.37, Kurtosis = 2.04, MValue = 2
-------------------- Histogram --------------------
[6.244 ns ; 6.515 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedLongNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.079 ns, StdErr = 0.022 ns (0.36%), N = 15, StdDev = 0.084 ns
Min = 5.973 ns, Q1 = 6.003 ns, Median = 6.079 ns, Q3 = 6.130 ns, Max = 6.236 ns
IQR = 0.128 ns, LowerFence = 5.811 ns, UpperFence = 6.322 ns
ConfidenceInterval = [5.989 ns; 6.170 ns] (CI 99.9%), Margin = 0.090 ns (1.49% of Mean)
Skewness = 0.35, Kurtosis = 1.82, MValue = 2
-------------------- Histogram --------------------
[5.948 ns ; 6.281 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedLongNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.916 ns, StdErr = 0.030 ns (0.51%), N = 18, StdDev = 0.129 ns
Min = 5.705 ns, Q1 = 5.834 ns, Median = 5.885 ns, Q3 = 5.975 ns, Max = 6.233 ns
IQR = 0.140 ns, LowerFence = 5.624 ns, UpperFence = 6.185 ns
ConfidenceInterval = [5.795 ns; 6.036 ns] (CI 99.9%), Margin = 0.120 ns (2.03% of Mean)
Skewness = 0.59, Kurtosis = 2.87, MValue = 2
-------------------- Histogram --------------------
[5.641 ns ; 5.771 ns) | @
[5.771 ns ; 5.946 ns) | @@@@@@@@@
[5.946 ns ; 6.169 ns) | @@@@@@@
[6.169 ns ; 6.298 ns) | @
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedLongNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.405 ns, StdErr = 0.036 ns (0.57%), N = 14, StdDev = 0.136 ns
Min = 6.200 ns, Q1 = 6.321 ns, Median = 6.378 ns, Q3 = 6.454 ns, Max = 6.733 ns
IQR = 0.133 ns, LowerFence = 6.122 ns, UpperFence = 6.653 ns
ConfidenceInterval = [6.252 ns; 6.558 ns] (CI 99.9%), Margin = 0.153 ns (2.39% of Mean)
Skewness = 0.88, Kurtosis = 3.16, MValue = 2
-------------------- Histogram --------------------
[6.126 ns ; 6.272 ns) | @
[6.272 ns ; 6.454 ns) | @@@@@@@@@
[6.454 ns ; 6.659 ns) | @@@
[6.659 ns ; 6.807 ns) | @
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.BaselineString: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.136 ns, StdErr = 0.006 ns (0.55%), N = 14, StdDev = 0.023 ns
Min = 1.105 ns, Q1 = 1.121 ns, Median = 1.129 ns, Q3 = 1.150 ns, Max = 1.184 ns
IQR = 0.029 ns, LowerFence = 1.078 ns, UpperFence = 1.193 ns
ConfidenceInterval = [1.110 ns; 1.162 ns] (CI 99.9%), Margin = 0.026 ns (2.31% of Mean)
Skewness = 0.6, Kurtosis = 2.14, MValue = 2
-------------------- Histogram --------------------
[1.092 ns ; 1.134 ns) | @@@@@@@@@
[1.134 ns ; 1.171 ns) | @@@@
[1.171 ns ; 1.197 ns) | @
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedString: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.064 ns, StdErr = 0.017 ns (0.34%), N = 15, StdDev = 0.067 ns
Min = 4.919 ns, Q1 = 5.023 ns, Median = 5.077 ns, Q3 = 5.121 ns, Max = 5.151 ns
IQR = 0.097 ns, LowerFence = 4.878 ns, UpperFence = 5.266 ns
ConfidenceInterval = [4.992 ns; 5.136 ns] (CI 99.9%), Margin = 0.072 ns (1.42% of Mean)
Skewness = -0.55, Kurtosis = 2.2, MValue = 2
-------------------- Histogram --------------------
[4.884 ns ; 5.153 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedString: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.075 ns, StdErr = 0.008 ns (0.71%), N = 14, StdDev = 0.029 ns
Min = 1.029 ns, Q1 = 1.052 ns, Median = 1.076 ns, Q3 = 1.101 ns, Max = 1.118 ns
IQR = 0.049 ns, LowerFence = 0.978 ns, UpperFence = 1.175 ns
ConfidenceInterval = [1.043 ns; 1.107 ns] (CI 99.9%), Margin = 0.032 ns (3.00% of Mean)
Skewness = -0.06, Kurtosis = 1.48, MValue = 2
-------------------- Histogram --------------------
[1.013 ns ; 1.037 ns) | @
[1.037 ns ; 1.068 ns) | @@@@@
[1.068 ns ; 1.110 ns) | @@@@@@@
[1.110 ns ; 1.133 ns) | @
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedString: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.948 ns, StdErr = 0.033 ns (0.66%), N = 21, StdDev = 0.150 ns
Min = 4.718 ns, Q1 = 4.839 ns, Median = 4.879 ns, Q3 = 5.054 ns, Max = 5.316 ns
IQR = 0.215 ns, LowerFence = 4.516 ns, UpperFence = 5.377 ns
ConfidenceInterval = [4.822 ns; 5.075 ns] (CI 99.9%), Margin = 0.126 ns (2.55% of Mean)
Skewness = 0.58, Kurtosis = 2.49, MValue = 3
-------------------- Histogram --------------------
[4.646 ns ; 4.763 ns) | @
[4.763 ns ; 4.906 ns) | @@@@@@@@@@
[4.906 ns ; 5.015 ns) | @@
[5.015 ns ; 5.244 ns) | @@@@@@@
[5.244 ns ; 5.387 ns) | @
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedString: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.766 ns, StdErr = 0.019 ns (0.40%), N = 15, StdDev = 0.074 ns
Min = 4.674 ns, Q1 = 4.707 ns, Median = 4.752 ns, Q3 = 4.814 ns, Max = 4.929 ns
IQR = 0.107 ns, LowerFence = 4.546 ns, UpperFence = 4.974 ns
ConfidenceInterval = [4.687 ns; 4.846 ns] (CI 99.9%), Margin = 0.079 ns (1.67% of Mean)
Skewness = 0.53, Kurtosis = 2.2, MValue = 2
-------------------- Histogram --------------------
[4.666 ns ; 4.777 ns) | @@@@@@@@
[4.777 ns ; 4.969 ns) | @@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedString: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.957 ns, StdErr = 0.018 ns (0.36%), N = 15, StdDev = 0.070 ns
Min = 4.789 ns, Q1 = 4.902 ns, Median = 4.972 ns, Q3 = 5.010 ns, Max = 5.041 ns
IQR = 0.107 ns, LowerFence = 4.741 ns, UpperFence = 5.171 ns
ConfidenceInterval = [4.882 ns; 5.031 ns] (CI 99.9%), Margin = 0.075 ns (1.50% of Mean)
Skewness = -0.77, Kurtosis = 2.72, MValue = 2
-------------------- Histogram --------------------
[4.752 ns ; 5.045 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.BaselineStringNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.385 ns, StdErr = 0.038 ns (0.59%), N = 18, StdDev = 0.161 ns
Min = 6.197 ns, Q1 = 6.258 ns, Median = 6.337 ns, Q3 = 6.526 ns, Max = 6.741 ns
IQR = 0.269 ns, LowerFence = 5.855 ns, UpperFence = 6.929 ns
ConfidenceInterval = [6.235 ns; 6.535 ns] (CI 99.9%), Margin = 0.150 ns (2.35% of Mean)
Skewness = 0.58, Kurtosis = 2.09, MValue = 2
-------------------- Histogram --------------------
[6.175 ns ; 6.336 ns) | @@@@@@@@@
[6.336 ns ; 6.569 ns) | @@@@@@@
[6.569 ns ; 6.760 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingMisalignedStringNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.498 ns, StdErr = 0.010 ns (0.15%), N = 12, StdDev = 0.034 ns
Min = 6.453 ns, Q1 = 6.480 ns, Median = 6.490 ns, Q3 = 6.503 ns, Max = 6.568 ns
IQR = 0.023 ns, LowerFence = 6.445 ns, UpperFence = 6.537 ns
ConfidenceInterval = [6.454 ns; 6.542 ns] (CI 99.9%), Margin = 0.044 ns (0.68% of Mean)
Skewness = 0.89, Kurtosis = 2.63, MValue = 2
-------------------- Histogram --------------------
[6.433 ns ; 6.588 ns) | @@@@@@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitNonOverlappingAlignedStringNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.915 ns, StdErr = 0.034 ns (0.49%), N = 15, StdDev = 0.132 ns
Min = 6.704 ns, Q1 = 6.824 ns, Median = 6.930 ns, Q3 = 6.985 ns, Max = 7.167 ns
IQR = 0.160 ns, LowerFence = 6.584 ns, UpperFence = 7.225 ns
ConfidenceInterval = [6.773 ns; 7.056 ns] (CI 99.9%), Margin = 0.141 ns (2.05% of Mean)
Skewness = 0.31, Kurtosis = 2.05, MValue = 2
-------------------- Histogram --------------------
[6.674 ns ; 6.812 ns) | @@@
[6.812 ns ; 7.073 ns) | @@@@@@@@@@
[7.073 ns ; 7.238 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingMisalignedStringNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.493 ns, StdErr = 0.040 ns (0.61%), N = 18, StdDev = 0.169 ns
Min = 6.264 ns, Q1 = 6.328 ns, Median = 6.460 ns, Q3 = 6.653 ns, Max = 6.752 ns
IQR = 0.325 ns, LowerFence = 5.840 ns, UpperFence = 7.140 ns
ConfidenceInterval = [6.335 ns; 6.651 ns] (CI 99.9%), Margin = 0.158 ns (2.43% of Mean)
Skewness = 0.2, Kurtosis = 1.33, MValue = 3.56
-------------------- Histogram --------------------
[6.257 ns ; 6.426 ns) | @@@@@@@@@
[6.426 ns ; 6.565 ns) | @
[6.565 ns ; 6.837 ns) | @@@@@@@@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedStringNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.474 ns, StdErr = 0.037 ns (0.57%), N = 14, StdDev = 0.138 ns
Min = 6.351 ns, Q1 = 6.384 ns, Median = 6.412 ns, Q3 = 6.512 ns, Max = 6.768 ns
IQR = 0.129 ns, LowerFence = 6.191 ns, UpperFence = 6.705 ns
ConfidenceInterval = [6.318 ns; 6.630 ns] (CI 99.9%), Margin = 0.156 ns (2.40% of Mean)
Skewness = 1.22, Kurtosis = 3.02, MValue = 2
-------------------- Histogram --------------------
[6.337 ns ; 6.487 ns) | @@@@@@@@@@
[6.487 ns ; 6.691 ns) | @@
[6.691 ns ; 6.843 ns) | @@
---------------------------------------------------

MemoryAlignmentOverlappingBenchmarks.ExplicitOverlappingAlignedOptimizedStringNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.639 ns, StdErr = 0.032 ns (0.48%), N = 14, StdDev = 0.118 ns
Min = 6.536 ns, Q1 = 6.554 ns, Median = 6.582 ns, Q3 = 6.699 ns, Max = 6.930 ns
IQR = 0.145 ns, LowerFence = 6.336 ns, UpperFence = 6.916 ns
ConfidenceInterval = [6.505 ns; 6.772 ns] (CI 99.9%), Margin = 0.133 ns (2.01% of Mean)
Skewness = 1.12, Kurtosis = 3.15, MValue = 2
-------------------- Histogram --------------------
[6.523 ns ; 6.759 ns) | @@@@@@@@@@@@
[6.759 ns ; 6.940 ns) | @@
---------------------------------------------------
```