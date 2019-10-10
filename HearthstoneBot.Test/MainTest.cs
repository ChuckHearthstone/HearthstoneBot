using System;
using NUnit.Framework;

namespace HearthstoneBot.Test
{
    [TestFixture]
    public class MainTest
    {
        [Test]
        public void Test()
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.method_21(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
