using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// File path list
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FilePathList
{
    /// <summary>
    /// Filepaths max entries
    /// </summary>
    public uint Capacity;

    /// <summary>
    /// Filepaths entries count
    /// </summary>
    public uint Count;
    
    /// <summary>
    /// Filepaths entries
    /// </summary>
    public sbyte** Paths;

    /// <summary>
    /// Filepaths entries
    /// </summary>
    public NativeStringArray PathsArray => new(Count, Paths);

    public override string ToString()
    {
        return $"<Capacity:{Capacity} Count:{Count}>";
    }
}