![logo](https://raw.githubusercontent.com/danilwhale/Raylib-cs.BleedingEdge/main/Assets/Logo-96.png)

### Raylib-cs.BleedingEdge

C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

[![NuGet Downloads](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge?style=flat-square&logo=nuget)](https://www.nuget.org/packages/Raylib-cs.BleedingEdge)
[![GitHub License](https://img.shields.io/github/license/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/blob/main/LICENSE)
[![Discord](https://img.shields.io/discord/426912293134270465?style=flat-square&logo=discord&logoColor=white)](https://discord.gg/raylib)
[![GitHub Repo stars](https://img.shields.io/github/stars/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/stargazers)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/commits/main/)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/danilwhale/Raylib-cs.BleedingEdge/build.yml?style=flat-square&logo=githubactions&logoColor=white)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/actions)

---

Raylib-cs.BleedingEdge targets .NET 8+ and
uses [the master branch of raylib repo](https://github.com/raysan5/raylib/tree/master)

> To see examples, you can reference the [Raylib-cs](https://github.com/chrisdill/raylib-cs) examples
> as this binding has mostly same function signatures (see [code differences](#code-differences))

installation
---

You will need to install one of the following NuGet packages:

- Base
    - Features *only binding for raylib, without prebuilt library files*. **Requires manually compiled raylib**
    - [![NuGet package](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge?style=flat-square&logo=nuget
      )](https://nuget.org/packages/Raylib-cs.BleedingEdge)
- Shared
    - Features *shared (dynamic) library*, which is located near the executable when you build your project. **While
      executable is less portable, it's easier to set up the project**
    - [![NuGet package](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge.Shared?style=flat-square&logo=nuget
      )](https://nuget.org/packages/Raylib-cs.BleedingEdge.Shared)
- Static
    - Features *static library*, **which can be linked with your NativeAOT project to make portable and compact
      executable**.
    - All static libraries will get copied to `static-runtimes` inside of your project root folder and are structured
      like this: `static-runtimes / RID / raylib.lib/libraylib.a`;
    - https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/interop
    - [![NuGet package](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge.Static?style=flat-square&logo=nuget
      )](https://nuget.org/packages/Raylib-cs.BleedingEdge.Static)

In case you need *only prebuilt raylib*, you can just
install [Raylib-cs.BleedingEdge.Runtimes.Static](https://nuget.org/packages/Raylib-cs.BleedingEdge.Runtimes.Static)
or [Raylib-cs.BleedingEdge.Runtimes.Shared](https://nuget.org/packages/Raylib-cs.BleedingEdge.Runtimes.Shared) depending
on your needs
(read above)

basic example
---

```csharp
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

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

### API differences

> [!NOTE]
> There are minor enum value name differences, such as `WindowHighDpi` instead of `HighDpiWindow`,
> `KbMenu` instead of `KeyboardMenu`. Enum value names in this binding are same as in raylib,
> but renamed to match PascalCase

| [Raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge                |
|-----------------------------------------------------|---------------------------------------|
| `using Raylib-cs`                                   | `using Raylib-cs.BleedingEdge`        |
| `T[]` for functions with pointers                   | `Span<T>` for functions with pointers |
| `int` argument for the length of array              | -, use `Span<T>.Slice` if necessary   |
| `Utf8Buffer`                                        | `Utf8Handle`                          |
| `AudioCallback`                                     | `AudioMixedCallback`                  |
