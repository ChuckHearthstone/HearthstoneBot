using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    class Class52
    {
        private Class53 class53_0 = new Class53();

        private Class53 class53_1 = new Class53();

        private Class54 class54_0 = new Class54();

        private Class61 class61_0 = new Class61();

        private uint uint_0;

        private uint uint_1;

        private uint uint_2;

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
    }
}
