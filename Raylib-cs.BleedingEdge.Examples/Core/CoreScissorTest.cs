/*******************************************************************************************
 *
 *   raylib [core] example - Scissor test
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 *
 *   Example originally created with raylib 2.5, last time updated with raylib 3.0
 *
 *   Example contributed by Chris Dill (@MysteriousSpace) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2019-2025 Chris Dill (@MysteriousSpace)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreScissorTest
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - scissor test");

        var scissorArea = new Rectangle(0, 0, 300, 300);
        var scissorMode = true;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.S)) scissorMode = !scissorMode;

            // Centre the scissor area around the mouse position
            scissorArea.Position = GetMousePosition() - scissorArea.Size / 2;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            if (scissorMode) BeginScissorMode((int)scissorArea.X, (int)scissorArea.Y, (int)scissorArea.Width, (int)scissorArea.Height);

            // Draw full screen rectangle and some text
            // NOTE: Only part defined by scissor area will be rendered
            DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Color.Red);
            DrawText("Move the mouse around to reveal this text!", 190, 200, 20, Color.LightGray);

            if (scissorMode) EndScissorMode();

            DrawRectangleLinesEx(scissorArea, 1, Color.Black);
            DrawText("Press S to toggle scissor test", 10, 10, 20, Color.Black);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}