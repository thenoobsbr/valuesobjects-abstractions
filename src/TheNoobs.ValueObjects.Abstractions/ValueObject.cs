using TheNoobs.ValueObjects.Abstractions.Internals;

namespace TheNoobs.ValueObjects.Abstractions;

/// <summary>
/// Value object base abstraction class.
/// </summary>
[Serializable]
public abstract class ValueObject : IEquatable<ValueObject?>
{
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equatable.Equals(left, right);
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equatable.Equals(left, right);
    }

    /// <inheritdoc cref="IEquatable{T}"/>
    public virtual bool Equals(ValueObject? other)
    {
        if (other is null)
        {
            return false;
        }

        return ReferenceEquals(this, other) ||
               other.GetType() == GetType() &&
                GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    /// <inheritdoc cref="object"/>
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((ValueObject)obj);
    }

    /// <inheritdoc cref="object"/>
    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Select(x => x is not null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <inheritdoc cref="object"/>
    public override string ToString()
    {
        return string.Join(";", GetAtomicValues());
    }

    /// <summary>
    /// Returns the atomic values used to do comparison with other <see cref="ValueObject"/>.
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<object> GetAtomicValues();
}

/// <summary>
/// Represents a value object that has a single value property.
/// </summary>
/// <typeparam name="TValue">The value type.</typeparam>
[Serializable]
public abstract class ValueObject<TValue> : ValueObject
    where TValue : notnull
{
    protected ValueObject(TValue value)
    {
        Value = value;
    }

    public TValue Value { get; }

    /// <inheritdoc cref="ValueObject"/>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
