using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types;

/// <summary>
/// ModelAnimation
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ModelAnimation
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
    public unsafe BoneInfo* Bones;

    /// <summary>
    /// Poses array by frame
    /// </summary>
    public unsafe Transform** FramePoses;
    
    /// <summary>
    /// Animation name
    /// </summary>
    public unsafe fixed sbyte Name[32];
}