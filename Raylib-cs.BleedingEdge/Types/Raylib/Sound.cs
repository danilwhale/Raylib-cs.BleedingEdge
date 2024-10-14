using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Sound
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Sound
{
    /// <summary>
    /// Audio stream
    /// </summary>
    public AudioStream Stream;

    /// <summary>
    /// Total number of frames (considering channels)
    /// </summary>
    public uint FrameCount;

    public override string ToString()
    {
        return $"<Stream:{Stream} FrameCount:{FrameCount}>";
    }
}