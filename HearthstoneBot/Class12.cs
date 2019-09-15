using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    class Class12
    {
        public static byte[] smethod_4(string string_1, out string string_2)
        {
            Class15 @class = new Class15();
            @class.string_0 = string_1;
            @class.string_1 = null;
            byte[] array = Class45.smethod_2<byte[]>(new Func<Class40, byte[]>(@class.method_0));
            string_2 = @class.string_1;
            byte[] array2 = array;
            if (array2 != null && array2.Length != 0)
            {
                return array2;
            }
            return null;
        }
    }
}
