using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneBot.Game;

namespace HearthstoneBot.Mapping
{
    public class GameState : MonoClass
    {
        public GameState(IntPtr address, string className) : base(address, className)
        {
        }
        public GameState(IntPtr address) : this(address, "GameState")
        {
        }

        public static GameState Get()
        {
            return MonoClass.smethod_15<GameState>(TritonHs.MainAssemblyPath, "", "GameState", "Get", Array.Empty<object>());
        }

        public void Concede()
        {
            base.method_8("Concede", Array.Empty<object>());
        }
    }
}
