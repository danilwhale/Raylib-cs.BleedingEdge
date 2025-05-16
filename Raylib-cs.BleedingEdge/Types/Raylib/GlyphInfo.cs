using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// GlyphInfo, font characters glyphs info
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct GlyphInfo : IEquatable<GlyphInfo>
{
    /// <summary>
    /// Character value (Unicode)
    /// </summary>
    public int Value;

    /// <summary>
    /// Character offset X when drawing
    /// </summary>
    public int OffsetX;

    /// <summary>
    /// Character offset Y when drawing
    /// </summary>
    public int OffsetY;

    /// <summary>
    /// Character advance position X
    /// </summary>
    public int AdvanceX;

    /// <summary>
    /// Character image data
    /// </summary>
    public Image Image;

    public readonly override string ToString()
    {
        return $"<Value:{Value} OffsetX:{OffsetX} OffsetY:{OffsetY} AdvanceX:{AdvanceX} Image:{Image}";
    }

    public readonly bool Equals(GlyphInfo other)
    {
        return Value == other.Value && 
               OffsetX == other.OffsetX && 
               OffsetY == other.OffsetY && 
               AdvanceX == other.AdvanceX &&
               Image.Equals(other.Image);
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is GlyphInfo other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Value, OffsetX, OffsetY, AdvanceX, Image);
    }

    public static bool operator ==(GlyphInfo left, GlyphInfo right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(GlyphInfo left, GlyphInfo right)
    {
        return !left.Equals(right);
    }
}