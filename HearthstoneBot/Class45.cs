using System;
using System.ServiceModel;

namespace HearthstoneBot
{
    class Class45
    {
        public static T smethod_2<T>(Func<Class40, T> func_0)
        {
            T result;
            try
            {
                Class40 @class = new Class40();
                bool flag = false;
                try
                {
                    T t = func_0(@class);
                    @class.method_2();
                    flag = true;
                    result = t;
                }
                catch (EndpointNotFoundException)
                {
                    @class.method_1();
                    result = smethod_2(func_0);
                }
                catch (CommunicationException)
                {
                    @class.method_1();
                    result = smethod_2(func_0);
                }
                catch (TimeoutException)
                {
                    @class.method_1();
                    result = smethod_2(func_0);
                }
                catch (Exception)
                {
                    @class.method_1();
                    throw;
                }
                finally
                {
                    if (!flag && @class.CommunicationState_0 != CommunicationState.Closed)
                    {
                        @class.method_1();
                    }
                }
            }
            catch
            {
                result = default;
            }
            return result;
        }
    }
}
