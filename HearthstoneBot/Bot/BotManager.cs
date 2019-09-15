using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using GreyMagic;
using HearthstoneBot.Common;
using HearthstoneBot.Game;

namespace HearthstoneBot.Bot
{
    public interface IRunnable
    {
        // Token: 0x06001173 RID: 4467
        void Start();

        // Token: 0x06001174 RID: 4468
        void Tick();

        // Token: 0x06001175 RID: 4469
        void Stop();
    }

    public interface IBase
    {
        // Token: 0x0600118F RID: 4495
        void Initialize();

        // Token: 0x06001190 RID: 4496
        void Deinitialize();
    }

    public interface IBot : IRunnable, IBase
    {
    }
    public class ClientFrozenEventArgs : EventArgs
    {
        // Token: 0x0600114B RID: 4427 RVA: 0x0000D9C2 File Offset: 0x0000BBC2
    }

    public class BotChangedEventArgs : EventArgs
    {
        // Token: 0x0600114C RID: 4428 RVA: 0x0000D9CA File Offset: 0x0000BBCA
        internal BotChangedEventArgs(IBot old, IBot @new)
        {
            Old = old;
            New = @new;
        }

        // Token: 0x04000836 RID: 2102
        public IBot Old;

        // Token: 0x04000837 RID: 2103
        public IBot New;
    }

    public class BotManager
    {
        static BotManager()
        {
            BotManager.object_0 = new object();
            BotManager.MsBetweenTicks = 15;
        }

        public delegate void BotEvent(IBot bot);

        public static event BotEvent PreStart;

        public static event BotEvent PostStop;


        public static bool IsRunning
        {
            get
            {
                return BotThread != null;
            }
        }


        public static Thread BotThread;

        private static string String_0
        {
            get
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly == null)
                {
                    throw new Exception("Can not find entry assembly");
                }
                else
                {
                    return Path.GetDirectoryName(entryAssembly.Location);
                }
            }
        }

        public static string BotsPath
        {
            get
            {
                return Path.Combine(String_0, "Bots");
            }
        }
        private static readonly object object_0;
        public static List<IBot> Bots;

        public static bool Load()
        {
            try
            {
                string botsPath = BotsPath;
                object obj = object_0;
                lock (obj)
                {
                    if (Bots != null)
                    {
                        //BotManager.ilog_0.ErrorFormat("[Load] This function can only be called once.", Array.Empty<object>());
                        return false;
                    }
                    if (!Directory.Exists(botsPath))
                    {
                        Directory.CreateDirectory(botsPath);
                    }
                    Bots = new List<IBot>();

                    AssemblyLoader<IBot> loader = new AssemblyLoader<IBot>(botsPath, false);
                    var types = loader.Instances.AsReadOnly();
                    foreach (IBot bot in types)
                    {
                        try
                        {
                            //Utility.smethod_0(bot);
                            bot.Initialize();
                            Bots.Add(bot);
                        }
                        catch (Exception exception)
                        {
                            //BotManager.ilog_0.Debug("[Load] Exception thrown when initializing " + bot.Name + ". Bot  will not be loaded.", exception);
                            //Utility.smethod_1(bot);
                            bot.Deinitialize();
                        }
                    }
                    return true;
                }
            }
            catch (Exception arg)
            {
                Console.WriteLine(arg);
                //BotManager.ilog_0.ErrorFormat("[Load] An exception occurred: {0}.", arg);
            }
            return false;
        }

        private static readonly AutoResetEvent autoResetEvent_0 = new AutoResetEvent(false);
        public static bool Stop()
        {
            object obj = object_0;
            bool result;
            lock (obj)
            {
                if (BotThread == null)
                {
                    //BotManager.ilog_0.ErrorFormat("[Stop] The BotThread is not running. Please use BotManager.Start first.", Array.Empty<object>());
                    result = false;
                }
                else
                {
                    //BotManager.ilog_0.InfoFormat("[Stop] Now requesting the BotThread to stop.", Array.Empty<object>());
                    autoResetEvent_0.Set();
                    result = true;
                }
            }
            return result;
        }

        private static bool bool_3;

        public static bool Start()
        {
            object obj = object_0;
            bool result;
            lock (obj)
            {
                if (IsRunning)
                {
                    Console.WriteLine("[Start] The BotThread is already running. Please use BotManager.Stop first.");
                    //BotManager.ilog_0.ErrorFormat("[Start] The BotThread is already running. Please use BotManager.Stop first.", Array.Empty<object>());
                    result = false;
                }
                else if (!TritonHs.Initialized)
                {
                    Console.WriteLine("[Start] TritonHs is not initialized yet.");
                    //BotManager.ilog_0.ErrorFormat("[Start] TritonHs is not initialized yet.", Array.Empty<object>());
                    result = false;
                }
                else if (CurrentBot == null)
                {
                    Console.WriteLine("[Start] There is no bot to run. Please assign a bot first.");
                    //BotManager.ilog_0.ErrorFormat("[Start] There is no bot to run. Please assign a bot first.", Array.Empty<object>());
                    result = false;
                }
                else
                {
                    Console.WriteLine("[Start] Now creating the BotThread.");
                    //BotManager.ilog_0.InfoFormat("[Start] Now creating the BotThread.", Array.Empty<object>());
                    bool_3 = false;
                    BotThread = new Thread(smethod_4);
                    BotThread.Start();
                    result = true;
                }
            }
            return result;
        }

        private static IBot ibot_0;
        private static EventHandler<BotChangedEventArgs> eventHandler_0;
        public static IBot CurrentBot
        {
            get
            {
                return ibot_0;
            }
            set
            {
                object obj = object_0;
                lock (obj)
                {
                    if (IsRunning)
                    {
                        throw new InvalidOperationException("The CurrentBot cannot change while the bot is running. Please Stop it first.");
                    }
                    if (value == null)
                    {
                        throw new InvalidOperationException("The CurrentBot cannot be set to null.");
                    }
                    if (ibot_0 != value)
                    {
                        IBot old = ibot_0;
                        ibot_0 = value;
                        TritonHs.InvokeEvent(eventHandler_0, null, new BotChangedEventArgs(old, ibot_0));
                    }
                }
            }
        }

        private static EventHandler<ClientFrozenEventArgs> eventHandler_1;
        private static int int_1;
        public static int MsBeforeNextTick
        {
            get
            {
                return int_1;
            }
            set
            {
                int_1 = value;
                if (int_1 < 0)
                {
                    int_1 = 0;
                }
            }
        }
        private static int int_0;
        public static int MsBetweenTicks
        {
            get
            {
                return int_0;
            }
            set
            {
                int_0 = value;
                if (int_0 < 0)
                {
                    int_0 = 0;
                }
                //BotManager.ilog_0.InfoFormat("[BotManager] MsBetweenTicks = {0}", BotManager.int_0);
            }
        }

        private static void smethod_4()
        {
            object obj = object_0;
            lock (obj)
            {
                Thread.Sleep(1);
            }
            TritonHs.Memory.DisableCache();
            TritonHs.Memory.ClearCache();
            TritonHs.Memory.Executor.FrameDropWaitTime = 15000u;
            TritonHs.Memory.Executor.ExecuteWaitTime = 15000;
            try
            {
                TritonHs.smethod_2();
            }
            catch
            {
            }
            try
            {
                smethod_0(CurrentBot);
                goto IL_FA;
            }
            catch
            {
                autoResetEvent_0.Set();
                goto IL_FA;
            }
            IL_87:
            try
            {
                if (MsBeforeNextTick != 0)
                {
                    Thread.Sleep(MsBeforeNextTick);
                    MsBeforeNextTick = 0;
                }
                smethod_1(CurrentBot);
                bool_3 = false;
                if (MsBetweenTicks != 0)
                {
                    Thread.Sleep(MsBetweenTicks);
                }
            }
            catch (InjectionDesyncException)
            {
                //BotManager.ilog_0.DebugFormat("[BotThreadFunction] An InjectionDesyncException was detected.", Array.Empty<object>());
                bool_3 = true;
                TritonHs.InvokeEvent(eventHandler_1, null, new ClientFrozenEventArgs());
            }
            catch
            {
            }
            IL_FA:
            if (!autoResetEvent_0.WaitOne(0))
            {
                goto IL_87;
            }
            try
            {
                smethod_2(CurrentBot);
            }
            catch
            {
            }
            BotThread = null;
            if (bool_3)
            {
                TritonHs.InvokeEvent(eventHandler_1, null, new ClientFrozenEventArgs());
                return;
            }
            try
            {
                TritonHs.smethod_2();
            }
            catch
            {
            }
        }

        private static bool bool_0;
        private static BotEvent botEvent_0;
        private static BotEvent botEvent_1;
        internal static void smethod_0(IBot ibot_1)
        {
            try
            {
                object obj = object_0;
                lock (obj)
                {
                    if (bool_0)
                    {
                        return;
                    }
                    bool_0 = true;
                }
                smethod_3(ibot_1, botEvent_0);
                using (TritonHs.AcquireFrame())
                {
                    using (TritonHs.Memory.TemporaryCacheState(false))
                    {
                        TritonHs.Memory.ClearCache();
                        ibot_1.Start();
                    }
                }

                smethod_3(ibot_1, botEvent_1);
            }
            finally
            {
                object obj = object_0;
                lock (obj)
                {
                    bool_0 = false;
                }
            }
        }

        private static void smethod_3(IBot ibot_1, BotEvent botEvent_6)
        {
            if (botEvent_6 == null)
            {
                return;
            }

            using (TritonHs.AcquireFrame())
            {
                using (TritonHs.Memory.TemporaryCacheState(false))
                {
                    botEvent_6(ibot_1);
                }
            }
        }

        private static bool bool_1;
        private static BotEvent botEvent_2;
        private static BotEvent botEvent_3;
        internal static void smethod_1(IBot ibot_1)
        {
            try
            {
                object obj = object_0;
                lock (obj)
                {
                    if (bool_1)
                    {
                        return;
                    }
                    bool_1 = true;
                }
                smethod_3(ibot_1, botEvent_2);
                using (TritonHs.AcquireFrame())
                {
                    using (TritonHs.Memory.TemporaryCacheState(false))
                    {
                        TritonHs.Memory.ClearCache();
                        ibot_1.Tick();
                        TritonHs.smethod_2(false);
                    }
                }

                smethod_3(ibot_1, botEvent_3);
            }
            finally
            {
                object obj = object_0;
                lock (obj)
                {
                    bool_1 = false;
                }
            }
        }

        private static bool bool_2;
        private static BotEvent botEvent_4;
        private static BotEvent botEvent_5;
        internal static void smethod_2(IBot ibot_1)
        {
            try
            {
                object obj = object_0;
                lock (obj)
                {
                    if (bool_2)
                    {
                        return;
                    }
                    bool_2 = true;
                }
                smethod_3(ibot_1, botEvent_4);
                using (TritonHs.AcquireFrame())
                {
                    using (TritonHs.Memory.TemporaryCacheState(false))
                    {
                        TritonHs.Memory.ClearCache();
                        ibot_1.Stop();
                    }
                }

                smethod_3(ibot_1, botEvent_5);
            }
            finally
            {
                object obj = object_0;
                lock (obj)
                {
                    bool_2 = false;
                }
            }
        }

    }
}
