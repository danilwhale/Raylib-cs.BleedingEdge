/*******************************************************************************************
 *
 *   raylib [core] example - VR Simulator (Oculus Rift CV1 parameters)
 *
 *   Example complexity rating: [★★★☆] 3/4
 *
 *   Example originally created with raylib 2.5, last time updated with raylib 4.0
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2017-2025 Ramon Santamaria (@raysan5)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public unsafe class CoreVrSimulator
{
    private static readonly string GlslVersion = OperatingSystem.IsAndroid() || OperatingSystem.IsBrowser() ? "100" : "330";

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // NOTE: screenWidth/screenHeight should match VR device aspect ratio
        InitWindow(screenWidth, screenHeight, "raylib [core] example - vr simulator");

        // VR device parameters definition
        var device = new VrDeviceInfo
        {
            // Oculus Rift CV1 parameters for simulator
            HResolution = 2160, // Horizontal resolution in pixels
            VResolution = 1200, // Vertical resolution in pixels
            HScreenSize = 0.133793f, // Horizontal size in meters
            VScreenSize = 0.0669f, // Vertical size in meters
            EyeToScreenDistance = 0.041f, // Distance between eye and display in meters
            LensSeparationDistance = 0.07f, // Lens separation distance in meters
            InterpupillaryDistance = 0.07f, // IPD (distance between pupils) in meters
        };

        // NOTE: CV1 uses fresnel-hybrid-asymmetric lenses with specific compute shaders
        // Following parameters are just an approximation to CV1 distortion stereo rendering
        device.LensDistortionValues[0] = 1.0f; // Lens distortion constant parameter 0
        device.LensDistortionValues[1] = 0.22f; // Lens distortion constant parameter 1
        device.LensDistortionValues[2] = 0.24f; // Lens distortion constant parameter 2
        device.LensDistortionValues[3] = 0.0f; // Lens distortion constant parameter 3
        device.ChromaAbCorrection[0] = 0.996f; // Chromatic aberration correction parameter 0
        device.ChromaAbCorrection[1] = -0.004f; // Chromatic aberration correction parameter 1
        device.ChromaAbCorrection[2] = 1.014f; // Chromatic aberration correction parameter 2
        device.ChromaAbCorrection[3] = 0.0f; // Chromatic aberration correction parameter 3

        // Load VR stereo config for VR device parameteres (Oculus Rift CV1 parameters)
        var config = LoadVrStereoConfig(device);

        // Distortion shader (uses device lens distortion and chroma)
        var distortion = LoadShader(null, $"resources/distortion{GlslVersion}.fs");

        // Update distortion shader with lens and distortion-scale parameters
        SetShaderValue(distortion, GetShaderLocation(distortion, "leftLensCenter"),
            config.LeftLensCenter, ShaderUniformDataType.Vec2);
        SetShaderValue(distortion, GetShaderLocation(distortion, "rightLensCenter"),
            config.RightLensCenter, ShaderUniformDataType.Vec2);
        SetShaderValue(distortion, GetShaderLocation(distortion, "leftScreenCenter"),
            config.LeftScreenCenter, ShaderUniformDataType.Vec2);
        SetShaderValue(distortion, GetShaderLocation(distortion, "rightScreenCenter"),
            config.RightScreenCenter, ShaderUniformDataType.Vec2);

        SetShaderValue(distortion, GetShaderLocation(distortion, "scale"),
            config.Scale, ShaderUniformDataType.Vec2);
        SetShaderValue(distortion, GetShaderLocation(distortion, "scaleIn"),
            config.ScaleIn, ShaderUniformDataType.Vec2);
        SetShaderValue(distortion, GetShaderLocation(distortion, "deviceWarpParam"),
            device.LensDistortionValues, ShaderUniformDataType.Vec4);
        SetShaderValue(distortion, GetShaderLocation(distortion, "chromaAbParam"),
            device.ChromaAbCorrection, ShaderUniformDataType.Vec4);

        // Initialize framebuffer for stereo rendering
        // NOTE: Screen size should match HMD aspect ratio
        var target = LoadRenderTexture(device.HResolution, device.VResolution);

        // The target's height is flipped (in the source Rectangle), due to OpenGL reasons
        var sourceRec = new Rectangle(0.0f, 0.0f, target.Texture.Width, -(float)target.Texture.Height);
        var destRec = new Rectangle(0.0f, 0.0f, GetScreenWidth(), GetScreenHeight());

        // Define the camera to look into our 3d world
        var camera = new Camera3D
        {
            Position = new Vector3(5.0f, 2.0f, 5.0f), // Camera position
            Target = new Vector3(0.0f, 2.0f, 0.0f), // Camera looking at point
            Up = Vector3.UnitY, // Camera up vector
            FovY = 60.0f, // Camera field-of-view Y
            Projection = CameraProjection.Perspective // Camera projection type
        };

        var cubePosition = new Vector3(0.0f, 0.0f, 0.0f);

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            UpdateCamera(&camera, CameraMode.FirstPerson);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginTextureMode(target);
            ClearBackground(Color.RayWhite);
            BeginVrStereoMode(config);
            BeginMode3D(camera);

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.Red);
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.Maroon);
            DrawGrid(40, 1.0f);

            EndMode3D();
            EndVrStereoMode();
            EndTextureMode();

            BeginDrawing();
            ClearBackground(Color.RayWhite);
            BeginShaderMode(distortion);
            DrawTexturePro(target.Texture, sourceRec, destRec, new Vector2(0.0f, 0.0f), 0.0f, Color.White);
            EndShaderMode();
            DrawFPS(10, 10);
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadVrStereoConfig(config); // Unload stereo config

        UnloadRenderTexture(target); // Unload stereo render fbo
        UnloadShader(distortion); // Unload distortion shader

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}