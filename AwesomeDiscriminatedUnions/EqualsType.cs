namespace AwesomeDiscriminatedUnions;

public enum EqualsType
{
    /// <summary>
    /// Do not generate Equals method and == operator
    /// </summary>
    None,
    /// <summary>
    /// Generate Equals method and == operator based on the item value and the tag value
    /// </summary>
    Strict,
}