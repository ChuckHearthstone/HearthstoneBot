using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    class Class15
    {
        public string string_0;

        public string string_1;

        internal byte[] method_0(Class40 class40_0)
        {
            d0 d = class40_0.method_7(this.string_0, Assembly.GetEntryAssembly().GetName().Version.ToString(), false);
            if (d.Success)
            {
                return Class60.smethod_2(d.Data);
            }
            this.string_1 = d.Body;
            return null;
        }
    }
}
