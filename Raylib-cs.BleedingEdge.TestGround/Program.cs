using System.Numerics;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Types;
using static Raylib_cs.BleedingEdge.Raylib;

// example with camera spinning around the cube!!!
// soon cube will be rotated (when I implement rlgl) instead of the camera

unsafe
{
    fixed (byte* pTitle = "hello window"u8)
    {
        InitWindow(800, 540, (sbyte*)pTitle);
    }

    var camera = new Camera3D(Vector3.One, Vector3.Zero, 70.0f, CameraProjection.Perspective);
    
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
        
        DrawCube(Vector3.Zero, 1.0f, 1.0f, 1.0f, Color.Red);
        
        EndMode3D();
        
        EndDrawing();
    }
    
    CloseWindow();
}