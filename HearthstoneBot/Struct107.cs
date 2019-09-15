namespace HearthstoneBot
{
    internal struct Struct107
    {
        // Token: 0x170004F2 RID: 1266
        // (get) Token: 0x06001A9B RID: 6811 RVA: 0x00012D5A File Offset: 0x00010F5A
        // (set) Token: 0x06001A9C RID: 6812 RVA: 0x00012D64 File Offset: 0x00010F64
        internal uint UInt32_0
        {
            get
            {
                return this.uint_0 & 1u;
            }
            set
            {
                this.uint_0 = (value | this.uint_0);
            }
        }

        // Token: 0x170004F3 RID: 1267
        // (get) Token: 0x06001A9D RID: 6813 RVA: 0x00012D74 File Offset: 0x00010F74
        // (set) Token: 0x06001A9E RID: 6814 RVA: 0x00012D81 File Offset: 0x00010F81
        internal uint UInt32_1
        {
            get
            {
                return (this.uint_0 & 4294967294u) / 2u;
            }
            set
            {
                this.uint_0 = (value * 2u | this.uint_0);
            }
        }

        // Token: 0x04000D95 RID: 3477
        internal uint uint_0;
    }
}
