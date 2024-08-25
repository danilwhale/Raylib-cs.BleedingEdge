namespace Raylib_cs.BleedingEdge.Types.Raylib;

/// <summary>
/// Font, font texture and GlyphInfo array data
/// </summary>
public struct Font
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
    public Texture Texture;

    /// <summary>
    /// Rectangles in texture for the glyphs
    /// </summary>
    public unsafe Rectangle* Recs;

    /// <summary>
    /// Glyphs info data
    /// </summary>
    public unsafe GlyphInfo* Glyphs;
}