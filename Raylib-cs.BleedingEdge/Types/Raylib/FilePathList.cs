using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// File path list
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FilePathList
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
    public unsafe sbyte** Paths;

    /// <summary>
    /// Filepaths entries
    /// </summary>
    public unsafe NativeStringArray PathsArray => new(Count, Paths);
}