/*******************************************************************************************
 *
 *   raylib [core] example - input virtual controls
 *
 *   Example complexity rating: [★★★☆] 3/4
 *
 *   Example originally created with raylib 5.0, last time updated with raylib 5.0
 *
 *   Example create by GreenSnakeLinux (@GreenSnakeLinux),
 *   lighter by oblerion (@oblerion) and
 *   reviewed by Ramon Santamaria (@raysan5) and
 *   improved by danilwhale (@danilwhale)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2024-2025 oblerion (@oblerion) and Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreInputVirtualControls : IExample
{
    private enum PadButton
    {
        None = -1,
        Up,
        Left,
        Right,
        Down,
        Max
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input virtual controls");

        Vector2 padPosition = new Vector2(100, 350);
        float buttonRadius = 30.0f;

        Vector2[] buttonPositions = new[]
        {
            new Vector2(padPosition.X, padPosition.Y - buttonRadius * 1.5f), // Up
            new Vector2(padPosition.X - buttonRadius * 1.5f, padPosition.Y), // Left
            new Vector2(padPosition.X + buttonRadius * 1.5f, padPosition.Y), // Right
            new Vector2(padPosition.X, padPosition.Y + buttonRadius * 1.5f) // Down
        };

        string[] buttonLabels = new[]
        {
            "Y", // Up
            "X", // Left
            "B", // Right
            "A" // Down
        };

        Color[] buttonLabelColors = new[]
        {
            Color.Yellow, // Up
            Color.Blue, // Left
            Color.Red, // Right
            Color.Green, // Down
        };

        PadButton pressedButton = PadButton.None;
        Vector2 inputPosition = new Vector2(0, 0);

        Vector2 playerPosition = new Vector2((float)screenWidth / 2, (float)screenHeight / 2);
        float playerSpeed = 75.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //--------------------------------------------------------------------------
            if (GetTouchPointCount() > 0)
            {
                // Use touch position
                inputPosition = GetTouchPosition(0);
            }
            else
            {
                // Use mouse position
                inputPosition = GetMousePosition();
            }

            // Reset pressed button to none
            pressedButton = PadButton.None;

            // Make sure user is pressing left mouse button if they're from desktop
            if (GetTouchPointCount() > 0 || GetTouchPointCount() == 0 && IsMouseButtonDown(MouseButton.Left))
            {
                // Find nearest D-Pad button to the input position
                for (int i = 0; i < (int)PadButton.Max; i++)
                {
                    float distX = Math.Abs(buttonPositions[i].X - inputPosition.X);
                    float distY = Math.Abs(buttonPositions[i].Y - inputPosition.Y);

                    if (distX + distY < buttonRadius)
                    {
                        pressedButton = (PadButton)i;
                        break;
                    }
                }
            }

            // Move player according to pressed button
            switch (pressedButton)
            {
                case PadButton.Up:
                {
                    playerPosition.Y -= playerSpeed * GetFrameTime();
                    break;
                }
                case PadButton.Left:
                {
                    playerPosition.X -= playerSpeed * GetFrameTime();
                    break;
                }
                case PadButton.Right:
                {
                    playerPosition.X += playerSpeed * GetFrameTime();
                    break;
                }
                case PadButton.Down:
                {
                    playerPosition.Y += playerSpeed * GetFrameTime();
                    break;
                }
                default: break;
            }

            //--------------------------------------------------------------------------
            // Draw
            //--------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            // Draw world
            DrawCircleV(playerPosition, 50, Color.Maroon);

            // Draw GUI
            for (int i = 0; i < (int)PadButton.Max; i++)
            {
                DrawCircleV(buttonPositions[i], buttonRadius, i == (int)pressedButton ? Color.DarkGray : Color.Black);

                DrawText(buttonLabels[i],
                    (int)buttonPositions[i].X - 7, (int)buttonPositions[i].Y - 8,
                    20, buttonLabelColors[i]);
            }

            DrawText("move the player with D-Pad buttons", 10, 10, 20, Color.DarkGray);

            EndDrawing();
            //--------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}