using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Struct109
    {
        // Token: 0x17000501 RID: 1281
        // (get) Token: 0x06001AAC RID: 6828 RVA: 0x00012E7E File Offset: 0x0001107E
        // (set) Token: 0x06001AAD RID: 6829 RVA: 0x00012E8C File Offset: 0x0001108C
        internal uint UInt32_0
        {
            get
            {
                return this.uint_0 & 65535u;
            }
            set
            {
                this.uint_0 = (value | this.uint_0);
            }
        }

        // Token: 0x17000502 RID: 1282
        // (get) Token: 0x06001AAE RID: 6830 RVA: 0x00012E9C File Offset: 0x0001109C
        // (set) Token: 0x06001AAF RID: 6831 RVA: 0x00012EB0 File Offset: 0x000110B0
        internal uint UInt32_1
        {
            get
            {
                return (this.uint_0 & 4128768u) / 65536u;
            }
            set
            {
                this.uint_0 = (value * 65536u | this.uint_0);
            }
        }

        // Token: 0x17000503 RID: 1283
        // (get) Token: 0x06001AB0 RID: 6832 RVA: 0x00012EC6 File Offset: 0x000110C6
        // (set) Token: 0x06001AB1 RID: 6833 RVA: 0x00012EDA File Offset: 0x000110DA
        internal uint UInt32_2
        {
            get
            {
                return (this.uint_0 & 4194304u) / 4194304u;
            }
            set
            {
                this.uint_0 = (value * 4194304u | this.uint_0);
            }
        }

        // Token: 0x17000504 RID: 1284
        // (get) Token: 0x06001AB2 RID: 6834 RVA: 0x00012EF0 File Offset: 0x000110F0
        // (set) Token: 0x06001AB3 RID: 6835 RVA: 0x00012F04 File Offset: 0x00011104
        internal uint UInt32_3
        {
            get
            {
                return (this.uint_0 & 8388608u) / 8388608u;
            }
            set
            {
                this.uint_0 = (value * 8388608u | this.uint_0);
            }
        }

        // Token: 0x17000505 RID: 1285
        // (get) Token: 0x06001AB4 RID: 6836 RVA: 0x00012F1A File Offset: 0x0001111A
        // (set) Token: 0x06001AB5 RID: 6837 RVA: 0x00012F2E File Offset: 0x0001112E
        internal uint UInt32_4
        {
            get
            {
                return (this.uint_0 & 16777216u) / 16777216u;
            }
            set
            {
                this.uint_0 = (value * 16777216u | this.uint_0);
            }
        }

        // Token: 0x17000506 RID: 1286
        // (get) Token: 0x06001AB6 RID: 6838 RVA: 0x00012F44 File Offset: 0x00011144
        // (set) Token: 0x06001AB7 RID: 6839 RVA: 0x00012F58 File Offset: 0x00011158
        internal uint UInt32_5
        {
            get
            {
                return (this.uint_0 & 33554432u) / 33554432u;
            }
            set
            {
                this.uint_0 = (value * 33554432u | this.uint_0);
            }
        }

        // Token: 0x17000507 RID: 1287
        // (get) Token: 0x06001AB8 RID: 6840 RVA: 0x00012F6E File Offset: 0x0001116E
        // (set) Token: 0x06001AB9 RID: 6841 RVA: 0x00012F82 File Offset: 0x00011182
        internal uint UInt32_6
        {
            get
            {
                return (this.uint_0 & 67108864u) / 67108864u;
            }
            set
            {
                this.uint_0 = (value * 67108864u | this.uint_0);
            }
        }

        // Token: 0x04000DCB RID: 3531
        internal IntPtr intptr_0;

        // Token: 0x04000DCC RID: 3532
        internal ushort ushort_0;

        // Token: 0x04000DCD RID: 3533
        internal short short_0;

        // Token: 0x04000DCE RID: 3534
        internal uint uint_0;

        // Token: 0x04000DCF RID: 3535
        internal IntPtr intptr_1;
    }

}
