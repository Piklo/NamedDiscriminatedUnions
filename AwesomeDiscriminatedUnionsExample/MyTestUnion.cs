using AwesomeDiscriminatedUnions;

namespace AwesomeDiscriminatedUnionsExample;

[DiscriminatedUnion()]
[DiscriminatedUnionType(typeof(int))]
[DiscriminatedUnionType(typeof(long))]
[DiscriminatedUnionType(typeof(double))]
[DiscriminatedUnionType(typeof(string))]
[DiscriminatedUnionType(typeof(MyTestClass))]
[DiscriminatedUnionType(typeof(MyTestStruct))]
internal partial struct MyTestUnion
{
}
