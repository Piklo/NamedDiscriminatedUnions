using AwesomeDiscriminatedUnions;
using BenchmarkDotNet.Attributes;
using OneOf;

namespace AwesomeDiscriminatedUnionsBenchmarks.OneOfVsADU;

[DiscriminatedUnion]
[DiscriminatedUnionType(typeof(int))]
public readonly partial struct JustIntUnion
{
}

public class IntOneOfVsADU
{
    [Benchmark]
    public OneOf<int> OneOf()
    {
        OneOf<int> obj = int.MaxValue;
        return obj;
    }

    [Benchmark]
    public JustIntUnion ADU()
    {
        JustIntUnion obj = int.MaxValue;
        return obj;
    }

    [Benchmark]
    public object OneOfBoxed()
    {
        OneOf<int> obj = int.MaxValue;
        object boxed = obj;
        return boxed;
    }

    [Benchmark]
    public object ADUBoxed()
    {
        JustIntUnion obj = int.MaxValue;
        object boxed = obj;
        return boxed;
    }
}
