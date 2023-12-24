using AwesomeDiscriminatedUnions.Attributes;

namespace AwesomeDiscriminatedUnions.Types;

[DiscriminatedUnion]
public readonly partial struct Result<T, E>
{
    private readonly T Value;
    private readonly E Error;
}
