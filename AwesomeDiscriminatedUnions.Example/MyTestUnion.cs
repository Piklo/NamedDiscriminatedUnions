using AwesomeDiscriminatedUnions.Attributes;
using System.Collections.Generic;

namespace AwesomeDiscriminatedUnions.Example;

[DiscriminatedUnion]
internal readonly partial struct MyTestUnion<T>
    where T : struct
{
    private readonly HashSet<int> hashSetInt;
    private readonly HashSet<T> hashSetT;
    private readonly T myT;
    private readonly int myInt;
    private readonly long myLong;
    private readonly double myDouble;
    private readonly string someString;
    private readonly MyTestClass? myTestClass;
    private readonly MyTestStruct myTestStruct;
}
