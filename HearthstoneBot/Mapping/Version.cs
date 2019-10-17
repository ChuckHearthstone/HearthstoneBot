using System;
using HearthstoneBot.Game;

namespace HearthstoneBot.Mapping
{
    class Version : MonoClass
    {
        public Version(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x0600969C RID: 38556 RVA: 0x0007F31C File Offset: 0x0007D51C
        public Version(IntPtr address) : this(address, "Version")
        {
        }

        public static int version
        {
            get
            {
                return smethod_6<int>(TritonHs.MainAssemblyPath, "", "Version", "version");
            }
        }

        // Token: 0x1700388C RID: 14476
        // (get) Token: 0x0600969E RID: 38558 RVA: 0x0007F345 File Offset: 0x0007D545
        public static int clientChangelist
        {
            get
            {
                return smethod_6<int>(TritonHs.MainAssemblyPath, "", "Version", "clientChangelist");
            }
        }
    }
}
