using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

/// <summary>
/// Music, audio stream, anything longer than ~10 seconds should be streamed
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Music
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
    public unsafe void* CtxData;
}