using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HearthstoneBot
{
    class Class25
    {
        public static readonly Class25 Instance = new Class25();

        internal void method_1(object sender, EventArgs e)
        {
           MessageBox.Show("[ProcessExited] The game process has closed. Hearthbuddy will now close.");
            Class12.smethod_0();
            Environment.Exit(0);
        }
    }
}
