using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// RenderTexture, fbo for texture rendering
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RenderTexture2D : IEquatable<RenderTexture2D>
{
    /// <summary>
    /// OpenGL framebuffer object id
    /// </summary>
    public uint Id;

    /// <summary>
    /// Color buffer attachment texture
    /// </summary>
    public Texture2D Texture;

    /// <summary>
    /// Depth buffer attachment texture
    /// </summary>
    public Texture2D Depth;

    public override string ToString()
    {
        return $"<Id:{Id} Texture:{Texture} Depth:{Depth}>";
    }

    public bool Equals(RenderTexture2D other)
    {
        return Id == other.Id && 
               Texture.Equals(other.Texture) && 
               Depth.Equals(other.Depth);
    }

    public override bool Equals(object? obj)
    {
        return obj is RenderTexture2D other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Texture, Depth);
    }

    public static bool operator ==(RenderTexture2D left, RenderTexture2D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RenderTexture2D left, RenderTexture2D right)
    {
        return !left.Equals(right);
    }
}