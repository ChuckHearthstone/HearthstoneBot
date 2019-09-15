using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot
{
    public interface IA
    {
        d0 Do(byte b, object[] args);
    }

    class AClient : ClientBase<IA>, IA
    {
        public d0 Do(byte b, object[] args)
        {
            return base.Channel.Do(b, args);
        }
    }
}
