using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge.Enums;

namespace Raylib_cs.BleedingEdge;

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class Rlgl
{
    public const string Version = "5.0";

    /// <summary>
    /// GL_TEXTURE_WRAP_S
    /// </summary>
    public const uint TextureWrapS = 0x2802;

    /// <summary>
    /// GL_TEXTURE_WRAP_T
    /// </summary>
    public const uint TextureWrapT = 0x2803;

    /// <summary>
    /// GL_TEXTURE_MAG_FILTER
    /// </summary>
    public const uint TextureMagFilter = 0x2800;

    /// <summary>
    /// GL_TEXTURE_MIN_FILTER
    /// </summary>
    public const uint TextureMinFilter = 0x2801;

    /// <summary>
    /// GL_NEAREST
    /// </summary>
    public const uint TextureFilterNearest = 0x2600;

    /// <summary>
    /// GL_LINEAR
    /// </summary>
    public const uint TextureFilterLinear = 0x2601;

    /// <summary>
    /// GL_NEAREST_MIPMAP_NEAREST
    /// </summary>
    public const uint TextureFilterMipNearest = 0x2700;

    /// <summary>
    /// GL_NEAREST_MIPMAP_LINEAR
    /// </summary>
    public const uint TextureFilterNearestMipLinear = 0x2702;

    /// <summary>
    /// GL_LINEAR_MIPMAP_NEAREST
    /// </summary>
    public const uint TextureFilterLinearMipNearest = 0x2701;

    /// <summary>
    /// GL_LINEAR_MIPMAP_LINEAR
    /// </summary>
    public const uint TextureFilterMipLinear = 0x2703;

    /// <summary>
    /// Anisotropic filter (custom identifier)
    /// </summary>
    public const uint TextureFilterAnisotropic = 0x3000;

    /// <summary>
    /// Texture mipmap bias, percentage ratio (custom identifier)
    /// </summary>
    public const uint TextureMipmapBiasRatio = 0x4000;

    /// <summary>
    /// GL_REPEAT
    /// </summary>
    public const uint TextureWrapRepeat = 0x2901;

    /// <summary>
    /// GL_CLAMP_TO_EDGE
    /// </summary>
    public const uint TextureWrapClamp = 0x812F;

    /// <summary>
    /// GL_MIRRORED_REPEAT
    /// </summary>
    public const uint TextureWrapMirrorRepeat = 0x8370;

    /// <summary>
    /// GL_MIRROR_CLAMP_EXT
    /// </summary>
    public const uint TextureWrapMirrorClamp = 0x8742;

    /// <summary>
    /// GL_UNSIGNED_BYTE
    /// </summary>
    public const uint UnsignedByte = 0x1401;

    /// <summary>
    /// GL_FLOAT
    /// </summary>
    public const uint Float = 0x1406;

    /// <summary>
    /// GL_STREAM_DRAW
    /// </summary>
    public const uint StreamDraw = 0x88E0;

    /// <summary>
    /// GL_STREAM_READ
    /// </summary>
    public const uint StreamRead = 0x88E1;

    /// <summary>
    /// GL_STREAM_COPY
    /// </summary>
    public const uint StreamCopy = 0x88E2;

    /// <summary>
    /// GL_STATIC_DRAW
    /// </summary>
    public const uint StaticDraw = 0x88E4;

    /// <summary>
    /// GL_STATIC_READ
    /// </summary>
    public const uint StaticRead = 0x88E5;

    /// <summary>
    /// GL_STATIC_COPY
    /// </summary>
    public const uint StaticCopy = 0x88E6;

    /// <summary>
    /// GL_DYNAMIC_DRAW
    /// </summary>
    public const uint DynamicDraw = 0x88E8;

    /// <summary>
    /// GL_DYNAMIC_READ
    /// </summary>
    public const uint DynamicRead = 0x88E9;

    /// <summary>
    /// GL_DYNAMIC_COPY
    /// </summary>
    public const uint DynamicCopy = 0x88EA;

    /// <summary>
    /// GL_ZERO
    /// </summary>
    public const uint Zero = 0;

    /// <summary>
    /// GL_ONE
    /// </summary>
    public const uint One = 1;

    /// <summary>
    /// GL_SRC_COLOR
    /// </summary>
    public const uint SrcColor = 0x0300;

    /// <summary>
    /// GL_ONE_MINUS_SRC_COLOR
    /// </summary>
    public const uint OneMinusSrcColor = 0x0301;

    /// <summary>
    /// GL_SRC_ALPHA
    /// </summary>
    public const uint SrcAlpha = 0x0302;

    /// <summary>
    /// GL_ONE_MINUS_SRC_ALPHA
    /// </summary>
    public const uint OneMinusSrcAlpha = 0x0303;

    /// <summary>
    /// GL_DST_ALPHA
    /// </summary>
    public const uint DstAlpha = 0x0304;

    /// <summary>
    /// GL_ONE_MINUS_DST_ALPHA
    /// </summary>
    public const uint OneMinusDstAlpha = 0x0305;

    /// <summary>
    /// GL_DST_COLOR
    /// </summary>
    public const uint DstColor = 0x0306;

    /// <summary>
    /// GL_ONE_MINUS_DST_COLOR
    /// </summary>
    public const uint OneMinusDstColor = 0x0307;

    /// <summary>
    /// GL_SRC_ALPHA_SATURATE
    /// </summary>
    public const uint SrcAlphaSaturate = 0x0308;

    /// <summary>
    /// GL_CONSTANT_COLOR
    /// </summary>
    public const uint ConstantColor = 0x8001;

    /// <summary>
    /// GL_ONE_MINUS_CONSTANT_COLOR
    /// </summary>
    public const uint OneMinusConstantColor = 0x8002;

    /// <summary>
    /// GL_CONSTANT_ALPHA
    /// </summary>
    public const uint ConstantAlpha = 0x8003;

    /// <summary>
    /// GL_ONE_MINUS_CONSTANT_ALPHA
    /// </summary>
    public const uint OneMinusConstantAlpha = 0x8004;

    /// <summary>
    /// GL_FUNC_ADD
    /// </summary>
    public const uint FuncAdd = 0x8006;

    /// <summary>
    /// GL_MIN
    /// </summary>
    public const uint Min = 0x8007;

    /// <summary>
    /// GL_MAX
    /// </summary>
    public const uint Max = 0x8008;

    /// <summary>
    /// GL_FUNC_SUBTRACT
    /// </summary>
    public const uint FuncSubtract = 0x800A;

    /// <summary>
    /// GL_FUNC_REVERSE_SUBTRACT
    /// </summary>
    public const uint FuncReverseSubtract = 0x800B;

    /// <summary>
    /// GL_BLEND_EQUATION
    /// </summary>
    public const uint BlendEquation = 0x8009;

    /// <summary>
    /// GL_BLEND_EQUATION_RGB (Same as BLEND_EQUATION)
    /// </summary>
    public const uint BlendEquationRgb = 0x8009;

    /// <summary>
    /// GL_BLEND_EQUATION_ALPHA
    /// </summary>
    public const uint BlendEquationAlpha = 0x883D;

    /// <summary>
    /// GL_BLEND_DST_RGB
    /// </summary>
    public const uint BlendDstRgb = 0x80C8;

    /// <summary>
    /// GL_BLEND_SRC_RGB
    /// </summary>
    public const uint BlendSrcRgb = 0x80C9;

    /// <summary>
    /// GL_BLEND_DST_ALPHA
    /// </summary>
    public const uint BlendDstAlpha = 0x80CA;

    /// <summary>
    /// GL_BLEND_SRC_ALPHA
    /// </summary>
    public const uint BlendSrcAlpha = 0x80CB;

    /// <summary>
    /// GL_BLEND_COLOR
    /// </summary>
    public const uint BlendColor = 0x8005;

    /// <summary>
    /// GL_READ_FRAMEBUFFER
    /// </summary>
    public const uint ReadFramebuffer = 0x8CA8;

    /// <summary>
    /// GL_DRAW_FRAMEBUFFER
    /// </summary>
    public const uint DrawFramebuffer = 0x8CA9;

    private const string LibName = "raylib";

    /// <summary>
    /// Choose the current matrix to be transformed
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlMatrixMode")]
    public static partial void MatrixMode(MatrixMode mode);

    /// <summary>
    /// Push the current matrix to stack
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlPushMatrix")]
    public static partial void PushMatrix();

    /// <summary>
    /// Pop latest inserted matrix from stack
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlPopMatrix")]
    public static partial void PopMatrix();

    /// <summary>
    /// Reset current matrix to identity matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadIdentity")]
    public static partial void LoadIdentity();

    /// <summary>
    /// Multiply the current matrix by a translation matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlTranslatef")]
    public static partial void Translatef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by a rotation matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlRotatef")]
    public static partial void Rotatef(float angle, float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by a scaling matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlScalef")]
    public static partial void Scalef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by another matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlMultMatrixf")]
    public static partial void MultMatrixf(float* matf);

    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlFrustum")]
    public static partial void Frustum(double left, double right, double bottom, double top, double znear, double zfar);

    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlOrtho")]
    public static partial void Ortho(double left, double right, double bottom, double top, double znear, double zfar);

    /// <summary>
    /// Set the viewport area
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlViewport")]
    public static partial void Viewport(int x, int y, int width, int height);

    /// <summary>
    /// Set clip planes distances
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetClipPlanes")]
    public static partial void SetClipPlanes(double nearPlane, double farPlane);
    
    /// <summary>
    /// Get cull plane distance near
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetCullDistanceNear")]
    public static partial double GetCullDistanceNear();
    
    /// <summary>
    /// Get cull plane distance far
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetCullDistanceFar")]
    public static partial double GetCullDistanceFar();
}