using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    internal interface Interface1
    {
        // Token: 0x060003F9 RID: 1017
        void imethod_0(long long_0, long long_1);
    }

    class Class52
    {
        private Class53 class53_0 = new Class53();

        private Class53 class53_1 = new Class53();

        private Class54 class54_0 = new Class54();

        private Class61 class61_0 = new Class61();

        private Class63 class63_0 = new Class63();

        private uint uint_0;

        private uint uint_1;

        private uint uint_2;

        public void imethod_0(Stream stream_0, Stream stream_1, long long_0, long long_1, Interface1 interface1_0)
        {
            this.method_3(stream_0, stream_1);
            Struct8 @struct = default(Struct8);
            @struct.method_0();
            uint num = 0u;
            uint num2 = 0u;
            uint num3 = 0u;
            uint num4 = 0u;
            ulong num5 = 0UL;
            if (0L < long_1)
            {
                if (this.struct12_0[(int)((int)@struct.uint_0 << 4)].method_2(this.class63_0) != 0u)
                {
                    throw new Exception0();
                }
                @struct.method_1();
                byte byte_ = this.class54_0.method_3(this.class63_0, 0u, 0);
                this.class61_0.method_6(byte_);
                num5 += 1UL;
            }
            while (num5 < (ulong)long_1)
            {
                uint num6 = (uint)num5 & this.uint_2;
                if (this.struct12_0[(int)((@struct.uint_0 << 4) + num6)].method_2(this.class63_0) == 0u)
                {
                    byte byte_2 = this.class61_0.method_7(0u);
                    byte byte_3;
                    if (!@struct.method_5())
                    {
                        byte_3 = this.class54_0.method_4(this.class63_0, (uint)num5, byte_2, this.class61_0.method_7(num));
                    }
                    else
                    {
                        byte_3 = this.class54_0.method_3(this.class63_0, (uint)num5, byte_2);
                    }
                    this.class61_0.method_6(byte_3);
                    @struct.method_1();
                    num5 += 1UL;
                }
                else
                {
                    uint num8;
                    if (this.struct12_1[(int)@struct.uint_0].method_2(this.class63_0) == 1u)
                    {
                        if (this.struct12_2[(int)@struct.uint_0].method_2(this.class63_0) == 0u)
                        {
                            if (this.struct12_5[(int)((@struct.uint_0 << 4) + num6)].method_2(this.class63_0) == 0u)
                            {
                                @struct.method_4();
                                this.class61_0.method_6(this.class61_0.method_7(num));
                                num5 += 1UL;
                                continue;
                            }
                        }
                        else
                        {
                            uint num7;
                            if (this.struct12_3[(int)@struct.uint_0].method_2(this.class63_0) == 0u)
                            {
                                num7 = num2;
                            }
                            else
                            {
                                if (this.struct12_4[(int)@struct.uint_0].method_2(this.class63_0) == 0u)
                                {
                                    num7 = num3;
                                }
                                else
                                {
                                    num7 = num4;
                                    num4 = num3;
                                }
                                num3 = num2;
                            }
                            num2 = num;
                            num = num7;
                        }
                        num8 = this.class53_1.method_2(this.class63_0, num6) + 2u;
                        @struct.method_3();
                    }
                    else
                    {
                        num4 = num3;
                        num3 = num2;
                        num2 = num;
                        num8 = 2u + this.class53_0.method_2(this.class63_0, num6);
                        @struct.method_2();
                        uint num9 = this.struct14_0[(int)Class51.smethod_0(num8)].method_1(this.class63_0);
                        if (num9 >= 4u)
                        {
                            int num10 = (int)((num9 >> 1) - 1u);
                            num = (2u | (num9 & 1u)) << num10;
                            if (num9 < 14u)
                            {
                                num += Struct14.smethod_0(this.struct12_6, num - num9 - 1u, this.class63_0, num10);
                            }
                            else
                            {
                                num += this.class63_0.method_7(num10 - 4) << 4;
                                num += this.struct14_1.method_2(this.class63_0);
                            }
                        }
                        else
                        {
                            num = num9;
                        }
                    }
                    if ((ulong)num < num5 && num < this.uint_1)
                    {
                        this.class61_0.method_5(num, num8);
                        num5 += (ulong)num8;
                    }
                    else
                    {
                        if (num != 4294967295u)
                        {
                            throw new Exception0();
                        }
                    IL_343:
                        this.class61_0.method_4();
                        this.class61_0.method_3();
                        this.class63_0.method_1();
                        return;
                    }
                }
            }
            goto IL_343;
        }

        public void imethod_1(byte[] byte_0)
        {
            if (byte_0.Length < 5)
            {
                throw new Exception1();
            }
            int int_ = (int)(byte_0[0] % 9);
            var b = byte_0[0] / 9;
            int int_2 = (int)(b % 5);
            int num = (int)(b / 5);
            if (num > 4)
            {
                throw new Exception1();
            }
            uint num2 = 0u;
            for (int i = 0; i < 4; i++)
            {
                num2 += (uint)((uint)byte_0[1 + i] << i * 8);
            }
            this.method_0(num2);
            this.method_1(int_2, int_);
            this.method_2(num);
        }

        private void method_0(uint uint_3)
        {
            if (this.uint_0 != uint_3)
            {
                this.uint_0 = uint_3;
                this.uint_1 = Math.Max(this.uint_0, 1u);
                uint uint_4 = Math.Max(this.uint_1, 4096u);
                this.class61_0.method_0(uint_4);
            }
        }

        private void method_1(int int_0, int int_1)
        {
            if (int_0 > 8)
            {
                throw new Exception1();
            }
            if (int_1 > 8)
            {
                throw new Exception1();
            }
            this.class54_0.method_0(int_0, int_1);
        }

        private void method_2(int int_0)
        {
            if (int_0 > 4)
            {
                throw new Exception1();
            }
            uint num = 1u << int_0;
            this.class53_0.method_0(num);
            this.class53_1.method_0(num);
            this.uint_2 = num - 1u;
        }

        // Token: 0x040002B8 RID: 696
        private Struct12[] struct12_0 = new Struct12[192];

        // Token: 0x040002B9 RID: 697
        private Struct12[] struct12_1 = new Struct12[12];

        // Token: 0x040002BA RID: 698
        private Struct12[] struct12_2 = new Struct12[12];

        // Token: 0x040002BB RID: 699
        private Struct12[] struct12_3 = new Struct12[12];

        // Token: 0x040002BC RID: 700
        private Struct12[] struct12_4 = new Struct12[12];

        // Token: 0x040002BD RID: 701
        private Struct12[] struct12_5 = new Struct12[192];
        private Struct14[] struct14_0 = new Struct14[4];
        private Struct12[] struct12_6 = new Struct12[114];
        private Struct14 struct14_1 = new Struct14(4);

        private void method_3(Stream stream_0, Stream stream_1)
        {
            this.class63_0.method_0(stream_0);
            this.class61_0.method_2(stream_1);
            for (uint num = 0u; num < 12u; num += 1u)
            {
                for (uint num2 = 0u; num2 <= this.uint_2; num2 += 1u)
                {
                    uint num3 = (num << 4) + num2;
                    this.struct12_0[(int)num3].method_1();
                    this.struct12_5[(int)num3].method_1();
                }
                this.struct12_1[(int)num].method_1();
                this.struct12_2[(int)num].method_1();
                this.struct12_3[(int)num].method_1();
                this.struct12_4[(int)num].method_1();
            }
            this.class54_0.method_1();
            for (uint num = 0u; num < 4u; num += 1u)
            {
                this.struct14_0[(int)num].method_0();
            }
            for (uint num = 0u; num < 114u; num += 1u)
            {
                this.struct12_6[(int)num].method_1();
            }
            this.class53_0.method_1();
            this.class53_1.method_1();
            this.struct14_1.method_0();
        }

    }
}
