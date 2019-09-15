namespace HearthstoneBot
{
    struct Struct14
    {
        private readonly Struct12[] struct12_0;

        private readonly int int_0;

        public Struct14(int numBitLevels)
        {
            this.int_0 = numBitLevels;
            this.struct12_0 = new Struct12[1 << numBitLevels];
        }

        public void method_0()
        {
            uint num = 1u;
            while ((ulong)num < (ulong)(1L << (this.int_0 & 31)))
            {
                this.struct12_0[(int)num].method_1();
                num += 1u;
            }
        }

        public uint method_1(Class63 class63_0)
        {
            uint num = 1u;
            for (int i = this.int_0; i > 0; i--)
            {
                num = (num << 1) + this.struct12_0[(int)num].method_2(class63_0);
            }
            return num - (1u << this.int_0);
        }

        public uint method_2(Class63 class63_0)
        {
            uint num = 1u;
            uint num2 = 0u;
            for (int i = 0; i < this.int_0; i++)
            {
                uint num3 = this.struct12_0[(int)num].method_2(class63_0);
                num <<= 1;
                num += num3;
                num2 |= num3 << i;
            }
            return num2;
        }

        public static uint smethod_0(Struct12[] struct12_1, uint uint_0, Class63 class63_0, int int_1)
        {
            uint num = 1u;
            uint num2 = 0u;
            for (int i = 0; i < int_1; i++)
            {
                uint num3 = struct12_1[(int)(uint_0 + num)].method_2(class63_0);
                num <<= 1;
                num += num3;
                num2 |= num3 << i;
            }
            return num2;
        }
    }
}
