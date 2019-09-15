using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    class Class53
    {
        private uint uint_0;

        private Struct14[] struct14_0 = new Struct14[16];

        private Struct14[] struct14_1 = new Struct14[16];

        public void method_0(uint uint_1)
        {
            for (uint num = this.uint_0; num < uint_1; num += 1u)
            {
                this.struct14_0[(int)num] = new Struct14(3);
                this.struct14_1[(int)num] = new Struct14(3);
            }
            this.uint_0 = uint_1;
        }
    }
}
