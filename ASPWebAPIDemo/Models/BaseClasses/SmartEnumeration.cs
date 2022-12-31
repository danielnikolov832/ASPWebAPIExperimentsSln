namespace ASPWebAPIDemo.Models.BaseClasses;

#pragma warning disable S4035 // Classes implementing "IEquatable<T>" should be sealed
// The enumeration comparison is exactly the same and should be enforced to be because we attempt to mimic, but improve the enum in c#, not change it
public abstract class SmartEnumeration : IEquatable<SmartEnumeration>, IComparable<SmartEnumeration>
#pragma warning restore S4035 // Classes implementing "IEquatable<T>" should be sealed
{
    protected SmartEnumeration(ushort value)
    {
        get_value = value;
    }

    public ushort get_value { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        return get_value == ((SmartEnumeration)obj).get_value;
    }

    public bool Equals(SmartEnumeration? other)
    {
        if (other is null) return false;

        return get_value == other.get_value;
    }

    public int CompareTo(SmartEnumeration? other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other), "Argument other must not be null");
        }

        return get_value.CompareTo(other.get_value);
    }

    public int CompareToNotNull(SmartEnumeration other)
    {
        return get_value.CompareTo(other.get_value);
    }

    public override int GetHashCode()
    {
        return get_value;
    }

    public static implicit operator ushort(SmartEnumeration smart)
    {
        return smart.get_value;
    }

    public static implicit operator int(SmartEnumeration smart)
    {
        return smart.get_value;
    }

    public static implicit operator double(SmartEnumeration smart)
    {
        return smart.get_value;
    }

    public static bool operator ==(SmartEnumeration left, SmartEnumeration right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(SmartEnumeration left, SmartEnumeration right)
    {
        return !(left == right);
    }

    public static bool operator <(SmartEnumeration left, SmartEnumeration right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(SmartEnumeration left, SmartEnumeration right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(SmartEnumeration left, SmartEnumeration right)
    {
        return left?.CompareTo(right) > 0;
    }

    public static bool operator >=(SmartEnumeration left, SmartEnumeration right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }
}