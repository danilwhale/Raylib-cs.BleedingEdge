namespace Raylib_cs.BleedingEdge;

/// <summary>
/// NOTE: Different logic is used when feeding data to the playback device
/// depending on whether data is streamed (Music vs Sound)
/// </summary>
public enum AudioBufferUsage
{
    Static,
    Stream
}