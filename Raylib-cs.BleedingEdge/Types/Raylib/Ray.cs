using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Ray, ray for raycasting
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Ray(Vector3 position, Vector3 direction)
{
    /// <summary>
    /// Ray position (origin)
    /// </summary>
    public Vector3 Position = position;

    /// <summary>
    /// Ray direction (normalized)
    /// </summary>
    public Vector3 Direction = direction;

    public override string ToString()
    {
        return $"<Position:{Position} Direction:{Direction}>";
    }
}