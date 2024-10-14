using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Float3
{
    public fixed float Values[3];
}