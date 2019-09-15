using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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

        private static bool smethod_6(Process process_0)
        {
            try
            {
                var certificate = X509Certificate.CreateFromSignedFile(process_0.MainModule.FileName);
                var flag1 = certificate.Subject.Contains("Blizzard Entertainment, Inc.");

                var processPath = Path.GetDirectoryName(process_0.MainModule.FileName);
                var dataPath = Path.Combine(processPath, "Hearthstone_Data");
                var flag2 = Directory.Exists(dataPath);

                if (flag1 && flag2)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }
    }
}
