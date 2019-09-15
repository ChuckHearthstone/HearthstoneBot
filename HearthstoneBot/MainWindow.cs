using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace HearthstoneBot
{
    class MainWindow
    {
        private Mutex mutex_0;

        private Process process_0;

        private void method_22()
        {
            if (!Class9.smethod_4(out mutex_0, out process_0))
            {
                //MainWindow.ilog_0.Error("Could not attach to a Hearthstone process. Please make sure an available Hearthstone process is running.");
                var error = string.Format(
                    "Could not attach to a Hearthstone process. Please make sure an available Hearthstone process is running.{0}{0}Hearthbuddy will now close.",
                    Environment.NewLine);
                MessageBox.Show(error, "Hearthbuddy", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //this.dispatcherTimer_0 = new DispatcherTimer(TimeSpan.FromSeconds(1.0), DispatcherPriority.Normal, new EventHandler(this.method_9), base.Dispatcher);
            //this.dispatcherTimer_0.Start();
        }
        
        private void method_21(object object_0)
        {
            try
            {
                this.method_22();
                string text;
                if (this.process_0 == null)
                {
                    Console.WriteLine("");
                    return;
                }
                else if (!TritonHs.smethod_0(this.process_0, new TritonHs.Delegate6(Class12.smethod_4), out text))
                {
                    MainWindow.ilog_0.Error(text);
                    System.Windows.MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                    base.Dispatcher.BeginInvoke(new Action(base.Close), Array.Empty<object>());
                }
                else
                {
                    TritonHs.Memory.ProcessExited += MainWindow.Class25.ChuckInstance9.method_1;
                    TritonHs.Memory.Executor.FrameDropWaitTime = 15000u;
                    TritonHs.Memory.Executor.ExecuteWaitTime = 15000;
                    TritonHs.Memory.DisableCache();
                    TritonHs.Memory.ClearCache();
                    int version;
                    int clientChangelist;
                    using (TritonHs.AcquireFrame())
                    {
                        version = Triton.Game.Mapping.Version.version;
                        clientChangelist = Triton.Game.Mapping.Version.clientChangelist;
                    }
                    if ((long)version != (long)((ulong)Class247.UInt32_1) && (long)clientChangelist != (long)((ulong)Class247.UInt32_2))
                    {
                        MainWindow.ilog_0.InfoFormat("Hearthstone client version ({0}, {1})", version, clientChangelist);
                        new Coroutine(new Func<Task>(MainWindow.Class25.ChuckInstance9.method_2));
                        Configuration.Instance.AddSettings(MainSettings.Instance);
                        Configuration.Instance.AddSettings(DevSettings.Instance);
                        Configuration.Instance.SaveAll();
                        base.Dispatcher.Invoke(new Action(this.method_23));
                        BotManager.PreStart += this.method_11;
                        BotManager.PostStop += this.method_10;
                        BotManager.Load();
                        base.Dispatcher.Invoke(new Action(this.method_24));
                        this.comboBox_0.Dispatcher.BeginInvoke(new Action(this.method_25), Array.Empty<object>());
                        BotManager.OnBotChanged += this.method_6;
                        RoutineManager.Load();
                        base.Dispatcher.Invoke(new Action(this.method_26));
                        this.comboBox_1.Dispatcher.BeginInvoke(new Action(this.method_27), Array.Empty<object>());
                        RoutineManager.OnRoutineChanged += this.method_7;
                        PluginManager.Load();
                        foreach (IPlugin plugin in PluginManager.Plugins)
                        {
                            if (MainSettings.Instance.EnabledPlugins.Contains(plugin.Name))
                            {
                                using (TritonHs.AcquireFrame())
                                {
                                    PluginManager.Enable(plugin);
                                }
                                Thread.Sleep(20);
                            }
                            else
                            {
                                using (TritonHs.AcquireFrame())
                                {
                                    PluginManager.Disable(plugin);
                                }
                                Thread.Sleep(20);
                            }
                        }
                        this.listBox_0.Dispatcher.Invoke<IEnumerable>(new Func<IEnumerable>(this.method_28), DispatcherPriority.Normal);
                        base.Dispatcher.Invoke(new Action(this.method_29));
                        PluginManager.PluginEnabled += this.method_5;
                        PluginManager.PluginDisabled += this.method_4;
                        MainWindow.ilog_0.ErrorFormat("{0}Please read the following guide before using this program:{0}https://github.com/ChuckHearthBuddy/SilverFish/blob/master/ReadMe.md", Environment.NewLine);
                        base.Dispatcher.Invoke(new Action(this.method_30));
                        base.Dispatcher.Invoke(new Action(this.method_31));
                        this.stopwatch_0.Restart();
                        RoutineManager.OnRoutineChanged += this.method_7;
                        BotManager.OnBotChanged += this.method_6;
                        TritonHs.IsBotFullyLoaded = true;
                        Hotkeys.Register("BotManager.StartStop", Keys.S, ModifierKeys.Alt | ModifierKeys.Shift, new Action<Hotkey>(MainWindow.Class25.ChuckInstance9.method_3));
                        if (CommandLine.Arguments.Exists("autostart"))
                        {
                            BotManager.Start();
                        }
                    }
                    else
                    {
                        text = string.Format("This client version ({0}, {1}) is unsupported. Hearthbuddy currently supports client version ({2}, {3}). Please check the forums for more information: https://www.thebuddyforum.com/hearthbuddy-forum/", new object[]
                        {
                    version,
                    clientChangelist,
                    Class247.UInt32_1,
                    Class247.UInt32_2
                        });
                        MainWindow.ilog_0.ErrorFormat(text, Array.Empty<object>());
                        System.Windows.MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        base.Dispatcher.BeginInvoke(new Action(base.Close), Array.Empty<object>());
                    }
                }
            }
            catch (Exception exception)
            {
                MainWindow.ilog_0.Error("[OnStartup] A top-level exception has been caught.", exception);
            }
        }

    }
}
