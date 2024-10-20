using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// VrStereoConfig, VR stereo rendering configuration for simulator
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VrStereoConfig
{
    /// <summary>
    /// VR projection matrices (per eye)
    /// </summary>
    public Matrix4x4 Projection0;

    /// <summary>
    /// VR projection matrices (per eye)
    /// </summary>
    public Matrix4x4 Projection1;

    /// <summary>
    /// VR view offset matrices (per eye)
    /// </summary>
    public Matrix4x4 ViewOffset0;

    /// <summary>
    /// VR view offset matrices (per eye)
    /// </summary>
    public Matrix4x4 ViewOffset1;

    /// <summary>
    /// VR left lens center
    /// </summary>
    public fixed float LeftLensCenter[2];

    /// <summary>
    /// VR right lens center
    /// </summary>
    public fixed float RightLensCenter[2];

    /// <summary>
    /// VR left screen center
    /// </summary>
    public fixed float LeftScreenCenter[2];

    /// <summary>
    /// VR right screen center
    /// </summary>
    public fixed float RightScreenCenter[2];

    /// <summary>
    /// VR distortion scale
    /// </summary>
    public fixed float Scale[2];

    /// <summary>
    /// VR distortion scale in
    /// </summary>
    public fixed float ScaleIn[2];
}