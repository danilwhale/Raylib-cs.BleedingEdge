using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// RayCollision, ray hit information
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RayCollision
{
    /// <summary>
    /// Did the ray hit something?
    /// </summary>
    public NativeBool Hit;

    /// <summary>
    /// Distance to the nearest hit
    /// </summary>
    public float Distance;

    /// <summary>
    /// Point of the nearest hit
    /// </summary>
    public Vector3 Point;

    /// <summary>
    /// Surface normal of hit
    /// </summary>
    public Vector3 Normal;
}