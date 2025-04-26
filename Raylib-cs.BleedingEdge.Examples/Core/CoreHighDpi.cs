/*******************************************************************************************
 *
 *   raylib [core] example - HighDPI
 *
 *   Example complexity rating: [★☆☆☆] e/4
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2013-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreHighDpi : IExample
{
    private static void DrawTextCenter(string text, int x, int y, int fontSize, Color color)
    {
        Vector2 size = MeasureTextEx(GetFontDefault(), text, fontSize, 3);
        Vector2 pos = new(x - size.X / 2, y - size.Y / 2);
        DrawTextEx(GetFontDefault(), text, pos, fontSize, 3, color);
    }

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
// Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(ConfigFlags.WindowHighDpi | ConfigFlags.WindowResizable);

        InitWindow(screenWidth, screenHeight, "raylib [core] example - highdpi");
        SetWindowMinSize(450, 450);

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            int monitorCount = GetMonitorCount();
            if (monitorCount > 1 && IsKeyPressed(KeyboardKey.N))
            {
                SetWindowMonitor((GetCurrentMonitor() + 1) % monitorCount);
            }

            int currentMonitor = GetCurrentMonitor();

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Vector2 dpiScale = GetWindowScaleDPI();
            ClearBackground(Color.RayWhite);

            int windowCenter = GetScreenWidth() / 2;
            DrawTextCenter($"Dpi Scale: {dpiScale.X}", windowCenter, 30, 40, Color.DarkGray);
            DrawTextCenter($"Monitor: {currentMonitor + 1}/{monitorCount} ([N] next monitor)", windowCenter, 70, 16, Color.LightGray);

            const int logicalGridDescY = 120;
            const int logicalGridLabelY = logicalGridDescY + 30;
            const int logicalGridTop = logicalGridLabelY + 30;
            const int logicalGridBottom = logicalGridTop + 80;
            const int pixelGridTop = logicalGridBottom - 20;
            const int pixelGridBottom = pixelGridTop + 80;
            const int pixelGridLabelY = pixelGridBottom + 30;
            const int pixelGridDescY = pixelGridLabelY + 30;

            const int cellSize = 50;
            int cellSizePx = (int)(cellSize / dpiScale.X);

            DrawTextCenter($"Window is {GetScreenWidth()} \"logical points\" wide", windowCenter, logicalGridDescY, 20, Color.Orange);
            bool odd = true;
            for (int i = cellSize; i < GetScreenWidth(); i += cellSize, odd = !odd)
            {
                if (odd)
                {
                    DrawRectangle(i, logicalGridTop, cellSize, logicalGridBottom - logicalGridTop, Color.Orange);
                }

                DrawTextCenter(i.ToString(), i, logicalGridLabelY, 12, Color.LightGray);
                DrawLine(i, logicalGridLabelY + 10, i, logicalGridBottom, Color.Gray);
            }

            odd = true;
            const int minTextSpace = 30;
            int lastTextX = -minTextSpace;
            for (int i = cellSize; i < GetRenderWidth(); i += cellSize, odd = !odd)
            {
                int x = (int)(i / dpiScale.X);
                if (odd)
                {
                    DrawRectangle(x, pixelGridTop, cellSizePx, pixelGridBottom - pixelGridTop, new Color(0, 121, 241, 100));
                }

                DrawLine(x, pixelGridTop, (int)(i / dpiScale.X), pixelGridLabelY - 10, Color.Gray);
                if (x - lastTextX >= minTextSpace)
                {
                    DrawTextCenter(i.ToString(), x, pixelGridLabelY, 12, Color.LightGray);
                    lastTextX = x;
                }
            }

            DrawTextCenter($"Window is {GetRenderWidth()} \"physical pixels\" wide", windowCenter, pixelGridDescY, 20, Color.Blue);

            {
                const string text = "Can you see this?";
                Vector2 size = MeasureTextEx(GetFontDefault(), text, 16, 3);
                Vector2 pos = new(GetScreenWidth() - size.X - 5, GetScreenHeight() - size.Y - 5);
                DrawTextEx(GetFontDefault(), text, pos, 16, 3, Color.LightGray);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}