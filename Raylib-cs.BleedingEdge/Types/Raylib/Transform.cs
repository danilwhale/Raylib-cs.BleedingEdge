using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Transform, vertex transformation data
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Transform(Vector3 translation, Quaternion rotation, Vector3 scale) : IEquatable<Transform>
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

    public override string ToString()
    {
        return $"<Translation:{Translation} Rotation:{Rotation} Scale:{Scale}>";
    }

    public bool Equals(Transform other)
    {
        return Translation.Equals(other.Translation) && Rotation.Equals(other.Rotation) && Scale.Equals(other.Scale);
    }

    public override bool Equals(object? obj)
    {
        return obj is Transform other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Translation, Rotation, Scale);
    }

    public static bool operator ==(Transform left, Transform right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Transform left, Transform right)
    {
        return !left.Equals(right);
    }
}