using NamedDiscriminatedUnions.Generators;
using Xunit.Abstractions;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class CouldBeNullTests
{
    public record struct CouldBeNullDummy(string FullTypeName, bool IsValueType) : ICouldBeNull, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FullTypeName = info.GetValue<string>(nameof(FullTypeName));
            IsValueType = info.GetValue<bool>(nameof(IsValueType));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FullTypeName), FullTypeName);
            info.AddValue(nameof(IsValueType), IsValueType);
        }
    }

    [Theory]
    [MemberData(nameof(GetCouldBeNullParameters))]
    internal static void CouldBeNull(CouldBeNullParameters parameters)
    {
        var res = BaseGenerator.CouldBeNull(parameters.CouldBeNullDummy);

        res.Should().Be(parameters.Expected);
    }

    public record struct CouldBeNullParameters(CouldBeNullDummy CouldBeNullDummy, bool Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            CouldBeNullDummy = info.GetValue<CouldBeNullDummy>(nameof(CouldBeNullDummy));
            Expected = info.GetValue<bool>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(CouldBeNullDummy), CouldBeNullDummy);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<CouldBeNullParameters> GetCouldBeNullParameters()
    {
        return new()
        {
            { new (new("int", true), false) },
            { new (new("int?", true), true) },
            { new (new("System.Collections.Generic.HashSet<int>", false), true) },
            { new (new("System.Collections.Generic.HashSet<int>?", false), true) },
            { new (new("TAny", false), true) }, // no constraints
            { new (new("TAny?", false), true) }, // no constraints
            { new (new("TStruct", true), false) }, // where T : struct
            { new (new("TStruct?", true), true) }, // where T : struct
            { new (new("TClass", false), true) }, // where T : class
            { new (new("TClass?", false), true) }, // where T : class
        };
    }
}
