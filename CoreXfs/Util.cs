using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreXfs
{
    public class Util
    {
        private static Regex regVersion = new Regex(@"^\d+\.\d+$");
        public static readonly int IntPtrSize = 0;
        static Util()
        {
            IntPtrSize = Marshal.SizeOf(typeof(IntPtr));
        }
        public static void PtrToStructure<T>(IntPtr ptr, ref T p) where T : struct
        {
            p = (T)Marshal.PtrToStructure(ptr, typeof(T));
        }
        public static int ParseVersionString(string lowVersion, string hightVersion)
        {
            if (regVersion.IsMatch(lowVersion) && regVersion.IsMatch(hightVersion))
            {
                string[] ssLow = lowVersion.Split('.');
                string[] ssHigh = hightVersion.Split('.');
                int low = int.Parse(ssLow[0]) | (int.Parse(ssLow[1]) << 8);
                int high = int.Parse(ssHigh[0]) | (int.Parse(ssHigh[1]) << 8);
                return high | (low << 16);
            }
            return -1;
        }
        public static T[] XFSPtrToArray<T>(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                int len = 0;
                for (int i = 0; Marshal.ReadIntPtr(IntPtr.Add(ptr, i)) != IntPtr.Zero; i += IntPtrSize)
                    ++len;
                if (len > 0)
                {
                    T[] arr = new T[len];
                    for (int i = 0; i < len; ++i)
                    {
                        arr[i] = (T)Marshal.PtrToStructure(Marshal.ReadIntPtr(IntPtr.Add(ptr, i * IntPtrSize)), typeof(T));
                    }
                    return arr;
                }
            }
            return new T[0];
        }
    }
}
