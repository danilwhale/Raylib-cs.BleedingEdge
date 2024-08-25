namespace Raylib_cs.BleedingEdge.Enums.Raylib;

/// <summary>
/// Shader uniform data type
/// </summary>
public enum ShaderUniformDataType
{
    /// <summary>
    /// Shader uniform type: float
    /// </summary>
    Float = 0,

    /// <summary>
    /// Shader uniform type: vec2 (2 float)
    /// </summary>
    Vec2,

    /// <summary>
    /// Shader uniform type: vec3 (3 float)
    /// </summary>
    Vec3,

    /// <summary>
    /// Shader uniform type: vec4 (4 float)
    /// </summary>
    Vec4,

    /// <summary>
    /// Shader uniform type: int
    /// </summary>
    Int,

    /// <summary>
    /// Shader uniform type: ivec2 (2 int)
    /// </summary>
    IVec2,

    /// <summary>
    /// Shader uniform type: ivec3 (3 int)
    /// </summary>
    IVec3,

    /// <summary>
    /// Shader uniform type: ivec4 (4 int)
    /// </summary>
    IVec4,

    /// <summary>
    /// Shader uniform type: unsigned int
    /// </summary>
    UInt,

    /// <summary>
    /// Shader uniform type: uivec2 (2 unsigned int)
    /// </summary>
    UIVec2,

    /// <summary>
    /// Shader uniform type: uivec3 (3 unsigned int)
    /// </summary>
    UIVec3,

    /// <summary>
    /// Shader uniform type: uivec4 (4 unsigned int)
    /// </summary>
    UIVec4,

    /// <summary>
    /// Shader uniform type: sampler2d
    /// </summary>
    Sampler2D
}