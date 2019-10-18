using System;
using System.Threading;
using HearthstoneBot.Mapping;

namespace HearthstoneBot.Game
{
    public static class Client
    {
        public static void LeftClickAt(Vector3 center)
        {
            Client.smethod_2(Camera.Main, center, true);
        }

        private static void smethod_2(Camera camera_0, Vector3 vector3_0, bool bool_0)
        {
            if (camera_0 != null)
            {
                Vector3 vector = camera_0.WorldToScreenPoint(vector3_0);
                Client.smethod_0((int)vector.X, Screen.Height - (int)vector.Y, bool_0);
            }
        }
        private static IntPtr intptr_0 = IntPtr.Zero;
        public static int DelayAfterMouseClick = 100;
        public static int DelayAfterMouseMove = 50;

        private static void smethod_0(int int_0, int int_1, bool bool_0)
        {
            PegUI pegUI = PegUI.Get();
            if (pegUI != null)
            {
                pegUI.OnAppFocusChanged(true, Client.intptr_0);
            }
            Input.SetMousePos(int_0, int_1);
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                Thread.Sleep(Client.DelayAfterMouseMove);
            }
            if (bool_0)
            {
                Client.ClickLMB();
                return;
            }
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                Thread.Sleep(Client.DelayAfterMouseClick);
            }
        }

        public static void ClickLMB()
        {
            PegUI pegUI = PegUI.Get();
            if (pegUI != null)
            {
                pegUI.OnAppFocusChanged(true, Client.intptr_0);
            }
            Input.PressLMB();
            PegUI pegUI2 = PegUI.Get();
            if (pegUI2 != null)
            {
                pegUI2.OnAppFocusChanged(true, Client.intptr_0);
            }
            Input.ReleaseLMB();
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                Thread.Sleep(Client.DelayAfterMouseClick);
            }
        }
    }
}
