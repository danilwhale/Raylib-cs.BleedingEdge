using System.Numerics;
using Raylib_cs.BleedingEdge.Enums.Raylib;
using Raylib_cs.BleedingEdge.Types.Raylib;

namespace Raylib_cs.BleedingEdge.TestGround;

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
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "bunnymark");
        
        var texBunny = Raylib.LoadTexture("wabbit_alpha.png");

        Span<Bunny> bunnies = stackalloc Bunny[MaxBunnies];
        var bunniesCount = 0;

        while (!Raylib.WindowShouldClose())
        {
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                for (var i = 0; i < 100; i++)
                {
                    if (bunniesCount < MaxBunnies)
                    {
                        bunnies[bunniesCount].Position = Raylib.GetMousePosition();
                        bunnies[bunniesCount].Speed.X = Raylib.GetRandomValue(-250, 250) / 60.0f;
                        bunnies[bunniesCount].Speed.Y = Raylib.GetRandomValue(-250, 250) / 60.0f;
                        bunnies[bunniesCount].Color = new Color((byte)Raylib.GetRandomValue(50, 240), (byte)Raylib.GetRandomValue(80, 240), (byte)Raylib.GetRandomValue(100, 240));
                        bunniesCount++;
                    }
                }
            }

            for (var i = 0; i < bunniesCount; i++)
            {
                bunnies[i].Position.X += bunnies[i].Speed.X;
                bunnies[i].Position.Y += bunnies[i].Speed.Y;

                if (bunnies[i].Position.X + texBunny.Width / 2.0f > Raylib.GetScreenWidth() ||
                    bunnies[i].Position.X + texBunny.Width / 2.0f < 0.0f)
                {
                    bunnies[i].Speed.X *= -1;
                }
                
                if (bunnies[i].Position.Y + texBunny.Height / 2.0f > Raylib.GetScreenHeight() ||
                    bunnies[i].Position.Y + texBunny.Height / 2.0f - 40.0f < 0.0f)
                {
                    bunnies[i].Speed.Y *= -1;
                }
            }
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            for (var i = 0; i < bunniesCount; i++)
            {
                Raylib.DrawTexture(texBunny, (int)bunnies[i].Position.X, (int)bunnies[i].Position.Y, bunnies[i].Color);
            }
            
            Raylib.DrawRectangle(0, 0, ScreenWidth, 40, Color.Black);
            Raylib.DrawText($"bunnies: {bunniesCount}", 120, 10, 20, Color.Green);
            Raylib.DrawText($"batched draw calls: {1 + bunniesCount / MaxBatchElements}", 320, 10, 20, Color.Maroon);
            
            Raylib.DrawFPS(10, 10);
            
            Raylib.EndDrawing();
        }
        
        Raylib.UnloadTexture(texBunny);
        
        Raylib.CloseWindow();
    }
}