using System;
using System.Runtime.InteropServices;

namespace HearthstoneBot
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct Struct110
    {
        // Token: 0x17000508 RID: 1288
        // (get) Token: 0x06001ABA RID: 6842 RVA: 0x00012F98 File Offset: 0x00011198
        internal uint UInt32_0
        {
            get
            {
                return this.uint_0 & 65535u;
            }
        }

        // Token: 0x17000509 RID: 1289
        // (get) Token: 0x06001ABB RID: 6843 RVA: 0x00012FA6 File Offset: 0x000111A6
        internal uint UInt32_1
        {
            get
            {
                return (this.uint_0 & 16711680u) / 65536u;
            }
        }

        // Token: 0x1700050A RID: 1290
        // (get) Token: 0x06001ABC RID: 6844 RVA: 0x00012FBA File Offset: 0x000111BA
        internal uint UInt32_2
        {
            get
            {
                return (this.uint_0 & 1056964608u) / 16777216u;
            }
        }

        // Token: 0x1700050B RID: 1291
        // (get) Token: 0x06001ABD RID: 6845 RVA: 0x00012FCE File Offset: 0x000111CE
        internal uint UInt32_3
        {
            get
            {
                return (this.uint_0 & 1073741824u) / 1073741824u;
            }
        }

        // Token: 0x1700050C RID: 1292
        // (get) Token: 0x06001ABE RID: 6846 RVA: 0x00012FE2 File Offset: 0x000111E2
        internal uint UInt32_4
        {
            get
            {
                return (this.uint_0 & 2147483648u) / 2147483648u;
            }
        }

        // Token: 0x04000DD0 RID: 3536
        internal IntPtr intptr_0;

        // Token: 0x04000DD1 RID: 3537
        internal uint uint_0;

        // Token: 0x04000DD2 RID: 3538
        internal Struct107 struct107_0;
    }
}
