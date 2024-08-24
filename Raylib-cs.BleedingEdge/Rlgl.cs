using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge.Enums;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge.Types;

namespace Raylib_cs.BleedingEdge;

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class Rlgl
{
    public const string Version = "5.0";

    /// <summary>
    /// GL_TEXTURE_WRAP_S
    /// </summary>
    public const int TextureWrapS = 0x2802;

    /// <summary>
    /// GL_TEXTURE_WRAP_T
    /// </summary>
    public const int TextureWrapT = 0x2803;

    /// <summary>
    /// GL_TEXTURE_MAG_FILTER
    /// </summary>
    public const int TextureMagFilter = 0x2800;

    /// <summary>
    /// GL_TEXTURE_MIN_FILTER
    /// </summary>
    public const int TextureMinFilter = 0x2801;

    /// <summary>
    /// GL_NEAREST
    /// </summary>
    public const int TextureFilterNearest = 0x2600;

    /// <summary>
    /// GL_LINEAR
    /// </summary>
    public const int TextureFilterLinear = 0x2601;

    /// <summary>
    /// GL_NEAREST_MIPMAP_NEAREST
    /// </summary>
    public const int TextureFilterMipNearest = 0x2700;

    /// <summary>
    /// GL_NEAREST_MIPMAP_LINEAR
    /// </summary>
    public const int TextureFilterNearestMipLinear = 0x2702;

    /// <summary>
    /// GL_LINEAR_MIPMAP_NEAREST
    /// </summary>
    public const int TextureFilterLinearMipNearest = 0x2701;

    /// <summary>
    /// GL_LINEAR_MIPMAP_LINEAR
    /// </summary>
    public const int TextureFilterMipLinear = 0x2703;

    /// <summary>
    /// Anisotropic filter (custom identifier)
    /// </summary>
    public const int TextureFilterAnisotropic = 0x3000;

    /// <summary>
    /// Texture mipmap bias, percentage ratio (custom identifier)
    /// </summary>
    public const int TextureMipmapBiasRatio = 0x4000;

    /// <summary>
    /// GL_REPEAT
    /// </summary>
    public const int TextureWrapRepeat = 0x2901;

    /// <summary>
    /// GL_CLAMP_TO_EDGE
    /// </summary>
    public const int TextureWrapClamp = 0x812F;

    /// <summary>
    /// GL_MIRRORED_REPEAT
    /// </summary>
    public const int TextureWrapMirrorRepeat = 0x8370;

    /// <summary>
    /// GL_MIRROR_CLAMP_EXT
    /// </summary>
    public const int TextureWrapMirrorClamp = 0x8742;

    /// <summary>
    /// GL_UNSIGNED_BYTE
    /// </summary>
    public const int UnsignedByte = 0x1401;

    /// <summary>
    /// GL_FLOAT
    /// </summary>
    public const int Float = 0x1406;

    /// <summary>
    /// GL_STREAM_DRAW
    /// </summary>
    public const int StreamDraw = 0x88E0;

    /// <summary>
    /// GL_STREAM_READ
    /// </summary>
    public const int StreamRead = 0x88E1;

    /// <summary>
    /// GL_STREAM_COPY
    /// </summary>
    public const int StreamCopy = 0x88E2;

    /// <summary>
    /// GL_STATIC_DRAW
    /// </summary>
    public const int StaticDraw = 0x88E4;

    /// <summary>
    /// GL_STATIC_READ
    /// </summary>
    public const int StaticRead = 0x88E5;

    /// <summary>
    /// GL_STATIC_COPY
    /// </summary>
    public const int StaticCopy = 0x88E6;

    /// <summary>
    /// GL_DYNAMIC_DRAW
    /// </summary>
    public const int DynamicDraw = 0x88E8;

    /// <summary>
    /// GL_DYNAMIC_READ
    /// </summary>
    public const int DynamicRead = 0x88E9;

    /// <summary>
    /// GL_DYNAMIC_COPY
    /// </summary>
    public const int DynamicCopy = 0x88EA;

    /// <summary>
    /// GL_ZERO
    /// </summary>
    public const int Zero = 0;

    /// <summary>
    /// GL_ONE
    /// </summary>
    public const int One = 1;

    /// <summary>
    /// GL_SRC_COLOR
    /// </summary>
    public const int SrcColor = 0x0300;

    /// <summary>
    /// GL_ONE_MINUS_SRC_COLOR
    /// </summary>
    public const int OneMinusSrcColor = 0x0301;

    /// <summary>
    /// GL_SRC_ALPHA
    /// </summary>
    public const int SrcAlpha = 0x0302;

    /// <summary>
    /// GL_ONE_MINUS_SRC_ALPHA
    /// </summary>
    public const int OneMinusSrcAlpha = 0x0303;

    /// <summary>
    /// GL_DST_ALPHA
    /// </summary>
    public const int DstAlpha = 0x0304;

    /// <summary>
    /// GL_ONE_MINUS_DST_ALPHA
    /// </summary>
    public const int OneMinusDstAlpha = 0x0305;

    /// <summary>
    /// GL_DST_COLOR
    /// </summary>
    public const int DstColor = 0x0306;

    /// <summary>
    /// GL_ONE_MINUS_DST_COLOR
    /// </summary>
    public const int OneMinusDstColor = 0x0307;

    /// <summary>
    /// GL_SRC_ALPHA_SATURATE
    /// </summary>
    public const int SrcAlphaSaturate = 0x0308;

    /// <summary>
    /// GL_CONSTANT_COLOR
    /// </summary>
    public const int ConstantColor = 0x8001;

    /// <summary>
    /// GL_ONE_MINUS_CONSTANT_COLOR
    /// </summary>
    public const int OneMinusConstantColor = 0x8002;

    /// <summary>
    /// GL_CONSTANT_ALPHA
    /// </summary>
    public const int ConstantAlpha = 0x8003;

    /// <summary>
    /// GL_ONE_MINUS_CONSTANT_ALPHA
    /// </summary>
    public const int OneMinusConstantAlpha = 0x8004;

    /// <summary>
    /// GL_FUNC_ADD
    /// </summary>
    public const int FuncAdd = 0x8006;

    /// <summary>
    /// GL_MIN
    /// </summary>
    public const int Min = 0x8007;

    /// <summary>
    /// GL_MAX
    /// </summary>
    public const int Max = 0x8008;

    /// <summary>
    /// GL_FUNC_SUBTRACT
    /// </summary>
    public const int FuncSubtract = 0x800A;

    /// <summary>
    /// GL_FUNC_REVERSE_SUBTRACT
    /// </summary>
    public const int FuncReverseSubtract = 0x800B;

    /// <summary>
    /// GL_BLEND_EQUATION
    /// </summary>
    public const int BlendEquation = 0x8009;

    /// <summary>
    /// GL_BLEND_EQUATION_RGB (Same as BLEND_EQUATION)
    /// </summary>
    public const int BlendEquationRgb = 0x8009;

    /// <summary>
    /// GL_BLEND_EQUATION_ALPHA
    /// </summary>
    public const int BlendEquationAlpha = 0x883D;

    /// <summary>
    /// GL_BLEND_DST_RGB
    /// </summary>
    public const int BlendDstRgb = 0x80C8;

    /// <summary>
    /// GL_BLEND_SRC_RGB
    /// </summary>
    public const int BlendSrcRgb = 0x80C9;

    /// <summary>
    /// GL_BLEND_DST_ALPHA
    /// </summary>
    public const int BlendDstAlpha = 0x80CA;

    /// <summary>
    /// GL_BLEND_SRC_ALPHA
    /// </summary>
    public const int BlendSrcAlpha = 0x80CB;

    /// <summary>
    /// GL_BLEND_COLOR
    /// </summary>
    public const int BlendColor = 0x8005;

    /// <summary>
    /// GL_READ_FRAMEBUFFER
    /// </summary>
    public const int ReadFramebuffer = 0x8CA8;

    /// <summary>
    /// GL_DRAW_FRAMEBUFFER
    /// </summary>
    public const int DrawFramebuffer = 0x8CA9;

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
    
    /// <summary>
    /// Initialize drawing mode (how to organize vertex)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlBegin")]
    public static partial void Begin(DrawMode mode);

    /// <summary>
    /// Finish vertex providing
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnd")]
    public static partial void End();

    /// <summary>
    /// Define one vertex (position) - 2 int
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlVertex2i")]
    public static partial void Vertex2i(int x, int y);

    /// <summary>
    /// Define one vertex (position) - 2 float
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlVertex2f")]
    public static partial void Vertex2f(float x, float y);

    /// <summary>
    /// Define one vertex (position) - 3 float
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlVertex3f")]
    public static partial void Vertex3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (texture coordinate) - 2 float
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlTexCoord2f")]
    public static partial void TexCoord2f(float x, float y);

    /// <summary>
    /// Define one vertex (normal) - 3 float
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlNormal3f")]
    public static partial void Normal3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (color) - 4 byte
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlColor4ub")]
    public static partial void Color4ub(byte r, byte g, byte b, byte a);

    /// <summary>
    /// Define one vertex (color) - 3 float
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlColor3f")]
    public static partial void Color3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (color) - 4 float
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlColor4f")]
    public static partial void Color4f(float x, float y, float z, float w);

    /// <summary>
    /// Enable vertex array (VAO, if supported)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableVertexArray")]
    public static partial NativeBool EnableVertexArray(uint vaoId);

    /// <summary>
    /// Disable vertex array (VAO, if supported)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableVertexArray")]
    public static partial void DisableVertexArray();

    /// <summary>
    /// Enable vertex buffer (VBO)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableVertexBuffer")]
    public static partial void EnableVertexBuffer(uint id);
    
    /// <summary>
    /// Disable vertex buffer (VBO)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableVertexBuffer")]
    public static partial void DisableVertexBuffer();

    /// <summary>
    /// Enable vertex buffer element (VBO element)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableVertexBufferElement")]
    public static partial void EnableVertexBufferElement(uint id);

    /// <summary>
    /// Disable vertex buffer element (VBO element)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableVertexBufferElement")]
    public static partial void DisableVertexBufferElement();

    /// <summary>
    /// Enable vertex attribute index
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableVertexAttribute")]
    public static partial void EnableVertexAttribute(uint index);

    /// <summary>
    /// Disable vertex attribute index
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableVertexAttribute")]
    public static partial void DisableVertexAttribute(uint index);

    /// <summary>
    /// Enable attribute state pointer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableStatePointer")]
    public static partial void EnableStatePointer(int vertexAttribType, void* buffer);

    /// <summary>
    /// Disable attribute state pointer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableStatePointer")]
    public static partial void DisableStatePointer(int vertexAttribType);

    /// <summary>
    /// Select and active a texture slot
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlActiveTextureSlot")]
    public static partial void ActiveTextureSlot(int slot);

    /// <summary>
    /// Enable texture
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableTexture")]
    public static partial void EnableTexture(uint id);

    /// <summary>
    /// Disable texture
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableTexture")]
    public static partial void DisableTexture();

    /// <summary>
    /// Enable texture cubemap
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableTextureCubemap")]
    public static partial void EnableTextureCubemap(uint id);

    /// <summary>
    /// Disable texture cubemap
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableTextureCubemap")]
    public static partial void DisableTextureCubemap();

    /// <summary>
    /// Set texture parameters (filter, wrap)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlTextureParameters")]
    public static partial void TextureParameters(uint id, int param, int value);

    /// <summary>
    /// Set cubemap parameters (filter, wrap)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlCubemapParameters")]
    public static partial void CubemapParameters(uint id, int param, int value);

    /// <summary>
    /// Enable shader program
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableShader")]
    public static partial void EnableShader(uint id);

    /// <summary>
    /// Disable shader program
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableShader")]
    public static partial void DisableShader();

    /// <summary>
    /// Enable render texture (fbo)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableFramebuffer")]
    public static partial void EnableFramebuffer(uint id);

    /// <summary>
    /// Disable render texture (fbo), return to default framebuffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableFramebuffer")]
    public static partial void DisableFramebuffer();

    /// <summary>
    /// Get the currently active render texture (fbo), 0 for default framebuffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetActiveFramebuffer")]
    public static partial uint GetActiveFramebuffer();

    /// <summary>
    /// Activate multiple draw color buffers
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlActiveDrawBuffers")]
    public static partial void ActiveDrawBuffers(int count);

    /// <summary>
    /// Blit active framebuffer to main framebuffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlBlitFramebuffer")]
    public static partial void BlitFramebuffer(int srcX, int srcY, int srcHeight, int dstX, int dstY, int dstWidth, int dstHeight, int bufferMask);

    /// <summary>
    /// Bind framebuffer (FBO)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlBindFramebuffer")]
    public static partial void BindFramebuffer(uint target, uint framebuffer);

    /// <summary>
    /// Enable color blending
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableColorBlend")]
    public static partial void EnableColorBlend();

    /// <summary>
    /// Disable color blending
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableColorBlend")]
    public static partial void DisableColorBlend();

    /// <summary>
    /// Enable depth test
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableDepthTest")]
    public static partial void EnableDepthTest();

    /// <summary>
    /// Disable depth test
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableDepthTest")]
    public static partial void DisableDepthTest();

    /// <summary>
    /// Enable depth write
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableDepthMask")]
    public static partial void EnableDepthMask();

    /// <summary>
    /// Disable depth write
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableDepthMask")]
    public static partial void DisableDepthMask();

    /// <summary>
    /// Enable backface culling
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableBackfaceCulling")]
    public static partial void EnableBackfaceCulling();

    /// <summary>
    /// Disable backface culling
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableBackfaceCulling")]
    public static partial void DisableBackfaceCulling();

    /// <summary>
    /// Color mask control
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlColorMask")]
    public static partial void ColorMask(NativeBool r, NativeBool g, NativeBool b, NativeBool a);

    /// <summary>
    /// Set face culling mode
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetCullFace")]
    public static partial void SetCullFace(CullMode mode);

    /// <summary>
    /// Enable scissor test
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableScissorTest")]
    public static partial void EnableScissorTest();

    /// <summary>
    /// Disable scissor test
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableScissorTest")]
    public static partial void DisableScissorTest();

    /// <summary>
    /// Scissor test
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlScissor")]
    public static partial void Scissor(int x, int y, int width, int height);

    /// <summary>
    /// Enable wire mode
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableWireMode")]
    public static partial void EnableWireMode();

    /// <summary>
    /// Enable point mode
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnablePointMode")]
    public static partial void EnablePointMode();

    /// <summary>
    /// Disable wire mode ( and point ) maybe rename
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableWireMode")]
    public static partial void DisableWireMode();

    /// <summary>
    /// Set the line drawing width
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetLineWidth")]
    public static partial void SetLineWidth(float width);

    /// <summary>
    /// Get the line drawing width
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetLineWidth")]
    public static partial float GetLineWidth();

    /// <summary>
    /// Enable line aliasing
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableSmoothLines")]
    public static partial void EnableSmoothLines();

    /// <summary>
    /// Disable line aliasing
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableSmoothLines")]
    public static partial void DisableSmoothLines();

    /// <summary>
    /// Enable stereo rendering
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlEnableStereoRender")]
    public static partial void EnableStereoRender();

    /// <summary>
    /// Disable stereo rendering
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDisableStereoRender")]
    public static partial void DisableStereoRender();

    /// <summary>
    /// Check if stereo render is enabled
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlIsStereoRenderEnabled")]
    public static partial NativeBool IsStereoRenderEnabled();

    /// <summary>
    /// Clear color buffer with color
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlClearColor")]
    public static partial void ClearColor(byte r, byte g, byte b, byte a);

    /// <summary>
    /// Clear used screen buffers (color and depth)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlClearScreenBuffers")]
    public static partial void ClearScreenBuffers();

    /// <summary>
    /// Check and log OpenGL error codes
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlCheckErrors")]
    public static partial void CheckErrors();

    /// <summary>
    /// Set blending mode
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetBlendMode")]
    public static partial void SetBlendMode(BlendMode mode);

    /// <summary>
    /// Set blending mode factor and equation (using OpenGL factors)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetBlendFactors")]
    public static partial void SetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

    /// <summary>
    /// Set blending mode factors and equations separately (using OpenGL factors)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetBlendFactorsSeparate")]
    public static partial void SetBlendFactorsSeparate(int glSrcRGB, int glDstRGB, int glSrcAlpha, int glDstAlpha, int glEqRGB, int glEqAlpha);

    /// <summary>
    /// Initialize rlgl (buffers, shaders, textures, states)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlInit")]
    public static partial void Init(int width, int height);

    /// <summary>
    /// De-initialize rlgl (buffers, shaders, textures)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlClose")]
    public static partial void Close();

    /// <summary>
    /// Load OpenGL extensions (loader function required)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadExtensions")]
    public static partial void LoadExtensions(void* loader);

    /// <summary>
    /// Get current OpenGL version
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetVersion")]
    public static partial GlVersion GetVersion();

    /// <summary>
    /// Set current framebuffer width
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetFramebufferWidth")]
    public static partial void SetFramebufferWidth(int width);

    /// <summary>
    /// Get default framebuffer width
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetFramebufferWidth")]
    public static partial int GetFramebufferWidth();

    /// <summary>
    /// Set current framebuffer height
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetFramebufferHeight")]
    public static partial void SetFramebufferHeight(int height);

    /// <summary>
    /// Get default framebuffer height
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetFramebufferHeight")]
    public static partial int GetFramebufferHeight();

    /// <summary>
    /// Get default texture id
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetTextureIdDefault")]
    public static partial uint GetTextureIdDefault();

    /// <summary>
    /// Get default shader id
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetShaderIdDefault")]
    public static partial uint GetShaderIdDefault();

    /// <summary>
    /// Get default shader locations
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetShaderLocsDefault")]
    public static partial int* GetShaderLocsDefault();

    /// <summary>
    /// Load a render batch system
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadRenderBatch")]
    public static partial RenderBatch LoadRenderBatch(int numBuffers, int bufferElements);

    /// <summary>
    /// Unload render batch system
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadRenderBatch")]
    public static partial void UnloadRenderBatch(RenderBatch batch);

    /// <summary>
    /// Draw render batch data (Update->Draw->Reset)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDrawRenderBatch")]
    public static partial void DrawRenderBatch(RenderBatch* batch);

    /// <summary>
    /// Set the active render batch for rlgl (NULL for default internal)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetRenderBatchActive")]
    public static partial void SetRenderBatchActive(RenderBatch* batch);

    /// <summary>
    /// Update and draw internal render batch
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDrawRenderBatchActive")]
    public static partial void DrawRenderBatchActive();

    /// <summary>
    /// Check internal buffer overflow for a given number of vertex
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlCheckRenderBatchLimit")]
    public static partial NativeBool CheckRenderBatchLimit(int vCount);

    /// <summary>
    /// Set current texture for render batch and check buffers limits
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetTexture")]
    public static partial void SetTexture(uint id);

    /// <summary>
    /// Load vertex array (vao) if supported
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadVertexArray")]
    public static partial uint LoadVertexArray();

    /// <summary>
    /// Load a vertex buffer object
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadVertexBuffer")]
    public static partial uint LoadVertexBuffer(void* buffer, int size, NativeBool @dynamic);

    /// <summary>
    /// Load vertex buffer elements object
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadVertexBufferElement")]
    public static partial uint LoadVertexBufferElement(void* buffer, int size, NativeBool @dynamic);

    /// <summary>
    /// Update vertex buffer object data on GPU buffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUpdateVertexBuffer")]
    public static partial void UpdateVertexBuffer(uint bufferId, void* data, int dataSize, int offset);

    /// <summary>
    /// Update vertex buffer elements data on GPU buffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUpdateVertexBufferElements")]
    public static partial void UpdateVertexBufferElements(uint id, void* data, int dataSize, int offset);

    /// <summary>
    /// Unload vertex array (vao)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadVertexArray")]
    public static partial void UnloadVertexArray(uint vaoId);

    /// <summary>
    /// Unload vertex buffer object
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadVertexBuffer")]
    public static partial void UnloadVertexBuffer(uint vboId);

    /// <summary>
    /// Set vertex attribute data configuration
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetVertexAttribute")]
    public static partial void SetVertexAttribute(uint index, int compSize, int type, NativeBool normalized, int stride, int offset);

    /// <summary>
    /// Set vertex attribute data divisor
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetVertexAttributeDivisor")]
    public static partial void SetVertexAttributeDivisor(uint index, int divisor);

    /// <summary>
    /// Set vertex attribute default value, when attribute to provided
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetVertexAttributeDefault")]
    public static partial void SetVertexAttributeDefault(int locIndex, void* value, ShaderAttributeDataType attribType, int count);

    /// <summary>
    /// Draw vertex array (currently active vao)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDrawVertexArray")]
    public static partial void DrawVertexArray(int offset, int count);

    /// <summary>
    /// Draw vertex array elements
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDrawVertexArrayElements")]
    public static partial void DrawVertexArrayElements(int offset, int count, void* buffer);

    /// <summary>
    /// Draw vertex array (currently active vao) with instancing
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDrawVertexArrayInstanced")]
    public static partial void DrawVertexArrayInstanced(int offset, int count, int instances);

    /// <summary>
    /// Draw vertex array elements with instancing
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlDrawVertexArrayElementsInstanced")]
    public static partial void DrawVertexArrayElementsInstanced(int offset, int count, void* buffer, int instances);

    /// <summary>
    /// Load texture data
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadTexture")]
    public static partial uint LoadTexture(void* data, int width, int height, PixelFormat format, int mipmapCount);

    /// <summary>
    /// Load depth texture/renderbuffer (to be attached to fbo)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadTextureDepth")]
    public static partial uint LoadTextureDepth(int width, int height, NativeBool useRenderBuffer);

    /// <summary>
    /// Load texture cubemap data
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadTextureCubemap")]
    public static partial uint LoadTextureCubemap(void* data, int size, PixelFormat format);

    /// <summary>
    /// Update texture with new data on GPU
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUpdateTexture")]
    public static partial void UpdateTexture(uint id, int offsetX, int offsetY, int width, int height, PixelFormat format, void* data);

    /// <summary>
    /// Get OpenGL internal formats
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetGlTextureFormats")]
    public static partial void GetGlTextureFormats(PixelFormat format, uint* glInternalFormat, uint* glFormat, uint* glType);

    /// <summary>
    /// Get name string for pixel format
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetPixelFormatName")]
    public static partial sbyte* GetPixelFormatName(PixelFormat format);

    /// <summary>
    /// Unload texture from GPU memory
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadTexture")]
    public static partial void UnloadTexture(uint id);

    /// <summary>
    /// Generate mipmap data for selected texture
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGenTextureMipmaps")]
    public static partial void GenTextureMipmaps(uint id, int width, int height, PixelFormat format, int* mipmaps);

    /// <summary>
    /// Read texture pixel data
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlReadTexturePixels")]
    public static partial void* ReadTexturePixels(uint id, int width, int height, PixelFormat format);

    /// <summary>
    /// Read screen pixel data (color buffer)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlReadScreenPixels")]
    public static partial byte* ReadScreenPixels(int width, int height);

    /// <summary>
    /// Load an empty framebuffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadFramebuffer")]
    public static partial uint LoadFramebuffer();

    /// <summary>
    /// Attach texture/renderbuffer to a framebuffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlFramebufferAttach")]
    public static partial void FramebufferAttach(uint fboId, uint texId, FramebufferAttachType attachType, FramebufferAttachTextureType texType, int mipLevel);

    /// <summary>
    /// Verify framebuffer is complete
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlFramebufferComplete")]
    public static partial void FramebufferComplete(uint id);

    /// <summary>
    /// Delete framebuffer from GPU
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadFramebuffer")]
    public static partial void UnloadFramebuffer(uint id);

    /// <summary>
    /// Load shader from code strings
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadShaderCode")]
    public static partial uint LoadShaderCode(sbyte* vsCode, sbyte* fsCode);

    /// <summary>
    /// Compile custom shader and return shader id (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlCompileShader")]
    public static partial uint CompileShader(sbyte* shaderCode, ShaderType type);

    /// <summary>
    /// Load custom shader program
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadShaderProgram")]
    public static partial uint LoadShaderProgram(uint vShaderId, uint fShaderId);

    /// <summary>
    /// Unload shader program
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadShaderProgram")]
    public static partial void UnloadShaderProgram(uint id);

    /// <summary>
    /// Get shader location uniform
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetLocationUniform")]
    public static partial int GetLocationUniform(uint shaderId, sbyte* uniformName);

    /// <summary>
    /// Get shader location attribute
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetLocationAttrib")]
    public static partial int GetLocationAttrib(uint shaderId, sbyte* attribName);

    /// <summary>
    /// Set shader value uniform
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetUniform")]
    public static partial void SetUniform(int locIndex, void* value, ShaderUniformDataType uniformType, int count);

    /// <summary>
    /// Set shader value matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetUniformMatrix")]
    public static partial void SetUniformMatrix(int locIndex, Matrix4x4 mat);

    /// <summary>
    /// Set shader value sampler
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetUniformSampler")]
    public static partial void SetUniformSampler(int locIndex, uint textureId);

    /// <summary>
    /// Set shader currently active (id and locations)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetShader")]
    public static partial void SetShader(uint id, int* locs);

    /// <summary>
    /// Load compute shader program
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadComputeShaderProgram")]
    public static partial uint LoadComputeShaderProgram(uint shaderId);

    /// <summary>
    /// Dispatch compute shader (equivalent to *draw* for graphics pipeline)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlComputeShaderDispatch")]
    public static partial void ComputeShaderDispatch(uint groupX, uint groupY, uint groupZ);

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadShaderBuffer")]
    public static partial uint LoadShaderBuffer(uint size, void* data, int usageHint);

    /// <summary>
    /// Unload shader storage buffer object (SSBO)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUnloadShaderBuffer")]
    public static partial void UnloadShaderBuffer(uint ssboId);

    /// <summary>
    /// Update SSBO buffer data
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlUpdateShaderBuffer")]
    public static partial void UpdateShaderBuffer(uint id, void* data, uint dataSize, uint offset);

    /// <summary>
    /// Bind SSBO buffer
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlBindShaderBuffer")]
    public static partial void BindShaderBuffer(uint id, uint index);

    /// <summary>
    /// Read SSBO buffer data (GPU->CPU)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlReadShaderBuffer")]
    public static partial void ReadShaderBuffer(uint id, void* dest, uint count, uint offset);

    /// <summary>
    /// Copy SSBO data between buffers
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlCopyShaderBuffer")]
    public static partial void CopyShaderBuffer(uint destId, uint srcId, uint destOffset, uint srcOffset, uint count);

    /// <summary>
    /// Get SSBO buffer size
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetShaderBufferSize")]
    public static partial uint GetShaderBufferSize(uint id);

    /// <summary>
    /// Bind image texture
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlBindImageTexture")]
    public static partial void BindImageTexture(uint id, uint index, PixelFormat format, NativeBool @readonly);

    /// <summary>
    /// Get internal modelview matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetMatrixModelview")]
    public static partial Matrix4x4 GetMatrixModelview();

    /// <summary>
    /// Get internal projection matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetMatrixProjection")]
    public static partial Matrix4x4 GetMatrixProjection();

    /// <summary>
    /// Get internal accumulated transform matrix
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetMatrixTransform")]
    public static partial Matrix4x4 GetMatrixTransform();

    /// <summary>
    /// Get internal projection matrix for stereo render (selected eye)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetMatrixProjectionStereo")]
    public static partial Matrix4x4 GetMatrixProjectionStereo(int eye);

    /// <summary>
    /// Get internal view offset matrix for stereo render (selected eye)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlGetMatrixViewOffsetStereo")]
    public static partial Matrix4x4 GetMatrixViewOffsetStereo(int eye);

    /// <summary>
    /// Set a custom projection matrix (replaces internal projection matrix)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetMatrixProjection")]
    public static partial void SetMatrixProjection(Matrix4x4 proj);

    /// <summary>
    /// Set a custom modelview matrix (replaces internal modelview matrix)
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetMatrixModelview")]
    public static partial void SetMatrixModelview(Matrix4x4 view);

    /// <summary>
    /// Set eyes projection matrices for stereo rendering
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetMatrixProjectionStereo")]
    public static partial void SetMatrixProjectionStereo(Matrix4x4 right, Matrix4x4 left);

    /// <summary>
    /// Set eyes view offsets matrices for stereo rendering
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlSetMatrixViewOffsetStereo")]
    public static partial void SetMatrixViewOffsetStereo(Matrix4x4 right, Matrix4x4 left);

    /// <summary>
    /// Load and draw a cube
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadDrawCube")]
    public static partial void LoadDrawCube();

    /// <summary>
    /// Load and draw a quad
    /// </summary>
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [LibraryImport(LibName, EntryPoint = "rlLoadDrawQuad")]
    public static partial void LoadDrawQuad();
}