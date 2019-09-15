using System.IO;

namespace HearthstoneBot
{
    class Class63
    {
        public uint uint_1;

        public uint uint_2;

        public Stream stream_0;

        public void method_0(Stream stream_1)
        {
            this.stream_0 = stream_1;
            this.uint_1 = 0u;
            this.uint_2 = uint.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                this.uint_1 = (this.uint_1 << 8 | (uint)((byte)this.stream_0.ReadByte()));
            }
        }

        public void method_1()
        {
            this.stream_0 = null;
        }

        public uint method_7(int int_0)
        {
            uint num = this.uint_2;
            uint num2 = this.uint_1;
            uint num3 = 0u;
            for (int i = int_0; i > 0; i--)
            {
                num >>= 1;
                uint num4 = num2 - num >> 31;
                num2 -= (num & num4 - 1u);
                num3 = (num3 << 1 | 1u - num4);
                if (num < 16777216u)
                {
                    num2 = (num2 << 8 | (uint)((byte)this.stream_0.ReadByte()));
                    num <<= 8;
                }
            }
            this.uint_2 = num;
            this.uint_1 = num2;
            return num3;
        }
    }
}
