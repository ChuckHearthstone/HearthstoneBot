using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace HearthstoneBot.Common
{
    public enum FileStructureType
    {
        // Token: 0x04000B17 RID: 2839
        SingleFile,
        // Token: 0x04000B18 RID: 2840
        Folder
    }

    class CodeCompiler
    {
        public float CompilerVersion;

        private static string string_1;
        public static string CompiledAssemblyPath
        {
            get
            {
                string result;
                if ((result = CodeCompiler.string_1) == null)
                {
                    result = (CodeCompiler.string_1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), string.Format("CompiledAssemblies\\{0}", Environment.TickCount)));
                }
                return result;
            }
        }

        public string CompiledToLocation;

        public CodeCompiler(string path)
        {
            this.CompilerVersion = 4f;
            this.SourceFilePaths = new List<string>();
            if (File.Exists(path))
            {
                this.FileStructure = FileStructureType.SingleFile;
            }
            else if (Directory.Exists(path))
            {
                this.FileStructure = FileStructureType.Folder;
            }
            this.SourcePath = path;
            this.Options = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = false,
                IncludeDebugInformation = true
            };
            string arg = "HSB_" + Assembly.GetEntryAssembly().GetName().Version.Revision;
            this.Options.CompilerOptions = string.Format("/d:HSB;{0} /unsafe", arg);
            this.Options.TempFiles = new TempFileCollection(Path.GetTempPath());
            this.Options.OutputAssembly = Path.Combine(CodeCompiler.CompiledAssemblyPath, this.AssemblyName);
            this.CompiledToLocation = this.Options.OutputAssembly;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    string location = assembly.Location;
                    if (assembly == Assembly.GetEntryAssembly())
                    {
                        location = CodeCompiler.string_0;
                    }
                    this.AddReference(location);
                }
                catch (NotSupportedException)
                {
                }
            }
        }

        private static string string_0;
        internal static void smethod_0(string string_4)
        {
            CodeCompiler.string_0 = string_4;
        }

        public Assembly CompiledAssembly;
        public CompilerResults Compile()
        {
            this.method_2();
            this.method_3();
            if (this.SourceFilePaths.Count != 0)
            {
                CompilerResults result;
                using (CSharpCodeProvider csharpCodeProvider = new CSharpCodeProvider())
                {
                    csharpCodeProvider.Supports(GeneratorSupport.Resources);
                    if (this.resourceWriter_0 != null)
                    {
                        this.resourceWriter_0.Close();
                        this.resourceWriter_0.Dispose();
                        this.resourceWriter_0 = null;
                    }
                    foreach (Stream stream in this.list_2)
                    {
                        try
                        {
                            stream.Close();
                            stream.Dispose();
                        }
                        catch
                        {
                        }
                    }
                    this.list_2.Clear();
                    CompilerResults compilerResults = csharpCodeProvider.CompileAssemblyFromFile(this.Options, this.SourceFilePaths.ToArray());
                    if (!compilerResults.Errors.HasErrors)
                    {
                        this.CompiledAssembly = compilerResults.CompiledAssembly;
                    }
                    compilerResults.TempFiles.Delete();
                    foreach (string path in this.list_1)
                    {
                        try
                        {
                            File.Delete(path);
                        }
                        catch
                        {
                        }
                    }
                    this.list_1.Clear();
                    result = compilerResults;
                }
                return result;
            }
            if (this.resourceWriter_0 != null)
            {
                this.resourceWriter_0.Close();
                this.resourceWriter_0.Dispose();
                this.resourceWriter_0 = null;
            }
            foreach (Stream stream2 in this.list_2)
            {
                try
                {
                    stream2.Close();
                    stream2.Dispose();
                }
                catch
                {
                }
            }
            this.list_2.Clear();
            foreach (string path2 in this.list_1)
            {
                try
                {
                    File.Delete(path2);
                }
                catch
                {
                }
            }
            this.list_1.Clear();
            return null;
        }

        public FileStructureType FileStructure;
        public string SourcePath;
        public List<string> SourceFilePaths;
        private void method_2()
        {
            if (this.FileStructure == FileStructureType.Folder)
            {
                foreach (string string_ in Directory.GetFiles(this.SourcePath, "*.resx", SearchOption.AllDirectories))
                {
                    this.method_1(string_);
                }
                bool flag = false;
                foreach (string string_2 in Directory.GetFiles(this.SourcePath, "*.baml", SearchOption.AllDirectories))
                {
                    flag = true;
                    this.method_0(string_2);
                }
                foreach (string text in Directory.GetFiles(this.SourcePath, "*.cs", SearchOption.AllDirectories))
                {
                    if (text.ToLowerInvariant().Contains(".g.cs"))
                    {
                        if (flag)
                        {
                            this.SourceFilePaths.Add(text);
                        }
                    }
                    else if (text.ToLowerInvariant().Contains(".xaml.cs"))
                    {
                        if (flag)
                        {
                            this.SourceFilePaths.Add(text);
                        }
                    }
                    else
                    {
                        string directoryName = Path.GetDirectoryName(text);
                        if (!Directory.GetParent(directoryName).Equals("DefaultRoutine") || directoryName.Equals("Chuck.SilverFish"))
                        {
                            this.SourceFilePaths.Add(text);
                        }
                        else
                        {
                            //CodeCompiler.ilog_0.ErrorFormat("ignore cs file " + text, Array.Empty<object>());
                        }
                    }
                }
                return;
            }
            this.SourceFilePaths.Add(this.SourcePath);
        }

        public string AssemblyName
        {
            get
            {
                return string.Format("{0}.dll", (this.FileStructure == FileStructureType.SingleFile) ? Path.GetFileNameWithoutExtension(this.SourcePath) : new DirectoryInfo(this.SourcePath).Name);
            }
        }

        private ResourceWriter resourceWriter_0;

        public CompilerParameters Options;
        private readonly List<string> list_1 = new List<string>();

        private readonly List<Stream> list_2 = new List<Stream>();

        private void method_0(string string_4)
        {
            if (this.resourceWriter_0 == null)
            {
                string text = Path.GetFileNameWithoutExtension(this.AssemblyName) + ".g.resources";
                this.resourceWriter_0 = new ResourceWriter(text);
                this.Options.EmbeddedResources.Add(text);
                this.list_1.Add(text);
            }
            FileStream fileStream = new FileStream(string_4, FileMode.Open, FileAccess.Read);
            this.list_2.Add(fileStream);
            this.resourceWriter_0.AddResource(Path.GetFileName(string_4).ToLowerInvariant(), fileStream);
        }

        private void method_1(string string_4)
        {
            string text = Path.ChangeExtension(string_4, ".resources");
            if (File.Exists(text))
            {
                File.Delete(text);
            }
            using (ResXResourceReader resXResourceReader = new ResXResourceReader(string_4))
            {
                resXResourceReader.BasePath = this.SourcePath;
                using (ResourceWriter resourceWriter = new ResourceWriter(text))
                {
                    foreach (object obj in resXResourceReader)
                    {
                        DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
                        resourceWriter.AddResource(dictionaryEntry.Key.ToString(), dictionaryEntry.Value);
                    }
                }
            }
            this.Options.EmbeddedResources.Add(text);
        }

        private void method_3()
        {
            foreach (string path in this.SourceFilePaths)
            {
                string[] array = File.ReadAllLines(path);
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i].Trim();
                    if (text.StartsWith("//!CompilerOption|"))
                    {
                        string[] array2 = text.Split(new char[]
                        {
                            '|'
                        }, StringSplitOptions.RemoveEmptyEntries);
                        string a = array2[1];
                        if (!(a == "AddRef"))
                        {
                            if (!(a == "Optimize"))
                            {
                                if (a == "Define" && array2.Length == 3 && !string.IsNullOrEmpty(array2[2]))
                                {
                                    CompilerParameters options = this.Options;
                                    options.CompilerOptions = options.CompilerOptions + " /d:" + array2[2] + ";";
                                }
                            }
                            else if (array2.Length == 3 && !string.IsNullOrEmpty(array2[2]) && array2[2] == "On" && !this.Options.CompilerOptions.Contains("/optimize;"))
                            {
                                this.Options.IncludeDebugInformation = false;
                                CompilerParameters options2 = this.Options;
                                options2.CompilerOptions += " /optimize";
                            }
                        }
                        else if (array2.Length == 3 && !string.IsNullOrEmpty(array2[2]) && array2[2].EndsWith(".dll") && !CodeCompiler.smethod_2(array2[2]) && !array2[2].ToLowerInvariant().Contains("hearthbuddy.exe"))
                        {
                            this.AddReference(array2[2]);
                        }
                    }
                }
            }
        }

        public void AddReference(string assembly)
        {
            if (!this.Options.ReferencedAssemblies.Contains(assembly))
            {
                this.Options.ReferencedAssemblies.Add(assembly);
            }
        }

        private static bool smethod_2(string string_4)
        {
            Class230 @class = new Class230();
            @class.string_0 = string_4;
            return AppDomain.CurrentDomain.GetAssemblies().Any(new Func<Assembly, bool>(@class.method_0));
        }
    }
}
