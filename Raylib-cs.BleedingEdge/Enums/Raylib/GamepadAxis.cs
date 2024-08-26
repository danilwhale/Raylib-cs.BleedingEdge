namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Gamepad axis
/// </summary>
public enum GamepadAxis
{
    /// <summary>
    /// Gamepad left stick X axis
    /// </summary>
    LeftX = 0,

    /// <summary>
    /// Gamepad left stick Y axis
    /// </summary>
    LeftY,

    /// <summary>
    /// Gamepad right stick X axis
    /// </summary>
    RightX,

    /// <summary>
    /// Gamepad right stick Y axis
    /// </summary>
    RightY,

    /// <summary>
    /// Gamepad back trigger left, pressure level: [1..-1]
    /// </summary>
    LeftTrigger,

    /// <summary>
    /// Gamepad back trigger right, pressure level: [1..-1]
    /// </summary>
    RightTrigger
}