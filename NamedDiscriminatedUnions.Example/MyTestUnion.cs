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
    //private readonly Test2? test;
    //private readonly int? myInt;
    //[DisallowNull] private readonly HashSet<int>? hashSetInt;
    //private readonly HashSet<T> hashSetT;
    //private readonly HashSet<string> hashSetString;
    //private readonly List<Test2> listTest1;
    //private readonly List<Test2?> listTest2;
    //private readonly T myT;
    //private readonly long myLong;
    //private readonly double myDouble;
    //private readonly string someString;
    //private readonly MyTestClass? myTestClass;
    //private readonly MyTestStruct myTestStruct;
}
