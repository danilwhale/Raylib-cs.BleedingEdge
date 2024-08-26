using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;
using Raylib_cs.BleedingEdge.Interop;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Logging: Redirect trace log messages
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void TraceLogCallback(TraceLogLevel logLevel, sbyte* text, nint args);

/// <summary>
/// FileIO: Load binary data
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate byte* LoadFileDataCallback(sbyte* fileName, int* dataSize);

/// <summary>
/// FileIO: Save binary data
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate NativeBool SaveFileDataCallback(sbyte* fileName, void* data, int dataSize);

/// <summary>
/// FileIO: Load text data
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate sbyte* LoadFileTextCallback(sbyte* fileName);

/// <summary>
/// FileIO: Save text data
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate NativeBool SaveFileTextCallback(sbyte* fileName, sbyte* text);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void AudioCallback(void* bufferData, uint frames);