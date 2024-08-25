using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

/// <summary>
/// Transform, vertex transformation data
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Transform(Vector3 translation, Quaternion rotation, Vector3 scale)
{
    /// <summary>
    /// Translation
    /// </summary>
    public Vector3 Translation = translation;

    /// <summary>
    /// Rotation
    /// </summary>
    public Quaternion Rotation = rotation;

    /// <summary>
    /// Scale
    /// </summary>
    public Vector3 Scale = scale;
}