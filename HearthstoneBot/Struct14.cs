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
    }
}
