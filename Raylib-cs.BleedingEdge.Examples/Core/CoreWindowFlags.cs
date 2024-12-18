/*******************************************************************************************
 *
 *   raylib [core] example - window flags
 *
 *   Example originally created with raylib 3.5, last time updated with raylib 3.5
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2020-2024 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreWindowFlags
{
    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //---------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Possible window flags
        /*
        ConfigFlags.VSyncHint
        ConfigFlags.FullscreenMode    -> not working properly -> wrong scaling!
        ConfigFlags.WindowResizable
        ConfigFlags.WindowUndecorated
        ConfigFlags.WindowTransparent
        ConfigFlags.WindowHidden
        ConfigFlags.WindowMinimized   -> Not supported on window creation
        ConfigFlags.WindowMaximized   -> Not supported on window creation
        ConfigFlags.WindowUnfocused
        ConfigFlags.WindowTopMost
        ConfigFlags.WindowHighDpi     -> errors after minimize-resize, fb size is recalculated
        ConfigFlags.WindowAlwaysRun
        ConfigFlags.Msaa4XHint
        */

        // Set configuration flags for window creation
        //SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.Msaa4XHint | ConfigFlags.WindowHighDpi);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - window flags");

        var ballPosition = new Vector2(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        var ballSpeed = new Vector2(5.0f, 4.0f);
        float ballRadius = 20;

        var framesCounter = 0;

        //SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
        //----------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //-----------------------------------------------------
            if (IsKeyPressed(KeyboardKey.F)) ToggleFullscreen(); // modifies window size when scaling!

            if (IsKeyPressed(KeyboardKey.R))
            {
                if (IsWindowState(ConfigFlags.WindowResizable)) ClearWindowState(ConfigFlags.WindowResizable);
                else SetWindowState(ConfigFlags.WindowResizable);
            }

            if (IsKeyPressed(KeyboardKey.D))
            {
                if (IsWindowState(ConfigFlags.WindowUndecorated)) ClearWindowState(ConfigFlags.WindowUndecorated);
                else SetWindowState(ConfigFlags.WindowUndecorated);
            }

            if (IsKeyPressed(KeyboardKey.H))
            {
                if (!IsWindowState(ConfigFlags.WindowHidden)) SetWindowState(ConfigFlags.WindowHidden);

                framesCounter = 0;
            }

            if (IsWindowState(ConfigFlags.WindowHidden))
            {
                framesCounter++;
                if (framesCounter >= 240) ClearWindowState(ConfigFlags.WindowHidden); // Show window after 3 seconds
            }

            if (IsKeyPressed(KeyboardKey.N))
            {
                if (!IsWindowState(ConfigFlags.WindowMinimized)) MinimizeWindow();

                framesCounter = 0;
            }

            if (IsWindowState(ConfigFlags.WindowMinimized))
            {
                framesCounter++;
                if (framesCounter >= 240) RestoreWindow(); // Restore window after 3 seconds
            }

            if (IsKeyPressed(KeyboardKey.M))
            {
                // NOTE: Requires ConfigFlags.WindowResizable enabled!
                if (IsWindowState(ConfigFlags.WindowMaximized)) RestoreWindow();
                else MaximizeWindow();
            }

            if (IsKeyPressed(KeyboardKey.U))
            {
                if (IsWindowState(ConfigFlags.WindowUnfocused)) ClearWindowState(ConfigFlags.WindowUnfocused);
                else SetWindowState(ConfigFlags.WindowUnfocused);
            }

            if (IsKeyPressed(KeyboardKey.T))
            {
                if (IsWindowState(ConfigFlags.WindowTopMost)) ClearWindowState(ConfigFlags.WindowTopMost);
                else SetWindowState(ConfigFlags.WindowTopMost);
            }

            if (IsKeyPressed(KeyboardKey.A))
            {
                if (IsWindowState(ConfigFlags.WindowAlwaysRun)) ClearWindowState(ConfigFlags.WindowAlwaysRun);
                else SetWindowState(ConfigFlags.WindowAlwaysRun);
            }

            if (IsKeyPressed(KeyboardKey.V))
            {
                if (IsWindowState(ConfigFlags.VSyncHint)) ClearWindowState(ConfigFlags.VSyncHint);
                else SetWindowState(ConfigFlags.VSyncHint);
            }

            // Bouncing ball logic
            ballPosition.X += ballSpeed.X;
            ballPosition.Y += ballSpeed.Y;
            if (ballPosition.X >= GetScreenWidth() - ballRadius || ballPosition.X <= ballRadius) ballSpeed.X *= -1.0f;
            if (ballPosition.Y >= GetScreenHeight() - ballRadius || ballPosition.Y <= ballRadius) ballSpeed.Y *= -1.0f;
            //-----------------------------------------------------

            // Draw
            //-----------------------------------------------------
            BeginDrawing();

            if (IsWindowState(ConfigFlags.WindowTransparent)) ClearBackground(Color.Blank);
            else ClearBackground(Color.RayWhite);

            DrawCircleV(ballPosition, ballRadius, Color.Maroon);
            DrawRectangleLinesEx(new Rectangle(0, 0, GetScreenWidth(), GetScreenHeight()), 4, Color.RayWhite);

            DrawCircleV(GetMousePosition(), 10, Color.DarkBlue);

            DrawFPS(10, 10);

            DrawText($"Screen Size: [{GetScreenWidth()}, {GetScreenHeight()}]", 10, 40, 10, Color.Green);

            // Draw window state info
            DrawText("Following flags can be set after window creation:", 10, 60, 10, Color.Gray);
            if (IsWindowState(ConfigFlags.FullscreenMode)) DrawText("[F] ConfigFlags.FullscreenMode: on", 10, 80, 10, Color.Lime);
            else DrawText("[F] ConfigFlags.FullscreenMode: off", 10, 80, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowResizable)) DrawText("[R] ConfigFlags.WindowResizable: on", 10, 100, 10, Color.Lime);
            else DrawText("[R] ConfigFlags.WindowResizable: off", 10, 100, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowUndecorated)) DrawText("[D] ConfigFlags.WindowUndecorated: on", 10, 120, 10, Color.Lime);
            else DrawText("[D] ConfigFlags.WindowUndecorated: off", 10, 120, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowHidden)) DrawText("[H] ConfigFlags.WindowHidden: on", 10, 140, 10, Color.Lime);
            else DrawText("[H] ConfigFlags.WindowHidden: off", 10, 140, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowMinimized)) DrawText("[N] ConfigFlags.WindowMinimized: on", 10, 160, 10, Color.Lime);
            else DrawText("[N] ConfigFlags.WindowMinimized: off", 10, 160, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowMaximized)) DrawText("[M] ConfigFlags.WindowMaximized: on", 10, 180, 10, Color.Lime);
            else DrawText("[M] ConfigFlags.WindowMaximized: off", 10, 180, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowUnfocused)) DrawText("[G] ConfigFlags.WindowUnfocused: on", 10, 200, 10, Color.Lime);
            else DrawText("[U] ConfigFlags.WindowUnfocused: off", 10, 200, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowTopMost)) DrawText("[T] ConfigFlags.WindowTopMost: on", 10, 220, 10, Color.Lime);
            else DrawText("[T] ConfigFlags.WindowTopMost: off", 10, 220, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowAlwaysRun)) DrawText("[A] ConfigFlags.WindowAlwaysRun: on", 10, 240, 10, Color.Lime);
            else DrawText("[A] ConfigFlags.WindowAlwaysRun: off", 10, 240, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.VSyncHint)) DrawText("[V] ConfigFlags.VSyncHint: on", 10, 260, 10, Color.Lime);
            else DrawText("[V] ConfigFlags.VSyncHint: off", 10, 260, 10, Color.Maroon);

            DrawText("Following flags can only be set before window creation:", 10, 300, 10, Color.Gray);
            if (IsWindowState(ConfigFlags.WindowHighDpi)) DrawText("ConfigFlags.WindowHighDpi: on", 10, 320, 10, Color.Lime);
            else DrawText("ConfigFlags.WindowHighDpi: off", 10, 320, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.WindowTransparent)) DrawText("ConfigFlags.WindowTransparent: on", 10, 340, 10, Color.Lime);
            else DrawText("ConfigFlags.WindowTransparent: off", 10, 340, 10, Color.Maroon);
            if (IsWindowState(ConfigFlags.Msaa4XHint)) DrawText("ConfigFlags.Msaa4XHint: on", 10, 360, 10, Color.Lime);
            else DrawText("ConfigFlags.Msaa4XHint: off", 10, 360, 10, Color.Maroon);

            EndDrawing();
            //-----------------------------------------------------
        }

        // De-Initialization
        //---------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //----------------------------------------------------------
    }
}