using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Material, includes shader and maps
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Material : IEquatable<Material>
{
    /// <summary>
    /// Material shader
    /// </summary>
    public Shader Shader;

    /// <summary>
    /// Material maps array (MAX_MATERIAL_MAPS)
    /// </summary>
    public MaterialMap* Maps;

    /// <summary>
    /// Material generic parameters (if required)
    /// </summary>
    public fixed float Params[4];

    public readonly bool Equals(Material other)
    {
        return Shader.Equals(other.Shader) &&
               Maps == other.Maps &&
               Params[0].Equals(other.Params[0]) &&
               Params[1].Equals(other.Params[1]) &&
               Params[2].Equals(other.Params[2]) &&
               Params[3].Equals(other.Params[3]);
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Material other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Shader, (nint)Maps, Params[0], Params[1], Params[2], Params[3]);
    }

    public static bool operator ==(Material left, Material right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Material left, Material right)
    {
        return !left.Equals(right);
    }
}