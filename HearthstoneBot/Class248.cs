namespace HearthstoneBot
{
    class Class248
    {
        public static unsafe uint smethod_0(byte[] byte_0, uint uint_1 = 3314489979u)
        {
            int num = byte_0.Length;
            if (num == 0)
            {
                return 0u;
            }
            uint num2 = uint_1 ^ (uint)num;
            int num3 = num & 3;
            int num4 = num >> 2;
            fixed (byte* ptr = &byte_0[0])
            {
                uint* ptr2 = (uint*)ptr;
                while (num4 != 0)
                {
                    uint num5 = *ptr2;
                    num5 *= 1540483477u;
                    num5 ^= num5 >> 24;
                    num5 *= 1540483477u;
                    num2 *= 1540483477u;
                    num2 ^= num5;
                    num4--;
                    ptr2++;
                }
                switch (num3)
                {
                    case 1:
                        num2 ^= (uint)(*(byte*)ptr2);
                        num2 *= 1540483477u;
                        break;
                    case 2:
                        num2 ^= (uint)((ushort)(*ptr2));
                        num2 *= 1540483477u;
                        break;
                    case 3:
                        num2 ^= (uint)((ushort)(*ptr2));
                        num2 ^= (uint)((uint)((byte*)ptr2)[2] << 16);
                        num2 *= 1540483477u;
                        break;
                }
            }
            num2 ^= num2 >> 13;
            num2 *= 1540483477u;
            return num2 ^ num2 >> 15;
        }
    }
}
