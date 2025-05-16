using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Ray, ray for raycasting
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Ray(Vector3 position, Vector3 direction) : IEquatable<Ray>
{
    /// <summary>
    /// Ray position (origin)
    /// </summary>
    public Vector3 Position = position;

    /// <summary>
    /// Ray direction (normalized)
    /// </summary>
    public Vector3 Direction = direction;

    public override string ToString()
    {
        return $"<Position:{Position} Direction:{Direction}>";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, Direction);
    }

    public bool Equals(Ray other)
    {
        return Position.Equals(other.Position) && Direction.Equals(other.Direction);
    }

    public override bool Equals(object? obj)
    {
        return obj is Ray other && Equals(other);
    }

    public static bool operator ==(Ray left, Ray right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Ray left, Ray right)
    {
        return !left.Equals(right);
    }
}