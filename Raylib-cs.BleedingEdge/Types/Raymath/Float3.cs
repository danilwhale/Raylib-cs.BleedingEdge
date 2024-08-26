using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types.Raymath;

[StructLayout(LayoutKind.Sequential)]
public struct Float3
{
    public unsafe fixed float Values[3];
}