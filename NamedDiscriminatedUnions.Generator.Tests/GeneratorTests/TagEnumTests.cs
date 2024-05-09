namespace NamedDiscriminatedUnions.Generator.Tests.GeneratorTests;

public static class TagEnumTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public static void TagEnumGeneratesCorrectly(string source, string filename, string generatedEnum)
    {
        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, filename)[filename];
        res.Should().Contain(generatedEnum);
    }

    public static IEnumerable<object[]> TestData()
    {
        const string filename = "Union.g.cs";

        yield return new object[] {
            """
            using NamedDiscriminatedUnions.Attributes;
                                
            namespace TestNamespace;
            
            [DiscriminatedUnion]
            public readonly partial struct Union
            {
                private readonly int value;
            }
            """,
            filename,
            """
                public enum Tag : byte
                {
                    Value = 1,
                }
            """
        };

        yield return new object[] {
            """
            using NamedDiscriminatedUnions.Attributes;
                                
            namespace TestNamespace;
            
            [DiscriminatedUnion]
            public readonly partial struct Union
            {
                private readonly int int1;
                private readonly int int2;
            }
            """,
            filename,
            """
                public enum Tag : byte
                {
                    Int1 = 1,
                    Int2 = 2,
                }
            """
        };

        yield return new object[] {
            """
            using NamedDiscriminatedUnions.Attributes;
                                
            namespace TestNamespace;
            
            [DiscriminatedUnion]
            public readonly partial struct Union
            {
                private readonly int int1;
                private readonly int int2;
                private readonly long long1;
            }
            """,
            filename,
            """
                public enum Tag : byte
                {
                    Int1 = 1,
                    Int2 = 2,
                    Long1 = 3,
                }
            """
        };
    }
}
