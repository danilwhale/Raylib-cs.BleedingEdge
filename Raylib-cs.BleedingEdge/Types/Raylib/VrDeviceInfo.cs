using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// VrDeviceInfo, Head-Mounted-Display device parameters
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VrDeviceInfo
{
    /// <summary>
    /// Horizontal resolution in pixels
    /// </summary>
    public int HResolution;

    /// <summary>
    /// Vertical resolution in pixels
    /// </summary>
    public int VResolution;

    /// <summary>
    /// Horizontal size in meters
    /// </summary>
    public float HScreenSize;

    /// <summary>
    /// Vertical size in meters
    /// </summary>
    public float VScreenSize;

    /// <summary>
    /// Distance between eye and display in meters
    /// </summary>
    public float EyeToScreenDistance;

    /// <summary>
    /// Lens separation distance in meters
    /// </summary>
    public float LensSeparationDistance;

    /// <summary>
    /// IPD (distance between pupils) in meters
    /// </summary>
    public float InterpupillaryDistance;

    /// <summary>
    /// Lens distortion constant parameters
    /// </summary>
    public fixed float LensDistortionValues[4];

    /// <summary>
    /// Chromatic aberration correction parameters
    /// </summary>
    public fixed float ChromaAbCorrection[4];
}