using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

[StructLayout(LayoutKind.Sequential)]
public readonly struct NativeBool(sbyte value) : IEquatable<NativeBool>
{
    private readonly sbyte _value = value;

    public override string ToString()
    {
        return ((bool)this).ToString();
    }

    public override int GetHashCode()
    {
        return _value != 0 ? 1 : 0;
    }
    
    public bool Equals(NativeBool other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is NativeBool other && Equals(other);
    }

    public static bool operator ==(NativeBool left, NativeBool right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NativeBool left, NativeBool right)
    {
        return !left.Equals(right);
    }

    public static NativeBool operator +(NativeBool left, NativeBool right)
    {
        return new NativeBool((sbyte)(left._value + right._value));
    }

    public static NativeBool operator -(NativeBool left, NativeBool right)
    {
        return new NativeBool((sbyte)(left._value - right._value));
    }

    public static implicit operator bool(NativeBool nbool)
    {
        return nbool._value != 0;
    }

    public static implicit operator NativeBool(bool value)
    {
        return new NativeBool((sbyte)(value ? 1 : 0));
    }

    public static implicit operator sbyte(NativeBool nbool)
    {
        return nbool._value;
    }

    public static implicit operator NativeBool(sbyte value)
    {
        return new NativeBool(value);
    }
}