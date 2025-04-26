/*******************************************************************************************
 *
 *   raylib [core] example - window scale letterbox (and virtual mouse)
 *
 *   Example complexity rating: [★★☆☆] 2/4
 *
 *   Example originally created with raylib 2.5, last time updated with raylib 4.0
 *
 *   Example contributed by Anata (@anatagawa) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2019-2025 Anata (@anatagawa) and Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreWindowLetterBox : IExample
{
    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        const int windowWidth = 800;
        const int windowHeight = 450;

        // Enable config flags for resizable window and vertical synchro
        SetConfigFlags(ConfigFlags.WindowResizable | ConfigFlags.VSyncHint);
        InitWindow(windowWidth, windowHeight, "raylib [core] example - window scale letterbox");
        SetWindowMinSize(320, 240);

        int gameScreenWidth = 640;
        int gameScreenHeight = 480;

        // Render texture initialization, used to hold the rendering result so we can easily resize it
        RenderTexture2D target = LoadRenderTexture(gameScreenWidth, gameScreenHeight);
        SetTextureFilter(target.Texture, TextureFilter.Bilinear); // Texture scale filter to use

        Color[] colors = new Color[10];
        for (int i = 0; i < 10; i++)
            colors[i] = new Color((byte)GetRandomValue(100, 250), (byte)GetRandomValue(50, 150), (byte)GetRandomValue(10, 100));

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Compute required framebuffer scaling
            float scale = Math.Min((float)GetScreenWidth() / gameScreenWidth, (float)GetScreenHeight() / gameScreenHeight);

            if (IsKeyPressed(KeyboardKey.Space))
            {
                // Recalculate random colors for the bars
                for (int i = 0; i < 10; i++)
                    colors[i] = new Color((byte)GetRandomValue(100, 250), (byte)GetRandomValue(50, 150), (byte)GetRandomValue(10, 100));
            }

            // Update virtual mouse (clamped mouse value behind game screen)
            Vector2 mouse = GetMousePosition();
            Vector2 virtualMouse = new Vector2
            {
                X = (mouse.X - (GetScreenWidth() - gameScreenWidth * scale) * 0.5f) / scale,
                Y = (mouse.Y - (GetScreenHeight() - gameScreenHeight * scale) * 0.5f) / scale
            };
            virtualMouse = Vector2.Clamp(virtualMouse, new Vector2(0.0f, 0.0f), new Vector2(gameScreenWidth, gameScreenHeight));

            // Apply the same transformation as the virtual mouse to the real mouse (i.e. to work with raygui)
            //SetMouseOffset(-(GetScreenWidth() - (gameScreenWidth*scale))*0.5f, -(GetScreenHeight() - (gameScreenHeight*scale))*0.5f);
            //SetMouseScale(1/scale, 1/scale);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            // Draw everything in the render texture, note this will not be rendered on screen, yet
            BeginTextureMode(target);
            ClearBackground(Color.RayWhite); // Clear render texture background color

            for (int i = 0; i < 10; i++) DrawRectangle(0, gameScreenHeight / 10 * i, gameScreenWidth, gameScreenHeight / 10, colors[i]);

            DrawText("If executed inside a window,\nyou can resize the window,\nand see the screen scaling!", 10, 25, 20, Color.White);
            DrawText($"Default Mouse: [{(int)mouse.X} , {(int)mouse.Y}]", 350, 25, 20, Color.Green);
            DrawText($"Virtual Mouse: [{(int)virtualMouse.X} , {(int)virtualMouse.Y}]", 350, 55, 20, Color.Yellow);
            EndTextureMode();

            BeginDrawing();
            ClearBackground(Color.Black); // Clear screen background

            // Draw render texture to screen, properly scaled
            DrawTexturePro(target.Texture, new Rectangle(0.0f, 0.0f, target.Texture.Width, -target.Texture.Height),
                new Rectangle((GetScreenWidth() - gameScreenWidth * scale) * 0.5f,
                    (GetScreenHeight() - gameScreenHeight * scale) * 0.5f,
                    gameScreenWidth * scale, gameScreenHeight * scale), new Vector2(0, 0), 0.0f, Color.White);
            EndDrawing();
            //--------------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadRenderTexture(target); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}