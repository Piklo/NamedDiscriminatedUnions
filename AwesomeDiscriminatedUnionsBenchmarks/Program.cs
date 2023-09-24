using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

var config = ManualConfig.Create(DefaultConfig.Instance);
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
