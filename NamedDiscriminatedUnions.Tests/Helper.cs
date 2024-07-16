using System.CodeDom.Compiler;

namespace NamedDiscriminatedUnions.Tests;
internal static class Helper
{
    public static IndentedTextWriter GetIndentedTextWriter()
    {
        var baseWriter = new StringWriter();
        var writer = new IndentedTextWriter(baseWriter, new string(' ', 4));

        return writer;
    }
}
