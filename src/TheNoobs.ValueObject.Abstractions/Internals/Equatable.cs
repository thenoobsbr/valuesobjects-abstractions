namespace TheNoobs.ValueObject.Abstractions.Internals;

internal static class Equatable
{
    internal static bool Equals<TLeft, TRight>(TLeft left, TRight right)
        where TLeft : class, IEquatable<TRight>
        where TRight : class
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }
}
