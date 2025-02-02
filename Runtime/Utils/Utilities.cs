using System;
using System.Collections;
using UnityEngine;

namespace ID.Utils
{
    public static class Utilities
    {
        public static byte BitsToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        public static byte BoolsToByte(bool[] bools)
        {
            if (bools.Length > 8)
            {
                Debug.LogError("Please send a max of 8 bools at a time");
                return 0;
            }
            BitArray total = new BitArray(new byte[1]);
            for (int i = 0; i < bools.Length; i++)
            {
                total.Set(i, bools[i]);
            }
            return BitsToByte(total);
        }

        public static BitArray ByteToBits(byte b)
        {
            byte[] bytes = new byte[1] { b };
            return new BitArray(bytes);
        }

        public static bool[] ByteToBools(byte b, int length)
        {
            bool[] bools = new bool[length];
            BitArray bits = ByteToBits(b);
            for (int i = 0; i < length; i++)
            {
                bools[i] = bits[i];
            }
            return bools;
        }

        public static Transform GetTransformInParentWithComponent<T>(this Transform t)
        {
            T component = t.gameObject.GetComponent<T>();
            if (t.parent != null && component == null) return t.parent.GetTransformInParentWithComponent<T>();
            return t;
        }
    }
}