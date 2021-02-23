using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Shotr.Core.MimeDetect
{
    public static class Extensions
    {
        public static byte[] ToByte(this string c)
        {
            return Encoding.UTF8.GetBytes(c);
        }
        
        public static bool Equals(this byte[] b, string c)
        {
            return UnSafeEquals(b, c.ToByte());
        }

        public static bool Equals(this byte[] b, byte[] c)
        {
            return UnSafeEquals(b, c);
        }

        public static bool Prefix(this byte[] b, byte[] c)
        {
            return UnSafeEquals(b.Take(c.Length).ToArray(), c);
        }
        
        public static bool Prefix(this byte[] b, string c)
        {
            return UnSafeEquals(b.Take(c.Length).ToArray(), c.ToByte());
        }

        public static bool Contains(this byte[] b, string c)
        {
            return Locate(b, c.ToByte());
        }

        public static bool Contains(this byte[] b, byte[] c)
        {
            return Locate(b, c);
        }

        public static uint ToBigEndian(this uint x)
        {
            return ((x & 0x000000ff) << 24) +  // First byte
                   ((x & 0x0000ff00) << 8) +   // Second byte
                   ((x & 0x00ff0000) >> 8) +   // Third byte
                   ((x & 0xff000000) >> 24);   // Fourth byte
        }
        
        private static readonly int [] Empty = new int [0];
        private static bool Locate (byte[] self, byte[] candidate)
        {
            var list = new List<int> ();

            for (int i = 0; i < self.Length; i++) {
                if (!IsMatch (self, i, candidate))
                    continue;

                list.Add (i);
            }

            return list.Count != 0;
        }

        static bool IsMatch (byte [] array, int position, byte [] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;

            for (int i = 0; i < candidate.Length; i++)
                if (array [position + i] != candidate [i])
                    return false;

            return true;
        }
        
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        private static unsafe bool UnSafeEquals(byte[] strA, byte[] strB)
        {
            int length = strA.Length;
            if (length != strB.Length)
            {
                return false;
            }
            fixed (byte* str = strA)
            {
                byte* chPtr = str;
                fixed (byte* str2 = strB)
                {
                    byte* chPtr2 = str2;
                    byte* chPtr3 = chPtr;
                    byte* chPtr4 = chPtr2;
                    while (length >= 10)
                    {
                        if ((((*(((int*)chPtr3)) != *(((int*)chPtr4))) || (*(((int*)(chPtr3 + 2))) != *(((int*)(chPtr4 + 2))))) || ((*(((int*)(chPtr3 + 4))) != *(((int*)(chPtr4 + 4)))) || (*(((int*)(chPtr3 + 6))) != *(((int*)(chPtr4 + 6)))))) || (*(((int*)(chPtr3 + 8))) != *(((int*)(chPtr4 + 8)))))
                        {
                            break;
                        }
                        chPtr3 += 10;
                        chPtr4 += 10;
                        length -= 10;
                    }
                    while (length > 0)
                    {
                        if (*(((int*)chPtr3)) != *(((int*)chPtr4)))
                        {
                            break;
                        }
                        chPtr3 += 2;
                        chPtr4 += 2;
                        length -= 2;
                    }
                    return (length <= 0);
                }
            }
        }
    }
}