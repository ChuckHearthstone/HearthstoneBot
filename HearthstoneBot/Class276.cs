using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using GreyMagic;

namespace HearthstoneBot
{
    class Class276
    {
        private readonly ExternalProcessMemory externalProcessMemory_0;

        private readonly Dictionary<Type, IntPtr> dictionary_0 = new Dictionary<Type, IntPtr>();

        private readonly IntPtr intptr_0;

        private readonly IntPtr intptr_1;

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
        private readonly IntPtr intptr_14;

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
            intptr_31 = intptr_0 + 522030;
            intptr_28 = intptr_0 + 91559;
            intptr_13 = intptr_0 + 226176;
            intptr_16 = intptr_0 + 91615;
            intptr_6 = intptr_0 + 78677;
            intptr_1 = intptr_0 + 102855;
            intptr_15 = intptr_0 + 230512;
            intptr_14 = intptr_0 + 224970;
            intptr_7 = intptr_0 + 73617;
            intptr_19 = intptr_0 + 120353;
            intptr_29 = intptr_0 + 162866;
            intptr_17 = intptr_0 + 525190;
            intptr_25 = intptr_0 + 389455;
            intptr_24 = intptr_0 + 385464;
            intptr_32 = intptr_0 + 389677;
            intptr_34 = intptr_0 + 384279;
            intptr_36 = intptr_0 + 382675;
            intptr_35 = intptr_0 + 91327;
            intptr_23 = intptr_0 + 428289;
            intptr_33 = intptr_0 + 378912;
            intptr_27 = intptr_0 + 515937;
            intptr_12 = intptr_0 + 176417;
            intptr_10 = intptr_0 + 176976;
            intptr_4 = intptr_0 + 77237;
            intptr_8 = intptr_0 + 107261;
            intptr_21 = intptr_0 + 231261;
            intptr_18 = intptr_0 + 522401;
            intptr_5 = intptr_0 + 733279;
            intptr_30 = intptr_0 + 91701;
            intptr_2 = intptr_0 + 733427;
            intptr_9 = intptr_0 + 162872;
            intptr_3 = intptr_0 + 91604;
            intptr_26 = intptr_0 + 383139;
            intptr_22 = intptr_0 + 385556;
            intptr_20 = intptr_0 + 91570;
            intptr_11 = intptr_0 + 401933;
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

        internal IntPtr method_18(string string_0)
        {
            IntPtr procAddress = externalProcessMemory_0.GetProcAddress("kernel32.dll", "GetModuleHandleW");
            IntPtr result;
            var length = string_0.Length * 2 + 2;
            using (AllocatedMemory allocatedMemory = externalProcessMemory_0.CreateAllocatedMemory(length))
            {
                allocatedMemory.WriteString(0, string_0, Encoding.Unicode);
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

        private T method_17<T>(IntPtr intptr_37, params object[] object_0) where T : struct
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
    }
}
