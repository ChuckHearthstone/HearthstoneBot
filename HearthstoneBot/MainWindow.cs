using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HearthstoneBot.Bot;
using HearthstoneBot.Common;
using log4net.Plugin;
using Version = HearthstoneBot.Mapping.Version;

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

        internal static async Task smethod_0()
        {
        }

        private void method_21(object object_0)
        {
            try
            {
                this.method_22();
                string text;
                if (this.process_0 == null)
                {
                    MessageBox.Show("can not find process");
                    return;
                }
                else if (!TritonHs.smethod_0(this.process_0, Class12.smethod_4, out text))
                {
                    MessageBox.Show("TritonHs.smethod_0 == false");
                }
                else
                {
                    TritonHs.Memory.ProcessExited += Class25.Instance.method_1;
                    TritonHs.Memory.Executor.FrameDropWaitTime = 15000u;
                    TritonHs.Memory.Executor.ExecuteWaitTime = 15000;
                    TritonHs.Memory.DisableCache();
                    TritonHs.Memory.ClearCache();
                    int version;
                    int clientChangelist;
                    using (TritonHs.AcquireFrame())
                    {
                        version = Version.version;
                        clientChangelist = Version.clientChangelist;
                    }
                    if ((long)version != (long)((ulong)Class247.UInt32_1) && (long)clientChangelist != (long)((ulong)Class247.UInt32_2))
                    {
                        Console.WriteLine("Hearthstone client version ({0}, {1})", version, clientChangelist);
                        //MainWindow.ilog_0.InfoFormat("Hearthstone client version ({0}, {1})", version, clientChangelist);
                        //new Coroutine(new Func<Task>(Class25.Instance.method_2));
                        smethod_0();
                        //Configuration.Instance.AddSettings(MainSettings.Instance);
                        //Configuration.Instance.AddSettings(DevSettings.Instance);
                        //Configuration.Instance.SaveAll();
                        //base.Dispatcher.Invoke(new Action(this.method_23));
                        //BotManager.PreStart += this.method_11;
                        //BotManager.PostStop += this.method_10;
                        BotManager.Load();
                        this.method_24();
                        this.method_25();
                        //BotManager.OnBotChanged += this.method_6;
                        RoutineManager.Load();
                        this.method_26();
                        this.method_27();
                        //RoutineManager.OnRoutineChanged += this.method_7;
                        //PluginManager.Load();
                        //foreach (IPlugin plugin in PluginManager.Plugins)
                        //{
                        //    if (MainSettings.Instance.EnabledPlugins.Contains(plugin.Name))
                        //    {
                        //        using (TritonHs.AcquireFrame())
                        //        {
                        //            PluginManager.Enable(plugin);
                        //        }
                        //        Thread.Sleep(20);
                        //    }
                        //    else
                        //    {
                        //        using (TritonHs.AcquireFrame())
                        //        {
                        //            PluginManager.Disable(plugin);
                        //        }
                        //        Thread.Sleep(20);
                        //    }
                        //}
                        //this.listBox_0.Dispatcher.Invoke<IEnumerable>(new Func<IEnumerable>(this.method_28), DispatcherPriority.Normal);
                        this.method_29();
                        //PluginManager.PluginEnabled += this.method_5;
                        //PluginManager.PluginDisabled += this.method_4;
                        //MainWindow.ilog_0.ErrorFormat("{0}Please read the following guide before using this program:{0}https://github.com/ChuckHearthBuddy/SilverFish/blob/master/ReadMe.md", Environment.NewLine);
                        //base.Dispatcher.Invoke(new Action(this.method_30));
                        //base.Dispatcher.Invoke(new Action(this.method_31));
                        //this.stopwatch_0.Restart();
                        //RoutineManager.OnRoutineChanged += this.method_7;
                        //BotManager.OnBotChanged += this.method_6;
                        TritonHs.IsBotFullyLoaded = true;
                        Hotkeys.Register("BotManager.StartStop", Keys.S, ModifierKeys.Alt | ModifierKeys.Shift, Class25.Instance.method_3);
                        //if (CommandLine.Arguments.Exists("autostart"))
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
                        //MainWindow.ilog_0.ErrorFormat(text, Array.Empty<object>());
                        //System.Windows.MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                        //base.Dispatcher.BeginInvoke(new Action(base.Close), Array.Empty<object>());
                    }
                }
            }
            catch (Exception exception)
            {
                //MainWindow.ilog_0.Error("[OnStartup] A top-level exception has been caught.", exception);
            }
        }
        private void method_24()
        {
            foreach (IBot object_ in BotManager.Bots)
            {
                this.method_2(object_);
            }
        }

        private void method_2(object object_0)
        {
            //IConfigurable configurable = object_0 as IConfigurable;
            //IAuthored authored = object_0 as IAuthored;
            //if (configurable != null && authored != null)
            //{
            //    System.Windows.Controls.UserControl control = configurable.Control;
            //    if (control != null)
            //    {
            //        TabItem newItem = new TabItem
            //        {
            //            Header = authored.Name,
            //            Content = control,
            //            Tag = object_0
            //        };
            //        this.tabControl_1.Items.Add(newItem);
            //    }
            //}
        }

        private void method_25()
        {
            List<IBot> bots = BotManager.Bots;
            //this.comboBox_0.ItemsSource = bots;
            //if (CommandLine.Arguments.Exists("bot"))
            //{
            //    MainWindow.Class26 @class = new MainWindow.Class26();
            //    @class.string_0 = CommandLine.Arguments.Single("bot");
            //    IBot bot = bots.FirstOrDefault(new Func<IBot, bool>(@class.method_0));
            //    if (bot != null)
            //    {
            //        this.comboBox_0.SelectedItem = bot;
            //    }
            //}
            //else if (!string.IsNullOrEmpty(MainSettings.Instance.LastBot))
            //{
            //    MainWindow.Class27 class2 = new MainWindow.Class27();
            //    class2.string_0 = MainSettings.Instance.LastBot;
            //    IBot bot2 = bots.FirstOrDefault(new Func<IBot, bool>(class2.method_0));
            //    if (bot2 != null)
            //    {
            //        this.comboBox_0.SelectedItem = bot2;
            //    }
            //}
            //if (this.comboBox_0.SelectedItem == null)
            //{
            //    this.comboBox_0.SelectedItem = bots.FirstOrDefault<IBot>();
            //}
            this.method_14();
        }

        private void method_14()
        {
            //foreach (object obj in ((IEnumerable)this.tabControl_1.Items))
            //{
            //    TabItem tabItem = (TabItem)obj;
            //    MainWindow.Class32 @class = new MainWindow.Class32();
            //    IBot bot = tabItem.Tag as IBot;
            //    if (bot != null)
            //    {
            //        tabItem.Visibility = ((this.comboBox_0.SelectedItem == bot) ? Visibility.Visible : Visibility.Collapsed);
            //    }
            //    IRoutine routine = tabItem.Tag as IRoutine;
            //    if (routine != null)
            //    {
            //        tabItem.Visibility = ((this.comboBox_1.SelectedItem == routine) ? Visibility.Visible : Visibility.Collapsed);
            //    }
            //    @class.iplugin_0 = (tabItem.Tag as IPlugin);
            //    if (@class.iplugin_0 != null)
            //    {
            //        IPlugin plugin = PluginManager.Plugins.First(new Func<IPlugin, bool>(@class.method_0));
            //        tabItem.Visibility = (plugin.IsEnabled ? Visibility.Visible : Visibility.Collapsed);
            //    }
            //}
            //TabItem tabItem2 = this.tabControl_1.SelectedItem as TabItem;
            //if (tabItem2 != null && tabItem2.Visibility == Visibility.Collapsed)
            //{
            //    this.tabControl_1.SelectedIndex = 0;
            //}
        }

        private void method_26()
        {
            foreach (IRoutine object_ in RoutineManager.Routines)
            {
                this.method_2(object_);
            }
        }

        private void method_27()
        {
            //List<IRoutine> routines = RoutineManager.Routines;
            //this.comboBox_1.ItemsSource = routines;
            //if (CommandLine.Arguments.Exists("routine"))
            //{
            //    MainWindow.Class28 @class = new MainWindow.Class28();
            //    @class.string_0 = CommandLine.Arguments.Single("routine");
            //    IRoutine routine = routines.FirstOrDefault(new Func<IRoutine, bool>(@class.method_0));
            //    if (routine != null)
            //    {
            //        this.comboBox_1.SelectedItem = routine;
            //    }
            //}
            //else if (!string.IsNullOrEmpty(MainSettings.Instance.LastRoutine))
            //{
            //    MainWindow.Class29 class2 = new MainWindow.Class29();
            //    class2.string_0 = MainSettings.Instance.LastRoutine;
            //    IRoutine routine2 = routines.FirstOrDefault(new Func<IRoutine, bool>(class2.method_0));
            //    if (routine2 != null)
            //    {
            //        this.comboBox_1.SelectedItem = routine2;
            //    }
            //}
            //if (this.comboBox_1.SelectedItem == null)
            //{
            //    this.comboBox_1.SelectedItem = routines.FirstOrDefault<IRoutine>();
            //}
            this.method_14();
        }

        private void method_29()
        {
            //foreach (IPlugin object_ in PluginManager.Plugins)
            //{
            //    this.method_2(object_);
            //}
            this.method_14();
        }

    }
}
