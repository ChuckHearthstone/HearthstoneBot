using System.Runtime.InteropServices;

namespace HearthstoneBot.Game
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RectWin32
    {
        // Token: 0x06001911 RID: 6417 RVA: 0x00011FE2 File Offset: 0x000101E2
        public bool Within(int x, int y)
        {
            return x > this.Left && x < this.Right && y > this.Top && y < this.Bottom;
        }

        // Token: 0x06001912 RID: 6418 RVA: 0x000D8EF0 File Offset: 0x000D70F0
        public override string ToString()
        {
            return string.Format("Left: {0}, Top: {1}, Right: {2}, Bottom: {3}", new object[]
            {
                this.Left,
                this.Top,
                this.Right,
                this.Bottom
            });
        }

        // Token: 0x04000C80 RID: 3200
        public int Left;

        // Token: 0x04000C81 RID: 3201
        public int Top;

        // Token: 0x04000C82 RID: 3202
        public int Right;

        // Token: 0x04000C83 RID: 3203
        public int Bottom;
    }
}
