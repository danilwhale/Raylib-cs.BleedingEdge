using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Wave, audio wave data
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Wave : IEquatable<Wave>
{
    /// <summary>
    /// Total number of frames (considering channels)
    /// </summary>
    public uint FrameCount;

    /// <summary>
    /// Frequency (samples per second)
    /// </summary>
    public uint SampleRate;

    /// <summary>
    /// Bit depth (bits per sample): 8, 16, 32 (24 not supported)
    /// </summary>
    public uint SampleSize;

    /// <summary>
    /// Number of channels (1-mono, 2-stereo, ...)
    /// </summary>
    public uint Channels;

    /// <summary>
    /// Buffer data pointer
    /// </summary>
    public void* Data;

    public override string ToString()
    {
        return $"<FrameCount:{FrameCount} SampleRate:{SampleRate} SampleSize:{SampleSize} Channels:{Channels}>";
    }

    public bool Equals(Wave other)
    {
        return FrameCount == other.FrameCount &&
               SampleRate == other.SampleRate && 
               SampleSize == other.SampleSize &&
               Channels == other.Channels && 
               Data == other.Data;
    }

    public override bool Equals(object? obj)
    {
        return obj is Wave other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FrameCount, SampleRate, SampleSize, Channels, (nint)Data);
    }

    public static bool operator ==(Wave left, Wave right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Wave left, Wave right)
    {
        return !left.Equals(right);
    }
}