using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge.Interop;

public static class LogInterop
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DefaultCallback(TraceLogLevel logLevel, sbyte* text, nint args)
    {
        var message = NativeStringFormatter.Format((nint)text, args);
        Console.WriteLine(message);
    }
}