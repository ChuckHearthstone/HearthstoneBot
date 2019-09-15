using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using HearthstoneBot.Common;

namespace HearthstoneBot
{
    class Class232
    {
        public MSG msg_0;

        public Func<Hotkey, bool> func_0;

        internal bool method_0(Hotkey hotkey_0)
        {
            return hotkey_0.Id == (int)this.msg_0.wParam;
        }
    }
}
