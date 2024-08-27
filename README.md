![logo](Assets/Logo-96.png)

### Raylib-cs.BleedingEdge
C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

![NuGet Downloads](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge?style=flat-square&logo=nuget)
![GitHub License](https://img.shields.io/github/license/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)
![Discord](https://img.shields.io/discord/426912293134270465?style=flat-square&logo=discord&logoColor=white)
![GitHub Repo stars](https://img.shields.io/github/stars/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)
![GitHub commit activity](https://img.shields.io/github/commit-activity/w/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/danilwhale/Raylib-cs.BleedingEdge/build.yml?style=flat-square&logo=githubactions&logoColor=white)

---

Raylib-cs.BleedingEdge targets .NET 8+ and uses [the master branch of raylib repo](https://github.com/raysan5/raylib/tree/master)

> there are still no examples, you can rely on [Raylib-cs](https://github.com/chrisdill/raylib-cs) examples
> as this binding has mostly same function signatures (see [code differences](#code-differences))

basic example
---

```csharp
using Raylib-cs.BleedingEdge;
using static Raylib-cs.BleedingEdge.Raylib;

const int screenWidth = 800;
const int screenHeight = 540;

InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.RayWhite);
    
    DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LightGray);
    
    EndDrawing();
}

CloseWindow();
```

differences from [Raylib-cs](https://github.com/ChrisDill/Raylib-cs)
---

### main differences
| [Raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge  |
|-----------------------------------------------------|-------------------------|
| .NET 6.0+                                           | .NET 8.0+               |
| Released 07-2018                                    | Released 08-2024        |
| raylib 5.0                                          | raylib 5.5-dev (master) |

### code differences
###### `*` means *any*, e.g. `*Span<T>` can be `Span<T>` or `ReadOnlySpan<T>`
| [Raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge                                   |
|-----------------------------------------------------|----------------------------------------------------------|
| `using Raylib-cs`                                   | `using Raylib-cs.BleedingEdge`                           |
| `Texture2D`                                         | `Texture`                                                |
| `RenderTexture2D`                                   | `RenderTexture`                                          |
| `T[]` for functions with pointers                   | `Span<T>` for functions with pointers                    |
| `int` argument for the length of array              | -, use `Span<T>.Slice` if necessary                      |
| `Function_()` as `string` variant                   | `FunctionString()` as `string` variant                   |
| `Utf8Buffer`                                        | `Utf8Handle`                                             |
| `New<T>(uint)`                                      | `MemAlloc<T>(uint)`                                      |
| `Get*` (`GetDroppedFiles`)                          | -, use `Load*`, `Unload*` (`Load/UnloadDroppedFiles`)    |