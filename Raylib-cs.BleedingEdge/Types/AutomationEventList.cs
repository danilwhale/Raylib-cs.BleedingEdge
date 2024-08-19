using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types;

/// <summary>
/// Automation event list
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AutomationEventList
{
    /// <summary>
    /// Events max entries (MAX_AUTOMATION_EVENTS)
    /// </summary>
    public uint Capacity;

    /// <summary>
    /// Events entries count
    /// </summary>
    public uint Count;

    /// <summary>
    /// Events entries
    /// </summary>
    public unsafe AutomationEvent* Events;
}