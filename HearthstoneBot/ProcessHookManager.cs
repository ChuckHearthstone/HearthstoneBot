using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Fasm;
using GreyMagic;

namespace HearthstoneBot
{
    public enum StateEnum
    {
        // Token: 0x04000C6C RID: 3180
        None,
        // Token: 0x04000C6D RID: 3181
        Enabled,
        // Token: 0x04000C6E RID: 3182
        Disabled
    }

    class ProcessHookManager
    {
        public static StateEnum State { get; set; }

        private static string[] string_0 = {"PatchTrack.dat"};

        internal static string String_0
        {
            get
            {
                return string.Format("PatchTrack_v2_{0}{1}{2}{3}{4}{5}{6}", new object[]
                {
                    1,
                    1,
                    0,
                    1,
                    1,
                    1,
                    0
                });
            }
        }

        internal static ExternalProcessMemory ExternalProcessMemory_0 => TritonHs.Memory;

        private static IntPtr intptr_1;

        private static IntPtr intptr_0;

        private static IntPtr intptr_2;

        private static IntPtr intptr_3;

        private static IntPtr intptr_4;

        private static AllocatedMemory allocatedMemory_0;

        private static IntPtr IntPtr_0
        {
            get
            {
                return TritonHs.ClientWindowHandle;
            }
        }

        private static byte[] byte_0;

        private static byte[] byte_1;

        private static byte[] byte_2;

        private static byte[] byte_3;

        private static byte[] byte_4;

        private static int int_0;

        private static int int_1;

        private static int int_2;

        private static int int_3;

        private static int int_4;

        private static int int_5;

        private static int int_6;

        private static List<Class243> smethod_0()
        {
            List<Class243> list = new List<Class243>();
            if (File.Exists(ProcessHookManager.String_0))
            {
                using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(ProcessHookManager.String_0)))
                {
                    int num = binaryReader.ReadInt32();
                    for (int i = 0; i < num; i++)
                    {
                        int num2 = binaryReader.ReadInt32();
                        int num3 = binaryReader.ReadInt32();
                        List<byte[]> list2 = new List<byte[]>();
                        for (int j = 0; j < num3; j++)
                        {
                            int count = binaryReader.ReadInt32();
                            list2.Add(binaryReader.ReadBytes(count));
                        }
                        list.Add(new Class243
                        {
                            int_0 = num2,
                            list_0 = list2
                        });
                    }
                }
            }
            return list;
        }

        private static List<byte[]> smethod_1()
        {
            List<Class243> list = smethod_0();
            if (list.Count == 0)
            {
                return null;
            }
            Class243 @class = list.FirstOrDefault(Class244.Instance.method_0);
            if (@class != null)
            {
                return @class.list_0;
            }
            return null;
        }

        internal static void smethod_3()
        {
            State = StateEnum.None;
            foreach (string path in string_0)
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                }
            }
            ExternalProcessMemory externalProcessMemory_ = ExternalProcessMemory_0;
            intptr_1 = externalProcessMemory_.GetProcAddress("user32.dll", "GetActiveWindow");
            if (intptr_1 == IntPtr.Zero)
            {
                throw new Exception("The function 'GetActiveWindow' was not found.");
            }
            intptr_0 = externalProcessMemory_.GetProcAddress("user32.dll", "GetForegroundWindow");
            if (intptr_0 == IntPtr.Zero)
            {
                throw new Exception("The function 'GetForegroundWindow' was not found.");
            }
            intptr_2 = externalProcessMemory_.GetProcAddress("user32.dll", "GetKeyState");
            if (intptr_2 == IntPtr.Zero)
            {
                throw new Exception("The function 'GetKeyState' was not found.");
            }
            intptr_3 = externalProcessMemory_.GetProcAddress("user32.dll", "GetCursorPos");
            if (intptr_3 == IntPtr.Zero)
            {
                throw new Exception("The function 'GetCursorPos' was not found.");
            }
            intptr_4 = externalProcessMemory_.GetProcAddress("user32.dll", "ScreenToClient");
            if (intptr_4 == IntPtr.Zero)
            {
                throw new Exception("The function 'ScreenToClient' was not found.");
            }
            allocatedMemory_0 = externalProcessMemory_.CreateAllocatedMemory(4096);
            List<byte[]> list = ProcessHookManager.smethod_1();
            if (list != null)
            {
                using (TritonHs.AcquireFrame())
                {
                    ExternalProcessMemory_0.WriteBytes(intptr_0, list[0]);
                    ExternalProcessMemory_0.WriteBytes(intptr_1, list[1]);
                    ExternalProcessMemory_0.WriteBytes(intptr_2, list[2]);
                    ExternalProcessMemory_0.WriteBytes(intptr_3, list[3]);
                    ExternalProcessMemory_0.WriteBytes(intptr_4, list[4]);
                }
            }
            bool flag = false;
            try
            {
                IntPtr intPtr_ = ProcessHookManager.IntPtr_0;
                ManagedFasm asm = externalProcessMemory_.Asm;
                asm.Clear();
                asm.smethod_3("mov eax, " + intPtr_);
                asm.smethod_3("retn");
                byte[] array2 = asm.Assemble();
                asm.Clear();
                allocatedMemory_0.WriteBytes(0, array2);
                int value = (allocatedMemory_0.Address + 0).ToInt32() - intptr_0.ToInt32() - 5;
                int value2 = (allocatedMemory_0.Address + 0).ToInt32() - intptr_1.ToInt32() - 5;
                int num = 0 + array2.Length;
                ProcessHookManager.byte_0 = new byte[5];
                ProcessHookManager.byte_0[0] = 233;
                byte[] bytes = BitConverter.GetBytes(value);
                for (int j = 0; j < bytes.Length; j++)
                {
                    ProcessHookManager.byte_0[j + 1] = bytes[j];
                }
                ProcessHookManager.byte_1 = new byte[5];
                ProcessHookManager.byte_1[0] = 233;
                byte[] bytes2 = BitConverter.GetBytes(value2);
                for (int k = 0; k < bytes2.Length; k++)
                {
                    ProcessHookManager.byte_1[k + 1] = bytes2[k];
                }
                externalProcessMemory_.Patches.Create(intptr_0, ProcessHookManager.byte_0, "ProcessHookManager_GetForegroundWindow");
                externalProcessMemory_.Patches.Create(intptr_1, ProcessHookManager.byte_1, "ProcessHookManager_GetActiveWindow");
                byte[] bytes3 = new byte[1024];
                allocatedMemory_0.WriteBytes(num, bytes3);
                IntPtr intPtr = allocatedMemory_0.Address + num;
                ProcessHookManager.int_0 = num;
                num += 1024;
                byte[] bytes4 = new byte[8];
                allocatedMemory_0.WriteBytes(num, bytes4);
                IntPtr intPtr2 = allocatedMemory_0.Address + num;
                num += 4;
                IntPtr intPtr3 = allocatedMemory_0.Address + num;
                num += 4;
                ManagedFasm asm2 = externalProcessMemory_.Asm;
                asm2.Clear();
                asm2.smethod_3("pop eax");
                asm2.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr2
                });
                asm2.smethod_3("pop eax");
                asm2.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr3
                });
                asm2.smethod_3("imul eax, 4");
                asm2.smethod_4("add eax, {0}", new object[]
                {
            intPtr
                });
                asm2.smethod_3("mov eax, [eax]");
                asm2.smethod_4("pushd [{0}]", new object[]
                {
            intPtr2
                });
                asm2.smethod_3("retn");
                byte[] array3 = asm2.Assemble();
                asm2.Clear();
                allocatedMemory_0.WriteBytes(num, array3);
                int value3 = (allocatedMemory_0.Address + num).ToInt32() - intptr_2.ToInt32() - 5;
                num += array3.Length;
                ProcessHookManager.byte_2 = new byte[5];
                ProcessHookManager.byte_2[0] = 233;
                byte[] bytes5 = BitConverter.GetBytes(value3);
                for (int l = 0; l < bytes5.Length; l++)
                {
                    ProcessHookManager.byte_2[l + 1] = bytes5[l];
                }
                externalProcessMemory_.Patches.Create(intptr_2, ProcessHookManager.byte_2, "ProcessHookManager_GetKeyState");
                byte[] array4 = new byte[12];
                array4[8] = 1;
                allocatedMemory_0.WriteBytes(num, array4);
                IntPtr intPtr4 = allocatedMemory_0.Address + num;
                ProcessHookManager.int_1 = num;
                num += 4;
                ProcessHookManager.int_2 = num;
                num += 4;
                ProcessHookManager.int_3 = num;
                num += 4;
                byte[] bytes6 = new byte[8];
                allocatedMemory_0.WriteBytes(num, bytes6);
                IntPtr intPtr5 = allocatedMemory_0.Address + num;
                num += 4;
                IntPtr intPtr6 = allocatedMemory_0.Address + num;
                num += 4;
                ManagedFasm asm3 = externalProcessMemory_.Asm;
                asm3.Clear();
                asm3.smethod_3("pop eax");
                asm3.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr5
                });
                asm3.smethod_3("pop eax");
                asm3.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr6
                });
                asm3.smethod_3("push ecx");
                asm3.smethod_4("mov ecx, {0}", new object[]
                {
            intPtr4
                });
                asm3.smethod_3("mov ecx, [ecx]");
                asm3.smethod_3("mov [eax], ecx");
                asm3.smethod_3("add eax, 4");
                asm3.smethod_4("mov ecx, {0}", new object[]
                {
            intPtr4
                });
                asm3.smethod_3("add ecx, 4");
                asm3.smethod_3("mov ecx, [ecx]");
                asm3.smethod_3("mov [eax], ecx");
                asm3.smethod_4("mov ecx, {0}", new object[]
                {
            intPtr4
                });
                asm3.smethod_3("add ecx, 8");
                asm3.smethod_3("mov eax, [ecx]");
                asm3.smethod_3("pop ecx");
                asm3.smethod_4("pushd [{0}]", new object[]
                {
            intPtr5
                });
                asm3.smethod_3("retn");
                byte[] array5 = asm3.Assemble();
                asm3.Clear();
                allocatedMemory_0.WriteBytes(num, array5);
                int value4 = (allocatedMemory_0.Address + num).ToInt32() - intptr_3.ToInt32() - 5;
                num += array5.Length;
                ProcessHookManager.byte_3 = new byte[5];
                ProcessHookManager.byte_3[0] = 233;
                byte[] bytes7 = BitConverter.GetBytes(value4);
                for (int m = 0; m < bytes7.Length; m++)
                {
                    ProcessHookManager.byte_3[m + 1] = bytes7[m];
                }
                externalProcessMemory_.Patches.Create(intptr_3, ProcessHookManager.byte_3, "ProcessHookManager_GetCursorPos");
                byte[] array6 = new byte[12];
                array6[8] = 1;
                allocatedMemory_0.WriteBytes(num, array6);
                IntPtr intPtr7 = allocatedMemory_0.Address + num;
                ProcessHookManager.int_4 = num;
                num += 4;
                ProcessHookManager.int_5 = num;
                num += 4;
                ProcessHookManager.int_6 = num;
                num += 4;
                byte[] bytes8 = new byte[12];
                allocatedMemory_0.WriteBytes(num, bytes8);
                IntPtr intPtr8 = allocatedMemory_0.Address + num;
                num += 4;
                IntPtr intPtr9 = allocatedMemory_0.Address + num;
                num += 4;
                IntPtr intPtr10 = allocatedMemory_0.Address + num;
                num += 4;
                ManagedFasm asm4 = externalProcessMemory_.Asm;
                asm4.Clear();
                asm4.smethod_3("pop eax");
                asm4.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr8
                });
                asm4.smethod_3("pop eax");
                asm4.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr9
                });
                asm4.smethod_3("pop eax");
                asm4.smethod_4("mov [{0}], eax", new object[]
                {
            intPtr10
                });
                asm4.smethod_3("push ecx");
                asm4.smethod_4("mov ecx, {0}", new object[]
                {
            intPtr7
                });
                asm4.smethod_3("mov ecx, [ecx]");
                asm4.smethod_3("mov [eax], ecx");
                asm4.smethod_3("add eax, 4");
                asm4.smethod_4("mov ecx, {0}", new object[]
                {
            intPtr7
                });
                asm4.smethod_3("add ecx, 4");
                asm4.smethod_3("mov ecx, [ecx]");
                asm4.smethod_3("mov [eax], ecx");
                asm4.smethod_4("mov ecx, {0}", new object[]
                {
            intPtr7
                });
                asm4.smethod_3("add ecx, 8");
                asm4.smethod_3("mov eax, [ecx]");
                asm4.smethod_3("pop ecx");
                asm4.smethod_4("pushd [{0}]", new object[]
                {
            intPtr8
                });
                asm4.smethod_3("retn");
                byte[] array7 = asm4.Assemble();
                asm4.Clear();
                allocatedMemory_0.WriteBytes(num, array7);
                int value5 = (allocatedMemory_0.Address + num).ToInt32() - intptr_4.ToInt32() - 5;
                num += array7.Length;
                ProcessHookManager.byte_4 = new byte[5];
                ProcessHookManager.byte_4[0] = 233;
                byte[] bytes9 = BitConverter.GetBytes(value5);
                for (int n = 0; n < bytes9.Length; n++)
                {
                    ProcessHookManager.byte_4[n + 1] = bytes9[n];
                }
                externalProcessMemory_.Patches.Create(intptr_4, ProcessHookManager.byte_4, "ProcessHookManager_ScreenToClient");
                ProcessHookManager.smethod_2();
            }
            catch (Exception)
            {
                flag = true;
                throw;
            }
            finally
            {
                if (flag && allocatedMemory_0 != null)
                {
                    allocatedMemory_0.Dispose();
                    allocatedMemory_0 = null;
                }
            }
        }

    }
}
