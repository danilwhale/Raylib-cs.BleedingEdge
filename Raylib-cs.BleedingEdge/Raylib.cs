using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge.Types;

[assembly: DisableRuntimeMarshalling]

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

    /// <summary>
    /// Check if window is currently hidden (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowHidden();

    /// <summary>
    /// Check if window is currently minimized (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowMinimized();

    /// <summary>
    /// Check if window is currently maximized (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowMaximized();

    /// <summary>
    /// Check if window is currently focused (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowFocused();

    /// <summary>
    /// Check if window has been resized last frame
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowResized();

    /// <summary>
    /// Check if one specific window flag is enabled
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsWindowState(ConfigFlags flag);

    /// <summary>
    /// Set window configuration state using flags (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowState(ConfigFlags flags);

    /// <summary>
    /// Clear window configuration state flags
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void ClearWindowState(ConfigFlags flags);

    /// <summary>
    /// Toggle window state: fullscreen/windowed (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void ToggleFullscreen();

    /// <summary>
    /// Toggle window state: borderless windowed (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void ToggleBorderlessWindowed();

    /// <summary>
    /// Set window state: maximized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void MaximizeWindow();

    /// <summary>
    /// Set window state: minimized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void MinimizeWindow();

    /// <summary>
    /// Set window state: not minimized/maximized (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void RestoreWindow();

    /// <summary>
    /// Set icon for window (single image, RGBA 32bit, only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowIcon(Image image);

    /// <summary>
    /// Set icon for window (multiple images, RGBA 32bit, only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowIcons(Image* images, int count);

    /// <summary>
    /// Set title for window (only PLATFORM_DESKTOP and PLATFORM_WEB)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowTitle(sbyte* title);

    /// <summary>
    /// Set window position on screen (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowPosition(int x, int y);

    /// <summary>
    /// Set monitor for the current window
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowMonitor(int monitor);

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowMinSize(int width, int height);

    /// <summary>
    /// Set window maximum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowMaxSize(int width, int height);

    /// <summary>
    /// Set window dimensions
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowSize(int width, int height);

    /// <summary>
    /// Set window opacity [0.0f..1.0f] (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowOpacity(float opacity);

    /// <summary>
    /// Set window focused (only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetWindowFocused();

    /// <summary>
    /// Get native window handle
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void* GetWindowHandle();

    /// <summary>
    /// Get current screen width
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetScreenWidth();

    /// <summary>
    /// Get current screen height
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetScreenHeight();

    /// <summary>
    /// Get current render width (it considers HiDPI)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetRenderWidth();

    /// <summary>
    /// Get current render height (it considers HiDPI)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetRenderHeight();

    /// <summary>
    /// Get number of connected monitors
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMonitorCount();

    /// <summary>
    /// Get current connected monitor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetCurrentMonitor();

    /// <summary>
    /// Get specified monitor position
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetMonitorPosition(int monitor);

    /// <summary>
    /// Get specified monitor width (current video mode used by monitor)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMonitorWidth(int monitor);

    /// <summary>
    /// Get specified monitor height (current video mode used by monitor)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMonitorHeight(int monitor);

    /// <summary>
    /// Get specified monitor physical width in millimetres
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMonitorPhysicalWidth(int monitor);

    /// <summary>
    /// Get specified monitor physical height in millimetres
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMonitorPhysicalHeight(int monitor);

    /// <summary>
    /// Get specified monitor refresh rate
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMonitorRefreshRate(int monitor);

    /// <summary>
    /// Get window position XY on monitor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetWindowPosition();

    /// <summary>
    /// Get window scale DPI factor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetWindowScaleDPI();

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the specified monitor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetMonitorName(int monitor);

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetClipboardText(sbyte* text);

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetClipboardText();

    /// <summary>
    /// Enable waiting for events on EndDrawing(), no automatic event polling
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EnableEventWaiting();

    /// <summary>
    /// Disable waiting for events on EndDrawing(), automatic events polling
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void DisableEventWaiting();

    /// <summary>
    /// Shows cursor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void ShowCursor();

    /// <summary>
    /// Hides cursor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void HideCursor();

    /// <summary>
    /// Check if cursor is not visible
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsCursorHidden();

    /// <summary>
    /// Enables cursor (unlock cursor)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EnableCursor();

    /// <summary>
    /// Disables cursor (lock cursor)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void DisableCursor();

    /// <summary>
    /// Check if cursor is on the screen
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsCursorOnScreen();

    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void ClearBackground(Color color);

    /// <summary>
    /// Setup canvas (framebuffer) to start drawing
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginDrawing();

    /// <summary>
    /// End canvas drawing and swap buffers (double buffering)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndDrawing();

    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginMode2D(Camera2D camera);

    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndMode2D();

    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginMode3D(Camera3D camera);

    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndMode3D();

    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginTextureMode(RenderTexture target);

    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndTextureMode();

    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginShaderMode(Shader shader);

    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndShaderMode();

    /// <summary>
    /// Begin blending mode (alpha, additive, multiplied, subtract, custom)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginBlendMode(BlendMode mode);

    /// <summary>
    /// End blending mode (reset to default: alpha blending)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndBlendMode();

    /// <summary>
    /// Begin scissor mode (define screen area for following drawing)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginScissorMode(int x, int y, int width, int height);

    /// <summary>
    /// End scissor mode
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndScissorMode();

    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void BeginVrStereoMode(VrStereoConfig config);

    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void EndVrStereoMode();

    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    [LibraryImport(LibName)]
    public static partial VrStereoConfig LoadVrStereoConfig(VrDeviceInfo device);

    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadVrStereoConfig(VrStereoConfig config);

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Shader LoadShader(sbyte* vsFileName, sbyte* fsFileName);

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Shader LoadShaderFromMemory(sbyte* vsCode, sbyte* fsCode);

    /// <summary>
    /// Check if a shader is ready
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsShaderReady(Shader shader);

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetShaderLocation(Shader shader, sbyte* uniformName);

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetShaderLocationAttrib(Shader shader, sbyte* attribName);

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetShaderValue(Shader shader, int locIndex, void* value, ShaderUniformDataType uniformType);

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetShaderValueV(Shader shader, int locIndex, void* value, ShaderUniformDataType uniformType, int count);

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetShaderValueMatrix(Shader shader, int locIndex, Matrix4x4 mat);

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetShaderValueTexture(Shader shader, int locIndex, Texture texture);

    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadShader(Shader shader);

    /// <summary>
    /// Get a ray trace from screen position (i.e mouse)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void GetMouseRay(Vector2 position, Camera3D camera);

    /// <summary>
    /// Get a ray trace from screen position (i.e mouse)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Ray GetScreenToWorldRay(Vector2 position, Camera3D camera);

    /// <summary>
    /// Get a ray trace from screen position (i.e mouse) in a viewport
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Ray GetScreenToWorldRayEx(Vector2 position, Camera3D camera, int width, int height);

    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetWorldToScreen(Vector3 position, Camera3D camera);

    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetWorldToScreenEx(Vector3 position, Camera3D camera, int width, int height);

    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera);

    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera);

    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Matrix4x4 GetCameraMatrix(Camera3D camera);

    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Matrix4x4 GetCameraMatrix2D(Camera2D camera);

    /// <summary>
    /// Set target FPS (maximum)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetTargetFPS(int fps);

    /// <summary>
    /// Get time in seconds for last frame drawn (delta time)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial float GetFrameTime();

    /// <summary>
    /// Get elapsed time in seconds since InitWindow()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial double GetTime();

    /// <summary>
    /// Get current FPS
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetFPS();

    /// <summary>
    /// Swap back buffer with front buffer (screen drawing)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SwapScreenBuffer();

    /// <summary>
    /// Register all input events
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void PollInputEvents();

    /// <summary>
    /// Wait for some time (halt program execution)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void WaitTime(double seconds);

    /// <summary>
    /// Set the seed for the random number generator
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetRandomSeed(uint seed);

    /// <summary>
    /// Get a random value between min and max (both included)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetRandomValue(int min, int max);

    /// <summary>
    /// Load random values sequence, no values repeated
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int* LoadRandomSequence(uint count, int min, int max);

    /// <summary>
    /// Unload random values sequence
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadRandomSequence(int* sequence);

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void TakeScreenshot(sbyte* fileName);

    /// <summary>
    /// Setup init configuration flags (view ConfigFlags)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetConfigFlags(ConfigFlags flags);

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void OpenURL(sbyte* url);

    /// <summary>
    /// Show trace log messages (TraceLogLevel.Debug, TraceLogLevel.Info, TraceLogLevel.Warning, TraceLogLevel.Error...)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void TraceLog(TraceLogLevel logLevel, sbyte* text);

    /// <summary>
    /// Set the current threshold (minimum) log level
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetTraceLogLevel(TraceLogLevel logLevel);

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void* MemAlloc(uint size);

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void* MemRealloc(void* ptr, uint size);

    /// <summary>
    /// Internal memory free
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void MemFree(void* ptr);

    /// <summary>
    /// Set custom trace log
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetTraceLogCallback(TraceLogCallback callback);

    /// <summary>
    /// Set custom file binary data loader
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetLoadFileDataCallback(LoadFileDataCallback callback);

    /// <summary>
    /// Set custom file binary data saver
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetSaveFileDataCallback(SaveFileDataCallback callback);

    /// <summary>
    /// Set custom file text data loader
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetLoadFileTextCallback(LoadFileTextCallback callback);

    /// <summary>
    /// Set custom file text data saver
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetSaveFileTextCallback(SaveFileTextCallback callback);
    
    /// <summary>
    /// Load file data as byte array (read)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial byte* LoadFileData(sbyte* fileName, int* dataSize);
    
    /// <summary>
    /// Unload file data allocated by LoadFileData()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadFileData(byte* data);
    
    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool SaveFileData(sbyte* fileName, void* data, int dataSize);
    
    /// <summary>
    /// Export data to code (.h), returns true on success
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool ExportDataAsCode(byte* data, int dataSize, sbyte* fileName);
    
    /// <summary>
    /// Load text data from file (read), returns a '\0' terminated string
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* LoadFileText(sbyte* fileName);
    
    /// <summary>
    /// Unload file text data allocated by LoadFileText()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadFileText(sbyte* text);
    
    /// <summary>
    /// Save text data to file (write), string must be '\0' terminated, returns true on success
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool SaveFileText(sbyte* fileName, sbyte* text);
    
    /// <summary>
    /// Check if file exists
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool FileExists(sbyte* fileName);
    
    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool DirectoryExists(sbyte* dirPath);
    
    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsFileExtension(sbyte* fileName, sbyte* ext);
    
    /// <summary>
    /// Get file length in bytes (NOTE: GetFileSize() conflicts with windows.h)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetFileLength(sbyte* fileName);
    
    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetFileExtension(sbyte* fileName);
    
    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetFileName(sbyte* filePath);
    
    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetFileNameWithoutExt(sbyte* filePath);
    
    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetDirectoryPath(sbyte* filePath);
    
    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetPrevDirectoryPath(sbyte* dirPath);
    
    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetWorkingDirectory();
    
    /// <summary>
    /// Get the directory of the running application (uses static string)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetApplicationDirectory();
    
    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool ChangeDirectory(sbyte* dir);
    
    /// <summary>
    /// Check if a given path is a file or a directory
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsPathFile(sbyte* path);
    
    /// <summary>
    /// Check if fileName is valid for the platform/OS
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsFileNameValid(sbyte* fileName);
    
    /// <summary>
    /// Load directory filepaths
    /// </summary>
    [LibraryImport(LibName)]
    public static partial FilePathList LoadDirectoryFiles(sbyte* dirPath);
    
    /// <summary>
    /// Load directory filepaths with extension filtering and recursive directory scan
    /// </summary>
    [LibraryImport(LibName)]
    public static partial FilePathList LoadDirectoryFilesEx(sbyte* basePath, sbyte* filter, NativeBool scanSubdirs);
    
    /// <summary>
    /// Unload filepaths
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadDirectoryFiles(FilePathList files);
    
    /// <summary>
    /// Check if a file has been dropped into window
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsFileDropped();
    
    /// <summary>
    /// Load dropped filepaths
    /// </summary>
    [LibraryImport(LibName)]
    public static partial FilePathList LoadDroppedFiles();
    
    /// <summary>
    /// Unload dropped filepaths
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadDroppedFiles(FilePathList files);
    
    /// <summary>
    /// Get file modification time (last write time)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial long GetFileModTime();
    
    /// <summary>
    /// Compress data (DEFLATE algorithm), memory must be MemFree()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial byte* CompressData(byte* data, int dataSize, int* compDataSize);
    
    /// <summary>
    /// Decompress data (DEFLATE algorithm), memory must be MemFree()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial byte* DecompressData(byte* compData, int compDataSize, int* dataSize);
    
    /// <summary>
    /// Encode data to Base64 string, memory must be MemFree()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* EncodeDataBase64(byte* data, int dataSize, int* outputSize);
    
    /// <summary>
    /// Decode Base64 string data, memory must be MemFree()
    /// </summary>
    [LibraryImport(LibName)]
    public static partial byte* DecodeDataBase64(byte* data, int* outputSize);
    
    /// <summary>
    /// Load automation events list from file, NULL for empty list, capacity = MAX_AUTOMATION_EVENTS
    /// </summary>
    [LibraryImport(LibName)]
    public static partial AutomationEventList LoadAutomationEventList(sbyte* fileName);
    
    /// <summary>
    /// Unload automation events list from file
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void UnloadAutomationEventList(AutomationEventList list);
    
    /// <summary>
    /// Export automation events list as text file
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool ExportAutomationEventList(AutomationEventList list, sbyte* fileName);
    
    /// <summary>
    /// Set automation event list to record to
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetAutomationEventList(AutomationEventList* list);
    
    /// <summary>
    /// Set automation event internal base frame to start recording
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetAutomationEventBaseFrame(int frame);
    
    /// <summary>
    /// Start recording automation events (AutomationEventList must be set)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void StartAutomationEventRecording();
    
    /// <summary>
    /// Stop recording automation events
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void StopAutomationEventRecording();
    
    /// <summary>
    /// Play a recorded automation event
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void PlayAutomationEvent(AutomationEvent @event);
    
    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsKeyPressed(KeyboardKey key);
    
    /// <summary>
    /// Check if a key has been pressed again (Only PLATFORM_DESKTOP)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsKeyPressedRepeat(KeyboardKey key);
    
    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsKeyDown(KeyboardKey key);
    
    /// <summary>
    /// Check if a key has been released once
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsKeyReleased(KeyboardKey key);
    
    /// <summary>
    /// Check if a key is NOT being pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsKeyUp(KeyboardKey key);
    
    /// <summary>
    /// Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    /// </summary>
    [LibraryImport(LibName)]
    public static partial KeyboardKey GetKeyPressed();
    
    /// <summary>
    /// Get char pressed (unicode), call it multiple times for chars queued, returns 0 when the queue is empty
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetCharPressed();
    
    /// <summary>
    /// Set a custom key to exit program (default is ESC)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetExitKey(KeyboardKey key);
    
    /// <summary>
    /// Check if a gamepad is available
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsGamepadAvailable(int gamepad);
    
    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    [LibraryImport(LibName)]
    public static partial sbyte* GetGamepadName(int gamepad);
    
    /// <summary>
    /// Check if a gamepad button has been pressed once
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsGamepadButtonPressed(int gamepad, GamepadButton button);
    
    /// <summary>
    /// Check if a gamepad button is being pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsGamepadButtonDown(int gamepad, GamepadButton button);
    
    /// <summary>
    /// Check if a gamepad button has been released once
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsGamepadButtonReleased(int gamepad, GamepadButton button);
    
    /// <summary>
    /// Check if a gamepad button is NOT being pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsGamepadButtonUp(int gamepad, GamepadButton button);
    
    /// <summary>
    /// Get the last gamepad button pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial GamepadButton GetGamepadButtonPressed();
    
    /// <summary>
    /// Get gamepad axis count for a gamepad
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetGamepadAxisCount(int gamepad);
    
    /// <summary>
    /// Get axis movement value for a gamepad axis
    /// </summary>
    [LibraryImport(LibName)]
    public static partial float GetGamepadAxisMovement(int gamepad, GamepadAxis axis);
    
    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int SetGamepadMappings(sbyte* mappings);
    
    /// <summary>
    /// Set gamepad vibration for both motors
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetGamepadVibration(int gamepad, float leftMotor, float rightMotor);
    
    /// <summary>
    /// Check if a mouse button has been pressed once
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsMouseButtonPressed(MouseButton button);
    
    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsMouseButtonDown(MouseButton button);
    
    /// <summary>
    /// Check if a mouse button has been released once
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsMouseButtonReleased(MouseButton button);
    
    /// <summary>
    /// Check if a mouse button is NOT being pressed
    /// </summary>
    [LibraryImport(LibName)]
    public static partial NativeBool IsMouseButtonUp(MouseButton button);
    
    /// <summary>
    /// Get mouse position X
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMouseX();
    
    /// <summary>
    /// Get mouse position Y
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetMouseY();
    
    /// <summary>
    /// Get mouse position XY
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetMousePosition();
    
    /// <summary>
    /// Get mouse delta between frames
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetMouseDelta();
    
    /// <summary>
    /// Set mouse position XY
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetMousePosition(int x, int y);
    
    /// <summary>
    /// Set mouse offset
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetMouseOffset(int offsetX, int offsetY);
    
    /// <summary>
    /// Set mouse scaling
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetMouseScale(float scaleX, float scaleY);
    
    /// <summary>
    /// Get mouse wheel movement for X or Y, whichever is larger
    /// </summary>
    [LibraryImport(LibName)]
    public static partial float GetMouseWheelMove();
    
    /// <summary>
    /// Get mouse wheel movement for both X and Y
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetMouseWheelMoveV();
    
    /// <summary>
    /// Set mouse cursor
    /// </summary>
    [LibraryImport(LibName)]
    public static partial void SetMouseCursor(MouseCursor cursor);
    
    /// <summary>
    /// Get touch position X for touch point 0 (relative to screen size)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetTouchX();
    
    /// <summary>
    /// Get touch position Y for touch point 0 (relative to screen size)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetTouchY();
    
    /// <summary>
    /// Get touch position XY for a touch point index (relative to screen size)
    /// </summary>
    [LibraryImport(LibName)]
    public static partial Vector2 GetTouchPosition(int index);
    
    /// <summary>
    /// Get touch point identifier for given index
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetTouchPointId(int index);
    
    /// <summary>
    /// Get number of touch points
    /// </summary>
    [LibraryImport(LibName)]
    public static partial int GetTouchPointCount();
}