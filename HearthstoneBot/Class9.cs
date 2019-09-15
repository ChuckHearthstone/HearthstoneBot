using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        internal static bool smethod_5(out Mutex mutex_0, out Process process_0)
        {
            mutex_0 = null;
            process_0 = null;
            bool result;
            try
            {
                var processName = ConstsHelper.ProcessName;
                process_0 = Process.GetProcessesByName(processName).FirstOrDefault();
                if (process_0 != null && smethod_6(process_0))
                {
                    mutex_0 = smethod_1(process_0.Id, out var flag2);
                    if (!flag2)
                    {
                        mutex_0 = null;
                        process_0 = null;
                        //Class9.ilog_0.Error("Invalid PNAME specifier passed to the command line: " +
                        //                    arguments.Single("pname") + ". This process has already been attached to.");
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    //Class9.ilog_0.Error("Invalid PNAME specifier passed to the command line: " +
                    //                    arguments.Single("pname") + ". This process is not a Hearthstone client.");
                    result = false;
                }
            }
            catch
            {
                //Class9.ilog_0.Error("Invalid PNAME specifier passed to the command line: " + arguments.Single("pname"));
                result = false;
            }

            return result;
        }

        internal static bool smethod_4(out Mutex mutex_0, out Process process_0)
        {
            if (!smethod_5(out mutex_0, out process_0))
            {
                return false;
            }

            var processFolder = Path.GetDirectoryName(process_0.MainModule.FileName);
            Path.Combine(processFolder, "Hearthstone_Data", "Mono");
            return true;
        }
    }
}
