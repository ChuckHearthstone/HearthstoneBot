using System;

namespace HearthstoneBot
{
    class Class12
    {
        public static byte[] smethod_4(string string_1, out string string_2)
        {
            Class15 @class = new Class15();
            @class.string_0 = string_1;
            @class.string_1 = null;
            byte[] array = Class45.smethod_2(@class.method_0);
            string_2 = @class.string_1;
            byte[] array2 = array;
            if (array2 != null && array2.Length != 0)
            {
                return array2;
            }
            return null;
        }

        internal static void smethod_0()
        {
            try
            {
                Class45.smethod_2<r0>(new Func<Class40, r0>(Class13.ChuckInstance9.method_0));
            }
            catch
            {
            }
        }
    }
}
