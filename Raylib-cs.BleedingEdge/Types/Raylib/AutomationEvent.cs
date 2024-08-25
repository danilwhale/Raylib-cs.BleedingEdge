using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Enums.Raylib;

namespace Raylib_cs.BleedingEdge.Types.Raylib;

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