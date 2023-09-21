namespace AwesomeDiscriminatedUnions;

public enum GetHashCodeType
{
    /// <summary>
    /// Do not generate GetHashCode method
    /// </summary>
    None,
    /// <summary>
    /// Generate GetHashCode method based on the item value and the tag value
    /// </summary>
    Strict,
    /// <summary>
    /// Generate GetHashCode method based on only the item value
    /// </summary>
    Weak,
}
