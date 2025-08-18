/*******************************************************************************************
 *
 *   raylib [core] example - Custom logging
 *
 *   Example complexity rating: [★★★☆] 3/4
 *
 *   Example originally created with raylib 2.5, last time updated with raylib 2.5
 *
 *   Example contributed by Pablo Marcos Oltra (@pamarcos) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2018-2025 Pablo Marcos Oltra (@pamarcos) and Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;
using Raylib_cs.BleedingEdge.Interop;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public unsafe class CoreCustomLogging : IExample
{
    // Custom logging function
    // (binding note): it's important for method to be marked with UnmanagedCallersOnly attribute
    //                 as GC won't move it around and native code will still be able to call it,
    //                 and you can take address of the method, which is required to set log callback
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void CustomLog(TraceLogLevel msgType, byte* text, nint args)
    {
        Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ");
        Console.Write($"[{msgType}] : ");
        Console.Write(NativeStringFormatter.Format((nint)text, args));
        Console.WriteLine();
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

        // Set custom logger
        // notice how we use '&' to take address of the method and pass it to the native code
        // this won't work when the method isn't marked with UnmanagedCallersOnly
        SetTraceLogCallback(&CustomLog);

        InitWindow(screenWidth, screenHeight, "raylib [core] example - custom logging");

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            DrawText("Check out the console output to see the custom logger in action!", 60, 200, 20, Color.LightGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();        // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}