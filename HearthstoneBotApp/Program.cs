using System;
using System.Threading;
using System.Windows.Forms;

namespace HearthstoneBotApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DealException(e.Exception);
        }

        static void DealException(Exception ex)
        {
            if (ex != null)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
