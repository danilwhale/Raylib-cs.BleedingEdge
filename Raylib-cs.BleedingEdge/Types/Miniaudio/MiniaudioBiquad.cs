using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_biquad
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MiniaudioBiquad
{
    /// <summary>
    /// miniaudio ma_biquad_coefficient
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Coefficient
    {
        [FieldOffset(0)] public float Float32;
        [FieldOffset(0)] public int Int32;
    }

    public MiniaudioFormat Format;
    public uint Channels;

    public Coefficient B0;
    public Coefficient B1;
    public Coefficient B2;
    public Coefficient A1;
    public Coefficient A2;
    public Coefficient* R1;
    public Coefficient* R2;

    private nint _heapPointer;
    [MarshalAs(UnmanagedType.U4)] private bool _ownsHeap;
}