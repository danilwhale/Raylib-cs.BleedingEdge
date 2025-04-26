Console.WriteLine("Hello, World!");

// using System.Reflection;
// using System.Text.RegularExpressions;
// using Raylib_cs.BleedingEdge;
// using Raylib_cs.BleedingEdge.Examples;
// using static Raylib_cs.BleedingEdge.Raylib;
//
// const int screenWidth = 800;
// const int screenHeight = 450;
// InitWindow(screenWidth, screenHeight, "raylib - example menu");
//
// ExampleCard[] examples = Assembly.GetExecutingAssembly().ExportedTypes
//     .Where(t => typeof(IExample).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false })
//     .Select(t => new ExampleCard(
//         // replace 'core3_d_' with 'core_3d_'
//         DimensionPrefixRegex().Replace(TextToSnake(t.Name), "$1_$2$3_"),
//         () => t.GetMethod("Main", BindingFlags.Static | BindingFlags.Public)!.Invoke(null, null))
//     )
//     .ToArray();
//
// int selectedIndex = 0;
//
// while (!WindowShouldClose())
// {
//     if (IsKeyPressed(KeyboardKey.Up) || IsKeyPressedRepeat(KeyboardKey.Up)) selectedIndex--;
//     if (IsKeyPressed(KeyboardKey.Down) || IsKeyPressedRepeat(KeyboardKey.Down)) selectedIndex++;
//     if (selectedIndex < 0) selectedIndex = examples.Length - 1;
//     selectedIndex %= examples.Length;
//
//     if (IsKeyPressed(KeyboardKey.Enter))
//     {
//         CloseWindow();
//         examples[selectedIndex].Entrypoint();
//         InitWindow(screenWidth, screenHeight, "example menu");
//     }
//
//     BeginDrawing();
//     ClearBackground(Color.RayWhite);
//
//     // draw examples list
//     for (int i = 0; i < examples.Length; i++)
//     {
//         ExampleCard example = examples[i];
//         DrawText(
//             selectedIndex == i ? "> " + example.Name : example.Name,
//             10,
//             10 + i * 30 - (selectedIndex + 1) * 30 + GetScreenHeight() / 2, 
//             20,
//             Color.Black
//         );
//     }
//
//     EndDrawing();
// }
//
// CloseWindow();
//
// internal record struct ExampleCard(string Name, Action Entrypoint);
//
// internal partial class Program
// {
//     [GeneratedRegex("(.*)([0-9]+)_(.*)_")]
//     private static partial Regex DimensionPrefixRegex();
// }