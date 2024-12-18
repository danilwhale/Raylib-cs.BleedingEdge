/*******************************************************************************************
*
*   raylib [core] example - 2D Camera system
*
*   Example originally created with raylib 1.5, last time updated with raylib 3.0
*
*   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
*   BSD-like license that allows static linking with closed source software
*
*   Copyright (c) 2016-2024 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core2DCamera
{
    private const int MaxBuildings = 100;

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        var player = new Rectangle(400.0f, 280.0f, 40.0f, 40.0f);
        var buildings = new Rectangle[MaxBuildings];
        var buildColors = new Color[MaxBuildings];

        var spacing = 0;

        for (var i = 0; i < MaxBuildings; i++)
        {
            ref var building = ref buildings[i];
            building.Width = GetRandomValue(50, 200);
            building.Height = GetRandomValue(100, 800);
            building.Y = screenHeight - 130.0f - building.Height;
            building.X = -6000.0f + spacing;

            spacing += (int)building.Width;

            buildColors[i] = new Color((byte)GetRandomValue(200, 240), (byte)GetRandomValue(200, 240), (byte)GetRandomValue(200, 250));
        }

        var camera = new Camera2D
        {
            Target = new Vector2(player.X + 20.0f, player.Y + 20.0f),
            Offset = new Vector2(screenWidth / 2.0f, screenHeight / 2.0f),
            Rotation = 0.0f,
            Zoom = 1.0f
        };

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Player movement
            if (IsKeyDown(KeyboardKey.Right)) player.X += 2;
            else if (IsKeyDown(KeyboardKey.Left)) player.X -= 2;

            // Camera target follows player
            camera.Target = new Vector2(player.X + 20, player.Y + 20);

            // Camera rotation controls
            if (IsKeyDown(KeyboardKey.A)) camera.Rotation--;
            else if (IsKeyDown(KeyboardKey.S)) camera.Rotation++;

            // Limit camera rotation to 80 degrees (-40 to 40)
            if (camera.Rotation > 40) camera.Rotation = 40;
            else if (camera.Rotation < -40) camera.Rotation = -40;

            // Camera zoom controls
            camera.Zoom += GetMouseWheelMove() * 0.05f;

            if (camera.Zoom > 3.0f) camera.Zoom = 3.0f;
            else if (camera.Zoom < 0.1f) camera.Zoom = 0.1f;

            // Camera reset (zoom and rotation)
            if (IsKeyPressed(KeyboardKey.R))
            {
                camera.Zoom = 1.0f;
                camera.Rotation = 0.0f;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            BeginMode2D(camera);

            DrawRectangle(-6000, 320, 13000, 8000, Color.DarkGray);

            for (var i = 0; i < MaxBuildings; i++) DrawRectangleRec(buildings[i], buildColors[i]);

            DrawRectangleRec(player, Color.Red);

            DrawLine((int)camera.Target.X, -screenHeight * 10, (int)camera.Target.X, screenHeight * 10, Color.Green);
            DrawLine(-screenWidth * 10, (int)camera.Target.Y, screenWidth * 10, (int)camera.Target.Y, Color.Green);

            EndMode2D();

            DrawText("SCREEN AREA", 640, 10, 20, Color.Red);

            DrawRectangle(0, 0, screenWidth, 5, Color.Red);
            DrawRectangle(0, 5, 5, screenHeight - 10, Color.Red);
            DrawRectangle(screenWidth - 5, 5, 5, screenHeight - 10, Color.Red);
            DrawRectangle(0, screenHeight - 5, screenWidth, 5, Color.Red);

            DrawRectangle(10, 10, 250, 113, ColorAlpha(Color.SkyBlue, 0.5f));
            DrawRectangleLines(10, 10, 250, 113, Color.Blue);

            DrawText("Free 2d camera controls:", 20, 20, 10, Color.Black);
            DrawText("- Right/Left to move Offset", 40, 40, 10, Color.DarkGray);
            DrawText("- Mouse Wheel to Zoom in-out", 40, 60, 10, Color.DarkGray);
            DrawText("- A / S to Rotate", 40, 80, 10, Color.DarkGray);
            DrawText("- R to reset Zoom and Rotation", 40, 100, 10, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}