using System.Collections.Generic;

namespace NamedDiscriminatedUnions.Example;

[DiscriminatedUnion]
internal readonly partial struct MyTestUnion<T>
    where T : struct
{
    private readonly int? myInt;
    [DisallowNull] private readonly HashSet<int>? hashSetInt;
    private readonly HashSet<T> hashSetT;
    private readonly T myT;
    private readonly long myLong;
    private readonly double myDouble;
    private readonly string someString;
    private readonly MyTestClass? myTestClass;
    private readonly MyTestStruct myTestStruct;
}
