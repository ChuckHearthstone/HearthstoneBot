using System;
using System.ServiceModel;
using System.Text;
using HearthstoneBot.Auth;
using HearthstoneBot.Enums;

namespace HearthstoneBot
{
    class Class40
    {
        public static Region Region_0;

        public static string string_0;

        public string String_2
        {
            get
            {
                return string_0;
            }
            set
            {
                string_0 = value;
            }
        }

        public static string String_0 { get; set; }

        internal readonly AClient aclient_0;

        private static EventHandler eventHandler_1;

        public CommunicationState CommunicationState_0
        {
            get
            {
                return this.aclient_0.State;
            }
        }
        public void method_1()
        {
            this.aclient_0.Abort();
        }

        public void method_2()
        {
            this.aclient_0.Close();
        }

        private d0 method_3(Enum4 enum4_0, params object[] object_0)
        {
            return aclient_0.Do((byte)enum4_0, object_0);
        }

        private bool method_4()
        {
            return !string.IsNullOrEmpty(String_2);
        }

        public r0 method_6()
        {
            if (!this.method_4())
            {
                return new r0
                {
                    Success = false,
                    Body = "Invalid Session"
                };
            }
            d0 d = this.method_3(Enum4.Logout, new object[]
            {
                this.String_2
            });
            if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
            {
                EventHandler eventHandler = Class40.eventHandler_1;
                if (eventHandler != null)
                {
                    eventHandler(null, null);
                }
            }
            return d;
        }

        public d0 method_7(string string_4, string string_5, bool bool_0 = false)
        {
            if (!method_4())
            {
                return new d0
                {
                    Success = false,
                    Body = "Invalid Session"
                };
            }
            d0 d = method_3(Enum4.Offsets, String_2, string_4, string_5, bool_0);
            if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
            {
                EventHandler eventHandler = eventHandler_1;
                eventHandler?.Invoke(null, null);
            }
            if (d.Data != null && d.Data.Length != 0)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(String_2);
                byte[] bytes2 = Encoding.ASCII.GetBytes(String_2);
                Array.Reverse(bytes2);
                d.Data = Class41.smethod_5(d.Data, bytes, bytes2);
            }
            String_0 = d.Info;
            return d;
        }
    }
}
