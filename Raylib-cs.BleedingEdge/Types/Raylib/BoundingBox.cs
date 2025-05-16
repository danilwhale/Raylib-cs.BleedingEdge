using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// BoundingBox
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BoundingBox(Vector3 min, Vector3 max) : IEquatable<BoundingBox>
{
    /// <summary>
    /// Minimum vertex box-corner
    /// </summary>
    public Vector3 Min = min;

    /// <summary>
    /// Maximum vertex box-corner
    /// </summary>
    public Vector3 Max = max;

    public override string ToString()
    {
        return $"<Min:{Min} Max:{Max}>";
    }

    public bool Equals(BoundingBox other)
    {
        return Min.Equals(other.Min) && Max.Equals(other.Max);
    }

    public override bool Equals(object? obj)
    {
        return obj is BoundingBox other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Min, Max);
    }

    public static bool operator ==(BoundingBox left, BoundingBox right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BoundingBox left, BoundingBox right)
    {
        return !left.Equals(right);
    }
}