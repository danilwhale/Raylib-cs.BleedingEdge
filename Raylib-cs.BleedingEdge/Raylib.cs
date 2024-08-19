using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge.Types;

namespace Raylib_cs.BleedingEdge;

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class Raylib
{
    public const int MajorVersion = 5;
    public const int MinorVersion = 5;
    public const int PatchVersion = 0;
    public const string VersionString = "5.5-dev";
    
    public const float Pi = 3.14159265358979323846f;
    public const float Deg2Rad = Pi / 180.0f;
    public const float Rad2Deg = 180.0f / Pi;
    
    private const string LibName = "raylib";

    /// <summary>
    /// Initialize window and OpenGL context
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void InitWindow(int width, int height, sbyte* title);
    
    /// <summary>
    /// Close window and unload OpenGL context
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void CloseWindow();
    
    /// <summary>
    /// Check if application should close (KeyboardKey.Escape pressed or windows close icon clicked)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool WindowShouldClose();
    
    /// <summary>
    /// Check if window has been initialized successfully
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowReady();
    
    /// <summary>
    /// Check if window is currently fullscreen
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowFullscreen();
    
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowHidden();
    
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowMinimized();
    
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowMaximized();
    
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowFocused();
    
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowResized();
    
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowState(ConfigFlags flag);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowState(ConfigFlags flags);
    
    [LibraryImport(LibName)]
    public static partial void ClearWindowState(ConfigFlags flags);
    
    [LibraryImport(LibName)]
    public static partial void ToggleFullscreen();
    
    [LibraryImport(LibName)]
    public static partial void ToggleBorderlessWindowed();
    
    [LibraryImport(LibName)]
    public static partial void MaximizeWindow();
    
    [LibraryImport(LibName)]
    public static partial void MinimizeWindow();
    
    [LibraryImport(LibName)]
    public static partial void RestoreWindow();
    
    [LibraryImport(LibName)]
    public static partial void SetWindowIcon(Image image);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowIcons(Image* images, int count);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowTitle(sbyte* title);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowPosition(int x, int y);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowMonitor(int monitor);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowMinSize(int width, int height);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowMaxSize(int width, int height);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowSize(int width, int height);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowOpacity(float opacity);
    
    [LibraryImport(LibName)]
    public static partial void SetWindowFocused();
    
    [LibraryImport(LibName)]
    public static partial void* GetWindowHandle();
    
    [LibraryImport(LibName)]
    public static partial int GetScreenWidth();
    
    [LibraryImport(LibName)]
    public static partial int GetScreenHeight();
    
    [LibraryImport(LibName)]
    public static partial int GetRenderWidth();
    
    [LibraryImport(LibName)]
    public static partial int GetRenderHeight();
    
    [LibraryImport(LibName)]
    public static partial int GetMonitorCount();
    
    [LibraryImport(LibName)]
    public static partial int GetCurrentMonitor();
    
    [LibraryImport(LibName)]
    public static partial Vector2 GetMonitorPosition();
    
    [LibraryImport(LibName)]
    public static partial int GetMonitorWidth(int monitor);
    
    [LibraryImport(LibName)]
    public static partial int GetMonitorHeight(int monitor);
    
    [LibraryImport(LibName)]
    public static partial int GetMonitorPhysicalWidth(int monitor);
    
    [LibraryImport(LibName)]
    public static partial int GetMonitorPhysicalHeight(int monitor);
    
    [LibraryImport(LibName)]
    public static partial int GetMonitorRefreshRate(int monitor);
    
    [LibraryImport(LibName)]
    public static partial Vector2 GetWindowPosition();
    
    [LibraryImport(LibName)]
    public static partial Vector2 GetWindowScaleDPI();
    
    [LibraryImport(LibName)]
    public static partial sbyte* GetMonitorName(int monitor);
    
    [LibraryImport(LibName)]
    public static partial void SetClipboardText(sbyte* text);
    
    [LibraryImport(LibName)]
    public static partial sbyte* GetClipboardText();
    
    [LibraryImport(LibName)]
    public static partial void EnableEventWaiting();
    
    [LibraryImport(LibName)]
    public static partial void DisableEventWaiting();
}