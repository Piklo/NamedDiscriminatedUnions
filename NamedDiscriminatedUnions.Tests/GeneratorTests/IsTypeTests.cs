using NamedDiscriminatedUnions.Generators;
using NamedDiscriminatedUnions.ParsedTypeStuff;
using Xunit.Abstractions;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class IsTypeTests
{
    public record struct TagEnumData(string FieldName) : IFieldName, IXunitSerializable
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

    public record struct NotNullAttribute(DisallowNullStatus DisallowNullStatus) : IDisallowNullStatus, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            DisallowNullStatus = info.GetValue<DisallowNullStatus>(nameof(DisallowNullStatus));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(DisallowNullStatus), DisallowNullStatus);
        }
    }

    [Theory]
    [MemberData(nameof(GetCanUseNotNullWhenAttributeParameters))]
    public static void CanUseNotNullWhenAttribute(CanUseNotNullWhenAttributeParameter parameters)
    {
        var res = BaseGenerator.CanUseNotNullWhenAttribute(parameters.NotNullAttribute);

        res.Should().Be(parameters.Expected);
    }

    public record struct CanUseNotNullWhenAttributeParameter(NotNullAttribute NotNullAttribute, bool Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            NotNullAttribute = info.GetValue<NotNullAttribute>(nameof(NotNullAttribute));
            Expected = info.GetValue<bool>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(NotNullAttribute), NotNullAttribute);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<CanUseNotNullWhenAttributeParameter> GetCanUseNotNullWhenAttributeParameters()
    {
        return new()
        {
            new(new(DisallowNullStatus.None), false),
            new(new(DisallowNullStatus.ExistsAllowsNull), false),
            new(new(DisallowNullStatus.ExistsThrowsIfNull), true),
        };
    }

    [Theory]
    [MemberData(nameof(GetCanUseNotNullWhenAttributeParameters))]
    public static void GetNotNullAttribute(CanUseNotNullWhenAttributeParameter parameters)
    {
        var res = BaseGenerator.GetNotNullAttribute(parameters.NotNullAttribute);

        if (parameters.Expected)
        {
            res.Should().Be("[System.Diagnostics.CodeAnalysis.NotNullWhen(true)] ");
        }
        else
        {
            res.Should().BeEmpty();
        }
    }

    public record struct AppendIsTypeMethodWithOutType(string FullUserTypeName, string FieldName, DisallowNullStatus DisallowNullStatus) : IFieldName, IDisallowNullStatus, IFullUserTypeName, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FullUserTypeName = info.GetValue<string>(nameof(FullUserTypeName));
            FieldName = info.GetValue<string>(nameof(FieldName));
            DisallowNullStatus = info.GetValue<DisallowNullStatus>(nameof(DisallowNullStatus));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FullUserTypeName), FullUserTypeName);
            info.AddValue(nameof(FieldName), FieldName);
            info.AddValue(nameof(DisallowNullStatus), DisallowNullStatus);
        }
    }

    [Theory]
    [MemberData(nameof(GetAppendIsTypeMethodWithOutParameters))]
    public static void AppendIsTypeMethodWithOut(AppendIsTypeMethodWithOutParameter parameters)
    {
        using var writer = Helper.GetIndentedTextWriter();

        BaseGenerator.AppendIsTypeMethodWithOut(writer, parameters.AppendIsTypeMethodWithOutType);
        var str = writer.InnerWriter.ToString();

        str.Should().Be(parameters.Expected);
    }

    public record struct AppendIsTypeMethodWithOutParameter(AppendIsTypeMethodWithOutType AppendIsTypeMethodWithOutType, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            AppendIsTypeMethodWithOutType = info.GetValue<AppendIsTypeMethodWithOutType>(nameof(AppendIsTypeMethodWithOutType));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(AppendIsTypeMethodWithOutType), AppendIsTypeMethodWithOutType);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<AppendIsTypeMethodWithOutParameter> GetAppendIsTypeMethodWithOutParameters()
    {
        return new()
        {
            new(new("int", "value", DisallowNullStatus.None),
@"public readonly bool IsValue(out int value)
{
    if (tag == Tag.Value)
    {
        value = this.value;
        return true;
    }
    
    value = default;
    return false;
}

"),
            new(new("int", "value", DisallowNullStatus.ExistsAllowsNull),
@"public readonly bool IsValue(out int value)
{
    if (tag == Tag.Value)
    {
        value = this.value;
        return true;
    }
    
    value = default;
    return false;
}

"),
            new(new("int", "value", DisallowNullStatus.ExistsThrowsIfNull),
@"public readonly bool IsValue([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out int value)
{
    if (tag == Tag.Value)
    {
        value = this.value!;
        return true;
    }
    
    value = default;
    return false;
}

"),
            new(new("int?", "value", DisallowNullStatus.None),
@"public readonly bool IsValue(out int? value)
{
    if (tag == Tag.Value)
    {
        value = this.value;
        return true;
    }
    
    value = default;
    return false;
}

"),
            new(new("int?", "value", DisallowNullStatus.ExistsAllowsNull),
@"public readonly bool IsValue(out int? value)
{
    if (tag == Tag.Value)
    {
        value = this.value;
        return true;
    }
    
    value = default;
    return false;
}

"),
            new(new("int?", "value", DisallowNullStatus.ExistsThrowsIfNull),
@"public readonly bool IsValue([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out int? value)
{
    if (tag == Tag.Value)
    {
        value = this.value!;
        return true;
    }
    
    value = default;
    return false;
}

"),
        };
    }
}
