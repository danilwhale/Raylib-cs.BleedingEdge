using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_resampler
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MiniaudioResampler
{
    public nint Backend; // ma_resampling_backend
    public nint BackendVTable; // ma_resampling_backend_vtable
    public nint BackendUserData;

    public MiniaudioFormat Format;
    public uint Channels;
    public uint SampleRateIn;
    public uint SampleRateOut;
    
}