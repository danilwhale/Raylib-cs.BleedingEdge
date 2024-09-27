namespace Raylib_cs.BleedingEdge;

public enum MiniaudioDataConverterExecutionPath
{
    /// <summary>
    /// No conversion.
    /// </summary>
    Passthrough,
    
    /// <summary>
    /// Only format conversion.
    /// </summary>
    FormatOnly,
    
    /// <summary>
    /// Only channel conversion.
    /// </summary>
    ChannelsOnly,
    
    /// <summary>
    /// Only resampling.
    /// </summary>
    ResampleOnly,
    
    /// <summary>
    /// All conversions, but resample as the first step.
    /// </summary>
    ResampleFirst,
    
    /// <summary>
    /// All conversions, but channels as the first step.
    /// </summary>
    ChannelsFirst
}