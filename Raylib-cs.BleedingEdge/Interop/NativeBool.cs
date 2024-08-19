using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

[StructLayout(LayoutKind.Sequential)]
public readonly struct NativeBool(sbyte value)
{
    private readonly sbyte _value = value;

    public static NativeBool operator +(NativeBool left, NativeBool right) => new((sbyte)(left._value + right._value));
    public static NativeBool operator -(NativeBool left, NativeBool right) => new((sbyte)(left._value - right._value));
    
    public static implicit operator bool(NativeBool nbool) => nbool._value != 0;
    public static implicit operator NativeBool(bool value) => new((sbyte)(value ? 1 : 0));
    
    public static implicit operator sbyte(NativeBool nbool) => nbool._value;
    public static implicit operator NativeBool(sbyte value) => new(value);
}