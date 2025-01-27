using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge;

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
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlMatrixMode")]
    public static extern void MatrixMode(MatrixMode mode);

    /// <summary>
    /// Push the current matrix to stack
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlPushMatrix")]
    public static extern void PushMatrix();

    /// <summary>
    /// Pop latest inserted matrix from stack
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlPopMatrix")]
    public static extern void PopMatrix();

    /// <summary>
    /// Reset current matrix to identity matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadIdentity")]
    public static extern void LoadIdentity();

    /// <summary>
    /// Multiply the current matrix by a translation matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlTranslatef")]
    public static extern void Translatef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by a rotation matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlRotatef")]
    public static extern void Rotatef(float angle, float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by a scaling matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlScalef")]
    public static extern void Scalef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by another matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlMultMatrixf")]
    public static extern void MultMatrixf(float* matf);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlFrustum")]
    public static extern void Frustum(double left, double right, double bottom, double top, double znear, double zfar);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlOrtho")]
    public static extern void Ortho(double left, double right, double bottom, double top, double znear, double zfar);

    /// <summary>
    /// Set the viewport area
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlViewport")]
    public static extern void Viewport(int x, int y, int width, int height);

    /// <summary>
    /// Set clip planes distances
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetClipPlanes")]
    public static extern void SetClipPlanes(double nearPlane, double farPlane);

    /// <summary>
    /// Get cull plane distance near
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetCullDistanceNear")]
    public static extern double GetCullDistanceNear();

    /// <summary>
    /// Get cull plane distance far
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetCullDistanceFar")]
    public static extern double GetCullDistanceFar();

    /// <summary>
    /// Initialize drawing mode (how to organize vertex)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlBegin")]
    public static extern void Begin(DrawMode mode);

    /// <summary>
    /// Finish vertex providing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnd")]
    public static extern void End();

    /// <summary>
    /// Define one vertex (position) - 2 int
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlVertex2i")]
    public static extern void Vertex2i(int x, int y);

    /// <summary>
    /// Define one vertex (position) - 2 float
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlVertex2f")]
    public static extern void Vertex2f(float x, float y);

    /// <summary>
    /// Define one vertex (position) - 3 float
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlVertex3f")]
    public static extern void Vertex3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (texture coordinate) - 2 float
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlTexCoord2f")]
    public static extern void TexCoord2f(float x, float y);

    /// <summary>
    /// Define one vertex (normal) - 3 float
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlNormal3f")]
    public static extern void Normal3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (color) - 4 byte
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlColor4ub")]
    public static extern void Color4ub(byte r, byte g, byte b, byte a);

    /// <summary>
    /// Define one vertex (color) - 3 float
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlColor3f")]
    public static extern void Color3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (color) - 4 float
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlColor4f")]
    public static extern void Color4f(float x, float y, float z, float w);

    /// <summary>
    /// Enable vertex array (VAO, if supported)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableVertexArray")]
    public static extern NativeBool EnableVertexArray(uint vaoId);

    /// <summary>
    /// Disable vertex array (VAO, if supported)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableVertexArray")]
    public static extern void DisableVertexArray();

    /// <summary>
    /// Enable vertex buffer (VBO)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableVertexBuffer")]
    public static extern void EnableVertexBuffer(uint id);

    /// <summary>
    /// Disable vertex buffer (VBO)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableVertexBuffer")]
    public static extern void DisableVertexBuffer();

    /// <summary>
    /// Enable vertex buffer element (VBO element)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableVertexBufferElement")]
    public static extern void EnableVertexBufferElement(uint id);

    /// <summary>
    /// Disable vertex buffer element (VBO element)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableVertexBufferElement")]
    public static extern void DisableVertexBufferElement();

    /// <summary>
    /// Enable vertex attribute index
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableVertexAttribute")]
    public static extern void EnableVertexAttribute(uint index);

    /// <summary>
    /// Disable vertex attribute index
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableVertexAttribute")]
    public static extern void DisableVertexAttribute(uint index);

    /// <summary>
    /// Enable attribute state pointer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableStatePointer")]
    public static extern void EnableStatePointer(int vertexAttribType, void* buffer);

    /// <summary>
    /// Disable attribute state pointer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableStatePointer")]
    public static extern void DisableStatePointer(int vertexAttribType);

    /// <summary>
    /// Select and active a texture slot
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlActiveTextureSlot")]
    public static extern void ActiveTextureSlot(int slot);

    /// <summary>
    /// Enable texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableTexture")]
    public static extern void EnableTexture(uint id);

    /// <summary>
    /// Disable texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableTexture")]
    public static extern void DisableTexture();

    /// <summary>
    /// Enable texture cubemap
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableTextureCubemap")]
    public static extern void EnableTextureCubemap(uint id);

    /// <summary>
    /// Disable texture cubemap
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableTextureCubemap")]
    public static extern void DisableTextureCubemap();

    /// <summary>
    /// Set texture parameters (filter, wrap)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlTextureParameters")]
    public static extern void TextureParameters(uint id, int param, int value);

    /// <summary>
    /// Set cubemap parameters (filter, wrap)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlCubemapParameters")]
    public static extern void CubemapParameters(uint id, int param, int value);

    /// <summary>
    /// Enable shader program
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableShader")]
    public static extern void EnableShader(uint id);

    /// <summary>
    /// Disable shader program
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableShader")]
    public static extern void DisableShader();

    /// <summary>
    /// Enable render texture (fbo)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableFramebuffer")]
    public static extern void EnableFramebuffer(uint id);

    /// <summary>
    /// Disable render texture (fbo), return to default framebuffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableFramebuffer")]
    public static extern void DisableFramebuffer();

    /// <summary>
    /// Get the currently active render texture (fbo), 0 for default framebuffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetActiveFramebuffer")]
    public static extern uint GetActiveFramebuffer();

    /// <summary>
    /// Activate multiple draw color buffers
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlActiveDrawBuffers")]
    public static extern void ActiveDrawBuffers(int count);

    /// <summary>
    /// Blit active framebuffer to main framebuffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlBlitFramebuffer")]
    public static extern void BlitFramebuffer(
        int srcX, int srcY, int srcHeight, int dstX, int dstY, int dstWidth, int dstHeight, int bufferMask);

    /// <summary>
    /// Bind framebuffer (FBO)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlBindFramebuffer")]
    public static extern void BindFramebuffer(uint target, uint framebuffer);

    /// <summary>
    /// Enable color blending
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableColorBlend")]
    public static extern void EnableColorBlend();

    /// <summary>
    /// Disable color blending
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableColorBlend")]
    public static extern void DisableColorBlend();

    /// <summary>
    /// Enable depth test
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableDepthTest")]
    public static extern void EnableDepthTest();

    /// <summary>
    /// Disable depth test
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableDepthTest")]
    public static extern void DisableDepthTest();

    /// <summary>
    /// Enable depth write
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableDepthMask")]
    public static extern void EnableDepthMask();

    /// <summary>
    /// Disable depth write
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableDepthMask")]
    public static extern void DisableDepthMask();

    /// <summary>
    /// Enable backface culling
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableBackfaceCulling")]
    public static extern void EnableBackfaceCulling();

    /// <summary>
    /// Disable backface culling
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableBackfaceCulling")]
    public static extern void DisableBackfaceCulling();

    /// <summary>
    /// Color mask control
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlColorMask")]
    public static extern void ColorMask(NativeBool r, NativeBool g, NativeBool b, NativeBool a);

    /// <summary>
    /// Set face culling mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetCullFace")]
    public static extern void SetCullFace(CullMode mode);

    /// <summary>
    /// Enable scissor test
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableScissorTest")]
    public static extern void EnableScissorTest();

    /// <summary>
    /// Disable scissor test
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableScissorTest")]
    public static extern void DisableScissorTest();

    /// <summary>
    /// Scissor test
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlScissor")]
    public static extern void Scissor(int x, int y, int width, int height);

    /// <summary>
    /// Enable point mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnablePointMode")]
    public static extern void EnablePointMode();
    
    /// <summary>
    /// Disable wire mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisablePointMode")]
    public static extern void DisablePointMode();
    
    /// <summary>
    /// Enable wire mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableWireMode")]
    public static extern void EnableWireMode();

    /// <summary>
    /// Disable wire mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableWireMode")]
    public static extern void DisableWireMode();

    /// <summary>
    /// Set the line drawing width
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetLineWidth")]
    public static extern void SetLineWidth(float width);

    /// <summary>
    /// Get the line drawing width
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetLineWidth")]
    public static extern float GetLineWidth();

    /// <summary>
    /// Enable line aliasing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableSmoothLines")]
    public static extern void EnableSmoothLines();

    /// <summary>
    /// Disable line aliasing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableSmoothLines")]
    public static extern void DisableSmoothLines();

    /// <summary>
    /// Enable stereo rendering
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlEnableStereoRender")]
    public static extern void EnableStereoRender();

    /// <summary>
    /// Disable stereo rendering
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDisableStereoRender")]
    public static extern void DisableStereoRender();

    /// <summary>
    /// Check if stereo render is enabled
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlIsStereoRenderEnabled")]
    public static extern NativeBool IsStereoRenderEnabled();

    /// <summary>
    /// Clear color buffer with color
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlClearColor")]
    public static extern void ClearColor(byte r, byte g, byte b, byte a);

    /// <summary>
    /// Clear used screen buffers (color and depth)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlClearScreenBuffers")]
    public static extern void ClearScreenBuffers();

    /// <summary>
    /// Check and log OpenGL error codes
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlCheckErrors")]
    public static extern void CheckErrors();

    /// <summary>
    /// Set blending mode
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetBlendMode")]
    public static extern void SetBlendMode(BlendMode mode);

    /// <summary>
    /// Set blending mode factor and equation (using OpenGL factors)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetBlendFactors")]
    public static extern void SetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

    /// <summary>
    /// Set blending mode factors and equations separately (using OpenGL factors)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetBlendFactorsSeparate")]
    public static extern void SetBlendFactorsSeparate(int glSrcRGB, int glDstRGB, int glSrcAlpha, int glDstAlpha, int glEqRGB, int glEqAlpha);

    /// <summary>
    /// Initialize rlgl (buffers, shaders, textures, states)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlInit")]
    public static extern void Init(int width, int height);

    /// <summary>
    /// De-initialize rlgl (buffers, shaders, textures)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlClose")]
    public static extern void Close();

    /// <summary>
    /// Load OpenGL extensions (loader function required)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadExtensions")]
    public static extern void LoadExtensions(void* loader);

    /// <summary>
    /// Get current OpenGL version
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetVersion")]
    public static extern GlVersion GetVersion();

    /// <summary>
    /// Set current framebuffer width
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetFramebufferWidth")]
    public static extern void SetFramebufferWidth(int width);

    /// <summary>
    /// Get default framebuffer width
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetFramebufferWidth")]
    public static extern int GetFramebufferWidth();

    /// <summary>
    /// Set current framebuffer height
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetFramebufferHeight")]
    public static extern void SetFramebufferHeight(int height);

    /// <summary>
    /// Get default framebuffer height
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetFramebufferHeight")]
    public static extern int GetFramebufferHeight();

    /// <summary>
    /// Get default texture id
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetTextureIdDefault")]
    public static extern uint GetTextureIdDefault();

    /// <summary>
    /// Get default shader id
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetShaderIdDefault")]
    public static extern uint GetShaderIdDefault();

    /// <summary>
    /// Get default shader locations
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetShaderLocsDefault")]
    public static extern int* GetShaderLocsDefault();

    /// <summary>
    /// Load a render batch system
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadRenderBatch")]
    public static extern RenderBatch LoadRenderBatch(int numBuffers, int bufferElements);

    /// <summary>
    /// Unload render batch system
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadRenderBatch")]
    public static extern void UnloadRenderBatch(RenderBatch batch);

    /// <summary>
    /// Draw render batch data (Update->Draw->Reset)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDrawRenderBatch")]
    public static extern void DrawRenderBatch(RenderBatch* batch);

    /// <summary>
    /// Set the active render batch for rlgl (NULL for default internal)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetRenderBatchActive")]
    public static extern void SetRenderBatchActive(RenderBatch* batch);

    /// <summary>
    /// Update and draw internal render batch
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDrawRenderBatchActive")]
    public static extern void DrawRenderBatchActive();

    /// <summary>
    /// Check internal buffer overflow for a given number of vertex
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlCheckRenderBatchLimit")]
    public static extern NativeBool CheckRenderBatchLimit(int vCount);

    /// <summary>
    /// Set current texture for render batch and check buffers limits
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetTexture")]
    public static extern void SetTexture(uint id);

    /// <summary>
    /// Load vertex array (vao) if supported
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadVertexArray")]
    public static extern uint LoadVertexArray();

    /// <summary>
    /// Load a vertex buffer object
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadVertexBuffer")]
    public static extern uint LoadVertexBuffer(void* buffer, int size, NativeBool dynamic);

    /// <summary>
    /// Load vertex buffer elements object
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadVertexBufferElement")]
    public static extern uint LoadVertexBufferElement(void* buffer, int size, NativeBool dynamic);

    /// <summary>
    /// Update vertex buffer object data on GPU buffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUpdateVertexBuffer")]
    public static extern void UpdateVertexBuffer(uint bufferId, void* data, int dataSize, int offset);

    /// <summary>
    /// Update vertex buffer elements data on GPU buffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUpdateVertexBufferElements")]
    public static extern void UpdateVertexBufferElements(uint id, void* data, int dataSize, int offset);

    /// <summary>
    /// Unload vertex array (vao)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadVertexArray")]
    public static extern void UnloadVertexArray(uint vaoId);

    /// <summary>
    /// Unload vertex buffer object
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadVertexBuffer")]
    public static extern void UnloadVertexBuffer(uint vboId);

    /// <summary>
    /// Set vertex attribute data configuration
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetVertexAttribute")]
    public static extern void SetVertexAttribute(uint index, int compSize, int type, NativeBool normalized, int stride, int offset);

    /// <summary>
    /// Set vertex attribute data divisor
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetVertexAttributeDivisor")]
    public static extern void SetVertexAttributeDivisor(uint index, int divisor);

    /// <summary>
    /// Set vertex attribute default value, when attribute to provided
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetVertexAttributeDefault")]
    public static extern void SetVertexAttributeDefault(int locIndex, void* value, ShaderAttributeDataType attribType, int count);

    /// <summary>
    /// Draw vertex array (currently active vao)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDrawVertexArray")]
    public static extern void DrawVertexArray(int offset, int count);

    /// <summary>
    /// Draw vertex array elements
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDrawVertexArrayElements")]
    public static extern void DrawVertexArrayElements(int offset, int count, void* buffer);

    /// <summary>
    /// Draw vertex array (currently active vao) with instancing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDrawVertexArrayInstanced")]
    public static extern void DrawVertexArrayInstanced(int offset, int count, int instances);

    /// <summary>
    /// Draw vertex array elements with instancing
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlDrawVertexArrayElementsInstanced")]
    public static extern void DrawVertexArrayElementsInstanced(int offset, int count, void* buffer, int instances);

    /// <summary>
    /// Load texture data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadTexture")]
    public static extern uint LoadTexture(void* data, int width, int height, PixelFormat format, int mipmapCount);

    /// <summary>
    /// Load depth texture/renderbuffer (to be attached to fbo)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadTextureDepth")]
    public static extern uint LoadTextureDepth(int width, int height, NativeBool useRenderBuffer);

    /// <summary>
    /// Load texture cubemap data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadTextureCubemap")]
    public static extern uint LoadTextureCubemap(void* data, int size, PixelFormat format);

    /// <summary>
    /// Update texture with new data on GPU
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUpdateTexture")]
    public static extern void UpdateTexture(uint id, int offsetX, int offsetY, int width, int height, PixelFormat format, void* data);

    /// <summary>
    /// Get OpenGL internal formats
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetGlTextureFormats")]
    public static extern void GetGlTextureFormats(PixelFormat format, uint* glInternalFormat, uint* glFormat, uint* glType);

    /// <summary>
    /// Get name string for pixel format
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetPixelFormatName")]
    public static extern sbyte* GetPixelFormatName(PixelFormat format);

    /// <summary>
    /// Unload texture from GPU memory
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadTexture")]
    public static extern void UnloadTexture(uint id);

    /// <summary>
    /// Generate mipmap data for selected texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGenTextureMipmaps")]
    public static extern void GenTextureMipmaps(uint id, int width, int height, PixelFormat format, int* mipmaps);

    /// <summary>
    /// Read texture pixel data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlReadTexturePixels")]
    public static extern void* ReadTexturePixels(uint id, int width, int height, PixelFormat format);

    /// <summary>
    /// Read screen pixel data (color buffer)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlReadScreenPixels")]
    public static extern byte* ReadScreenPixels(int width, int height);

    /// <summary>
    /// Load an empty framebuffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadFramebuffer")]
    public static extern uint LoadFramebuffer();

    /// <summary>
    /// Attach texture/renderbuffer to a framebuffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlFramebufferAttach")]
    public static extern void FramebufferAttach(
        uint fboId, uint texId, FramebufferAttachType attachType, FramebufferAttachTextureType texType, int mipLevel);

    /// <summary>
    /// Verify framebuffer is complete
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlFramebufferComplete")]
    public static extern void FramebufferComplete(uint id);

    /// <summary>
    /// Delete framebuffer from GPU
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadFramebuffer")]
    public static extern void UnloadFramebuffer(uint id);

    /// <summary>
    /// Load shader from code strings
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadShaderCode")]
    public static extern uint LoadShaderCode(sbyte* vsCode, sbyte* fsCode);

    /// <summary>
    /// Compile custom shader and return shader id (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlCompileShader")]
    public static extern uint CompileShader(sbyte* shaderCode, ShaderType type);

    /// <summary>
    /// Load custom shader program
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadShaderProgram")]
    public static extern uint LoadShaderProgram(uint vShaderId, uint fShaderId);

    /// <summary>
    /// Unload shader program
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadShaderProgram")]
    public static extern void UnloadShaderProgram(uint id);

    /// <summary>
    /// Get shader location uniform
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetLocationUniform")]
    public static extern int GetLocationUniform(uint shaderId, sbyte* uniformName);

    /// <summary>
    /// Get shader location attribute
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetLocationAttrib")]
    public static extern int GetLocationAttrib(uint shaderId, sbyte* attribName);

    /// <summary>
    /// Set shader value uniform
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetUniform")]
    public static extern void SetUniform(int locIndex, void* value, ShaderUniformDataType uniformType, int count);

    /// <summary>
    /// Set shader value matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetUniformMatrix")]
    public static extern void SetUniformMatrix(int locIndex, Matrix4x4 mat);
    
    /// <summary>
    /// Set shader value matrices
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetUniformMatrices")]
    public static extern void SetUniformMatrices(int locIndex, Matrix4x4* mat, int count);

    /// <summary>
    /// Set shader value sampler
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetUniformSampler")]
    public static extern void SetUniformSampler(int locIndex, uint textureId);

    /// <summary>
    /// Set shader currently active (id and locations)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetShader")]
    public static extern void SetShader(uint id, int* locs);

    /// <summary>
    /// Load compute shader program
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadComputeShaderProgram")]
    public static extern uint LoadComputeShaderProgram(uint shaderId);

    /// <summary>
    /// Dispatch compute shader (equivalent to *draw* for graphics pipeline)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlComputeShaderDispatch")]
    public static extern void ComputeShaderDispatch(uint groupX, uint groupY, uint groupZ);

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadShaderBuffer")]
    public static extern uint LoadShaderBuffer(uint size, void* data, int usageHint);

    /// <summary>
    /// Unload shader storage buffer object (SSBO)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUnloadShaderBuffer")]
    public static extern void UnloadShaderBuffer(uint ssboId);

    /// <summary>
    /// Update SSBO buffer data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlUpdateShaderBuffer")]
    public static extern void UpdateShaderBuffer(uint id, void* data, uint dataSize, uint offset);

    /// <summary>
    /// Bind SSBO buffer
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlBindShaderBuffer")]
    public static extern void BindShaderBuffer(uint id, uint index);

    /// <summary>
    /// Read SSBO buffer data (GPU->CPU)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlReadShaderBuffer")]
    public static extern void ReadShaderBuffer(uint id, void* dest, uint count, uint offset);

    /// <summary>
    /// Copy SSBO data between buffers
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlCopyShaderBuffer")]
    public static extern void CopyShaderBuffer(uint destId, uint srcId, uint destOffset, uint srcOffset, uint count);

    /// <summary>
    /// Get SSBO buffer size
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetShaderBufferSize")]
    public static extern uint GetShaderBufferSize(uint id);

    /// <summary>
    /// Bind image texture
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlBindImageTexture")]
    public static extern void BindImageTexture(uint id, uint index, PixelFormat format, NativeBool @readonly);

    /// <summary>
    /// Get internal modelview matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetMatrixModelview")]
    public static extern Matrix4x4 GetMatrixModelview();

    /// <summary>
    /// Get internal projection matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetMatrixProjection")]
    public static extern Matrix4x4 GetMatrixProjection();

    /// <summary>
    /// Get internal accumulated transform matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetMatrixTransform")]
    public static extern Matrix4x4 GetMatrixTransform();

    /// <summary>
    /// Get internal projection matrix for stereo render (selected eye)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetMatrixProjectionStereo")]
    public static extern Matrix4x4 GetMatrixProjectionStereo(int eye);

    /// <summary>
    /// Get internal view offset matrix for stereo render (selected eye)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlGetMatrixViewOffsetStereo")]
    public static extern Matrix4x4 GetMatrixViewOffsetStereo(int eye);

    /// <summary>
    /// Set a custom projection matrix (replaces internal projection matrix)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetMatrixProjection")]
    public static extern void SetMatrixProjection(Matrix4x4 proj);

    /// <summary>
    /// Set a custom modelview matrix (replaces internal modelview matrix)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetMatrixModelview")]
    public static extern void SetMatrixModelview(Matrix4x4 view);

    /// <summary>
    /// Set eyes projection matrices for stereo rendering
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetMatrixProjectionStereo")]
    public static extern void SetMatrixProjectionStereo(Matrix4x4 right, Matrix4x4 left);

    /// <summary>
    /// Set eyes view offsets matrices for stereo rendering
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlSetMatrixViewOffsetStereo")]
    public static extern void SetMatrixViewOffsetStereo(Matrix4x4 right, Matrix4x4 left);

    /// <summary>
    /// Load and draw a cube
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadDrawCube")]
    public static extern void LoadDrawCube();

    /// <summary>
    /// Load and draw a quad
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rlLoadDrawQuad")]
    public static extern void LoadDrawQuad();
}