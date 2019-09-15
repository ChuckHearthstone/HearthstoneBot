using System;
using System.Collections.Generic;
using GreyMagic;

namespace HearthstoneBot
{
    class MonoClass
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
    }
}
