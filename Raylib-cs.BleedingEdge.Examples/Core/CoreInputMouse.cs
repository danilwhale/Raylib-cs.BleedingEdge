/*******************************************************************************************
 *
 *   raylib [core] example - Mouse input
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 *
 *   Example originally created with raylib 1.0, last time updated with raylib 5.5
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2014-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreInputMouse
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse input");

        var ballPosition = new Vector2(-100.0f, -100.0f);
        var ballColor = Color.DarkBlue;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            ballPosition = GetMousePosition();

            if (IsMouseButtonPressed(MouseButton.Left)) ballColor = Color.Maroon;
            else if (IsMouseButtonPressed(MouseButton.Middle)) ballColor = Color.Lime;
            else if (IsMouseButtonPressed(MouseButton.Right)) ballColor = Color.DarkBlue;
            else if (IsMouseButtonPressed(MouseButton.Side)) ballColor = Color.Purple;
            else if (IsMouseButtonPressed(MouseButton.Extra)) ballColor = Color.Yellow;
            else if (IsMouseButtonPressed(MouseButton.Forward)) ballColor = Color.Orange;
            else if (IsMouseButtonPressed(MouseButton.Back)) ballColor = Color.Beige;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            DrawCircleV(ballPosition, 40, ballColor);

            DrawText("move ball with mouse and click mouse button to change color", 10, 10, 20, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}