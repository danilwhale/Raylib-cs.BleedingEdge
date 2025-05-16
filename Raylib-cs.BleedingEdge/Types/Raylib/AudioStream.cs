using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// AudioStream, custom audio stream
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioStream : IEquatable<AudioStream>
{
    /// <summary>
    /// Pointer to internal data used by the audio system
    /// </summary>
    public AudioBuffer* Buffer;

    /// <summary>
    /// Pointer to internal data processor, useful for audio effects
    /// </summary>
    public AudioProcessor* Processor;

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

    public readonly override string ToString()
    {
        return $"<SampleRate:{SampleRate} SampleSize:{SampleSize} Channels:{Channels}>";
    }

    public readonly bool Equals(AudioStream other)
    {
        return Buffer == other.Buffer && 
               Processor == other.Processor &&
               SampleRate == other.SampleRate &&
               SampleSize == other.SampleSize && 
               Channels == other.Channels;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is AudioStream other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(
            (nint)Buffer, 
            (nint)Processor,
            SampleRate,
            SampleSize,
            Channels);
    }

    public static bool operator ==(AudioStream left, AudioStream right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AudioStream left, AudioStream right)
    {
        return !left.Equals(right);
    }
}