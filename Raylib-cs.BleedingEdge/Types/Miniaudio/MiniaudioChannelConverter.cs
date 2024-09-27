using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_channel_converter
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MiniaudioChannelConverter
{
    [StructLayout(LayoutKind.Explicit)]
    public struct WeightsUnion
    {
        [FieldOffset(0)] public float** Float32;
        [FieldOffset(0)] public int** Signed16;
    }

    public MiniaudioFormat Format;

    public uint ChannelsIn;
    public uint ChannelsOut;

    public MiniaudioChannelMixMode MixingMode;

    public byte* ChannelMapIn;
    public byte* ChannelMapOut;

    /// <summary>
    /// Indexed by output channel index.
    /// </summary>
    public byte* ShuffleTable;

    public WeightsUnion Weights;

    private nint _heapPointer;
    [MarshalAs(UnmanagedType.U4)] private bool _ownsHeap;
}