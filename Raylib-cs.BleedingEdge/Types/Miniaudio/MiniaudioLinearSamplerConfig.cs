using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_linear_sampler_config
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MiniaudioLinearSamplerConfig
{
    public MiniaudioFormat Format;
    public uint Channels;
    public uint SampleRateIn;
    public uint SampleRateOut;
    
    /// <summary>
    /// The low-pass filter order. Setting this to 0 will disable low-pass filtering.
    /// </summary>
    public uint LowPassFilterOrder;

    /// <summary>
    /// 0..1. Defaults to 1. 1 = Half the sampling frequency (Nyquist Frequency), 0.5 = Quarter the sampling frequency (half Nyquest Frequency), etc.
    /// </summary>
    public double LowPassFilterNyquistFactor;
}