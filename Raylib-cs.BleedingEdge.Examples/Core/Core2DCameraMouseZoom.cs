/*******************************************************************************************
*
*   raylib [core] example - 2d camera mouse zoom
*
*   Example originally created with raylib 4.2, last time updated with raylib 4.2
*
*   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
*   BSD-like license that allows static linking with closed source software
*
*   Copyright (c) 2022-2024 Jeffery Myers (@JeffM2501)
*
********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core2DCameraMouseZoom
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera mouse zoom");

        var camera = new Camera2D
        {
            Zoom = 1.0f
        };

        var zoomMode = 0; // 0-Mouse Wheel, 1-Mouse Move

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.One)) zoomMode = 0;
            else if (IsKeyPressed(KeyboardKey.Two)) zoomMode = 1;

            // Translate based on mouse right click
            if (IsMouseButtonDown(MouseButton.Left))
            {
                var delta = GetMouseDelta();
                delta *= -1.0f / camera.Zoom;
                camera.Target += delta;
            }

            if (zoomMode == 0)
            {
                // Zoom based on mouse wheel
                var wheel = GetMouseWheelMove();
                if (wheel != 0)
                {
                    // Get the world point that is under the mouse
                    var mouseWorldPos = GetScreenToWorld2D(GetMousePosition(), camera);

                    // Set the offset to where the mouse is
                    camera.Offset = GetMousePosition();

                    // Set the target to match, so that the camera maps the world space point 
                    // under the cursor to the screen space point under the cursor at any zoom
                    camera.Target = mouseWorldPos;

                    // Zoom increment
                    var scaleFactor = 1.0f + 0.25f * Math.Abs(wheel);
                    if (wheel < 0) scaleFactor = 1.0f / scaleFactor;
                    camera.Zoom = Math.Clamp(camera.Zoom * scaleFactor, 0.125f, 64.0f);
                }
            }
            else
            {
                // Zoom based on mouse right click
                if (IsMouseButtonPressed(MouseButton.Right))
                {
                    // Get the world point that is under the mouse
                    var mouseWorldPos = GetScreenToWorld2D(GetMousePosition(), camera);

                    // Set the offset to where the mouse is
                    camera.Offset = GetMousePosition();

                    // Set the target to match, so that the camera maps the world space point 
                    // under the cursor to the screen space point under the cursor at any zoom
                    camera.Target = mouseWorldPos;
                }

                if (IsMouseButtonDown(MouseButton.Right))
                {
                    // Zoom increment
                    var deltaX = GetMouseDelta().X;
                    var scaleFactor = 1.0f + 0.01f * Math.Abs(deltaX);
                    if (deltaX < 0) scaleFactor = 1.0f / scaleFactor;
                    camera.Zoom = Math.Clamp(camera.Zoom * scaleFactor, 0.125f, 64.0f);
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            BeginMode2D(camera);

            // Draw the 3d grid, rotated 90 degrees and centered around 0,0 
            // just so we have something in the XY plane
            Rlgl.PushMatrix();
            Rlgl.Translatef(0, 25 * 50, 0);
            Rlgl.Rotatef(90, 1, 0, 0);
            DrawGrid(100, 50);
            Rlgl.PopMatrix();

            // Draw a reference circle
            DrawCircle(GetScreenWidth() / 2, GetScreenHeight() / 2, 50, Color.Maroon);

            EndMode2D();

            // Draw mouse reference
            //Vector2 mousePos = GetWorldToScreen2D(GetMousePosition(), camera)
            DrawCircleV(GetMousePosition(), 4, Color.DarkGray);
            DrawTextEx(GetFontDefault(), $"[{GetMouseX()} {GetMouseY()}]",
                GetMousePosition() + new Vector2(-44, -24), 20, 2, Color.Black);

            DrawText("[1][2] Select mouse zoom mode (Wheel or Move)", 20, 20, 20, Color.DarkGray);
            if (zoomMode == 0) DrawText("Mouse left button drag to move, mouse wheel to zoom", 20, 50, 20, Color.DarkGray);
            else DrawText("Mouse left button drag to move, mouse press and move to zoom", 20, 50, 20, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}