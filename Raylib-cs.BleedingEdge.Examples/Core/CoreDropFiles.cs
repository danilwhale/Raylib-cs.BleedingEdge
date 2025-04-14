/*******************************************************************************************
 *
 *   raylib [core] example - Windows drop files
 *
 *   Example complexity rating: [★★☆☆] 2/4
 *
 *   NOTE: This example only works on platforms that support drag & drop (Windows, Linux, OSX, Html5?)
 *
 *   Example originally created with raylib 1.3, last time updated with raylib 4.2
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2015-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class CoreDropFiles
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - drop files");

        var filePathCounter = 0;
        var filePaths = new string[4096]; // We will register a maximum of filepaths

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsFileDropped())
            {
                var droppedFiles = LoadDroppedFiles();

                for (int i = 0, offset = filePathCounter; i < (int)droppedFiles.Count; i++)
                {
                    if (filePathCounter < filePaths.Length - 1)
                    {
                        filePaths[offset + i] = droppedFiles.PathsArray[i];
                        filePathCounter++;
                    }
                }

                UnloadDroppedFiles(droppedFiles); // Unload filepaths from memory
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            if (filePathCounter == 0) DrawText("Drop your files to this window!", 100, 40, 20, Color.DarkGray);
            else
            {
                DrawText("Dropped files:", 100, 40, 20, Color.DarkGray);

                for (var i = 0; i < filePathCounter; i++)
                {
                    if (i % 2 == 0) DrawRectangle(0, 85 + 40 * i, screenWidth, 40, ColorAlpha(Color.LightGray, 0.5f));
                    else DrawRectangle(0, 85 + 40 * i, screenWidth, 40, ColorAlpha(Color.LightGray, 0.3f));

                    DrawText(filePaths[i], 120, 100 + 40 * i, 10, Color.Gray);
                }

                DrawText("Drop new files...", 100, 110 + 40 * filePathCounter, 20, Color.DarkGray);
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}