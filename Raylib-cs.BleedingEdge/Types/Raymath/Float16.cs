using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

[StructLayout(LayoutKind.Sequential)]
public struct Float16
{
    public unsafe fixed float Values[16];
}