using System;
using System.Threading;

namespace HearthstoneBot
{
    public class Class9
    {
        private static Mutex smethod_1(int int_0, out bool bool_0)
        {
            var mutexName = "Local\\" + (Environment.MachineName.GetHashCode() ^ int_0.GetHashCode() ^
                                         TimeZone.CurrentTimeZone.StandardName.GetHashCode() ^
                                         "Blizz_HS_BuddyTeam".GetHashCode() + 25);
            var mutex = new Mutex(true, mutexName, out bool_0);
            return mutex;
        }

    }
}
