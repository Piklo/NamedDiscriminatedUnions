using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NamedDiscriminatedUnions.Generators;
using System.Threading;

namespace NamedDiscriminatedUnions;

internal readonly record struct GenericType(string FullNamespace, string TypeName, bool IsValueType, bool IsReferenceType, bool IsGeneric);

[Generator]
internal class UnionGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var discriminatedUnionData =
            context.SyntaxProvider.ForAttributeWithMetadataName(
                "NamedDiscriminatedUnions.DiscriminatedUnionAttribute",
                IsRightNode,
                UnionParser.ParseDiscriminatedUnionData);

        context.RegisterSourceOutput(discriminatedUnionData, BaseGenerator.GenerateUnion);
    }

    private static bool IsRightNode(SyntaxNode node, CancellationToken cancellationToken)
    {
        var result = node is StructDeclarationSyntax;
        return result;
    }
}
