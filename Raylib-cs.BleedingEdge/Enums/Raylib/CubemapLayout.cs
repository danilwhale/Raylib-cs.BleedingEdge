namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Cubemap layouts
/// </summary>
public enum CubemapLayout
{
    /// <summary>
    /// Automatically detect layout type
    /// </summary>
    AutoDetect = 0,

    /// <summary>
    /// Layout is defined by a vertical line with faces
    /// </summary>
    LineVertical,

    /// <summary>
    /// Layout is defined by a horizontal line with faces
    /// </summary>
    LineHorizontal,

    /// <summary>
    /// Layout is defined by a 3x4 cross with cubemap faces
    /// </summary>
    ThreeByFour,

    /// <summary>
    /// Layout is defined by a 4x3 cross with cubemap faces
    /// </summary>
    FourByThree
}