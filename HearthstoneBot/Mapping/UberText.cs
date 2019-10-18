using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Mapping
{
    public class UberText : MonoBehaviour
    {
        // Token: 0x06009329 RID: 37673 RVA: 0x00013318 File Offset: 0x00011518
        public UberText(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x0600932A RID: 37674 RVA: 0x0007C196 File Offset: 0x0007A396
        public UberText(IntPtr address) : this(address, "UberText")
        {
        }

        public GameObject m_TextMeshGameObject
        {
            get
            {
                return base.method_3<GameObject>("m_TextMeshGameObject");
            }
        }
    }
}
