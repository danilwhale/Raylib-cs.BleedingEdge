using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// NPatchInfo, n-patch layout info
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct NPatchInfo : IEquatable<NPatchInfo>
{
    /// <summary>
    /// Texture source rectangle
    /// </summary>
    public Rectangle Source;

    /// <summary>
    /// Left border offset
    /// </summary>
    public int Left;

    /// <summary>
    /// Top border offset
    /// </summary>
    public int Top;

    /// <summary>
    /// Right border offset
    /// </summary>
    public int Right;

    /// <summary>
    /// Bottom border offset
    /// </summary>
    public int Bottom;

    /// <summary>
    /// Layout of the n-patch: 3x3, 1x3 or 3x1
    /// </summary>
    public NPatchLayout Layout;

    public readonly override string ToString()
    {
        return $"<Source:{Source} Left:{Left} Top:{Top} Right:{Right} Bottom:{Bottom} Layout:{Layout}";
    }

    public readonly bool Equals(NPatchInfo other)
    {
        return Source.Equals(other.Source) &&
               Left == other.Left && 
               Top == other.Top && 
               Right == other.Right &&
               Bottom == other.Bottom && 
               Layout == other.Layout;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is NPatchInfo other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Source, Left, Top, Right, Bottom, Layout);
    }

    public static bool operator ==(NPatchInfo left, NPatchInfo right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NPatchInfo left, NPatchInfo right)
    {
        return !left.Equals(right);
    }
}