using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Mapping
{
    public class PegUIElement : MonoBehaviour
    {
        // Token: 0x06001EFD RID: 7933 RVA: 0x00013318 File Offset: 0x00011518
        public PegUIElement(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06001EFE RID: 7934 RVA: 0x0001783C File Offset: 0x00015A3C
        public PegUIElement(IntPtr address) : this(address, "PegUIElement")
        {
        }
    }

    public class PlayButton : PegUIElement
    {
        // Token: 0x06007541 RID: 30017 RVA: 0x00017702 File Offset: 0x00015902
        public PlayButton(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06007542 RID: 30018 RVA: 0x000654F3 File Offset: 0x000636F3
        public PlayButton(IntPtr address) : this(address, "PlayButton")
        {
        }

        public UberText m_newPlayButtonText
        {
            get
            {
                return base.method_3<UberText>("m_newPlayButtonText");
            }
        }
    }
}