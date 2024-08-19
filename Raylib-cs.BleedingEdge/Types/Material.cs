using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Types;

/// <summary>
/// Material, includes shader and maps
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Material
{
    /// <summary>
    /// Material shader
    /// </summary>
    public Shader Shader;

    /// <summary>
    /// Material maps array (MAX_MATERIAL_MAPS)
    /// </summary>
    public unsafe MaterialMap* Maps;

    /// <summary>
    /// Material generic parameters (if required)
    /// </summary>
    public unsafe fixed float Params[4];
}