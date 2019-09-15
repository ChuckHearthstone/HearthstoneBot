namespace HearthstoneBot
{
    struct Struct12
    {
        private uint uint_1;

        public void method_1()
        {
            this.uint_1 = 1024u;
        }

        public uint method_2(Class63 class63_0)
        {
            uint num = (class63_0.uint_2 >> 11) * this.uint_1;
            if (class63_0.uint_1 < num)
            {
                class63_0.uint_2 = num;
                this.uint_1 += 2048u - this.uint_1 >> 5;
                if (class63_0.uint_2 < 16777216u)
                {
                    class63_0.uint_1 = (class63_0.uint_1 << 8 | (uint)((byte)class63_0.stream_0.ReadByte()));
                    class63_0.uint_2 <<= 8;
                }
                return 0u;
            }
            class63_0.uint_2 -= num;
            class63_0.uint_1 -= num;
            this.uint_1 -= this.uint_1 >> 5;
            if (class63_0.uint_2 < 16777216u)
            {
                class63_0.uint_1 = (class63_0.uint_1 << 8 | (uint)((byte)class63_0.stream_0.ReadByte()));
                class63_0.uint_2 <<= 8;
            }
            return 1u;
        }

    }
}
