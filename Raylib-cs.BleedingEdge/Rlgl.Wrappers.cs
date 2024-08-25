using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge.Enums.Raylib;
using Raylib_cs.BleedingEdge.Interop;
using Raylib_cs.BleedingEdge.Types.Raylib;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Rlgl
{

    private static GCHandle _activeRenderBatch;

    /// <inheritdoc cref="MultMatrixf(float*)" />
    public static void MultMatrixf(Matrix4x4 mat)
    {
        MultMatrixf((float*)&mat);
    }

    /// <inheritdoc cref="DrawRenderBatch(RenderBatch*)" />
    public static void DrawRenderBatch(ref RenderBatch batch)
    {
        fixed (RenderBatch* pBatch = &batch)
        {
            DrawRenderBatch(pBatch);
        }
    }

    /// <inheritdoc cref="SetRenderBatchActive(RenderBatch*)" />
    public static void SetRenderBatchActive(ref RenderBatch batch)
    {
        if (_activeRenderBatch.IsAllocated)
        {
            _activeRenderBatch.Free();
        }

        // pin specified batch, so GC won't move it while rlgl using it
        _activeRenderBatch = GCHandle.Alloc(batch, GCHandleType.Pinned);

        SetRenderBatchActive((RenderBatch*)_activeRenderBatch.AddrOfPinnedObject());
    }

    /// <inheritdoc cref="LoadVertexBuffer" />
    public static uint LoadVertexBuffer<T>(ReadOnlySpan<T> buffer, NativeBool dynamic)
        where T : unmanaged
    {
        fixed (T* pBuffer = buffer)
        {
            return LoadVertexBuffer(pBuffer, buffer.Length, dynamic);
        }
    }

    /// <inheritdoc cref="LoadVertexBufferElement" />
    public static uint LoadVertexBufferElement<T>(ReadOnlySpan<T> buffer, NativeBool dynamic)
        where T : unmanaged
    {
        fixed (T* pBuffer = buffer)
        {
            return LoadVertexBufferElement(pBuffer, buffer.Length, dynamic);
        }
    }

    /// <inheritdoc cref="UpdateVertexBuffer" />
    public static void UpdateVertexBuffer<T>(uint bufferId, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateVertexBuffer(bufferId, pData, data.Length, offset);
        }
    }

    /// <inheritdoc cref="UpdateVertexBufferElements" />
    public static void UpdateVertexBufferElements<T>(uint id, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateVertexBufferElements(id, pData, data.Length, offset);
        }
    }

    /// <inheritdoc cref="SetVertexAttributeDefault" />
    public static void SetVertexAttributeDefault<T>(int locIndex, T value, ShaderAttributeDataType attribType, int count)
        where T : unmanaged
    {
        SetVertexAttributeDefault(locIndex, &value, attribType, count);
    }

    /// <inheritdoc cref="SetVertexAttributeDefault" />
    public static void SetVertexAttributeDefault<T>(int locIndex, ReadOnlySpan<T> value, ShaderAttributeDataType attribType)
        where T : unmanaged
    {
        fixed (T* pValue = value)
        {
            SetVertexAttributeDefault(locIndex, pValue, attribType, value.Length);
        }
    }

    /// <inheritdoc cref="LoadTexture" />
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
            return LoadTextureCubemap(pData, data.Length, format);
        }
    }

    /// <summary>
    /// Load texture cubemap data
    /// </summary>
    public static uint LoadTextureCubemap(int size, PixelFormat format)
    {
        return LoadTextureCubemap(null, size, format);
    }

    /// <inheritdoc cref="UpdateTexture" />
    public static void UpdateTexture<T>(uint id, int offsetX, int offsetY, int width, int height, PixelFormat format, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateTexture(id, offsetX, offsetY, width, height, format, pData);
        }
    }

    /// <inheritdoc cref="GetGlTextureFormats(PixelFormat,uint*,uint*,uint*)" />
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

    /// <inheritdoc cref="GetPixelFormatName" />
    public static string GetPixelFormatNameString(PixelFormat format)
    {
        return Marshal.PtrToStringUTF8((nint)GetPixelFormatName(format)) ?? string.Empty;
    }

    /// <inheritdoc cref="GenTextureMipmaps(uint,int,int,PixelFormat,int*)" />
    public static void GenTextureMipmaps(uint id, int width, int height, PixelFormat format, out int mipmaps)
    {
        fixed (int* pMipmaps = &mipmaps)
        {
            GenTextureMipmaps(id, width, height, format, pMipmaps);
        }
    }

    /// <inheritdoc cref="LoadShaderCode(sbyte*,sbyte*)" />
    public static uint LoadShaderCode(string vsCode, string fsCode)
    {
        var pVsCode = Marshal.StringToCoTaskMemUTF8(vsCode);
        var pFsCode = Marshal.StringToCoTaskMemUTF8(fsCode);
        var result = LoadShaderCode((sbyte*)pVsCode, (sbyte*)pFsCode);
        Marshal.FreeCoTaskMem(pFsCode);
        Marshal.FreeCoTaskMem(pVsCode);
        return result;
    }

    /// <inheritdoc cref="CompileShader(sbyte*,ShaderType)" />
    public static uint CompileShader(string shaderCode, ShaderType type)
    {
        var pShaderCode = Marshal.StringToCoTaskMemUTF8(shaderCode);
        var result = CompileShader((sbyte*)pShaderCode, type);
        Marshal.FreeCoTaskMem(pShaderCode);
        return result;
    }

    /// <inheritdoc cref="GetLocationUniform(uint,sbyte*)" />
    public static int GetLocationUniform(uint shaderId, string uniformName)
    {
        var pUniformName = Marshal.StringToCoTaskMemUTF8(uniformName);
        var result = GetLocationUniform(shaderId, (sbyte*)pUniformName);
        Marshal.FreeCoTaskMem(pUniformName);
        return result;
    }

    /// <inheritdoc cref="GetLocationAttrib(uint,sbyte*)" />
    public static int GetLocationAttrib(uint shaderId, string attribName)
    {
        var pAttribName = Marshal.StringToCoTaskMemUTF8(attribName);
        var result = GetLocationAttrib(shaderId, (sbyte*)pAttribName);
        Marshal.FreeCoTaskMem(pAttribName);
        return result;
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

    // overloads with similiar methods for convenience

    /// <inheritdoc cref="SetUniformMatrix" />
    public static void SetUniform(int locIndex, Matrix4x4 mat)
    {
        SetUniformMatrix(locIndex, mat);
    }

    /// <inheritdoc cref="SetUniformSampler" />
    public static void SetUniform(int locIndex, uint textureId)
    {
        SetUniformSampler(locIndex, textureId);
    }

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    public static uint LoadShaderBuffer<T>(ReadOnlySpan<T> data, int usageHint)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            return LoadShaderBuffer((uint)data.Length, pData, usageHint);
        }
    }

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    public static uint LoadShaderBuffer(uint size, int usageHint)
    {
        return LoadShaderBuffer(size, null, usageHint);
    }

    /// <inheritdoc cref="UpdateShaderBuffer" />
    public static void UpdateShaderBuffer<T>(uint id, ReadOnlySpan<T> data, uint offset)
        where T : unmanaged
    {
        fixed (T* pData = data)
        {
            UpdateShaderBuffer(id, pData, (uint)data.Length, offset);
        }
    }

    /// <inheritdoc cref="ReadShaderBuffer" />
    public static void ReadShaderBuffer<T>(uint id, Span<T> dest, uint count, uint offset)
        where T : unmanaged
    {
        fixed (T* pDest = dest)
        {
            ReadShaderBuffer(id, pDest, count, offset);
        }
    }
}