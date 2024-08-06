Getting Started
---
Create your union and mark it with `[DiscriminatedUnion]` attribute
```cs
[DiscriminatedUnion]
internal readonly partial struct MyUnion
{
    private readonly int bestNumber;
    private readonly int worstNumber;
    private readonly string? name;
    [DisallowNull]
    private readonly string[]? friends;
}
```

This will generate a couple kinds of methods for the struct,
1. `bool IsXYZ()` and `bool IsXYZ(out)`, which are used to test whether the union is of given type. In case of reference types marked with `[DisallowNull]` the `out` parameters will be marked with `[NotNullWhen(true)]`.
2. `MyUnion FromXYZ(type)` which are used for creating the union. In case of reference types marked with `[DisallowNull]` the method will throw if input is null.
3. `TMatchResult Match<TMatchResult>(Func<type1, TMatchResult>, Func<type2, TMatchResult>, ...)` and `void Switch(Action<type1>, Func<type2>, ...)` which are used to exhaustively parse the discriminated union.

The source generator will also generate an enum for the tag, the tag field and a private constructor which are used internally for the public methods.


Usage
---
```cs
MyUnion result = MyUnion.FromBestNumber(7);
Print(result);
Console.WriteLine(NumberOrLength(result));
//My favourite number is 7
//7

result = MyUnion.FromWorstNumber(13);
Print(result);
Console.WriteLine(NumberOrLength(result));
//worst number = 13
//13

result = MyUnion.FromName("John");
Print(result);
Console.WriteLine(NumberOrLength(result));
//hi, my name is John
//4

result = MyUnion.FromFriends(["John", "Anny"]);
Print(result);
Console.WriteLine(NumberOrLength(result));
//John, Anny
//2

static void Print(MyUnion union)
{
    union.Switch(bestNumber => Console.WriteLine($"My favourite number is {bestNumber}"),
        worstNumber => Console.WriteLine($"worst number = {worstNumber}"),
        name => Console.WriteLine($"hi, my name is {name}"),
        friends => Console.WriteLine(string.Join(", ", friends)));
}

static int NumberOrLength(MyUnion union)
{
    return union.Match(bestNumber => bestNumber, worstNumber => worstNumber, name => name.Length, friends => friends.Length);
}
```
