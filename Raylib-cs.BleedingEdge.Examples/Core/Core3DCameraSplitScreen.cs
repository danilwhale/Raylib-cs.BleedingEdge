/*******************************************************************************************
 *
 *   raylib [core] example - 3d cmaera split screen
 *
 *   Example originally created with raylib 3.7, last time updated with raylib 4.0
 *
 *   Example contributed by Jeffery Myers (@JeffM2501) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2021-2024 Jeffery Myers (@JeffM2501)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core3DCameraSplitScreen
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera split screen");

        // Setup player 1 camera and screen
        var cameraPlayer1 = new Camera3D
        {
            FovY = 45.0f,
            Up = Vector3.UnitY,
            Target = new Vector3(0.0f, 1.0f, 0.0f),
            Position = new Vector3(0.0f, 1.0f, -3.0f)
        };

        var screenPlayer1 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Setup player two camera and screen
        var cameraPlayer2 = new Camera3D
        {
            FovY = 45.0f,
            Up = Vector3.UnitY,
            Target = new Vector3(0.0f, 3.0f, 0.0f),
            Position = new Vector3(0.0f, 3.0f, -3.0f)
        };

        var screenPlayer2 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Build a flipped rectangle the size of the split view to use for drawing later
        var splitScreenRect = new Rectangle(0.0f, 0.0f, screenPlayer1.Texture.Width, -screenPlayer1.Texture.Height);

        // Grid data
        var count = 5;
        var spacing = 4.0f;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // If anyone moves this frame, how far will they move based on the time since the last frame
            // this moves thigns at 10 world units per second, regardless of the actual FPS
            var offsetThisFrame = 10.0f * GetFrameTime();

            // Move Player1 forward and backwards (no turning)
            if (IsKeyDown(KeyboardKey.W))
            {
                cameraPlayer1.Position.Z += offsetThisFrame;
                cameraPlayer1.Target.Z += offsetThisFrame;
            }
            else if (IsKeyDown(KeyboardKey.S))
            {
                cameraPlayer1.Position.Z -= offsetThisFrame;
                cameraPlayer1.Target.Z -= offsetThisFrame;
            }

            // Move Player2 forward and backwards (no turning)
            if (IsKeyDown(KeyboardKey.Up))
            {
                cameraPlayer2.Position.X += offsetThisFrame;
                cameraPlayer2.Target.X += offsetThisFrame;
            }
            else if (IsKeyDown(KeyboardKey.Down))
            {
                cameraPlayer2.Position.X -= offsetThisFrame;
                cameraPlayer2.Target.X -= offsetThisFrame;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            // Draw Player1 view to the render texture
            BeginTextureMode(screenPlayer1);
            ClearBackground(Color.SkyBlue);

            BeginMode3D(cameraPlayer1);

            // Draw scene: grid of cube trees on a plane to make a "world"
            DrawPlane(new Vector3(0, 0, 0), new Vector2(50, 50), Color.Beige); // Simple world plane

            for (var x = -count * spacing; x <= count * spacing; x += spacing)
            {
                for (var z = -count * spacing; z <= count * spacing; z += spacing)
                {
                    DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1, Color.Lime);
                    DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f, Color.Brown);
                }
            }

            // Draw a cube at each player's Position
            DrawCube(cameraPlayer1.Position, 1, 1, 1, Color.Red);
            DrawCube(cameraPlayer2.Position, 1, 1, 1, Color.Blue);

            EndMode3D();

            DrawRectangle(0, 0, GetScreenWidth() / 2, 40, ColorAlpha(Color.RayWhite, 0.8f));
            DrawText("PLAYER1: W/S to move", 10, 10, 20, Color.Maroon);

            EndTextureMode();

            // Draw Player2 view to the render texture
            BeginTextureMode(screenPlayer2);
            ClearBackground(Color.SkyBlue);

            BeginMode3D(cameraPlayer2);

            // Draw scene: grid of cube trees on a plane to make a "world"
            DrawPlane(new Vector3(0, 0, 0), new Vector2(50, 50), Color.Beige); // Simple world plane

            for (var x = -count * spacing; x <= count * spacing; x += spacing)
            {
                for (var z = -count * spacing; z <= count * spacing; z += spacing)
                {
                    DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1, Color.Lime);
                    DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f, Color.Brown);
                }
            }

            // Draw a cube at each player's Position
            DrawCube(cameraPlayer1.Position, 1, 1, 1, Color.Red);
            DrawCube(cameraPlayer2.Position, 1, 1, 1, Color.Blue);

            EndMode3D();

            DrawRectangle(0, 0, GetScreenWidth() / 2, 40, ColorAlpha(Color.RayWhite, 0.8f));
            DrawText("PLAYER2: UP/DOWN to move", 10, 10, 20, Color.Maroon);

            EndTextureMode();

            // Draw both views render textures to the screen side by side
            BeginDrawing();
            ClearBackground(Color.Black);

            DrawTextureRec(screenPlayer1.Texture, splitScreenRect, new Vector2(0.0f, 0.0f), Color.White);
            DrawTextureRec(screenPlayer2.Texture, splitScreenRect, new Vector2(screenWidth / 2.0f, 0), Color.White);

            DrawRectangle(GetScreenWidth() / 2 - 2, 0, 4, GetScreenHeight(), Color.LightGray);
            EndDrawing();
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadRenderTexture(screenPlayer1); // Unload render texture
        UnloadRenderTexture(screenPlayer2); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}