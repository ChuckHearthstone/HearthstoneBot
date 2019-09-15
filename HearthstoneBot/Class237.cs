using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    public partial class TypeLoader<T> : List<T>
    {
        class Class237
        {
            public Type type_0;

            internal bool method_0(T gparam_0)
            {
                string fullName = gparam_0.GetType().FullName;
                string fullName2 = this.type_0.FullName;
                return fullName == fullName2;
            }
        }

    }
}
