using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Automation event
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AutomationEvent : IEquatable<AutomationEvent>
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

    public bool Equals(AutomationEvent other)
    {
        return Frame == other.Frame &&
               Type == other.Type &&
               Params[0] == other.Params[0] &&
               Params[1] == other.Params[1] &&
               Params[2] == other.Params[2] &&
               Params[3] == other.Params[3];
    }

    public override bool Equals(object? obj)
    {
        return obj is AutomationEvent other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Frame, Type, Params[0], Params[1], Params[2], Params[3]);
    }

    public static bool operator ==(AutomationEvent left, AutomationEvent right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AutomationEvent left, AutomationEvent right)
    {
        return !left.Equals(right);
    }
}