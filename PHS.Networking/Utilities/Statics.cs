using System;
using System.Collections.Generic;

namespace PHS.Networking.Utilities
{
    public static class Statics
    {
        public static byte[] ByteArrayAppend(byte[] first, byte[] second)
        {
            var array = new byte[first.Length + second.Length];
            first.CopyTo(array, 0);
            second.CopyTo(array, first.Length);
            return array;
        }
        public static byte[][] ByteArraySeparate(byte[] source, byte[] separator)
        {
            var Parts = new List<byte[]>();
            var Index = 0;
            byte[] Part;
            for (var I = 0; I < source.Length; ++I)
            {
                if (ByteArrayEquals(source, separator, I))
                {
                    if (I - Index > 0)
                    {
                        Part = new byte[I - Index];
                        Array.Copy(source, Index, Part, 0, Part.Length);
                        Parts.Add(Part);
                    }
                    Index = I + separator.Length;
                    I += separator.Length - 1;
                }
            }
            if (Index - Index > 0)
            {
                Part = new byte[source.Length - Index];
                Array.Copy(source, Index, Part, 0, Part.Length);
                Parts.Add(Part);
            }
            return Parts.ToArray();
        }
        private static bool ByteArrayEquals(byte[] source, byte[] separator, int index)
        {
            for (int i = 0; i < separator.Length; ++i)
            {
                if (index + i >= source.Length || source[index + i] != separator[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ByteArrayEquals(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static int ByteArrayContainsSequence(byte[] toSearch, byte[] toFind)
        {
            for (var i = 0; i < toSearch.Length; i++)
            { 
                if (ByteArrayEquals(toSearch, toFind, i))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
