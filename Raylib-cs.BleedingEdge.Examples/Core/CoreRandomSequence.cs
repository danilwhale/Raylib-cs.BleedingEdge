/*******************************************************************************************
 *
 *   raylib [core] example - Generates a random sequence
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 *
 *   Example originally created with raylib 5.0, last time updated with raylib 5.0
 *
 *   Example contributed by Dalton Overmyer (@REDl3east) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2023-2025 Dalton Overmyer (@REDl3east)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public unsafe class CoreRandomSequence
{
    private struct ColorRect
    {
        public Color C;
        public Rectangle R;
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - Generates a random sequence");

        var rectCount = 20;
        var rectSize = (float)screenWidth / rectCount;
        var rectangles = GenerateRandomColorRectSequence(rectCount, rectSize, screenWidth, 0.75f * screenHeight);

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------

            if (IsKeyPressed(KeyboardKey.Space))
            {
                ShuffleColorRectSequence(rectangles);
            }

            if (IsKeyPressed(KeyboardKey.Up))
            {
                rectCount++;
                rectSize = (float)screenWidth / rectCount;
                rectangles = GenerateRandomColorRectSequence(rectCount, rectSize, screenWidth, 0.75f * screenHeight);
            }

            if (IsKeyPressed(KeyboardKey.Down))
            {
                if (rectCount >= 4)
                {
                    rectCount--;
                    rectSize = (float)screenWidth / rectCount;
                    rectangles = GenerateRandomColorRectSequence(rectCount, rectSize, screenWidth, 0.75f * screenHeight);
                }
            }

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            var fontSize = 20;
            for (var x = 0; x < rectCount; x++)
            {
                DrawRectangleRec(rectangles[x].R, rectangles[x].C);
                DrawTextCenterKeyHelp("SPACE", "to shuffle the sequence.", 10, screenHeight - 96, fontSize, Color.Black);
                DrawTextCenterKeyHelp("UP", "to add a rectangle and generate a new sequence.", 10, screenHeight - 64, fontSize, Color.Black);
                DrawTextCenterKeyHelp("DOWN", "to remove a rectangle and generate a new sequence.", 10, screenHeight - 32, fontSize, Color.Black);
            }

            var rectCountText = $"{rectCount} rectangles";
            var rectCountTextSize = MeasureText(rectCountText, fontSize);
            DrawText(rectCountText, screenWidth - rectCountTextSize - 10, 10, fontSize, Color.Black);

            DrawFPS(10, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    private static Color GenerateRandomColor()
    {
        return new Color(
            (byte)GetRandomValue(0, 255),
            (byte)GetRandomValue(0, 255),
            (byte)GetRandomValue(0, 255)
        );
    }

    private static ColorRect[] GenerateRandomColorRectSequence(int rectCount, float rectWidth, float screenWidth, float screenHeight)
    {
        var seq = LoadRandomSequence((uint)rectCount, 0, rectCount - 1);

        var rectangles = new ColorRect[rectCount];

        var rectSeqWidth = rectCount * rectWidth;
        var startX = (screenWidth - rectSeqWidth) * 0.5f;

        for (var x = 0; x < rectCount; x++)
        {
            var rectHeight = (int)Raymath.Remap(seq[x], 0, rectCount - 1, 0, screenHeight);
            rectangles[x] = new ColorRect
            {
                C = GenerateRandomColor(),
                R = new Rectangle(startX + x * rectWidth, screenHeight - rectHeight, rectWidth, rectHeight)
            };
        }

        UnloadRandomSequence(seq);

        return rectangles;
    }

    private static void ShuffleColorRectSequence(ColorRect[] rectangles)
    {
        var seq = LoadRandomSequence((uint)rectangles.Length, 0, rectangles.Length - 1);

        for (var i = 0; i < rectangles.Length; i++)
        {
            ref var r1 = ref rectangles[i];
            ref var r2 = ref rectangles[seq[i]];

            // swap only the color and height
            var tmp = r1;
            (r1.C, r1.R.Y, r1.R.Height) = (r2.C, r2.R.Y, r2.R.Height);
            (r2.C, r2.R.Y, r2.R.Height) = (tmp.C, tmp.R.Y, tmp.R.Height);
        }

        UnloadRandomSequence(seq);
    }

    private static void DrawTextCenterKeyHelp(string key, string text, int posX, int posY, int fontSize, Color color)
    {
        var spaceSize = MeasureText(" ", fontSize);
        var pressSize = MeasureText("Press", fontSize);
        var keySize = MeasureText(key, fontSize);
        var textSizeCurrent = 0;

        DrawText("Press", posX, posY, fontSize, color);
        textSizeCurrent += pressSize + 2 * spaceSize;
        DrawText(key, posX + textSizeCurrent, posY, fontSize, Color.Red);
        DrawRectangle(posX + textSizeCurrent, posY + fontSize, keySize, 3, Color.Red);
        textSizeCurrent += keySize + 2 * spaceSize;
        DrawText(text, posX + textSizeCurrent, posY, fontSize, color);
    }
}