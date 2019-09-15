using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HearthstoneBot.Common
{
    public partial class AssemblyLoader<T>
    {
        public List<T> Instances;

        private readonly bool bool_0;

        private readonly string string_0;

        private readonly FileSystemWatcher fileSystemWatcher_0 = new FileSystemWatcher();

        public AssemblyLoader(string directory, bool detectFileChanges)
        {
            Instances = new List<T>();
            string_0 = directory;
            bool_0 = detectFileChanges;
            if (bool_0)
            {
                fileSystemWatcher_0.Path = directory;
                fileSystemWatcher_0.Filter = "*.cs";
                fileSystemWatcher_0.IncludeSubdirectories = true;
                fileSystemWatcher_0.EnableRaisingEvents = true;
                //this.fileSystemWatcher_0.Changed += this.method_0;
                //this.fileSystemWatcher_0.Created += this.method_1;
                //this.fileSystemWatcher_0.Deleted += this.method_2;
            }
            Reload("Initializing");
        }

        private EventHandler eventHandler_0;
        public void Reload(string reason)
        {
            //this.ilog_0.Debug(string.Format("Reloading AssemblyLoader<{0}> - {1}", typeof(T), reason));
            Instances = new List<T>();
            if (!Directory.Exists(string_0))
            {
                //this.ilog_0.Error(string.Format("Could not Reload assemblies because the path \"{0}\" does not exist.", this.string_0));
                return;
            }
            //this.ilog_0.Info("Reload cs files from " + this.string_0);
            foreach (string path in Directory.GetDirectories(string_0))
            {
                try
                {
                    CodeCompiler codeCompiler = new CodeCompiler(path);
                    CompilerResults compilerResults = codeCompiler.Compile();
                    if (compilerResults != null)
                    {
                        if (compilerResults.Errors.HasErrors)
                        {
                            foreach (object arg in compilerResults.Errors)
                            {
                                //this.ilog_0.Error(string.Format("Compiler Error: {0}", arg));
                                Console.WriteLine($"Compiler Error: {arg}");
                            }
                        }
                        Instances.AddRange(new TypeLoader<T>(codeCompiler.CompiledAssembly));
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ReflectionTypeLoadException)
                    {
                        foreach (Exception exception in (ex as ReflectionTypeLoadException).LoaderExceptions)
                        {
                            //this.ilog_0.Error("[Reload] An exception occurred.", exception);
                            Console.WriteLine($"Compiler Error: {exception}");
                        }
                    }
                    else
                    {
                        //this.ilog_0.Error("[Reload] An exception occurred.", ex);
                        Console.WriteLine($"Compiler Error: {ex}");
                    }
                }
            }
            using (List<T>.Enumerator enumerator2 = new TypeLoader<T>().GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    Class229 @class = new Class229();
                    @class.gparam_0 = enumerator2.Current;
                    if (!Instances.Any(@class.method_0))
                    {
                        Instances.Add(@class.gparam_0);
                    }
                }
            }
            if (eventHandler_0 != null)
            {
                eventHandler_0(this, null);
            }
        }
    }
}
