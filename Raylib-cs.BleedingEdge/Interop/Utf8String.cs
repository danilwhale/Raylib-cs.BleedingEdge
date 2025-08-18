using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Unicode;

namespace Raylib_cs.BleedingEdge.Interop;

/// <summary>
/// Allocates UTF-8 string on stack to use in native library
/// </summary>
public readonly unsafe ref struct Utf8String(ReadOnlySpan<byte> value)
{
    public readonly ReadOnlySpan<byte> Value = value;

    public ref readonly byte GetPinnableReference() => ref Value.GetPinnableReference();

    [Obsolete($"Use equality operator instead. Calling this method will throw {nameof(NotSupportedException)}")]
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        throw new NotSupportedException();
    }

    public static bool operator ==(Utf8String left, Utf8String right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(Utf8String left, Utf8String right)
    {
        return !(left == right);
    }

    public static implicit operator Utf8String(string? utf16)
    {
        if (utf16 == null) return new Utf8String(null);
        if (utf16.Length == 0) return new Utf8String([0]);

        byte[] value = new byte[utf16[^1] == '\0' ? Encoding.UTF8.GetByteCount(utf16) : (Encoding.UTF8.GetByteCount(utf16) + 1)];
        Utf8.FromUtf16(utf16, value, out _, out _);
        return new Utf8String(value);
    }

    public static implicit operator Utf8String(ReadOnlySpan<char> utf16)
    {
        if (utf16 == null) return new Utf8String(null);
        if (utf16.IsEmpty) return new Utf8String([0]);

        byte[] value = new byte[utf16[^1] == '\0' ? Encoding.UTF8.GetByteCount(utf16) : (Encoding.UTF8.GetByteCount(utf16) + 1)];
        Utf8.FromUtf16(utf16, value, out _, out _);
        return new Utf8String(value);
    }

    public static implicit operator Utf8String(ReadOnlySpan<byte> utf8)
    {
        return new Utf8String(utf8);
    }
}