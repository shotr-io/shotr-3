using System;
using System.Runtime.InteropServices;

namespace Shotr.Core.Services
{
    public class WineDetectionService
    {
        public static bool IsWine()
        {
            try
            {
                var hModule = LoadLibrary("ntdll.dll");
                var proc = GetProcAddress(hModule, "wine_get_version");
                var exists = proc != IntPtr.Zero;

                //Clean up, although not really necessary here, better to use a SafeHandle anyway, not exception safe!!!
                FreeLibrary(hModule);
                return exists;
            }
            catch
            {
                return false;
            }
        }

        //From Pinvoke.net
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr
            LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeLibrary(IntPtr hModule);
    }
}
