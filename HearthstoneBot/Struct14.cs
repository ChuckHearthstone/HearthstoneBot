namespace HearthstoneBot
{
    class Struct14
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
    }
}
