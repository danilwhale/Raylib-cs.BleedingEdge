using System.Collections;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge.Interop;

public unsafe readonly struct NativeStringArray(uint length, sbyte** arr) : IEnumerable<string>
{
    private readonly uint _length = length;
    public uint Length => _length;

    public string this[int index] => Marshal.PtrToStringUTF8((IntPtr)arr[index]) ?? string.Empty;
    public string this[uint index] => Marshal.PtrToStringUTF8((IntPtr)arr[index]) ?? string.Empty;

    public IEnumerator<string> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private struct Enumerator(NativeStringArray array) : IEnumerator<string>
    {
        private uint _index;
        
        public bool MoveNext()
        {
            _index++;
            return _index < array._length;
        }

        public void Reset()
        {
            _index = 0;
        }

        public string Current => array[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}