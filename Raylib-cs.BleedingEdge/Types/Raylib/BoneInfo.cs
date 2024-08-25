using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

/// <summary>
/// Bone, skeletal animation bone
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BoneInfo
{
    /// <summary>
    /// Bone name
    /// </summary>
    public unsafe fixed sbyte Name[32];

    /// <summary>
    /// Bone parent
    /// </summary>
    public int Parent;
}