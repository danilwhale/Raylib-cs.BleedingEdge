/*******************************************************************************************
 *
 *   raylib [core] example - World to screen
 *
 *   Example complexity rating: [★★☆☆] 2/4
 *
 *   Example originally created with raylib 1.3, last time updated with raylib 1.4
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

public class CoreWorldScreen
{
    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - core world screen");

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
        Vector2 cubeScreenPosition = new Vector2(0.0f, 0.0f);

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(ref camera, CameraMode.ThirdPerson);

            // Calculate cube screen space position (with a little offset to be in top)
            cubeScreenPosition = GetWorldToScreen(new Vector3(cubePosition.X, cubePosition.Y + 2.5f, cubePosition.Z), camera);
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

            DrawText("Enemy: 100 / 100", (int)cubeScreenPosition.X - MeasureText("Enemy: 100/100", 20) / 2, (int)cubeScreenPosition.Y, 20, Color.Black);

            DrawText($"Cube position in screen space coordinates: [{(int)cubeScreenPosition.X}, {(int)cubeScreenPosition.Y}]", 10,
                10, 20, Color.Lime);
            DrawText("Text 2d should be always on top of the cube", 10, 40, 20, Color.Gray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}