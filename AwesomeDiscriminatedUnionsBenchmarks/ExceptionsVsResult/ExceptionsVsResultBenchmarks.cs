using AwesomeDiscriminatedUnions;
using BenchmarkDotNet.Attributes;

namespace AwesomeDiscriminatedUnionsBenchmarks.ExceptionsVsResult;

[DiscriminatedUnion]
[DiscriminatedUnionType(typeof(int))]
[DiscriminatedUnionType(typeof(Error))]
public readonly partial struct Result
{

}

public readonly struct Error
{
}

public sealed class MultiplierWithResult
{
    private int _counter;
    private readonly int _initial;

    public MultiplierWithResult(int initial)
    {
        _counter = initial;
        _initial = initial;
    }

    public Result Multiply(int value)
    {
        _counter--;
        if (_counter == 0)
        {
            _counter = _initial;
            return new Error();
        }

        return 2 * value;
    }
}

public sealed class MultiplierWithExceptions
{
    private int _counter;
    private readonly int _initial;

    public MultiplierWithExceptions(int initial)
    {
        _counter = initial;
        _initial = initial;
    }

    public int Multiply(int value)
    {
        _counter--;
        if (_counter == 0)
        {
            _counter = _initial;
            throw new Exception();
        }

        return 2 * value;
    }
}

[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class ExceptionsVsResultBenchmarks
{
    private MultiplierWithResult withResult = default!;
    private MultiplierWithExceptions withExceptions = default!;
    private const int valueToMultiply = 5;

    [Params(0, 1, 2, 5, 10, 50, 100, 1_000, 10_000)]
    public int ErrorEveryNth { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        withResult = new(ErrorEveryNth);
        withExceptions = new(ErrorEveryNth);
    }

    [Benchmark(Baseline = true)]
    public int WithResult()
    {
        var result = withResult.Multiply(valueToMultiply);
        if (result.IsInt(out var value))
        {
            return value;
        }

        return -1;
    }

    [Benchmark]
    public int WithExceptions()
    {
        try
        {
            var value = withExceptions.Multiply(valueToMultiply);
            return value;
        }
        catch (Exception)
        {
            return -1;
        }
    }
}
