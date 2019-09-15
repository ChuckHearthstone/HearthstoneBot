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
    }
}
