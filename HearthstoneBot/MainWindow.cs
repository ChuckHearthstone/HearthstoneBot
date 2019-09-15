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
    }
}
