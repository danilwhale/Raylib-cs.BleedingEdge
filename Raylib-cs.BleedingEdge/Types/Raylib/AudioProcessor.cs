using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Audio processor struct
/// </summary>
/// <remarks>
/// NOTE: Useful to apply effects to an AudioBuffer
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioProcessor
{
    /// <summary>
    /// Processor callback function
    /// </summary>
    public delegate* unmanaged[Cdecl]<void*, uint, void> Process;
    
    /// <summary>
    /// Next audio processor on the list
    /// </summary>
    public AudioProcessor* Next;
    
    /// <summary>
    /// Previous audio processor on the list
    /// </summary>
    public AudioProcessor* Previous;
}