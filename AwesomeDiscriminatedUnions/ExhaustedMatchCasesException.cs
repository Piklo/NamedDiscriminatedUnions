using System;
using System.Runtime.Serialization;

namespace AwesomeDiscriminatedUnions;

public class ExhaustedMatchCasesException : Exception
{
    public ExhaustedMatchCasesException()
    {
    }

    public ExhaustedMatchCasesException(string message) : base(message)
    {
    }

    public ExhaustedMatchCasesException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ExhaustedMatchCasesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
