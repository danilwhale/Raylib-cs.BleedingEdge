using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// RayCollision, ray hit information
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RayCollision : IEquatable<RayCollision>
{
    /// <summary>
    /// Did the ray hit something?
    /// </summary>
    public NativeBool Hit;

    /// <summary>
    /// Distance to the nearest hit
    /// </summary>
    public float Distance;

    /// <summary>
    /// Point of the nearest hit
    /// </summary>
    public Vector3 Point;

    /// <summary>
    /// Surface normal of hit
    /// </summary>
    public Vector3 Normal;

    public override string ToString()
    {
        return $"<Hit:{Hit} Distance:{Distance} Point:{Point} Normal:{Normal}>";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hit, Distance, Point, Normal);
    }

    public bool Equals(RayCollision other)
    {
        return Hit.Equals(other.Hit) && Distance.Equals(other.Distance) && Point.Equals(other.Point) && Normal.Equals(other.Normal);
    }

    public override bool Equals(object? obj)
    {
        return obj is RayCollision other && Equals(other);
    }

    public static bool operator ==(RayCollision left, RayCollision right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RayCollision left, RayCollision right)
    {
        return !left.Equals(right);
    }
}