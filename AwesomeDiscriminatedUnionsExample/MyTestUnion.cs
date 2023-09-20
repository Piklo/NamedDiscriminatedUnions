using AwesomeDiscriminatedUnions;

namespace AwesomeDiscriminatedUnionsExample;

[DiscriminatedUnionType(typeof(int))]
[DiscriminatedUnionType(typeof(long))]
[DiscriminatedUnionType(typeof(double))]
[DiscriminatedUnionType(typeof(string))]
[DiscriminatedUnionType(typeof(MyTestClass))]
[DiscriminatedUnionType(typeof(MyTestStruct))]
[DiscriminatedUnionGetHashCode(DiscriminatedUnionGetHashCodeType.Strict)]
internal partial struct MyTestUnion
{
}
