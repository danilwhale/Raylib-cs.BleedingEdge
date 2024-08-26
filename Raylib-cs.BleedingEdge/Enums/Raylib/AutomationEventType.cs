namespace Raylib_cs.BleedingEdge;

public enum AutomationEventType : uint
{
    None = 0,

    // Input events

    /// <summary>
    /// param[0]: key
    /// </summary>
    InputKeyUp,

    /// <summary>
    /// param[0]: key
    /// </summary>
    InputKeyDown,

    /// <summary>
    /// param[0]: key
    /// </summary>
    InputKeyPressed,

    /// <summary>
    /// param[0]: key
    /// </summary>
    InputKeyReleased,

    /// <summary>
    /// param[0]: button
    /// </summary>
    InputMouseButtonUp,

    /// <summary>
    /// param[0]: button
    /// </summary>
    InputMouseButtonDown,

    /// <summary>
    /// param[0]: x, param[1]: y
    /// </summary>
    InputMousePosition,

    /// <summary>
    /// param[0]: x delta, param[1]: y delta
    /// </summary>
    InputMouseWheelMotion,

    /// <summary>
    /// param[0]: gamepad
    /// </summary>
    InputGamepadConnect,

    /// <summary>
    /// param[0]: gamepad
    /// </summary>
    InputGamepadDisconnect,

    /// <summary>
    /// param[0]: button
    /// </summary>
    InputGamepadButtonUp,

    /// <summary>
    /// param[0]: button
    /// </summary>
    InputGamepadButtonDown,

    /// <summary>
    /// param[0]: axis, param[1]: delta
    /// </summary>
    InputGamepadAxisMotion,

    /// <summary>
    /// param[0]: id
    /// </summary>
    InputTouchUp,

    /// <summary>
    /// param[0]: id
    /// </summary>
    InputTouchDown,

    /// <summary>
    /// param[0]: x, param[1]: y
    /// </summary>
    InputTouchPosition,

    /// <summary>
    /// param[0]: gesture
    /// </summary>
    InputGesture,

    // Window events

    /// <summary>
    /// no params
    /// </summary>
    WindowClose,

    /// <summary>
    /// no params
    /// </summary>
    WindowMaximize,

    /// <summary>
    /// no params
    /// </summary>
    WindowMinimize,

    /// <summary>
    /// param[0]: width, param[1]: height
    /// </summary>
    WindowResize,

    // Custom events

    /// <summary>
    /// no params
    /// </summary>
    ActionTakeScreenshot,

    /// <summary>
    /// param[0]: fps
    /// </summary>
    ActionSetTargetFPS
}