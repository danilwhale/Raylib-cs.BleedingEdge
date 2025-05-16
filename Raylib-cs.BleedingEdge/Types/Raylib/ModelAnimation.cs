using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// ModelAnimation
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ModelAnimation
{
    /// <summary>
    /// Number of bones
    /// </summary>
    public int BoneCount;

    /// <summary>
    /// Number of animation frames
    /// </summary>
    public int FrameCount;

    /// <summary>
    /// Bones information (skeleton)
    /// </summary>
    public BoneInfo* Bones;

    /// <summary>
    /// Poses array by frame
    /// </summary>
    public Transform** FramePoses;

    /// <summary>
    /// Animation name
    /// </summary>
    public fixed sbyte Name[32];

    public readonly override string ToString()
    {
        fixed (sbyte* pName = Name)
        {
            return $"<BoneCount:{BoneCount} FrameCount:{FrameCount} Name:{Marshal.PtrToStringUTF8((nint)pName)}>";
        }
    }
}