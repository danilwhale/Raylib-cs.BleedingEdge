/*******************************************************************************************
 *
 *   raylib [core] example - 2D Camera platformer
 *
 *   Example complexity rating: [★★★☆] 3/4
 *
 *   Example originally created with raylib 2.5, last time updated with raylib 3.0
 *
 *   Example contributed by arvyy (@arvyy) and reviewed by Ramon Santamaria (@raysan5)
 *
 *   Example licensed under an unmodified zlib/libpng license, which is an OSI-certified,
 *   BSD-like license that allows static linking with closed source software
 *
 *   Copyright (c) 2019-2025 arvyy (@arvyy)
 *
 ********************************************************************************************/

using System.Numerics;
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

namespace Raylib_cs.BleedingEdge.Examples.Core;

public class Core2DCameraPlatformer
{
    private const float G = 400;
    private const float PlayerJumpSpd = 350.0f;
    private const float PlayerHorSpd = 200.0f;

    private struct Player
    {
        public Vector2 Position;
        public float Speed;
        public bool CanJump;
    }

    private struct EnvItem
    {
        public Rectangle Rect;
        public bool Blocking;
        public Color Color;
    }

    private delegate void CameraUpdater(ref Camera2D camera, ref Player player, Span<EnvItem> envItems, float delta,
        int width, int height);

    //------------------------------------------------------------------------------------
    // Program main entry point
    //------------------------------------------------------------------------------------
    public static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        Player player = new Player
        {
            Position = new Vector2(400, 280),
            Speed = 0,
            CanJump = false
        };

        EnvItem[] envItems = new EnvItem[]
        {
            new() { Rect = new Rectangle(0, 0, 1000, 400), Blocking = false, Color = Color.LightGray },
            new() { Rect = new Rectangle(0, 400, 1000, 200), Blocking = true, Color = Color.Gray },
            new() { Rect = new Rectangle(300, 200, 400, 10), Blocking = true, Color = Color.Gray },
            new() { Rect = new Rectangle(250, 300, 100, 10), Blocking = true, Color = Color.Gray },
            new() { Rect = new Rectangle(650, 300, 100, 10), Blocking = true, Color = Color.Gray }
        };

        Camera2D camera = new Camera2D
        {
            Target = player.Position,
            Offset = new Vector2(screenWidth / 2.0f, screenHeight / 2.0f),
            Rotation = 0.0f,
            Zoom = 1.0f
        };

        // Store pointers to the multiple update camera functions
        CameraUpdater[] cameraUpdaters = new CameraUpdater[]
        {
            UpdateCameraCenter,
            UpdateCameraCenterInsideMap,
            UpdateCameraCenterSmoothFollow,
            UpdateCameraEvenOutOnLanding,
            UpdateCameraPlayerBoundsPush
        };

        int cameraOption = 0;

        string[] cameraDescriptions = new[]
        {
            "Follow player center",
            "Follow player center, but clamp to map edges",
            "Follow player center; smoothed",
            "Follow player center horizontally; update player center vertically after landing",
            "Player push camera on getting too close to screen edge"
        };

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            float deltaTime = GetFrameTime();

            UpdatePlayer(ref player, envItems, deltaTime);

            camera.Zoom += GetMouseWheelMove() * 0.05f;

            if (camera.Zoom > 3.0f) camera.Zoom = 3.0f;
            else if (camera.Zoom < 0.25f) camera.Zoom = 0.25f;

            if (IsKeyPressed(KeyboardKey.R))
            {
                camera.Zoom = 1.0f;
                player.Position = new Vector2(400, 280);
            }

            if (IsKeyPressed(KeyboardKey.C)) cameraOption = (cameraOption + 1) % cameraUpdaters.Length;

            // Call update camera function by its pointer
            cameraUpdaters[cameraOption](ref camera, ref player, envItems, deltaTime, screenWidth, screenHeight);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            ClearBackground(Color.LightGray);

            BeginMode2D(camera);

            for (int i = 0; i < envItems.Length; i++) DrawRectangleRec(envItems[i].Rect, envItems[i].Color);

            Rectangle playerRect = new Rectangle(player.Position.X - 20, player.Position.Y - 40, 40.0f, 40.0f);
            DrawRectangleRec(playerRect, Color.Red);

            DrawCircleV(player.Position, 5.0f, Color.Gold);

            EndMode2D();

            DrawText("Controls:", 20, 20, 10, Color.Black);
            DrawText("- Right/Left to move", 40, 40, 10, Color.DarkGray);
            DrawText("- Space to jump", 40, 60, 10, Color.DarkGray);
            DrawText("- Mouse Wheel to Zoom in-out, R to reset zoom", 40, 80, 10, Color.DarkGray);
            DrawText("- C to change camera mode", 40, 100, 10, Color.DarkGray);
            DrawText("Current camera mode:", 20, 120, 10, Color.Black);
            DrawText(cameraDescriptions[cameraOption], 40, 140, 10, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    private static void UpdatePlayer(ref Player player, Span<EnvItem> envItems, float delta)
    {
        if (IsKeyDown(KeyboardKey.Left)) player.Position.X -= PlayerHorSpd * delta;
        if (IsKeyDown(KeyboardKey.Right)) player.Position.X += PlayerHorSpd * delta;
        if (IsKeyDown(KeyboardKey.Space) && player.CanJump)
        {
            player.Speed = -PlayerJumpSpd;
            player.CanJump = false;
        }

        bool hitObstacle = false;
        for (int i = 0; i < envItems.Length; i++)
        {
            ref EnvItem ei = ref envItems[i];
            ref Vector2 p = ref player.Position;

            if (ei.Blocking &&
                ei.Rect.X <= p.X &&
                ei.Rect.X + ei.Rect.Width >= p.X &&
                ei.Rect.Y >= p.Y &&
                ei.Rect.Y <= p.Y + player.Speed * delta)
            {
                hitObstacle = true;
                player.Speed = 0.0f;
                p.Y = ei.Rect.Y;
                break;
            }
        }

        if (!hitObstacle)
        {
            player.Position.Y += player.Speed * delta;
            player.Speed += G * delta;
            player.CanJump = false;
        }
        else player.CanJump = true;
    }

    private static void UpdateCameraCenter(
        ref Camera2D camera, ref Player player, Span<EnvItem> envItems, float delta, int width, int height)
    {
        camera.Offset = new Vector2(width / 2.0f, height / 2.0f);
        camera.Target = player.Position;
    }

    private static void UpdateCameraCenterInsideMap(
        ref Camera2D camera, ref Player player, Span<EnvItem> envItems, float delta, int width, int height)
    {
        camera.Target = player.Position;
        camera.Offset = new Vector2(width / 2.0f, height / 2.0f);
        float minX = 1000, minY = 1000, maxX = -1000, maxY = -1000;

        for (int i = 0; i < envItems.Length; i++)
        {
            ref EnvItem ei = ref envItems[i];
            minX = Math.Min(ei.Rect.X, minX);
            maxX = Math.Max(ei.Rect.X + ei.Rect.Width, maxX);
            minY = Math.Min(ei.Rect.Y, minY);
            maxY = Math.Max(ei.Rect.Y + ei.Rect.Height, maxY);
        }

        Vector2 max = GetWorldToScreen2D(new Vector2(maxX, maxY), camera);
        Vector2 min = GetWorldToScreen2D(new Vector2(minX, minY), camera);

        if (max.X < width) camera.Offset.X = width - (max.X - width / 2);
        if (max.Y < height) camera.Offset.Y = height - (max.Y - height / 2);
        if (min.X > 0) camera.Offset.X = width / 2 - min.X;
        if (min.Y > 0) camera.Offset.Y = height / 2 - min.Y;
    }

    private static void UpdateCameraCenterSmoothFollow(
        ref Camera2D camera, ref Player player, Span<EnvItem> envItems, float delta, int width, int height)
    {
        const float minSpeed = 30;
        const float minEffectLength = 10;
        const float fractionSpeed = 0.8f;

        camera.Offset = new Vector2(width / 2.0f, height / 2.0f);
        Vector2 diff = player.Position - camera.Target;
        float length = diff.Length();

        if (length > minEffectLength)
        {
            float speed = Math.Max(fractionSpeed * length, minSpeed);
            camera.Target += diff * speed * delta / length;
        }
    }

    private static bool _eveningOut;
    private static float _evenOutTarget;

    private static void UpdateCameraEvenOutOnLanding(
        ref Camera2D camera, ref Player player, Span<EnvItem> envItems, float delta, int width, int height)
    {
        const float evenOutSpeed = 700;

        camera.Offset = new Vector2(width / 2.0f, height / 2.0f);
        camera.Target.X = player.Position.X;

        if (_eveningOut)
        {
            if (_evenOutTarget > camera.Target.Y)
            {
                camera.Target.Y += evenOutSpeed * delta;

                if (camera.Target.Y > _evenOutTarget)
                {
                    camera.Target.Y = _evenOutTarget;
                    _eveningOut = false;
                }
            }
            else
            {
                camera.Target.Y -= evenOutSpeed * delta;

                if (camera.Target.Y < _evenOutTarget)
                {
                    camera.Target.Y = _evenOutTarget;
                    _eveningOut = false;
                }
            }
        }
        else
        {
            if (player.CanJump && player.Speed == 0 && player.Position.Y != camera.Target.Y)
            {
                _eveningOut = true;
                _evenOutTarget = player.Position.Y;
            }
        }
    }

    private static void UpdateCameraPlayerBoundsPush(
        ref Camera2D camera, ref Player player, Span<EnvItem> envItems, float delta, int width, int height)
    {
        const float bboxX = 0.2f;
        const float bboxY = 0.2f;

        Vector2 bboxWorldMin =
            GetScreenToWorld2D(new Vector2((1 - bboxX) * 0.5f * width, (1 - bboxY) * 0.5f * height), camera);
        Vector2 bboxWorldMax =
            GetScreenToWorld2D(new Vector2((1 + bboxX) * 0.5f * width, (1 + bboxY) * 0.5f * height), camera);
        camera.Offset = new Vector2((1 - bboxX) * 0.5f * width, (1 - bboxY) * 0.5f * height);

        if (player.Position.X < bboxWorldMin.X) camera.Target.X = player.Position.X;
        if (player.Position.Y < bboxWorldMin.Y) camera.Target.Y = player.Position.Y;
        if (player.Position.X > bboxWorldMax.X) camera.Target.X = bboxWorldMin.X + (player.Position.X - bboxWorldMax.X);
        if (player.Position.Y > bboxWorldMax.Y) camera.Target.Y = bboxWorldMin.Y + (player.Position.Y - bboxWorldMax.Y);
    }
}