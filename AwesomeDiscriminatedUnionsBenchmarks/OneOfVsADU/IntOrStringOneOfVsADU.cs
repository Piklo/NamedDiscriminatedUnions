using AwesomeDiscriminatedUnions;
using BenchmarkDotNet.Attributes;
using OneOf;
using Perfolizer.Mathematics.OutlierDetection;

namespace AwesomeDiscriminatedUnionsBenchmarks.OneOfVsADU;

[DiscriminatedUnion]
[DiscriminatedUnionType(typeof(int))]
[DiscriminatedUnionType(typeof(string))]
public readonly partial struct IntOrStringUnion
{
}

[MemoryDiagnoser]
//[MaxRelativeError(0.001)]
[AllStatisticsColumn]
[Outliers(OutlierMode.RemoveAll)]
public class IntOrStringOneOfVsADU
{
    private const string _string = "Hello world";

    [Benchmark]
    public OneOf<int, string> OneOfInt()
    {
        OneOf<int, string> obj = int.MaxValue;
        return obj;
    }
    [Benchmark]
    public OneOf<int, string> OneOfString()
    {
        OneOf<int, string> obj = _string;
        return obj;
    }
    [Benchmark]
    public IntOrStringUnion ADUInt()
    {
        IntOrStringUnion obj = int.MaxValue;
        return obj;
    }
    [Benchmark]
    public IntOrStringUnion ADUString()
    {
        IntOrStringUnion obj = _string;
        return obj;
    }
    [Benchmark]
    public object OneOfIntBoxed()
    {
        OneOf<int, string> value = int.MaxValue;
        return value;
    }
    [Benchmark]
    public object OneOfStringBoxed()
    {
        OneOf<int, string> obj = _string;
        object boxed = obj;
        return boxed;
    }
    [Benchmark]
    public object ADUIntBoxed()
    {
        IntOrStringUnion obj = int.MaxValue;
        object boxed = obj;
        return boxed;
    }
    [Benchmark]
    public object ADUStringBoxed()
    {
        IntOrStringUnion obj = _string;
        object boxed = obj;
        return boxed;
    }
}