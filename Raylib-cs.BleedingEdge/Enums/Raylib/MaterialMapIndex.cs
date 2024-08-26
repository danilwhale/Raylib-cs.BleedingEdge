namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Material map index
/// </summary>
public enum MaterialMapIndex
{
    /// <summary>
    /// Albedo material (same as: Diffuse)
    /// </summary>
    Albedo = 0,

    /// <summary>
    /// Metalness material (same as: Specular)
    /// </summary>
    Metalness,

    /// <summary>
    /// Normal material
    /// </summary>
    Normal,

    /// <summary>
    /// Roughness material
    /// </summary>
    Roughness,

    /// <summary>
    /// Ambient occlusion material
    /// </summary>
    Occlusion,

    /// <summary>
    /// Emission material
    /// </summary>
    Emission,

    /// <summary>
    /// Heightmap material
    /// </summary>
    Height,

    /// <summary>
    /// Cubemap material (NOTE: Uses GL_TEXTURE_CUBE_MAP)
    /// </summary>
    Cubemap,

    /// <summary>
    /// Irradiance material (NOTE: Uses GL_TEXTURE_CUBE_MAP)
    /// </summary>
    Irradiance,

    /// <summary>
    /// Brdf material
    /// </summary>
    Brdf,

    Diffuse = Albedo,
    Specular = Metalness
}