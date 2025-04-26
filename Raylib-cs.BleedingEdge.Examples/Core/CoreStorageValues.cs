/*******************************************************************************************
 *
 *   raylib [core] example - Storage save/load values
 *
 *   Example complexity rating: [★★☆☆] 2/4
 *
 *   Example originally created with raylib 1.4, last time updated with raylib 4.2
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

public class CoreStorageValues
{
    private const string StorageDataFile = "storage.data"; // Storage file

    // NOTE: Storage positions must start with 0, directly related to file memory layout
    private enum StoragePosition
    {
        Score = 0,
        HiScore = 1
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

        InitWindow(screenWidth, screenHeight, "raylib [core] example - storage save/load values");

        int score = 0;
        int hiscore = 0;
        int framesCounter = 0;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.R))
            {
                score = GetRandomValue(1000, 2000);
                hiscore = GetRandomValue(2000, 4000);
            }

            if (IsKeyPressed(KeyboardKey.Enter))
            {
                SaveStorageValue(StoragePosition.Score, score);
                SaveStorageValue(StoragePosition.HiScore, hiscore);
            }
            else if (IsKeyPressed(KeyboardKey.Space))
            {
                // NOTE: If requested position could not be found, value 0 is returned
                score = LoadStorageValue(StoragePosition.Score);
                hiscore = LoadStorageValue(StoragePosition.HiScore);
            }

            framesCounter++;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            DrawText($"SCORE: {score}", 280, 130, 40, Color.Maroon);
            DrawText($"HI-SCORE: {hiscore}", 210, 200, 50, Color.Black);

            DrawText($"frames: {framesCounter}", 10, 10, 20, Color.Lime);

            DrawText("Press R to generate random numbers", 220, 40, 20, Color.LightGray);
            DrawText("Press ENTER to SAVE values", 250, 310, 20, Color.LightGray);
            DrawText("Press SPACE to LOAD values", 252, 350, 20, Color.LightGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    // Save integer value to storage file (to defined position)
    // NOTE: Storage positions is directly related to file memory layout (4 bytes each integer)
    private static bool SaveStorageValue(StoragePosition position, int value)
    {
        bool success;

        try
        {
            byte[] fileData;
            if (File.Exists(StorageDataFile))
            {
                fileData = File.ReadAllBytes(StorageDataFile);
                if (fileData.Length <= (int)position * sizeof(int))
                {
                    // Increase data size up to position and store value
                    Array.Resize(ref fileData, ((int)position + 1) * sizeof(int));
                }
            }
            else
            {
                TraceLog(TraceLogLevel.Info, $"FILEIO: [{StorageDataFile}] File created successfully");
                fileData = new byte[((int)position + 1) * sizeof(int)];
            }

            // Replace value on selected position
            BitConverter.TryWriteBytes(fileData.AsSpan((int)position * sizeof(int)), value);

            File.WriteAllBytes(StorageDataFile, fileData);
            TraceLog(TraceLogLevel.Info, $"FILEIO: [{StorageDataFile}] Saved storage value: {value}");

            success = true;
        }
        catch
        {
            success = false;
        }

        return success;
    }

    // Load integer value from storage file (from defined position)
    // NOTE: If requested position could not be found, value 0 is returned
    private static int LoadStorageValue(StoragePosition position)
    {
        int value = 0;

        if (!File.Exists(StorageDataFile)) return value;

        try
        {
            byte[] fileData = File.ReadAllBytes(StorageDataFile);
            if (fileData.Length < (int)position * sizeof(int))
            {
                TraceLog(TraceLogLevel.Warning, $"FILEIO: [{StorageDataFile}] Failed to find storage position: {(int)position}");
            }
            else
            {
                value = BitConverter.ToInt32(fileData.AsSpan((int)position * sizeof(int)));
            }

            TraceLog(TraceLogLevel.Info, $"FILEIO: [{StorageDataFile}] Loaded storage value: {value}");
        }
        catch
        {
            // ignored
        }

        return value;
    }
}