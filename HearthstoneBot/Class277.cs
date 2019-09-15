using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HearthstoneBot
{
    class Class277 : IEnumerable<IntPtr>,IEnumerator<IntPtr>
    {
        private int int_0;

        // Token: 0x04000E01 RID: 3585
        private int int_1;

        public Class276 class276_0;
        public IntPtr intptr_1;
        public IntPtr intptr_2;
        private IntPtr intptr_0;

        public Class277(int tempState)
        {
            this.int_0 = tempState;
            this.int_1 = Environment.CurrentManagedThreadId;
        }

        public IEnumerator<IntPtr> GetEnumerator()
        {
            Class277 @class;
            if (this.int_0 == -2 && this.int_1 == Environment.CurrentManagedThreadId)
            {
                this.int_0 = 0;
                @class = this;
            }
            else
            {
                @class = new Class277(0);
                @class.class276_0 = this.class276_0;
            }
            @class.intptr_1 = this.intptr_2;
            return @class;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
         
        }

        // Token: 0x04000E05 RID: 3589
        private int int_2;

        // Token: 0x04000E06 RID: 3590
        private int int_3;
        public bool MoveNext()
        {

            int num = this.int_0;
            if (num != 0)
            {
                if (num != 1)
                {
                    return false;
                }
                this.int_0 = -1;
                int num2 = this.int_2;
                this.int_2 = num2 + 1;
            }
            else
            {
                this.int_0 = -1;
                this.int_3 = this.class276_0.method_17<int>(this.class276_0.intptr_14, new object[]
                {
                    this.intptr_1,
                    2
                });
                this.int_2 = 1;
            }
            if (this.int_2 >= this.int_3 + 1)
            {
                return false;
            }

            var memory = class276_0.externalProcessMemory_0;
            this.intptr_0 = memory.CallInjected<IntPtr>(class276_0.intptr_1, CallingConvention.Cdecl, new object[]
            {
                this.intptr_1,
                this.int_2 | 33554432
            });
            this.int_0 = 1;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IntPtr Current => this.intptr_0;

        object IEnumerator.Current => Current;
    }
}
