using System;
using System.Diagnostics;
using System.IO;
using GreyMagic;

namespace HearthstoneBot
{
    class TritonHs
    {
        private static ExternalProcessMemory externalProcessMemory_0;

        internal static string String_0 => Class247.String_0;

        public static bool Initialized { get; set; }

        internal delegate byte[] Delegate6(string v, out string message);

        internal static Class276 class276_0;

        private static IntPtr intptr_1;

        private static IntPtr intptr_0;

        public static IntPtr ClientWindowHandle
        {
            get
            {
                if (intptr_0 == IntPtr.Zero)
                {
                    intptr_0 = Interop.smethod_0(Memory.Process, "UnityWndClass");
                }
                return intptr_0;
            }
        }

        public static string MainAssemblyDir
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(TritonHs.Memory.Process.MainModule.FileName), "Hearthstone_Data", "Managed");
            }
        }

        public static string UnityEngineAssemblyPath
        {
            get
            {
                return Path.Combine(TritonHs.MainAssemblyDir, "UnityEngine.dll");
            }
        }

        public static string MainAssemblyPath
        {
            get
            {
                return Path.Combine(TritonHs.MainAssemblyDir, "Assembly-CSharp.dll");
            }
        }

        internal static bool bool_0 = true;

        internal static Class276 Class276_0
        {
            get
            {
                return TritonHs.class276_0;
            }
        }

        internal static bool smethod_0(Process process_0, Delegate6 delegate6_0, out string string_0)
        {
            if (Initialized)
            {
                string_0 = "SmartInitialize has already been called.";
                return false;
            }
            if (process_0 == null)
            {
                string_0 = "process == null";
                return false;
            }
            if (delegate6_0 == null)
            {
                string_0 = "getOffsetsDelegate == null";
                return false;
            }
            if (Class247.smethod_1(process_0.MainModule.FileName) == Class247.UInt32_0)
            {
                string_0 = "This client version is unsupported.";
                return false;
            }
            if (delegate6_0(String_0, out string_0) != null)
            {
                if (!string.IsNullOrEmpty(string_0))
                {
                    string_0 = string.Format("The data required to run the bot was not successfully obtained. Please make sure your key is still valid at the Buddy Auth Portal: http://buddyauth.com/User/Keys {0}{0}For any further assistance, please contact support: https://bosslandgmbh.zendesk.com/home", Environment.NewLine);
                }
                return false;
            }
            try
            {
                ExternalProcessMemoryInitParams externalProcessMemoryInitParams = new ExternalProcessMemoryInitParams
                {
                    Process = process_0,
                    StartupRasm = false,
                    DefaultCacheValue = true,
                    Executor = ExecutorInitParams.DX9()
                };
                externalProcessMemoryInitParams.Executor.MinSkipBytes = 8;
                try
                {
                    externalProcessMemory_0 = new ExternalProcessMemory(externalProcessMemoryInitParams);
                }
                catch (Exception ex)
                {
                    if (!ex.Message.Equals("Could not find DX9 in process!"))
                    {
                        throw;
                    }
                    //TritonHs.ilog_0.Info("Process is not using DX9, now trying DX11...");
                    externalProcessMemoryInitParams = new ExternalProcessMemoryInitParams
                    {
                        Process = process_0,
                        StartupRasm = false,
                        DefaultCacheValue = true,
                        Executor = ExecutorInitParams.DX11()
                    };
                    externalProcessMemoryInitParams.Executor.MinSkipBytes = 8;
                    externalProcessMemory_0 = new ExternalProcessMemory(externalProcessMemoryInitParams);
                }
                externalProcessMemory_0.ProcessExited += Class246.ChuckInstance9.method_0;
                class276_0 = new Class276(externalProcessMemory_0);
                using (AcquireFrame())
                {
                    intptr_1 = class276_0.method_2();
                }
                ProcessHookManager.smethod_3();
                Hotkeys.Initialize(ClientWindowHandle);
                Input.DebugMouseCursorPos = false;
                Initialized = true;
                TritonHs.bool_0 = false;
            }
            catch (Exception ex2)
            {
                string_0 = ex2.ToString();
                return false;
            }
            string_0 = string.Empty;
            return true;
        }

        public static FrameLock AcquireFrame()
        {
            return externalProcessMemory_0.AcquireFrame(true);
        }

        public static ExternalProcessMemory Memory => externalProcessMemory_0;
    }
}
