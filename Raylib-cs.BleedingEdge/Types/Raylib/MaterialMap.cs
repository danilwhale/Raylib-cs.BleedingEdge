using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// MaterialMap
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MaterialMap : IEquatable<MaterialMap>
{
    /// <summary>
    /// Material map texture
    /// </summary>
    public Texture2D Texture;

    /// <summary>
    /// Material map color
    /// </summary>
    public Color Color;

    /// <summary>
    /// Material map value
    /// </summary>
    public float Value;

    public override string ToString()
    {
        return $"<Texture:{Texture} Color:{Color} Value:{Value}>";
    }

    public bool Equals(MaterialMap other)
    {
        return Texture.Equals(other.Texture) && 
               Color.Equals(other.Color) && 
               Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is MaterialMap other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Texture, Color, Value);
    }

    public static bool operator ==(MaterialMap left, MaterialMap right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(MaterialMap left, MaterialMap right)
    {
        return !left.Equals(right);
    }
}