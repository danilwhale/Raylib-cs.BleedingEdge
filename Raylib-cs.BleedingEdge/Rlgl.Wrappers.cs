using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Rlgl
{
    /// <summary>
    /// Multiply the current matrix by another matrix
    /// </summary>
    public static void MultMatrixf(Matrix4x4 mat)
    {
        MultMatrixf((float*)&mat);
    }

    /// <summary>
    /// Enable attribute state pointer
    /// </summary>
    public static void EnableStatePointer<T>(int vertexAttribType, ReadOnlySpan<T> buffer) where T : unmanaged
    {
        fixed (T* pBuffer = buffer)
        {
            EnableStatePointer(vertexAttribType, pBuffer);
        }
    }

    /// <summary>
    /// Get OpenGL procedure address
    /// </summary>
    /// <remarks>
    /// void* replaced with <see cref="nint"/> for compatability with OpenGL bindings
    /// </remarks>
    public static nint GetProcAddress(Utf8String procName)
    {
        fixed (byte* pProcName = procName) return (nint)GetProcAddress(pProcName);
    }

    /// <summary>
    /// Draw render batch data (Update->Draw->Reset)
    /// </summary>
    public static void DrawRenderBatch(ref RenderBatch batch)
    {
        fixed (RenderBatch* pBatch = &batch)
        {
            DrawRenderBatch(pBatch);
        }
    }

    /// <summary>
    /// Set the active render batch for rlgl (NULL for default internal)
    /// </summary>
    public static void SetRenderBatchActive(ref RenderBatch batch)
    {
        fixed (RenderBatch* pBatch = &batch)
        {
            SetRenderBatchActive(pBatch);
        }
    }

    /// <summary>
    /// Load a vertex buffer object
    /// </summary>
    public static uint LoadVertexBuffer<T>(ReadOnlySpan<T> buffer, NativeBool dynamic)
        where T : unmanaged
    {
        fixed (T* pBuffer = buffer)
        {
            return LoadVertexBuffer(pBuffer, buffer.Length * sizeof(T), dynamic);
        }
    }

    /// <summary>
    /// Load vertex buffer elements object
    /// </summary>
    public static uint LoadVertexBufferElement<T>(ReadOnlySpan<T> buffer, NativeBool dynamic)
        where T : unmanaged
    {
        fixed (T* pBuffer = buffer)
        {
            return LoadVertexBufferElement(pBuffer, buffer.Length * sizeof(T), dynamic);
        }
    }

    /// <summary>
    /// Update vertex buffer object data on GPU buffer
    /// </summary>
    public static void UpdateVertexBuffer<T>(uint bufferId, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateVertexBuffer(bufferId, pData, data.Length * sizeof(T), offset);
        }
    }

    /// <summary>
    /// Update vertex buffer elements data on GPU buffer
    /// </summary>
    public static void UpdateVertexBufferElements<T>(uint id, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateVertexBufferElements(id, pData, data.Length * sizeof(T), offset);
        }
    }

    /// <summary>
    /// Set vertex attribute default value, when attribute to provided
    /// </summary>
    public static void SetVertexAttributeDefault<T>(int locIndex, T value, ShaderAttributeDataType attribType, int count)
        where T : unmanaged
    {
        SetVertexAttributeDefault(locIndex, &value, attribType, count);
    }

    /// <summary>
    /// Set vertex attribute default value, when attribute to provided
    /// </summary>
    public static void SetVertexAttributeDefault<T>(int locIndex, ReadOnlySpan<T> value, ShaderAttributeDataType attribType)
        where T : unmanaged
    {
        fixed (T* pValue = value)
        {
            SetVertexAttributeDefault(locIndex, pValue, attribType, value.Length);
        }
    }

    /// <summary>
    /// Load texture data
    /// </summary>
    public static uint LoadTexture<T>(ReadOnlySpan<T> data, int width, int height, PixelFormat format, int mipmapCount)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            return LoadTexture(pData, width, height, format, mipmapCount);
        }
    }

    /// <summary>
    /// Load texture cubemap data
    /// </summary>
    public static uint LoadTextureCubemap<T>(ReadOnlySpan<T> data, PixelFormat format)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            return LoadTextureCubemap(pData, data.Length * sizeof(T), format);
        }
    }

    /// <summary>
    /// Load texture cubemap data
    /// </summary>
    public static uint LoadTextureCubemap(int size, PixelFormat format)
    {
        return LoadTextureCubemap(null, size, format);
    }

    /// <summary>
    /// Update texture with new data on GPU
    /// </summary>
    public static void UpdateTexture<T>(uint id, int offsetX, int offsetY, int width, int height, PixelFormat format, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateTexture(id, offsetX, offsetY, width, height, format, pData);
        }
    }

    /// <summary>
    /// Get OpenGL internal formats
    /// </summary>
    public static void GetGlTextureFormats(PixelFormat format, out uint glInternalFormat, out uint glFormat, out uint glType)
    {
        // the
        fixed (uint* pGlInternalFormat = &glInternalFormat)
        {
            fixed (uint* pGlFormat = &glFormat)
            {
                fixed (uint* pGlType = &glType)
                {
                    GetGlTextureFormats(format, pGlInternalFormat, pGlFormat, pGlType);
                }
            }
        }
    }

    /// <summary>
    /// Get name string for pixel format
    /// </summary>
    public static string? GetPixelFormatNameString(PixelFormat format)
    {
        return Marshal.PtrToStringUTF8((nint)GetPixelFormatName(format));
    }

    /// <summary>
    /// Generate mipmap data for selected texture
    /// </summary>
    public static void GenTextureMipmaps(uint id, int width, int height, PixelFormat format, out int mipmaps)
    {
        fixed (int* pMipmaps = &mipmaps)
        {
            GenTextureMipmaps(id, width, height, format, pMipmaps);
        }
    }

    /// <summary>
    /// Load shader from code strings
    /// </summary>
    public static uint LoadShaderCode(Utf8String vsCode, Utf8String fsCode)
    {
        fixed (byte* pVsCode = vsCode)
        fixed (byte* pFsCode = fsCode)
            return LoadShaderCode(pVsCode, pFsCode);
    }

    /// <summary>
    /// Compile custom shader and return shader id (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER)
    /// </summary>
    public static uint CompileShader(Utf8String shaderCode, RlglEnum type)
    {
        fixed (byte* pShaderCode = shaderCode) return CompileShader(pShaderCode, type);
    }

    /// <summary>
    /// Get shader location uniform
    /// </summary>
    public static int GetLocationUniform(uint shaderId, Utf8String uniformName)
    {
        fixed (byte* pUniformName = uniformName) return GetLocationUniform(shaderId, pUniformName);
    }

    /// <summary>
    /// Get shader location attribute
    /// </summary>
    public static int GetLocationAttrib(uint shaderId, Utf8String attribName)
    {
        fixed (byte* pAttribName = attribName) return GetLocationAttrib(shaderId, pAttribName);
    }

    /// <summary>
    /// Set shader value uniform
    /// </summary>
    public static void SetUniform<T>(int locIndex, T value, ShaderUniformDataType uniformType, int count)
        where T : unmanaged
    {
        SetUniform(locIndex, &value, uniformType, count);
    }

    /// <summary>
    /// Set shader value uniform
    /// </summary>
    public static void SetUniform<T>(int locIndex, ReadOnlySpan<T> value, ShaderUniformDataType uniformType)
        where T : unmanaged
    {
        fixed (T* pValue = value)
        {
            SetUniform(locIndex, pValue, uniformType, value.Length);
        }
    }

    /// <summary>
    /// Set shader value matrix
    /// </summary>
    public static void SetUniform(int locIndex, Matrix4x4 mat)
    {
        SetUniformMatrix(locIndex, mat);
    }

    /// <summary>
    /// Set shader value sampler
    /// </summary>
    public static void SetUniform(int locIndex, uint textureId)
    {
        SetUniformSampler(locIndex, textureId);
    }

    /// <summary>
    /// Set shader value matrices
    /// </summary>
    public static void SetUniform(int locIndex, ReadOnlySpan<Matrix4x4> mat)
    {
        SetUniformMatrices(locIndex, mat);
    }

    /// <summary>
    /// Set shader value matrices
    /// </summary>
    public static void SetUniformMatrices(int locIndex, ReadOnlySpan<Matrix4x4> mat)
    {
        fixed (Matrix4x4* pMat = mat)
        {
            SetUniformMatrices(locIndex, pMat, mat.Length);
        }
    }

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    public static uint LoadShaderBuffer<T>(ReadOnlySpan<T> data, RlglEnum usageHint)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            return LoadShaderBuffer((uint)(data.Length * sizeof(T)), pData, usageHint);
        }
    }

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    public static uint LoadShaderBuffer(uint size, RlglEnum usageHint)
    {
        return LoadShaderBuffer(size, null, usageHint);
    }

    /// <summary>
    /// Update SSBO buffer data
    /// </summary>
    public static void UpdateShaderBuffer<T>(uint id, ReadOnlySpan<T> data, uint offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateShaderBuffer(id, pData, (uint)(data.Length * sizeof(T)), offset);
        }
    }

    /// <summary>
    /// Read SSBO buffer data (GPU->CPU)
    /// </summary>
    public static void ReadShaderBuffer<T>(uint id, Span<T> dest, uint count, uint offset)
        where T : unmanaged
    {
        fixed (T* pDest = dest)
        {
            ReadShaderBuffer(id, pDest, count, offset);
        }
    }
}