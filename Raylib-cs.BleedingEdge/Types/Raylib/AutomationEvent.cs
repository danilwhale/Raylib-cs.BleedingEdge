using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Automation event
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AutomationEvent
{
    /// <summary>
    /// Event frame
    /// </summary>
    public uint Frame;

    /// <summary>
    /// Event type
    /// </summary>
    public AutomationEventType Type;

    /// <summary>
    /// Event parameters (if required)
    /// </summary>
    public unsafe fixed int Params[4];
}