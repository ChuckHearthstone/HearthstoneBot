using System;
using System.Collections.Generic;
using System.Linq;
using GreyMagic;
using HearthstoneBot.Common;
using HearthstoneBot.Enums;
using HearthstoneBot.Game;

namespace HearthstoneBot
{
    public partial class MonoClass
    {
        internal static ExternalProcessMemory ExternalProcessMemory_0
        {
            get
            {
                return TritonHs.Memory;
            }
        }
        internal static Class276 Class276_0
        {
            get
            {
                return TritonHs.Class276_0;
            }
        }

        public IntPtr Address { get; set; }

        public string AssemblyPath { get; set; }

        public string ClassNamespace { get; set; }

        internal uint UInt32_0 { get; set; }

        public virtual IntPtr GetClassInstance()
        {
            return this.Address;
        }

        internal MonoClass(string assembly, string classNamespace, string className)
        {
            this.AssemblyPath = assembly;
            this.ClassNamespace = classNamespace;
            this.ClassName = className;
        }

        public string ClassName { get; set; }

        public string RealClassName { get; set; }

        private IntPtr? nullable_0;
        internal IntPtr IntPtr_0
        {
            get
            {
                IntPtr? intPtr = this.nullable_0;
                if (intPtr == null)
                {
                    IntPtr? intPtr2 = this.nullable_0 = new IntPtr?(this.vmethod_0(this.AssemblyPath, this.ClassNamespace, this.ClassName));
                    return intPtr2.Value;
                }
                return intPtr.GetValueOrDefault();
            }
        }

        internal MonoClass(IntPtr address, string className) : this(TritonHs.MainAssemblyPath, "", className)
        {
            if (address == IntPtr.Zero)
            {
                throw new InvalidOperationException("Cannot create an instance of MonoClass with a backing pointer of Zero.");
            }
            this.Address = address;
            this.UInt32_0 = MonoClass.Class276_0.method_10(address, true);//mono_gchandle_new
            this.RealClassName = MonoClass.Class276_0.method_45(this.IntPtr_0);
        }

        /// <summary>
        /// mono_object_get_class
        /// </summary>
        /// <param name="string_4"></param>
        /// <param name="string_5"></param>
        /// <param name="string_6"></param>
        /// <returns></returns>
        internal virtual IntPtr vmethod_0(string string_4, string string_5, string string_6)
        {
            if (this.Address != IntPtr.Zero)
            {
                return MonoClass.Class276_0.method_23(this.Address);//mono_object_get_class
            }
            return MonoClass.smethod_3(string_4, string_5, string_6);
        }

        internal IntPtr method_7(string string_4, Enum20[] enum20_0, params object[] object_0)
        {
            IntPtr classInstance = this.GetClassInstance();
            if (classInstance == IntPtr.Zero)
            {
                throw new Exception("Cannot call a method on an object instance that has no address!");
            }
            IntPtr intPtr = this.method_0(string_4, enum20_0);
            if (intPtr == IntPtr.Zero)
            {
                throw new MissingMethodException(this.ClassName, string_4);
            }
            return MonoClass.Class276_0.method_43(intPtr, classInstance, object_0);
        }

        internal IntPtr method_0(string string_4, Enum20[] enum20_0)
        {
            if (this.IntPtr_0 == IntPtr.Zero)
            {
                throw new InvalidOperationException("Cannot get a method pointer on an object that has no MonoClass pointer.");
            }
            return MonoClass.smethod_4(this.IntPtr_0, string_4, enum20_0);
        }

        private static readonly Dictionary<IntPtr, Dictionary<string, List<MonoClass.Class273>>> dictionary_3 = new Dictionary<IntPtr, Dictionary<string, List<MonoClass.Class273>>>();
        private static IntPtr smethod_4(IntPtr intptr_1, string string_4, Enum20[] enum20_0)
        {
            Class274 @class = new Class274();
            @class.string_0 = string_4;
            @class.enum20_0 = enum20_0;
            Dictionary<string, List<MonoClass.Class273>> dictionary;
            if (!MonoClass.dictionary_3.TryGetValue(intptr_1, out dictionary))
            {
                MonoClass.dictionary_3.Add(intptr_1, new Dictionary<string, List<MonoClass.Class273>>());
                dictionary = MonoClass.dictionary_3[intptr_1];
            }
            List<MonoClass.Class273> list;
            if (!dictionary.TryGetValue(@class.string_0, out list))
            {
                dictionary.Add(@class.string_0, new List<MonoClass.Class273>());
                list = dictionary[@class.string_0];
            }
            MonoClass.Class273 class2 = list.FirstOrDefault(new Func<MonoClass.Class273, bool>(@class.method_0));
            if (class2 == null)
            {
                IntPtr intPtr = MonoClass.Class276_0.method_33(intptr_1, @class.string_0, @class.enum20_0);
                if (intPtr != IntPtr.Zero)
                {
                    class2 = new MonoClass.Class273(@class.string_0, intPtr, @class.enum20_0);
                    list.Add(class2);
                }
            }
            if (class2 == null)
            {
                return IntPtr.Zero;
            }
            return class2.IntPtr_0;
        }

        internal void method_8(string string_4, params object[] object_0)
        {
            this.method_9(string_4, null, object_0);
        }

        internal void method_9(string string_4, Enum20[] enum20_0, params object[] object_0)
        {
            this.method_7(string_4, enum20_0, object_0);
        }

        private static readonly AllocatedMemory[] allocatedMemory_0 = new AllocatedMemory[32];
        public static bool IsOutParam(int index, out IntPtr addr)
        {
            addr = IntPtr.Zero;
            if (index < 0 || index >= 32)
            {
                return false;
            }
            if (MonoClass.allocatedMemory_0[index] != null)
            {
                addr = MonoClass.allocatedMemory_0[index].Address;
                return true;
            }
            return false;
        }

        internal static T smethod_6<T>(string string_4, string string_5, string string_6, string string_7) where T : struct
        {
            IntPtr intPtr = smethod_9(string_4, string_5, string_6, string_7);
            if (intPtr == IntPtr.Zero)
            {
                return default;
            }
            return ExternalProcessMemory_0.Read<T>(Class276_0.method_26(intPtr));
        }

        internal static IntPtr smethod_9(string string_4, string string_5, string string_6, string string_7)
        {
            IntPtr intPtr = smethod_5(string_4, string_5, string_6, string_7);
            if (intPtr == IntPtr.Zero)
            {
                throw new MissingFieldException(string_6, string_7);
            }
            return Class276_0.method_22(IntPtr.Zero, intPtr);
        }

        private static readonly Dictionary<string, Dictionary<string, IntPtr>> dictionary_5 = new Dictionary<string, Dictionary<string, IntPtr>>();
        internal static IntPtr smethod_5(string string_4, string string_5, string string_6, string string_7)
        {
            string key = string_6 + "." + string_7;
            Dictionary<string, IntPtr> dictionary;
            if (!dictionary_5.TryGetValue(key, out dictionary))
            {
                dictionary_5.Add(key, new Dictionary<string, IntPtr>());
                dictionary = dictionary_5[key];
            }
            IntPtr intptr_ = smethod_3(string_4, string_5, string_6);
            IntPtr intPtr;
            if (!dictionary.TryGetValue(string_7, out intPtr))
            {
                intPtr = Class276_0.method_34(intptr_, string_7);
                if (intPtr != IntPtr.Zero)
                {
                    dictionary.Add(string_7, intPtr);
                }
            }
            return intPtr;
        }

        internal static Dictionary<string, IntPtr> dictionary_2;
        private static Dictionary<string, IntPtr> Dictionary_1
        {
            get
            {
                if (dictionary_2 == null)
                {
                    smethod_1();
                }
                return dictionary_2;
            }
        }
        internal static IntPtr smethod_3(string string_4, string string_5, string string_6)
        {
            string key = string.Concat(string_4, "~", string_5, ".", string_6);
            IntPtr intPtr;
            if (!Dictionary_1.TryGetValue(key, out intPtr))
            {
                intPtr = Class276_0.method_21(string_4, string_5, string_6);
                if (intPtr != IntPtr.Zero)
                {
                    Dictionary_1.Add(key, intPtr);
                }
            }
            return intPtr;
        }

        internal static Dictionary<string, IntPtr> dictionary_1;

        private static void smethod_1()
        {
            if (dictionary_1 == null)
            {
                dictionary_1 = new Dictionary<string, IntPtr>();
            }
            else
            {
                dictionary_1.Clear();
            }
            if (dictionary_2 == null)
            {
                dictionary_2 = new Dictionary<string, IntPtr>();
            }
            else
            {
                dictionary_2.Clear();
            }
            foreach (KeyValuePair<string, IntPtr> keyValuePair in TritonHs.Class276_0.method_20(TritonHs.UnityEngineAssemblyPath, ref dictionary_1))
            {
                dictionary_2.Add(keyValuePair.Key, keyValuePair.Value);
            }
            foreach (KeyValuePair<string, IntPtr> keyValuePair2 in TritonHs.Class276_0.method_20(TritonHs.MainAssemblyPath, ref dictionary_1))
            {
                dictionary_2.Add(keyValuePair2.Key, keyValuePair2.Value);
            }
        }

        private static readonly List<uint> list_0 = new List<uint>();
        internal static void smethod_0()
        {
            List<uint> obj = MonoClass.list_0;
            lock (obj)
            {
                int count = MonoClass.list_0.Count;
                foreach (uint num in MonoClass.list_0)
                {
                    MonoClass.Class276_0.method_11(num);
                }
                MonoClass.list_0.Clear();
            }
        }

        internal static T smethod_15<T>(string string_4, string string_5, string string_6, string string_7, params object[] object_0) where T : MonoClass
        {
            return MonoClass.smethod_16<T>(string_4, string_5, string_6, string_7, null, object_0);
        }

        internal static T smethod_16<T>(string string_4, string string_5, string string_6, string string_7, Enum20[] enum20_0, params object[] object_0) where T : MonoClass
        {
            IntPtr intPtr = MonoClass.smethod_10(string_4, string_5, string_6, string_7, enum20_0, object_0);
            if (intPtr == IntPtr.Zero)
            {
                return default(T);
            }
            return FastObjectFactory.CreateObjectInstance<T>(intPtr);
        }

        internal static IntPtr smethod_10(string string_4, string string_5, string string_6, string string_7, Enum20[] enum20_0, params object[] object_0)
        {
            string key = string.Concat(new string[]
            {
                string_4,
                "~",
                string_5,
                ".",
                string_6
            });
            IntPtr intPtr;
            if (!MonoClass.Dictionary_1.TryGetValue(key, out intPtr))
            {
                intPtr = MonoClass.Class276_0.method_21(string_4, string_5, string_6);
                MonoClass.Dictionary_1.Add(key, intPtr);
            }
            IntPtr intPtr2 = MonoClass.smethod_4(intPtr, string_7, enum20_0);
            if (intPtr2 == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }
            return MonoClass.Class276_0.method_43(intPtr2, IntPtr.Zero, object_0);
        }

        internal static T smethod_14<T>(string string_4, string string_5, string string_6, string string_7, params object[] object_0) where T : struct
        {
            return MonoClass.smethod_11<T>(string_4, string_5, string_6, string_7, null, object_0);
        }

        internal static T smethod_11<T>(string string_4, string string_5, string string_6, string string_7, Enum20[] enum20_0, params object[] object_0) where T : struct
        {
            IntPtr intPtr = MonoClass.smethod_10(string_4, string_5, string_6, string_7, enum20_0, object_0);
            if (intPtr == IntPtr.Zero)
            {
                return default(T);
            }
            if (typeof(T) == typeof(bool))
            {
                IntPtr addr = MonoClass.Class276_0.method_26(intPtr);
                return (T)((object)(MonoClass.ExternalProcessMemory_0.Read<byte>(addr) > 0));
            }
            return MonoClass.ExternalProcessMemory_0.Read<T>(MonoClass.Class276_0.method_26(intPtr));
        }

        internal T method_10<T>(string string_4, Enum20[] enum20_0, params object[] object_0) where T : struct
        {
            IntPtr intPtr = this.method_7(string_4, enum20_0, object_0);
            if (intPtr == IntPtr.Zero)
            {
                return default(T);
            }
            if (typeof(T) == typeof(bool))
            {
                IntPtr addr = MonoClass.Class276_0.method_26(intPtr);
                return (T)((object)(MonoClass.ExternalProcessMemory_0.Read<byte>(addr) > 0));
            }
            return MonoClass.ExternalProcessMemory_0.Read<T>(MonoClass.Class276_0.method_26(intPtr));
        }
    }
}
