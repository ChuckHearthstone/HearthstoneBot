using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    class Class54
    {
        private Struct9[] struct9_0;

        private int int_0;

        private int int_1;

        private uint uint_0;

        public void method_0(int int_2, int int_3)
        {
            if (this.struct9_0 != null && this.int_0 == int_3 && this.int_1 == int_2)
            {
                return;
            }
            this.int_1 = int_2;
            this.uint_0 = (1u << int_2) - 1u;
            this.int_0 = int_3;
            uint num = 1u << this.int_0 + this.int_1;
            this.struct9_0 = new Struct9[num];
            for (uint num2 = 0u; num2 < num; num2 += 1u)
            {
                this.struct9_0[(int)num2].method_0();
            }
        }

        public void method_1()
        {
            uint num = 1u << this.int_0 + this.int_1;
            for (uint num2 = 0u; num2 < num; num2 += 1u)
            {
                this.struct9_0[(int)num2].method_1();
            }
        }
    }
}
