namespace Raylib_cs.BleedingEdge;

/// <summary>
/// miniaudio ma_format
/// </summary>
public enum MiniaudioFormat
{
    /// <summary>
    /// Mainly used for indicating an error, but also used as the default for the output format for decoders.
    /// </summary>
    Unknown,
    
    Unsigned8,
    
    /// <summary>
    /// Seems to be the most widely supported format.
    /// </summary>
    Signed16,
    
    /// <summary>
    /// Tightly packed. 3 bytes per sample.
    /// </summary>
    Signed24,
    
    Signed32,
    Float32,
    
    Count
}