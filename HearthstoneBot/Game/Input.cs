using System;
using System.Diagnostics;
using System.Threading;

namespace HearthstoneBot.Game
{
    class Input
    {
        public static bool DebugMouseCursorPos { get; set; }
        private static IntPtr IntPtr_0
        {
            get
            {
                return TritonHs.ClientWindowHandle;
            }
        }

        public static void SetMousePos(int cx, int cy)
        {
            RectWin32 client = ProcessHookManager.WindowInfo.Client;
            ProcessHookManager.ScreenToClient(cx, cy, 1);
            ProcessHookManager.SetCursorPos(cx + client.Left, cy + client.Top, 1);
            Input.MoveMouse(cx, cy);
            if (Input.DebugMouseCursorPos)
            {
                Interop.SetCursorPos(cx + client.Left, cy + client.Top);
            }
        }
        public static void MoveMouse(int cx, int cy)
        {
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                Interop.SendMessage(Input.IntPtr_0, 32, Input.IntPtr_0, (IntPtr)33554433);
                Interop.SendMessage(Input.IntPtr_0, 512, IntPtr.Zero, (IntPtr)((cx & 65535) | (cy & 65535) << 16));
            }
        }
        private static readonly Stopwatch stopwatch_0 = Stopwatch.StartNew();
        public static int InputEventMsDelay = 50;
        public static void ReleaseLMB()
        {
            int num = (int)((long)Input.InputEventMsDelay - Input.stopwatch_0.ElapsedMilliseconds);
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                if (num > 0)
                {
                    Thread.Sleep(num);
                }
                Interop.SendMessage(Input.IntPtr_0, 514, (IntPtr)1, IntPtr.Zero);
            }
            Input.stopwatch_0.Restart();
        }

        public static void PressLMB()
        {
            int num = (int)((long)Input.InputEventMsDelay - Input.stopwatch_0.ElapsedMilliseconds);
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                if (num > 0)
                {
                    Thread.Sleep(num);
                }
                Interop.SendMessage(Input.IntPtr_0, 513, (IntPtr)1, IntPtr.Zero);
            }
            Input.stopwatch_0.Restart();
        }
    }
}
