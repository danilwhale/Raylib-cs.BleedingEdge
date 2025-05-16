using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Camera2D, defines position/orientation in 2d space
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Camera2D(Vector2 offset, Vector2 target, float rotation, float zoom = 1.0f) : IEquatable<Camera2D>
{
    /// <summary>
    /// Camera offset (displacement from target)
    /// </summary>
    public Vector2 Offset = offset;

    /// <summary>
    /// Camera target (rotation and zoom origin)
    /// </summary>
    public Vector2 Target = target;

    /// <summary>
    /// Camera rotation in degrees
    /// </summary>
    public float Rotation = rotation;

    /// <summary>
    /// Camera zoom (scaling), should be 1.0f by default
    /// </summary>
    public float Zoom = zoom;

    public readonly override string ToString()
    {
        return $"<Offset:{Offset} Target:{Target} Rotation:{Rotation} Zoom:{Zoom}>";
    }

    public readonly bool Equals(Camera2D other)
    {
        return Offset.Equals(other.Offset) &&
               Target.Equals(other.Target) && 
               Rotation.Equals(other.Rotation) &&
               Zoom.Equals(other.Zoom);
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Camera2D other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Offset, Target, Rotation, Zoom);
    }

    public static bool operator ==(Camera2D left, Camera2D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Camera2D left, Camera2D right)
    {
        return !left.Equals(right);
    }
}