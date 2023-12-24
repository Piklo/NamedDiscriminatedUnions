//namespace AwesomeDiscriminatedUnions.Tests;
//public sealed class GetHashCodeTests
//{
//    [Fact]
//    public void None()
//    {
//        const string source = """
//            using AwesomeDiscriminatedUnions;

//            namespace TestNamespace;

//            [DiscriminatedUnion(getHashCodeType: GetHashCodeType.None)]
//            [DiscriminatedUnionType(typeof(int))]
//            public readonly partial struct JustIntUnion
//            {
//            }
//            """;

//        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

//        res.Should().NotContain("public override int GetHashCode");
//    }

//    [Fact]
//    public void Strict()
//    {
//        const string source = """
//            using AwesomeDiscriminatedUnions;

//            namespace TestNamespace;

//            [DiscriminatedUnion(getHashCodeType: GetHashCodeType.Strict)]
//            [DiscriminatedUnionType(typeof(int))]
//            public readonly partial struct JustIntUnion
//            {
//            }
//            """;

//        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

//        res.Should().Contain("""
//                    readonly public override int GetHashCode()
//                    {
//                        switch (_tag)
//                        {
//                            case TagInt:
//                                return HashCode.Combine(_tag, _int);
//                            default:
//                                return 0;
//                        }
//                    }
//            """);
//    }

//    [Fact]
//    public void Weak()
//    {
//        const string source = """
//            using AwesomeDiscriminatedUnions;

//            namespace TestNamespace;

//            [DiscriminatedUnion(getHashCodeType: GetHashCodeType.Weak)]
//            [DiscriminatedUnionType(typeof(int))]
//            public readonly partial struct JustIntUnion
//            {
//            }
//            """;

//        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

//        res.Should().Contain("""
//                    readonly public override int GetHashCode()
//                    {
//                        switch (_tag)
//                        {
//                            case TagInt:
//                                return _int.GetHashCode();
//                            default:
//                                return 0;
//                        }
//                    }
//            """);
//    }

//    [Fact]
//    public void Default()
//    {
//        Strict();
//    }
//}
