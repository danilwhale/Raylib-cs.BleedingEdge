using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_data_converter
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MiniaudioDataConverter
{
    public MiniaudioFormat FormatIn;
    public MiniaudioFormat FormatOut;

    public uint ChannelsIn;
    public uint ChannelsOut;
    
    public uint SampleRateIn;
    public uint SampleRateOut;

    public MiniaudioDitherMode DitherMode;
    
    /// <summary>
    /// The execution path the data converter will follow when processing.
    /// </summary>
    public MiniaudioDataConverterExecutionPath ExecutionPath;

    public MiniaudioChannelConverter ChannelConverter;
    public MiniaudioResampler Resampler;

    [MarshalAs(UnmanagedType.U1)] public bool HasPreFormatConversion;
    [MarshalAs(UnmanagedType.U1)] public bool HasPostFormatConversion;
    [MarshalAs(UnmanagedType.U1)] public bool HasChannelConversion;
    [MarshalAs(UnmanagedType.U1)] public bool HasResampler;
    [MarshalAs(UnmanagedType.U1)] public bool IsPassthrough;

    [MarshalAs(UnmanagedType.U1)] private bool _ownsHeap;
    private nint _heapPointer;
}