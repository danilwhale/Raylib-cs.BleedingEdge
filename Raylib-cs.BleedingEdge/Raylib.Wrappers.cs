using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge.Types;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Raylib
{
    // all methods with native string (char*, or sbyte* in P/Invoke) parameters are using Marshal directly
    // instead of something like Utf8Buffer in Raylib-cs to reduce execution time and allocations
    // Utf8Handle is provided for user use

    /// <inheritdoc cref="InitWindow(int,int,sbyte*)"/>
    public static void InitWindow(int width, int height, string title)
    {
        var pTitle = Marshal.StringToCoTaskMemUTF8(title);
        InitWindow(width, height, (sbyte*)pTitle);
        Marshal.FreeCoTaskMem(pTitle);
    }

    /// <inheritdoc cref="SetWindowIcons(Image*,int)"/>
    public static void SetWindowIcons(ReadOnlySpan<Image> images)
    {
        fixed (Image* pImages = images)
        {
            SetWindowIcons(pImages, images.Length);
        }
    }

    /// <inheritdoc cref="SetWindowTitle(sbyte*)"/>
    public static void SetWindowTitle(string title)
    {
        var pTitle = Marshal.StringToCoTaskMemUTF8(title);
        SetWindowTitle((sbyte*)pTitle);
        Marshal.FreeCoTaskMem(pTitle);
    }

    /// <inheritdoc cref="GetMonitorName"/>
    public static string GetMonitorNameString(int monitor)
    {
        return Marshal.PtrToStringUTF8((IntPtr)GetMonitorName(monitor)) ?? string.Empty;
    }

    /// <inheritdoc cref="SetClipboardText(sbyte*)"/>
    public static void SetClipboardText(string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        SetClipboardText((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="GetClipboardText"/>
    public static string GetClipboardTextString()
    {
        return Marshal.PtrToStringUTF8((nint)GetClipboardText()) ?? string.Empty;
    }

    /// <inheritdoc cref="LoadShader(sbyte*,sbyte*)"/>
    public static Shader LoadShader(string vsFileName, string fsFileName)
    {
        var pVsFileName = Marshal.StringToCoTaskMemUTF8(vsFileName);
        var pFsFileName = Marshal.StringToCoTaskMemUTF8(fsFileName);
        var result = LoadShader((sbyte*)pVsFileName, (sbyte*)pFsFileName);
        Marshal.FreeCoTaskMem(pFsFileName);
        Marshal.FreeCoTaskMem(pFsFileName);
        return result;
    }

    /// <inheritdoc cref="LoadShaderFromMemory(sbyte*,sbyte*)"/>
    public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
    {
        var pVsCode = Marshal.StringToCoTaskMemUTF8(vsCode);
        var pFsCode = Marshal.StringToCoTaskMemUTF8(fsCode);
        var result = LoadShaderFromMemory((sbyte*)pVsCode, (sbyte*)pFsCode);
        Marshal.FreeCoTaskMem(pFsCode);
        Marshal.FreeCoTaskMem(pFsCode);
        return result;
    }

    /// <inheritdoc cref="GetShaderLocation(Raylib_cs.BleedingEdge.Types.Shader,sbyte*)"/>
    public static int GetShaderLocation(Shader shader, string uniformName)
    {
        var pUniformName = Marshal.StringToCoTaskMemUTF8(uniformName);
        var result = GetShaderLocation(shader, (sbyte*)pUniformName);
        Marshal.FreeCoTaskMem(pUniformName);
        return result;
    }

    /// <inheritdoc cref="GetShaderLocationAttrib(Raylib_cs.BleedingEdge.Types.Shader,sbyte*)"/>
    public static int GetShaderLocationAttrib(Shader shader, string attribName)
    {
        var pAttribName = Marshal.StringToCoTaskMemUTF8(attribName);
        var result = GetShaderLocationAttrib(shader, (sbyte*)pAttribName);
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

    /// <inheritdoc cref="SetShaderValueV"/>
    public static void SetShaderValue<T>(Shader shader, int locIndex, ReadOnlySpan<T> value, ShaderUniformDataType uniformType)
        where T : unmanaged
    {
        fixed (T* pValue = value)
        {
            SetShaderValueV(shader, locIndex, pValue, uniformType, value.Length);
        }
    }

    /// <inheritdoc cref="SetShaderValueMatrix"/>
    public static void SetShaderValue(Shader shader, int locIndex, Matrix4x4 mat)
    {
        SetShaderValueMatrix(shader, locIndex, mat);
    }

    /// <inheritdoc cref="SetShaderValueTexture"/>
    public static void SetShaderValue(Shader shader, int locIndex, Texture texture)
    {
        SetShaderValueTexture(shader, locIndex, texture);
    }

    /// <inheritdoc cref="TakeScreenshot(sbyte*)"/>
    public static void TakeScreenshot(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        TakeScreenshot((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
    }

    /// <inheritdoc cref="OpenURL(sbyte*)"/>
    public static void OpenURL(string url)
    {
        var pUrl = Marshal.StringToCoTaskMemUTF8(url);
        OpenURL((sbyte*)pUrl);
        Marshal.FreeCoTaskMem(pUrl);
    }

    /// <inheritdoc cref="TraceLog(Raylib_cs.BleedingEdge.Enums.TraceLogLevel,sbyte*)"/>
    public static void TraceLog(TraceLogLevel logLevel, string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        TraceLog(logLevel, (sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="MemAlloc"/>
    public static T* MemAlloc<T>(uint elementCount)
        where T : unmanaged
    {
        return (T*)MemAlloc((uint)(elementCount * sizeof(T)));
    }

    /// <inheritdoc cref="MemRealloc"/>
    public static T* MemRealloc<T>(T* ptr, uint elementCount)
        where T : unmanaged
    {
        return (T*)MemRealloc((void*)ptr, (uint)(elementCount * sizeof(T)));
    }

    /// <inheritdoc cref="MemFree)"/>
    public static void MemFree<T>(Span<T> span)
        where T : unmanaged
    {
        fixed (T* pSpan = span)
        {
            MemFree(pSpan);
        }
    }

    /// <inheritdoc cref="LoadFileData(sbyte*,int*)"/>
    public static byte* LoadFileData(string fileName, out int dataSize)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
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
    public static NativeBool SaveFileData(string fileName, ReadOnlySpan<byte> data)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result;
        fixed (byte* pData = data)
        {
            result = SaveFileData((sbyte*)pFileName, pData, data.Length);
        }
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="ExportDataAsCode(byte*,int,sbyte*)"/>
    public static NativeBool ExportDataAsCode(ReadOnlySpan<byte> data, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        NativeBool result;
        fixed (byte* pData = data)
        {
            result = ExportDataAsCode(pData, data.Length, (sbyte*)pFileName);
        }
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadFileText(sbyte*)"/>
    public static sbyte* LoadFileText(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadFileText((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="SaveFileText(sbyte*,sbyte*)"/>
    public static NativeBool SaveFileText(string fileName, string text)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = SaveFileText((sbyte*)pFileName, (sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="FileExists(sbyte*)"/>
    public static NativeBool FileExists(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = FileExists((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="DirectoryExists(sbyte*)"/>
    public static NativeBool DirectoryExists(string dirName)
    {
        var pDirName = Marshal.StringToCoTaskMemUTF8(dirName);
        var result = DirectoryExists((sbyte*)pDirName);
        Marshal.FreeCoTaskMem(pDirName);
        return result;
    }

    /// <inheritdoc cref="IsFileExtension(sbyte*,sbyte*)"/>
    public static NativeBool IsFileExtension(string fileName, string ext)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var pExt = Marshal.StringToCoTaskMemUTF8(ext);
        var result = IsFileExtension((sbyte*)pFileName, (sbyte*)pExt);
        Marshal.FreeCoTaskMem(pExt);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="GetFileLength(sbyte*)"/>
    public static int GetFileLength(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = GetFileLength((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="GetFileExtension(sbyte*)"/>
    public static string GetFileExtension(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = GetFileExtension((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="GetFileName(sbyte*)"/>
    public static string GetFileName(string filePath)
    {
        var pFilePath = Marshal.StringToCoTaskMemUTF8(filePath);
        var result = GetFileName((sbyte*)pFilePath);
        Marshal.FreeCoTaskMem(pFilePath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="GetFileNameWithoutExt(sbyte*)"/>
    public static string GetFileNameWithoutExt(string filePath)
    {
        var pFilePath = Marshal.StringToCoTaskMemUTF8(filePath);
        var result = GetFileNameWithoutExt((sbyte*)pFilePath);
        Marshal.FreeCoTaskMem(pFilePath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="GetDirectoryPath(sbyte*)"/>
    public static string GetDirectoryPath(string filePath)
    {
        var pFilePath = Marshal.StringToCoTaskMemUTF8(filePath);
        var result = GetDirectoryPath((sbyte*)pFilePath);
        Marshal.FreeCoTaskMem(pFilePath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="GetPrevDirectoryPath(sbyte*)"/>
    public static string GetPrevDirectoryPath(string dirPath)
    {
        var pDirPath = Marshal.StringToCoTaskMemUTF8(dirPath);
        var result = GetPrevDirectoryPath((sbyte*)pDirPath);
        Marshal.FreeCoTaskMem(pDirPath);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="GetWorkingDirectory"/>
    public static string GetWorkingDirectoryString()
    {
        ;
        return Marshal.PtrToStringUTF8((nint)GetWorkingDirectory()) ?? string.Empty;
    }

    /// <inheritdoc cref="GetApplicationDirectory"/>
    public static string GetApplicationDirectoryString()
    {
        return Marshal.PtrToStringUTF8((nint)GetApplicationDirectory()) ?? string.Empty;
    }

    /// <inheritdoc cref="ChangeDirectory(sbyte*)"/>
    public static NativeBool ChangeDirectory(string dir)
    {
        var pDir = Marshal.StringToCoTaskMemUTF8(dir);
        var result = ChangeDirectory((sbyte*)pDir);
        Marshal.FreeCoTaskMem(pDir);
        return result;
    }

    /// <inheritdoc cref="IsPathFile(sbyte*)"/>
    public static NativeBool IsPathFile(string path)
    {
        var pPath = Marshal.StringToCoTaskMemUTF8(path);
        var result = IsPathFile((sbyte*)pPath);
        Marshal.FreeCoTaskMem(pPath);
        return result;
    }

    /// <inheritdoc cref="IsFileNameValid(sbyte*)"/>
    public static NativeBool IsFileNameValid(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = IsFileNameValid((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadDirectoryFiles(sbyte*)"/>
    public static FilePathList LoadDirectoryFiles(string dirPath)
    {
        var pDirPath = Marshal.StringToCoTaskMemUTF8(dirPath);
        var result = LoadDirectoryFiles((sbyte*)pDirPath);
        Marshal.FreeCoTaskMem(pDirPath);
        return result;
    }

    /// <inheritdoc cref="LoadDirectoryFilesEx(sbyte*,sbyte*,NativeBool)"/>
    public static FilePathList LoadDirectoryFilesEx(string basePath, string filter, NativeBool scanSubdirs)
    {
        var pBasePath = Marshal.StringToCoTaskMemUTF8(basePath);
        var pFilter = Marshal.StringToCoTaskMemUTF8(filter);
        var result = LoadDirectoryFilesEx((sbyte*)pBasePath, (sbyte*)pFilter, scanSubdirs);
        Marshal.FreeCoTaskMem(pFilter);
        Marshal.FreeCoTaskMem(pBasePath);
        return result;
    }

    /// <inheritdoc cref="CompressData(byte*,int,int*)"/>
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

    /// <inheritdoc cref="DecompressData(byte*,int,int*)"/>
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

    /// <inheritdoc cref="EncodeDataBase64(byte*,int,int*)"/>
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

    /// <inheritdoc cref="DecodeDataBase64(byte*,int*)"/>
    public static byte* DecodeDataBase64(ReadOnlySpan<byte> data, out int outputSize)
    {
        fixed (byte* pData = data)
        {
            fixed (int* pOutputSize = &outputSize)
            {
                return DecodeDataBase64(pData, pOutputSize);
            }
        }
    }

    /// <inheritdoc cref="LoadAutomationEventList(sbyte*)"/>
    public static AutomationEventList LoadAutomationEventList(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadAutomationEventList((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="ExportAutomationEventList(AutomationEventList,sbyte*)"/>
    public static NativeBool ExportAutomationEventList(AutomationEventList list, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportAutomationEventList(list, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    private static GCHandle _automationEventListHandle;

    /// <inheritdoc cref="SetAutomationEventList(AutomationEventList*)"/>
    public static void SetAutomationEventList(ref AutomationEventList list)
    {
        if (_automationEventListHandle.IsAllocated)
        {
            _automationEventListHandle.Free();
        }

        // pin specified AutomationEventList, so GC won't move it while raylib is recording data to it
        _automationEventListHandle = GCHandle.Alloc(list, GCHandleType.Pinned);

        SetAutomationEventList((AutomationEventList*)_automationEventListHandle.AddrOfPinnedObject());
    }

    /// <inheritdoc cref="GetGamepadName"/>
    public static string GetGamepadNameString(int gamepad)
    {
        return Marshal.PtrToStringUTF8((nint)GetGamepadName(gamepad)) ?? string.Empty;
    }

    /// <inheritdoc cref="SetGamepadMappings(sbyte*)"/>
    public static int SetGamepadMappings(string mappings)
    {
        var pMappings = Marshal.StringToCoTaskMemUTF8(mappings);
        var result = SetGamepadMappings((sbyte*)pMappings);
        Marshal.FreeCoTaskMem(pMappings);
        return result;
    }

    /// <inheritdoc cref="UpdateCamera(Camera3D*,CameraMode)"/>
    public static void UpdateCamera(ref Camera3D camera, CameraMode mode)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            UpdateCamera(pCamera, mode);
        }
    }

    /// <inheritdoc cref="UpdateCameraPro(Camera3D*,Vector3,Vector3,float)"/>
    public static void UpdateCameraPro(ref Camera3D camera, Vector3 movement, Vector3 rotation, float zoom)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            UpdateCameraPro(pCamera, movement, rotation, zoom);
        }
    }

    /// <inheritdoc cref="GetCameraForward(Camera3D*)"/>
    public static Vector3 GetCameraForward(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraForward(pCamera);
        }
    }

    /// <inheritdoc cref="GetCameraUp(Camera3D*)"/>
    public static Vector3 GetCameraUp(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraUp(pCamera);
        }
    }

    /// <inheritdoc cref="GetCameraRight(Camera3D*)"/>
    public static Vector3 GetCameraRight(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraRight(pCamera);
        }
    }

    /// <inheritdoc cref="CameraMoveForward(Camera3D*,float,NativeBool)"/>
    public static void CameraMoveForward(ref Camera3D camera, float distance, NativeBool moveInWorldPlane)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveForward(pCamera, distance, moveInWorldPlane);
        }
    }

    /// <inheritdoc cref="CameraMoveUp(Camera3D*,float)"/>
    public static void CameraMoveUp(ref Camera3D camera, float distance)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveUp(pCamera, distance);
        }
    }

    /// <inheritdoc cref="CameraMoveRight(Camera3D*,float,NativeBool)"/>
    public static void CameraMoveRight(ref Camera3D camera, float distance, NativeBool moveInWorldPlane)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveRight(pCamera, distance, moveInWorldPlane);
        }
    }

    /// <inheritdoc cref="CameraMoveToTarget(Camera3D*,float)"/>
    public static void CameraMoveToTarget(ref Camera3D camera, float delta)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraMoveToTarget(pCamera, delta);
        }
    }

    /// <inheritdoc cref="CameraYaw(Camera3D*,float,NativeBool)"/>
    public static void CameraYaw(ref Camera3D camera, float angle, NativeBool rotateAroundTarget)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraYaw(pCamera, angle, rotateAroundTarget);
        }
    }

    /// <inheritdoc cref="CameraPitch(Camera3D*,float,NativeBool,NativeBool,NativeBool)"/>
    public static void CameraPitch(ref Camera3D camera, float angle, NativeBool lockView, NativeBool rotateAroundTarget, NativeBool rotateUp)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraPitch(pCamera, angle, lockView, rotateAroundTarget, rotateUp);
        }
    }

    /// <inheritdoc cref="CameraRoll(Camera3D*,float)"/>
    public static void CameraRoll(ref Camera3D camera, float angle)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            CameraRoll(pCamera, angle);
        }
    }

    /// <inheritdoc cref="GetCameraViewMatrix(Camera3D*)"/>
    public static Matrix4x4 GetCameraViewMatrix(ref Camera3D camera)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraViewMatrix(pCamera);
        }
    }

    /// <inheritdoc cref="GetCameraProjectionMatrix(Camera3D*,float)"/>
    public static Matrix4x4 GetCameraProjectionMatrix(ref Camera3D camera, float aspect)
    {
        fixed (Camera3D* pCamera = &camera)
        {
            return GetCameraProjectionMatrix(pCamera, aspect);
        }
    }

    /// <inheritdoc cref="DrawLineStrip(Vector2*,int,Color)"/>
    public static void DrawLineStrip(ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawLineStrip(pPoints, points.Length, color);
        }
    }

    /// <inheritdoc cref="DrawTriangleFan(Vector2*,int,Color"/>
    public static void DrawTriangleFan(ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawTriangleFan(pPoints, points.Length, color);
        }
    }

    /// <inheritdoc cref="DrawTriangleStrip(Vector2*,int,Color)"/>
    public static void DrawTriangleStrip(ReadOnlySpan<Vector2> points, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawTriangleStrip(pPoints, points.Length, color);
        }
    }

    /// <inheritdoc cref="DrawSplineLinear(Vector2*,int,float,Color)"/>
    public static void DrawSplineLinear(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineLinear(pPoints, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="DrawSplineBasis(Vector2*,int,float,Color"/>
    public static void DrawSplineBasis(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineBasis(pPoints, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="DrawSplineCatmullRom(Vector2*,int,float,Color)"/>
    public static void DrawSplineCatmullRom(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineCatmullRom(pPoints, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="DrawSplineBezierQuadratic(Vector2*,int,float,Color)"/>
    public static void DrawSplineBezierQuadratic(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineBezierQuadratic(pPoints, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="DrawSplineBezierCubic(Vector2*,int,float,Color)"/>
    public static void DrawSplineBezierCubic(ReadOnlySpan<Vector2> points, float thick, Color color)
    {
        fixed (Vector2* pPoints = points)
        {
            DrawSplineBezierCubic(pPoints, points.Length, thick, color);
        }
    }

    /// <inheritdoc cref="CheckCollisionPointPoly(Vector2,Vector2*,int)"/>
    public static NativeBool CheckCollisionPointPoly(Vector2 point, ReadOnlySpan<Vector2> points)
    {
        fixed (Vector2* pPoints = points)
        {
            return CheckCollisionPointPoly(point, pPoints, points.Length);
        }
    }

    /// <inheritdoc cref="CheckCollisionLines(Vector2,Vector2,Vector2,Vector2,Vector2*)"/>
    public static NativeBool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, out Vector2 collisionPoint)
    {
        fixed (Vector2* pCollisionPoint = &collisionPoint)
        {
            return CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, pCollisionPoint);
        }
    }

    /// <inheritdoc cref="LoadImage(sbyte*)"/>
    public static Image LoadImage(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadImage((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadImageRaw(sbyte*,int,int,PixelFormat,int)"/>
    public static Image LoadImageRaw(string fileName, int width, int height, PixelFormat format, int headerSize)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadImageRaw((sbyte*)pFileName, width, height, format, headerSize);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadImageSvg(sbyte*,int,int)"/>
    public static Image LoadImageSvg(string fileNameOrString, int width, int height)
    {
        var pFileNameOrString = Marshal.StringToCoTaskMemUTF8(fileNameOrString);
        var result = LoadImageSvg((sbyte*)pFileNameOrString, width, height);
        Marshal.FreeCoTaskMem(pFileNameOrString);
        return result;
    }

    /// <inheritdoc cref="LoadImageAnim(sbyte*,int*)"/>
    public static Image LoadImageAnim(string fileName, out int frames)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Image result;
        fixed (int* pFrames = &frames)
        {
            result = LoadImageAnim((sbyte*)pFileName, pFrames);
        }
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadImageAnimFromMemory(sbyte*,byte*,int,int*)"/>
    public static Image LoadImageAnimFromMemory(string fileType, ReadOnlySpan<byte> fileData, out int frames)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
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

    /// <inheritdoc cref="LoadImageFromMemory(sbyte*,byte*,int)"/>
    public static Image LoadImageFromMemory(string fileType, ReadOnlySpan<byte> fileData)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Image result;
        fixed (byte* pFileData = fileData)
        {
            result = LoadImageFromMemory((sbyte*)pFileType, pFileData, fileData.Length);
        }
        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <inheritdoc cref="ExportImage(Image,sbyte*)"/>
    public static NativeBool ExportImage(Image image, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportImage(image, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="ExportImageToMemory(Image,sbyte*,int*)"/>
    public static byte* ExportImageToMemory(Image image, string fileType, out int fileSize)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        byte* result;
        fixed (int* pFileSize = &fileSize)
        {
            result = ExportImageToMemory(image, (sbyte*)pFileSize, pFileSize);
        }
        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <inheritdoc cref="ExportImageAsCode(Image,sbyte*)"/>
    public static NativeBool ExportImageAsCode(Image image, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportImageAsCode(image, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="GenImageText(int,int,sbyte*)"/>
    public static Image GenImageText(int width, int height, string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = GenImageText(width, height, (sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="ImageText(sbyte*,int,Color)"/>
    public static Image ImageText(string text, int fontSize, Color color)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = ImageText((sbyte*)pText, fontSize, color);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="ImageTextEx(Font,sbyte*,float,float,Color)"/>
    public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = ImageTextEx(font, (sbyte*)pText, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="ImageFormat(Image*,PixelFormat)"/>
    public static void ImageFormat(ref Image image, PixelFormat newFormat)
    {
        fixed (Image* pImage = &image) ImageFormat(pImage, newFormat);
    }

    /// <inheritdoc cref="ImageToPOT(Image*,Color)"/>
    public static void ImageToPOT(ref Image image, Color fill)
    {
        fixed (Image* pImage = &image) ImageToPOT(pImage, fill);
    }

    /// <inheritdoc cref="ImageCrop(Image*,Rectangle)"/>
    public static void ImageCrop(ref Image image, Rectangle crop)
    {
        fixed (Image* pImage = &image) ImageCrop(pImage, crop);
    }

    /// <inheritdoc cref="ImageAlphaCrop(Image*,float)"/>
    public static void ImageAlphaCrop(ref Image image, float threshold)
    {
        fixed (Image* pImage = &image) ImageAlphaCrop(pImage, threshold);
    }

    /// <inheritdoc cref="ImageAlphaClear(Image*,Color,float)"/>
    public static void ImageAlphaClear(ref Image image, Color color, float threshold)
    {
        fixed (Image* pImage = &image) ImageAlphaClear(pImage, color, threshold);
    }

    /// <inheritdoc cref="ImageAlphaMask(Image*,Image)"/>
    public static void ImageAlphaMask(ref Image image, Image alphaMask)
    {
        fixed (Image* pImage = &image) ImageAlphaMask(pImage, alphaMask);
    }

    /// <inheritdoc cref="ImageAlphaPremultiply(Image*)"/>
    public static void ImageAlphaPremultiply(ref Image image)
    {
        fixed (Image* pImage = &image) ImageAlphaPremultiply(pImage);
    }

    /// <inheritdoc cref="ImageBlurGaussian(Image*,int)"/>
    public static void ImageBlurGaussian(ref Image image, int blurSize)
    {
        fixed (Image* pImage = &image) ImageBlurGaussian(pImage, blurSize);
    }

    /// <inheritdoc cref="ImageKernelConvolution(Image*,float*,int)"/>
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

    /// <inheritdoc cref="ImageResize(Image*,int,int)"/>
    public static void ImageResize(ref Image image, int newWidth, int newHeight)
    {
        fixed (Image* pImage = &image) ImageResize(pImage, newWidth, newHeight);
    }

    /// <inheritdoc cref="ImageResizeNN(Image*,int,int)"/>
    public static void ImageResizeNN(ref Image image, int newWidth, int newHeight)
    {
        fixed (Image* pImage = &image) ImageResizeNN(pImage, newWidth, newHeight);
    }

    /// <inheritdoc cref="ImageResizeCanvas(Image*,int,int,int,int,Color)"/>
    public static void ImageResizeCanvas(ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
    {
        fixed (Image* pImage = &image) ImageResizeCanvas(pImage, newWidth, newHeight, offsetX, offsetY, fill);
    }

    /// <inheritdoc cref="ImageMipmaps(Image*)"/>
    public static void ImageMipmaps(ref Image image)
    {
        fixed (Image* pImage = &image) ImageMipmaps(pImage);
    }

    /// <inheritdoc cref="ImageDither(Image*,int,int,int,int)"/>
    public static void ImageDither(ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        fixed (Image* pImage = &image) ImageDither(pImage, rBpp, gBpp, bBpp, aBpp);
    }

    /// <inheritdoc cref="ImageFlipVertical(Image*)"/>
    public static void ImageFlipVertical(ref Image image)
    {
        fixed (Image* pImage = &image) ImageFlipVertical(pImage);
    }

    /// <inheritdoc cref="ImageFlipHorizontal(Image*)"/>
    public static void ImageFlipHorizontal(ref Image image)
    {
        fixed (Image* pImage = &image) ImageFlipHorizontal(pImage);
    }

    /// <inheritdoc cref="ImageRotate(Image*,int)"/>
    public static void ImageRotate(ref Image image, int degrees)
    {
        fixed (Image* pImage = &image) ImageRotate(pImage, degrees);
    }

    /// <inheritdoc cref="ImageRotateCW(Image*)"/>
    public static void ImageRotateCW(ref Image image)
    {
        fixed (Image* pImage = &image) ImageRotateCW(pImage);
    }

    /// <inheritdoc cref="ImageRotateCCW(Image*)"/>
    public static void ImageRotateCCW(ref Image image)
    {
        fixed (Image* pImage = &image) ImageRotateCCW(pImage);
    }

    /// <inheritdoc cref="ImageColorTint(Image*,Color)"/>
    public static void ImageColorTint(ref Image image, Color color)
    {
        fixed (Image* pImage = &image) ImageColorTint(pImage, color);
    }

    /// <inheritdoc cref="ImageColorInvert(Image*)"/>
    public static void ImageColorInvert(ref Image image)
    {
        fixed (Image* pImage = &image) ImageColorInvert(pImage);
    }

    /// <inheritdoc cref="ImageColorGrayscale(Image*)"/>
    public static void ImageColorGrayscale(ref Image image)
    {
        fixed (Image* pImage = &image) ImageColorGrayscale(pImage);
    }

    /// <inheritdoc cref="ImageColorContrast(Image*,float)"/>
    public static void ImageColorContrast(ref Image image, float contrast)
    {
        fixed (Image* pImage = &image) ImageColorContrast(pImage, contrast);
    }

    /// <inheritdoc cref="ImageColorBrightness(Image*,int)"/>
    public static void ImageColorBrightness(ref Image image, int brightness)
    {
        fixed (Image* pImage = &image) ImageColorBrightness(pImage, brightness);
    }

    /// <inheritdoc cref="ImageColorReplace(Image*,Color,Color)"/>
    public static void ImageColorReplace(ref Image image, Color color, Color replace)
    {
        fixed (Image* pImage = &image) ImageColorReplace(pImage, color, replace);
    }

    /// <inheritdoc cref="LoadImagePalette(Image,int,int*)"/>
    public static Color* LoadImagePalette(Image image, int maxPaletteSize, out int colorCount)
    {
        fixed (int* pColorCount = &colorCount)
        {
            return LoadImagePalette(image, maxPaletteSize, pColorCount);
        }
    }

    /// <inheritdoc cref="ImageClearBackground(Image*,Color)"/>
    public static void ImageClearBackground(ref Image image, Color color)
    {
        fixed (Image* pImage = &image) ImageClearBackground(pImage, color);
    }

    /// <inheritdoc cref="ImageDrawPixel(Image*,int,int,Color)"/>
    public static void ImageDrawPixel(ref Image dst, int posX, int posY, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawPixel(pDst, posX, posY, color);
    }

    /// <inheritdoc cref="ImageDrawPixelV(Image*,Vector2,Color)"/>
    public static void ImageDrawPixelV(ref Image dst, Vector2 position, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawPixelV(pDst, position, color);
    }

    /// <inheritdoc cref="ImageDrawLine(Image*,int,int,int,int,Color)"/>
    public static void ImageDrawLine(ref Image dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawLine(pDst, startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <inheritdoc cref="ImageDrawLineV(Image*,Vector2,Vector2,Color)"/>
    public static void ImageDrawLineV(ref Image dst, Vector2 start, Vector2 end, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawLineV(pDst, start, end, color);
    }

    /// <inheritdoc cref="ImageDrawLineEx(Image*,Vector2,Vector2,int,Color)"/>
    public static void ImageDrawLineEx(ref Image dst, Vector2 start, Vector2 end, int thick, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawLineEx(pDst, start, end, thick, color);
    }

    /// <inheritdoc cref="ImageDrawCircle(Image*,int,int,int,Color)"/>
    public static void ImageDrawCircle(ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawCircle(pDst, centerX, centerY, radius, color);
    }

    /// <inheritdoc cref="ImageDrawCircleV(Image*,Vector2,int,Color)"/>
    public static void ImageDrawCircleV(ref Image dst, Vector2 center, int radius, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawCircleV(pDst, center, radius, color);
    }

    /// <inheritdoc cref="ImageDrawCircleLines(Image*,int,int,int,Color)"/>
    public static void ImageDrawCircleLines(ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawCircleLines(pDst, centerX, centerY, radius, color);
    }

    /// <inheritdoc cref="ImageDrawCircleLinesV(Image*,Vector2,int,Color)"/>
    public static void ImageDrawCircleLinesV(ref Image dst, Vector2 center, int radius, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawCircleLinesV(pDst, center, radius, color);
    }

    /// <inheritdoc cref="ImageDrawRectangle(Image*,int,int,int,int,Color)"/>
    public static void ImageDrawRectangle(ref Image dst, int posX, int posY, int width, int height, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawRectangle(pDst, posX, posY, width, height, color);
    }

    /// <inheritdoc cref="ImageDrawRectangleV(Image*,Vector2,Vector2,Color)"/>
    public static void ImageDrawRectangleV(ref Image dst, Vector2 position, Vector2 size, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawRectangleV(pDst, position, size, color);
    }

    /// <inheritdoc cref="ImageDrawRectangleRec(Image*,Rectangle,Color)"/>
    public static void ImageDrawRectangleRec(ref Image dst, Rectangle rec, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawRectangleRec(pDst, rec, color);
    }

    /// <inheritdoc cref="ImageDrawRectangleLines(Image*,Rectangle,int,Color)"/>
    public static void ImageDrawRectangleLines(ref Image dst, Rectangle rec, int thick, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawRectangleLines(pDst, rec, thick, color);
    }

    /// <inheritdoc cref="ImageDrawTriangle(Image*,Vector2,Vector2,Vector2,Color)"/>
    public static void ImageDrawTriangle(ref Image dst, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawTriangle(pDst, v1, v2, v3, color);
    }

    /// <inheritdoc cref="ImageDrawTriangleEx(Image*,Vector2,Vector2,Vector2,Color,Color,Color)"/>
    public static void ImageDrawTriangleEx(ref Image dst, Vector2 v1, Vector2 v2, Vector2 v3, Color c1, Color c2, Color c3)
    {
        fixed (Image* pDst = &dst) ImageDrawTriangleEx(pDst, v1, v2, v3, c1, c2, c3);
    }

    /// <inheritdoc cref="ImageDrawTriangleLines(Image*,Vector2,Vector2,Vector2,Color)"/>
    public static void ImageDrawTriangleLines(ref Image dst, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        fixed (Image* pDst = &dst) ImageDrawTriangleLines(pDst, v1, v2, v3, color);
    }

    /// <inheritdoc cref="ImageDrawTriangleFan(Image*,Vector2*,int,Color)"/>
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

    /// <inheritdoc cref="ImageDrawTriangleStrip(Image*,Vector2*,int,Color)"/>
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

    /// <inheritdoc cref="ImageDraw(Image*,Image,Rectangle,Rectangle,Color)"/>
    public static void ImageDraw(ref Image dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
    {
        fixed (Image* pDst = &dst) ImageDraw(pDst, src, srcRec, dstRec, tint);
    }

    /// <inheritdoc cref="ImageDrawText(Image*,sbyte*,int,int,int,Color)"/>
    public static void ImageDrawText(ref Image dst, string text, int posX, int posY, int fontSize, Color color)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        fixed (Image* pDst = &dst) ImageDrawText(pDst, (sbyte*)pText, posX, posY, fontSize, color);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="ImageDrawTextEx(Image*,Font,sbyte*,Vector2,float,float,Color)"/>
    public static void ImageDrawTextEx(ref Image dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        fixed (Image* pDst = &dst) ImageDrawTextEx(pDst, font, (sbyte*)pText, position, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="LoadTexture(sbyte*)"/>
    public static Texture LoadTexture(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadTexture((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="UpdateTexture"/>
    public static void UpdateTexture<T>(Texture texture, ReadOnlySpan<T> pixels)
        where T : unmanaged
    {
        fixed (T* pPixels = pixels)
        {
            UpdateTexture(texture, pPixels);
        }
    }

    /// <inheritdoc cref="UpdateTextureRec"/>
    public static void UpdateTextureRec<T>(Texture texture, Rectangle rec, ReadOnlySpan<T> pixels)
        where T : unmanaged
    {
        fixed (T* pPixels = pixels)
        {
            UpdateTextureRec(texture, rec, pPixels);
        }
    }

    /// <inheritdoc cref="LoadFont(sbyte*)"/>
    public static Font LoadFont(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadFont((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadFontEx(sbyte*,int,int*,int)"/>
    public static Font LoadFontEx(string fileName, int fontSize, ReadOnlySpan<int> codepoints)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Font result;
        if (codepoints.IsEmpty)
        {
            result = LoadFontEx((sbyte*)pFileName, fontSize, null, 0);
        }
        else
        {
            fixed (int* pCodepoints = codepoints)
            {
                result = LoadFontEx((sbyte*)pFileName, fontSize, pCodepoints, codepoints.Length);
            }
        }
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadFontEx(sbyte*,int,int*,int)"/>
    public static Font LoadFontEx(string fileName, int fontSize, int codepointCount)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadFontEx((sbyte*)pFileName, fontSize, null, codepointCount);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadFontFromMemory(sbyte*,byte*,int,int,int*,int)"/>
    public static Font LoadFontFromMemory(string fileType, ReadOnlySpan<byte> fileData, int fontSize, ReadOnlySpan<int> codepoints)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Font result;
        fixed (byte* pFileData = fileData)
        {
            if (codepoints.IsEmpty)
            {
                result = LoadFontFromMemory((sbyte*)pFileType, pFileData, fileData.Length, fontSize, null, 0);
            }
            else
            {
                fixed (int* pCodepoints = codepoints)
                {
                    result = LoadFontFromMemory((sbyte*)pFileType, pFileData, fileData.Length, fontSize, pCodepoints, codepoints.Length);
                }
            }
        }
        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <inheritdoc cref="LoadFontFromMemory(sbyte*,byte*,int,int,int*,int)"/>
    public static Font LoadFontFromMemory(string fileType, ReadOnlySpan<byte> fileData, int fontSize, int codepointCount)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Font result;
        fixed (byte* pFileData = fileData)
        {
            result = LoadFontFromMemory((sbyte*)pFileType, pFileData, fileData.Length, fontSize, null, codepointCount);
        }
        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <inheritdoc cref="LoadFontData(byte*,int,int,int*,int,FontType)"/>
    public static GlyphInfo* LoadFontData(ReadOnlySpan<byte> fileData, int fontSize, ReadOnlySpan<int> codepoints, FontType type)
    {
        fixed (byte* pFileData = fileData)
        {
            if (codepoints.IsEmpty)
            {
                return LoadFontData(pFileData, fileData.Length, fontSize, null, 0, type);
            }

            fixed (int* pCodepoints = codepoints)
            {
                return LoadFontData(pFileData, fileData.Length, fontSize, pCodepoints, codepoints.Length, type);
            }
        }
    }

    /// <inheritdoc cref="LoadFontData(byte*,int,int,int*,int,FontType)"/>
    public static GlyphInfo* LoadFontData(ReadOnlySpan<byte> fileData, int fontSize, int codepointCount, FontType type)
    {
        fixed (byte* pFileData = fileData)
        {
            return LoadFontData(pFileData, fileData.Length, fontSize, null, codepointCount, type);
        }
    }

    /// <inheritdoc cref="GenImageFontAtlas(GlyphInfo*,Rectangle**,int,int,int,int)"/>
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
                var size = glyphs.Length * sizeof(GlyphInfo);
                Buffer.MemoryCopy(nativeGlyphRecs, pGlyphRecs, size, size);
            }

            MemFree(nativeGlyphRecs);
        }
        return result;
    }

    /// <inheritdoc cref="ExportFontAsCode(Font,sbyte*)"/>
    public static NativeBool ExportFontAsCode(Font font, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportFontAsCode(font, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="DrawText(sbyte*,int,int,int,Color)"/>
    public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        DrawText((sbyte*)pText, posX, posY, fontSize, color);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="DrawTextEx(Font,sbyte*,Vector2,float,float,Color)"/>
    public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        DrawTextEx(font, (sbyte*)pText, position, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="DrawTextPro(Font,sbyte*,Vector2,Vector2,float,float,float,Color)"/>
    public static void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        DrawTextPro(font, (sbyte*)pText, position, origin, rotation, fontSize, spacing, tint);
        Marshal.FreeCoTaskMem(pText);
    }

    /// <inheritdoc cref="DrawTextCodepoints(Font,int*,int,Vector2,float,float,Color)"/>
    public static void DrawTextCodepoints(Font font, ReadOnlySpan<int> codepoints, Vector2 position, float fontSize, float spacing, Color tint)
    {
        fixed (int* pCodepoints = codepoints)
        {
            DrawTextCodepoints(font, pCodepoints, codepoints.Length, position, fontSize, spacing, tint);
        }
    }

    /// <inheritdoc cref="MeasureText(sbyte*,int)"/>
    public static int MeasureText(string text, int fontSize)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = MeasureText((sbyte*)pText, fontSize);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="MeasureTextEx(Font,sbyte*,float,float)"/>
    public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = MeasureTextEx(font, (sbyte*)pText, fontSize, spacing);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="LoadUTF8(int*,int)"/>
    public static sbyte* LoadUTF8(ReadOnlySpan<int> codepoints)
    {
        fixed (int* pCodepoints = codepoints)
        {
            return LoadUTF8(pCodepoints, codepoints.Length);
        }
    }

    /// <inheritdoc cref="LoadCodepoints(sbyte*,int*)"/>
    public static int* LoadCodepoints(string text, out int count)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        int* result;
        fixed (int* pCount = &count)
        {
            result = LoadCodepoints((sbyte*)pText, pCount);
        }
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="GetCodepointCount(sbyte*)"/>
    public static int GetCodepointCount(string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = GetCodepointCount((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="GetCodepoint(sbyte*,int*)"/>
    public static int GetCodepoint(string text, out int codepointSize)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        int result;
        fixed (int* pCodepointSize = &codepointSize)
        {
            result = GetCodepoint((sbyte*)pText, pCodepointSize);
        }
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="GetCodepointNext(sbyte*,int*)"/>
    public static int GetCodepointNext(string text, out int codepointSize)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        int result;
        fixed (int* pCodepointSize = &codepointSize)
        {
            result = GetCodepointNext((sbyte*)pText, pCodepointSize);
        }
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="GetCodepointPrevious(sbyte*,int*)"/>
    public static int GetCodepointPrevious(string text, out int codepointSize)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        int result;
        fixed (int* pCodepointSize = &codepointSize)
        {
            result = GetCodepointPrevious((sbyte*)pText, pCodepointSize);
        }
        Marshal.FreeCoTaskMem(pText);
        return result;
    }

    /// <inheritdoc cref="CodepointToUTF8(int,int*)"/>
    public static string CodepointToUTF8(int codepoint)
    {
        int utf8Size;
        return Marshal.PtrToStringUTF8((nint)CodepointToUTF8(codepoint, &utf8Size), utf8Size) ?? string.Empty;
    }

    /// <inheritdoc cref="TextToPascal(sbyte*)"/>
    public static string TextToPascal(string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = TextToPascal((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="TextToSnake(sbyte*)"/>
    public static string TextToSnake(string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = TextToSnake((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="TextToCamel(sbyte*)"/>
    public static string TextToCamel(string text)
    {
        var pText = Marshal.StringToCoTaskMemUTF8(text);
        var result = TextToCamel((sbyte*)pText);
        Marshal.FreeCoTaskMem(pText);
        return Marshal.PtrToStringUTF8((nint)result) ?? string.Empty;
    }

    /// <inheritdoc cref="DrawTriangleStrip3D(Vector3*,int,Color)"/>
    public static void DrawTriangleStrip3D(ReadOnlySpan<Vector3> points, Color color)
    {
        fixed (Vector3* pPoints = points)
        {
            DrawTriangleStrip3D(pPoints, points.Length, color);
        }
    }

    /// <inheritdoc cref="LoadModel(sbyte*)"/>
    public static Model LoadModel(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadModel((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="UploadMesh(Mesh*,NativeBool)"/>
    public static void UploadMesh(ref Mesh mesh, NativeBool @dynamic)
    {
        fixed (Mesh* pMesh = &mesh)
        {
            UploadMesh(pMesh, @dynamic);
        }
    }

    /// <inheritdoc cref="UpdateMeshBuffer"/>
    public static void UpdateMeshBuffer<T>(Mesh mesh, int index, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateMeshBuffer(mesh, index, pData, data.Length, offset);
        }
    }

    /// <inheritdoc cref="DrawMeshInstanced(Mesh,Material,Matrix4x4*,int)"/>
    public static void DrawMeshInstanced(Mesh mesh, Material material, ReadOnlySpan<Matrix4x4> transforms)
    {
        fixed (Matrix4x4* pTransforms = transforms)
        {
            DrawMeshInstanced(mesh, material, pTransforms, transforms.Length);
        }
    }

    /// <inheritdoc cref="GenMeshTangents(Mesh*)"/>
    public static void GenMeshTangents(ref Mesh mesh)
    {
        fixed (Mesh* pMesh = &mesh)
        {
            GenMeshTangents(pMesh);
        }
    }

    /// <inheritdoc cref="ExportMesh(Mesh,sbyte*)"/>
    public static NativeBool ExportMesh(Mesh mesh, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportMesh(mesh, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="ExportMeshAsCode(Mesh,sbyte*)"/>
    public static NativeBool ExportMeshAsCode(Mesh mesh, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportMeshAsCode(mesh, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadMaterials(sbyte*,int*)"/>
    public static Material* LoadMaterials(string fileName, out int materialCount)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        Material* result;
        fixed (int* pMaterialCount = &materialCount)
        {
            result = LoadMaterials((sbyte*)pFileName, pMaterialCount); 
        }
        Marshal.FreeCoTaskMem(pFileName);

        return result;
    }

    /// <inheritdoc cref="SetMaterialTexture(Material*,MaterialMapIndex,Texture)"/>
    public static void SetMaterialTexture(ref Material material, MaterialMapIndex mapType, Texture texture)
    {
        fixed (Material* pMaterial = &material)
        {
            SetMaterialTexture(pMaterial, mapType, texture);
        }
    }

    /// <inheritdoc cref="SetModelMeshMaterial(Model*,int,int)"/>
    public static void SetModelMeshMaterial(ref Model model, int meshId, int materialId)
    {
        fixed (Model* pModel = &model)
        {
            SetModelMeshMaterial(pModel, meshId, materialId);
        }
    }

    /// <inheritdoc cref="LoadModelAnimations(sbyte*,int*)"/>
    public static ModelAnimation* LoadModelAnimations(string fileName, out int animCount)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        ModelAnimation* result;
        fixed (int* pAnimCount = &animCount)
        {
            result = LoadModelAnimations((sbyte*)pFileName, pAnimCount);
        }
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadWave(sbyte*)"/>
    public static Wave LoadWave(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadWave((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadWaveFromMemory(sbyte*,byte*,int)"/>
    public static Wave LoadWaveFromMemory(string fileType, ReadOnlySpan<byte> fileData)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Wave result;
        fixed (byte* pFileData = fileData)
        {
            result = LoadWaveFromMemory((sbyte*)pFileType, pFileData, fileData.Length);
        }
        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <inheritdoc cref="LoadSound(sbyte*)"/>
    public static Sound LoadSound(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadSound((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="UpdateSound"/>
    public static void UpdateSound<T>(Sound sound, ReadOnlySpan<T> data, int sampleCount)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateSound(sound, pData, sampleCount);
        }
    }

    /// <inheritdoc cref="ExportWave(Wave,sbyte*)"/>
    public static NativeBool ExportWave(Wave wave, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportWave(wave, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="ExportWaveAsCode(Wave,sbyte*)"/>
    public static NativeBool ExportWaveAsCode(Wave wave, string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = ExportWaveAsCode(wave, (sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="WaveCrop(Wave*,int,int)"/>
    public static void WaveCrop(ref Wave wave, int initFrame, int finalFrame)
    {
        fixed (Wave* pWave = &wave)
        {
            WaveCrop(pWave, initFrame, finalFrame);
        }
    }

    /// <inheritdoc cref="WaveFormat(Wave*,int,int,int)"/>
    public static void WaveFormat(ref Wave wave, int sampleRate, int sampleSize, int channels)
    {
        fixed (Wave* pWave = &wave)
        {
            WaveFormat(pWave, sampleRate, sampleSize, channels);
        }
    }

    /// <inheritdoc cref="LoadMusicStream(sbyte*)"/>
    public static Music LoadMusicStream(string fileName)
    {
        var pFileName = Marshal.StringToCoTaskMemUTF8(fileName);
        var result = LoadMusicStream((sbyte*)pFileName);
        Marshal.FreeCoTaskMem(pFileName);
        return result;
    }

    /// <inheritdoc cref="LoadMusicStreamFromMemory(sbyte*,byte*,int)"/>
    public static Music LoadMusicStreamFromMemory(string fileType, ReadOnlySpan<byte> data)
    {
        var pFileType = Marshal.StringToCoTaskMemUTF8(fileType);
        Music result;
        fixed (byte* pData = data)
        {
            result = LoadMusicStreamFromMemory((sbyte*)pFileType, pData, data.Length);
        }
        Marshal.FreeCoTaskMem(pFileType);
        return result;
    }

    /// <inheritdoc cref="UpdateAudioStream"/>
    public static void UpdateAudioStream<T>(AudioStream stream, ReadOnlySpan<T> data, int frameCount)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateAudioStream(stream, pData, frameCount);
        }
    }
}