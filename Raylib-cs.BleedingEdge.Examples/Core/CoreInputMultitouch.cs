/*******************************************************************************************
 *
 *   raylib [core] example - Input multitouch
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 * 
 *   Example originally created with raylib 2.1, last time updated with raylib 2.5
 *
 *   Example contributed by Berni (@Berni8k) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2019-2025 Berni (@Berni8k) and Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreInputMultitouch : IExample
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input multitouch");

        Vector2[] touchPositions = new Vector2[10];

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Get the touch point count ( how many fingers are touching the screen )
            int tCount = GetTouchPointCount();
            // Clamp touch points available ( set the maximum touch points allowed )
            if (tCount > touchPositions.Length) tCount = touchPositions.Length;
            // Get touch points positions
            for (int i = 0; i < tCount; ++i) touchPositions[i] = GetTouchPosition(i);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            for (int i = 0; i < tCount; ++i)
            {
                // Make sure point is not (0, 0) as this means there is no touch for it
                if (touchPositions[i].X > 0 && touchPositions[i].Y > 0)
                {
                    // Draw circle and touch index number
                    DrawCircleV(touchPositions[i], 34, Color.Orange);
                    DrawText(i.ToString(), (int)touchPositions[i].X - 10, (int)touchPositions[i].Y - 70, 40, Color.Black);
                }
            }

            DrawText("touch the screen at multiple locations to get multiple balls", 10, 10, 20, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}