namespace HearthstoneBot
{
    struct Struct9
    {
        private Struct12[] struct12_0;

        public void method_0()
        {
            this.struct12_0 = new Struct12[768];
        }

        public void method_1()
        {
            for (int i = 0; i < 768; i++)
            {
                this.struct12_0[i].method_1();
            }
        }

        public byte method_2(Class63 class63_0)
        {
            uint num = 1u;
            do
            {
                num = (num << 1 | this.struct12_0[(int)num].method_2(class63_0));
            }
            while (num < 256u);
            return (byte)num;
        }

        public byte method_3(Class63 class63_0, byte byte_0)
        {
            uint num = 1u;
            for (; ; )
            {
                uint num2 = (uint)(byte_0 >> 7 & 1);
                byte_0 = (byte)(byte_0 << 1);
                uint num3 = this.struct12_0[(int)((1u + num2 << 8) + num)].method_2(class63_0);
                num = (num << 1 | num3);
                if (num2 != num3)
                {
                    break;
                }
                if (num >= 256u)
                {
                    goto IL_5C;
                }
            }
            while (num < 256u)
            {
                num = (num << 1 | this.struct12_0[(int)num].method_2(class63_0));
            }
            IL_5C:
            return (byte)num;
        }
    }
}
