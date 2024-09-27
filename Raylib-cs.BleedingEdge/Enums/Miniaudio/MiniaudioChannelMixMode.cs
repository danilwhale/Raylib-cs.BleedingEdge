namespace Raylib_cs.BleedingEdge;

public enum MiniaudioChannelMixMode
{
    /// <summary>
    /// Simple averaging based on the plane(s) the channel is sitting on.
    /// </summary>
    Rectangular,
    
    /// <summary>
    /// Drop excess channels; zeroed out extra channels
    /// </summary>
    Simple,
    
    /// <summary>
    /// Use custom weights specified in ma_channel_converter_config.
    /// </summary>
    CustomWeights,
    
    /// <summary>
    /// Simple averaging based on the plane(s) the channel is sitting on.
    /// </summary>
    Default = Rectangular
}