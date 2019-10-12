using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using GreyMagic;

namespace HearthstoneBot
{
    class Class276
    {
        internal readonly ExternalProcessMemory externalProcessMemory_0;

        private readonly Dictionary<Type, IntPtr> dictionary_0 = new Dictionary<Type, IntPtr>();

        private readonly IntPtr intptr_0;

        internal readonly IntPtr intptr_1;

        // Token: 0x04000D4D RID: 3405
        private readonly IntPtr intptr_2;

        // Token: 0x04000D4E RID: 3406
        private readonly IntPtr intptr_3;

        // Token: 0x04000D4F RID: 3407
        private readonly IntPtr intptr_4;

        // Token: 0x04000D50 RID: 3408
        private readonly IntPtr intptr_5;

        // Token: 0x04000D51 RID: 3409
        private readonly IntPtr intptr_6;

        // Token: 0x04000D52 RID: 3410
        private readonly IntPtr intptr_7;

        // Token: 0x04000D53 RID: 3411
        private readonly IntPtr intptr_8;

        // Token: 0x04000D54 RID: 3412
        private readonly IntPtr intptr_9;

        // Token: 0x04000D55 RID: 3413
        private readonly IntPtr intptr_10;

        // Token: 0x04000D56 RID: 3414
        private readonly IntPtr intptr_11;

        // Token: 0x04000D57 RID: 3415
        private readonly IntPtr intptr_12;

        // Token: 0x04000D58 RID: 3416
        private readonly IntPtr intptr_13;

        // Token: 0x04000D59 RID: 3417
        internal readonly IntPtr intptr_14;

        // Token: 0x04000D5A RID: 3418
        private readonly IntPtr intptr_15;

        // Token: 0x04000D5B RID: 3419
        private readonly IntPtr intptr_16;

        // Token: 0x04000D5C RID: 3420
        private readonly IntPtr intptr_17;

        // Token: 0x04000D5D RID: 3421
        private readonly IntPtr intptr_18;

        // Token: 0x04000D5E RID: 3422
        private readonly IntPtr intptr_19;

        // Token: 0x04000D5F RID: 3423
        private readonly IntPtr intptr_20;

        // Token: 0x04000D60 RID: 3424
        private readonly IntPtr intptr_21;

        // Token: 0x04000D61 RID: 3425
        private readonly IntPtr intptr_22;

        // Token: 0x04000D62 RID: 3426
        private readonly IntPtr intptr_23;

        // Token: 0x04000D63 RID: 3427
        private readonly IntPtr intptr_24;

        // Token: 0x04000D64 RID: 3428
        private readonly IntPtr intptr_25;

        // Token: 0x04000D65 RID: 3429
        private readonly IntPtr intptr_26;

        // Token: 0x04000D66 RID: 3430
        private readonly IntPtr intptr_27;

        // Token: 0x04000D67 RID: 3431
        private readonly IntPtr intptr_28;

        // Token: 0x04000D68 RID: 3432
        private readonly IntPtr intptr_29;

        // Token: 0x04000D69 RID: 3433
        private readonly IntPtr intptr_30;

        // Token: 0x04000D6A RID: 3434
        private readonly IntPtr intptr_31;

        // Token: 0x04000D6B RID: 3435
        private readonly IntPtr intptr_32;

        // Token: 0x04000D6C RID: 3436
        private readonly IntPtr intptr_33;

        // Token: 0x04000D6D RID: 3437
        private readonly IntPtr intptr_34;

        // Token: 0x04000D6E RID: 3438
        private readonly IntPtr intptr_35;

        // Token: 0x04000D6F RID: 3439
        private readonly IntPtr intptr_36;

        internal Class276(ExternalProcessMemory memory)
        {
            externalProcessMemory_0 = memory;
            intptr_0 = method_18("mono.dll");
            intptr_1 = intptr_0 + 0x19193;
            intptr_2 = intptr_0 + 0xB2DA2;
            intptr_3 = intptr_0 + 0x1657F;
            intptr_4 = intptr_0 + 0x12D60;
            intptr_5 = intptr_0 + 0x1D6AA;
            intptr_6 = intptr_0 + 0x13300;
            intptr_7 = intptr_0 + 0x11F3C;
            intptr_8 = intptr_0 + 0x1A2C9;
            intptr_9 = intptr_0 + 0x27BD0;
            intptr_10 = intptr_0 + 0x2B31E;
            intptr_11 = intptr_0 + 0x62181;
            intptr_12 = intptr_0 + 0x2B0EF;
            intptr_13 = intptr_0 + 0x3733B;
            intptr_14 = intptr_0 + 0x36E85;
            intptr_15 = intptr_0 + 0x3842B;
            intptr_16 = intptr_0 + 0x1658A;
            intptr_17 = intptr_0 + 0x800ED;
            intptr_18 = intptr_0 + 0x7F77D;
            intptr_19 = intptr_0 + 0x1D5ED;
            intptr_20 = intptr_0 + 0x36E5F;
            intptr_21 = intptr_0 + 0x16601;
            intptr_22 = intptr_0 + 0x5E188;
            intptr_23 = intptr_0 + 0x687F4;
            intptr_24 = intptr_0 + 0x5E12C;
            intptr_25 = intptr_0 + 0x5F0C3;
            intptr_26 = intptr_0 + 0x5D817;
            intptr_27 = intptr_0 + 0x7DE5C;
            intptr_28 = intptr_0 + 0x1655D;
            intptr_29 = intptr_0 + 0x27BCA;
            intptr_30 = intptr_0 + 0x165F6;
            intptr_31 = intptr_0 + 0x7F60A;
            intptr_32 = intptr_0 + 0x5F1A1;
            intptr_33 = intptr_0 + 0x5C79C;
            intptr_34 = intptr_0 + 0x5DC8B;
            intptr_35 = intptr_0 + 0x16475;
            intptr_36 = intptr_0 + 0x5D647;

            method_15<bool>("boolean");
            method_15<object>("object");
            method_15<sbyte>("sbyte");
            method_15<byte>("byte");
            method_15<short>("int16");
            method_15<ushort>("uint16");
            method_15<int>("int32");
            method_15<uint>("uint32");
            method_15<long>("int64");
            method_15<ulong>("uint64");
            method_15<float>("single");
            method_15<double>("double");
            method_15<char>("char");
            method_15<string>("string");
            method_15<Enum>("enum");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryName">mono.dll</param>
        /// <returns></returns>
        internal IntPtr method_18(string libraryName)
        {
            IntPtr procAddress = externalProcessMemory_0.GetProcAddress("kernel32.dll", "GetModuleHandleW");
            IntPtr result;
            var length = libraryName.Length * 2 + 2;
            using (AllocatedMemory allocatedMemory = externalProcessMemory_0.CreateAllocatedMemory(length))
            {
                allocatedMemory.WriteString(0, libraryName, Encoding.Unicode);
                result = externalProcessMemory_0.CallInjected<IntPtr>(procAddress, CallingConvention.StdCall, allocatedMemory.Address);
            }
            return result;
        }

        private void method_15<T>(string string_0)
        {
            var ptr1 = method_19($"mono_get_{string_0}_class");
            var ptr2 = method_17<IntPtr>(ptr1, Array.Empty<object>());
            dictionary_0.Add(typeof(T), ptr2);
        }

        internal T method_17<T>(IntPtr intptr_37, params object[] object_0) where T : struct
        {
            return externalProcessMemory_0.CallInjected<T>(intptr_37, CallingConvention.Cdecl, object_0);
        }

        internal IntPtr method_19(string string_0)
        {
            IntPtr procAddress = externalProcessMemory_0.GetProcAddress("kernel32.dll", "GetProcAddress");
            IntPtr result;
            var length = string_0.Length + 1;
            using (AllocatedMemory allocatedMemory = externalProcessMemory_0.CreateAllocatedMemory(length))
            {
                allocatedMemory.WriteString(0, string_0, Encoding.ASCII);
                result = externalProcessMemory_0.CallInjected<IntPtr>(procAddress, CallingConvention.StdCall, intptr_0, allocatedMemory.Address);
            }
            return result;
        }

        internal IntPtr method_2()
        {
            var ptr = method_4();
            return method_17<IntPtr>(intptr_31, ptr);
        }

        internal IntPtr method_4()
        {
            return method_17<IntPtr>(intptr_29, Array.Empty<object>());
        }

        internal IntPtr method_22(IntPtr intptr_37, IntPtr intptr_38)
        {
            IntPtr intPtr = this.method_27();
            return this.method_17<IntPtr>(this.intptr_11, new object[]
            {
                intPtr,
                intptr_38,
                intptr_37
            });
        }

        internal IntPtr method_26(IntPtr intptr_37)
        {
            return this.method_17<IntPtr>(this.intptr_22, new object[]
            {
                intptr_37
            });
        }

        internal IntPtr method_27()
        {
            return this.method_17<IntPtr>(this.intptr_9, Array.Empty<object>());
        }

        internal Dictionary<string, IntPtr> method_20(string string_0, ref Dictionary<string, IntPtr> dictionary_1)
        {
            Dictionary<string, IntPtr> dictionary = new Dictionary<string, IntPtr>();
            IntPtr value = this.method_29();
            IntPtr intPtr = this.method_30();
            //value != intPtr;
            if (intPtr == IntPtr.Zero)
            {
                throw new Exception("Code is not running on a mono thread!");
            }
            int num;
            IntPtr intptr_ = this.method_40(string_0, out num);
            this.method_16(intptr_, "Could not load assembly. Status: " + num);
            IntPtr intptr_2 = this.method_39(intptr_);
            this.method_16(intptr_2, "Could not open mono image. Status: " + num);
            foreach (IntPtr intPtr2 in this.method_44(intptr_2))
            {
                if (intPtr2 != IntPtr.Zero)
                {
                    this.externalProcessMemory_0.Read<Struct111>(intPtr2);
                    IntPtr intPtr3 = this.method_14(intPtr2);
                    string text = this.method_45(intPtr2);
                    if (intPtr3 != IntPtr.Zero)
                    {
                        text = this.method_44(intPtr3) + "." + text;
                    }
                    string text2 = this.method_46(intPtr2);
                    if (!dictionary.ContainsKey(string.Concat(new string[]
                    {
                        string_0,
                        "~",
                        text2,
                        ".",
                        text
                    })))
                    {
                        string key = string.Concat(new string[]
                        {
                            string_0,
                            "~",
                            text2,
                            ".",
                            text
                        });
                        dictionary.Add(key, intPtr2);
                        dictionary_1.Add(key, this.method_12(intPtr2));
                    }
                }
            }
            return dictionary;
        }

        internal IntPtr method_29()
        {
            return this.method_17<IntPtr>(this.intptr_33, Array.Empty<object>());
        }

        internal IntPtr method_30()
        {
            return this.method_17<IntPtr>(this.intptr_27, Array.Empty<object>());
        }

        internal IntPtr method_39(IntPtr intptr_37)
        {
            return this.method_17<IntPtr>(this.intptr_4, new object[]
            {
                intptr_37
            });
        }

        internal IntPtr method_40(string string_0, out int int_0)
        {
            IntPtr result;
            using (AllocatedMemory allocatedMemory = this.externalProcessMemory_0.CreateAllocatedMemory(string_0.Length * 2 + 2 + 4))
            {
                allocatedMemory.WriteString(4, string_0, Encoding.UTF8);
                IntPtr intPtr = this.method_17<IntPtr>(this.intptr_6, new object[]
                {
                    allocatedMemory.Address + 4,
                    allocatedMemory.Address
                });
                int_0 = allocatedMemory.Read<int>(0);
                result = intPtr;
            }
            return result;
        }

        private void method_16(IntPtr intptr_37, string string_0)
        {
            if (intptr_37 == IntPtr.Zero)
            {
                throw new Exception(string_0);
            }
        }

        internal IEnumerable<IntPtr> method_44(IntPtr intptr_37)
        {
            Class277 @class = new Class277(-2);
            @class.class276_0 = this;
            @class.intptr_2 = intptr_37;
            return @class;
        }

        internal IntPtr method_14(IntPtr intptr_37)
        {
            return this.method_17<IntPtr>(this.intptr_20, new object[]
            {
                intptr_37
            });
        }

        internal string method_45(IntPtr intptr_37)
        {
            IntPtr intPtr = this.method_14(intptr_37);
            string text = "";
            while (intPtr != IntPtr.Zero)
            {
                text = this.method_45(intPtr) + "." + text;
                intPtr = this.method_14(intPtr);
            }
            return text + this.externalProcessMemory_0.ReadStringA(this.method_17<IntPtr>(this.intptr_2, new object[]
            {
                intptr_37
            }));
        }

        internal string method_46(IntPtr intptr_37)
        {
            return this.externalProcessMemory_0.ReadStringA(this.method_17<IntPtr>(this.intptr_3, new object[]
            {
                intptr_37
            }));
        }

        internal IntPtr method_12(IntPtr intptr_37)
        {
            return this.method_17<IntPtr>(this.intptr_16, new object[]
            {
                intptr_37
            });
        }

        internal IntPtr method_34(IntPtr intptr_37, string string_0)
        {
            while (intptr_37 != IntPtr.Zero)
            {
                using (AllocatedMemory allocatedMemory = this.externalProcessMemory_0.CreateAllocatedMemory(256))
                {
                    allocatedMemory.AllocateOfChunk<IntPtr>("Itr");
                    IntPtr intPtr;
                    while ((intPtr = this.method_36(intptr_37, allocatedMemory["Itr"])) != IntPtr.Zero)
                    {
                        IntPtr address = this.method_38(intPtr);
                        if (this.externalProcessMemory_0.ReadStringA(address) == string_0)
                        {
                            return intPtr;
                        }
                    }
                }
                intptr_37 = this.method_25(intptr_37);
            }
            return IntPtr.Zero;
        }

        internal IntPtr method_36(IntPtr intptr_37, IntPtr intptr_38)
        {
            return this.method_17<IntPtr>(this.intptr_8, new object[]
            {
                intptr_37,
                intptr_38
            });
        }

        internal IntPtr method_38(IntPtr intptr_37)
        {
            return this.method_17<IntPtr>(this.intptr_30, new object[]
            {
                intptr_37
            });
        }

        internal IntPtr method_25(IntPtr intptr_37)
        {
            return this.method_17<IntPtr>(this.intptr_28, new object[]
            {
                intptr_37
            });
        }

        internal IntPtr method_21(string string_0, string string_1, string string_2)
        {
            IntPtr value = this.method_29();
            IntPtr intPtr = this.method_30();
            //value != intPtr;
            if (intPtr == IntPtr.Zero)
            {
                throw new Exception("Code is not running on a mono thread!");
            }
            int num;
            IntPtr intptr_ = this.method_40(string_0, out num);
            this.method_16(intptr_, "Could not load assembly. Status: " + num);
            IntPtr intptr_2 = this.method_39(intptr_);
            this.method_16(intptr_2, "Could not open mono image. Status: " + num);
            using (IEnumerator<IntPtr> enumerator = this.method_44(intptr_2).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    IntPtr intPtr2 = enumerator.Current;
                    if (intPtr2 != IntPtr.Zero)
                    {
                        string a = this.method_45(intPtr2);
                        string a2 = this.method_46(intPtr2);
                        if (a == string_2 && a2 == string_1)
                        {
                            return intPtr2;
                        }
                    }
                }
            }
            Debugger.Break();
            return IntPtr.Zero;
        }

        internal void method_11(uint uint_0)
        {
            this.method_17<int>(this.intptr_10, new object[]
            {
                uint_0
            });
        }
    }
}
