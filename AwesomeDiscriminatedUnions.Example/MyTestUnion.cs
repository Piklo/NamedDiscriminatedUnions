using AwesomeDiscriminatedUnions.Attributes;
using System.Collections.Generic;

namespace AwesomeDiscriminatedUnions.Example;

[DiscriminatedUnion]
internal readonly partial struct MyTestUnion<T>
    where T : struct
{
    private readonly HashSet<int> _HashSetInt;
    private readonly HashSet<T> _HashSetT;
    private readonly T _MyT;
    private readonly int _int;
    private readonly long _long;
    private readonly double _double;
    private readonly string _string;
    private readonly MyTestClass? _MyTestClass;
    private readonly MyTestStruct _MyTestStruct;
}
