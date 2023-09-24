using BenchmarkDotNet.Attributes;
using Perfolizer.Mathematics.OutlierDetection;

namespace AwesomeDiscriminatedUnionsBenchmarks.ByteVsInt;

[MemoryDiagnoser]
//[MaxRelativeError(0.001)]
[AllStatisticsColumn]
[Outliers(OutlierMode.RemoveAll)]
public class ByteVsIntBenchmarks
{
    [Benchmark]
    public ByteTag ByteTag()
    {
        var obj = new ByteTag(byte.MaxValue, int.MaxValue); ;
        return obj;
    }

    [Benchmark]
    public IntTag IntTag()
    {
        var obj = new IntTag(int.MaxValue, int.MaxValue);
        return obj;
    }
}
public readonly struct ByteTag
{
    private readonly byte _tag;
    private readonly int _value;
    public readonly byte Tag => _tag;
    public readonly int Value => _value;

    public ByteTag(byte tag, int value)
    {
        _tag = tag;
        _value = value;
    }
}

public readonly struct IntTag
{
    private readonly int _tag;
    private readonly int _value;
    public readonly int Tag => _tag;
    public readonly int Value => _value;

    public IntTag(int tag, int value)
    {
        _tag = tag;
        _value = value;
    }
}