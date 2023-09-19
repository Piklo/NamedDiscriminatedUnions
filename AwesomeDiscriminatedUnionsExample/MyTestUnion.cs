using AwesomeDiscriminatedUnions;
using System;

namespace AwesomeDiscriminatedUnionsExample;

[DiscriminatedUnionType(typeof(int))]
[DiscriminatedUnionType(typeof(long))]
[DiscriminatedUnionType(typeof(double))]
[DiscriminatedUnionType(typeof(string))]
[DiscriminatedUnionType(typeof(MyTestClass))]
[DiscriminatedUnionType(typeof(MyTestStruct))]
internal readonly ref partial struct MyTestUnion
{

    public TResult Match<TResult>(Func<int, TResult> processInt)
    {
        return processInt(_int);
    }
}
