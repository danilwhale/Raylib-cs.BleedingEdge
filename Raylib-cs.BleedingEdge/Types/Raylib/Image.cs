using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Enums.Raylib;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

/// <summary>
/// Image, pixel data stored in CPU memory (RAM)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Image
{
    /// <summary>
    /// Image raw data
    /// </summary>
    public unsafe void* Data;

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
}