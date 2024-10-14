using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// GlyphInfo, font characters glyphs info
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct GlyphInfo
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

    public override string ToString()
    {
        return $"<Value:{Value} OffsetX:{OffsetX} OffsetY:{OffsetY} AdvanceX:{AdvanceX} Image:{Image}";
    }
}