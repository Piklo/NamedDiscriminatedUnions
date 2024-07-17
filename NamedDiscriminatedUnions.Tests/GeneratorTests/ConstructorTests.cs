using NamedDiscriminatedUnions.Generators;
using Xunit.Abstractions;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class ConstructorTests
{
    public record struct ConstructorParameter(string FullTypeName, bool IsValueType, string FieldName) : IConstructorParameters, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FullTypeName = info.GetValue<string>(nameof(FullTypeName));
            IsValueType = info.GetValue<bool>(nameof(IsValueType));
            FieldName = info.GetValue<string>(nameof(FieldName));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FullTypeName), FullTypeName);
            info.AddValue(nameof(IsValueType), IsValueType);
            info.AddValue(nameof(FieldName), FieldName);
        }
    }

    [Theory]
    [MemberData(nameof(GetAppendConstructorDeclarationParameters))]
    public static void AppendConstructorDeclaration(AppendConstructorDeclarationParameters parameters)
    {
        using var writer = Helper.GetIndentedTextWriter();

        BaseGenerator.AppendConstructorDeclaration(writer, parameters.TypeName, parameters.ConstructorParameter);
        var str = writer.InnerWriter.ToString();

        str.Should().Be(parameters.Expected);
    }

    public record struct AppendConstructorDeclarationParameters(string TypeName, ConstructorParameter[] ConstructorParameter, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            TypeName = info.GetValue<string>(nameof(TypeName));
            ConstructorParameter = info.GetValue<ConstructorParameter[]>(nameof(ConstructorParameter));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(TypeName), TypeName);
            info.AddValue(nameof(ConstructorParameter), ConstructorParameter);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<AppendConstructorDeclarationParameters> GetAppendConstructorDeclarationParameters()
    {
        return new()
        {
            new("Union",
            [
                new("int", true, "value")
            ],
            """
            private Union(Tag tag, int value)

            """),
            new("Union2",
            [
                new("int?", true, "value2"),
            ],
            """
            private Union2(Tag tag, int? value2)

            """),
            new("Union2",
            [
                new("System.Collections.Generic.HashSet<int>", false, "ints"),
            ],
            """
            private Union2(Tag tag, System.Collections.Generic.HashSet<int>? ints)

            """),
            new("Union2",
            [
                new("System.Collections.Generic.HashSet<int>?", false, "ints"),
            ],
            """
            private Union2(Tag tag, System.Collections.Generic.HashSet<int>? ints)

            """),
            new("Union2",
            [
                new("System.Collections.Generic.HashSet<int>", false, "ints1"),
                new("System.Collections.Generic.HashSet<int>?", false, "ints2"),
            ],
            """
            private Union2(Tag tag, System.Collections.Generic.HashSet<int>? ints1, System.Collections.Generic.HashSet<int>? ints2)

            """),
            new("Union",
            [
                new("TAny", false, "field"), // no constraints
            ],
            """
            private Union(Tag tag, TAny? field)

            """),
            new("Union",
            [
                new("TAny?", false, "field"), // no constraints
            ],
            """
            private Union(Tag tag, TAny? field)

            """),
            new("Union",
            [
                new("TStruct", true, "field"), // where TStruct : struct
            ],
            """
            private Union(Tag tag, TStruct field)

            """),
            new("Union",
            [
                new("TStruct?", true, "field"), // where TStruct : struct
            ],
            """
            private Union(Tag tag, TStruct? field)

            """),
            new("Union",
            [
                new("TClass", false, "field"), // where TClass : class
            ],
            """
            private Union(Tag tag, TClass? field)

            """),
            new("Union",
            [
                new("TClass?", false, "field"), // where TClass : class
            ],
            """
            private Union(Tag tag, TClass? field)

            """),
        };
    }

    public record struct ConstructorTypeParameter(string FullTypeName, bool IsValueType) : ICouldBeNull, IXunitSerializable
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
    [MemberData(nameof(GetGetConstructorParameterTypeStringParameters))]
    public static void GetConstructorParameterTypeString(GetConstructorParameterTypeStringParameters parameters)
    {
        var str = BaseGenerator.GetConstructorParameterTypeString(parameters.ConstructorTypeParameter);

        str.Should().Be(parameters.Expected);
    }

    public record struct GetConstructorParameterTypeStringParameters(ConstructorTypeParameter ConstructorTypeParameter, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            ConstructorTypeParameter = info.GetValue<ConstructorTypeParameter>(nameof(ConstructorTypeParameter));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(ConstructorTypeParameter), ConstructorTypeParameter);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<GetConstructorParameterTypeStringParameters> GetGetConstructorParameterTypeStringParameters()
    {
        return new()
        {
            new(new("int", true), "int"),
            new(new("int?", true), "int?"),
            new(new("System.Collections.Generic.HashSet<int>", false), "System.Collections.Generic.HashSet<int>?"),
            new(new("System.Collections.Generic.HashSet<int>?", false), "System.Collections.Generic.HashSet<int>?"),
            new(new("T", false), "T?"), // no constraints
            new(new("T?", false), "T?"), // no constraints
            new(new("TStruct", true), "TStruct"), // where T : struct
            new(new("TStruct?", true), "TStruct?"), // where T : struct
            new(new("TClass", false), "TClass?"), // where T : class
            new(new("TClass?", false), "TClass?"), // where T : class
        };
    }
}
