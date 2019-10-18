using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneBot.Game;

namespace HearthstoneBot.Mapping
{
    public class Screen : MonoClass
    {
        // Token: 0x06009A27 RID: 39463 RVA: 0x0008297A File Offset: 0x00080B7A
        public Screen(IntPtr address) : base(address, "Screen")
        {
        }

        // Token: 0x170039B3 RID: 14771
        // (get) Token: 0x06009A28 RID: 39464 RVA: 0x00082988 File Offset: 0x00080B88
        public static int Width
        {
            get
            {
                return MonoClass.smethod_14<int>(TritonHs.UnityEngineAssemblyPath, "UnityEngine", "Screen", "get_width", Array.Empty<object>());
            }
        }

        // Token: 0x170039B4 RID: 14772
        // (get) Token: 0x06009A29 RID: 39465 RVA: 0x000829A8 File Offset: 0x00080BA8
        public static int Height
        {
            get
            {
                return MonoClass.smethod_14<int>(TritonHs.UnityEngineAssemblyPath, "UnityEngine", "Screen", "get_height", Array.Empty<object>());
            }
        }
    }
}
