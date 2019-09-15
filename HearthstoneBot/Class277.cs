using System;
using System.Collections;
using System.Collections.Generic;

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

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IntPtr Current => this.intptr_0;

        object IEnumerator.Current => Current;
    }
}
