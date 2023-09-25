The point of those benchmarks is to check whether there are inherent performance differences caused by different memory layouts between effectively same structs.

The answer is no, not really.

`dotnet run -c release`

```
// * Summary *

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


| Method                        | Mean       | Error     | StdDev    | Median     |
|------------------------------ |-----------:|----------:|----------:|-----------:|
| Int1Sequential                |  0.0058 ns | 0.0139 ns | 0.0148 ns |  0.0000 ns |
| Int1Explicit                  |  0.0098 ns | 0.0180 ns | 0.0150 ns |  0.0007 ns |
| Int1Auto                      |  0.0154 ns | 0.0144 ns | 0.0128 ns |  0.0142 ns |
| Int4Sequential                |  0.0199 ns | 0.0119 ns | 0.0105 ns |  0.0185 ns |
| Int4Explicit                  |  0.0048 ns | 0.0081 ns | 0.0076 ns |  0.0001 ns |
| Int4Auto                      |  0.0401 ns | 0.0258 ns | 0.0229 ns |  0.0372 ns |
| Int16Sequential               |  7.3587 ns | 0.0806 ns | 0.0673 ns |  7.3477 ns |
| Int16Explicit                 |  7.5843 ns | 0.0501 ns | 0.0469 ns |  7.5823 ns |
| Int16Auto                     |  7.3177 ns | 0.0414 ns | 0.0367 ns |  7.3112 ns |
| Int1SequentialNoOptimization  |  1.1757 ns | 0.0256 ns | 0.0240 ns |  1.1729 ns |
| Int1ExplicitNoOptimization    |  1.1649 ns | 0.0209 ns | 0.0163 ns |  1.1678 ns |
| Int1AutoNoOptimization        |  1.1799 ns | 0.0181 ns | 0.0169 ns |  1.1762 ns |
| Int4SequentialNoOptimization  |  5.3254 ns | 0.0335 ns | 0.0261 ns |  5.3321 ns |
| Int4ExplicitNoOptimization    |  5.3023 ns | 0.0588 ns | 0.0522 ns |  5.2906 ns |
| Int4AutoNoOptimization        |  5.2442 ns | 0.0717 ns | 0.0671 ns |  5.2121 ns |
| Int16SequentialNoOptimization | 11.2654 ns | 0.0635 ns | 0.0563 ns | 11.2585 ns |
| Int16ExplicitNoOptimization   | 11.6321 ns | 0.1622 ns | 0.1437 ns | 11.5757 ns |
| Int16AutoNoOptimization       | 11.3744 ns | 0.1149 ns | 0.1019 ns | 11.3641 ns |

// * Warnings *
ZeroMeasurement
  StructLayoutsBaseline.Int1Sequential: Default -> The method duration is indistinguishable from the empty method duration
  StructLayoutsBaseline.Int1Explicit: Default   -> The method duration is indistinguishable from the empty method duration
  StructLayoutsBaseline.Int1Auto: Default       -> The method duration is indistinguishable from the empty method duration
  StructLayoutsBaseline.Int4Sequential: Default -> The method duration is indistinguishable from the empty method duration
  StructLayoutsBaseline.Int4Explicit: Default   -> The method duration is indistinguishable from the empty method duration

// * Hints *
Outliers
  StructLayoutsBaseline.Int1Sequential: Default                -> 1 outlier  was  removed (1.57 ns)
  StructLayoutsBaseline.Int1Explicit: Default                  -> 2 outliers were removed (1.56 ns, 1.57 ns)
  StructLayoutsBaseline.Int1Auto: Default                      -> 1 outlier  was  removed (1.56 ns)
  StructLayoutsBaseline.Int4Sequential: Default                -> 1 outlier  was  removed (1.54 ns)
  StructLayoutsBaseline.Int4Auto: Default                      -> 1 outlier  was  removed (1.62 ns)
  StructLayoutsBaseline.Int16Sequential: Default               -> 2 outliers were removed (9.08 ns, 9.13 ns)
  StructLayoutsBaseline.Int16Auto: Default                     -> 1 outlier  was  removed (8.92 ns)
  StructLayoutsBaseline.Int1ExplicitNoOptimization: Default    -> 3 outliers were removed (2.79 ns..2.84 ns)
  StructLayoutsBaseline.Int4SequentialNoOptimization: Default  -> 3 outliers were removed (6.94 ns..6.98 ns)
  StructLayoutsBaseline.Int4ExplicitNoOptimization: Default    -> 1 outlier  was  removed (7.04 ns)
  StructLayoutsBaseline.Int16SequentialNoOptimization: Default -> 1 outlier  was  removed (12.88 ns)
  StructLayoutsBaseline.Int16ExplicitNoOptimization: Default   -> 1 outlier  was  removed (13.68 ns)
  StructLayoutsBaseline.Int16AutoNoOptimization: Default       -> 1 outlier  was  removed (13.93 ns)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 ns   : 1 Nanosecond (0.000000001 sec)

// ***** BenchmarkRunner: End *****
Run time: 00:08:45 (525.5 sec), executed benchmarks: 18

Global total time: 00:09:04 (544.5 sec), executed benchmarks: 18



// * Detailed results *
StructLayoutsBaseline.Int1Sequential: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.006 ns, StdErr = 0.003 ns (60.02%), N = 18, StdDev = 0.015 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.000 ns, Max = 0.048 ns
IQR = 0.000 ns, LowerFence = 0.000 ns, UpperFence = 0.000 ns
ConfidenceInterval = [-0.008 ns; 0.020 ns] (CI 99.9%), Margin = 0.014 ns (237.98% of Mean)
Skewness = 2.2, Kurtosis = 6.15, MValue = 2
-------------------- Histogram --------------------
[-0.003 ns ; 0.011 ns) | @@@@@@@@@@@@@@@@
[ 0.011 ns ; 0.026 ns) |
[ 0.026 ns ; 0.039 ns) |
[ 0.039 ns ; 0.055 ns) | @@
---------------------------------------------------

StructLayoutsBaseline.Int1Explicit: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.010 ns, StdErr = 0.004 ns (42.68%), N = 13, StdDev = 0.015 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.001 ns, Q3 = 0.017 ns, Max = 0.049 ns
IQR = 0.017 ns, LowerFence = -0.025 ns, UpperFence = 0.042 ns
ConfidenceInterval = [-0.008 ns; 0.028 ns] (CI 99.9%), Margin = 0.018 ns (184.30% of Mean)
Skewness = 1.35, Kurtosis = 3.76, MValue = 2
-------------------- Histogram --------------------
[-0.002 ns ; 0.015 ns) | @@@@@@@@@
[ 0.015 ns ; 0.031 ns) | @@@
[ 0.031 ns ; 0.040 ns) |
[ 0.040 ns ; 0.057 ns) | @
---------------------------------------------------

StructLayoutsBaseline.Int1Auto: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.015 ns, StdErr = 0.003 ns (22.17%), N = 14, StdDev = 0.013 ns
Min = 0.000 ns, Q1 = 0.004 ns, Median = 0.014 ns, Q3 = 0.024 ns, Max = 0.039 ns
IQR = 0.020 ns, LowerFence = -0.027 ns, UpperFence = 0.055 ns
ConfidenceInterval = [0.001 ns; 0.030 ns] (CI 99.9%), Margin = 0.014 ns (93.58% of Mean)
Skewness = 0.31, Kurtosis = 1.66, MValue = 2
-------------------- Histogram --------------------
[-0.002 ns ; 0.012 ns) | @@@@@@@
[ 0.012 ns ; 0.029 ns) | @@@@@
[ 0.029 ns ; 0.044 ns) | @@
---------------------------------------------------

StructLayoutsBaseline.Int4Sequential: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.020 ns, StdErr = 0.003 ns (14.11%), N = 14, StdDev = 0.011 ns
Min = 0.003 ns, Q1 = 0.015 ns, Median = 0.019 ns, Q3 = 0.023 ns, Max = 0.039 ns
IQR = 0.008 ns, LowerFence = 0.002 ns, UpperFence = 0.036 ns
ConfidenceInterval = [0.008 ns; 0.032 ns] (CI 99.9%), Margin = 0.012 ns (59.56% of Mean)
Skewness = 0.21, Kurtosis = 2.07, MValue = 2.5
-------------------- Histogram --------------------
[0.001 ns ; 0.013 ns) | @@@
[0.013 ns ; 0.025 ns) | @@@@@@@@
[0.025 ns ; 0.030 ns) |
[0.030 ns ; 0.041 ns) | @@@
---------------------------------------------------

StructLayoutsBaseline.Int4Explicit: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.005 ns, StdErr = 0.002 ns (41.10%), N = 15, StdDev = 0.008 ns
Min = 0.000 ns, Q1 = 0.000 ns, Median = 0.000 ns, Q3 = 0.006 ns, Max = 0.022 ns
IQR = 0.006 ns, LowerFence = -0.010 ns, UpperFence = 0.016 ns
ConfidenceInterval = [-0.003 ns; 0.013 ns] (CI 99.9%), Margin = 0.008 ns (170.17% of Mean)
Skewness = 1.35, Kurtosis = 3.34, MValue = 2.2
-------------------- Histogram --------------------
[-0.002 ns ; 0.006 ns) | @@@@@@@@@@@
[ 0.006 ns ; 0.014 ns) | @@
[ 0.014 ns ; 0.018 ns) |
[ 0.018 ns ; 0.027 ns) | @@
---------------------------------------------------

StructLayoutsBaseline.Int4Auto: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 0.040 ns, StdErr = 0.006 ns (15.23%), N = 14, StdDev = 0.023 ns
Min = 0.011 ns, Q1 = 0.021 ns, Median = 0.037 ns, Q3 = 0.050 ns, Max = 0.084 ns
IQR = 0.029 ns, LowerFence = -0.023 ns, UpperFence = 0.094 ns
ConfidenceInterval = [0.014 ns; 0.066 ns] (CI 99.9%), Margin = 0.026 ns (64.28% of Mean)
Skewness = 0.57, Kurtosis = 1.96, MValue = 2.44
-------------------- Histogram --------------------
[-0.002 ns ; 0.016 ns) | @
[ 0.016 ns ; 0.041 ns) | @@@@@@@@@
[ 0.041 ns ; 0.064 ns) | @
[ 0.064 ns ; 0.089 ns) | @@@
---------------------------------------------------

StructLayoutsBaseline.Int16Sequential: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 7.359 ns, StdErr = 0.019 ns (0.25%), N = 13, StdDev = 0.067 ns
Min = 7.256 ns, Q1 = 7.305 ns, Median = 7.348 ns, Q3 = 7.408 ns, Max = 7.497 ns
IQR = 0.103 ns, LowerFence = 7.151 ns, UpperFence = 7.562 ns
ConfidenceInterval = [7.278 ns; 7.439 ns] (CI 99.9%), Margin = 0.081 ns (1.10% of Mean)
Skewness = 0.38, Kurtosis = 2.07, MValue = 2
-------------------- Histogram --------------------
[7.254 ns ; 7.534 ns) | @@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int16Explicit: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 7.584 ns, StdErr = 0.012 ns (0.16%), N = 15, StdDev = 0.047 ns
Min = 7.521 ns, Q1 = 7.552 ns, Median = 7.582 ns, Q3 = 7.618 ns, Max = 7.693 ns
IQR = 0.066 ns, LowerFence = 7.454 ns, UpperFence = 7.716 ns
ConfidenceInterval = [7.534 ns; 7.634 ns] (CI 99.9%), Margin = 0.050 ns (0.66% of Mean)
Skewness = 0.49, Kurtosis = 2.56, MValue = 2
-------------------- Histogram --------------------
[7.496 ns ; 7.718 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int16Auto: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 7.318 ns, StdErr = 0.010 ns (0.13%), N = 14, StdDev = 0.037 ns
Min = 7.280 ns, Q1 = 7.287 ns, Median = 7.311 ns, Q3 = 7.338 ns, Max = 7.409 ns
IQR = 0.050 ns, LowerFence = 7.212 ns, UpperFence = 7.413 ns
ConfidenceInterval = [7.276 ns; 7.359 ns] (CI 99.9%), Margin = 0.041 ns (0.57% of Mean)
Skewness = 0.93, Kurtosis = 3.16, MValue = 2
-------------------- Histogram --------------------
[7.260 ns ; 7.429 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int1SequentialNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.176 ns, StdErr = 0.006 ns (0.53%), N = 15, StdDev = 0.024 ns
Min = 1.145 ns, Q1 = 1.154 ns, Median = 1.173 ns, Q3 = 1.190 ns, Max = 1.233 ns
IQR = 0.036 ns, LowerFence = 1.100 ns, UpperFence = 1.244 ns
ConfidenceInterval = [1.150 ns; 1.201 ns] (CI 99.9%), Margin = 0.026 ns (2.18% of Mean)
Skewness = 0.61, Kurtosis = 2.76, MValue = 2
-------------------- Histogram --------------------
[1.137 ns ; 1.163 ns) | @@@@@
[1.163 ns ; 1.194 ns) | @@@@@@@
[1.194 ns ; 1.220 ns) | @@
[1.220 ns ; 1.246 ns) | @
---------------------------------------------------

StructLayoutsBaseline.Int1ExplicitNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.165 ns, StdErr = 0.005 ns (0.40%), N = 12, StdDev = 0.016 ns
Min = 1.138 ns, Q1 = 1.153 ns, Median = 1.168 ns, Q3 = 1.172 ns, Max = 1.191 ns
IQR = 0.018 ns, LowerFence = 1.126 ns, UpperFence = 1.199 ns
ConfidenceInterval = [1.144 ns; 1.186 ns] (CI 99.9%), Margin = 0.021 ns (1.79% of Mean)
Skewness = -0.04, Kurtosis = 1.83, MValue = 2
-------------------- Histogram --------------------
[1.135 ns ; 1.158 ns) | @@@@
[1.158 ns ; 1.201 ns) | @@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int1AutoNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.180 ns, StdErr = 0.004 ns (0.37%), N = 15, StdDev = 0.017 ns
Min = 1.154 ns, Q1 = 1.171 ns, Median = 1.176 ns, Q3 = 1.192 ns, Max = 1.206 ns
IQR = 0.021 ns, LowerFence = 1.140 ns, UpperFence = 1.223 ns
ConfidenceInterval = [1.162 ns; 1.198 ns] (CI 99.9%), Margin = 0.018 ns (1.53% of Mean)
Skewness = 0.12, Kurtosis = 1.75, MValue = 2
-------------------- Histogram --------------------
[1.145 ns ; 1.211 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int4SequentialNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.325 ns, StdErr = 0.008 ns (0.14%), N = 12, StdDev = 0.026 ns
Min = 5.287 ns, Q1 = 5.303 ns, Median = 5.332 ns, Q3 = 5.340 ns, Max = 5.362 ns
IQR = 0.038 ns, LowerFence = 5.246 ns, UpperFence = 5.397 ns
ConfidenceInterval = [5.292 ns; 5.359 ns] (CI 99.9%), Margin = 0.033 ns (0.63% of Mean)
Skewness = -0.03, Kurtosis = 1.4, MValue = 2
-------------------- Histogram --------------------
[5.272 ns ; 5.377 ns) | @@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int4ExplicitNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.302 ns, StdErr = 0.014 ns (0.26%), N = 14, StdDev = 0.052 ns
Min = 5.206 ns, Q1 = 5.276 ns, Median = 5.291 ns, Q3 = 5.335 ns, Max = 5.404 ns
IQR = 0.059 ns, LowerFence = 5.188 ns, UpperFence = 5.424 ns
ConfidenceInterval = [5.243 ns; 5.361 ns] (CI 99.9%), Margin = 0.059 ns (1.11% of Mean)
Skewness = 0.23, Kurtosis = 2.39, MValue = 2
-------------------- Histogram --------------------
[5.177 ns ; 5.433 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int4AutoNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 5.244 ns, StdErr = 0.017 ns (0.33%), N = 15, StdDev = 0.067 ns
Min = 5.182 ns, Q1 = 5.187 ns, Median = 5.212 ns, Q3 = 5.308 ns, Max = 5.351 ns
IQR = 0.120 ns, LowerFence = 5.007 ns, UpperFence = 5.488 ns
ConfidenceInterval = [5.173 ns; 5.316 ns] (CI 99.9%), Margin = 0.072 ns (1.37% of Mean)
Skewness = 0.54, Kurtosis = 1.45, MValue = 2
-------------------- Histogram --------------------
[5.166 ns ; 5.375 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int16SequentialNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 11.265 ns, StdErr = 0.015 ns (0.13%), N = 14, StdDev = 0.056 ns
Min = 11.180 ns, Q1 = 11.237 ns, Median = 11.258 ns, Q3 = 11.286 ns, Max = 11.382 ns
IQR = 0.049 ns, LowerFence = 11.163 ns, UpperFence = 11.360 ns
ConfidenceInterval = [11.202 ns; 11.329 ns] (CI 99.9%), Margin = 0.063 ns (0.56% of Mean)
Skewness = 0.47, Kurtosis = 2.43, MValue = 2
-------------------- Histogram --------------------
[11.149 ns ; 11.413 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int16ExplicitNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 11.632 ns, StdErr = 0.038 ns (0.33%), N = 14, StdDev = 0.144 ns
Min = 11.469 ns, Q1 = 11.524 ns, Median = 11.576 ns, Q3 = 11.716 ns, Max = 11.973 ns
IQR = 0.192 ns, LowerFence = 11.237 ns, UpperFence = 12.003 ns
ConfidenceInterval = [11.470 ns; 11.794 ns] (CI 99.9%), Margin = 0.162 ns (1.39% of Mean)
Skewness = 0.82, Kurtosis = 2.73, MValue = 2
-------------------- Histogram --------------------
[11.408 ns ; 12.051 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

StructLayoutsBaseline.Int16AutoNoOptimization: DefaultJob
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 11.374 ns, StdErr = 0.027 ns (0.24%), N = 14, StdDev = 0.102 ns
Min = 11.218 ns, Q1 = 11.312 ns, Median = 11.364 ns, Q3 = 11.421 ns, Max = 11.564 ns
IQR = 0.110 ns, LowerFence = 11.147 ns, UpperFence = 11.586 ns
ConfidenceInterval = [11.259 ns; 11.489 ns] (CI 99.9%), Margin = 0.115 ns (1.01% of Mean)
Skewness = 0.39, Kurtosis = 2.13, MValue = 2
-------------------- Histogram --------------------
[11.162 ns ; 11.620 ns) | @@@@@@@@@@@@@@
---------------------------------------------------
```