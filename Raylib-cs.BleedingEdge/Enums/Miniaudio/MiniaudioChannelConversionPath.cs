namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_channel_conversion_path
/// </summary>
public enum MiniaudioChannelConversionPath
{
    Unknown,
    Passthrough,
    
    /// <summary>
    /// Converting to mono.
    /// </summary>
    MonoOut,
    
    /// <summary>
    /// Converting from mono.
    /// </summary>
    MonoIn,
    
    /// <summary>
    /// Simple shuffle. Will use this when all channels are present in both input and output channel maps, but just in a different order.
    /// </summary>
    Shuffle,
    
    /// <summary>
    /// Blended based on weights.
    /// </summary>
    Weights
}