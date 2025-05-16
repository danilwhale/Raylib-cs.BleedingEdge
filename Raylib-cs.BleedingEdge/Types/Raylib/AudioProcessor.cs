using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Audio processor struct
/// </summary>
/// <remarks>
/// NOTE: Useful to apply effects to an AudioBuffer
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioProcessor : IEquatable<AudioProcessor>
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

    public readonly bool Equals(AudioProcessor other)
    {
        return Process == other.Process && Next == other.Next && Previous == other.Previous;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is AudioProcessor other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine((nint)Process, (nint)Next, (nint)Previous);
    }

    public static bool operator ==(AudioProcessor left, AudioProcessor right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AudioProcessor left, AudioProcessor right)
    {
        return !left.Equals(right);
    }
}