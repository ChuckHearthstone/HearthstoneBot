using System.ServiceModel;

namespace HearthstoneBot.Auth
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
