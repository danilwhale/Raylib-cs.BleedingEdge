using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge.Types;
using static Raylib_cs.BleedingEdge.Raylib;

// example with camera spinning around the cube!!!
// soon cube will be rotated (when I implement rlgl) instead of the camera

unsafe
{
    SetTraceLogCallback((level, text, args1) =>
    {
        Console.ForegroundColor = level switch
        {
            TraceLogLevel.Trace => ConsoleColor.DarkGray,
            TraceLogLevel.Debug => ConsoleColor.DarkYellow,
            TraceLogLevel.Info => ConsoleColor.Blue,
            TraceLogLevel.Warning => ConsoleColor.Yellow,
            TraceLogLevel.Error => ConsoleColor.Red,
            TraceLogLevel.Fatal => ConsoleColor.DarkRed,
            _ => ConsoleColor.Green
        };
        Console.WriteLine("[{0}] {1}", level.ToString(), NativeStringFormatter.Format((nint)text, args1));
        Console.ResetColor();
    });
    
    SetLoadFileDataCallback((name, size) =>
    {
        var strName = Marshal.PtrToStringUTF8((nint)name) ?? throw new Exception("failed to marshal file name");
        
        var bytes = File.ReadAllBytes(strName);
        *size = bytes.Length;

        var textHandle = Marshal.StringToCoTaskMemUTF8($"loaded {strName} using custom callback!");
        TraceLog(TraceLogLevel.Info, (sbyte*)textHandle);
        Marshal.FreeCoTaskMem(textHandle);
        
        var mem = (byte*)MemAlloc((uint)bytes.Length);

        fixed (byte* pBytes = bytes)
        {
            Buffer.MemoryCopy(pBytes, mem, *size, *size);
        }

        return mem;
    });
    
    fixed (byte* pTitle = "hello window"u8)
    {
        InitWindow(800, 540, (sbyte*)pTitle);
    }

    var camera = new Camera3D(Vector3.One, Vector3.Zero, 70.0f, CameraProjection.Perspective);
    var mesh = GenMeshCube(1.0f, 1.0f, 1.0f);
    var material = LoadMaterialDefault();

    fixed (byte* pFileName = "warning.png"u8)
    {
        SetMaterialTexture(&material, MaterialMapIndex.Albedo, LoadTexture((sbyte*)pFileName));
    }
    
    while (!WindowShouldClose())
    {
        // no rlgl yet, spin camera around the cube, instead of the cube itself
        CameraYaw(&camera, GetFrameTime(), true);
        CameraPitch(&camera, GetFrameTime() * 0.8f, false, true, true);
        CameraRoll(&camera, GetFrameTime() * 0.5f);
        
        BeginDrawing();
        ClearBackground(Color.SkyBlue);
        
        DrawFPS(0, 0);
        
        BeginMode3D(camera);
        
        DrawMesh(mesh, material, Matrix4x4.Transpose(Matrix4x4.Identity));
        
        EndMode3D();
        
        EndDrawing();
    }
    
    UnloadMaterial(material);
    UnloadMesh(mesh);
    
    CloseWindow();
}