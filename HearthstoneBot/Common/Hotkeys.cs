using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Interop;

namespace HearthstoneBot.Common
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
        private static int int_1;
        private static readonly Queue<Hotkey> queue_0 = new Queue<Hotkey>();
        private static readonly List<Hotkey> list_0 = new List<Hotkey>();
        public static Hotkey Register(string name, Keys key, ModifierKeys modifierKeys, Action<Hotkey> callback)
        {
            Hotkey hotkey = new Hotkey(name, key, modifierKeys, Hotkeys.int_1++, callback);
            Queue<Hotkey> obj = Hotkeys.queue_0;
            lock (obj)
            {
                Hotkeys.queue_0.Enqueue(hotkey);
            }
            Hotkeys.list_0.Add(hotkey);
            Hotkeys.smethod_2();
            return hotkey;
        }

        private static object object_0 = new object();
        private static Thread thread_0;
        private static void smethod_2()
        {
            object obj = Hotkeys.object_0;
            lock (obj)
            {
                if (Hotkeys.thread_0 == null)
                {
                    Hotkeys.thread_0 = new Thread(new ThreadStart(Hotkeys.smethod_3))
                    {
                        Name = "Hotkey Processing Loop",
                        IsBackground = true
                    };
                    Hotkeys.thread_0.Start();
                }
            }
        }


        private static readonly Queue<Hotkey> queue_1 = new Queue<Hotkey>();
        private static void smethod_3()
        {
            try
            {
                while (true)
                {
                    Queue<Hotkey> queue = new Queue<Hotkey>();
                    Queue<Hotkey> queue2 = new Queue<Hotkey>();
                    lock (queue_0)
                    {
                        while (queue_0.Count != 0)
                        {
                            queue.Enqueue(queue_0.Dequeue());
                        }
                    }
                    lock (queue_1)
                    {
                        while (queue_1.Count != 0)
                        {
                            queue2.Enqueue(queue_1.Dequeue());
                        }
                    }
                    while (queue.Count != 0)
                    {
                        smethod_0(queue.Dequeue());
                    }
                    while (queue2.Count != 0)
                    {
                        smethod_1(queue2.Dequeue());
                    }
                    if (!Boolean_0)
                    {
                        foreach (Hotkey item in list_0)
                        {
                            smethod_1(item);
                        }
                    }
                    else
                    {
                        foreach (Hotkey item2 in list_0)
                        {
                            smethod_0(item2);
                        }
                        MouseHook.smethod_0();
                        smethod_4();
                    }
                    Thread.Sleep(100);
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

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr intptr_1, int int_2);

        private static void smethod_1(Hotkey hotkey_0)
        {
            if (!hotkey_0.Boolean_0)
            {
                return;
            }
            if (Hotkeys.UnregisterHotKey(IntPtr.Zero, hotkey_0.Id))
            {
                hotkey_0.Boolean_0 = false;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RegisterHotKey(IntPtr intptr_1, int int_2, uint uint_0, uint uint_1);
        private static void smethod_0(Hotkey hotkey_0)
        {
            if (hotkey_0.Boolean_0)
            {
                return;
            }
            if (Hotkeys.RegisterHotKey(IntPtr.Zero, hotkey_0.Id, (uint)hotkey_0.ModifierKeys, (uint)hotkey_0.Key))
            {
                hotkey_0.Boolean_0 = true;
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PeekMessage(out MSG msg_0, IntPtr intptr_1, uint uint_0, uint uint_1, uint uint_2);
        private static void smethod_4()
        {
            Class232 @class = new Class232();
            while (Hotkeys.PeekMessage(out @class.msg_0, IntPtr.Zero, 786u, 786u, 1u))
            {
                IEnumerable<Hotkey> registeredHotkeys = Hotkeys.RegisteredHotkeys;
                Func<Hotkey, bool> predicate;
                if ((predicate = @class.func_0) == null)
                {
                    predicate = (@class.func_0 = new Func<Hotkey, bool>(@class.method_0));
                }
                Hotkey hotkey = registeredHotkeys.FirstOrDefault(predicate);
                if (hotkey != null)
                {
                    //Hotkeys.ilog_0.DebugFormat(hotkey.Name + " pressed.", Array.Empty<object>());
                    hotkey.Callback(hotkey);
                }
            }
        }

        public static IEnumerable<Hotkey> RegisteredHotkeys
        {
            get
            {
                return Hotkeys.list_0.AsReadOnly();
            }
        }
    }
}
