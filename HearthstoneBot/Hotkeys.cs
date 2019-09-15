using System;
using System.Runtime.InteropServices;

namespace HearthstoneBot
{
    class Hotkeys
    {
        private static bool bool_0;

        private static IntPtr intptr_0;

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        public static void Initialize(IntPtr windowHandleToWatch)
        {
            if (bool_0)
            {
                return;
            }
            MouseHook.smethod_0();
            intptr_0 = windowHandleToWatch;
            bool_0 = true;
        }

        internal static bool Boolean_0
        {
            get
            {
                return GetForegroundWindow() == intptr_0;
            }
        }
    }
}
