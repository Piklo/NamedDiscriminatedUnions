The point of those benchmarks was to compare the performance of exceptions and result types

`dotnet run -c release -- -m`

```
// * Summary *

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


| Method         | ErrorEveryNth | Mean         | Error      | StdDev     | Ratio    | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------- |-------------- |-------------:|-----------:|-----------:|---------:|--------:|-------:|----------:|------------:|
| WithResult     | 0             |     4.561 ns |  0.0199 ns |  0.0186 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 0             |     1.428 ns |  0.0235 ns |  0.0208 ns |     0.31 |    0.01 |      - |         - |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 1             |     4.626 ns |  0.0103 ns |  0.0091 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 1             | 6,893.162 ns | 94.0006 ns | 83.3291 ns | 1,490.23 |   18.89 | 0.0534 |     344 B |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 2             |     4.756 ns |  0.0595 ns |  0.0527 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 2             | 3,522.210 ns | 46.4666 ns | 60.4197 ns |   741.25 |   16.01 | 0.0267 |     172 B |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 5             |     4.712 ns |  0.0551 ns |  0.0515 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 5             | 1,390.261 ns |  7.6304 ns |  6.3718 ns |   295.39 |    3.58 | 0.0095 |      69 B |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 10            |     4.628 ns |  0.0700 ns |  0.0620 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 10            |   702.080 ns | 13.9481 ns | 14.9243 ns |   152.03 |    3.88 | 0.0048 |      34 B |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 50            |     4.579 ns |  0.0243 ns |  0.0227 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 50            |   136.792 ns |  0.5673 ns |  0.4737 ns |    29.86 |    0.15 | 0.0010 |       7 B |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 100           |     4.611 ns |  0.0346 ns |  0.0324 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 100           |    69.553 ns |  0.5152 ns |  0.4567 ns |    15.09 |    0.17 | 0.0005 |       3 B |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 1000          |     4.704 ns |  0.0596 ns |  0.0529 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 1000          |     8.520 ns |  0.1532 ns |  0.1358 ns |     1.81 |    0.04 | 0.0000 |         - |          NA |
|                |               |              |            |            |          |         |        |           |             |
| WithResult     | 10000         |     4.515 ns |  0.0171 ns |  0.0152 ns |     1.00 |    0.00 |      - |         - |          NA |
| WithExceptions | 10000         |     2.150 ns |  0.0268 ns |  0.0251 ns |     0.48 |    0.00 | 0.0000 |         - |          NA |

// * Hints *
Outliers
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 1 outlier  was  removed (3.03 ns)
  ExceptionsVsResultBenchmarks.WithResult: Default     -> 1 outlier  was  removed (6.15 ns)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 1 outlier  was  removed (10.21 us)
  ExceptionsVsResultBenchmarks.WithResult: Default     -> 1 outlier  was  removed (6.39 ns)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 7 outliers were removed (3.93 us..4.22 us)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 2 outliers were removed (1.41 us, 1.43 us)
  ExceptionsVsResultBenchmarks.WithResult: Default     -> 1 outlier  was  removed (6.40 ns)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 2 outliers were removed (804.62 ns, 1.01 us)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 2 outliers were removed (140.40 ns, 140.54 ns)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 1 outlier  was  removed (73.49 ns)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 1 outlier  was  removed (10.99 ns)
  ExceptionsVsResultBenchmarks.WithResult: Default     -> 1 outlier  was  removed (6.06 ns)
  ExceptionsVsResultBenchmarks.WithExceptions: Default -> 1 outlier  was  detected (3.59 ns)

// * Legends *
  ErrorEveryNth : Value of the 'ErrorEveryNth' parameter
  Mean          : Arithmetic mean of all measurements
  Error         : Half of 99.9% confidence interval
  StdDev        : Standard deviation of all measurements
  Ratio         : Mean of the ratio distribution ([Current]/[Baseline])
  RatioSD       : Standard deviation of the ratio distribution ([Current]/[Baseline])
  Gen0          : GC Generation 0 collects per 1000 operations
  Allocated     : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  Alloc Ratio   : Allocated memory ratio distribution ([Current]/[Baseline])
  1 ns          : 1 Nanosecond (0.000000001 sec)

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:07:45 (465.25 sec), executed benchmarks: 18

Global total time: 00:08:04 (484.15 sec), executed benchmarks: 18
// * Detailed results *
ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=0]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.561 ns, StdErr = 0.005 ns (0.11%), N = 15, StdDev = 0.019 ns
Min = 4.539 ns, Q1 = 4.545 ns, Median = 4.554 ns, Q3 = 4.575 ns, Max = 4.595 ns
IQR = 0.029 ns, LowerFence = 4.502 ns, UpperFence = 4.618 ns
ConfidenceInterval = [4.541 ns; 4.580 ns] (CI 99.9%), Margin = 0.020 ns (0.44% of Mean)
Skewness = 0.45, Kurtosis = 1.55, MValue = 2
-------------------- Histogram --------------------
[4.529 ns ; 4.605 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=0]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.428 ns, StdErr = 0.006 ns (0.39%), N = 14, StdDev = 0.021 ns
Min = 1.391 ns, Q1 = 1.416 ns, Median = 1.432 ns, Q3 = 1.443 ns, Max = 1.462 ns
IQR = 0.027 ns, LowerFence = 1.376 ns, UpperFence = 1.483 ns
ConfidenceInterval = [1.405 ns; 1.452 ns] (CI 99.9%), Margin = 0.024 ns (1.65% of Mean)
Skewness = -0.27, Kurtosis = 1.84, MValue = 2
-------------------- Histogram --------------------
[1.380 ns ; 1.422 ns) | @@@@@
[1.422 ns ; 1.474 ns) | @@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=1]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.626 ns, StdErr = 0.002 ns (0.05%), N = 14, StdDev = 0.009 ns
Min = 4.614 ns, Q1 = 4.620 ns, Median = 4.622 ns, Q3 = 4.630 ns, Max = 4.646 ns
IQR = 0.010 ns, LowerFence = 4.604 ns, UpperFence = 4.645 ns
ConfidenceInterval = [4.615 ns; 4.636 ns] (CI 99.9%), Margin = 0.010 ns (0.22% of Mean)
Skewness = 0.94, Kurtosis = 2.78, MValue = 2
-------------------- Histogram --------------------
[4.609 ns ; 4.651 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=1]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 6.893 us, StdErr = 0.022 us (0.32%), N = 14, StdDev = 0.083 us
Min = 6.825 us, Q1 = 6.837 us, Median = 6.855 us, Q3 = 6.917 us, Max = 7.085 us
IQR = 0.079 us, LowerFence = 6.718 us, UpperFence = 7.036 us
ConfidenceInterval = [6.799 us; 6.987 us] (CI 99.9%), Margin = 0.094 us (1.36% of Mean)
Skewness = 1.07, Kurtosis = 2.68, MValue = 2
-------------------- Histogram --------------------
[6.797 us ; 7.117 us) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=2]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.756 ns, StdErr = 0.014 ns (0.30%), N = 14, StdDev = 0.053 ns
Min = 4.683 ns, Q1 = 4.718 ns, Median = 4.745 ns, Q3 = 4.788 ns, Max = 4.885 ns
IQR = 0.070 ns, LowerFence = 4.612 ns, UpperFence = 4.894 ns
ConfidenceInterval = [4.697 ns; 4.816 ns] (CI 99.9%), Margin = 0.059 ns (1.25% of Mean)
Skewness = 0.79, Kurtosis = 3.05, MValue = 2
-------------------- Histogram --------------------
[4.681 ns ; 4.914 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=2]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 3.522 us, StdErr = 0.012 us (0.35%), N = 24, StdDev = 0.060 us
Min = 3.445 us, Q1 = 3.477 us, Median = 3.524 us, Q3 = 3.540 us, Max = 3.735 us
IQR = 0.063 us, LowerFence = 3.382 us, UpperFence = 3.635 us
ConfidenceInterval = [3.476 us; 3.569 us] (CI 99.9%), Margin = 0.046 us (1.32% of Mean)
Skewness = 1.64, Kurtosis = 6.77, MValue = 2
-------------------- Histogram --------------------
[3.433 us ; 3.513 us) | @@@@@@@@@@
[3.513 us ; 3.627 us) | @@@@@@@@@@@@@
[3.627 us ; 3.762 us) | @
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=5]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.712 ns, StdErr = 0.013 ns (0.28%), N = 15, StdDev = 0.052 ns
Min = 4.619 ns, Q1 = 4.675 ns, Median = 4.698 ns, Q3 = 4.745 ns, Max = 4.795 ns
IQR = 0.070 ns, LowerFence = 4.570 ns, UpperFence = 4.850 ns
ConfidenceInterval = [4.657 ns; 4.767 ns] (CI 99.9%), Margin = 0.055 ns (1.17% of Mean)
Skewness = 0.13, Kurtosis = 1.83, MValue = 2
-------------------- Histogram --------------------
[4.591 ns ; 4.822 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=5]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 1.390 us, StdErr = 0.002 us (0.13%), N = 13, StdDev = 0.006 us
Min = 1.377 us, Q1 = 1.387 us, Median = 1.390 us, Q3 = 1.396 us, Max = 1.398 us
IQR = 0.009 us, LowerFence = 1.374 us, UpperFence = 1.409 us
ConfidenceInterval = [1.383 us; 1.398 us] (CI 99.9%), Margin = 0.008 us (0.55% of Mean)
Skewness = -0.55, Kurtosis = 2.12, MValue = 2
-------------------- Histogram --------------------
[1.373 us ; 1.401 us) | @@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=10]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.628 ns, StdErr = 0.017 ns (0.36%), N = 14, StdDev = 0.062 ns
Min = 4.561 ns, Q1 = 4.580 ns, Median = 4.608 ns, Q3 = 4.672 ns, Max = 4.756 ns
IQR = 0.092 ns, LowerFence = 4.442 ns, UpperFence = 4.810 ns
ConfidenceInterval = [4.558 ns; 4.698 ns] (CI 99.9%), Margin = 0.070 ns (1.51% of Mean)
Skewness = 0.69, Kurtosis = 2.01, MValue = 2
-------------------- Histogram --------------------
[4.544 ns ; 4.789 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=10]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 702.080 ns, StdErr = 3.518 ns (0.50%), N = 18, StdDev = 14.924 ns
Min = 685.780 ns, Q1 = 690.230 ns, Median = 695.717 ns, Q3 = 713.372 ns, Max = 732.747 ns
IQR = 23.142 ns, LowerFence = 655.517 ns, UpperFence = 748.085 ns
ConfidenceInterval = [688.131 ns; 716.028 ns] (CI 99.9%), Margin = 13.948 ns (1.99% of Mean)
Skewness = 0.71, Kurtosis = 2.04, MValue = 2
-------------------- Histogram --------------------
[683.412 ns ; 701.041 ns) | @@@@@@@@@@
[701.041 ns ; 715.989 ns) | @@@@@
[715.989 ns ; 735.781 ns) | @@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=50]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.579 ns, StdErr = 0.006 ns (0.13%), N = 15, StdDev = 0.023 ns
Min = 4.552 ns, Q1 = 4.561 ns, Median = 4.573 ns, Q3 = 4.593 ns, Max = 4.628 ns
IQR = 0.031 ns, LowerFence = 4.514 ns, UpperFence = 4.640 ns
ConfidenceInterval = [4.554 ns; 4.603 ns] (CI 99.9%), Margin = 0.024 ns (0.53% of Mean)
Skewness = 0.76, Kurtosis = 2.33, MValue = 2
-------------------- Histogram --------------------
[4.540 ns ; 4.641 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=50]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 136.792 ns, StdErr = 0.131 ns (0.10%), N = 13, StdDev = 0.474 ns
Min = 136.250 ns, Q1 = 136.474 ns, Median = 136.616 ns, Q3 = 136.963 ns, Max = 137.962 ns
IQR = 0.489 ns, LowerFence = 135.741 ns, UpperFence = 137.696 ns
ConfidenceInterval = [136.225 ns; 137.360 ns] (CI 99.9%), Margin = 0.567 ns (0.41% of Mean)
Skewness = 1.07, Kurtosis = 3.27, MValue = 2
-------------------- Histogram --------------------
[135.986 ns ; 138.226 ns) | @@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=100]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.611 ns, StdErr = 0.008 ns (0.18%), N = 15, StdDev = 0.032 ns
Min = 4.559 ns, Q1 = 4.582 ns, Median = 4.616 ns, Q3 = 4.628 ns, Max = 4.666 ns
IQR = 0.045 ns, LowerFence = 4.515 ns, UpperFence = 4.695 ns
ConfidenceInterval = [4.576 ns; 4.645 ns] (CI 99.9%), Margin = 0.035 ns (0.75% of Mean)
Skewness = 0.08, Kurtosis = 1.7, MValue = 2
-------------------- Histogram --------------------
[4.542 ns ; 4.667 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=100]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 69.553 ns, StdErr = 0.122 ns (0.18%), N = 14, StdDev = 0.457 ns
Min = 69.082 ns, Q1 = 69.235 ns, Median = 69.357 ns, Q3 = 69.671 ns, Max = 70.462 ns
IQR = 0.436 ns, LowerFence = 68.581 ns, UpperFence = 70.325 ns
ConfidenceInterval = [69.038 ns; 70.068 ns] (CI 99.9%), Margin = 0.515 ns (0.74% of Mean)
Skewness = 0.95, Kurtosis = 2.28, MValue = 2
-------------------- Histogram --------------------
[68.834 ns ; 70.711 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=1000]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.704 ns, StdErr = 0.014 ns (0.30%), N = 14, StdDev = 0.053 ns
Min = 4.625 ns, Q1 = 4.677 ns, Median = 4.704 ns, Q3 = 4.719 ns, Max = 4.812 ns
IQR = 0.043 ns, LowerFence = 4.613 ns, UpperFence = 4.783 ns
ConfidenceInterval = [4.645 ns; 4.764 ns] (CI 99.9%), Margin = 0.060 ns (1.27% of Mean)
Skewness = 0.43, Kurtosis = 2.31, MValue = 2
-------------------- Histogram --------------------
[4.596 ns ; 4.745 ns) | @@@@@@@@@@@
[4.745 ns ; 4.841 ns) | @@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=1000]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 8.520 ns, StdErr = 0.036 ns (0.43%), N = 14, StdDev = 0.136 ns
Min = 8.385 ns, Q1 = 8.407 ns, Median = 8.495 ns, Q3 = 8.585 ns, Max = 8.800 ns
IQR = 0.178 ns, LowerFence = 8.139 ns, UpperFence = 8.853 ns
ConfidenceInterval = [8.367 ns; 8.674 ns] (CI 99.9%), Margin = 0.153 ns (1.80% of Mean)
Skewness = 0.71, Kurtosis = 2.11, MValue = 2
-------------------- Histogram --------------------
[8.361 ns ; 8.854 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithResult: DefaultJob [ErrorEveryNth=10000]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 4.515 ns, StdErr = 0.004 ns (0.09%), N = 14, StdDev = 0.015 ns
Min = 4.501 ns, Q1 = 4.504 ns, Median = 4.509 ns, Q3 = 4.523 ns, Max = 4.546 ns
IQR = 0.018 ns, LowerFence = 4.477 ns, UpperFence = 4.550 ns
ConfidenceInterval = [4.498 ns; 4.533 ns] (CI 99.9%), Margin = 0.017 ns (0.38% of Mean)
Skewness = 0.93, Kurtosis = 2.47, MValue = 2
-------------------- Histogram --------------------
[4.493 ns ; 4.554 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

ExceptionsVsResultBenchmarks.WithExceptions: DefaultJob [ErrorEveryNth=10000]
Runtime = .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 2.150 ns, StdErr = 0.006 ns (0.30%), N = 15, StdDev = 0.025 ns
Min = 2.094 ns, Q1 = 2.140 ns, Median = 2.148 ns, Q3 = 2.170 ns, Max = 2.189 ns
IQR = 0.030 ns, LowerFence = 2.095 ns, UpperFence = 2.214 ns
ConfidenceInterval = [2.124 ns; 2.177 ns] (CI 99.9%), Margin = 0.027 ns (1.25% of Mean)
Skewness = -0.64, Kurtosis = 2.61, MValue = 2
-------------------- Histogram --------------------
[2.080 ns ; 2.124 ns) | @@
[2.124 ns ; 2.202 ns) | @@@@@@@@@@@@@
---------------------------------------------------
```