using System;
using Fasm;

namespace HearthstoneBot
{
    static class Class242
    {
        internal static readonly Random random_0 = new Random();

        internal static void smethod_3(this ManagedFasm managedFasm_0, string string_0)
        {
            int num = random_0.Next(2, 5);
            int num2 = num / 2;
            smethod_2(managedFasm_0, num2);
            managedFasm_0.AddLine(string_0);
            smethod_2(managedFasm_0, num % 2 + num2);
        }

        private static void smethod_2(ManagedFasm managedFasm_0, int int_0)
        {
            if (int_0 > 0)
            {
                do
                {
                    int_0--;
                    string text = smethod_1();
                    string text2 = smethod_0();
                    switch (random_0.Next(1, 6))
                    {
                        case 1:
                            for (int i = random_0.Next(1, 4); i > 0; i--)
                            {
                                managedFasm_0.AddLine("nop");
                            }
                            break;
                        case 2:
                            managedFasm_0.AddLine("mov {0}, {0}", text);
                            break;
                        case 3:
                            managedFasm_0.AddLine("mov {0}, {0}", text2);
                            break;
                        case 4:
                            managedFasm_0.AddLine("push {0}", text2);
                            managedFasm_0.AddLine("pop {0}", text2);
                            break;
                        case 5:
                            managedFasm_0.AddLine("push {0}", text);
                            managedFasm_0.AddLine("pop {0}", text);
                            break;
                    }
                }
                while (int_0 > 0);
            }
        }

        private static string smethod_0()
        {
            switch (random_0.Next(1, 7))
            {
                case 1:
                    return "ax";
                case 2:
                    return "bx";
                case 3:
                    return "cx";
                case 4:
                    return "dx";
                case 5:
                    return "di";
                case 6:
                    return "si";
                default:
                    return "ax";
            }
        }

        private static string smethod_1()
        {
            switch (random_0.Next(1, 7))
            {
                case 1:
                    return "eax";
                case 2:
                    return "ebx";
                case 3:
                    return "ecx";
                case 4:
                    return "edx";
                case 5:
                    return "edi";
                case 6:
                    return "esi";
                default:
                    return "eax";
            }
        }

        internal static void smethod_4(this ManagedFasm managedFasm_0, string string_0, params object[] object_0)
        {
            int num = random_0.Next(2, 5);
            int num2 = num / 2;
            smethod_2(managedFasm_0, num2);
            managedFasm_0.AddLine(string_0, object_0);
            smethod_2(managedFasm_0, num % 2 + num2);
        }
    }
}
