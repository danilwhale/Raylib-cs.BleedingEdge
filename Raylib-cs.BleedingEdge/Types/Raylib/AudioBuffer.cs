using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Audio buffer struct
/// </summary>
public unsafe struct AudioBuffer
{
    /// <summary>
    /// Audio data converter
    /// </summary>
    public MiniaudioDataConverter Converter;

    /// <summary>
    /// Audio buffer callback for buffer filling on audio threads
    /// </summary>
    public delegate* unmanaged[Cdecl]<void*, uint, void> Callback;

    /// <summary>
    /// Audio processor
    /// </summary>
    public AudioProcessor* Processor;
    
    /// <summary>
    /// Audio buffer volume
    /// </summary>
    public float Volume;

    /// <summary>
    /// Audio buffer pitch
    /// </summary>
    public float Pitch;

    /// <summary>
    /// Audio buffer pan (0.0f to 1.0f)
    /// </summary>
    public float Pan;

    /// <summary>
    /// Audio buffer state: AUDIO_PLAYING
    /// </summary>
    public NativeBool Playing;

    /// <summary>
    /// Audio buffer state: AUDIO_PAUSED
    /// </summary>
    public NativeBool Paused;

    /// <summary>
    /// Audio buffer looping, default to true for AudioStreams
    /// </summary>
    public NativeBool Looping;

    /// <summary>
    /// Audio buffer usage mode: STATIC or STREAM
    /// </summary>
    public AudioBufferUsage Usage;

    /// <summary>
    /// SubBuffer processed (virtual double buffer)
    /// </summary>
    public NativeBool IsSubBufferProcessed0;
    
    /// <summary>
    /// SubBuffer processed (virtual double buffer)
    /// </summary>
    public NativeBool IsSubBufferProcessed1;

    /// <summary>
    /// Total buffer size in frames
    /// </summary>
    public uint SizeInFrames;

    /// <summary>
    /// Frame cursor position
    /// </summary>
    public uint FrameCursorPos;

    /// <summary>
    /// Total frames processed in this buffer (required for play timing)
    /// </summary>
    public uint FramesProcessed;

    /// <summary>
    /// Data buffer, on music stream keeps filling
    /// </summary>
    public nint Data;

    /// <summary>
    /// Next audio buffer on the list
    /// </summary>
    public AudioBuffer* Next;
    
    /// <summary>
    /// Previous audio buffer on the list
    /// </summary>
    public AudioBuffer* Previous;
}