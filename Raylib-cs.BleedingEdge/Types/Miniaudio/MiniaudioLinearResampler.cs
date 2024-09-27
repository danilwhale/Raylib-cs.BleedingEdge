using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MiniaudioLinearResampler
{
    [StructLayout(LayoutKind.Explicit)]
    public struct X0Union
    {
        [FieldOffset(0)] public float* Float32;
        [FieldOffset(0)] public short* Signed16;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct X1Union
    {
        [FieldOffset(0)] public float* Float32;
        [FieldOffset(0)] public short* Signed16;
    }
    
    public MiniaudioLinearSamplerConfig Config;
    
    public uint InAdvanceInt;
    public uint InAdvanceFrac;

    public uint InTimeInt;
    public uint InTimeFrac;

    /// <summary>
    /// The previous input frame.
    /// </summary>
    public X0Union X0;
    
    /// <summary>
    /// The next input frame.
    /// </summary>
    public X1Union X1;

    public MiniaudioLowPassFilter LowPassFilter;

    private nint _heapPointer;
    [MarshalAs(UnmanagedType.U4)] private bool _ownsHeap;
}