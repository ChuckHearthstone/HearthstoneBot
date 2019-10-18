using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Game
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WindowInfoWin32
    {
        // Token: 0x04000C76 RID: 3190
        public uint Size;

        // Token: 0x04000C77 RID: 3191
        public RectWin32 Window;

        // Token: 0x04000C78 RID: 3192
        public RectWin32 Client;

        // Token: 0x04000C79 RID: 3193
        public uint Style;

        // Token: 0x04000C7A RID: 3194
        public uint ExStyle;

        // Token: 0x04000C7B RID: 3195
        public uint WindowStatus;

        // Token: 0x04000C7C RID: 3196
        public uint WindowBordersX;

        // Token: 0x04000C7D RID: 3197
        public uint WindowBordersY;

        // Token: 0x04000C7E RID: 3198
        public ushort WindowType;

        // Token: 0x04000C7F RID: 3199
        public ushort CreatorVersion;
    }
}
