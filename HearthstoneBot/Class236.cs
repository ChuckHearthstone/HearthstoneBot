using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HearthstoneBot.Common
{
    public partial class TypeLoader<T> : List<T>
    {
        class Class236
        {
            public static readonly Class236 Instance = new Class236();

            internal object[] method_0()
            {
                return null;
            }

            internal IEnumerable<Type> method_1(Assembly assembly_0)
            {
                return assembly_0.GetTypes().Where(Class236.Instance.method_2);
            }

            internal bool method_2(Type type_0)
            {
                if (type_0.IsAbstract)
                {
                    return false;
                }

                if (!type_0.IsSubclassOf(typeof(T)))
                {
                    return type_0.GetInterfaces().Any(new Func<Type, bool>(Instance.method_3));
                }

                return true;
            }

            internal bool method_3(Type type_0)
            {
                return type_0 == typeof(T);
            }
        }
    }
}
