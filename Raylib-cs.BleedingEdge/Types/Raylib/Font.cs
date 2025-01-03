namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Font, font texture and GlyphInfo array data
/// </summary>
public unsafe struct Font
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

    public override string ToString()
    {
        return $"<BaseSize:{BaseSize} GlyphCount:{GlyphCount} GlyphPadding:{GlyphPadding} Texture:{Texture}>";
    }
}