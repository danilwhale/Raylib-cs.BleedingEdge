<img align="left" width="160" height="160" src="https://raw.githubusercontent.com/danilwhale/Raylib-cs.BleedingEdge/main/Assets/Logo-256.png" alt="Logo">

### Raylib-cs.BleedingEdge

Bleeding-edge C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

[![Discord](https://img.shields.io/discord/426912293134270465?style=flat-square&logo=discord&logoColor=white)](https://discord.gg/raylib)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge?style=flat-square&logo=nuget)](https://www.nuget.org/packages/Raylib-cs.BleedingEdge)
[![GitHub License](https://img.shields.io/github/license/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/blob/main/LICENSE)
[![GitHub Repo stars](https://img.shields.io/github/stars/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/stargazers)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/commits/main/)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/danilwhale/Raylib-cs.BleedingEdge/build.yml?style=flat-square&logo=githubactions&logoColor=white)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/actions)

---

Raylib-cs.BleedingEdge targets .NET 8+ and
binds [raylib's master branch](https://github.com/raysan5/raylib/tree/master)

> there are [WIP examples](https://github.com/danilwhale/Raylib-cs.BleedingEdge/tree/main/Raylib-cs.BleedingEdge.Examples). 
> you can reference [raylib-cs](https://github.com/chrisdill/raylib-cs/tree/master/Examples)
> or [raylib](https://github.com/raysan5/raylib/tree/master/examples) for missing examples

installation
---

```
$ dotnet add package Raylib-cs.BleedingEdge --prerelease
$ dotnet add package Raylib-cs.BleedingEdge.Runtimes --prerelease
```

if you need...
---

- ... just runtimes: install `Raylib-cs.BleedingEdge.Runtimes`.

- ... custom native build: uninstall `Raylib-cs.BleedingEdge.Runtimes` and
add [CompileNatives.props](https://raw.githubusercontent.com/danilwhale/Raylib-cs.BleedingEdge/refs/heads/main/Raylib-cs.BleedingEdge.Native/CompileNatives.props)
to your project and import it (add `<Import Project="CompileNatives.props"/>`). You also need to clone [raylib](https://github.com/raysan5/raylib) repo and specify path to it in the `CustomNatives.props` (by default it's `../raylib`)

- ... to compile a static library: add `<CompileShared>false</CompileShared>` to your project's `PropertyGroup`. Note that you need custom native build setup for this (read above).

- ... prebuilt static library: you can get it from [GitHub Actions](https://github.com/danilwhale/Raylib-cs.BleedingEdge/actions/workflows/build-static-natives.yaml). if you don't have a GitHub account, use [nightly.link](https://nightly.link/danilwhale/Raylib-cs.BleedingEdge/workflows/build-static-natives.yaml/main)

"hello, world!"
---

```csharp
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

const int screenWidth = 800;
const int screenHeight = 450;

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