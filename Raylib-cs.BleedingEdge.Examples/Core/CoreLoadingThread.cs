/*******************************************************************************************
 *
 *   raylib [core] example - loading thread
 *
 *   Example complexity rating: [★★★☆] 3/4
 *
 *   NOTE: This example requires linking with pthreads library on MinGW,
 *   it can be accomplished passing -static parameter to compiler
 *
 *   Example originally created with raylib 2.5, last time updated with raylib 3.0
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *
 *   Copyright (c) 2014-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreLoadingThread
{
    private enum State
    {
        Waiting,
        Loading,
        Finished
    }

    private static long _dataLoaded; // Data Loaded completion indicator
    private static long _dataProgress; // Data progress accumulator

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - loading thread");

        var state = State.Waiting;
        var thread = new Thread(LoadDataThread);
        var framesCounter = 0;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            switch (state)
            {
                case State.Waiting:
                {
                    if (IsKeyPressed(KeyboardKey.Enter))
                    {
                        thread = new Thread(LoadDataThread);
                        thread.Start();

                        state = State.Loading;
                    }

                    break;
                }
                case State.Loading:
                {
                    framesCounter++;
                    if (Interlocked.Read(ref _dataLoaded) == 1)
                    {
                        framesCounter = 0;
                        thread.Join();

                        state = State.Finished;
                    }

                    break;
                }
                case State.Finished:
                {
                    if (IsKeyPressed(KeyboardKey.Enter))
                    {
                        // Reset everything to launch again
                        Interlocked.Exchange(ref _dataLoaded, 0);
                        Interlocked.Exchange(ref _dataProgress, 0);

                        state = State.Waiting;
                    }

                    break;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            switch (state)
            {
                case State.Waiting:
                {
                    DrawText("PRESS ENTER to START LOADING DATA", 150, 170, 20, Color.DarkGray);
                    break;
                }
                case State.Loading:
                {
                    DrawRectangle(150, 200, (int)Interlocked.Read(ref _dataProgress), 60, Color.SkyBlue);
                    if (framesCounter / 15 % 2 != 0) DrawText("LOADING DATA...", 240, 210, 40, Color.DarkBlue);
                    break;
                }
                case State.Finished:
                {
                    DrawRectangle(150, 200, 500, 60, Color.Lime);
                    DrawText("DATA LOADED!", 250, 210, 40, Color.Green);

                    break;
                }
            }

            DrawRectangleLines(150, 200, 500, 60, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
    
    // Loading data thread function definition
    private static void LoadDataThread()
    {
        var timeCounter = 0; // Time counted in ms
        var prevTime = DateTime.UtcNow; // Previous time

        // We simulate data loading with a time counter for 5 seconds
        while (timeCounter < 5000)
        {
            var currentTime = DateTime.UtcNow - prevTime;
            timeCounter = (int)currentTime.TotalMilliseconds;

            // We accumulate time over a global variable to be used in
            // main thread as a progress bar
            Interlocked.Exchange(ref _dataProgress, timeCounter / 10);
        }

        // When data has finished loading, we set global variable
        Interlocked.Exchange(ref _dataLoaded, 1);
    }
}