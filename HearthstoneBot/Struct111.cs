using System;
using System.Runtime.InteropServices;

namespace HearthstoneBot
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct Struct111
    {
        // Token: 0x1700050D RID: 1293
        // (get) Token: 0x06001ABF RID: 6847 RVA: 0x00012FF6 File Offset: 0x000111F6
        // (set) Token: 0x06001AC0 RID: 6848 RVA: 0x00013000 File Offset: 0x00011200
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

        // Token: 0x1700050E RID: 1294
        // (get) Token: 0x06001AC1 RID: 6849 RVA: 0x00013010 File Offset: 0x00011210
        internal uint UInt32_1
        {
            get
            {
                return (this.uint_0 & 2u) / 2u;
            }
        }

        // Token: 0x1700050F RID: 1295
        // (get) Token: 0x06001AC2 RID: 6850 RVA: 0x0001301C File Offset: 0x0001121C
        internal uint UInt32_2
        {
            get
            {
                return (this.uint_0 & 4u) / 4u;
            }
        }

        // Token: 0x17000510 RID: 1296
        // (get) Token: 0x06001AC3 RID: 6851 RVA: 0x00013028 File Offset: 0x00011228
        internal uint UInt32_3
        {
            get
            {
                return (this.uint_0 & 8u) / 8u;
            }
        }

        // Token: 0x17000511 RID: 1297
        // (get) Token: 0x06001AC4 RID: 6852 RVA: 0x00013034 File Offset: 0x00011234
        internal uint UInt32_4
        {
            get
            {
                return (this.uint_0 & 16u) / 16u;
            }
        }

        // Token: 0x17000512 RID: 1298
        // (get) Token: 0x06001AC5 RID: 6853 RVA: 0x00013042 File Offset: 0x00011242
        internal uint UInt32_5
        {
            get
            {
                return (this.uint_0 & 32u) / 32u;
            }
        }

        // Token: 0x17000513 RID: 1299
        // (get) Token: 0x06001AC6 RID: 6854 RVA: 0x00013050 File Offset: 0x00011250
        internal uint UInt32_6
        {
            get
            {
                return (this.uint_0 & 64u) / 64u;
            }
        }

        // Token: 0x17000514 RID: 1300
        // (get) Token: 0x06001AC7 RID: 6855 RVA: 0x0001305E File Offset: 0x0001125E
        internal uint UInt32_7
        {
            get
            {
                return (this.uint_0 & 128u) / 128u;
            }
        }

        // Token: 0x17000515 RID: 1301
        // (get) Token: 0x06001AC8 RID: 6856 RVA: 0x00013072 File Offset: 0x00011272
        internal uint UInt32_8
        {
            get
            {
                return this.uint_1 & 15u;
            }
        }

        // Token: 0x17000516 RID: 1302
        // (get) Token: 0x06001AC9 RID: 6857 RVA: 0x0001307D File Offset: 0x0001127D
        internal uint UInt32_9
        {
            get
            {
                return (this.uint_1 & 16u) / 16u;
            }
        }

        // Token: 0x17000517 RID: 1303
        // (get) Token: 0x06001ACA RID: 6858 RVA: 0x0001308B File Offset: 0x0001128B
        internal uint UInt32_10
        {
            get
            {
                return (this.uint_1 & 32u) / 32u;
            }
        }

        // Token: 0x17000518 RID: 1304
        // (get) Token: 0x06001ACB RID: 6859 RVA: 0x00013099 File Offset: 0x00011299
        internal uint UInt32_11
        {
            get
            {
                return (this.uint_1 & 64u) / 64u;
            }
        }

        // Token: 0x17000519 RID: 1305
        // (get) Token: 0x06001ACC RID: 6860 RVA: 0x000130A7 File Offset: 0x000112A7
        internal uint UInt32_12
        {
            get
            {
                return (this.uint_1 & 128u) / 128u;
            }
        }

        // Token: 0x1700051A RID: 1306
        // (get) Token: 0x06001ACD RID: 6861 RVA: 0x000130BB File Offset: 0x000112BB
        internal uint UInt32_13
        {
            get
            {
                return (this.uint_1 & 256u) / 256u;
            }
        }

        // Token: 0x1700051B RID: 1307
        // (get) Token: 0x06001ACE RID: 6862 RVA: 0x000130CF File Offset: 0x000112CF
        internal uint UInt32_14
        {
            get
            {
                return (this.uint_1 & 512u) / 512u;
            }
        }

        // Token: 0x1700051C RID: 1308
        // (get) Token: 0x06001ACF RID: 6863 RVA: 0x000130E3 File Offset: 0x000112E3
        internal uint UInt32_15
        {
            get
            {
                return (this.uint_1 & 1024u) / 1024u;
            }
        }

        // Token: 0x1700051D RID: 1309
        // (get) Token: 0x06001AD0 RID: 6864 RVA: 0x000130F7 File Offset: 0x000112F7
        internal uint UInt32_16
        {
            get
            {
                return (this.uint_1 & 2048u) / 2048u;
            }
        }

        // Token: 0x1700051E RID: 1310
        // (get) Token: 0x06001AD1 RID: 6865 RVA: 0x0001310B File Offset: 0x0001130B
        internal uint UInt32_17
        {
            get
            {
                return (this.uint_1 & 4096u) / 4096u;
            }
        }

        // Token: 0x1700051F RID: 1311
        // (get) Token: 0x06001AD2 RID: 6866 RVA: 0x0001311F File Offset: 0x0001131F
        internal uint UInt32_18
        {
            get
            {
                return (this.uint_1 & 8192u) / 8192u;
            }
        }

        // Token: 0x17000520 RID: 1312
        // (get) Token: 0x06001AD3 RID: 6867 RVA: 0x00013133 File Offset: 0x00011333
        internal uint UInt32_19
        {
            get
            {
                return (this.uint_1 & 16384u) / 16384u;
            }
        }

        // Token: 0x17000521 RID: 1313
        // (get) Token: 0x06001AD4 RID: 6868 RVA: 0x00013147 File Offset: 0x00011347
        internal uint UInt32_20
        {
            get
            {
                return (this.uint_1 & 32768u) / 32768u;
            }
        }

        // Token: 0x17000522 RID: 1314
        // (get) Token: 0x06001AD5 RID: 6869 RVA: 0x0001315B File Offset: 0x0001135B
        internal uint UInt32_21
        {
            get
            {
                return (this.uint_1 & 65536u) / 65536u;
            }
        }

        // Token: 0x17000523 RID: 1315
        // (get) Token: 0x06001AD6 RID: 6870 RVA: 0x0001316F File Offset: 0x0001136F
        internal uint UInt32_22
        {
            get
            {
                return (this.uint_1 & 131072u) / 131072u;
            }
        }

        // Token: 0x17000524 RID: 1316
        // (get) Token: 0x06001AD7 RID: 6871 RVA: 0x00013183 File Offset: 0x00011383
        internal uint UInt32_23
        {
            get
            {
                return (this.uint_1 & 262144u) / 262144u;
            }
        }

        // Token: 0x17000525 RID: 1317
        // (get) Token: 0x06001AD8 RID: 6872 RVA: 0x00013197 File Offset: 0x00011397
        internal uint UInt32_24
        {
            get
            {
                return (this.uint_1 & 524288u) / 524288u;
            }
        }

        // Token: 0x17000526 RID: 1318
        // (get) Token: 0x06001AD9 RID: 6873 RVA: 0x000131AB File Offset: 0x000113AB
        internal uint UInt32_25
        {
            get
            {
                return (this.uint_1 & 1048576u) / 1048576u;
            }
        }

        // Token: 0x17000527 RID: 1319
        // (get) Token: 0x06001ADA RID: 6874 RVA: 0x000131BF File Offset: 0x000113BF
        internal uint UInt32_26
        {
            get
            {
                return (this.uint_1 & 2097152u) / 2097152u;
            }
        }

        // Token: 0x17000528 RID: 1320
        // (get) Token: 0x06001ADB RID: 6875 RVA: 0x000131D3 File Offset: 0x000113D3
        internal uint UInt32_27
        {
            get
            {
                return (this.uint_1 & 4194304u) / 4194304u;
            }
        }

        // Token: 0x04000DD3 RID: 3539
        internal IntPtr intptr_0;

        // Token: 0x04000DD4 RID: 3540
        internal IntPtr intptr_1;

        // Token: 0x04000DD5 RID: 3541
        internal IntPtr intptr_2;

        // Token: 0x04000DD6 RID: 3542
        internal ushort ushort_0;

        // Token: 0x04000DD7 RID: 3543
        internal byte byte_0;

        // Token: 0x04000DD8 RID: 3544
        internal int int_0;

        // Token: 0x04000DD9 RID: 3545
        private uint uint_0;

        // Token: 0x04000DDA RID: 3546
        internal byte byte_1;

        // Token: 0x04000DDB RID: 3547
        private readonly uint uint_1;

        // Token: 0x04000DDC RID: 3548
        internal byte byte_2;

        // Token: 0x04000DDD RID: 3549
        internal IntPtr intptr_3;

        // Token: 0x04000DDE RID: 3550
        internal IntPtr intptr_4;

        // Token: 0x04000DDF RID: 3551
        internal IntPtr intptr_5;

        // Token: 0x04000DE0 RID: 3552
        private readonly IntPtr intptr_6;

        // Token: 0x04000DE1 RID: 3553
        private readonly IntPtr intptr_7;

        // Token: 0x04000DE2 RID: 3554
        internal uint uint_2;

        // Token: 0x04000DE3 RID: 3555
        internal int int_1;

        // Token: 0x04000DE4 RID: 3556
        internal ushort ushort_1;

        // Token: 0x04000DE5 RID: 3557
        internal ushort ushort_2;

        // Token: 0x04000DE6 RID: 3558
        internal ushort ushort_3;

        // Token: 0x04000DE7 RID: 3559
        internal ushort ushort_4;

        // Token: 0x04000DE8 RID: 3560
        internal IntPtr intptr_8;

        // Token: 0x04000DE9 RID: 3561
        internal IntPtr intptr_9;

        // Token: 0x04000DEA RID: 3562
        internal IntPtr intptr_10;

        // Token: 0x04000DEB RID: 3563
        internal IntPtr intptr_11;

        // Token: 0x04000DEC RID: 3564
        internal int int_2;

        // Token: 0x04000DED RID: 3565
        internal uint uint_3;

        // Token: 0x04000DEE RID: 3566
        internal uint uint_4;

        // Token: 0x04000DEF RID: 3567
        internal uint uint_5;

        // Token: 0x04000DF0 RID: 3568
        internal uint uint_6;

        // Token: 0x04000DF1 RID: 3569
        internal uint uint_7;

        // Token: 0x04000DF2 RID: 3570
        internal uint uint_8;

        // Token: 0x04000DF3 RID: 3571
        internal IntPtr intptr_12;

        // Token: 0x04000DF4 RID: 3572
        internal IntPtr intptr_13;

        // Token: 0x04000DF5 RID: 3573
        internal IntPtr intptr_14;

        // Token: 0x04000DF6 RID: 3574
        internal Struct110 struct110_0;

        // Token: 0x04000DF7 RID: 3575
        internal Struct110 struct110_1;

        // Token: 0x04000DF8 RID: 3576
        internal IntPtr intptr_15;

        // Token: 0x04000DF9 RID: 3577
        internal IntPtr intptr_16;

        // Token: 0x04000DFA RID: 3578
        internal IntPtr intptr_17;

        // Token: 0x04000DFB RID: 3579
        internal IntPtr intptr_18;

        // Token: 0x04000DFC RID: 3580
        internal IntPtr intptr_19;

        // Token: 0x04000DFD RID: 3581
        internal IntPtr intptr_20;

        // Token: 0x04000DFE RID: 3582
        internal IntPtr intptr_21;
    }
}
