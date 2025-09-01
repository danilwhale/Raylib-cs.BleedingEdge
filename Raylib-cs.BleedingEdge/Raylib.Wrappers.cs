using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Raylib
{
    /// <summary>
    /// Initialize window and OpenGL context
    /// </summary>
    public static void InitWindow(int width, int height, Utf8String title)
    {
        fixed (byte* pTitle = title) InitWindow(width, height, pTitle);
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
    public static void SetWindowTitle(Utf8String title)
    {
        fixed (byte* pTitle = title) SetWindowTitle(pTitle);
    }

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the specified monitor
    /// </summary>
    public static Utf8String GetMonitorNameString(int monitor)
    {
        return Marshal.PtrToStringUTF8((nint)GetMonitorName(monitor)) ?? string.Empty;
    }

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    public static void SetClipboardText(Utf8String text)
    {
        fixed (byte* pText = text) SetClipboardText(pText);
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    public static string? GetClipboardTextString()
    {
        return Marshal.PtrToStringUTF8((nint)GetClipboardText());
    }

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    public static Shader LoadShader(Utf8String vsFileName, Utf8String fsFileName)
    {
        fixed (byte* pVsFileName = vsFileName)
        fixed (byte* pFsFileName = fsFileName)
            return LoadShader(pVsFileName, pFsFileName);
    }

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    public static Shader LoadShaderFromMemory(Utf8String vsCode, Utf8String fsCode)
    {
        fixed (byte* pVsCode = vsCode)
        fixed (byte* pFsCode = fsCode)
            return LoadShaderFromMemory(pVsCode, pFsCode);
    }

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public static int GetShaderLocation(Shader shader, Utf8String uniformName)
    {
        fixed (byte* pUniformName = uniformName) return GetShaderLocation(shader, pUniformName);
    }

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public static int GetShaderLocationAttrib(Shader shader, Utf8String attribName)
    {
        fixed (byte* pAttribName = attribName) return GetShaderLocationAttrib(shader, pAttribName);
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
    public static void TakeScreenshot(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) TakeScreenshot(pFileName);
    }

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    public static void OpenURL(Utf8String url)
    {
        fixed (byte* pUrl = url) OpenURL(pUrl);
    }

    /// <summary>
    /// Show trace log messages (TraceLogLevel.Debug, TraceLogLevel.Info, TraceLogLevel.Warning, TraceLogLevel.Error...)
    /// </summary>
    public static void TraceLog(TraceLogLevel logLevel, Utf8String text)
    {
        fixed (byte* pText = text) TraceLog(logLevel, pText);
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
    public static byte* LoadFileData(Utf8String fileName, out int dataSize)
    {
        fixed (byte* pFileName = fileName)
        fixed (int* pDataSize = &dataSize)
        {
            return LoadFileData(pFileName, pDataSize);
        }
    }

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    public static NativeBool SaveFileData<T>(Utf8String fileName, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        fixed (byte* pFileName = fileName)
        fixed (T* pData = data)
        {
            return SaveFileData(pFileName, pData, data.Length * sizeof(T));
        }
    }

    /// <summary>
    /// Export data to code (.h), returns true on success
    /// </summary>
    public static NativeBool ExportDataAsCode(ReadOnlySpan<byte> data, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName)
        fixed (byte* pData = data)
        {
            return ExportDataAsCode(pData, data.Length, pFileName);
        }
    }

    /// <summary>
    /// Load text data from file (read), returns a '\0' terminated string
    /// </summary>
    public static byte* LoadFileText(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadFileText(pFileName);
    }

    /// <summary>
    /// Save text data to file (write), Utf8String must be '\0' terminated, returns true on success
    /// </summary>
    public static NativeBool SaveFileText(Utf8String fileName, Utf8String text)
    {
        fixed (byte* pFileName = fileName)
        fixed (byte* pText = text)
            return SaveFileText(pFileName, pText);
    }

    /// <summary>
    /// Check if file exists
    /// </summary>
    public static NativeBool FileExists(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return FileExists(pFileName);
    }

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    public static NativeBool DirectoryExists(Utf8String dirName)
    {
        fixed (byte* pDirName = dirName) return DirectoryExists(pDirName);
    }

    /// <summary>
    /// Check file extension (recommended include point: .png, .wav)
    /// </summary>
    public static NativeBool IsFileExtension(Utf8String fileName, Utf8String ext)
    {
        fixed (byte* pFileName = fileName)
        fixed (byte* pExt = ext)
            return IsFileExtension(pFileName, pExt);
    }

    /// <summary>
    /// Get file length in bytes (NOTE: GetFileSize() conflicts with windows.h)
    /// </summary>
    public static int GetFileLength(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return GetFileLength(pFileName);
    }

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    public static string? GetFileExtension(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return Marshal.PtrToStringUTF8((nint)GetFileExtension(pFileName));
    }

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    public static string? GetFileName(Utf8String filePath)
    {
        fixed (byte* pFilePath = filePath) return Marshal.PtrToStringUTF8((nint)GetFileName(pFilePath));
    }

    /// <summary>
    /// Get filename Utf8String without extension (uses static string)
    /// </summary>
    public static string? GetFileNameWithoutExt(Utf8String filePath)
    {
        fixed (byte* pFilePath = filePath) return Marshal.PtrToStringUTF8((nint)GetFileNameWithoutExt(pFilePath));
    }

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    public static string? GetDirectoryPath(Utf8String filePath)
    {
        fixed (byte* pFilePath = filePath) return Marshal.PtrToStringUTF8((nint)GetDirectoryPath(pFilePath));
    }

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    public static string? GetPrevDirectoryPath(Utf8String dirPath)
    {
        fixed (byte* pDirPath = dirPath) return Marshal.PtrToStringUTF8((nint)GetPrevDirectoryPath(pDirPath));
    }

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    public static string? GetWorkingDirectoryString()
    {
        return Marshal.PtrToStringUTF8((nint)GetWorkingDirectory());
    }

    /// <summary>
    /// Get the directory of the running application (uses static string)
    /// </summary>
    public static string? GetApplicationDirectoryString()
    {
        return Marshal.PtrToStringUTF8((nint)GetApplicationDirectory());
    }

    /// <summary>
    /// Create directories (including full path requested), returns 0 on success
    /// </summary>
    public static int MakeDirectory(Utf8String dirPath)
    {
        fixed (byte* pDirPath = dirPath) return MakeDirectory(pDirPath);
    }

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    public static NativeBool ChangeDirectory(Utf8String dir)
    {
        fixed (byte* pDir = dir) return ChangeDirectory(pDir);
    }

    /// <summary>
    /// Check if a given path is a file or a directory
    /// </summary>
    public static NativeBool IsPathFile(Utf8String path)
    {
        fixed (byte* pPath = path) return IsPathFile(pPath);
    }

    /// <summary>
    /// Check if fileName is valid for the platform/OS
    /// </summary>
    public static NativeBool IsFileNameValid(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return IsFileNameValid(pFileName);
    }

    /// <summary>
    /// Load directory filepaths
    /// </summary>
    public static FilePathList LoadDirectoryFiles(Utf8String dirPath)
    {
        fixed (byte* pDirPath = dirPath) return LoadDirectoryFiles(pDirPath);
    }

    /// <summary>
    /// Load directory filepaths with extension filtering and recursive directory scan
    /// </summary>
    public static FilePathList LoadDirectoryFilesEx(Utf8String basePath, Utf8String filter, NativeBool scanSubdirs)
    {
        fixed (byte* pBasePath = basePath)
        fixed (byte* pFilter = filter)
            return LoadDirectoryFilesEx(pBasePath, pFilter, scanSubdirs);
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
    /// Encode data to Base64 string (includes NULL terminator), memory must be MemFree()
    /// </summary>
    public static byte* EncodeDataBase64(ReadOnlySpan<byte> data, out int outputSize)
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
    /// Decode Base64 Utf8String data, memory must be MemFree()
    /// </summary>
    public static byte* DecodeDataBase64(Utf8String text, out int outputSize)
    {
        fixed (byte* pText = text)
        fixed (int* pOutputSize = &outputSize) 
        {
            return DecodeDataBase64(pText, pOutputSize);
        }
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

    // ComputeMD5 and ComputeSHA1 don't allocate memory using MemAlloc, so we can use Span for them

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
    public static AutomationEventList LoadAutomationEventList(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadAutomationEventList(pFileName);
    }

    /// <summary>
    /// Export automation events list as text file
    /// </summary>
    public static NativeBool ExportAutomationEventList(AutomationEventList list, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportAutomationEventList(list, pFileName);
    }

    /// <summary>
    /// Set automation event list to record to
    /// </summary>
    /// <remarks>
    /// Use <see cref="SetAutomationEventList(NativeHandle{AutomationEventList})"/>
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
    public static string? GetKeyNameString(KeyboardKey key)
    {
        return Marshal.PtrToStringUTF8((nint)GetKeyName(key));
    }

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    public static string? GetGamepadNameString(int gamepad)
    {
        return Marshal.PtrToStringUTF8((nint)GetGamepadName(gamepad));
    }

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    public static int SetGamepadMappings(Utf8String mappings)
    {
        fixed (byte* pMappings = mappings) return SetGamepadMappings(pMappings);
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
    public static Image LoadImage(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadImage(pFileName);
    }

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    public static Image LoadImageRaw(Utf8String fileName, int width, int height, PixelFormat format, int headerSize)
    {
        fixed (byte* pFileName = fileName) return LoadImageRaw(pFileName, width, height, format, headerSize);
    }

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    public static Image LoadImageAnim(Utf8String fileName, out int frames)
    {
        fixed (byte* pFileName = fileName)
        fixed (int* pFrames = &frames)
            return LoadImageAnim(pFileName, pFrames);
    }

    /// <summary>
    /// Load image sequence from memory buffer
    /// </summary>
    public static Image LoadImageAnimFromMemory(Utf8String fileType, ReadOnlySpan<byte> fileData, out int frames)
    {
        fixed (byte* pFileType = fileType)
        fixed (byte* pFileData = fileData)
        fixed (int* pFrames = &frames)
        {
            return LoadImageAnimFromMemory(pFileType, pFileData, fileData.Length, pFrames);
        }
    }

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    public static Image LoadImageFromMemory(Utf8String fileType, ReadOnlySpan<byte> fileData)
    {
        fixed (byte* pFileType = fileType)
        fixed (byte* pFileData = fileData)
        {
            return LoadImageFromMemory(pFileType, pFileData, fileData.Length);
        }
    }

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    public static NativeBool ExportImage(Image image, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportImage(image, pFileName);
    }

    /// <summary>
    /// Export image to memory buffer
    /// </summary>
    public static byte* ExportImageToMemory(Image image, Utf8String fileType, out int fileSize)
    {
        fixed (byte* pFileType = fileType)
        fixed (int* pFileSize = &fileSize)
        {
            return ExportImageToMemory(image, pFileType, pFileSize);
        }
    }

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public static NativeBool ExportImageAsCode(Image image, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportImageAsCode(image, pFileName);
    }

    /// <summary>
    /// Generate image: grayscale image from text data
    /// </summary>
    public static Image GenImageText(int width, int height, Utf8String text)
    {
        fixed (byte* pText = text) return GenImageText(width, height, pText);
    }

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    public static Image ImageText(Utf8String text, int fontSize, Color color)
    {
        fixed (byte* pText = text) return ImageText(pText, fontSize, color);
    }

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    public static Image ImageTextEx(Font font, Utf8String text, float fontSize, float spacing, Color tint)
    {
        fixed (byte* pText = text) return ImageTextEx(font, pText, fontSize, spacing, tint);
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
    public static void ImageDrawText(ref Image dst, Utf8String text, int posX, int posY, int fontSize, Color color)
    {
        fixed (Image* pDst = &dst)
        fixed (byte* pText = text)
        {
            ImageDrawText(pDst, pText, posX, posY, fontSize, color);
        }
    }

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public static void ImageDrawTextEx(ref Image dst, Font font, Utf8String text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        fixed (Image* pDst = &dst)
        fixed (byte* pText = text)
        {
            ImageDrawTextEx(pDst, font, pText, position, fontSize, spacing, tint);
        }
    }

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    public static Texture2D LoadTexture(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadTexture(pFileName);
    }

    /// <summary>
    /// Update GPU texture with new data (pixels should be able to fill texture)
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
    /// Update GPU texture rectangle with new data (pixels and rec should fit in texture)
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
    public static Font LoadFont(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadFont(pFileName);
    }

    /// <summary>
    /// Load font from file with extended parameters, use NULL for codepoints and 0 for codepointCount to load the default
    /// character set, font size is provided in pixels height
    /// </summary>
    public static Font LoadFontEx(Utf8String fileName, int fontSize, ReadOnlySpan<int> codepoints)
    {
        fixed (byte* pFileName = fileName)
        fixed (int* pCodepoints = codepoints)
        {
            return LoadFontEx(pFileName, fontSize, pCodepoints, codepoints.Length);
        }
    }

    /// <summary>
    /// Load font from file with extended parameters, use NULL for codepoints and 0 for codepointCount to load the default
    /// character set, font size is provided in pixels height
    /// </summary>
    public static Font LoadFontEx(Utf8String fileName, int fontSize, int codepointCount)
    {
        fixed (byte* pFileName = fileName) return LoadFontEx(pFileName, fontSize, null, codepointCount);
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(Utf8String fileType, ReadOnlySpan<byte> fileData, int fontSize, ReadOnlySpan<int> codepoints)
    {
        fixed (byte* pFileType = fileType)
        fixed (byte* pFileData = fileData)
            fixed (int* pCodepoints = codepoints)
            {
                return LoadFontFromMemory(pFileType, pFileData, fileData.Length, fontSize, pCodepoints, codepoints.Length);
            }
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(Utf8String fileType, ReadOnlySpan<byte> fileData, int fontSize, int codepointCount)
    {
        fixed (byte* pFileType = fileType)
        fixed (byte* pFileData = fileData)
        {
            return LoadFontFromMemory(pFileType, pFileData, fileData.Length, fontSize, null, codepointCount);
        }
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public static GlyphInfo* LoadFontData(ReadOnlySpan<byte> fileData, int fontSize, Span<int> codepoints, FontType type)
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
    /// <remarks>
    /// Allocates managed array to return glyph rectangles, use <see cref="GenImageFontAtlas(System.ReadOnlySpan{Raylib_cs.BleedingEdge.GlyphInfo},out Raylib_cs.BleedingEdge.Rectangle*,int,int,int)"/>
    /// to avoid allocating extra memory
    /// </remarks>
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
    /// Generate image font atlas using chars info
    /// </summary>
    public static Image GenImageFontAtlas(ReadOnlySpan<GlyphInfo> glyphs, out Rectangle* glyphRecs, int fontSize, int padding, int packMethod)
    {
        Image result;
        fixed (GlyphInfo* pGlyphs = glyphs)
        fixed (Rectangle** pGlyphRecs = &glyphRecs)
        {
            result = GenImageFontAtlas(pGlyphs, pGlyphRecs, glyphs.Length, fontSize, padding, packMethod);
        }

        return result;
    }

    /// <summary>
    /// Export font as code file, returns true on success
    /// </summary>
    public static NativeBool ExportFontAsCode(Font font, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportFontAsCode(font, pFileName);
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(Utf8String text, int posX, int posY, int fontSize, Color color)
    {
        fixed (byte* pText = text) DrawText(pText, posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public static void DrawTextEx(Font font, Utf8String text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        fixed (byte* pText = text) DrawTextEx(font, pText, position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public static void DrawTextPro(
        Font font, Utf8String text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        fixed (byte* pText = text) DrawTextPro(font, pText, position, origin, rotation, fontSize, spacing, tint);
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
    /// Measure Utf8String width for default font
    /// </summary>
    public static int MeasureText(Utf8String text, int fontSize)
    {
        fixed (byte* pText = text) return MeasureText(pText, fontSize);
    }

    /// <summary>
    /// Measure Utf8String size for Font
    /// </summary>
    public static Vector2 MeasureTextEx(Font font, Utf8String text, float fontSize, float spacing)
    {
        fixed (byte* pText = text) return MeasureTextEx(font, pText, fontSize, spacing);
    }

    /// <summary>
    /// Load UTF-8 text encoded from codepoints array
    /// </summary>
    public static byte* LoadUTF8(ReadOnlySpan<int> codepoints)
    {
        fixed (int* pCodepoints = codepoints)
        {
            return LoadUTF8(pCodepoints, codepoints.Length);
        }
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public static int* LoadCodepoints(Utf8String text, out int count)
    {
        fixed (byte* pText = text)
        fixed (int* pCount = &count)
        {
            return LoadCodepoints(pText, pCount);
        }
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public static int GetCodepointCount(Utf8String text)
    {
        fixed (byte* pText = text) return GetCodepointCount(pText);
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepoint(Utf8String text, out int codepointSize)
    {
        fixed (byte* pText = text)
        fixed (int* pCodepointSize = &codepointSize)
        {
            return GetCodepoint(pText, pCodepointSize);
        }
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepointNext(Utf8String text, out int codepointSize)
    {
        fixed (byte* pText = text)
        fixed (int* pCodepointSize = &codepointSize)
        {
            return GetCodepointNext(pText, pCodepointSize);
        }
    }

    /// <summary>
    /// Get previous codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepointPrevious(Utf8String text, out int codepointSize)
    {
        fixed (byte* pText = text)
        fixed (int* pCodepointSize = &codepointSize)
        {
            return GetCodepointPrevious(pText, pCodepointSize);
        }
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
    public static string? TextToPascal(Utf8String text)
    {
        fixed (byte* pText = text) return Marshal.PtrToStringUTF8((nint)TextToPascal(pText));
    }

    /// <summary>
    /// Get Snake case notation version of provided string
    /// </summary>
    public static string? TextToSnake(Utf8String text)
    {
        fixed (byte* pText = text) return Marshal.PtrToStringUTF8((nint)TextToSnake(pText));
    }

    /// <summary>
    /// Get Camel case notation version of provided string
    /// </summary>
    public static string? TextToCamel(Utf8String text)
    {
        fixed (byte* pText = text) return Marshal.PtrToStringUTF8((nint)TextToCamel(pText));
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
    public static Model LoadModel(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadModel(pFileName);
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
    public static NativeBool ExportMesh(Mesh mesh, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportMesh(mesh, pFileName);
    }

    /// <summary>
    /// Export mesh as code file (.h) defining multiple arrays of vertex attributes
    /// </summary>
    public static NativeBool ExportMeshAsCode(Mesh mesh, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportMeshAsCode(mesh, pFileName);
    }

    /// <summary>
    /// Load materials from model file
    /// </summary>
    public static Material* LoadMaterials(Utf8String fileName, out int materialCount)
    {
        fixed (byte* pFileName = fileName)
        fixed (int* pMaterialCount = &materialCount)
        {
            return LoadMaterials(pFileName, pMaterialCount);
        }
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
    public static ModelAnimation* LoadModelAnimations(Utf8String fileName, out int animCount)
    {
        fixed (byte* pFileName = fileName)
        fixed (int* pAnimCount = &animCount)
        {
            return LoadModelAnimations(pFileName, pAnimCount);
        }
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public static Wave LoadWave(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadWave(pFileName);
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public static Wave LoadWaveFromMemory(Utf8String fileType, ReadOnlySpan<byte> fileData)
    {
        fixed (byte* pFileType = fileType)
        fixed (byte* pFileData = fileData)
        {
            return LoadWaveFromMemory(pFileType, pFileData, fileData.Length);
        }
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public static Sound LoadSound(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadSound(pFileName);
    }

    /// <summary>
    /// Update sound buffer with new data (data and frame count should fit in sound)
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
    public static NativeBool ExportWave(Wave wave, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportWave(wave, pFileName);
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public static NativeBool ExportWaveAsCode(Wave wave, Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return ExportWaveAsCode(wave, pFileName);
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
    public static Music LoadMusicStream(Utf8String fileName)
    {
        fixed (byte* pFileName = fileName) return LoadMusicStream(pFileName);
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public static Music LoadMusicStreamFromMemory(Utf8String fileType, ReadOnlySpan<byte> data)
    {
        fixed (byte* pFileType = fileType)
        fixed (byte* pData = data)
        {
            return LoadMusicStreamFromMemory(pFileType, pData, data.Length);
        }
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