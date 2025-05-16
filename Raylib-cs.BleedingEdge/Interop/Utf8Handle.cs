using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

/// <summary>
/// Allocates UTF-8 pointer to use in native library
/// </summary>
/// <remarks>
/// using statement or Dispose method should be used to free the memory
/// </remarks>
public readonly unsafe ref struct Utf8Handle(string str)
{
    public readonly sbyte* Value = (sbyte*)Marshal.StringToCoTaskMemUTF8(str);

    public void Dispose()
    {
        Marshal.FreeCoTaskMem((nint)Value);
    }

    public override int GetHashCode()
    {
        return ((nint)Value).GetHashCode();
    }

    [Obsolete($"Use equality operator instead. Calling this method will throw {nameof(NotSupportedException)}")]
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        throw new NotSupportedException();
    }

    public static bool operator ==(Utf8Handle left, Utf8Handle right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(Utf8Handle left, Utf8Handle right)
    {
        return !(left == right);
    }
}