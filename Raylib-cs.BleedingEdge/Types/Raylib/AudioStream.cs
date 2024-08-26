using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// AudioStream, custom audio stream
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AudioStream
{
    /// <summary>
    /// Pointer to internal data used by the audio system
    /// </summary>
    public unsafe void* Buffer;

    /// <summary>
    /// Pointer to internal data processor, useful for audio effects
    /// </summary>
    public unsafe void* Processor;

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
}