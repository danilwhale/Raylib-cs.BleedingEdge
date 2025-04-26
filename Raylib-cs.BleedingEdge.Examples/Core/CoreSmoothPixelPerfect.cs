/*******************************************************************************************
 *
 *   raylib [core] example - Smooth Pixel-perfect camera
 *
 *   Example complexity rating: [★★★☆] 3/4
 *
 *   Example originally created with raylib 3.7, last time updated with raylib 4.0
 *
 *   Example contributed by Giancamillo Alessandroni (@NotManyIdeasDev) and
 *   reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2021-2025 Giancamillo Alessandroni (@NotManyIdeasDev) and Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreSmoothPixelPerfect : IExample
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

        const int virtualScreenWidth = 160;
        const int virtualScreenHeight = 90;

        const float virtualRatio = screenWidth / (float)virtualScreenWidth;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - smooth pixel-perfect camera");

        Camera2D worldSpaceCamera = new Camera2D
        {
            Zoom = 1.0f
        }; // Game world camera

        Camera2D screenSpaceCamera = new Camera2D
        {
            Zoom = 1.0f
        }; // Smoothing camera

        RenderTexture2D target = LoadRenderTexture(virtualScreenWidth, virtualScreenHeight); // This is where we'll draw all our objects.

        Rectangle rec01 = new Rectangle(70.0f, 35.0f, 20.0f, 20.0f);
        Rectangle rec02 = new Rectangle(90.0f, 55.0f, 30.0f, 10.0f);
        Rectangle rec03 = new Rectangle(80.0f, 65.0f, 15.0f, 25.0f);

        // The Target's height is flipped (in the source Rectangle), due to OpenGL reasons
        Rectangle sourceRec = new Rectangle(0.0f, 0.0f, target.Texture.Width, -(float)target.Texture.Height);
        Rectangle destRec = new Rectangle(-virtualRatio, -virtualRatio, screenWidth + virtualRatio * 2, screenHeight + virtualRatio * 2);

        Vector2 origin = new Vector2(0.0f, 0.0f);

        float rotation = 0.0f;

        float cameraX = 0.0f;
        float cameraY = 0.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            rotation += 60.0f * GetFrameTime(); // Rotate the rectangles, 60 degrees per second

            // Make the camera move to demonstrate the effect
            cameraX = MathF.Sin((float)GetTime()) * 50.0f - 10.0f;
            cameraY = MathF.Cos((float)GetTime()) * 30.0f;

            // Set the camera's Target to the values computed above
            screenSpaceCamera.Target = new Vector2(cameraX, cameraY);

            // Round worldSpace coordinates, keep decimals into screenSpace coordinates
            worldSpaceCamera.Target.X = MathF.Truncate(screenSpaceCamera.Target.X);
            screenSpaceCamera.Target.X -= worldSpaceCamera.Target.X;
            screenSpaceCamera.Target.X *= virtualRatio;

            worldSpaceCamera.Target.Y = MathF.Truncate(screenSpaceCamera.Target.Y);
            screenSpaceCamera.Target.Y -= worldSpaceCamera.Target.Y;
            screenSpaceCamera.Target.Y *= virtualRatio;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginTextureMode(target);
            ClearBackground(Color.RayWhite);

            BeginMode2D(worldSpaceCamera);
            DrawRectanglePro(rec01, origin, rotation, Color.Black);
            DrawRectanglePro(rec02, origin, -rotation, Color.Red);
            DrawRectanglePro(rec03, origin, rotation + 45.0f, Color.Blue);
            EndMode2D();
            EndTextureMode();

            BeginDrawing();
            ClearBackground(Color.Red);

            BeginMode2D(screenSpaceCamera);
            DrawTexturePro(target.Texture, sourceRec, destRec, origin, 0.0f, Color.White);
            EndMode2D();

            DrawText($"Screen resolution: {screenWidth}x{screenHeight}", 10, 10, 20, Color.DarkBlue);
            DrawText($"World resolution: {virtualScreenWidth}x{virtualScreenHeight}", 10, 40, 20, Color.DarkGreen);
            DrawFPS(GetScreenWidth() - 95, 10);
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadRenderTexture(target); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}