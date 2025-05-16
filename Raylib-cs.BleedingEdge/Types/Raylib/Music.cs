using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Music, audio stream, anything longer than ~10 seconds should be streamed
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Music : IEquatable<Music>
{
    /// <summary>
    /// Audio stream
    /// </summary>
    public AudioStream Stream;

    /// <summary>
    /// Total number of frames (considering channels)
    /// </summary>
    public uint FrameCount;

    /// <summary>
    /// Music looping enable
    /// </summary>
    public NativeBool Looping;

    /// <summary>
    /// Type of music context (audio filetype)
    /// </summary>
    public int CtxType;

    /// <summary>
    /// Audio context data, depends on type
    /// </summary>
    public void* CtxData;

    public readonly override string ToString()
    {
        return $"<Stream:{Stream} FrameCount:{FrameCount} Looping:{Looping} CtxType:{CtxType}>";
    }

    public readonly bool Equals(Music other)
    {
        return Stream.Equals(other.Stream) &&
               FrameCount == other.FrameCount && 
               Looping.Equals(other.Looping) && 
               CtxType == other.CtxType &&
               CtxData == other.CtxData;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Music other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Stream, FrameCount, Looping, CtxType, (nint)CtxData);
    }

    public static bool operator ==(Music left, Music right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Music left, Music right)
    {
        return !left.Equals(right);
    }
}