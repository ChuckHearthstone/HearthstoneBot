using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace HearthstoneBot.Common
{
    class MouseHook
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys keys_0);

        private static Thread thread_0;

        private static bool Boolean_0
        {
            get
            {
                return (GetAsyncKeyState(Keys.LButton) & 32769) != 0 || (GetAsyncKeyState(Keys.RButton) & 32769) != 0 || (GetAsyncKeyState(Keys.MButton) & 32769) != 0;
            }
        }

        private static volatile bool bool_0;

        public delegate void MouseEventDelegate();

        private static MouseEventDelegate mouseEventDelegate_0;

        private static MouseEventDelegate mouseEventDelegate_1;

        internal static void smethod_0()
        {
            if (thread_0 != null && thread_0.IsAlive)
            {
                return;
            }
            thread_0 = new Thread(smethod_1)
            {
                IsBackground = true,
                Name = "Mouse Polling Thread"
            };
            thread_0.Start();
        }

        private static void smethod_1()
        {
            try
            {
                for (;;)
                {
                    Thread.Sleep(100);
                    if (Hotkeys.Boolean_0)
                    {
                        if (Boolean_0)
                        {
                            if (!bool_0)
                            {
                                mouseEventDelegate_0?.Invoke();
                                bool_0 = true;
                            }
                        }
                        else if (bool_0)
                        {
                            mouseEventDelegate_1?.Invoke();
                            bool_0 = false;
                        }
                    }
                    else if (bool_0)
                    {
                        mouseEventDelegate_1?.Invoke();
                        bool_0 = false;
                    }
                }
            }
            catch (Exception ex)
            {
                EventNotifyManager.Instance.OnChildThreadExceptionOccured(new ChildThreadExceptionOccuredEventArgs
                {
                    Exception = ex
                });
            }
        }
    }
}
