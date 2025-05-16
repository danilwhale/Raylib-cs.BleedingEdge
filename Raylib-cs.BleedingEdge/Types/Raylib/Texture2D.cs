using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Texture, tex data stored in GPU memory (VRAM)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Texture2D : IEquatable<Texture2D>
{
    /// <summary>
    /// OpenGL texture id
    /// </summary>
    public uint Id;

    /// <summary>
    /// Texture base width
    /// </summary>
    public int Width;

    /// <summary>
    /// Texture base height
    /// </summary>
    public int Height;

    /// <summary>
    /// Mipmap levels, 1 by default
    /// </summary>
    public int Mipmaps;

    /// <summary>
    /// Data format
    /// </summary>
    public PixelFormat Format;

    public override string ToString()
    {
        return $"<Id:{Id} Width:{Width} Height:{Height} Mipmaps:{Mipmaps} Format:{Format}>";
    }

    public bool Equals(Texture2D other)
    {
        return Id == other.Id &&
               Width == other.Width &&
               Height == other.Height && 
               Mipmaps == other.Mipmaps && 
               Format == other.Format;
    }

    public override bool Equals(object? obj)
    {
        return obj is Texture2D other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Width, Height, Mipmaps, Format);
    }

    public static bool operator ==(Texture2D left, Texture2D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Texture2D left, Texture2D right)
    {
        return !left.Equals(right);
    }
}