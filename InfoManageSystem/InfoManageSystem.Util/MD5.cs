using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfoManageSystem.Util
{
    public class MD5
    {
        [DllImport(@"Win32Lib.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr EncryptStringW([MarshalAs(UnmanagedType.LPWStr)]string inString);

        public static string encode(string src)
        {
            IntPtr ip = EncryptStringW(src);
            string encoded = Marshal.PtrToStringUni(ip);
            return encoded; 
        }
    }
}
