using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Shader
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Shader : IEquatable<Shader>
{
    /// <summary>
    /// Shader program id
    /// </summary>
    public uint Id;

    /// <summary>
    /// Shader locations array (RL_MAX_SHADER_LOCATIONS)
    /// </summary>
    public int* Locs;

    public readonly override string ToString()
    {
        return $"<Id:{Id}>";
    }

    public readonly bool Equals(Shader other)
    {
        return Id == other.Id && Locs == other.Locs;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Shader other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Id, (nint)Locs);
    }

    public static bool operator ==(Shader left, Shader right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Shader left, Shader right)
    {
        return !left.Equals(right);
    }
}