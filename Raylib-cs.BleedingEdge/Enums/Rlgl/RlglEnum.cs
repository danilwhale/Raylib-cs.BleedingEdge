namespace Raylib_cs.BleedingEdge;

public enum RlglEnum : uint
{
    // Texture parameters (equivalent to OpenGL defines)
    /// <summary>
    /// GL_TEXTURE_WRAP_S
    /// </summary>
    TextureWrapS = 0x2802,

    /// <summary>
    /// GL_TEXTURE_WRAP_T
    /// </summary>
    TextureWrapT = 0x2803,

    /// <summary>
    /// GL_TEXTURE_MAG_FILTER
    /// </summary>
    TextureMagFilter = 0x2800,

    /// <summary>
    /// GL_TEXTURE_MIN_FILTER
    /// </summary>
    TextureMinFilter = 0x2801,

    /// <summary>
    /// GL_NEAREST
    /// </summary>
    TextureFilterNearest = 0x2600,

    /// <summary>
    /// GL_LINEAR
    /// </summary>
    TextureFilterLinear = 0x2601,

    /// <summary>
    /// GL_NEAREST_MIPMAP_NEAREST
    /// </summary>
    TextureFilterMipNearest = 0x2700,

    /// <summary>
    /// GL_NEAREST_MIPMAP_LINEAR
    /// </summary>
    TextureFilterNearestMipLinear = 0x2702,

    /// <summary>
    /// GL_LINEAR_MIPMAP_NEAREST
    /// </summary>
    TextureFilterLinearMipNearest = 0x2701,

    /// <summary>
    /// GL_LINEAR_MIPMAP_LINEAR
    /// </summary>
    TextureFilterMipLinear = 0x2703,

    /// <summary>
    /// Anisotropic filter (custom identifier)
    /// </summary>
    TextureFilterAnisotropic = 0x3000,

    /// <summary>
    /// Texture mipmap bias, percentage ratio (custom identifier)
    /// </summary>
    TextureMipmapBiasRatio = 0x4000,

    /// <summary>
    /// GL_REPEAT
    /// </summary>
    TextureWrapRepeat = 0x2901,

    /// <summary>
    /// GL_CLAMP_TO_EDGE
    /// </summary>
    TextureWrapClamp = 0x812F,

    /// <summary>
    /// GL_MIRRORED_REPEAT
    /// </summary>
    TextureWrapMirrorRepeat = 0x8370,

    /// <summary>
    /// GL_MIRROR_CLAMP_EXT
    /// </summary>
    TextureWrapMirrorClamp = 0x8742,

// Matrix modes (equivalent to OpenGL)
    /// <summary>
    /// GL_MODELVIEW
    /// </summary>
    Modelview = 0x1700,

    /// <summary>
    /// GL_PROJECTION
    /// </summary>
    Projection = 0x1701,

    /// <summary>
    /// GL_TEXTURE
    /// </summary>
    Texture = 0x1702,

// Primitive assembly draw modes
    /// <summary>
    /// GL_LINES
    /// </summary>
    Lines = 0x0001,

    /// <summary>
    /// GL_TRIANGLES
    /// </summary>
    Triangles = 0x0004,

    /// <summary>
    /// GL_QUADS
    /// </summary>
    Quads = 0x0007,

// GL equivalent data types
    /// <summary>
    /// GL_UNSIGNED_BYTE
    /// </summary>
    UnsignedByte = 0x1401,

    /// <summary>
    /// GL_FLOAT
    /// </summary>
    Float = 0x1406,

// GL buffer usage hint
    /// <summary>
    /// GL_STREAM_DRAW
    /// </summary>
    StreamDraw = 0x88E0,

    /// <summary>
    /// GL_STREAM_READ
    /// </summary>
    StreamRead = 0x88E1,

    /// <summary>
    /// GL_STREAM_COPY
    /// </summary>
    StreamCopy = 0x88E2,

    /// <summary>
    /// GL_STATIC_DRAW
    /// </summary>
    StaticDraw = 0x88E4,

    /// <summary>
    /// GL_STATIC_READ
    /// </summary>
    StaticRead = 0x88E5,

    /// <summary>
    /// GL_STATIC_COPY
    /// </summary>
    StaticCopy = 0x88E6,

    /// <summary>
    /// GL_DYNAMIC_DRAW
    /// </summary>
    DynamicDraw = 0x88E8,

    /// <summary>
    /// GL_DYNAMIC_READ
    /// </summary>
    DynamicRead = 0x88E9,

    /// <summary>
    /// GL_DYNAMIC_COPY
    /// </summary>
    DynamicCopy = 0x88EA,

// GL Shader type
    /// <summary>
    /// GL_FRAGMENT_SHADER
    /// </summary>
    FragmentShader = 0x8B30,

    /// <summary>
    /// GL_VERTEX_SHADER
    /// </summary>
    VertexShader = 0x8B31,

    /// <summary>
    /// GL_COMPUTE_SHADER
    /// </summary>
    ComputeShader = 0x91B9,

// GL blending factors
    /// <summary>
    /// GL_ZERO
    /// </summary>
    Zero = 0,

    /// <summary>
    /// GL_ONE
    /// </summary>
    One = 1,

    /// <summary>
    /// GL_SRC_COLOR
    /// </summary>
    SrcColor = 0x0300,

    /// <summary>
    /// GL_ONE_MINUS_SRC_COLOR
    /// </summary>
    OneMinusSrcColor = 0x0301,

    /// <summary>
    /// GL_SRC_ALPHA
    /// </summary>
    SrcAlpha = 0x0302,

    /// <summary>
    /// GL_ONE_MINUS_SRC_ALPHA
    /// </summary>
    OneMinusSrcAlpha = 0x0303,

    /// <summary>
    /// GL_DST_ALPHA
    /// </summary>
    DstAlpha = 0x0304,

    /// <summary>
    /// GL_ONE_MINUS_DST_ALPHA
    /// </summary>
    OneMinusDstAlpha = 0x0305,

    /// <summary>
    /// GL_DST_COLOR
    /// </summary>
    DstColor = 0x0306,

    /// <summary>
    /// GL_ONE_MINUS_DST_COLOR
    /// </summary>
    OneMinusDstColor = 0x0307,

    /// <summary>
    /// GL_SRC_ALPHA_SATURATE
    /// </summary>
    SrcAlphaSaturate = 0x0308,

    /// <summary>
    /// GL_CONSTANT_COLOR
    /// </summary>
    ConstantColor = 0x8001,

    /// <summary>
    /// GL_ONE_MINUS_CONSTANT_COLOR
    /// </summary>
    OneMinusConstantColor = 0x8002,

    /// <summary>
    /// GL_CONSTANT_ALPHA
    /// </summary>
    ConstantAlpha = 0x8003,

    /// <summary>
    /// GL_ONE_MINUS_CONSTANT_ALPHA
    /// </summary>
    OneMinusConstantAlpha = 0x8004,

// GL blending functions/equations
    /// <summary>
    /// GL_FUNC_ADD
    /// </summary>
    FuncAdd = 0x8006,

    /// <summary>
    /// GL_MIN
    /// </summary>
    Min = 0x8007,

    /// <summary>
    /// GL_MAX
    /// </summary>
    Max = 0x8008,

    /// <summary>
    /// GL_FUNC_SUBTRACT
    /// </summary>
    FuncSubtract = 0x800A,

    /// <summary>
    /// GL_FUNC_REVERSE_SUBTRACT
    /// </summary>
    FuncReverseSubtract = 0x800B,

    /// <summary>
    /// GL_BLEND_EQUATION
    /// </summary>
    BlendEquation = 0x8009,

    /// <summary>
    /// GL_BLEND_EQUATION_RGB   // (Same as BLEND_EQUATION)
    /// </summary>
    BlendEquationRgb = 0x8009,

    /// <summary>
    /// GL_BLEND_EQUATION_ALPHA
    /// </summary>
    BlendEquationAlpha = 0x883D,

    /// <summary>
    /// GL_BLEND_DST_RGB
    /// </summary>
    BlendDstRgb = 0x80C8,

    /// <summary>
    /// GL_BLEND_SRC_RGB
    /// </summary>
    BlendSrcRgb = 0x80C9,

    /// <summary>
    /// GL_BLEND_DST_ALPHA
    /// </summary>
    BlendDstAlpha = 0x80CA,

    /// <summary>
    /// GL_BLEND_SRC_ALPHA
    /// </summary>
    BlendSrcAlpha = 0x80CB,

    /// <summary>
    /// GL_BLEND_COLOR
    /// </summary>
    BlendColor = 0x8005,

    /// <summary>
    /// GL_READ_FRAMEBUFFER
    /// </summary>
    ReadFramebuffer = 0x8CA8,

    /// <summary>
    /// GL_DRAW_FRAMEBUFFER
    /// </summary>
    DrawFramebuffer = 0x8CA9,
}