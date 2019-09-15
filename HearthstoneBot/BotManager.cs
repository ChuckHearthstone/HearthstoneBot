using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using GreyMagic;
using HearthstoneBot.Common;

namespace HearthstoneBot
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
        public ClientFrozenEventArgs()
        {
        }
    }

    public class BotChangedEventArgs : EventArgs
    {
        // Token: 0x0600114C RID: 4428 RVA: 0x0000D9CA File Offset: 0x0000BBCA
        internal BotChangedEventArgs(IBot old, IBot @new)
        {
            this.Old = old;
            this.New = @new;
        }

        // Token: 0x04000836 RID: 2102
        public IBot Old;

        // Token: 0x04000837 RID: 2103
        public IBot New;
    }

    class BotManager
    {
        public delegate void BotEvent(IBot bot);

        public static event BotEvent PreStart;

        public static event BotEvent PostStop;


        public static bool IsRunning
        {
            get
            {
                return BotManager.BotThread != null;
            }
        }


        public static Thread BotThread;

        private static string String_0
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
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
                //BotManager.ilog_0.ErrorFormat("[Load] An exception occurred: {0}.", arg);
            }
            return false;
        }

        private static readonly AutoResetEvent autoResetEvent_0 = new AutoResetEvent(false);
        public static bool Stop()
        {
            object obj = BotManager.object_0;
            bool result;
            lock (obj)
            {
                if (BotManager.BotThread == null)
                {
                    //BotManager.ilog_0.ErrorFormat("[Stop] The BotThread is not running. Please use BotManager.Start first.", Array.Empty<object>());
                    result = false;
                }
                else
                {
                    //BotManager.ilog_0.InfoFormat("[Stop] Now requesting the BotThread to stop.", Array.Empty<object>());
                    BotManager.autoResetEvent_0.Set();
                    result = true;
                }
            }
            return result;
        }

        private static bool bool_3;

        public static bool Start()
        {
            object obj = BotManager.object_0;
            bool result;
            lock (obj)
            {
                if (BotManager.IsRunning)
                {
                    //BotManager.ilog_0.ErrorFormat("[Start] The BotThread is already running. Please use BotManager.Stop first.", Array.Empty<object>());
                    result = false;
                }
                else if (!TritonHs.Initialized)
                {
                    //BotManager.ilog_0.ErrorFormat("[Start] TritonHs is not initialized yet.", Array.Empty<object>());
                    result = false;
                }
                else if (BotManager.CurrentBot == null)
                {
                    //BotManager.ilog_0.ErrorFormat("[Start] There is no bot to run. Please assign a bot first.", Array.Empty<object>());
                    result = false;
                }
                else
                {
                    //BotManager.ilog_0.InfoFormat("[Start] Now creating the BotThread.", Array.Empty<object>());
                    BotManager.bool_3 = false;
                    BotManager.BotThread = new Thread(new ThreadStart(BotManager.smethod_4));
                    BotManager.BotThread.Start();
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
                return BotManager.ibot_0;
            }
            set
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    if (BotManager.IsRunning)
                    {
                        throw new InvalidOperationException("The CurrentBot cannot change while the bot is running. Please Stop it first.");
                    }
                    if (value == null)
                    {
                        throw new InvalidOperationException("The CurrentBot cannot be set to null.");
                    }
                    if (BotManager.ibot_0 != value)
                    {
                        IBot old = BotManager.ibot_0;
                        BotManager.ibot_0 = value;
                        TritonHs.InvokeEvent(BotManager.eventHandler_0, new object[]
                        {
                            null,
                            new BotChangedEventArgs(old, BotManager.ibot_0)
                        });
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
                return BotManager.int_1;
            }
            set
            {
                BotManager.int_1 = value;
                if (BotManager.int_1 < 0)
                {
                    BotManager.int_1 = 0;
                }
            }
        }
        private static int int_0;
        public static int MsBetweenTicks
        {
            get
            {
                return BotManager.int_0;
            }
            set
            {
                BotManager.int_0 = value;
                if (BotManager.int_0 < 0)
                {
                    BotManager.int_0 = 0;
                }
                //BotManager.ilog_0.InfoFormat("[BotManager] MsBetweenTicks = {0}", BotManager.int_0);
            }
        }

        private static void smethod_4()
        {
            object obj = BotManager.object_0;
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
                TritonHs.smethod_2(true);
            }
            catch
            {
            }
            try
            {
                BotManager.smethod_0(BotManager.CurrentBot);
                goto IL_FA;
            }
            catch
            {
                BotManager.autoResetEvent_0.Set();
                goto IL_FA;
            }
            IL_87:
            try
            {
                if (BotManager.MsBeforeNextTick != 0)
                {
                    Thread.Sleep(BotManager.MsBeforeNextTick);
                    BotManager.MsBeforeNextTick = 0;
                }
                BotManager.smethod_1(BotManager.CurrentBot);
                BotManager.bool_3 = false;
                if (BotManager.MsBetweenTicks != 0)
                {
                    Thread.Sleep(BotManager.MsBetweenTicks);
                }
            }
            catch (InjectionDesyncException)
            {
                //BotManager.ilog_0.DebugFormat("[BotThreadFunction] An InjectionDesyncException was detected.", Array.Empty<object>());
                BotManager.bool_3 = true;
                TritonHs.InvokeEvent(BotManager.eventHandler_1, new object[]
                {
                    null,
                    new ClientFrozenEventArgs()
                });
            }
            catch
            {
            }
            IL_FA:
            if (!BotManager.autoResetEvent_0.WaitOne(0))
            {
                goto IL_87;
            }
            try
            {
                BotManager.smethod_2(BotManager.CurrentBot);
            }
            catch
            {
            }
            BotManager.BotThread = null;
            if (BotManager.bool_3)
            {
                TritonHs.InvokeEvent(BotManager.eventHandler_1, new object[]
                {
                    null,
                    new ClientFrozenEventArgs()
                });
                return;
            }
            try
            {
                TritonHs.smethod_2(true);
            }
            catch
            {
            }
        }

        private static bool bool_0;
        private static BotManager.BotEvent botEvent_0;
        private static BotManager.BotEvent botEvent_1;
        internal static void smethod_0(IBot ibot_1)
        {
            try
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    if (BotManager.bool_0)
                    {
                        return;
                    }
                    BotManager.bool_0 = true;
                }
                BotManager.smethod_3(ibot_1, BotManager.botEvent_0);
                try
                {
                    using (TritonHs.AcquireFrame())
                    {
                        using (TritonHs.Memory.TemporaryCacheState(false))
                        {
                            TritonHs.Memory.ClearCache();
                            ibot_1.Start();
                        }
                    }
                }
                catch (Exception exception)
                {
                    //BotManager.ilog_0.Error("[Start] Exception during execution:", exception);
                    throw;
                }
                BotManager.smethod_3(ibot_1, BotManager.botEvent_1);
            }
            finally
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    BotManager.bool_0 = false;
                }
            }
        }

        private static void smethod_3(IBot ibot_1, BotManager.BotEvent botEvent_6)
        {
            if (botEvent_6 == null)
            {
                return;
            }
            try
            {
                using (TritonHs.AcquireFrame())
                {
                    using (TritonHs.Memory.TemporaryCacheState(false))
                    {
                        botEvent_6(ibot_1);
                    }
                }
            }
            catch (Exception exception)
            {
                //BotManager.ilog_0.Error("[Invoke] Error during execution:", exception);
                throw;
            }
        }

        private static bool bool_1;
        private static BotManager.BotEvent botEvent_2;
        private static BotManager.BotEvent botEvent_3;
        internal static void smethod_1(IBot ibot_1)
        {
            try
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    if (BotManager.bool_1)
                    {
                        return;
                    }
                    BotManager.bool_1 = true;
                }
                BotManager.smethod_3(ibot_1, BotManager.botEvent_2);
                try
                {
                    using (TritonHs.AcquireFrame())
                    {
                        using (TritonHs.Memory.TemporaryCacheState(false))
                        {
                            TritonHs.Memory.ClearCache();
                            ibot_1.Tick();
                            TritonHs.smethod_2(false);
                        }
                    }
                }
                catch (Exception exception)
                {
                    //BotManager.ilog_0.Error("[Tick] Exception during execution:", exception);
                    throw;
                }
                BotManager.smethod_3(ibot_1, BotManager.botEvent_3);
            }
            finally
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    BotManager.bool_1 = false;
                }
            }
        }

        private static bool bool_2;
        private static BotManager.BotEvent botEvent_4;
        private static BotManager.BotEvent botEvent_5;
        internal static void smethod_2(IBot ibot_1)
        {
            try
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    if (BotManager.bool_2)
                    {
                        return;
                    }
                    BotManager.bool_2 = true;
                }
                BotManager.smethod_3(ibot_1, BotManager.botEvent_4);
                try
                {
                    using (TritonHs.AcquireFrame())
                    {
                        using (TritonHs.Memory.TemporaryCacheState(false))
                        {
                            TritonHs.Memory.ClearCache();
                            ibot_1.Stop();
                        }
                    }
                }
                catch (Exception exception)
                {
                    //BotManager.ilog_0.Error("[Stop] Exception during execution:", exception);
                    throw;
                }
                BotManager.smethod_3(ibot_1, BotManager.botEvent_5);
            }
            finally
            {
                object obj = BotManager.object_0;
                lock (obj)
                {
                    BotManager.bool_2 = false;
                }
            }
        }

    }
}
