using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

public static class LogInterop
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DefaultCallback(TraceLogLevel logLevel, byte* text, nint args)
    {
        string message = NativeStringFormatter.Format((nint)text, args);
        Console.WriteLine(message);
    }
}