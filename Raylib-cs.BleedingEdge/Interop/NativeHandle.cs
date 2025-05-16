using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

public readonly unsafe struct NativeHandle<T>() : IEquatable<NativeHandle<T>>, IDisposable
    where T : unmanaged
{
    public ref T Value => ref Unsafe.AsRef<T>(Address);

    public readonly T* Address = (T*)NativeMemory.AllocZeroed((nuint)sizeof(T));

    public NativeHandle(T value) : this()
    {
        Unsafe.Write(Address, value);
    }
    
    public void Dispose()
    {
        NativeMemory.Free(Address);
    }

    public override int GetHashCode()
    {
        return ((nint)Address).GetHashCode();
    }

    public bool Equals(NativeHandle<T> other)
    {
        return Address == other.Address;
    }

    public override bool Equals(object? obj)
    {
        return obj is NativeHandle<T> other && Equals(other);
    }

    public static bool operator ==(NativeHandle<T> left, NativeHandle<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NativeHandle<T> left, NativeHandle<T> right)
    {
        return !left.Equals(right);
    }
}