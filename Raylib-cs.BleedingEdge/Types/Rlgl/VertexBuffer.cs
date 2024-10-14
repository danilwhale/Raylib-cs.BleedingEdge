using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Dynamic vertex buffers (position + texcoords + colors + indices arrays)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VertexBuffer
{
    /// <summary>
    /// Number of elements in the buffer (QUADS)
    /// </summary>
    public int ElementCount;

    /// <summary>
    /// Vertex position (XYZ - 3 components per vertex) (shader-location = 0)
    /// </summary>
    public float* Vertices;

    /// <summary>
    /// Vertex texture coordinates (UV - 2 components per vertex) (shader-location = 1)
    /// </summary>
    public float* Texcoords;

    /// <summary>
    /// Vertex normal (XYZ - 3 components per vertex) (shader-location = 2)
    /// </summary>
    public float* Normals;

    /// <summary>
    /// Vertex colors (RGBA - 4 components per vertex) (shader-location = 3)
    /// </summary>
    public byte* Colors;

    /// <summary>
    /// Vertex indices (in case vertex data comes indexed) (6 indices per quad)
    /// </summary>
    public uint* Indices;

    /// <summary>
    /// OpenGL Vertex Array Object id
    /// </summary>
    public uint VaoId;

    /// <summary>
    /// OpenGL Vertex Buffer Objects id (5 types of vertex data)
    /// </summary>
    public fixed uint VboId[5];

    public override string ToString()
    {
        return $"<ElementCount:{ElementCount} VaoId:{VaoId} VboId:<{VboId[0]}, {VboId[1]}, {VboId[2]}, {VboId[3]}, {VboId[4]}>>";
    }
}