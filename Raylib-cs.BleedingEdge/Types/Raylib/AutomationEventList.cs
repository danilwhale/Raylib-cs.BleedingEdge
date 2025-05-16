using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Automation event list
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AutomationEventList : IEquatable<AutomationEventList>
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
    public AutomationEvent* Events;

    public readonly override string ToString()
    {
        return $"<Capacity:{Capacity} Count:{Count}>";
    }

    public readonly bool Equals(AutomationEventList other)
    {
        return Capacity == other.Capacity && Count == other.Count && Events == other.Events;
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is AutomationEventList other && Equals(other);
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(Capacity, Count, (nint)Events);
    }

    public static bool operator ==(AutomationEventList left, AutomationEventList right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AutomationEventList left, AutomationEventList right)
    {
        return !left.Equals(right);
    }
}