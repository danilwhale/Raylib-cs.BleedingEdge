using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Sound
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Sound : IEquatable<Sound>
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

    public bool Equals(Sound other)
    {
        return Stream.Equals(other.Stream) &&
               FrameCount == other.FrameCount;
    }

    public override bool Equals(object? obj)
    {
        return obj is Sound other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Stream, FrameCount);
    }

    public static bool operator ==(Sound left, Sound right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Sound left, Sound right)
    {
        return !left.Equals(right);
    }
}