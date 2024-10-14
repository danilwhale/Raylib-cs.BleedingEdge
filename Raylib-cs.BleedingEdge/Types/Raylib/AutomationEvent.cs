using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Automation event
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AutomationEvent
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
    public fixed int Params[4];

    public override string ToString()
    {
        return $"<Frame:{Frame} Type:{Type} Params:<{Params[0]} {Params[1]} {Params[2]} {Params[3]}>>";
    }
}