using System;
using HearthstoneBot.Game;

namespace HearthstoneBot.Mapping
{
    public class MonoBehaviour : Behaviour
    {
        // Token: 0x06001B0E RID: 6926 RVA: 0x00013442 File Offset: 0x00011642
        public MonoBehaviour(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06001B0F RID: 6927 RVA: 0x0001344C File Offset: 0x0001164C
        public MonoBehaviour(IntPtr address) : base(address, "MonoBehaviour")
        {
        }
    }

    public class PegUI : MonoBehaviour
    {
        // Token: 0x060074BC RID: 29884 RVA: 0x00013318 File Offset: 0x00011518
        public PegUI(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x060074BD RID: 29885 RVA: 0x00064C1D File Offset: 0x00062E1D
        public PegUI(IntPtr address) : this(address, "PegUI")
        {
        }

        public static PegUI Get()
        {
            return MonoClass.smethod_15<PegUI>(TritonHs.MainAssemblyPath, "", "PegUI", "Get", Array.Empty<object>());
        }

        public void OnAppFocusChanged(bool focus, object userData)
        {
            base.method_8("OnAppFocusChanged", new object[]
            {
                focus,
                userData
            });
        }

    }
}
