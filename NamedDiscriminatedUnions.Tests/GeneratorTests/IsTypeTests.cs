using NamedDiscriminatedUnions.Generators;
using Xunit.Abstractions;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class IsTypeTests
{
    public record struct TagEnumData(string FieldName) : ITagEnumData, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FieldName = info.GetValue<string>(nameof(FieldName));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FieldName), FieldName);
        }
    }

    [Theory]
    [MemberData(nameof(GetAppendIsTypeMethodWithoutOutParameters))]
    public static void AppendIsTypeMethodWithoutOut(AppendIsTypeMethodWithoutOutParameter parameter)
    {
        using var writer = Helper.GetIndentedTextWriter();

        BaseGenerator.AppendIsTypeMethodWithoutOut(writer, parameter.TagEnumData);
        var str = writer.InnerWriter.ToString();

        str.Should().Be(parameter.Expected);
    }

    public record struct AppendIsTypeMethodWithoutOutParameter(TagEnumData TagEnumData, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            TagEnumData = info.GetValue<TagEnumData>(nameof(TagEnumData));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(TagEnumData), TagEnumData);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<AppendIsTypeMethodWithoutOutParameter> GetAppendIsTypeMethodWithoutOutParameters()
    {
        return new()
        {
            new(new("value"),
            """
            public readonly bool IsValue()
            {
                return tag == Tag.Value;
            }


            """)
        };
    }
}
