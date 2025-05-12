using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Raylib
{
    // all methods with native string (char*, or sbyte* in P/Invoke) parameters are using Marshal directly
    // instead of something like Utf8Buffer in Raylib-cs to reduce execution time and allocations
    // Utf8Handle is provided for user use

    /// <summary>
    /// Initialize window and OpenGL context
    /// </summary>
    public static void InitWindow(int width, int height, string title)
    {
        nint pTitle = Marshal.StringToCoTaskMemUTF8(title);
        InitWindow(width, height, (sbyte*)pTitle);
        Marshal.FreeCoTaskMem(pTitle);
    }

    /// <summary>
    /// Set icon for window (multiple images, RGBA 32bit, only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowIcons(ReadOnlySpan<Image> images)
    {
        fixed (Image* pImages = images)
        {
            SetWindowIcons(pImages, images.Length);
        }
    }

    /// <summary>
    /// Set title for window (only PLATFORM_DESKTOP and PLATFORM_WEB)
    /// </summary>
    public static void SetWindowTitle(string title)
    {
        nint pTitle = Marshal.StringToCoTaskMemUTF8(title);
        SetWindowTitle((sbyte*)pTitle);
        Marshal.FreeCoTaskMem(pTitle);
    }

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the specified monitor
    /// </summary>
    public static string GetMonitorNameString(int monitor)
    {
        return Marshal.PtrToStringUTF8((nint)GetMonitorName(monitor)) ?? string.Empty;
    }

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    public static void SetClipboardText(string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        SetClipboardText((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    public static string GetClipboardTextString()
    {
        return Marshal.PtrToStringUTF8((nint)GetClipboardText()) ?? string.Empty;
    }

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    public static Shader LoadShader(string vsFileName, string fsFileName)
    {
        nint pVsFileName = Marshal.StringToCoTaskMemUTF8(vsFileName);
        nint pFsFileName = Marshal.StringToCoTaskMemUTF8(fsFileName);
        Shader result = LoadShader((sbyte*)pVsFileName, (sbyte*)pFsFileName);
        Marshal.FreeCoTaskMem(pFsFileName);
        Marshal.FreeCoTaskMem(pVsFileName);
        return result;
    }

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
    {
        nint pVsCode = Marshal.StringToCoTaskMemUTF8(vsCode);
        nint pFsCode = Marshal.StringToCoTaskMemUTF8(fsCode);
        Shader result = LoadShaderFromMemory((sbyte*)pVsCode, (sbyte*)pFsCode);
        Marshal.FreeCoTaskMem(pFsCode);
        Marshal.FreeCoTaskMem(pVsCode);
        return result;
    }

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public static int GetShaderLocation(Shader shader, string uniformName)
    {
        nint pUniformName = Marshal.StringToCoTaskMemUTF8(uniformName);
        int result = GetShaderLocation(shader, (sbyte*)pUniformName);
        Marshal.FreeCoTaskMem(pUniformName);
        return result;
    }

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public static int GetShaderLocationAttrib(Shader shader, string attribName)
    {
        nint pAttribName = Marshal.StringToCoTaskMemUTF8(attribName);
        int result = GetShaderLocationAttrib(shader, (sbyte*)pAttribName);
        Marshal.FreeCoTaskMem(pAttribName);
        return result;
    }

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetShaderValue<T>(Shader shader, int locIndex, T value, ShaderUniformDataType uniformType)
        where T : unmanaged
    {
        SetShaderValue(shader, locIndex, &value, uniformType);
    }

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetShaderValue<T>(Shader shader, int locIndex, ReadOnlySpan<T> value, ShaderUniformDataType uniformType)
        where T : unmanaged
    {
        fixed (T* pValue = value)
        {
            SetShaderValueV(shader, locIndex, pValue, uniformType, value.Length);
        }
    }

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetShaderValue(Shader shader, int locIndex, Matrix4x4 mat)
    {
        SetShaderValueMatrix(shader, locIndex, mat);
    }

    /// <summary>
    /// Set shader uniform value and bind the texture (sampler2d)
    /// </summary>
    public static void SetShaderValue(Shader shader, int locIndex, Texture2D texture)
    {
        SetShaderValueTexture(shader, locIndex, texture);
    }

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    public static void TakeScreenshot(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        TakeScreenshot((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
    }

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    public static void OpenURL(string url)
    {
        nint pUrl = Marshal.StringToCoTaskMemUTF8(url);
        OpenURL((sbyte*)pUrl);
        Marshal.FreeCoTaskMem(pUrl);
    }

    /// <summary>
    /// Show trace log messages (TraceLogLevel.Debug, TraceLogLevel.Info, TraceLogLevel.Warning, TraceLogLevel.Error...)
    /// </summary>
    public static void TraceLog(TraceLogLevel logLevel, string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        TraceLog(logLevel, (sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    public static T* MemAlloc<T>(uint elementCount)
        where T : unmanaged
    {
        return (T*)MemAlloc((uint)(elementCount * sizeof(T)));
    }

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    public static T* MemRealloc<T>(T* ptr, uint elementCount)
        where T : unmanaged
    {
        return (T*)MemRealloc((void*)ptr, (uint)(elementCount * sizeof(T)));
    }

    /// <summary>
    /// Load file data as byte array (read)
    /// </summary>
    public static byte* LoadFileData(string fileName, out int dataSize)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        byte* result;
        fixed (int* pDataSize = &dataSize)
        {
            result = LoadFileData((sbyte*)pFileName, pDataSize);
        }

        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    public static NativeBool SaveFileData<T>(string fileName, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result;
        fixed (T* pData = data)
        {
            result = SaveFileData((sbyte*)pFileName, pData, data.Length * sizeof(T));
        }

        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Export data to code (.h), returns true on success
    /// </summary>
    public static NativeBool ExportDataAsCode(ReadOnlySpan<byte> data, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result;
        fixed (byte* pData = data)
        {
            result = ExportDataAsCode(pData, data.Length, (sbyte*)pFileName);
        }

        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load text data from file (read), returns a '\0' terminated string
    /// </summary>
    public static sbyte* LoadFileText(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        sbyte* result = LoadFileText((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Save text data to file (write), string must be '\0' terminated, returns true on success
    /// </summary>
    public static NativeBool SaveFileText(string fileName, string text)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        NativeBool result = SaveFileText((sbyte*)pFileName, (sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Check if file exists
    /// </summary>
    public static NativeBool FileExists(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = FileExists((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    public static NativeBool DirectoryExists(string dirName)
    {
        nint pDirName = Marshal.StringToCoTaskMemUTF8(dirName);
        NativeBool result = DirectoryExists((sbyte*)pDirName);
        Marshal.FreeCoTaskMem(pDirName);
        return result;
    }

    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    public static NativeBool IsFileExtension(string fileName, string ext)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        nint pExt = Marshal.StringToCoTaskMemUTF8(ext);
        NativeBool result = IsFileExtension((sbyte*)pFileName, (sbyte*)pExt);
        Marshal.FreeCoTaskMem(pExt);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Get file length in bytes (NOTE: GetFileSize() conflicts with windows.h)
    /// </summary>
    public static int GetFileLength(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        int result = GetFileLength((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    public static string GetFileExtension(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        sbyte* result = GetFileExtension((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    public static string GetFileName(string filePath)
    {
        nint pFilePath = Marshal.StringToCoTaskMemUTF8(filePath);
        sbyte* result = GetFileName((sbyte*)pFilePath);
        Marshal.FreeCoTaskMem(pFilePath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    public static string GetFileNameWithoutExt(string filePath)
    {
        nint pFilePath = Marshal.StringToCoTaskMemUTF8(filePath);
        sbyte* result = GetFileNameWithoutExt((sbyte*)pFilePath);
        Marshal.FreeCoTaskMem(pFilePath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    public static string GetDirectoryPath(string filePath)
    {
        nint pFilePath = Marshal.StringToCoTaskMemUTF8(filePath);
        sbyte* result = GetDirectoryPath((sbyte*)pFilePath);
        Marshal.FreeCoTaskMem(pFilePath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    public static string GetPrevDirectoryPath(string dirPath)
    {
        nint pDirPath = Marshal.StringToCoTaskMemUTF8(dirPath);
        sbyte* result = GetPrevDirectoryPath((sbyte*)pDirPath);
        Marshal.FreeCoTaskMem(pDirPath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    public static string GetWorkingDirectoryString()
    {
        return Marshal.PtrToStringUTF8((nint)GetWorkingDirectory()) ?? string.Empty;
    }

    /// <summary>
    /// Get the directory of the running application (uses static string)
    /// </summary>
    public static string GetApplicationDirectoryString()
    {
        return Marshal.PtrToStringUTF8((nint)GetApplicationDirectory()) ?? string.Empty;
    }

    /// <summary>
    /// Create directories (including full path requested), returns 0 on success
    /// </summary>
    public static int MakeDirectory(string dirPath)
    {
        nint pDirPath = Marshal.StringToCoTaskMemUTF8(dirPath);
        int result = MakeDirectory((sbyte*)pDirPath);
        Marshal.FreeCoTaskMem(pDirPath);
        return result;
    }

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    public static NativeBool ChangeDirectory(string dir)
    {
        nint pDir = Marshal.StringToCoTaskMemUTF8(dir);
        NativeBool result = ChangeDirectory((sbyte*)pDir);
        Marshal.FreeCoTaskMem(pDir);
        return result;
    }

    /// <summary>
    /// Check if a given path is a file or a directory
    /// </summary>
    public static NativeBool IsPathFile(string path)
    {
        nint pPath = Marshal.StringToCoTaskMemUTF8(path);
        NativeBool result = IsPathFile((sbyte*)pPath);
        Marshal.FreeCoTaskMem(pPath);
        return result;
    }

    /// <summary>
    /// Check if fileName is valid for the platform/OS
    /// </summary>
    public static NativeBool IsFileNameValid(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = IsFileNameValid((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load directory filepaths
    /// </summary>
    public static FilePathList LoadDirectoryFiles(string dirPath)
    {
        nint pDirPath = Marshal.StringToCoTaskMemUTF8(dirPath);
        FilePathList result = LoadDirectoryFiles((sbyte*)pDirPath);
        Marshal.FreeCoTaskMem(pDirPath);
        return result;
    }

    /// <summary>
    /// Load directory filepaths with extension filtering and recursive directory scan
    /// </summary>
    public static FilePathList LoadDirectoryFilesEx(string basePath, string filter, NativeBool scanSubdirs)
    {
        nint pBasePath = Marshal.StringToCoTaskMemUTF8(basePath);
        nint pFilter = Marshal.StringToCoTaskMemUTF8(filter);
        FilePathList result = LoadDirectoryFilesEx((sbyte*)pBasePath, (sbyte*)pFilter, scanSubdirs);
        Marshal.FreeCoTaskMem(pFilter);
        Marshal.FreeCoTaskMem(pBasePath);
        return result;
    }

    /// <summary>
    /// Compress data (DEFLATE algorithm), memory must be MemFree()
    /// </summary>
    public static byte* CompressData(ReadOnlySpan<byte> data, out int compDataSize)
    {
        fixed (byte* pData = data)
        {
            fixed (int* pCompDataSize = &compDataSize)
            {
                return CompressData(pData, data.Length, pCompDataSize);
            }
        }
    }

    /// <summary>
    /// Decompress data (DEFLATE algorithm), memory must be MemFree()
    /// </summary>
    public static byte* DecompressData(ReadOnlySpan<byte> compData, out int dataSize)
    {
        fixed (byte* pCompData = compData)
        {
            fixed (int* pDataSize = &dataSize)
            {
                return DecompressData(pCompData, compData.Length, pDataSize);
            }
        }
    }

    /// <summary>
    /// Encode data to Base64 string, memory must be MemFree()
    /// </summary>
    public static sbyte* EncodeDataBase64(ReadOnlySpan<byte> data, out int outputSize)
    {
        fixed (byte* pData = data)
        {
            fixed (int* pOutputSize = &outputSize)
            {
                return EncodeDataBase64(pData, data.Length, pOutputSize);
            }
        }
    }

    /// <summary>
    /// Decode Base64 string data, memory must be MemFree()
    /// </summary>
    public static byte* DecodeDataBase64(string data, out int outputSize)
    {
        nint pData = Marshal.StringToCoTaskMemUTF8(data);
        byte* result;
        fixed (int* pOutputSize = &outputSize) 
        {
            result = DecodeDataBase64((sbyte*)pData, pOutputSize);
        }
        Marshal.FreeCoTaskMem(pData);
        return result;
    }

    /// <summary>
    /// Compute CRC32 hash code
    /// </summary>
    public static uint ComputeCRC32(ReadOnlySpan<byte> data)
    {
        fixed (byte* pData = data)
        {
            return ComputeCRC32(pData, data.Length);
        }
    }

    // ComputeMD5 and ComputeSHA1 don't allocate memory using MemAlloc, so we can use Span for it

    /// <summary>
    /// Compute MD5 hash code, returns static int[4] (16 bytes)
    /// </summary>
    public static Span<uint> ComputeMD5(ReadOnlySpan<byte> data)
    {
        fixed (byte* pData = data)
        {
            return new Span<uint>(ComputeMD5(pData, data.Length), 4);
        }
    }
    
    /// <summary>
    /// Compute SHA1 hash code, returns static int[5] (20 bytes)
    /// </summary>
    public static Span<uint> ComputeSHA1(ReadOnlySpan<byte> data)
    {
        fixed (byte* pData = data)
        {
            return new Span<uint>(ComputeSHA1(pData, data.Length), 5);
        }
    }

    /// <summary>
    /// Load automation events list from file, NULL for empty list, capacity = MAX_AUTOMATION_EVENTS
    /// </summary>
    public static AutomationEventList LoadAutomationEventList(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        AutomationEventList result = LoadAutomationEventList((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Export automation events list as text file
    /// </summary>
    public static NativeBool ExportAutomationEventList(AutomationEventList list, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportAutomationEventList(list, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Set automation event list to record to
    /// </summary>
    /// <remarks>
    /// Use <see cref="SetAutomationEventList(NativeHandle{T})"/>
    /// for instance fields instead:
    /// <code>
    /// private NativeHandle&lt;AutomationEventList&gt; _list;
    /// </code>
    /// </remarks>
    public static void SetAutomationEventList(ref AutomationEventList list)
    {
        fixed (AutomationEventList* pList = &list)
        {
            SetAutomationEventList(pList);
        }
    }
    
    /// <summary>
    /// Set automation event list to record to
    /// </summary>
    /// <remarks>
    /// Use <see cref="SetAutomationEventList(ref Raylib_cs.BleedingEdge.AutomationEventList)"/>
    /// for local variables instead:
    /// <code>
    /// AutomationEventList list;
    /// </code>
    /// </remarks>
    public static void SetAutomationEventList(NativeHandle<AutomationEventList> list)
    {
        SetAutomationEventList((AutomationEventList*)list.Address);
    }

    /// <summary>
    /// Get name of a QWERTY key on the current keyboard layout (eg returns string 'q' for KEY_A on an AZERTY keyboard)
    /// </summary>
    public static string GetKeyNameString(KeyboardKey key)
    {
        return Marshal.PtrToStringUTF8((nint)GetKeyName(key)) ?? string.Empty;
    }

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    public static string GetGamepadNameString(int gamepad)
    {
        return Marshal.PtrToStringUTF8((nint)GetGamepadName(gamepad)) ?? string.Empty;
    }

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    public static int SetGamepadMappings(string mappings)
    {
        nint pMappings = Marshal.StringToCoTaskMemUTF8(mappings);
        int result = SetGamepadMappings((sbyte*)pMappings);
        Marshal.FreeCoTaskMem(pMappings);
        return result;
    }

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void UpdateCamera(ref Camera3D camera, CameraMode mode)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            UpdateCamera(pCamera, mode);
        }
    }

    /// <summary>
    /// Update camera movement/rotation
    /// </summary>
    public static void UpdateCameraPro(ref Camera3D camera, Vector3 movement, Vector3 rotation, float zoom)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            UpdateCameraPro(pCamera, movement, rotation, zoom);
        }
    }

    /// <summary>
    /// Returns the cameras forward vector (normalized)
    /// </summary>
    public static Vector3 GetCameraForward(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraForward(pCamera);
        }
    }

    /// <summary>
    /// Returns the cameras up vector (normalized)
    /// </summary>
    /// <remarks>
    /// Note: The up vector might not be perpendicular to the forward vector
    /// </remarks>
    public static Vector3 GetCameraUp(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraUp(pCamera);
        }
    }

    /// <summary>
    /// Returns the cameras right vector (normalized)
    /// </summary>
    public static Vector3 GetCameraRight(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraRight(pCamera);
        }
    }

    /// <summary>
    /// Moves the camera in its forward direction
    /// </summary>
    public static void CameraMoveForward(ref Camera3D camera, float distance, NativeBool moveInWorldPlane)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveForward(pCamera, distance, moveInWorldPlane);
        }
    }

    /// <summary>
    /// Moves the camera in its up direction
    /// </summary>
    public static void CameraMoveUp(ref Camera3D camera, float distance)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveUp(pCamera, distance);
        }
    }

    /// <summary>
    /// Moves the camera target in its current right direction
    /// </summary>
    public static void CameraMoveRight(ref Camera3D camera, float distance, NativeBool moveInWorldPlane)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveRight(pCamera, distance, moveInWorldPlane);
        }
    }

    /// <summary>
    /// Moves the camera position closer/farther to/from the camera target
    /// </summary>
    public static void CameraMoveToTarget(ref Camera3D camera, float delta)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveToTarget(pCamera, delta);
        }
    }

    /// <summary>
    /// Rotates the camera around its up vector <br />
    /// Yaw is "looking left and right" <br />
    /// If rotateAroundTarget is false, the camera rotates around its position
    /// </summary>
    /// <remarks>
    /// Note: angle must be provided in radians
    /// </remarks>
    public static void CameraYaw(ref Camera3D camera, float angle, NativeBool rotateAroundTarget)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraYaw(pCamera, angle, rotateAroundTarget);
        }
    }

    /// <summary>
    /// Rotates the camera around its right vector, pitch is "looking up and down" <br />
    /// - lockView prevents camera overrotation (aka "somersaults") <br />
    /// - rotateAroundTarget defines if rotation is around target or around its position <br />
    /// - rotateUp rotates the up direction as well (typically only usefull in CAMERA_FREE)
    /// </summary>
    /// <remarks>
    /// NOTE: angle must be provided in radians
    /// </remarks>
    public static void CameraPitch(ref Camera3D camera, float angle, NativeBool lockView, NativeBool rotateAroundTarget, NativeBool rotateUp)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraPitch(pCamera, angle, lockView, rotateAroundTarget, rotateUp);
        }
    }

    /// <summary>
    /// Rotates the camera around its forward vector <br />
    /// Roll is "turning your head sideways to the left or right"
    /// </summary>
    /// <remarks>
    /// Note: angle must be provided in radians
    /// </remarks>
    public static void CameraRoll(ref Camera3D camera, float angle)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraRoll(pCamera, angle);
        }
    }

    /// <summary>
    /// Returns the camera view matrix
    /// </summary>
    public static Matrix4x4 GetCameraViewMatrix(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraViewMatrix(pCamera);
        }
    }

    /// <summary>
    /// Returns the camera projection matrix
    /// </summary>
    public static Matrix4x4 GetCameraProjectionMatrix(ref Camera3D camera, float aspect)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraProjectionMatrix(pCamera, aspect);
        }
    }

    /// <summary>
    /// Draw lines sequence (using gl lines)
    /// </summary>
    public static void DrawLineStrip(ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawLineStrip(pPoints, points.Length, color);
        }
    }

    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    public static void DrawTriangleFan(ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawTriangleFan(pPoints, points.Length, color);
        }
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip(ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawTriangleStrip(pPoints, points.Length, color);
        }
    }

    /// <summary>
    /// Draw spline: Linear, minimum 2 points
    /// </summary>
    public static void DrawSplineLinear(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineLinear(pPoints, points.Length, thick, color);
        }
    }

    /// <summary>
    /// Draw spline: B-Spline, minimum 4 points
    /// </summary>
    public static void DrawSplineBasis(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineBasis(pPoints, points.Length, thick, color);
        }
    }

    /// <summary>
    /// Draw spline: Catmull-Rom, minimum 4 points
    /// </summary>
    public static void DrawSplineCatmullRom(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineCatmullRom(pPoints, points.Length, thick, color);
        }
    }

    /// <summary>
    /// Draw spline: Quadratic Bezier, minimum 3 points (1 control point): [p1, c2, p3, c4...]
    /// </summary>
    public static void DrawSplineBezierQuadratic(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineBezierQuadratic(pPoints, points.Length, thick, color);
        }
    }

    /// <summary>
    /// Draw spline: Cubic Bezier, minimum 4 points (2 control points): [p1, c2, c3, p4, c5, c6...]
    /// </summary>
    public static void DrawSplineBezierCubic(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineBezierCubic(pPoints, points.Length, thick, color);
        }
    }

    /// <summary>
    /// Check if point is within a polygon described by array of vertices
    /// </summary>
    public static NativeBool CheckCollisionPointPoly(Vector2 point, ReadOnlySpan<Vector2> points)
    {
        fixed (Vector2* pPoints = points)
        {
            return CheckCollisionPointPoly(point, pPoints, points.Length);
        }
    }

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    public static NativeBool CheckCollisionLines(
        Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, out Vector2 collisionPoint)
    {
        fixed (Vector2* pCollisionPoint = &collisionPoint)
        {
            return CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, pCollisionPoint);
        }
    }

    /// <summary>
    /// Load image from file into CPU memory (RAM)
    /// </summary>
    public static Image LoadImage(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Image result = LoadImage((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    public static Image LoadImageRaw(string fileName, int width, int height, PixelFormat format, int headerSize)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Image result = LoadImageRaw((sbyte*)pFileName, width, height, format, headerSize);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    public static Image LoadImageAnim(string fileName, out int frames)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Image result;
        fixed (int* pFrames = &frames)
        {
            result = LoadImageAnim((sbyte*)pFileName, pFrames);
        }

        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load image sequence from memory buffer
    /// </summary>
    public static Image LoadImageAnimFromMemory(string fileType, ReadOnlySpan<byte> fileData, out int frames)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Image result;
        fixed (byte* pFileData = fileData)
        {
            fixed (int* pFrames = &frames)
            {
                result = LoadImageAnimFromMemory((sbyte*)pFileData, pFileData, fileData.Length, pFrames);
            }
        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    public static Image LoadImageFromMemory(string fileType, ReadOnlySpan<byte> fileData)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Image result;
        fixed (byte* pFileData = fileData)
        {
            result = LoadImageFromMemory((sbyte*)pFileType, pFileData, fileData.Length);
        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    public static NativeBool ExportImage(Image image, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportImage(image, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Export image to memory buffer
    /// </summary>
    public static byte* ExportImageToMemory(Image image, string fileType, out int fileSize)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        byte* result;
        fixed (int* pFileSize = &fileSize)
        {
            result = ExportImageToMemory(image, (sbyte*)pFileSize, pFileSize);
        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public static NativeBool ExportImageAsCode(Image image, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportImageAsCode(image, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Generate image: grayscale image from text data
    /// </summary>
    public static Image GenImageText(int width, int height, string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        Image result = GenImageText(width, height, (sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    public static Image ImageText(string text, int fontSize, Color color)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        Image result = ImageText((sbyte*)pText, fontSize, color);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        Image result = ImageTextEx(font, (sbyte*)pText, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    public static void ImageFormat(ref Image image, PixelFormat newFormat)
    {
        fixed (Image* pImage = &image)
        {
            ImageFormat(pImage, newFormat);
        }
    }

    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    public static void ImageToPOT(ref Image image, Color fill)
    {
        fixed (Image* pImage = &image)
        {
            ImageToPOT(pImage, fill);
        }
    }

    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    public static void ImageCrop(ref Image image, Rectangle crop)
    {
        fixed (Image* pImage = &image)
        {
            ImageCrop(pImage, crop);
        }
    }

    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    public static void ImageAlphaCrop(ref Image image, float threshold)
    {
        fixed (Image* pImage = &image)
        {
            ImageAlphaCrop(pImage, threshold);
        }
    }

    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    public static void ImageAlphaClear(ref Image image, Color color, float threshold)
    {
        fixed (Image* pImage = &image)
        {
            ImageAlphaClear(pImage, color, threshold);
        }
    }

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    public static void ImageAlphaMask(ref Image image, Image alphaMask)
    {
        fixed (Image* pImage = &image)
        {
            ImageAlphaMask(pImage, alphaMask);
        }
    }

    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    public static void ImageAlphaPremultiply(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageAlphaPremultiply(pImage);
        }
    }

    /// <summary>
    /// Apply Gaussian blur using a box blur approximation
    /// </summary>
    public static void ImageBlurGaussian(ref Image image, int blurSize)
    {
        fixed (Image* pImage = &image)
        {
            ImageBlurGaussian(pImage, blurSize);
        }
    }

    /// <summary>
    /// Apply custom square convolution kernel to image
    /// </summary>
    public static void ImageKernelConvolution(ref Image image, ReadOnlySpan<float> kernel, int kernelSize)
    {
        fixed (Image* pImage = &image)
        {
            fixed (float* pKernel = kernel)
            {
                ImageKernelConvolution(pImage, pKernel, kernelSize);
            }
        }
    }

    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    public static void ImageResize(ref Image image, int newWidth, int newHeight)
    {
        fixed (Image* pImage = &image)
        {
            ImageResize(pImage, newWidth, newHeight);
        }
    }

    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    public static void ImageResizeNN(ref Image image, int newWidth, int newHeight)
    {
        fixed (Image* pImage = &image)
        {
            ImageResizeNN(pImage, newWidth, newHeight);
        }
    }

    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    public static void ImageResizeCanvas(ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
    {
        fixed (Image* pImage = &image)
        {
            ImageResizeCanvas(pImage, newWidth, newHeight, offsetX, offsetY, fill);
        }
    }

    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    public static void ImageMipmaps(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageMipmaps(pImage);
        }
    }

    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    public static void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        fixed (Image* pImage = &image)
        {
            ImageDither(pImage, rBpp, gBpp, bBpp, aBpp);
        }
    }

    /// <summary>
    /// Flip image vertically
    /// </summary>
    public static void ImageFlipVertical(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageFlipVertical(pImage);
        }
    }

    /// <summary>
    /// Flip image horizontally
    /// </summary>
    public static void ImageFlipHorizontal(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageFlipHorizontal(pImage);
        }
    }

    /// <summary>
    /// Rotate image by input angle in degrees (-359 to 359)
    /// </summary>
    public static void ImageRotate(ref Image image, int degrees)
    {
        fixed (Image* pImage = &image)
        {
            ImageRotate(pImage, degrees);
        }
    }

    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    public static void ImageRotateCW(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageRotateCW(pImage);
        }
    }

    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    public static void ImageRotateCCW(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageRotateCCW(pImage);
        }
    }

    /// <summary>
    /// Modify image color: tint
    /// </summary>
    public static void ImageColorTint(ref Image image, Color color)
    {
        fixed (Image* pImage = &image)
        {
            ImageColorTint(pImage, color);
        }
    }

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    public static void ImageColorInvert(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageColorInvert(pImage);
        }
    }

    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    public static void ImageColorGrayscale(ref Image image)
    {
        fixed (Image* pImage = &image)
        {
            ImageColorGrayscale(pImage);
        }
    }

    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    public static void ImageColorContrast(ref Image image, float contrast)
    {
        fixed (Image* pImage = &image)
        {
            ImageColorContrast(pImage, contrast);
        }
    }

    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    public static void ImageColorBrightness(ref Image image, int brightness)
    {
        fixed (Image* pImage = &image)
        {
            ImageColorBrightness(pImage, brightness);
        }
    }

    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    public static void ImageColorReplace(ref Image image, Color color, Color replace)
    {
        fixed (Image* pImage = &image)
        {
            ImageColorReplace(pImage, color, replace);
        }
    }

    /// <summary>
    /// Load colors palette from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color* LoadImagePalette(Image image, int maxPaletteSize, out int colorCount)
    {
        fixed (int* pColorCount = &colorCount)
        {
            return LoadImagePalette(image, maxPaletteSize, pColorCount);
        }
    }

    /// <summary>
    /// Clear image background with given color
    /// </summary>
    public static void ImageClearBackground(ref Image image, Color color)
    {
        fixed (Image* pImage = &image)
        {
            ImageClearBackground(pImage, color);
        }
    }

    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    public static void ImageDrawPixel(ref Image dst, int posX, int posY, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawPixel(pDst, posX, posY, color);
        }
    }

    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    public static void ImageDrawPixelV(ref Image dst, Vector2 position, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawPixelV(pDst, position, color);
        }
    }

    /// <summary>
    /// Draw line within an image
    /// </summary>
    public static void ImageDrawLine(ref Image dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawLine(pDst, startPosX, startPosY, endPosX, endPosY, color);
        }
    }

    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    public static void ImageDrawLineV(ref Image dst, Vector2 start, Vector2 end, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawLineV(pDst, start, end, color);
        }
    }

    /// <summary>
    /// Draw a line defining thickness within an image
    /// </summary>
    public static void ImageDrawLineEx(ref Image dst, Vector2 start, Vector2 end, int thick, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawLineEx(pDst, start, end, thick, color);
        }
    }

    /// <summary>
    /// Draw a filled circle within an image
    /// </summary>
    public static void ImageDrawCircle(ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawCircle(pDst, centerX, centerY, radius, color);
        }
    }

    /// <summary>
    /// Draw a filled circle within an image (Vector version)
    /// </summary>
    public static void ImageDrawCircleV(ref Image dst, Vector2 center, int radius, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawCircleV(pDst, center, radius, color);
        }
    }

    /// <summary>
    /// Draw circle outline within an image
    /// </summary>
    public static void ImageDrawCircleLines(ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawCircleLines(pDst, centerX, centerY, radius, color);
        }
    }

    /// <summary>
    /// Draw circle outline within an image (Vector version)
    /// </summary>
    public static void ImageDrawCircleLinesV(ref Image dst, Vector2 center, int radius, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawCircleLinesV(pDst, center, radius, color);
        }
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangle(ref Image dst, int posX, int posY, int width, int height, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawRectangle(pDst, posX, posY, width, height, color);
        }
    }

    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    public static void ImageDrawRectangleV(ref Image dst, Vector2 position, Vector2 size, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawRectangleV(pDst, position, size, color);
        }
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangleRec(ref Image dst, Rectangle rec, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawRectangleRec(pDst, rec, color);
        }
    }

    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    public static void ImageDrawRectangleLines(ref Image dst, Rectangle rec, int thick, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawRectangleLines(pDst, rec, thick, color);
        }
    }

    /// <summary>
    /// Draw triangle within an image
    /// </summary>
    public static void ImageDrawTriangle(ref Image dst, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawTriangle(pDst, v1, v2, v3, color);
        }
    }

    /// <summary>
    /// Draw triangle with interpolated colors within an image
    /// </summary>
    public static void ImageDrawTriangleEx(ref Image dst, Vector2 v1, Vector2 v2, Vector2 v3, Color c1, Color c2, Color c3)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawTriangleEx(pDst, v1, v2, v3, c1, c2, c3);
        }
    }

    /// <summary>
    /// Draw triangle outline within an image
    /// </summary>
    public static void ImageDrawTriangleLines(ref Image dst, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDrawTriangleLines(pDst, v1, v2, v3, color);
        }
    }

    /// <summary>
    /// Draw a triangle fan defined by points within an image (first vertex is the center)
    /// </summary>
    public static void ImageDrawTriangleFan(ref Image dst, ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            fixed (Vector2* pPoints = points)
            {
                ImageDrawTriangleFan(pDst, pPoints, points.Length, color);
            }
        }
    }

    /// <summary>
    /// Draw a triangle strip defined by points within an image
    /// </summary>
    public static void ImageDrawTriangleStrip(ref Image dst, ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Image* pDst = &dst)
        {
            fixed (Vector2* pPoints = points)
            {
                ImageDrawTriangleStrip(pDst, pPoints, points.Length, color);
            }
        }
    }

    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    public static void ImageDraw(ref Image dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
    {
        fixed (Image* pDst = &dst)
        {
            ImageDraw(pDst, src, srcRec, dstRec, tint);
        }
    }

    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    public static void ImageDrawText(ref Image dst, string text, int posX, int posY, int fontSize, Color color)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        fixed (Image* pDst = &dst)
        {
            ImageDrawText(pDst, (sbyte*)pText, posX, posY, fontSize, color);
        }

        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public static void ImageDrawTextEx(ref Image dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        fixed (Image* pDst = &dst)
        {
            ImageDrawTextEx(pDst, font, (sbyte*)pText, position, fontSize, spacing, tint);
        }

        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    public static Texture2D LoadTexture(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Texture2D result = LoadTexture((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    public static void UpdateTexture<T>(Texture2D texture, ReadOnlySpan<T> pixels)
        where T : unmanaged
    {
        fixed (T* pPixels = pixels)
        {
            UpdateTexture(texture, pPixels);
        }
    }

    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    public static void UpdateTextureRec<T>(Texture2D texture, Rectangle rec, ReadOnlySpan<T> pixels)
        where T : unmanaged
    {
        fixed (T* pPixels = pixels)
        {
            UpdateTextureRec(texture, rec, pPixels);
        }
    }

    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    public static void GenTextureMipmaps(ref Texture2D texture)
    {
        fixed (Texture2D* pTexture = &texture)
        {
            GenTextureMipmaps(pTexture);
        }
    }

    /// <summary>
    /// Load font from file into GPU memory (VRAM)
    /// </summary>
    public static Font LoadFont(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Font result = LoadFont((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load font from file with extended parameters, use NULL for codepoints and 0 for codepointCount to load the default
    /// character set, font size is provided in pixels height
    /// </summary>
    public static Font LoadFontEx(string fileName, int fontSize, ReadOnlySpan<int> codepoints)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Font result;
        fixed (int* pCodepoints = codepoints)
        {
            result = LoadFontEx((sbyte*)pFileName, fontSize, pCodepoints, codepoints.Length);
        }

        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load font from file with extended parameters, use NULL for codepoints and 0 for codepointCount to load the default
    /// character set, font size is provided in pixels height
    /// </summary>
    public static Font LoadFontEx(string fileName, int fontSize, int codepointCount)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Font result = LoadFontEx((sbyte*)pFileName, fontSize, null, codepointCount);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(string fileType, ReadOnlySpan<byte> fileData, int fontSize, ReadOnlySpan<int> codepoints)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Font result;
        fixed (byte* pFileData = fileData)
        {
            fixed (int* pCodepoints = codepoints)
            {
                result = LoadFontFromMemory((sbyte*)pFileType, pFileData, fileData.Length, fontSize, pCodepoints, codepoints.Length);
            }

        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(string fileType, ReadOnlySpan<byte> fileData, int fontSize, int codepointCount)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Font result;
        fixed (byte* pFileData = fileData)
        {
            result = LoadFontFromMemory((sbyte*)pFileType, pFileData, fileData.Length, fontSize, null, codepointCount);
        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public static GlyphInfo* LoadFontData(ReadOnlySpan<byte> fileData, int fontSize, ReadOnlySpan<int> codepoints, FontType type)
    {
        fixed (byte* pFileData = fileData)
        {
            fixed (int* pCodepoints = codepoints)
            {
                return LoadFontData(pFileData, fileData.Length, fontSize, pCodepoints, codepoints.Length, type);
            }
        }
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public static GlyphInfo* LoadFontData(ReadOnlySpan<byte> fileData, int fontSize, int codepointCount, FontType type)
    {
        fixed (byte* pFileData = fileData)
        {
            return LoadFontData(pFileData, fileData.Length, fontSize, null, codepointCount, type);
        }
    }

    // TODO: maybe use Span<Rectangle> instead?
    // nevermind using span causes heap corruption

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    public static Image GenImageFontAtlas(ReadOnlySpan<GlyphInfo> glyphs, out Rectangle[] glyphRecs, int fontSize, int padding, int packMethod)
    {
        Image result;
        fixed (GlyphInfo* pGlyphs = glyphs)
        {
            Rectangle* nativeGlyphRecs;
            result = GenImageFontAtlas(pGlyphs, &nativeGlyphRecs, glyphs.Length, fontSize, padding, packMethod);

            glyphRecs = new Rectangle[glyphs.Length];
            fixed (Rectangle* pGlyphRecs = glyphRecs)
            {
                int size = glyphs.Length * sizeof(GlyphInfo);
                Buffer.MemoryCopy(nativeGlyphRecs, pGlyphRecs, size, size);
            }

            MemFree(nativeGlyphRecs);
        }

        return result;
    }

    /// <summary>
    /// Export font as code file, returns true on success
    /// </summary>
    public static NativeBool ExportFontAsCode(Font font, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportFontAsCode(font, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        DrawText((sbyte*)pText, posX, posY, fontSize, color);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        DrawTextEx(font, (sbyte*)pText, position, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public static void DrawTextPro(
        Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        DrawTextPro(font, (sbyte*)pText, position, origin, rotation, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <summary>
    /// Draw multiple character (codepoint)
    /// </summary>
    public static void DrawTextCodepoints(Font font, ReadOnlySpan<int> codepoints, Vector2 position, float fontSize, float spacing, Color tint)
    {
        fixed (int* pCodepoints = codepoints)
        {
            DrawTextCodepoints(font, pCodepoints, codepoints.Length, position, fontSize, spacing, tint);
        }
    }

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    public static int MeasureText(string text, int fontSize)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        int result = MeasureText((sbyte*)pText, fontSize);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        Vector2 result = MeasureTextEx(font, (sbyte*)pText, fontSize, spacing);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Load UTF-8 text encoded from codepoints array
    /// </summary>
    public static sbyte* LoadUTF8(ReadOnlySpan<int> codepoints)
    {
        fixed (int* pCodepoints = codepoints)
        {
            return LoadUTF8(pCodepoints, codepoints.Length);
        }
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public static int* LoadCodepoints(string text, out int count)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        int* result;
        fixed (int* pCount = &count)
        {
            result = LoadCodepoints((sbyte*)pText, pCount);
        }

        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public static int GetCodepointCount(string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        int result = GetCodepointCount((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepoint(string text, out int codepointSize)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        int result;
        fixed (int* pCodepointSize = &codepointSize)
        {
            result = GetCodepoint((sbyte*)pText, pCodepointSize);
        }

        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepointNext(string text, out int codepointSize)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        int result;
        fixed (int* pCodepointSize = &codepointSize)
        {
            result = GetCodepointNext((sbyte*)pText, pCodepointSize);
        }

        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Get previous codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepointPrevious(string text, out int codepointSize)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        int result;
        fixed (int* pCodepointSize = &codepointSize)
        {
            result = GetCodepointPrevious((sbyte*)pText, pCodepointSize);
        }

        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    public static string CodepointToUTF8(int codepoint)
    {
        int utf8Size;
        return Marshal.PtrToStringUTF8((nint)CodepointToUTF8(codepoint, &utf8Size), utf8Size);
    }

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    public static string TextToPascal(string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        sbyte* result = TextToPascal((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get Snake case notation version of provided string
    /// </summary>
    public static string TextToSnake(string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        sbyte* result = TextToSnake((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Get Camel case notation version of provided string
    /// </summary>
    public static string TextToCamel(string text)
    {
        nint pText = Marshal.StringToCoTaskMemUTF8(text);
        sbyte* result = TextToCamel((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip3D(ReadOnlySpan<Vector3> points, Color color)
    {
        fixed (Vector3* pPoints = points)
        {
            DrawTriangleStrip3D(pPoints, points.Length, color);
        }
    }

    /// <summary>
    /// Load model from files (meshes and materials)
    /// </summary>
    public static Model LoadModel(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Model result = LoadModel((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    public static void UploadMesh(ref Mesh mesh, NativeBool dynamic)
    {
        fixed (Mesh* pMesh = &mesh)
        {
            UploadMesh(pMesh, dynamic);
        }
    }

    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    public static void UpdateMeshBuffer<T>(Mesh mesh, int index, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateMeshBuffer(mesh, index, pData, data.Length * sizeof(T), offset);
        }
    }

    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    public static void DrawMeshInstanced(Mesh mesh, Material material, ReadOnlySpan<Matrix4x4> transforms)
    {
        fixed (Matrix4x4* pTransforms = transforms)
        {
            DrawMeshInstanced(mesh, material, pTransforms, transforms.Length);
        }
    }

    /// <summary>
    /// Compute mesh tangents
    /// </summary>
    public static void GenMeshTangents(ref Mesh mesh)
    {
        fixed (Mesh* pMesh = &mesh)
        {
            GenMeshTangents(pMesh);
        }
    }

    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    public static NativeBool ExportMesh(Mesh mesh, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportMesh(mesh, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Export mesh as code file (.h) defining multiple arrays of vertex attributes
    /// </summary>
    public static NativeBool ExportMeshAsCode(Mesh mesh, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportMeshAsCode(mesh, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load materials from model file
    /// </summary>
    public static Material* LoadMaterials(string fileName, out int materialCount)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Material* result;
        fixed (int* pMaterialCount = &materialCount)
        {
            result = LoadMaterials((sbyte*)pFileName, pMaterialCount);
        }

        Marshal.FreeCoTaskMem(pFileName);

        return result;
    }

    /// <summary>
    /// Set texture for a material map type (MATERIAL_MAP_DIFFUSE, MATERIAL_MAP_SPECULAR...)
    /// </summary>
    public static void SetMaterialTexture(ref Material material, MaterialMapIndex mapType, Texture2D texture)
    {
        fixed (Material* pMaterial = &material)
        {
            SetMaterialTexture(pMaterial, mapType, texture);
        }
    }

    /// <summary>
    /// Set material for a mesh
    /// </summary>
    public static void SetModelMeshMaterial(ref Model model, int meshId, int materialId)
    {
        fixed (Model* pModel = &model)
        {
            SetModelMeshMaterial(pModel, meshId, materialId);
        }
    }

    /// <summary>
    /// Load model animations from file
    /// </summary>
    public static ModelAnimation* LoadModelAnimations(string fileName, out int animCount)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        ModelAnimation* result;
        fixed (int* pAnimCount = &animCount)
        {
            result = LoadModelAnimations((sbyte*)pFileName, pAnimCount);
        }

        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public static Wave LoadWave(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Wave result = LoadWave((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public static Wave LoadWaveFromMemory(string fileType, ReadOnlySpan<byte> fileData)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Wave result;
        fixed (byte* pFileData = fileData)
        {
            result = LoadWaveFromMemory((sbyte*)pFileType, pFileData, fileData.Length);
        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public static Sound LoadSound(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Sound result = LoadSound((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public static void UpdateSound<T>(Sound sound, ReadOnlySpan<T> data, int sampleCount)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateSound(sound, pData, sampleCount);
        }
    }

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public static NativeBool ExportWave(Wave wave, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportWave(wave, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public static NativeBool ExportWaveAsCode(Wave wave, string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result = ExportWaveAsCode(wave, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Crop a wave to defined frames range
    /// </summary>
    public static void WaveCrop(ref Wave wave, int initFrame, int finalFrame)
    {
        fixed (Wave* pWave = &wave)
        {
            WaveCrop(pWave, initFrame, finalFrame);
        }
    }

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public static void WaveFormat(ref Wave wave, int sampleRate, int sampleSize, int channels)
    {
        fixed (Wave* pWave = &wave)
        {
            WaveFormat(pWave, sampleRate, sampleSize, channels);
        }
    }

    /// <summary>
    /// Load music stream from file
    /// </summary>
    public static Music LoadMusicStream(string fileName)
    {
        nint pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Music result = LoadMusicStream((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public static Music LoadMusicStreamFromMemory(string fileType, ReadOnlySpan<byte> data)
    {
        nint pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Music result;
        fixed (byte* pData = data)
        {
            result = LoadMusicStreamFromMemory((sbyte*)pFileType, pData, data.Length);
        }

        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public static void UpdateAudioStream<T>(AudioStream stream, ReadOnlySpan<T> data, int frameCount)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateAudioStream(stream, pData, frameCount);
        }
    }
}