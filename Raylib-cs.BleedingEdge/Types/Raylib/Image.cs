using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Image, pixel data stored in CPU memory (RAM)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Image : IEquatable<Image>
{
    /// <summary>
    /// Image raw data
    /// </summary>
    public void* Data;

    /// <summary>
    /// Image base width
    /// </summary>
    public int Width;

    /// <summary>
    /// Image base height
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

    public readonly override string ToString()
    {
        return $"<Width:{Width} Height:{Height} Mipmaps:{Mipmaps} Format:{Format}>";
    }

    public readonly bool Equals(Image other)
    {
        return Data == other.Data &&
               Width == other.Width &&
               Height == other.Height && 
               Mipmaps == other.Mipmaps &&
               Format == other.Format;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Image other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine((nint)Data, Width, Height, Mipmaps, Format);
    }

    public static bool operator ==(Image left, Image right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Image left, Image right)
    {
        return !left.Equals(right);
    }
}