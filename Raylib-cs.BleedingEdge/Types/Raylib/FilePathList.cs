using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

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
}