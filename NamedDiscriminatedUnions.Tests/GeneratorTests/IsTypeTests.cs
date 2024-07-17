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

    public record struct NotNullAttribute(string FullTypeName, bool IsValueType, AllowNullableType AllowNullableInFromMethods) : INotNullAttribute, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FullTypeName = info.GetValue<string>(nameof(FullTypeName));
            IsValueType = info.GetValue<bool>(nameof(IsValueType));
            AllowNullableInFromMethods = info.GetValue<AllowNullableType>(nameof(AllowNullableInFromMethods));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FullTypeName), FullTypeName);
            info.AddValue(nameof(IsValueType), IsValueType);
            info.AddValue(nameof(AllowNullableInFromMethods), AllowNullableInFromMethods);
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
            new(new("int", true, AllowNullableType.ImplicitNo), false),
            new(new("int", true, AllowNullableType.ExplicitNo), false),
            new(new("int", true, AllowNullableType.ExplicitNoThrowIfNull), false),
            new(new("int?", true, AllowNullableType.ExplicitYes), false),
            new(new("int?", true, AllowNullableType.ExplicitNo), false),
            new(new("int?", true, AllowNullableType.ExplicitNoThrowIfNull), true),

            new(new("System.Collections.Generic.HashSet<int>", false, AllowNullableType.ImplicitYes), false),
            new(new("System.Collections.Generic.HashSet<int>", false, AllowNullableType.ExplicitNo), false),
            new(new("System.Collections.Generic.HashSet<int>", false, AllowNullableType.ExplicitNoThrowIfNull), true),
            new(new("System.Collections.Generic.HashSet<int>?", false, AllowNullableType.ExplicitYes), false),
            new(new("System.Collections.Generic.HashSet<int>?", false, AllowNullableType.ExplicitNo), false),
            new(new("System.Collections.Generic.HashSet<int>?", false, AllowNullableType.ExplicitNoThrowIfNull), true),

            // no constraints
            new(new("TAny", false, AllowNullableType.ImplicitYes), false),
            new(new("TAny", false, AllowNullableType.ExplicitNo), false),
            new(new("TAny", false, AllowNullableType.ExplicitNoThrowIfNull), true),
            new(new("TAny?", false, AllowNullableType.ExplicitYes), false),
            new(new("TAny?", false, AllowNullableType.ExplicitNo), false),
            new(new("TAny?", false, AllowNullableType.ExplicitNoThrowIfNull), true),

            // where T : struct
            new(new("TStruct", true, AllowNullableType.ImplicitNo), false),
            new(new("TStruct", true, AllowNullableType.ExplicitNo), false),
            new(new("TStruct", true, AllowNullableType.ExplicitNoThrowIfNull), false),
            new(new("TStruct?", true, AllowNullableType.ExplicitYes), false),
            new(new("TStruct?", true, AllowNullableType.ExplicitNo), false),
            new(new("TStruct?", true, AllowNullableType.ExplicitNoThrowIfNull), true),

            // where T : class
            new(new("TClass", false, AllowNullableType.ImplicitYes), false),
            new(new("TClass", false, AllowNullableType.ExplicitNo), false),
            new(new("TClass", false, AllowNullableType.ExplicitNoThrowIfNull), true),
            new(new("TClass?", false, AllowNullableType.ExplicitYes), false),
            new(new("TClass?", false, AllowNullableType.ExplicitNo), false),
            new(new("TClass?", false, AllowNullableType.ExplicitNoThrowIfNull), true),
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

    [Theory]
    [MemberData(nameof(GetAppendIsTypeMethodWithOutParameters))]
    public static void AppendIsTypeMethodWithOut(AppendIsTypeMethodWithOutParameter parameters)
    {
        using var writer = Helper.GetIndentedTextWriter();

        BaseGenerator.AppendIsTypeMethodWithOut(writer, parameters.FieldName, parameters.TagName, parameters.ParameterType, parameters.CanUseNotNullWhenAttribute);
        var str = writer.InnerWriter.ToString();

        str.Should().Be(parameters.Expected);
    }

    public record struct AppendIsTypeMethodWithOutParameter(string FieldName, string TagName, string ParameterType, bool CanUseNotNullWhenAttribute, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FieldName = info.GetValue<string>(nameof(FieldName));
            TagName = info.GetValue<string>(nameof(TagName));
            ParameterType = info.GetValue<string>(nameof(ParameterType));
            CanUseNotNullWhenAttribute = info.GetValue<bool>(nameof(CanUseNotNullWhenAttribute));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FieldName), FieldName);
            info.AddValue(nameof(TagName), TagName);
            info.AddValue(nameof(ParameterType), ParameterType);
            info.AddValue(nameof(CanUseNotNullWhenAttribute), CanUseNotNullWhenAttribute);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<AppendIsTypeMethodWithOutParameter> GetAppendIsTypeMethodWithOutParameters()
    {
        return new()
        {
            new("value", "Value", "int", false,
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
            new("value", "Value", "int?", false,
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
            new("value", "Value", "int?", true,
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
