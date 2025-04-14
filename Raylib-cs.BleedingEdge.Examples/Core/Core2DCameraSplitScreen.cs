/*******************************************************************************************
 *
 *   raylib [core] example - 2d camera split screen
 *
 *   Example complexity rating: [★★★★] 4/4
 *
 *   Addapted from the core_3d_camera_split_screen example:
 *       https://github.com/raysan5/raylib/blob/master/examples/core/core_3d_camera_split_screen.c
 *
 *   Example originally created with raylib 4.5, last time updated with raylib 4.5
 *
 *   Example contributed by Gabriel dos Santos Sanches (@gabrielssanches) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2023-2025 Gabriel dos Santos Sanches (@gabrielssanches)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core2DCameraSplitScreen
{
    private const int PlayerSize = 40;

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 440;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera split screen");

        var player1 = new Rectangle(200, 200, PlayerSize, PlayerSize);
        var player2 = new Rectangle(250, 200, PlayerSize, PlayerSize);

        var camera1 = new Camera2D
        {
            Target = new Vector2(player1.X, player1.Y),
            Offset = new Vector2(200.0f, 200.0f),
            Rotation = 0.0f,
            Zoom = 1.0f
        };

        var camera2 = new Camera2D
        {
            Target = new Vector2(player2.X, player2.Y),
            Offset = new Vector2(200.0f, 200.0f),
            Rotation = 0.0f,
            Zoom = 1.0f
        };

        var screenCamera1 = LoadRenderTexture(screenWidth / 2, screenHeight);
        var screenCamera2 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Build a flipped rectangle the size of the split view to use for drawing later
        var splitScreenRect = new Rectangle(0.0f, 0.0f, screenCamera1.Texture.Width, -screenCamera1.Texture.Height);

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyDown(KeyboardKey.S)) player1.Y += 3.0f;
            else if (IsKeyDown(KeyboardKey.W)) player1.Y -= 3.0f;
            if (IsKeyDown(KeyboardKey.D)) player1.X += 3.0f;
            else if (IsKeyDown(KeyboardKey.A)) player1.X -= 3.0f;

            if (IsKeyDown(KeyboardKey.Up)) player2.Y -= 3.0f;
            else if (IsKeyDown(KeyboardKey.Down)) player2.Y += 3.0f;
            if (IsKeyDown(KeyboardKey.Right)) player2.X += 3.0f;
            else if (IsKeyDown(KeyboardKey.Left)) player2.X -= 3.0f;

            camera1.Target = player1.Position;
            camera2.Target = player2.Position;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginTextureMode(screenCamera1);
            ClearBackground(Color.RayWhite);

            BeginMode2D(camera1);

            // Draw full scene with first camera
            for (var i = 0; i < screenWidth / PlayerSize + 1; i++)
            {
                DrawLineV(new Vector2((float)PlayerSize * i, 0), new Vector2((float)PlayerSize * i, screenHeight),
                    Color.LightGray);
            }

            for (var i = 0; i < screenHeight / PlayerSize + 1; i++)
            {
                DrawLineV(new Vector2(0, (float)PlayerSize * i), new Vector2(screenWidth, (float)PlayerSize * i),
                    Color.LightGray);
            }

            for (var i = 0; i < screenWidth / PlayerSize; i++)
            {
                for (var j = 0; j < screenHeight / PlayerSize; j++)
                {
                    DrawText($"[{i} {j}]", 10 + PlayerSize * i, 15 + PlayerSize * j, 10, Color.LightGray);
                }
            }

            DrawRectangleRec(player1, Color.Red);
            DrawRectangleRec(player2, Color.Blue);
            EndMode2D();

            DrawRectangle(0, 0, GetScreenWidth() / 2, 30, ColorAlpha(Color.RayWhite, 0.6f));
            DrawText("PLAYER1: W/S/A/D to move", 10, 10, 10, Color.Maroon);

            EndTextureMode();

            BeginTextureMode(screenCamera2);
            ClearBackground(Color.RayWhite);

            BeginMode2D(camera2);

            // Draw full scene with second camera
            for (var i = 0; i < screenWidth / PlayerSize + 1; i++)
            {
                DrawLineV(new Vector2((float)PlayerSize * i, 0), new Vector2((float)PlayerSize * i, screenHeight),
                    Color.LightGray);
            }

            for (var i = 0; i < screenHeight / PlayerSize + 1; i++)
            {
                DrawLineV(new Vector2(0, (float)PlayerSize * i), new Vector2(screenWidth, (float)PlayerSize * i),
                    Color.LightGray);
            }

            for (var i = 0; i < screenWidth / PlayerSize; i++)
            {
                for (var j = 0; j < screenHeight / PlayerSize; j++)
                {
                    DrawText($"[{i} {j}]", 10 + PlayerSize * i, 15 + PlayerSize * j, 10, Color.LightGray);
                }
            }

            DrawRectangleRec(player1, Color.Red);
            DrawRectangleRec(player2, Color.Blue);

            EndMode2D();

            DrawRectangle(0, 0, GetScreenWidth() / 2, 30, ColorAlpha(Color.RayWhite, 0.6f));
            DrawText("PLAYER2: UP/DOWN/LEFT/RIGHT to move", 10, 10, 10, Color.DarkBlue);

            EndTextureMode();

            // Draw both views render textures to the screen side by side
            BeginDrawing();
            ClearBackground(Color.Black);

            DrawTextureRec(screenCamera1.Texture, splitScreenRect, new Vector2(0, 0), Color.White);
            DrawTextureRec(screenCamera2.Texture, splitScreenRect, new Vector2(screenWidth / 2.0f, 0), Color.White);

            DrawRectangle(GetScreenWidth() / 2 - 2, 0, 4, GetScreenHeight(), Color.LightGray);
            EndDrawing();
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadRenderTexture(screenCamera1); // Unload render texture
        UnloadRenderTexture(screenCamera2); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}