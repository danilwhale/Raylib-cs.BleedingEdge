namespace Raylib_cs.BleedingEdge.Enums.Raylib;

/// <summary>
/// Texture parameters: filter mode
/// </summary>
/// <remarks>
/// NOTE 1: Filtering considers mipmaps if available in the texture <br />
/// NOTE 2: Filter is accordingly set for minification and magnification
/// </remarks>
public enum TextureFilter
{
    /// <summary>
    /// No filter, just pixel approximation
    /// </summary>
    Point = 0,

    /// <summary>
    /// Linear filtering
    /// </summary>
    Bilinear,

    /// <summary>
    /// Trilinear filtering (linear with mipmaps)
    /// </summary>
    Trilinear,

    /// <summary>
    /// Anisotropic filtering 4x
    /// </summary>
    Anisotropic4X,

    /// <summary>
    /// Anisotropic filtering 8x
    /// </summary>
    Anisotropic8X,

    /// <summary>
    /// Anisotropic filtering 16x
    /// </summary>
    Anisotropic16X
}