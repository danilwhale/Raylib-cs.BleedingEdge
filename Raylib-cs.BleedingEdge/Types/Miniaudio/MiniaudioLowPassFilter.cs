using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_lpf
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MiniaudioLowPassFilter
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Filter1
    {
        public MiniaudioFormat Format;
        public uint Channels;

        public MiniaudioBiquad.Coefficient A;
        public MiniaudioBiquad.Coefficient* R2;

        private nint _heapPointer;
        [MarshalAs(UnmanagedType.U4)] private bool _ownsHeap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Filter2
    {
        /// <summary>
        /// The second order low-pass filter is implemented as a biquad filter.
        /// </summary>
        public MiniaudioBiquad Bq;
    }
    
    public MiniaudioFormat Format;
    public uint Channels;
    public uint SampleRate;
    
    public uint LowPassFilters1Count;
    public uint LowPassFilters2Count;
    public Filter1* LowPassFilters1;
    public Filter2* LowPassFilters2;

    private nint _heapPointer;
    [MarshalAs(UnmanagedType.U4)] private bool _ownsHeap;
}