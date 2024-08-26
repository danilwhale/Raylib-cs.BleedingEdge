namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Font type, defines generation method
/// </summary>
public enum FontType
{
    /// <summary>
    /// Default font generation, anti-aliased
    /// </summary>
    Default = 0,

    /// <summary>
    /// Bitmap font generation, no anti-aliasing
    /// </summary>
    Bitmap,

    /// <summary>
    /// SDF font generation, requires external shader
    /// </summary>
    Sdf
}