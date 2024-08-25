using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Enums.Raylib;

namespace Raylib_cs.BleedingEdge.Types.Rlgl;

/// <summary>
/// Draw call type
/// </summary>
/// <remarks>
/// NOTE: Only texture changes register a new draw, other state-change-related elements are not
/// used at this moment (vaoId, shaderId, matrices), raylib just forces a batch draw call if any
/// of those state-change happens (this is done in core module)
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public struct DrawCall
{
    /// <summary>
    /// Drawing mode: LINES, TRIANGLES, QUADS
    /// </summary>
    public DrawMode Mode;

    /// <summary>
    /// Number of vertex of the draw
    /// </summary>
    public int VertexCount;

    /// <summary>
    /// Number of vertex required for index alignment (LINES, TRIANGLES)
    /// </summary>
    public int VertexAlignment;

    /// <summary>
    /// Texture id to be used on the draw -> Use to create new draw call if changes
    /// </summary>
    public uint TextureID;
}