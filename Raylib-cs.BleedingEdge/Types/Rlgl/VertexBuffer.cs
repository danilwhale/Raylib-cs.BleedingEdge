using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types.Rlgl;

/// <summary>
/// Dynamic vertex buffers (position + texcoords + colors + indices arrays)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct VertexBuffer
{
    /// <summary>
    /// Number of elements in the buffer (QUADS)
    /// </summary>
    public int ElementCount;

    /// <summary>
    /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
    /// </summary>
    public unsafe float* Vertices;

    /// <summary>
    /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
    /// </summary>
    public unsafe float* Texcoords;

    /// <summary>
    /// Vertex normal (XYZ - 3 components per vertex) (shader-location = 2)
    /// </summary>
    public unsafe float* Normals;

    /// <summary>
    /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
    /// </summary>
    public unsafe byte* Colors;

    /// <summary>
    /// Vertex indices (in case vertex data comes indexed) (6 indices per quad)
    /// </summary>
    public unsafe uint* Indices;

    /// <summary>
    /// OpenGL Vertex Array Object id
    /// </summary>
    public uint VaoID;

    /// <summary>
    /// OpenGL Vertex Buffer Objects id (5 types of vertex data)
    /// </summary>
    public unsafe fixed uint VboID[5];
}