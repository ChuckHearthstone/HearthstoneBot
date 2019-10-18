using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneBot.Enums;

namespace HearthstoneBot.Mapping
{
    public struct Bounds
    {
        // Token: 0x04001DD5 RID: 7637
        public Vector3 m_Center;

        // Token: 0x04001DD6 RID: 7638
        public Vector3 m_Extents;
    }

    public class Renderer : Component
    {
        // Token: 0x06009A18 RID: 39448 RVA: 0x00082818 File Offset: 0x00080A18
        public Renderer(IntPtr address) : base(address, "Renderer")
        {
        }

        // Token: 0x06009A19 RID: 39449 RVA: 0x0001345A File Offset: 0x0001165A
        public Renderer(IntPtr address, string className) : base(address, className)
        {
        }

        public Bounds Bounds
        {
            get
            {
                return base.method_11<Bounds>("get_bounds", Array.Empty<object>());
            }
        }
    }

    public class GameObject : UnityObject
    {
        public GameObject(IntPtr address) : base(address, "GameObject")
        {
        }

        public Renderer Renderer
        {
            get
            {
                Component component = this.GetComponent<Renderer>();
                if (component == null)
                {
                    return null;
                }
                return new Renderer(component.Address);
            }
        }
        public Component GetComponent(string type)
        {
            return base.method_15<Component>("GetComponent", new Enum20[]
            {
                Enum20.String
            }, new object[]
            {
                type
            });
        }

        // Token: 0x06009A0A RID: 39434 RVA: 0x00082771 File Offset: 0x00080971
        public Component GetComponent<T>() where T : Component
        {
            return this.GetComponent(typeof(T).Name);
        }
    }

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
