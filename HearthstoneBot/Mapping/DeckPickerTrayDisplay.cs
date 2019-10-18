using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneBot.Game;

namespace HearthstoneBot.Mapping
{
    public class DeckPickerTrayDisplay : MonoBehaviour
    {
        // Token: 0x0600460F RID: 17935 RVA: 0x00013318 File Offset: 0x00011518
        public DeckPickerTrayDisplay(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06004610 RID: 17936 RVA: 0x0003B8C1 File Offset: 0x00039AC1
        public DeckPickerTrayDisplay(IntPtr address) : this(address, "DeckPickerTrayDisplay")
        {
        }

        public static DeckPickerTrayDisplay Get()
        {
            return MonoClass.smethod_15<DeckPickerTrayDisplay>(TritonHs.MainAssemblyPath, "", "DeckPickerTrayDisplay", "Get", Array.Empty<object>());
        }

        public PlayButton m_playButton
        {
            get
            {
                return base.method_3<PlayButton>("m_playButton");
            }
        }
    }
}
