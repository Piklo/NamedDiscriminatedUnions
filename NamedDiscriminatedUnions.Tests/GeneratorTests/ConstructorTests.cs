using NamedDiscriminatedUnions.Generators;
using NamedDiscriminatedUnions.ParsedTypeStuff;
using Xunit.Abstractions;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class ConstructorTests
{
    public record struct ConstructorParameter(string FullTypeName, string FieldName) : IFieldName, IFullTypeName, IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            FullTypeName = info.GetValue<string>(nameof(FullTypeName));
            FieldName = info.GetValue<string>(nameof(FieldName));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(FullTypeName), FullTypeName);
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
                new("int", "value")
            ],
            """
            private Union(Tag tag, int value)

            """),
            new("Union2",
            [
                new("int?", "value2"),
            ],
            """
            private Union2(Tag tag, int? value2)

            """),
            new("Union2",
            [
                new("System.Collections.Generic.HashSet<int>?", "ints"),
            ],
            """
            private Union2(Tag tag, System.Collections.Generic.HashSet<int>? ints)

            """),
            new("Union2",
            [
                new("System.Collections.Generic.HashSet<int>?", "ints1"),
                new("System.Collections.Generic.HashSet<int>?", "ints2"),
            ],
            """
            private Union2(Tag tag, System.Collections.Generic.HashSet<int>? ints1, System.Collections.Generic.HashSet<int>? ints2)

            """),
            new("Union",
            [
                new("TAny?", "field"), // no constraints
            ],
            """
            private Union(Tag tag, TAny? field)

            """),
            new("Union",
            [
                new("TStruct", "field"), // where TStruct : struct
            ],
            """
            private Union(Tag tag, TStruct field)

            """),
            new("Union",
            [
                new("TStruct?", "field"), // where TStruct : struct
            ],
            """
            private Union(Tag tag, TStruct? field)

            """),
            new("Union",
            [
                new("TClass?", "field"), // where TClass : class
            ],
            """
            private Union(Tag tag, TClass? field)

            """),
        };
    }

    public record struct ConstructorTypeParameter(string TypeName, bool IsValueType) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            TypeName = info.GetValue<string>(nameof(TypeName));
            IsValueType = info.GetValue<bool>(nameof(IsValueType));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(TypeName), TypeName);
            info.AddValue(nameof(IsValueType), IsValueType);
        }
    }

    public record struct ConstructorBody(string FieldName) : IFieldName, IXunitSerializable
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
    [MemberData(nameof(GetAppendConstructorBodyParameters))]
    public static void AppendConstructorBody(AppendConstructorBodyParameters parameters)
    {
        using var writer = Helper.GetIndentedTextWriter();

        BaseGenerator.AppendConstructorBody(writer, parameters.ConstructorBodies);
        var str = writer.InnerWriter.ToString();

        str.Should().Be(parameters.Expected);
    }

    public record struct AppendConstructorBodyParameters(ConstructorBody[] ConstructorBodies, string Expected) : IXunitSerializable
    {
        void IXunitSerializable.Deserialize(IXunitSerializationInfo info)
        {
            ConstructorBodies = info.GetValue<ConstructorBody[]>(nameof(ConstructorBodies));
            Expected = info.GetValue<string>(nameof(Expected));
        }

        readonly void IXunitSerializable.Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(ConstructorBodies), ConstructorBodies);
            info.AddValue(nameof(Expected), Expected);
        }
    }

    public static TheoryData<AppendConstructorBodyParameters> GetAppendConstructorBodyParameters()
    {
        return new()
        {
            new (
            [
                new("field"),
            ],
            """
            {
                this.tag = tag;
                this.field = field;
            }

            """),
            new (
            [
                new("field1"),
                new("field2"),
            ],
            """
            {
                this.tag = tag;
                this.field1 = field1;
                this.field2 = field2;
            }

            """),
        };
    }
}
