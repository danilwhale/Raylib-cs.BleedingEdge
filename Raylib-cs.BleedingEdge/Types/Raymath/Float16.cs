using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

// column-major
[StructLayout(LayoutKind.Sequential)]
public struct Float16 : IEquatable<Float16>
{
    public Vector4 X; // first column
    public Vector4 Y; // second column
    public Vector4 Z; // third column
    public Vector4 W; // fourth column

    /// <remarks>Matrix still will be in column-major order, make sure to transpose it.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Matrix4x4 AsMatrix4x4()
    {
        return Unsafe.ReadUnaligned<Matrix4x4>(ref Unsafe.As<Float16, byte>(ref this));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Float16 other)
    {
        return X.Equals(other.X) &&
               Y.Equals(other.Y) &&
               Z.Equals(other.Z) &&
               W.Equals(other.W);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
    {
        return obj is Float16 other && Equals(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float16 left, Float16 right)
    {
        return left.Equals(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float16 left, Float16 right)
    {
        return !left.Equals(right);
    }
}