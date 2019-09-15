using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Common
{
    public partial class AssemblyLoader<T>
    {
        class Class229
        {
            public T gparam_0;

            internal bool method_0(T gparam_1)
            {
                string fullName = gparam_1.GetType().FullName;
                string fullName2 = this.gparam_0.GetType().FullName;
                return fullName == fullName2;
            }
        }
    }
}
