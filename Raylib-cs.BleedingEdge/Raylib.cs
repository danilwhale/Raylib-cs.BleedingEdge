using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class Raylib
{
    public const int MajorVersion = 5;
    public const int MinorVersion = 6;
    public const int PatchVersion = 0;
    public const string VersionString = "5.6-dev";

    public const float Pi = 3.14159265358979323846f;
    public const float Deg2Rad = Pi / 180.0f;
    public const float Rad2Deg = 180.0f / Pi;
    
    private const string LibName = "raylib";

    /// <summary>
    /// Initialize window and OpenGL context
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitWindow(int width, int height, sbyte* title);

    /// <summary>
    /// Close window and unload OpenGL context
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CloseWindow();

    /// <summary>
    /// Check if application should close (KeyboardKey.Escape pressed or windows close icon clicked)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool WindowShouldClose();

    /// <summary>
    /// Check if window has been initialized successfully
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowReady();

    /// <summary>
    /// Check if window is currently fullscreen
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowFullscreen();

    /// <summary>
    /// Check if window is currently hidden
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowHidden();

    /// <summary>
    /// Check if window is currently minimized
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowMinimized();

    /// <summary>
    /// Check if window is currently maximized
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowMaximized();

    /// <summary>
    /// Check if window is currently focused
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowFocused();

    /// <summary>
    /// Check if window has been resized last frame
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowResized();

    /// <summary>
    /// Check if one specific window flag is enabled
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWindowState(ConfigFlags flag);

    /// <summary>
    /// Set window configuration state using flags
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowState(ConfigFlags flags);

    /// <summary>
    /// Clear window configuration state flags
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ClearWindowState(ConfigFlags flags);

    /// <summary>
    /// Toggle window state: fullscreen/windowed, resizes monitor to match window resolution
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ToggleFullscreen();

    /// <summary>
    /// Toggle window state: borderless windowed, resizes window to match monitor resolution
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ToggleBorderlessWindowed();

    /// <summary>
    /// Set window state: maximized, if resizable
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void MaximizeWindow();

    /// <summary>
    /// Set window state: minimized, if resizable
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void MinimizeWindow();

    /// <summary>
    /// Set window state: not minimized/maximized
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RestoreWindow();

    /// <summary>
    /// Set icon for window (single image, RGBA 32bit)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowIcon(Image image);

    /// <summary>
    /// Set icon for window (multiple images, RGBA 32bit)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowIcons(Image* images, int count);

    /// <summary>
    /// Set title for window
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowTitle(sbyte* title);

    /// <summary>
    /// Set window position on screen
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowPosition(int x, int y);

    /// <summary>
    /// Set monitor for the current window
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowMonitor(int monitor);

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowMinSize(int width, int height);

    /// <summary>
    /// Set window maximum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowMaxSize(int width, int height);

    /// <summary>
    /// Set window dimensions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowSize(int width, int height);

    /// <summary>
    /// Set window opacity [0.0f..1.0f]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowOpacity(float opacity);

    /// <summary>
    /// Set window focused
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetWindowFocused();

    /// <summary>
    /// Get native window handle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void* GetWindowHandle();

    /// <summary>
    /// Get current screen width
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetScreenWidth();

    /// <summary>
    /// Get current screen height
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetScreenHeight();

    /// <summary>
    /// Get current render width (it considers HiDPI)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetRenderWidth();

    /// <summary>
    /// Get current render height (it considers HiDPI)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetRenderHeight();

    /// <summary>
    /// Get number of connected monitors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMonitorCount();

    /// <summary>
    /// Get current monitor where window is placed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetCurrentMonitor();

    /// <summary>
    /// Get specified monitor position
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetMonitorPosition(int monitor);

    /// <summary>
    /// Get specified monitor width (current video mode used by monitor)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMonitorWidth(int monitor);

    /// <summary>
    /// Get specified monitor height (current video mode used by monitor)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMonitorHeight(int monitor);

    /// <summary>
    /// Get specified monitor physical width in millimetres
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMonitorPhysicalWidth(int monitor);

    /// <summary>
    /// Get specified monitor physical height in millimetres
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMonitorPhysicalHeight(int monitor);

    /// <summary>
    /// Get specified monitor refresh rate
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMonitorRefreshRate(int monitor);

    /// <summary>
    /// Get window position XY on monitor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetWindowPosition();

    /// <summary>
    /// Get window scale DPI factor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetWindowScaleDPI();

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the specified monitor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetMonitorName(int monitor);

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetClipboardText(sbyte* text);

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetClipboardText();

    /// <summary>
    /// Get clipboard image content
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GetClipboardImage();

    /// <summary>
    /// Enable waiting for events on EndDrawing(), no automatic event polling
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EnableEventWaiting();

    /// <summary>
    /// Disable waiting for events on EndDrawing(), automatic events polling
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DisableEventWaiting();

    /// <summary>
    /// Shows cursor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ShowCursor();

    /// <summary>
    /// Hides cursor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void HideCursor();

    /// <summary>
    /// Check if cursor is not visible
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsCursorHidden();

    /// <summary>
    /// Enables cursor (unlock cursor)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EnableCursor();

    /// <summary>
    /// Disables cursor (lock cursor)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DisableCursor();

    /// <summary>
    /// Check if cursor is on the screen
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsCursorOnScreen();

    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ClearBackground(Color color);

    /// <summary>
    /// Setup canvas (framebuffer) to start drawing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginDrawing();

    /// <summary>
    /// End canvas drawing and swap buffers (double buffering)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndDrawing();

    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginMode2D(Camera2D camera);

    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndMode2D();

    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginMode3D(Camera3D camera);

    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndMode3D();

    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginTextureMode(RenderTexture2D target);

    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndTextureMode();

    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginShaderMode(Shader shader);

    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndShaderMode();

    /// <summary>
    /// Begin blending mode (alpha, additive, multiplied, subtract, custom)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginBlendMode(BlendMode mode);

    /// <summary>
    /// End blending mode (reset to default: alpha blending)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndBlendMode();

    /// <summary>
    /// Begin scissor mode (define screen area for following drawing)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginScissorMode(int x, int y, int width, int height);

    /// <summary>
    /// End scissor mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndScissorMode();

    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void BeginVrStereoMode(VrStereoConfig config);

    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void EndVrStereoMode();

    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern VrStereoConfig LoadVrStereoConfig(VrDeviceInfo device);

    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadVrStereoConfig(VrStereoConfig config);

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Shader LoadShader(sbyte* vsFileName, sbyte* fsFileName);

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Shader LoadShaderFromMemory(sbyte* vsCode, sbyte* fsCode);

    /// <summary>
    /// Check if a shader is valid (loaded on GPU)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsShaderValid(Shader shader);

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetShaderLocation(Shader shader, sbyte* uniformName);

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetShaderLocationAttrib(Shader shader, sbyte* attribName);

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetShaderValue(Shader shader, int locIndex, void* value, ShaderUniformDataType uniformType);

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetShaderValueV(Shader shader, int locIndex, void* value, ShaderUniformDataType uniformType, int count);

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetShaderValueMatrix(Shader shader, int locIndex, Matrix4x4 mat);

    /// <summary>
    /// Set shader uniform value and bind the texture (sampler2d)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetShaderValueTexture(Shader shader, int locIndex, Texture2D texture);

    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadShader(Shader shader);
    
    /// <summary>
    /// Get a ray trace from screen position (i.e mouse)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Ray GetScreenToWorldRay(Vector2 position, Camera3D camera);

    /// <summary>
    /// Get a ray trace from screen position (i.e mouse) in a viewport
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Ray GetScreenToWorldRayEx(Vector2 position, Camera3D camera, int width, int height);

    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetWorldToScreen(Vector3 position, Camera3D camera);

    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetWorldToScreenEx(Vector3 position, Camera3D camera, int width, int height);

    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera);

    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera);

    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetCameraMatrix(Camera3D camera);

    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetCameraMatrix2D(Camera2D camera);

    /// <summary>
    /// Set target FPS (maximum)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTargetFPS(int fps);

    /// <summary>
    /// Get time in seconds for last frame drawn (delta time)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetFrameTime();

    /// <summary>
    /// Get elapsed time in seconds since InitWindow()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double GetTime();

    /// <summary>
    /// Get current FPS
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetFPS();

    /// <summary>
    /// Swap back buffer with front buffer (screen drawing)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SwapScreenBuffer();

    /// <summary>
    /// Register all input events
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PollInputEvents();

    /// <summary>
    /// Wait for some time (halt program execution)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void WaitTime(double seconds);

    /// <summary>
    /// Set the seed for the random number generator
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetRandomSeed(uint seed);

    /// <summary>
    /// Get a random value between min and max (both included)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetRandomValue(int min, int max);

    /// <summary>
    /// Load random values sequence, no values repeated
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int* LoadRandomSequence(uint count, int min, int max);

    /// <summary>
    /// Unload random values sequence
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadRandomSequence(int* sequence);

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TakeScreenshot(sbyte* fileName);

    /// <summary>
    /// Setup init configuration flags (view ConfigFlags)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetConfigFlags(ConfigFlags flags);

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void OpenURL(sbyte* url);

    /// <summary>
    /// Show trace log messages (TraceLogLevel.Debug, TraceLogLevel.Info, TraceLogLevel.Warning, TraceLogLevel.Error...)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TraceLog(TraceLogLevel logLevel, sbyte* text);

    /// <summary>
    /// Set the current threshold (minimum) log level
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTraceLogLevel(TraceLogLevel logLevel);

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void* MemAlloc(uint size);

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void* MemRealloc(void* ptr, uint size);

    /// <summary>
    /// Internal memory free
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void MemFree(void* ptr);

    /// <summary>
    /// Set custom trace log
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTraceLogCallback(delegate* unmanaged[Cdecl]<TraceLogLevel, sbyte*, nint, void> callback);

    /// <summary>
    /// Set custom file binary data loader
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetLoadFileDataCallback(delegate* unmanaged[Cdecl]<sbyte*, int*, byte*> callback);

    /// <summary>
    /// Set custom file binary data saver
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSaveFileDataCallback(delegate* unmanaged[Cdecl]<sbyte*, void*, int, NativeBool> callback);

    /// <summary>
    /// Set custom file text data loader
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetLoadFileTextCallback(delegate* unmanaged[Cdecl]<sbyte*, sbyte*> callback);

    /// <summary>
    /// Set custom file text data saver
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSaveFileTextCallback(delegate* unmanaged[Cdecl]<sbyte*, sbyte*, NativeBool> callback);

    /// <summary>
    /// Load file data as byte array (read)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte* LoadFileData(sbyte* fileName, int* dataSize);

    /// <summary>
    /// Unload file data allocated by LoadFileData()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadFileData(byte* data);

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool SaveFileData(sbyte* fileName, void* data, int dataSize);

    /// <summary>
    /// Export data to code (.h), returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportDataAsCode(byte* data, int dataSize, sbyte* fileName);

    /// <summary>
    /// Load text data from file (read), returns a '\0' terminated string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* LoadFileText(sbyte* fileName);

    /// <summary>
    /// Unload file text data allocated by LoadFileText()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadFileText(sbyte* text);

    /// <summary>
    /// Save text data to file (write), string must be '\0' terminated, returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool SaveFileText(sbyte* fileName, sbyte* text);

    /// <summary>
    /// Check if file exists
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool FileExists(sbyte* fileName);

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool DirectoryExists(sbyte* dirPath);

    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsFileExtension(sbyte* fileName, sbyte* ext);

    /// <summary>
    /// Get file length in bytes (NOTE: GetFileSize() conflicts with windows.h)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetFileLength(sbyte* fileName);

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetFileExtension(sbyte* fileName);

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetFileName(sbyte* filePath);

    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetFileNameWithoutExt(sbyte* filePath);

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetDirectoryPath(sbyte* filePath);

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetPrevDirectoryPath(sbyte* dirPath);

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetWorkingDirectory();

    /// <summary>
    /// Get the directory of the running application (uses static string)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetApplicationDirectory();

    /// <summary>
    /// Create directories (including full path requested), returns 0 on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int MakeDirectory(sbyte* dirPath);

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ChangeDirectory(sbyte* dir);

    /// <summary>
    /// Check if a given path is a file or a directory
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsPathFile(sbyte* path);

    /// <summary>
    /// Check if fileName is valid for the platform/OS
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsFileNameValid(sbyte* fileName);

    /// <summary>
    /// Load directory filepaths
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern FilePathList LoadDirectoryFiles(sbyte* dirPath);

    /// <summary>
    /// Load directory filepaths with extension filtering and recursive directory scan.
    /// Use 'DIR' in the filter string to include directories in the result
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern FilePathList LoadDirectoryFilesEx(sbyte* basePath, sbyte* filter, NativeBool scanSubdirs);

    /// <summary>
    /// Unload filepaths
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadDirectoryFiles(FilePathList files);

    /// <summary>
    /// Check if a file has been dropped into window
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsFileDropped();

    /// <summary>
    /// Load dropped filepaths
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern FilePathList LoadDroppedFiles();

    /// <summary>
    /// Unload dropped filepaths
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadDroppedFiles(FilePathList files);

    /// <summary>
    /// Get file modification time (last write time)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long GetFileModTime();

    /// <summary>
    /// Compress data (DEFLATE algorithm), memory must be MemFree()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte* CompressData(byte* data, int dataSize, int* compDataSize);

    /// <summary>
    /// Decompress data (DEFLATE algorithm), memory must be MemFree()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte* DecompressData(byte* compData, int compDataSize, int* dataSize);

    /// <summary>
    /// Encode data to Base64 string, memory must be MemFree()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* EncodeDataBase64(byte* data, int dataSize, int* outputSize);

    /// <summary>
    /// Decode Base64 string data, memory must be MemFree()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte* DecodeDataBase64(byte* data, int* outputSize);

    /// <summary>
    /// Compute CRC32 hash code
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint ComputeCRC32(byte* data, int dataSize);
    
    /// <summary>
    /// Compute MD5 hash code, returns static int[4] (16 bytes)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint* ComputeMD5(byte* data, int dataSize);
    
    /// <summary>
    /// Compute SHA1 hash code, returns static int[5] (20 bytes)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint* ComputeSHA1(byte* data, int dataSize);

    /// <summary>
    /// Load automation events list from file, NULL for empty list, capacity = MAX_AUTOMATION_EVENTS
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern AutomationEventList LoadAutomationEventList(sbyte* fileName);

    /// <summary>
    /// Unload automation events list from file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadAutomationEventList(AutomationEventList list);

    /// <summary>
    /// Export automation events list as text file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportAutomationEventList(AutomationEventList list, sbyte* fileName);

    /// <summary>
    /// Set automation event list to record to
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAutomationEventList(AutomationEventList* list);

    /// <summary>
    /// Set automation event internal base frame to start recording
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAutomationEventBaseFrame(int frame);

    /// <summary>
    /// Start recording automation events (AutomationEventList must be set)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void StartAutomationEventRecording();

    /// <summary>
    /// Stop recording automation events
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void StopAutomationEventRecording();

    /// <summary>
    /// Play a recorded automation event
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlayAutomationEvent(AutomationEvent @event);

    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsKeyPressed(KeyboardKey key);

    /// <summary>
    /// Check if a key has been pressed again
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsKeyPressedRepeat(KeyboardKey key);

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsKeyDown(KeyboardKey key);

    /// <summary>
    /// Check if a key has been released once
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsKeyReleased(KeyboardKey key);

    /// <summary>
    /// Check if a key is NOT being pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsKeyUp(KeyboardKey key);

    /// <summary>
    /// Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern KeyboardKey GetKeyPressed();

    /// <summary>
    /// Get char pressed (unicode), call it multiple times for chars queued, returns 0 when the queue is empty
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetCharPressed();
    
    /// <summary>
    /// Get name of a QWERTY key on the current keyboard layout (eg returns string 'q' for KEY_A on an AZERTY keyboard)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetKeyName(KeyboardKey key);

    /// <summary>
    /// Set a custom key to exit program (default is ESC)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetExitKey(KeyboardKey key);
    
    /// <summary>
    /// Check if a gamepad is available
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsGamepadAvailable(int gamepad);

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* GetGamepadName(int gamepad);

    /// <summary>
    /// Check if a gamepad button has been pressed once
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsGamepadButtonPressed(int gamepad, GamepadButton button);

    /// <summary>
    /// Check if a gamepad button is being pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsGamepadButtonDown(int gamepad, GamepadButton button);

    /// <summary>
    /// Check if a gamepad button has been released once
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsGamepadButtonReleased(int gamepad, GamepadButton button);

    /// <summary>
    /// Check if a gamepad button is NOT being pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsGamepadButtonUp(int gamepad, GamepadButton button);

    /// <summary>
    /// Get the last gamepad button pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern GamepadButton GetGamepadButtonPressed();

    /// <summary>
    /// Get gamepad axis count for a gamepad
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetGamepadAxisCount(int gamepad);

    /// <summary>
    /// Get axis movement value for a gamepad axis
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetGamepadAxisMovement(int gamepad, GamepadAxis axis);

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetGamepadMappings(sbyte* mappings);

    /// <summary>
    /// Set gamepad vibration for both motors (duration in seconds)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetGamepadVibration(int gamepad, float leftMotor, float rightMotor, float duration);

    /// <summary>
    /// Check if a mouse button has been pressed once
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMouseButtonPressed(MouseButton button);

    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMouseButtonDown(MouseButton button);

    /// <summary>
    /// Check if a mouse button has been released once
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMouseButtonReleased(MouseButton button);

    /// <summary>
    /// Check if a mouse button is NOT being pressed
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMouseButtonUp(MouseButton button);

    /// <summary>
    /// Get mouse position X
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMouseX();

    /// <summary>
    /// Get mouse position Y
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetMouseY();

    /// <summary>
    /// Get mouse position XY
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetMousePosition();

    /// <summary>
    /// Get mouse delta between frames
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetMouseDelta();

    /// <summary>
    /// Set mouse position XY
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMousePosition(int x, int y);

    /// <summary>
    /// Set mouse offset
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMouseOffset(int offsetX, int offsetY);

    /// <summary>
    /// Set mouse scaling
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMouseScale(float scaleX, float scaleY);

    /// <summary>
    /// Get mouse wheel movement for X or Y, whichever is larger
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMouseWheelMove();

    /// <summary>
    /// Get mouse wheel movement for both X and Y
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetMouseWheelMoveV();

    /// <summary>
    /// Set mouse cursor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMouseCursor(MouseCursor cursor);

    /// <summary>
    /// Get touch position X for touch point 0 (relative to screen size)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetTouchX();

    /// <summary>
    /// Get touch position Y for touch point 0 (relative to screen size)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetTouchY();

    /// <summary>
    /// Get touch position XY for a touch point index (relative to screen size)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetTouchPosition(int index);

    /// <summary>
    /// Get touch point identifier for given index
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetTouchPointId(int index);

    /// <summary>
    /// Get number of touch points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetTouchPointCount();

    /// <summary>
    /// Enable a set of gestures using flags
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetGesturesEnabled(Gesture flags);

    /// <summary>
    /// Check if a gesture have been detected
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsGestureDetected(Gesture gesture);

    /// <summary>
    /// Get latest detected gesture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Gesture GetGestureDetected();

    /// <summary>
    /// Get gesture hold time in seconds
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetGestureHoldDuration();

    /// <summary>
    /// Get gesture drag vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetGestureDragVector();

    /// <summary>
    /// Get gesture drag angle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetGestureDragAngle();

    /// <summary>
    /// Get gesture pinch delta
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetGesturePinchVector();

    /// <summary>
    /// Get gesture pinch angle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetGesturePinchAngle();

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateCamera(Camera3D* camera, CameraMode mode);

    /// <summary>
    /// Update camera movement/rotation
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateCameraPro(Camera3D* camera, Vector3 movement, Vector3 rotation, float zoom);

    /// <summary>
    /// Returns the cameras forward vector (normalized)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 GetCameraForward(Camera3D* camera);

    /// <summary>
    /// Returns the cameras up vector (normalized)
    /// </summary>
    /// <remarks>
    /// Note: The up vector might not be perpendicular to the forward vector
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 GetCameraUp(Camera3D* camera);

    /// <summary>
    /// Returns the cameras right vector (normalized)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 GetCameraRight(Camera3D* camera);

    /// <summary>
    /// Moves the camera in its forward direction
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraMoveForward(Camera3D* camera, float distance, NativeBool moveInWorldPlane);

    /// <summary>
    /// Moves the camera in its up direction
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraMoveUp(Camera3D* camera, float distance);

    /// <summary>
    /// Moves the camera target in its current right direction
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraMoveRight(Camera3D* camera, float distance, NativeBool moveInWorldPlane);

    /// <summary>
    /// Moves the camera position closer/farther to/from the camera target
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraMoveToTarget(Camera3D* camera, float delta);

    /// <summary>
    /// Rotates the camera around its up vector <br />
    /// Yaw is "looking left and right" <br />
    /// If rotateAroundTarget is false, the camera rotates around its position
    /// </summary>
    /// <remarks>
    /// Note: angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraYaw(Camera3D* camera, float angle, NativeBool rotateAroundTarget);

    /// <summary>
    /// Rotates the camera around its right vector, pitch is "looking up and down" <br />
    /// - lockView prevents camera overrotation (aka "somersaults") <br />
    /// - rotateAroundTarget defines if rotation is around target or around its position <br />
    /// - rotateUp rotates the up direction as well (typically only usefull in CAMERA_FREE)
    /// </summary>
    /// <remarks>
    /// NOTE: angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraPitch(
        Camera3D* camera, float angle, NativeBool lockView, NativeBool rotateAroundTarget, NativeBool rotateUp);

    /// <summary>
    /// Rotates the camera around its forward vector <br />
    /// Roll is "turning your head sideways to the left or right"
    /// </summary>
    /// <remarks>
    /// Note: angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CameraRoll(Camera3D* camera, float angle);

    /// <summary>
    /// Returns the camera view matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetCameraViewMatrix(Camera3D* camera);

    /// <summary>
    /// Returns the camera projection matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 GetCameraProjectionMatrix(Camera3D* camera, float aspect);

    /// <summary>
    /// Set texture and rectangle to be used on shapes drawing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetShapesTexture(Texture2D texture, Rectangle source);

    /// <summary>
    /// Get texture that is used for shapes drawing
    /// </summary>
    /// +
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Texture2D GetShapesTexture();

    /// <summary>
    /// Get texture source rectangle that is used for shapes drawing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Rectangle GetShapesTextureRectangle();

    /// <summary>
    /// Draw a pixel using geometry [Can be slow, use with care]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPixel(int posX, int posY, Color color);

    /// <summary>
    /// Draw a pixel using geometry (Vector version) [Can be slow, use with care]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPixelV(Vector2 position, Color color);

    /// <summary>
    /// Draw a line
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color);

    /// <summary>
    /// Draw a line (using gl lines)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawLineV(Vector2 startPos, Vector2 endPos, Color color);

    /// <summary>
    /// Draw a line (using triangles/quads)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color);

    /// <summary>
    /// Draw lines sequence (using gl lines)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawLineStrip(Vector2* points, int pointCount, Color color);

    /// <summary>
    /// Draw line segment cubic-bezier in-out interpolation
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color);

    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircle(int centerX, int centerY, float radius, Color color);

    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircleSector(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color);

    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircleSectorLines(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color);

    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircleGradient(int centerX, int centerY, float radius, Color inner, Color outter);

    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircleV(Vector2 center, float radius, Color color);

    /// <summary>
    /// Draw circle outline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircleLines(int centerX, int centerY, float radius, Color color);

    /// <summary>
    /// Draw circle outline (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircleLinesV(Vector2 center, float radius, Color color);

    /// <summary>
    /// Draw ellipse
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color);

    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color);

    /// <summary>
    /// Draw ring
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRing(
        Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color);

    /// <summary>
    /// Draw ring outline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRingLines(
        Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color);

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangle(int posX, int posY, int width, int height, Color color);

    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleV(Vector2 position, Vector2 size, Color color);

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleRec(Rectangle rec, Color color);

    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color);

    /// <summary>
    /// Draw a vertical-gradient-filled rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleGradientV(int posX, int posY, int width, int height, Color top, Color bottom);

    /// <summary>
    /// Draw a horizontal-gradient-filled rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleGradientH(int posX, int posY, int width, int height, Color left, Color right);

    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleGradientEx(Rectangle rec, Color topLeft, Color bottomLeft, Color topRight, Color bottomRight);

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleLines(int posX, int posY, int width, int height, Color color);

    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleLinesEx(Rectangle rec, float lineThick, Color color);

    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color);

    /// <summary>
    /// Draw rectangle lines with rounded edges
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, Color color);

    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRectangleRoundedLinesEx(Rectangle rec, float roundness, int segments, float lineThick, Color color);

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color);

    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTriangleFan(Vector2* points, int pointCount, Color color);

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTriangleStrip(Vector2* points, int pointCount, Color color);

    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color);

    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color);

    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPolyLinesEx(Vector2 center, int sides, float radius, float rotation, float lineThick, Color color);

    /// <summary>
    /// Draw spline: Linear, minimum 2 points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineLinear(Vector2* points, int pointCount, float thick, Color color);

    /// <summary>
    /// Draw spline: B-Spline, minimum 4 points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineBasis(Vector2* points, int pointCount, float thick, Color color);

    /// <summary>
    /// Draw spline: Catmull-Rom, minimum 4 points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineCatmullRom(Vector2* points, int pointCount, float thick, Color color);

    /// <summary>
    /// Draw spline: Quadratic Bezier, minimum 3 points (1 control point): [p1, c2, p3, c4...]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineBezierQuadratic(Vector2* points, int pointCount, float thick, Color color);

    /// <summary>
    /// Draw spline: Cubic Bezier, minimum 4 points (2 control points): [p1, c2, c3, p4, c5, c6...]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineBezierCubic(Vector2* points, int pointCount, float thick, Color color);

    /// <summary>
    /// Draw spline segment: Linear, 2 points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineSegmentLinear(Vector2 p1, Vector2 p2, float thick, Color color);

    /// <summary>
    /// Draw spline segment: B-Spline, 4 points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineSegmentBasis(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float thick, Color color);

    /// <summary>
    /// Draw spline segment: Catmull-Rom, 4 points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineSegmentCatmullRom(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float thick, Color color);

    /// <summary>
    /// Draw spline segment: Quadratic Bezier, 2 points, 1 control point
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineSegmentBezierQuadratic(Vector2 p1, Vector2 c2, Vector2 p3, float thick, Color color);

    /// <summary>
    /// Draw spline segment: Cubic Bezier, 2 points, 2 control points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSplineSegmentBezierCubic(Vector2 p1, Vector2 c2, Vector2 c3, Vector2 p4, float thick, Color color);

    /// <summary>
    /// Get (evaluate) spline point: Linear
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetSplinePointLinear(Vector2 startPos, Vector2 endPos, float t);

    /// <summary>
    /// Get (evaluate) spline point: B-Spline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetSplinePointBasis(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float t);

    /// <summary>
    /// Get (evaluate) spline point: Catmull-Rom
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetSplinePointCatmullRom(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float t);

    /// <summary>
    /// Get (evaluate) spline point: Quadratic Bezier
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetSplinePointBezierQuad(Vector2 p1, Vector2 c2, Vector2 p3, float t);

    /// <summary>
    /// Get (evaluate) spline point: Cubic Bezier
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 GetSplinePointBezierCubic(Vector2 p1, Vector2 c2, Vector2 c3, Vector2 p4, float t);

    /// <summary>
    /// Check collision between two rectangles
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionRecs(Rectangle rec1, Rectangle rec2);

    /// <summary>
    /// Check collision between two circles
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2);

    /// <summary>
    /// Check collision between circle and rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec);
    
    /// <summary>
    /// Check if circle collides with a line created betweeen two points [p1] and [p2]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionCircleLine(Vector2 center, float radius, Vector2 p1, Vector2 p2);

    /// <summary>
    /// Check if point is inside rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionPointRec(Vector2 point, Rectangle rec);

    /// <summary>
    /// Check if point is inside circle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius);

    /// <summary>
    /// Check if point is inside a triangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3);
    
    /// <summary>
    /// Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionPointLine(Vector2 point, Vector2 p1, Vector2 p2, int threshold);

    /// <summary>
    /// Check if point is within a polygon described by array of vertices
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionPointPoly(Vector2 point, Vector2* points, int pointCount);

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionLines(
        Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, Vector2* collisionPoint);

    /// <summary>
    /// Get collision rectangle for two rectangles collision
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2);

    /// <summary>
    /// Load image from file into CPU memory (RAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImage(sbyte* fileName);

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImageRaw(sbyte* fileName, int width, int height, PixelFormat format, int headerSize);

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImageAnim(sbyte* fileName, int* frames);

    /// <summary>
    /// Load image sequence from memory buffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImageAnimFromMemory(sbyte* fileType, byte* fileData, int dataSize, int* frames);

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImageFromMemory(sbyte* fileType, byte* fileData, int dataSize);

    /// <summary>
    /// Load image from GPU texture data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImageFromTexture(Texture2D texture);

    /// <summary>
    /// Load image from screen buffer and (screenshot)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image LoadImageFromScreen();

    /// <summary>
    /// Check if an image is valid (data and parameters)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsImageValid(Image image);

    /// <summary>
    /// Unload image from CPU memory (RAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadImage(Image image);

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportImage(Image image, sbyte* fileName);

    /// <summary>
    /// Export image to memory buffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte* ExportImageToMemory(Image image, sbyte* fileType, int* fileSize);

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportImageAsCode(Image image, sbyte* fileName);

    /// <summary>
    /// Generate image: plain color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageColor(int width, int height, Color color);

    /// <summary>
    /// Generate image: linear gradient, direction in degrees [0..360], 0=Vertical gradient
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageGradientLinear(int width, int height, int direction, Color start, Color end);

    /// <summary>
    /// Generate image: radial gradient
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer);

    /// <summary>
    /// Generate image: square gradient
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageGradientSquare(int width, int height, float density, Color inner, Color outer);

    /// <summary>
    /// Generate image: checked
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2);

    /// <summary>
    /// Generate image: white noise
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageWhiteNoise(int width, int height, float factor);

    /// <summary>
    /// Generate image: perlin noise
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImagePerlinNoise(int width, int height, int offsetX, int offsetY, float scale);

    /// <summary>
    /// Generate image: cellular algorithm, bigger tileSize means bigger cells
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageCellular(int width, int height, int tileSize);

    /// <summary>
    /// Generate image: grayscale image from text data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageText(int width, int height, sbyte* text);

    /// <summary>
    /// Create an image duplicate (useful for transformations)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image ImageCopy(Image image);

    /// <summary>
    /// Create an image from another image piece
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image ImageFromImage(Image image, Rectangle rec);

    /// <summary>
    /// Create an image from a selected channel of another image (GRAYSCALE)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image ImageFromChannel(Image image, int selectedChannel);

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image ImageText(sbyte* text, int fontSize, Color color);

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image ImageTextEx(Font font, sbyte* text, float fontSize, float spacing, Color tint);

    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageFormat(Image* image, PixelFormat newFormat);

    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageToPOT(Image* image, Color fill);

    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageCrop(Image* image, Rectangle crop);

    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageAlphaCrop(Image* image, float threshold);

    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageAlphaClear(Image* image, Color color, float threshold);

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageAlphaMask(Image* image, Image alphaMask);

    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageAlphaPremultiply(Image* image);

    /// <summary>
    /// Apply Gaussian blur using a box blur approximation
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageBlurGaussian(Image* image, int blurSize);

    /// <summary>
    /// Apply custom square convolution kernel to image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageKernelConvolution(Image* image, float* kernel, int kernelSize);

    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageResize(Image* image, int newWidth, int newHeight);

    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageResizeNN(Image* image, int newWidth, int newHeight);

    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageResizeCanvas(Image* image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill);

    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageMipmaps(Image* image);

    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDither(Image* image, int rBpp, int gBpp, int bBpp, int aBpp);

    /// <summary>
    /// Flip image vertically
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageFlipVertical(Image* image);

    /// <summary>
    /// Flip image horizontally
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageFlipHorizontal(Image* image);

    /// <summary>
    /// Rotate image by input angle in degrees (-359 to 359)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageRotate(Image* image, int degrees);

    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageRotateCW(Image* image);

    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageRotateCCW(Image* image);

    /// <summary>
    /// Modify image color: tint
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageColorTint(Image* image, Color color);

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageColorInvert(Image* image);

    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageColorGrayscale(Image* image);

    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageColorContrast(Image* image, float contrast);

    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageColorBrightness(Image* image, int brightness);

    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageColorReplace(Image* image, Color color, Color replace);

    /// <summary>
    /// Load color data from image as a Color array (RGBA - 32bit)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color* LoadImageColors(Image image);

    /// <summary>
    /// Load colors palette from image as a Color array (RGBA - 32bit)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color* LoadImagePalette(Image image, int maxPaletteSize, int* colorCount);

    /// <summary>
    /// Unload color data loaded with LoadImageColors()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadImageColors(Color* colors);

    /// <summary>
    /// Unload colors palette loaded with LoadImagePalette()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadImagePalette(Color* colors);

    /// <summary>
    /// Get image alpha border rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Rectangle GetImageAlphaBorder(Image image, float threshold);

    /// <summary>
    /// Get image pixel color at (x, y) position
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color GetImageColor(Image image, int x, int y);

    /// <summary>
    /// Clear image background with given color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageClearBackground(Image* dst, Color color);

    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawPixel(Image* dst, int posX, int posY, Color color);

    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawPixelV(Image* dst, Vector2 position, Color color);

    /// <summary>
    /// Draw line within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawLine(Image* dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color);

    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawLineV(Image* dst, Vector2 start, Vector2 end, Color color);

    /// <summary>
    /// Draw a line defining thickness within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawLineEx(Image* dst, Vector2 start, Vector2 end, int thick, Color color);

    /// <summary>
    /// Draw a filled circle within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawCircle(Image* dst, int centerX, int centerY, int radius, Color color);

    /// <summary>
    /// Draw a filled circle within an image (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawCircleV(Image* dst, Vector2 center, int radius, Color color);

    /// <summary>
    /// Draw circle outline within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawCircleLines(Image* dst, int centerX, int centerY, int radius, Color color);

    /// <summary>
    /// Draw circle outline within an image (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawCircleLinesV(Image* dst, Vector2 center, int radius, Color color);

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawRectangle(Image* dst, int posX, int posY, int width, int height, Color color);

    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawRectangleV(Image* dst, Vector2 position, Vector2 size, Color color);

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawRectangleRec(Image* dst, Rectangle rec, Color color);

    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawRectangleLines(Image* dst, Rectangle rec, int thick, Color color);

    /// <summary>
    /// Draw triangle within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawTriangle(Image* dst, Vector2 v1, Vector2 v2, Vector2 v3, Color color);

    /// <summary>
    /// Draw triangle with interpolated colors within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawTriangleEx(Image* dst, Vector2 v1, Vector2 v2, Vector2 v3, Color c1, Color c2, Color c3);

    /// <summary>
    /// Draw triangle outline within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawTriangleLines(Image* dst, Vector2 v1, Vector2 v2, Vector2 v3, Color color);

    /// <summary>
    /// Draw a triangle fan defined by points within an image (first vertex is the center)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawTriangleFan(Image* dst, Vector2* points, int pointCount, Color color);

    /// <summary>
    /// Draw a triangle strip defined by points within an image
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawTriangleStrip(Image* dst, Vector2* points, int pointCount, Color color);

    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDraw(Image* dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint);

    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawText(Image* dst, sbyte* text, int posX, int posY, int fontSize, Color color);

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ImageDrawTextEx(Image* dst, Font font, sbyte* text, Vector2 position, float fontSize, float spacing, Color tint);

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Texture2D LoadTexture(sbyte* fileName);

    /// <summary>
    /// Load texture from image data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Texture2D LoadTextureFromImage(Image image);

    /// <summary>
    /// Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Texture2D LoadTextureCubemap(Image image, CubemapLayout layout);

    /// <summary>
    /// Load texture for rendering (framebuffer)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern RenderTexture2D LoadRenderTexture(int width, int height);

    /// <summary>
    /// Check if a texture is valid (loaded in GPU)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsTextureValid(Texture2D texture);

    /// <summary>
    /// Unload texture from GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadTexture(Texture2D texture);

    /// <summary>
    /// Check if a render texture is valid (loaded in GPU)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsRenderTextureValid(RenderTexture2D target);

    /// <summary>
    /// Unload render texture from GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadRenderTexture(RenderTexture2D target);

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateTexture(Texture2D texture, void* pixels);

    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateTextureRec(Texture2D texture, Rectangle rec, void* pixels);

    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GenTextureMipmaps(Texture2D* texture);

    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTextureFilter(Texture2D texture, TextureFilter filter);

    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTextureWrap(Texture2D texture, TextureWrap wrap);

    /// <summary>
    /// Draw a Texture2D
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTexture(Texture2D texture, int posX, int posY, Color tint);

    /// <summary>
    /// Draw a Texture2D with position defined as Vector2
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextureV(Texture2D texture, Vector2 position, Color tint);

    /// <summary>
    /// Draw a Texture2D with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint);

    /// <summary>
    /// Draw a part of a texture defined by a rectangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextureRec(Texture2D texture, Rectangle source, Vector2 position, Color tint);

    /// <summary>
    /// Draw a part of a texture defined by a rectangle with 'pro' parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTexturePro(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint);

    /// <summary>
    /// Draws a texture (or part of it) that stretches or shrinks nicely
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextureNPatch(
        Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint);

    /// <summary>
    /// Check if two colors are equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ColorIsEqual(Color col1, Color col2);

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color Fade(Color color, float alpha);

    /// <summary>
    /// Get hexadecimal value for a Color (0xRRGGBBAA)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int ColorToInt(Color color);

    /// <summary>
    /// Get Color normalized as float [0..1]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 ColorNormalize(Color color);

    /// <summary>
    /// Get Color from normalized values [0..1]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorFromNormalized(Vector4 normalized);

    /// <summary>
    /// Get HSV values for a Color, hue [0..360], saturation/value [0..1]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 ColorToHSV(Color color);

    /// <summary>
    /// Get a Color from HSV values, hue [0..360], saturation/value [0..1]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorFromHSV(float hue, float saturation, float value);

    /// <summary>
    /// Get color multiplied with another color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorTint(Color color, Color tint);

    /// <summary>
    /// Get color with brightness correction, brightness factor goes from -1.0f to 1.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorBrightness(Color color, float factor);

    /// <summary>
    /// Get color with contrast correction, contrast values between -1.0f and 1.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorContrast(Color color, float contrast);

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorAlpha(Color color, float alpha);

    /// <summary>
    /// Get src alpha-blended into dst color with tint
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorAlphaBlend(Color dst, Color src, Color tint);

    /// <summary>
    /// Get Color structure from hexadecimal value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color GetColor(uint hexValue);

    /// <summary>
    /// Get Color from a source pixel pointer of certain format
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color GetPixelColor(void* srcPtr, PixelFormat format);

    /// <summary>
    /// Set color formatted into destination pixel pointer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetPixelColor(void* dstPtr, Color color, PixelFormat format);

    /// <summary>
    /// Get pixel data size in bytes for certain format
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetPixelDataSize(int width, int height, PixelFormat format);

    /// <summary>
    /// Get color lerp interpolation between two colors, factor [0.0f..1.0f]
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Color ColorLerp(Color color1, Color color2, float factor);

    /// <summary>
    /// Get the default Font
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Font GetFontDefault();

    /// <summary>
    /// Load font from file into GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Font LoadFont(sbyte* fileName);

    /// <summary>
    /// Load font from file with extended parameters, use NULL for codepoints and 0 for codepointCount to load the default
    /// character set, font size is provided in pixels height
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Font LoadFontEx(sbyte* fileName, int fontSize, int* codepoints, int codepointCount);

    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Font LoadFontFromImage(Image image, Color key, int firstChar);

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Font LoadFontFromMemory(
        sbyte* fileType, byte* fileData, int dataSize, int fontSize, int* codepoints, int codepointCount);

    /// <summary>
    /// Check if a font is valid (font data loaded, WARNING: GPU texture not checked)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsFontValid(Font font);

    /// <summary>
    /// Load font data for further use
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern GlyphInfo* LoadFontData(byte* fileData, int dataSize, int fontSize, int* codepoints, int codepointCount, FontType type);

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Image GenImageFontAtlas(
        GlyphInfo* glyphs, Rectangle** glyphRecs, int glyphCount, int fontSize, int padding, int packMethod);

    /// <summary>
    /// Unload font chars info data (RAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadFontData(GlyphInfo* glyphs, int glyphCount);

    /// <summary>
    /// Unload font from GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadFont(Font font);

    /// <summary>
    /// Export font as code file, returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportFontAsCode(Font font, sbyte* fileName);

    /// <summary>
    /// Draw current FPS
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawFPS(int posX, int posY);

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawText(sbyte* text, int posX, int posY, int fontSize, Color color);

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextEx(Font font, sbyte* text, Vector2 position, float fontSize, float spacing, Color tint);

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextPro(
        Font font, sbyte* text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint);

    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint);

    /// <summary>
    /// Draw multiple character (codepoint)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTextCodepoints(
        Font font, int* codepoints, int codepointCount, Vector2 position, float fontSize, float spacing, Color tint);

    /// <summary>
    /// Set vertical line spacing when drawing with line-breaks
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetTextLineSpacing(int spacing);

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int MeasureText(sbyte* text, int fontSize);

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 MeasureTextEx(Font font, sbyte* text, float fontSize, float spacing);

    /// <summary>
    /// Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetGlyphIndex(Font font, int codepoint);

    /// <summary>
    /// Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern GlyphInfo GetGlyphInfo(Font font, int codepoint);

    /// <summary>
    /// Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Rectangle GetGlyphAtlasRec(Font font, int codepoint);

    /// <summary>
    /// Load UTF-8 text encoded from codepoints array
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* LoadUTF8(int* codepoints, int length);

    /// <summary>
    /// Unload UTF-8 text encoded from codepoints array
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadUTF8(sbyte* text);

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int* LoadCodepoints(sbyte* text, int* count);

    /// <summary>
    /// Unload codepoints data from memory
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadCodepoints(int* codepoints);

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetCodepointCount(sbyte* text);

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetCodepoint(sbyte* text, int* codepointSize);

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetCodepointNext(sbyte* text, int* codepointSize);

    /// <summary>
    /// Get previous codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetCodepointPrevious(sbyte* text, int* codepointSize);

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* CodepointToUTF8(int codepoint, int* utf8Size);

    /// <summary>
    /// Copy one string to another, returns bytes copied
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TextCopy(sbyte* dst, sbyte* src);

    /// <summary>
    /// Check if two text string are equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool TextIsEqual(sbyte* text1, sbyte* text2);

    /// <summary>
    /// Get text length, checks for '\0' ending
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint TextLength(sbyte* text);

    // TODO: add support for variable args and implement the function
    /// <summary>
    /// Text formatting with variables (sprintf() style)
    /// </summary>
    public static sbyte* TextFormat(sbyte* text)
    {
        throw new Exception("Function not implemented.");
    }

    /// <summary>
    /// Get a piece of a text string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextSubtext(sbyte* text, int position, int length);

    /// <summary>
    /// Replace text string (WARNING: memory must be freed!)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextReplace(sbyte* text, sbyte* replace, sbyte* by);

    /// <summary>
    /// Insert text in a position (WARNING: memory must be freed!)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextInsert(sbyte* text, sbyte* insert, int position);

    /// <summary>
    /// Join text strings with delimiter
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextJoin(sbyte** textList, int count, sbyte* delimiter);

    /// <summary>
    /// Split text into multiple strings
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte** TextSplit(sbyte* text, sbyte delimeter, int* count);

    /// <summary>
    /// Append text at specific position and move cursor!
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TextAppend(sbyte* text, sbyte* append, int* position);

    /// <summary>
    /// Find first text occurrence within a string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TextFindIndex(sbyte* text, sbyte* find);

    /// <summary>
    /// Get upper case version of provided string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextToUpper(sbyte* text);

    /// <summary>
    /// Get lower case version of provided string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextToLower(sbyte* text);

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextToPascal(sbyte* text);

    /// <summary>
    /// Get Snake case notation version of provided string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextToSnake(sbyte* text);

    /// <summary>
    /// Get Camel case notation version of provided string
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* TextToCamel(sbyte* text);

    /// <summary>
    /// Get integer value from text
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TextToInteger(sbyte* text);

    /// <summary>
    /// Get float value from text
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float TextToFloat(sbyte* text);

    /// <summary>
    /// Draw a line in 3D world space
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color);

    /// <summary>
    /// Draw a point in 3D space, actually a small line
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPoint3D(Vector3 position, Color color);

    /// <summary>
    /// Draw a circle in 3D world space
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color);

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color);

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawTriangleStrip3D(Vector3* points, int pointCount, Color color);

    /// <summary>
    /// Draw cube
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCube(Vector3 position, float width, float height, float length, Color color);

    /// <summary>
    /// Draw cube (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCubeV(Vector3 position, Vector3 size, Color color);

    /// <summary>
    /// Draw cube wires
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCubeWires(Vector3 position, float width, float height, float length, Color color);

    /// <summary>
    /// Draw cube wires (Vector version)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCubeWiresV(Vector3 position, Vector3 size, Color color);

    /// <summary>
    /// Draw sphere
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSphere(Vector3 centerPos, float radius, Color color);

    /// <summary>
    /// Draw sphere with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color);

    /// <summary>
    /// Draw sphere wires
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color);

    /// <summary>
    /// Draw sphere wires
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

    /// <summary>
    /// Draw a cylinder/cone
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCylinderEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color);

    /// <summary>
    /// Draw a cylinder with base at startPos and top at endPos
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color);

    /// <summary>
    /// Draw a cylinder/cone wires
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCylinderWiresEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int slices, Color color);

    /// <summary>
    /// Draw a cylinder wires with base at startPos and top at endPos
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCapsule(Vector3 startPos, Vector3 endPos, float radius, int slices, int rings, Color color);

    /// <summary>
    /// Draw capsule wireframe with the center of its sphere caps at startPos and endPos
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawCapsuleWires(Vector3 startPos, Vector3 endPos, float radius, int slices, int rings, Color color);

    /// <summary>
    /// Draw a plane XZ
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawPlane(Vector3 centerPos, Vector2 size, Color color);

    /// <summary>
    /// Draw a ray line
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawRay(Ray ray, Color color);

    /// <summary>
    /// Draw a grid (centered at (0, 0, 0))
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawGrid(int slices, float spacing);

    /// <summary>
    /// Load model from files (meshes and materials)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Model LoadModel(sbyte* fileName);

    /// <summary>
    /// Load model from generated mesh (default material)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Model LoadModelFromMesh(Mesh mesh);

    /// <summary>
    /// Check if a model is valid (loaded in GPU, VAO/VBOs)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsModelValid(Model model);

    /// <summary>
    /// Unload model (including meshes) from memory (RAM and/or VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadModel(Model model);

    /// <summary>
    /// Compute model bounding box limits (considers all meshes)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern BoundingBox GetModelBoundingBox(Model model);

    /// <summary>
    /// Draw a model (with texture if set)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawModel(Model model, Vector3 position, float scale, Color tint);

    /// <summary>
    /// Draw a model with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

    /// <summary>
    /// Draw a model wires (with texture if set)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawModelWires(Model model, Vector3 position, float scale, Color tint);

    /// <summary>
    /// Draw a model wires (with texture if set) with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawModelWiresEx(
        Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

    /// <summary>
    /// Draw a model as points
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawModelPoints(Model model, Vector3 position, float scale, Color tint);

    /// <summary>
    /// Draw a model as points with extended parameters
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawModelPointsEx(
        Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint);

    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawBoundingBox(BoundingBox box, Color color);

    /// <summary>
    /// Draw a billboard texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawBillboard(Camera3D camera, Texture2D texture, Vector3 position, float scale, Color tint);

    /// <summary>
    /// Draw a billboard texture defined by source
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawBillboardRec(Camera3D camera, Texture2D texture, Rectangle source, Vector3 position, Vector2 size, Color tint);

    /// <summary>
    /// Draw a billboard texture defined by source and rotation
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawBillboardPro(
        Camera3D camera, Texture2D texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation,
        Color tint);

    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UploadMesh(Mesh* mesh, NativeBool dynamic);

    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateMeshBuffer(Mesh mesh, int index, void* data, int dataSize, int offset);

    /// <summary>
    /// Unload mesh data from CPU and GPU
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadMesh(Mesh mesh);

    /// <summary>
    /// Draw a 3d mesh with material and transform
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawMesh(Mesh mesh, Material material, Matrix4x4 transform);

    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DrawMeshInstanced(Mesh mesh, Material material, Matrix4x4* transforms, int instances);

    /// <summary>
    /// Compute mesh bounding box limits
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern BoundingBox GetMeshBoundingBox(Mesh mesh);

    /// <summary>
    /// Compute mesh tangents
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GenMeshTangents(Mesh* mesh);

    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportMesh(Mesh mesh, sbyte* fileName);

    /// <summary>
    /// Export mesh as code file (.h) defining multiple arrays of vertex attributes
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportMeshAsCode(Mesh mesh, sbyte* fileName);

    /// <summary>
    /// Generate polygonal mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshPoly(int sides, float radius);

    /// <summary>
    /// Generate plane mesh (with subdivisions)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshPlane(float width, float length, int resX, int resZ);

    /// <summary>
    /// Generate cuboid mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshCube(float width, float height, float length);

    /// <summary>
    /// Generate sphere mesh (standard sphere)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshSphere(float radius, int rings, int slices);

    /// <summary>
    /// Generate half-sphere mesh (no bottom cap)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshHemiSphere(float radius, int rings, int slices);

    /// <summary>
    /// Generate cylinder mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshCylinder(float radius, float height, int slices);

    /// <summary>
    /// Generate cone/pyramid mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshCone(float radius, float height, int slices);

    /// <summary>
    /// Generate torus mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshTorus(float radius, float size, int radSeg, int sides);

    /// <summary>
    /// Generate trefoil knot mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshKnot(float radius, float size, int radSeg, int sides);

    /// <summary>
    /// Generate heightmap mesh from image data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshHeightmap(Image heightmap, Vector3 size);

    /// <summary>
    /// Generate cubes-based map mesh from image data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize);

    /// <summary>
    /// Load materials from model file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Material* LoadMaterials(sbyte* fileName, int* materialCount);

    /// <summary>
    /// Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Material LoadMaterialDefault();

    /// <summary>
    /// Check if a material is valid (shader assigned, map textures loaded in GPU)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMaterialValid(Material material);

    /// <summary>
    /// Unload material from GPU memory (VRAM)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadMaterial(Material material);

    /// <summary>
    /// Set texture for a material map type (MATERIAL_MAP_DIFFUSE, MATERIAL_MAP_SPECULAR...)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMaterialTexture(Material* material, MaterialMapIndex mapType, Texture2D texture);

    /// <summary>
    /// Set material for a mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetModelMeshMaterial(Model* model, int meshId, int materialid);

    /// <summary>
    /// Load model animations from file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ModelAnimation* LoadModelAnimations(sbyte* fileName, int* animCount);

    /// <summary>
    /// Update model animation pose (CPU)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateModelAnimation(Model model, ModelAnimation anim, int frame);
    
    /// <summary>
    /// Update model animation mesh bone matrices (GPU skinning)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateModelAnimationBones(Model model, ModelAnimation anim, int frame);

    /// <summary>
    /// Unload animation data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadModelAnimation(ModelAnimation anim);

    /// <summary>
    /// Unload animation array data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadModelAnimations(ModelAnimation* animations, int animCount);

    /// <summary>
    /// Check model animation skeleton match
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsModelAnimationValid(Model model, ModelAnimation anim);

    /// <summary>
    /// Check collision between two spheres
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2);

    /// <summary>
    /// Check collision between two bounding boxes
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2);

    /// <summary>
    /// Check collision between box and sphere
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius);

    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern RayCollision GetRayCollisionSphere(Ray ray, Vector3 center, float radius);

    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern RayCollision GetRayCollisionBox(Ray ray, BoundingBox box);

    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern RayCollision GetRayCollisionMesh(Ray ray, Mesh mesh, Matrix4x4 transform);

    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern RayCollision GetRayCollisionTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3);

    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern RayCollision GetRayCollisionQuad(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4);

    /// <summary>
    /// Initialize audio device and context
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void InitAudioDevice();

    /// <summary>
    /// Close the audio device and context
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void CloseAudioDevice();

    /// <summary>
    /// Check if audio device has been initialized successfully
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsAudioDeviceReady();

    /// <summary>
    /// Set master volume (listener)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMasterVolume(float volume);

    /// <summary>
    /// Get master volume (listener)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMasterVolume();

    /// <summary>
    /// Load wave data from file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Wave LoadWave(sbyte* fileName);

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Wave LoadWaveFromMemory(sbyte* fileType, byte* fileData, int dataSize);

    /// <summary>
    /// Checks if wave data is valid (data loaded and parameters)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsWaveValid(Wave wave);

    /// <summary>
    /// Load sound from file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Sound LoadSound(sbyte* fileName);

    /// <summary>
    /// Load sound from wave data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Sound LoadSoundFromWave(Wave wave);

    /// <summary>
    /// Create a new sound that shares the same sample data as the source sound, does not own the sound data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Sound LoadSoundAlias(Sound source);

    /// <summary>
    /// Checks if a sound is valid (data loaded and buffers initialized)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsSoundValid(Sound sound);

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateSound(Sound sound, void* data, int sampleCount);

    /// <summary>
    /// Unload wave data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadWave(Wave wave);

    /// <summary>
    /// Unload sound
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadSound(Sound sound);

    /// <summary>
    /// Unload a sound alias (does not deallocate sample data)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadSoundAlias(Sound alias);

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportWave(Wave wave, sbyte* fileName);

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool ExportWaveAsCode(Wave wave, sbyte* fileName);

    /// <summary>
    /// Play a sound
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlaySound(Sound sound);

    /// <summary>
    /// Stop playing a sound
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void StopSound(Sound sound);

    /// <summary>
    /// Pause a sound
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PauseSound(Sound sound);

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ResumeSound(Sound sound);

    /// <summary>
    /// Check if a sound is currently playing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsSoundPlaying(Sound sound);

    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSoundVolume(Sound sound, float volume);

    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSoundPitch(Sound sound, float pitch);

    /// <summary>
    /// Set pan for a sound (0.5 is center)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSoundPan(Sound sound, float pan);

    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Wave WaveCopy(Wave wave);

    /// <summary>
    /// Crop a wave to defined frames range
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void WaveCrop(Wave* wave, int initFrame, int finalFrame);

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void WaveFormat(Wave* wave, int sampleRate, int sampleSize, int channels);

    /// <summary>
    /// Load samples data from wave as a 32bit float data array
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float* LoadWaveSamples(Wave wave);

    /// <summary>
    /// Unload samples data loaded with LoadWaveSamples()
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadWaveSamples(float* samples);

    /// <summary>
    /// Load music stream from file
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Music LoadMusicStream(sbyte* fileName);

    /// <summary>
    /// Load music stream from data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Music LoadMusicStreamFromMemory(sbyte* fileType, byte* data, int dataSize);

    /// <summary>
    /// Checks if a music stream is valid (context and buffers initialized)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMusicValid(Music music);

    /// <summary>
    /// Unload music stream
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadMusicStream(Music music);

    /// <summary>
    /// Start music playing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlayMusicStream(Music music);

    /// <summary>
    /// Check if music is playing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsMusicStreamPlaying(Music music);

    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateMusicStream(Music music);

    /// <summary>
    /// Stop music playing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void StopMusicStream(Music music);

    /// <summary>
    /// Pause music playing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PauseMusicStream(Music music);

    /// <summary>
    /// Resume playing paused music
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ResumeMusicStream(Music music);

    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SeekMusicStream(Music music, float position);

    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMusicVolume(Music music, float volume);

    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMusicPitch(Music music, float pitch);

    /// <summary>
    /// Set pan for a music (0.5 is center)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMusicPan(Music music, float pan);

    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMusicTimeLength(Music music);

    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMusicTimePlayed(Music music);

    /// <summary>
    /// Load audio stream (to stream raw audio pcm data)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern AudioStream LoadAudioStream(uint sampleRate, uint sampleSize, uint channels);

    /// <summary>
    /// Checks if an audio stream is valid (buffers initialized)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsAudioStreamValid(AudioStream stream);

    /// <summary>
    /// Unload audio stream and free memory
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnloadAudioStream(AudioStream stream);

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateAudioStream(AudioStream stream, void* data, int frameCount);

    /// <summary>
    /// Check if any audio stream buffers requires refill
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsAudioStreamProcessed(AudioStream stream);

    /// <summary>
    /// Play audio stream
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlayAudioStream(AudioStream stream);

    /// <summary>
    /// Pause audio stream
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PauseAudioStream(AudioStream stream);

    /// <summary>
    /// Resume audio stream
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void ResumeAudioStream(AudioStream stream);

    /// <summary>
    /// Check if audio stream is playing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern NativeBool IsAudioStreamPlaying(AudioStream stream);

    /// <summary>
    /// Stop audio stream
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void StopAudioStream(AudioStream stream);

    /// <summary>
    /// Set volume for audio stream (1.0 is max level)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAudioStreamVolume(AudioStream stream, float volume);

    /// <summary>
    /// Set pitch for audio stream (1.0 is base level)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAudioStreamPitch(AudioStream stream, float pitch);

    /// <summary>
    /// Set pan for audio stream (0.5 is centered)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAudioStreamPan(AudioStream stream, float pan);

    /// <summary>
    /// Default size for new audio streams
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAudioStreamBufferSizeDefault(int size);

    /// <summary>
    /// Audio thread callback to request new data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAudioStreamCallback(AudioStream stream, delegate* unmanaged[Cdecl]<void*, uint, void> callback);

    /// <summary>
    /// Attach audio stream processor to stream, receives frames x 2 samples as 'float' (stereo)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AttachAudioStreamProcessor(AudioStream stream, delegate* unmanaged[Cdecl]<void*, uint, void> processor);

    /// <summary>
    /// Detach audio stream processor from stream
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DetachAudioStreamProcessor(AudioStream stream, delegate* unmanaged[Cdecl]<void*, uint, void> processor);

    /// <summary>
    /// Attach audio stream processor to the entire audio pipeline, receives frames x 2 samples as 'float' (stereo)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AttachAudioMixedProcessor(delegate* unmanaged[Cdecl]<void*, uint, void> processor);

    /// <summary>
    /// Detach audio stream processor from the entire audio pipeline
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void DetachAudioMixedProcessor(delegate* unmanaged[Cdecl]<void*, uint, void> processor);
}