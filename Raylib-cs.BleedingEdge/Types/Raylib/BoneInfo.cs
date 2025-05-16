using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Bone, skeletal animation bone
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BoneInfo
{
    /// <summary>
    /// Bone name
    /// </summary>
    public fixed sbyte Name[32];

    /// <summary>
    /// Bone parent
    /// </summary>
    public int Parent;

    public readonly override string ToString()
    {
        fixed (sbyte* pName = Name)
        {
            return $"<Name:{Marshal.PtrToStringUTF8((nint)pName)} Parent:{Parent}>";
        }
    }
}