using System;
using System.Windows.Forms;

namespace HearthstoneBot.Common
{
    [Flags]
    public enum ModifierKeys
    {
        // Token: 0x04000B38 RID: 2872
        Alt = 1,
        // Token: 0x04000B39 RID: 2873
        Control = 2,
        // Token: 0x04000B3A RID: 2874
        Shift = 4,
        // Token: 0x04000B3B RID: 2875
        Win = 8,
        // Token: 0x04000B3C RID: 2876
        NoRepeat = 16384
    }

    class Hotkey
    {
        internal bool Boolean_0;
        internal Hotkey(string name, Keys key, ModifierKeys modifierKeys, int id, Action<Hotkey> callback)
        {
            this.Name = name;
            this.Key = key;
            this.ModifierKeys = modifierKeys;
            this.Id = id;
            this.Callback = callback;
        }

        private string Name;

        public Keys Key;
        public  ModifierKeys ModifierKeys;
        public int Id;
        public Action<Hotkey> Callback;
    }
}
