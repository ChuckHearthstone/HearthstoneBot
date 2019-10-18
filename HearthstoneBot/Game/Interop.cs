using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace HearthstoneBot.Game
{
    class Interop
    {
        public delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        internal static IntPtr smethod_0(Process process_0, string string_0)
        {
            using (IEnumerator<IntPtr> enumerator = smethod_1(process_0).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    IntPtr intPtr = enumerator.Current;
                    StringBuilder stringBuilder = new StringBuilder(1024);
                    GetClassName(intPtr, stringBuilder, stringBuilder.Capacity);
                    if (stringBuilder.ToString() == string_0)
                    {
                        return intPtr;
                    }
                }
            }
            return IntPtr.Zero;
        }

        internal static IEnumerable<IntPtr> smethod_1(Process process_0)
        {
            var @class = new Class245();
            @class.list_0 = new List<IntPtr>();
            foreach (object obj in process_0.Threads)
            {
                int id = ((ProcessThread)obj).Id;
                EnumThreadDelegate lpfn;
                if ((lpfn = @class.enumThreadDelegate_0) == null)
                {
                    lpfn = (@class.enumThreadDelegate_0 = @class.method_0);
                }
                EnumThreadWindows(id, lpfn, IntPtr.Zero);
            }
            return @class.list_0;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowInfo(IntPtr hWnd, ref WindowInfoWin32 pwi);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);
    }
}
