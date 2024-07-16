using System;

namespace NamedDiscriminatedUnions;

public class UnknownTagException : Exception
{
    public UnknownTagException()
    {
    }

    public UnknownTagException(string message) : base(message)
    {
    }

    public UnknownTagException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
