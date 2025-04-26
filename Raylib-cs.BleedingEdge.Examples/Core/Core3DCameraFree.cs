/*******************************************************************************************
 *
 *   raylib [core] example - Initialize 3d camera free
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 *
 *   Example originally created with raylib 1.3, last time updated with raylib 1.3
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2015-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core3DCameraFree : IExample
{
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D
        {
            Position = new Vector3(10.0f, 10.0f, 10.0f), // Camera position
            Target = new Vector3(0.0f, 0.0f, 0.0f), // Camera looking at point
            Up = Vector3.UnitY, // Camera up vector (rotation towards target)
            FovY = 45.0f, // Camera field-of-view Y
            Projection = CameraProjection.Perspective // Camera projection type
        };

        Vector3 cubePosition = new Vector3(0.0f, 0.0f, 0.0f);

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.Free);

            if (IsKeyPressed(KeyboardKey.Z)) camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.Red);
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.Maroon);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawRectangle(10, 10, 320, 93, ColorAlpha(Color.SkyBlue, 0.5f));
            DrawRectangleLines(10, 10, 320, 93, Color.Blue);

            DrawText("Free camera default controls:", 20, 20, 10, Color.Black);
            DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10, Color.DarkGray);
            DrawText("- Mouse Wheel Pressed to Pan", 40, 60, 10, Color.DarkGray);
            DrawText("- Z to zoom to (0, 0, 0)", 40, 80, 10, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}