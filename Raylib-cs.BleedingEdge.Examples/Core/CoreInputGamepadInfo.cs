/*******************************************************************************************
 *
 *   raylib [core] example - Gamepad information
 *
 *   NOTE: This example requires a Gamepad connected to the system
 *         Check raylib.h for buttons configuration
 *
 *   Example originally created with raylib 4.6, last time updated with raylib 4.6
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2013-2024 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreInputGamepadInfo
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

        SetConfigFlags(ConfigFlags.Msaa4XHint); // Set MSAA 4X hint before windows creation

        InitWindow(screenWidth, screenHeight, "raylib [core] example - gamepad information");

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            for (int i = 0, y = 5; i < 4; i++) // MAX_GAMEPADS = 4
            {
                if (IsGamepadAvailable(i))
                {
                    DrawText($"Gamepad name: {GetGamepadNameString(i)}", 10, y, 10, Color.Black);
                    y += 11;
                    DrawText($"\tAxis count:   {GetGamepadAxisCount(i)}", 10, y, 10, Color.Black);
                    y += 11;

                    for (var axis = 0; axis < GetGamepadAxisCount(i); axis++)
                    {
                        DrawText($"\tAxis {axis} = {GetGamepadAxisMovement(i, (GamepadAxis)axis)}", 10, y, 10, Color.Black);
                        y += 11;
                    }

                    for (var button = 0; button < 32; button++)
                    {
                        DrawText($"\tButton {button} = {IsGamepadButtonDown(i, (GamepadButton)button)}", 10, y, 10, Color.Black);
                        y += 11;
                    }
                }
            }

            DrawFPS(GetScreenWidth() - 100, 100);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}