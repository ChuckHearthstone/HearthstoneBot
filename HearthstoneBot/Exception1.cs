using System;

namespace HearthstoneBot
{
    internal class Exception1 : ApplicationException
    {
        public Exception1() : base("Invalid Parameter")
        {
        }
    }
}
