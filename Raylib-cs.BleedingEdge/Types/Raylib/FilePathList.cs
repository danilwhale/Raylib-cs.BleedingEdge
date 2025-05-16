using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// File path list
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FilePathList : IEquatable<FilePathList>
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

    public bool Equals(FilePathList other)
    {
        return Capacity == other.Capacity &&
               Count == other.Count &&
               Paths == other.Paths;
    }

    public override bool Equals(object? obj)
    {
        return obj is FilePathList other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Capacity, Count, (nint)Paths);
    }

    public static bool operator ==(FilePathList left, FilePathList right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(FilePathList left, FilePathList right)
    {
        return !left.Equals(right);
    }
}