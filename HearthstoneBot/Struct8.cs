using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    struct Struct8
    {
        public uint uint_0;

        public void method_0()
        {
            this.uint_0 = 0u;
        }

        public void method_1()
        {
            if (this.uint_0 < 4u)
            {
                this.uint_0 = 0u;
                return;
            }
            if (this.uint_0 < 10u)
            {
                this.uint_0 -= 3u;
                return;
            }
            this.uint_0 -= 6u;
        }
        public void method_2()
        {
            this.uint_0 = ((this.uint_0 < 7u) ? 7u : 10u);
        }

        public void method_3()
        {
            this.uint_0 = ((this.uint_0 < 7u) ? 8u : 11u);
        }

        public void method_4()
        {
            this.uint_0 = ((this.uint_0 < 7u) ? 9u : 11u);
        }

        public bool method_5()
        {
            return this.uint_0 < 7u;
        }
    }
}
