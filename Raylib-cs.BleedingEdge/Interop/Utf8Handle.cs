using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

/// <summary>
/// Allocates UTF-8 pointer to use in native library
/// </summary>
/// <remarks>
/// using statement or Dispose method should be used to free the memory
/// </remarks>
public unsafe readonly ref struct Utf8Handle(string str)
{
    public readonly sbyte* Value = (sbyte*)Marshal.StringToCoTaskMemUTF8(str);

    public void Dispose()
    {
        Marshal.FreeCoTaskMem((nint)Value);
    }
}