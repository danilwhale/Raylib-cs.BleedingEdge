using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Image, pixel data stored in CPU memory (RAM)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Image
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

    public override string ToString()
    {
        return $"<Width:{Width} Height:{Height} Mipmaps:{Mipmaps} Format:{Format}>";
    }
}