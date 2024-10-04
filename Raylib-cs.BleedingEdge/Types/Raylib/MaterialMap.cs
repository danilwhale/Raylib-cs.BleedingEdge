using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// MaterialMap
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MaterialMap
{
    /// <summary>
    /// Material map texture
    /// </summary>
    public Texture2D Texture;

    /// <summary>
    /// Material map color
    /// </summary>
    public Color Color;

    /// <summary>
    /// Material map value
    /// </summary>
    public float Value;
}