using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Raylib_cs.BleedingEdge;

[StructLayout(LayoutKind.Sequential)]
public struct Float3 : IEquatable<Float3>
{
    public float X;
    public float Y;
    public float Z;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector128<float> AsVector128()
    {
        return new Vector4(X, Y, Z, 0.0f).AsVector128();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector3 AsVector3()
    {
        return new Vector3(X, Y, Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Float3 other)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return AsVector128().Equals(other.AsVector128());
        }
        
        return X.Equals(other.X) && 
               Y.Equals(other.Y) && 
               Z.Equals(other.Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return obj is Float3 other && Equals(other);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Float3 left, Float3 right)
    {
        return left.Equals(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Float3 left, Float3 right)
    {
        return !left.Equals(right);
    }
}