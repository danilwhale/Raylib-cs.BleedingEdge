/*******************************************************************************************
 *
 *   raylib [core] examples - basic screen manager
 *
 *   Example complexity rating: [★☆☆☆] 1/4
 *
 *   NOTE: This example illustrates a very simple screen manager based on a states machines
 *
 *   Example originally created with raylib 4.0, last time updated with raylib 4.0
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2021-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreBasicScreenManager
{
    //------------------------------------------------------------------------------------------
    // Types and Structures Definition
    //------------------------------------------------------------------------------------------
    public enum GameScreen
    {
        Logo,
        Title,
        Gameplay,
        Ending
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - basic screen manager");

        var currentScreen = GameScreen.Logo;

        // TODO: Initialize all required variables and load all required data here!

        var framesCounter = 0; // Useful to count frames

        SetTargetFPS(60); // Set desired framerate (frames-per-second)
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            switch (currentScreen)
            {
                case GameScreen.Logo:
                {
                    // TODO: Update LOGO screen variables here!

                    framesCounter++; // Count frames

                    // Wait for 2 seconds (120 frames) before jumping to TITLE screen
                    if (framesCounter > 120)
                    {
                        currentScreen = GameScreen.Title;
                    }
                }
                    break;
                case GameScreen.Title:
                {
                    // TODO: Update GameScreen.Title screen variables here!

                    // Press enter to change to GAMEPLAY screen
                    if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                    {
                        currentScreen = GameScreen.Gameplay;
                    }
                }
                    break;
                case GameScreen.Gameplay:
                {
                    // TODO: Update GameScreen.Gameplay screen variables here!

                    // Press enter to change to ENDING screen
                    if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                    {
                        currentScreen = GameScreen.Ending;
                    }
                }
                    break;
                case GameScreen.Ending:
                {
                    // TODO: Update GameScreen.Ending screen variables here!

                    // Press enter to return to TITLE screen
                    if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                    {
                        currentScreen = GameScreen.Title;
                    }
                }
                    break;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            switch (currentScreen)
            {
                case GameScreen.Logo:
                {
                    // TODO: Draw LOGO screen here!
                    DrawText("LOGO SCREEN", 20, 20, 40, Color.LightGray);
                    DrawText("WAIT for 2 SECONDS...", 290, 220, 20, Color.Gray);

                }
                    break;
                case GameScreen.Title:
                {
                    // TODO: Draw TITLE screen here!
                    DrawRectangle(0, 0, screenWidth, screenHeight, Color.Green);
                    DrawText("TITLE SCREEN", 20, 20, 40, Color.DarkGreen);
                    DrawText("PRESS ENTER or TAP to JUMP to GAMEPLAY SCREEN", 120, 220, 20, Color.DarkGreen);

                }
                    break;
                case GameScreen.Gameplay:
                {
                    // TODO: Draw GAMEPLAY screen here!
                    DrawRectangle(0, 0, screenWidth, screenHeight, Color.Purple);
                    DrawText("GAMEPLAY SCREEN", 20, 20, 40, Color.Maroon);
                    DrawText("PRESS ENTER or TAP to JUMP to ENDING SCREEN", 130, 220, 20, Color.Maroon);

                }
                    break;
                case GameScreen.Ending:
                {
                    // TODO: Draw ENDING screen here!
                    DrawRectangle(0, 0, screenWidth, screenHeight, Color.Blue);
                    DrawText("ENDING SCREEN", 20, 20, 40, Color.DarkBlue);
                    DrawText("PRESS ENTER or TAP to RETURN to TITLE SCREEN", 120, 220, 20, Color.DarkBlue);

                }
                    break;
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------

        // TODO: Unload all loaded data (textures, fonts, audio) here!

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}