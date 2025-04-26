/*******************************************************************************************
 *
 *   raylib [core] example - Picking in 3d mode
 *
 *   Example complexity rating: [★★☆☆] 2/4
 * 
 *   Example originally created with raylib 1.3, last time updated with raylib 4.0
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

public class Core3DPicking : IExample
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d picking");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D
        {
            Position = new Vector3(10.0f, 10.0f, 10.0f), // Camera position
            Target = new Vector3(0.0f, 0.0f, 0.0f), // Camera looking at point
            Up = new Vector3(0.0f, 1.0f, 0.0f), // Camera up vector (rotation towards target)
            FovY = 45.0f, // Camera field-of-view Y
            Projection = CameraProjection.Perspective // Camera projection type
        };

        Vector3 cubePosition = new Vector3(0.0f, 1.0f, 0.0f);
        Vector3 cubeSize = new Vector3(2.0f, 2.0f, 2.0f);

        Ray ray = new Ray(); // Picking line ray
        RayCollision collision = new RayCollision(); // Ray collision hit info

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsCursorHidden()) UpdateCamera(ref camera, CameraMode.FirstPerson);

            // Toggle camera controls
            if (IsMouseButtonPressed(MouseButton.Right))
            {
                if (IsCursorHidden()) EnableCursor();
                else DisableCursor();
            }

            if (IsMouseButtonPressed(MouseButton.Left))
            {
                if (!collision.Hit)
                {
                    ray = GetScreenToWorldRay(GetMousePosition(), camera);

                    // Check collision between ray and box
                    collision = GetRayCollisionBox(ray, new BoundingBox(cubePosition - cubeSize / 2, cubePosition + cubeSize / 2));
                }
                else collision.Hit = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            if (collision.Hit)
            {
                DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Red);
                DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Maroon);

                DrawCubeWires(cubePosition, cubeSize.X + 0.2f, cubeSize.Y + 0.2f, cubeSize.Z + 0.2f, Color.Green);
            }
            else
            {
                DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Gray);
                DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.DarkGray);
            }

            DrawRay(ray, Color.Maroon);
            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawText("Try clicking on the box with your mouse!", 240, 10, 20, Color.DarkGray);

            if (collision.Hit)
                DrawText("BOX SELECTED", (screenWidth - MeasureText("BOX SELECTED", 30)) / 2, (int)(screenHeight * 0.1f), 30, Color.Green);

            DrawText("Right click mouse to toggle camera controls", 10, 430, 10, Color.Gray);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}