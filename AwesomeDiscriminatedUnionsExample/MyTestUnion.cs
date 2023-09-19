using AwesomeDiscriminatedUnions;

namespace AwesomeDiscriminatedUnionsExample;

[DiscriminatedUnionType(typeof(int))]
[DiscriminatedUnionType(typeof(long))]
[DiscriminatedUnionType(typeof(double))]
[DiscriminatedUnionType(typeof(string))]
[DiscriminatedUnionType(typeof(MyTestClass))]
[DiscriminatedUnionType(typeof(MyTestStruct))]
internal readonly ref partial struct MyTestUnion
{
}
