/*******************************************************************************************
 *
 *   raylib [core] example - Input Gestures Detection
 *
 *   Example originally created with raylib 1.4, last time updated with raylib 4.2
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

public class CoreInputGestures
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input gestures");

        var touchPosition = new Vector2(0.0f, 0.0f);
        var touchArea = new Rectangle(220, 10, screenWidth - 230.0f, screenHeight - 20.0f);

        var gesturesCount = 0;
        var gestureStrings = new string[20];

        var currentGesture = Gesture.None;
        var lastGesture = Gesture.None;

        //SetGesturesEnabled(0b0000000000001001);   // Enable only some gestures to be detected

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            lastGesture = currentGesture;
            currentGesture = GetGestureDetected();
            touchPosition = GetTouchPosition(0);

            if (CheckCollisionPointRec(touchPosition, touchArea) && currentGesture != Gesture.None)
            {
                if (currentGesture != lastGesture)
                {
                    // Store gesture string
                    switch (currentGesture)
                    {
                        case Gesture.Tap: gestureStrings[gesturesCount] = "GESTURE TAP"; break;
                        case Gesture.DoubleTap: gestureStrings[gesturesCount] = "GESTURE DOUBLETAP"; break;
                        case Gesture.Hold: gestureStrings[gesturesCount] = "GESTURE HOLD"; break;
                        case Gesture.Drag: gestureStrings[gesturesCount] = "GESTURE DRAG"; break;
                        case Gesture.SwipeRight: gestureStrings[gesturesCount] = "GESTURE SWIPE RIGHT"; break;
                        case Gesture.SwipeLeft: gestureStrings[gesturesCount] = "GESTURE SWIPE LEFT"; break;
                        case Gesture.SwipeUp: gestureStrings[gesturesCount] = "GESTURE SWIPE UP"; break;
                        case Gesture.SwipeDown: gestureStrings[gesturesCount] = "GESTURE SWIPE DOWN"; break;
                        case Gesture.PinchIn: gestureStrings[gesturesCount] = "GESTURE PINCH IN"; break;
                        case Gesture.PinchOut: gestureStrings[gesturesCount] = "GESTURE PINCH OUT"; break;
                    }

                    gesturesCount++;

                    // Reset gestures strings
                    if (gesturesCount >= gestureStrings.Length)
                    {
                        for (var i = 0; i < gestureStrings.Length; i++) gestureStrings[i] = string.Empty;

                        gesturesCount = 0;
                    }
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            DrawRectangleRec(touchArea, Color.Gray);
            DrawRectangle(225, 15, screenWidth - 240, screenHeight - 30, Color.RayWhite);

            DrawText("GESTURES TEST AREA", screenWidth - 270, screenHeight - 40, 20, ColorAlpha(Color.Gray, 0.5f));

            for (var i = 0; i < gesturesCount; i++)
            {
                if (i % 2 == 0) DrawRectangle(10, 30 + 20 * i, 200, 20, ColorAlpha(Color.LightGray, 0.5f));
                else DrawRectangle(10, 30 + 20 * i, 200, 20, ColorAlpha(Color.LightGray, 0.3f));

                if (i < gesturesCount - 1) DrawText(gestureStrings[i], 35, 36 + 20 * i, 10, Color.DarkGray);
                else DrawText(gestureStrings[i], 35, 36 + 20 * i, 10, Color.Maroon);
            }

            DrawRectangleLines(10, 29, 200, screenHeight - 50, Color.Gray);
            DrawText("DETECTED GESTURES", 50, 15, 10, Color.Gray);

            if (currentGesture != Gesture.None) DrawCircleV(touchPosition, 30, Color.Maroon);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}