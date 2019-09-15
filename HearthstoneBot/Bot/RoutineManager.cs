using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using HearthstoneBot.Common;

namespace HearthstoneBot.Bot
{
    public interface IRoutine : IRunnable, IBase
    { 

        // Token: 0x06001196 RID: 4502
        void SetConfiguration(string name, params object[] param);

        // Token: 0x06001197 RID: 4503
        object GetConfiguration(string name);

        // Token: 0x06001198 RID: 4504
        Task<bool> Logic(string type, object context);
    }

    class RoutineManager
    {
        private static string String_0
        {
            get
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly == null)
                {
                    throw new Exception("Can not find entry assembly");
                }
                else
                {
                    return Path.GetDirectoryName(entryAssembly.Location);
                }
            }
        }

        public static string RoutinesPath
        {
            get
            {
                return Path.Combine(RoutineManager.String_0, "Routines");
            }
        }

        public static List<IRoutine> Routines;

        public static bool Load()
        {
            try
            {
                string routinesPath = RoutineManager.RoutinesPath;
                if (RoutineManager.Routines != null)
                {
                    //RoutineManager.ilog_0.ErrorFormat("[Load] This function can only be called once.", Array.Empty<object>());
                    return false;
                }
                if (!Directory.Exists(routinesPath))
                {
                    Directory.CreateDirectory(routinesPath);
                }
                AssemblyLoader<IRoutine> assemblyLoader = new AssemblyLoader<IRoutine>(routinesPath, false);
                RoutineManager.Routines = new List<IRoutine>();
                foreach (IRoutine routine in assemblyLoader.Instances.AsReadOnly())
                {
                    try
                    {
                        //Utility.smethod_0(routine);
                        routine.Initialize();
                        RoutineManager.Routines.Add(routine);
                    }
                    catch (Exception exception)
                    {
                        //RoutineManager.ilog_0.Debug("[Load] Exception thrown when initializing " + routine.Name + ". Routine will not be loaded.", exception);
                        //Utility.smethod_1(routine);
                        routine.Deinitialize();
                    }
                }
                return true;
            }
            catch (Exception arg)
            {
                Console.WriteLine(arg);
                //RoutineManager.ilog_0.ErrorFormat("[Load] An exception occurred: {0}.", arg);
            }
            return false;
        }
    }
}
