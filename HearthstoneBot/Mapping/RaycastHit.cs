using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Mapping
{
    public struct Vector2
    {
        // Token: 0x04001DE2 RID: 7650
        public float X;

        // Token: 0x04001DE3 RID: 7651
        public float Y;
    }

    public struct RaycastHit
    {
        // Token: 0x04001DE9 RID: 7657
        public Vector3 Point;

        // Token: 0x04001DEA RID: 7658
        public Vector3 Normal;

        // Token: 0x04001DEB RID: 7659
        public int FaceID;

        // Token: 0x04001DEC RID: 7660
        public float Distance;

        // Token: 0x04001DED RID: 7661
        public Vector2 UV;

        // Token: 0x04001DEE RID: 7662
        public IntPtr Collider;
    }
}
