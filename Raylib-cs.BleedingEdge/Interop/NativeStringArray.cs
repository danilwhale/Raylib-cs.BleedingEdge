using System.Collections;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

public readonly unsafe struct NativeStringArray(uint length, byte** address) : IEnumerable<string?>, IEquatable<NativeStringArray>
{
    public readonly uint Length = length;
    public readonly byte** Address = address;

    public string? this[int index] => Marshal.PtrToStringUTF8((nint)Address[index]);
    public string? this[uint index] => Marshal.PtrToStringUTF8((nint)Address[index]);

    public IEnumerator<string> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Length, (nint)Address);
    }

    public bool Equals(NativeStringArray other)
    {
        return Length == other.Length && Address == other.Address;
    }

    public override bool Equals(object? obj)
    {
        return obj is NativeStringArray other && Equals(other);
    }

    public static bool operator ==(NativeStringArray left, NativeStringArray right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NativeStringArray left, NativeStringArray right)
    {
        return !left.Equals(right);
    }

    private struct Enumerator(NativeStringArray array) : IEnumerator<string?>
    {
        private uint _index;

        public bool MoveNext()
        {
            _index++;
            return _index < array.Length;
        }

        public void Reset()
        {
            _index = 0;
        }

        public string? Current => array[_index];

#nullable disable
        object IEnumerator.Current => Current;
#nullable restore

        public void Dispose()
        {
        }
    }
}