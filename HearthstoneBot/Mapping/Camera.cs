using System;
using HearthstoneBot.Enums;
using HearthstoneBot.Game;

namespace HearthstoneBot.Mapping
{

    public class UnityObject : MonoClass
    {
        public UnityObject(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06001B1D RID: 6941 RVA: 0x0001352F File Offset: 0x0001172F
        public UnityObject(IntPtr address) : base(address, "Object")
        {
        }
    }

    public class Component : UnityObject
    {
        // Token: 0x06001B13 RID: 6931 RVA: 0x00013484 File Offset: 0x00011684
        public Component(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06001B14 RID: 6932 RVA: 0x0001348E File Offset: 0x0001168E
        public Component(IntPtr address) : base(address, "Component")
        {
        }
    }

    public class Behaviour : Component
    {
        // Token: 0x06001B10 RID: 6928 RVA: 0x0001345A File Offset: 0x0001165A
        public Behaviour(IntPtr address, string className) : base(address, className)
        {
        }

        // Token: 0x06001B11 RID: 6929 RVA: 0x00013464 File Offset: 0x00011664
        public Behaviour(IntPtr address) : base(address, "Behaviour")
        {
        }
    }

    public class Camera : Behaviour
    {
        public Camera(IntPtr address) : base(address, "Camera")
        {
        }

        public static Camera Main
        {
            get
            {
                return MonoClass.smethod_15<Camera>(TritonHs.UnityEngineAssemblyPath, "UnityEngine", "Camera",
                    "get_main", Array.Empty<object>());
            }
        }

        public Vector3 WorldToScreenPoint(Vector3 position)
        {
            return base.method_10<Vector3>("WorldToScreenPoint", new Enum20[]
            {
                Enum20.ValueType
            }, new object[]
            {
                position
            });
        }
    }
}
