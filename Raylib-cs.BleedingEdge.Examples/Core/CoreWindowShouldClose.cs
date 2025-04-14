/*******************************************************************************************
 *
 *   raylib [core] example - Window should close
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 *
 *   Example originally created with raylib 4.2, last time updated with raylib 4.2
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2013-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreWindowShouldClose
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - window should close");

        SetExitKey(KeyboardKey.Null); // Disable KEY_ESCAPE to close window, X-button still works

        var exitWindowRequested = false; // Flag to request window to exit
        var exitWindow = false; // Flag to set window to exit

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!exitWindow)
        {
            // Update
            //----------------------------------------------------------------------------------
            // Detect if X-button or KEY_ESCAPE have been pressed to close window
            if (WindowShouldClose() || IsKeyPressed(KeyboardKey.Escape)) exitWindowRequested = true;

            if (exitWindowRequested)
            {
                // A request for close window has been issued, we can save data before closing
                // or just show a message asking for confirmation

                if (IsKeyPressed(KeyboardKey.Y)) exitWindow = true;
                else if (IsKeyPressed(KeyboardKey.N)) exitWindowRequested = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            if (exitWindowRequested)
            {
                DrawRectangle(0, 100, screenWidth, 200, Color.Black);
                DrawText("Are you sure you want to exit program? [Y/N]", 40, 180, 30, Color.White);
            }
            else DrawText("Try to close the window to get confirmation message!", 120, 200, 20, Color.LightGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}