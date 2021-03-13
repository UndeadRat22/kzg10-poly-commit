using System;
using System.Runtime.InteropServices;

namespace Commitments.Types
{
    [StructLayout(LayoutKind.Explicit, Size = ByteSize)]
    public struct Fp
    {
        public const int ByteSize = 48;
        [FieldOffset(0)]
        private FpBuffer _value;

        public byte[] GetBytes()
        {
            var result = new byte[ByteSize];
            unsafe
            {
                for (var i = 0; i < ByteSize; i++)
                {
                    result[i] = _value.bytes[i];
                }
            }
            return result;
        }

        public void SetBytes(byte[] bytes)
        {
            var start = ByteSize - bytes.Length;
            unsafe
            {
                for (var i = start; i < ByteSize; i++)
                {
                    _value.bytes[i] = bytes[i - start];
                }
            }
        }

        public static Fp FromBytes(byte[] bytes)
        {
            var fp = new Fp();
            fp.SetBytes(bytes);

            return fp;
        }

        public override string ToString()
        {
            var bytes = GetBytes();
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = Fp.ByteSize)]
    internal unsafe struct FpBuffer
    {
        [FieldOffset(0)]
        public fixed byte bytes[Fp.ByteSize];
    }
}