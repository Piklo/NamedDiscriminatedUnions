using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NamedDiscriminatedUnions.Generators;
using System.Threading;

namespace NamedDiscriminatedUnions;

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
