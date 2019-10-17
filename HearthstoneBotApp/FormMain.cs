using System;
using System.Threading;
using System.Windows.Forms;
using HearthstoneBot;
using HearthstoneBot.Bot;
using HearthstoneBot.Game;

namespace HearthstoneBotApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private MainWindow mainWindow = new MainWindow();

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (BotManager.CurrentBot == null)
            {
                var bot=new DefaultBot();
                BotManager.Bots.Add(bot);
                BotManager.CurrentBot = bot;
            }

            if (BotManager.IsRunning)
            {
                BotManager.Stop();
            }
            else
            {
                bool success = BotManager.Start();
                if (!success)
                {
                    MessageBox.Show($@"Start failed.");
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = @"HearthstoneBot(https://github.com/ChuckHearthstone/HearthstoneBot)";
            method_3();
            //this.textBox_0.Text = Triton.Common.LogUtilities.Logger.FileName;
        }

        private void method_3()
        {
            ThreadPool.QueueUserWorkItem(mainWindow.method_21);
        }

        private void ButtonConcede_Click(object sender, EventArgs e)
        {
            bool success = TritonHs.Concede(true);
            if (success)
            {
                MessageBox.Show(@"Concede successfully!");
            }
            else
            {
                MessageBox.Show(@"Concede failed!");
            }
        }
    }
}
