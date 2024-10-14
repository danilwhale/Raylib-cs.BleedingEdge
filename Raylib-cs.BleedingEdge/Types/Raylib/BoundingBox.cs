using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// BoundingBox
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BoundingBox(Vector3 min, Vector3 max)
{
    /// <summary>
    /// Minimum vertex box-corner
    /// </summary>
    public Vector3 Min = min;

    /// <summary>
    /// Maximum vertex box-corner
    /// </summary>
    public Vector3 Max = max;

    public override string ToString()
    {
        return $"<Min:{Min} Max:{Max}>";
    }
}