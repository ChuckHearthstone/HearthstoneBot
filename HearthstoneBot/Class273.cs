using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HearthstoneBot.Enums;

namespace HearthstoneBot
{
    public partial class MonoClass
    {
        public class Class273
        {
            // Token: 0x060019FD RID: 6653 RVA: 0x00012789 File Offset: 0x00010989
            public Class273(string name, IntPtr address, Enum20[] parameters)
            {
                this.Name = name;
                this.IntPtr_0 = address;
                this.Enum20_0 = parameters;
            }

            // Token: 0x170004D2 RID: 1234
            // (get) Token: 0x060019FE RID: 6654 RVA: 0x000127A6 File Offset: 0x000109A6
            // (set) Token: 0x060019FF RID: 6655 RVA: 0x000127AE File Offset: 0x000109AE
            public string Name
            {
                [CompilerGenerated]
                get
                {
                    return this.string_0;
                }
                [CompilerGenerated]
                internal set
                {
                    this.string_0 = value;
                }
            }

            // Token: 0x170004D3 RID: 1235
            // (get) Token: 0x06001A00 RID: 6656 RVA: 0x000127B7 File Offset: 0x000109B7
            // (set) Token: 0x06001A01 RID: 6657 RVA: 0x000127BF File Offset: 0x000109BF
            public Enum20[] Enum20_0
            {
                [CompilerGenerated]
                get
                {
                    return this.enum20_0;
                }
                [CompilerGenerated]
                set
                {
                    this.enum20_0 = value;
                }
            }

            // Token: 0x170004D4 RID: 1236
            // (get) Token: 0x06001A02 RID: 6658 RVA: 0x000127C8 File Offset: 0x000109C8
            // (set) Token: 0x06001A03 RID: 6659 RVA: 0x000127D0 File Offset: 0x000109D0
            public IntPtr IntPtr_0
            {
                [CompilerGenerated]
                get
                {
                    return this.intptr_0;
                }
                [CompilerGenerated]
                set
                {
                    this.intptr_0 = value;
                }
            }

            // Token: 0x06001A04 RID: 6660 RVA: 0x000DCB60 File Offset: 0x000DAD60
            public bool method_0(string string_1, params Enum20[] enum20_1)
            {
                if (this.Name != string_1)
                {
                    return false;
                }
                if (enum20_1 == null)
                {
                    return this.Enum20_0 == null || this.Enum20_0.Length == 0;
                }
                if (enum20_1.Length != this.Enum20_0.Length)
                {
                    return false;
                }
                for (int i = 0; i < enum20_1.Length; i++)
                {
                    if (enum20_1[i] != this.Enum20_0[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            // Token: 0x04000D42 RID: 3394
            [CompilerGenerated]
            private string string_0;

            // Token: 0x04000D43 RID: 3395
            [CompilerGenerated]
            private Enum20[] enum20_0;

            // Token: 0x04000D44 RID: 3396
            [CompilerGenerated]
            private IntPtr intptr_0;
        }
    }
}
