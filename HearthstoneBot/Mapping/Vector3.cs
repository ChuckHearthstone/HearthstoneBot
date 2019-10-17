using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Mapping
{
    public struct Vector3
    {
        // Token: 0x06009A30 RID: 39472 RVA: 0x00082A33 File Offset: 0x00080C33
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", this.X, this.Y, this.Z);
        }

        // Token: 0x06009A31 RID: 39473 RVA: 0x00082A60 File Offset: 0x00080C60
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Token: 0x06009A32 RID: 39474 RVA: 0x00082A77 File Offset: 0x00080C77
        public override bool Equals(object obj)
        {
            return obj is Vector3 && this == (Vector3)obj;
        }

        // Token: 0x06009A33 RID: 39475 RVA: 0x00082A94 File Offset: 0x00080C94
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
        }

        // Token: 0x06009A34 RID: 39476 RVA: 0x00082AB9 File Offset: 0x00080CB9
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X.Equals(rhs.X) && lhs.Y.Equals(rhs.Y) && lhs.Z.Equals(rhs.Z);
        }

        // Token: 0x06009A35 RID: 39477 RVA: 0x00082AF7 File Offset: 0x00080CF7
        public static bool operator !=(Vector3 x, Vector3 y)
        {
            return !(x == y);
        }

        // Token: 0x04001DD7 RID: 7639
        public float X;

        // Token: 0x04001DD8 RID: 7640
        public float Y;

        // Token: 0x04001DD9 RID: 7641
        public float Z;
    }
}
