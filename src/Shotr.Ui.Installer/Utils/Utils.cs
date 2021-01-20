using System;
using System.IO;

namespace Shotr.Ui.Installer.Utils
{
    class Utils
    {
        private static string abc = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static Random r;
        public static string RandStr(int count)
        {
            var ret = "";
            for (var i = 0; i < count; i++)
                ret += abc[r.Next(0, abc.Length - 1)];
            return ret;
        }
        public static long FreeBytes(string drive)
        {
            foreach(var x in DriveInfo.GetDrives())
            {
                if (x.IsReady && x.RootDirectory.FullName == drive)
                {
                    return x.TotalFreeSpace;
                }
            }
            return 0;
        }
    }
}
