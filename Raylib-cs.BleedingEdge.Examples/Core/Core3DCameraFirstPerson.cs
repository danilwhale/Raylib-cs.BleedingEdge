/*******************************************************************************************
*
*   raylib [core] example - 3d camera first person
*
*   Example originally created with raylib 1.3, last time updated with raylib 1.3
*
*   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
*   BSD-like license that allows static linking with closed source software
*
*   Copyright (c) 2015-2024 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core3DCameraFirstPerson
{
    private const int MaxColumns = 20;

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera first person");

        // Define the camera to look into our 3d world (position, target, up vector)
        var camera = new Camera3D
        {
            Position = new Vector3(0.0f, 2.0f, 4.0f), // Camera position
            Target = new Vector3(0.0f, 2.0f, 0.0f), // Camera looking at point
            Up = Vector3.UnitY, // Camera up vector (rotation towards target)
            FovY = 60.0f, // Camera field-of-view Y
            Projection = CameraProjection.Perspective // Camera projection type
        };

        var cameraMode = CameraMode.FirstPerson;

        // Generates some random columns
        var heights = new float[MaxColumns];
        var positions = new Vector3[MaxColumns];
        var colors = new Color[MaxColumns];

        for (var i = 0; i < MaxColumns; i++)
        {
            heights[i] = GetRandomValue(1, 12);
            positions[i] = new Vector3(GetRandomValue(-15, 15), heights[i] / 2.0f, GetRandomValue(-15, 15));
            colors[i] = new Color((byte)GetRandomValue(20, 255), (byte)GetRandomValue(10, 55), 30);
        }

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Switch camera mode
            if (IsKeyPressed(KeyboardKey.One))
            {
                cameraMode = CameraMode.Free;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.Two))
            {
                cameraMode = CameraMode.FirstPerson;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.Three))
            {
                cameraMode = CameraMode.ThirdPerson;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.Four))
            {
                cameraMode = CameraMode.Orbital;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            // Switch camera projection
            if (IsKeyPressed(KeyboardKey.P))
            {
                if (camera.Projection == CameraProjection.Perspective)
                {
                    // Create isometric view
                    cameraMode = CameraMode.ThirdPerson;
                    // Note: The target distance is related to the render distance in the orthographic projection
                    camera.Position = new Vector3(0.0f, 2.0f, -100.0f);
                    camera.Target = new Vector3(0.0f, 2.0f, 0.0f);
                    camera.Up = Vector3.UnitY;
                    camera.Projection = CameraProjection.Orthographic;
                    camera.FovY = 20.0f; // near plane width in CAMERA_ORTHOGRAPHIC
                    CameraYaw(ref camera, -135 * Deg2Rad, true);
                    CameraPitch(ref camera, -45 * Deg2Rad, true, true, false);
                }
                else if (camera.Projection == CameraProjection.Orthographic)
                {
                    // Reset to default view
                    cameraMode = CameraMode.ThirdPerson;
                    camera.Position = new Vector3(0.0f, 2.0f, 10.0f);
                    camera.Target = new Vector3(0.0f, 2.0f, 0.0f);
                    camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
                    camera.Projection = CameraProjection.Perspective;
                    camera.FovY = 60.0f;
                }
            }

            // Update camera computes movement internally depending on the camera mode
            // Some default standard keyboard/mouse inputs are hardcoded to simplify use
            // For advanced camera controls, it's recommended to compute camera movement manually
            UpdateCamera(ref camera, cameraMode); // Update camera

/*
        // Camera PRO usage example (EXPERIMENTAL)
        // This new camera function allows custom movement/rotation values to be directly provided
        // as input parameters, with this approach, rcamera module is internally independent of raylib inputs
        UpdateCameraPro(ref camera,
            new Vector3(
                (IsKeyDown(KeyboardKey.W) || IsKeyDown(KeyboardKey.Up)) * 0.1f -      // Move forward-backward
                (IsKeyDown(KeyboardKey.S) || IsKeyDown(KeyboardKey.Down)) * 0.1f,
                (IsKeyDown(KeyboardKey.D) || IsKeyDown(KeyboardKey.Right)) * 0.1f -   // Move right-left
                (IsKeyDown(KeyboardKey.A) || IsKeyDown(KeyboardKey.Left)) * 0.1f,
                0.0f                                                // Move up-down
            ),
            new Vector3(
                GetMouseDelta().X * 0.05f,                            // Rotation: yaw
                GetMouseDelta().Y * 0.05f,                            // Rotation: pitch
                0.0f                                                // Rotation: roll
            ),
            GetMouseWheelMove() * 2.0f);                              // Move to target (zoom)
*/
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            BeginMode3D(camera);

            DrawPlane(new Vector3(0.0f, 0.0f, 0.0f), new Vector2(32.0f, 32.0f), Color.LightGray); // Draw ground
            DrawCube(new Vector3(-16.0f, 2.5f, 0.0f), 1.0f, 5.0f, 32.0f, Color.Blue); // Draw a blue wall
            DrawCube(new Vector3(16.0f, 2.5f, 0.0f), 1.0f, 5.0f, 32.0f, Color.Lime); // Draw a green wall
            DrawCube(new Vector3(0.0f, 2.5f, 16.0f), 32.0f, 5.0f, 1.0f, Color.Gold); // Draw a yellow wall

            // Draw some cubes around
            for (var i = 0; i < MaxColumns; i++)
            {
                DrawCube(positions[i], 2.0f, heights[i], 2.0f, colors[i]);
                DrawCubeWires(positions[i], 2.0f, heights[i], 2.0f, Color.Maroon);
            }

            // Draw player cube
            if (cameraMode == CameraMode.ThirdPerson)
            {
                DrawCube(camera.Target, 0.5f, 0.5f, 0.5f, Color.Purple);
                DrawCubeWires(camera.Target, 0.5f, 0.5f, 0.5f, Color.DarkPurple);
            }

            EndMode3D();

            // Draw info boxes
            DrawRectangle(5, 5, 330, 100, ColorAlpha(Color.SkyBlue, 0.5f));
            DrawRectangleLines(5, 5, 330, 100, Color.Blue);

            DrawText("Camera controls:", 15, 15, 10, Color.Black);
            DrawText("- Move keys: W, A, S, D, Space, Left-Ctrl", 15, 30, 10, Color.Black);
            DrawText("- Look around: arrow keys or mouse", 15, 45, 10, Color.Black);
            DrawText("- Camera mode keys: 1, 2, 3, 4", 15, 60, 10, Color.Black);
            DrawText("- Zoom keys: num-plus, num-minus or mouse scroll", 15, 75, 10, Color.Black);
            DrawText("- Camera projection key: P", 15, 90, 10, Color.Black);

            DrawRectangle(600, 5, 195, 100, ColorAlpha(Color.SkyBlue, 0.5f));
            DrawRectangleLines(600, 5, 195, 100, Color.Blue);

            DrawText("Camera status:", 610, 15, 10, Color.Black);
            DrawText($"- Mode: {cameraMode}", 610, 30, 10, Color.Black);
            DrawText($"- Projection: {camera.Projection}", 610, 45, 10, Color.Black);
            DrawText($"- Position: {camera.Position:00.000}", 610, 60, 10, Color.Black);
            DrawText($"- Target: {camera.Target:00.000}", 610, 75, 10, Color.Black);
            DrawText($"- Up: {camera.Up:00.000}", 610, 90, 10, Color.Black);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------

    }
}