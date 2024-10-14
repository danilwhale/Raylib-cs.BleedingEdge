using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Camera, defines position/orientation in 3d space
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Camera3D(Vector3 position, Vector3 target, Vector3 up, float fovY, CameraProjection projection)
{
    /// <summary>
    /// Camera position
    /// </summary>
    public Vector3 Position = position;

    /// <summary>
    /// Camera target it looks-at
    /// </summary>
    public Vector3 Target = target;

    /// <summary>
    /// Camera up vector (rotation over its axis)
    /// </summary>
    public Vector3 Up = up;

    /// <summary>
    /// Camera field-of-view aperture in Y (degrees) in perspective, used as near plane width in orthographic
    /// </summary>
    public float FovY = fovY;

    /// <summary>
    /// Camera projection
    /// </summary>
    public CameraProjection Projection = projection;

    /// <summary>
    /// Camera, defines position/orientation in 3d space (with up set to Vector3.UnitY)
    /// </summary>
    public Camera3D(Vector3 position, Vector3 target, float fovY, CameraProjection projection)
        : this(position, target, Vector3.UnitY, fovY, projection)
    {
    }

    public override string ToString()
    {
        return $"<Position:{Position} Target:{Target} Up:{Up} FovY:{FovY} Projection:{Projection}>";
    }
}