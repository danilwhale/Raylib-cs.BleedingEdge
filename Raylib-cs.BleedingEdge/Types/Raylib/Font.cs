namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Font, font texture and GlyphInfo array data
/// </summary>
public unsafe struct Font : IEquatable<Font>
{
    /// <summary>
    /// Base size (default chars height)
    /// </summary>
    public int BaseSize;

    /// <summary>
    /// Number of glyph characters
    /// </summary>
    public int GlyphCount;

    /// <summary>
    /// Padding around the glyph characters
    /// </summary>
    public int GlyphPadding;

    /// <summary>
    /// Texture atlas containing the glyphs
    /// </summary>
    public Texture2D Texture;

    /// <summary>
    /// Rectangles in texture for the glyphs
    /// </summary>
    public Rectangle* Recs;

    /// <summary>
    /// Glyphs info data
    /// </summary>
    public GlyphInfo* Glyphs;

    public readonly override string ToString()
    {
        return $"<BaseSize:{BaseSize} GlyphCount:{GlyphCount} GlyphPadding:{GlyphPadding} Texture:{Texture}>";
    }

    public readonly bool Equals(Font other)
    {
        return BaseSize == other.BaseSize &&
               GlyphCount == other.GlyphCount && 
               GlyphPadding == other.GlyphPadding && 
               Texture.Equals(other.Texture) &&
               Recs == other.Recs &&
               Glyphs == other.Glyphs;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Font other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(
            BaseSize, 
            GlyphCount, 
            GlyphPadding, 
            Texture, 
            (nint)Recs,
            (nint)Glyphs
        );
    }

    public static bool operator ==(Font left, Font right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Font left, Font right)
    {
        return !left.Equals(right);
    }
}