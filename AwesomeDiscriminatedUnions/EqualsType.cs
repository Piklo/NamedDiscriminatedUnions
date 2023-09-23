using System;

namespace AwesomeDiscriminatedUnions;

[Flags]
public enum EqualsType
{
    /// <summary>
    /// Do not generate Equals method and == operator
    /// </summary>
    None = 0,
    /// <summary>
    /// Override default Equals(object) method
    /// </summary>
    /// <remarks>
    /// Requires Equals(YourStruct) method. Hand written or from <seealso cref="EqualsStrict"/>.
    /// </remarks>
    OverrideEquals = 1,
    /// <summary>
    /// Generate Equals(YourStruct) method which compares the tag and the value of the structs
    /// </summary>
    EqualsStrict = 2,
    /// <summary>
    /// Adds IEquatable<T> interface to your struct. Meant to be used with <see cref="EqualsStrict"/>.
    /// </summary>
    /// <remarks>
    /// Ignored on ref structs since they can't implement interfaces.
    /// </remarks>
    IEquatable = 4,
    /// <summary>
    /// Generate == and != operators using Equals(YourStruct) method
    /// </summary>
    EqualsOperator = 8,
}