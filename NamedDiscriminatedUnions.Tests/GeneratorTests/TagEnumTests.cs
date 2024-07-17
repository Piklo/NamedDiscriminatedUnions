using NamedDiscriminatedUnions.Generators;
using Xunit.Abstractions;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class TagEnumTests
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
    [MemberData(nameof(GetAppendTagsEnumParameters))]
    internal static void AppendTagsEnum(AppendTagsEnumParameters parameters)
    {
        using var writer = Helper.GetIndentedTextWriter();

        BaseGenerator.AppendTagsEnum(writer, parameters.TagEnumData);
        var str = writer.InnerWriter.ToString();

        str.Should().Be(parameters.Expected);
    }

    public record struct AppendTagsEnumParameters(TagEnumData[] TagEnumData, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            TagEnumData = info.GetValue<TagEnumData[]>(nameof(TagEnumData));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(TagEnumData), TagEnumData);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<AppendTagsEnumParameters> GetAppendTagsEnumParameters()
    {
        return new()
        {
            new ([new("value")],"""
            public enum Tag : byte
            {
                Value = 1,
            }


            """),
            new ([new("_value")],"""
            public enum Tag : byte
            {
                _value = 1,
            }


            """),
            new ([new("_value"), new("value2"), new("FuNnYVaLuE")],"""
            public enum Tag : byte
            {
                _value = 1,
                Value2 = 2,
                FuNnYVaLuE = 3,
            }


            """),
        };
    }
}
