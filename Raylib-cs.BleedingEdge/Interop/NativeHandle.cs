using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

public readonly unsafe struct NativeHandle<T> : IDisposable 
    where T : unmanaged
{
    public ref T Value => ref Unsafe.AsRef<T>(Address);

    public readonly T* Address;

    public NativeHandle()
    {
        Address = (T*)NativeMemory.AllocZeroed((nuint)sizeof(T));
    }

    public NativeHandle(T value) : this()
    {
        Unsafe.Write(Address, value);
    }
    
    public void Dispose()
    {
        NativeMemory.Free(Address);
    }
}