<img src="Assets/Logo-256.png" style="width:96px;margin-right:10px" align="left" alt="logo">

### Raylib-cs.BleedingEdge
C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

---

> TODO: add nuget package badge

Raylib-cs.BleedingEdge targets .NET 8+ and uses [the master branch of raylib repo](https://github.com/raysan5/raylib/tree/master)

> [!WARNING]
> there are still no examples, you can rely on Raylib-cs' examples
> as this binding has mostly same function signatures (see [code differences](#code-differences))

## differences from [Raylib-cs](https://github.com/ChrisDill/Raylib-cs)
### main differences
| Raylib-cs        | Raylib-cs.BleedingEdge  |
|------------------|-------------------------|
| .NET 6.0+        | .NET 8.0+               |
| Released 07-2018 | Released 08-2024        |
| raylib 5.0       | raylib 5.5-dev (master) |

### code differences
###### `*` means *any*, e.g. `*Span<T>` can be `Span<T>` or `ReadOnlySpan<T>`
| Raylib-cs                                           | Raylib-cs.BleedingEdge                                   |
|-----------------------------------------------------|----------------------------------------------------------|
| `using Raylib-cs`                                   | `using Raylib-cs.BleedingEdge`                           |
| `T[]` for functions with pointers                   | `Span<T>` for functions with pointers                    |
| `Function_()` as `string` variant                   | `FunctionString()` as `string` variant                   |
| `int` argument for the length of array              | -, use `Span<T>.Slice` if necessary                      |
| `Function()` -> `sbyte*`; `Function_()` -> `string` | `Function()` -> `sbyte*`; `FunctionString()` -> `string` |
| `Utf8Buffer`                                        | `Utf8Handle`                                             |
| `New<T>(uint)`                                      | `MemAlloc<T>(uint)`                                      |
| `Get*` (`GetDroppedFiles`)                          | -, use `Load*`, `Unload*` (`Load/UnloadDroppedFiles`)    |