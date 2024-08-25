using System.Numerics;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Enums.Raylib;
using Raylib_cs.BleedingEdge.Types;
using Raylib_cs.BleedingEdge.Types.Raylib;
using static Raylib_cs.BleedingEdge.Raylib;

// bunnymark
internal struct Bunny
{
    public Vector2 Position;
    public Vector2 Speed;
    public Color Color;
}

internal class Program
{
    private const int MaxBunnies = 50_000;
    private const int MaxBatchElements = 8_192;

    private const int ScreenWidth = 800;
    private const int ScreenHeight = 540;
    
    public static void Main()
    {
        InitWindow(ScreenWidth, ScreenHeight, "bunnymark");
        
        var texBunny = LoadTexture("wabbit_alpha.png");

        Span<Bunny> bunnies = stackalloc Bunny[MaxBunnies];
        var bunniesCount = 0;

        while (!WindowShouldClose())
        {
            if (IsMouseButtonDown(MouseButton.Left))
            {
                for (var i = 0; i < 100; i++)
                {
                    if (bunniesCount < MaxBunnies)
                    {
                        bunnies[bunniesCount].Position = GetMousePosition();
                        bunnies[bunniesCount].Speed.X = GetRandomValue(-250, 250) / 60.0f;
                        bunnies[bunniesCount].Speed.Y = GetRandomValue(-250, 250) / 60.0f;
                        bunnies[bunniesCount].Color = new Color((byte)GetRandomValue(50, 240), (byte)GetRandomValue(80, 240), (byte)GetRandomValue(100, 240));
                        bunniesCount++;
                    }
                }
            }

            for (var i = 0; i < bunniesCount; i++)
            {
                bunnies[i].Position.X += bunnies[i].Speed.X;
                bunnies[i].Position.Y += bunnies[i].Speed.Y;

                if (bunnies[i].Position.X + texBunny.Width / 2.0f > GetScreenWidth() ||
                    bunnies[i].Position.X + texBunny.Width / 2.0f < 0.0f)
                {
                    bunnies[i].Speed.X *= -1;
                }
                
                if (bunnies[i].Position.Y + texBunny.Height / 2.0f > GetScreenHeight() ||
                    bunnies[i].Position.Y + texBunny.Height / 2.0f - 40.0f < 0.0f)
                {
                    bunnies[i].Speed.Y *= -1;
                }
            }
            
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            for (var i = 0; i < bunniesCount; i++)
            {
                DrawTexture(texBunny, (int)bunnies[i].Position.X, (int)bunnies[i].Position.Y, bunnies[i].Color);
            }
            
            DrawRectangle(0, 0, ScreenWidth, 40, Color.Black);
            DrawText($"bunnies: {bunniesCount}", 120, 10, 20, Color.Green);
            DrawText($"batched draw calls: {1 + bunniesCount / MaxBatchElements}", 320, 10, 20, Color.Maroon);
            
            DrawFPS(10, 10);
            
            EndDrawing();
        }
        
        UnloadTexture(texBunny);
        
        CloseWindow();
    }
}

