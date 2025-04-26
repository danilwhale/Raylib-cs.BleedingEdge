using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

public static partial class NativeStringFormatter
{

    public static string Format(nint format, nint args)
    {
        if (OperatingSystem.IsMacOS())
        {
            return FormatMacOs(format, args);
        }

        if (OperatingSystem.IsLinux() && nint.Size == 8)
        {
            return FormatLinuxX64(format, args);
        }

        int argsByteLength = VsnPrintf(nint.Zero, nuint.Zero, format, args) + 1;
        if (argsByteLength <= 1) return string.Empty;

        nint utf8Buffer = Marshal.AllocHGlobal(argsByteLength);
        VsPrintf(utf8Buffer, format, args);

        string? result = Marshal.PtrToStringUTF8(utf8Buffer);

        Marshal.FreeHGlobal(utf8Buffer);

        return result ?? string.Empty;
    }

    private static string FormatMacOs(nint format, nint args)
    {
        nint buffer = nint.Zero;

        try
        {
            int count = Native.MacOs.vasprintf(ref buffer, format, args);
            if (count == -1) return string.Empty;
            return Marshal.PtrToStringUTF8(buffer) ?? string.Empty;
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    private static unsafe string FormatLinuxX64(nint format, nint args)
    {
        Native.Linux.VaListLinuxX64 valistStruct = *(Native.Linux.VaListLinuxX64*)args;

        nint valistPtr = Marshal.AllocHGlobal(Marshal.SizeOf(valistStruct));
        *(Native.Linux.VaListLinuxX64*)valistPtr = valistStruct;
        int argsByteLength = Native.Linux.vsnprintf(nint.Zero, nuint.Zero, format, valistPtr) + 1;
        *(Native.Linux.VaListLinuxX64*)valistPtr = valistStruct;
        nint utf8Buffer = Marshal.AllocHGlobal(argsByteLength);
        _ = Native.Linux.vsprintf(utf8Buffer, format, valistPtr);

        string? result = Marshal.PtrToStringUTF8(utf8Buffer);

        Marshal.FreeHGlobal(valistPtr);
        Marshal.FreeHGlobal(utf8Buffer);

        return result ?? string.Empty;
    }

    private static int VsPrintf(nint buffer, nint format, nint args)
    {
        if (OperatingSystem.IsWindows())
        {
            return Native.Windows.vsprintf(buffer, format, args);
        }

        if (OperatingSystem.IsLinux() || OperatingSystem.IsAndroid())
        {
            return Native.Linux.vsprintf(buffer, format, args);
        }

        return -1;
    }

    private static int VsnPrintf(nint buffer, nuint size, nint format, nint args)
    {
        if (OperatingSystem.IsWindows())
        {
            return Native.Windows.vsnprintf(buffer, size, format, args);
        }

        if (OperatingSystem.IsLinux() || OperatingSystem.IsAndroid())
        {
            return Native.Linux.vsnprintf(buffer, size, format, args);
        }

        return -1;
    }

    private static partial class Native
    {
        public static partial class Windows
        {
            [LibraryImport("msvcrt")]
            public static partial int vsprintf(nint buffer, nint format, nint args);

            [LibraryImport("msvcrt")]
            public static partial int vsnprintf(nint buffer, nuint size, nint format, nint args);
        }

        public static partial class Linux
        {

            [LibraryImport("libc")]
            public static partial int vsprintf(nint buffer, nint format, nint args);

            [LibraryImport("libc")]
            public static partial int vsnprintf(nint buffer, nuint size, nint format, nint args);

            [StructLayout(LayoutKind.Sequential, Pack = 4)]
            public struct VaListLinuxX64
            {
                private uint _gpOffset;
                private uint _fpOffset;
                private nint _overflowArgArea;
                private nint _regSaveArea;
            }
        }

        public static partial class MacOs
        {
            [LibraryImport("libSystem")]
            public static partial int vasprintf(ref nint buffer, nint format, nint args);
        }
    }
}