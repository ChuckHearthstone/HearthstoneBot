using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace HearthstoneBot.Common
{
    public partial class TypeLoader<T> : List<T>
    {
        private readonly Assembly assembly_0;
        private Func<object[]> func_0;
        public TypeLoader(Assembly asm = null, Func<object[]> constructorArguments = null)
        {
            this.assembly_0 = asm;
            if (constructorArguments == null)
            {
                this.func_0 = new Func<object[]>(Class236.Instance.method_0);
            }
            else
            {
                this.func_0 = constructorArguments;
            }
            this.Reload();
        }

        public void Reload()
        {
            base.Clear();
            if (this.assembly_0 == null)
            {
                this.method_0(AppDomain.CurrentDomain.GetAssemblies());
                return;
            }
            this.method_0(new Assembly[]
            {
                this.assembly_0
            });
        }

        private void method_0(params Assembly[] assembly_1)
        {
            using (IEnumerator<Type> enumerator = assembly_1.SelectMany(Class236.Instance.method_1).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Class237 @class = new Class237();
                    @class.type_0 = enumerator.Current;
                    if (!this.Any(new Func<T, bool>(@class.method_0)))
                    {
                        base.Add((T) ((object) Activator.CreateInstance(@class.type_0,
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.CreateInstance, null, this.func_0(), CultureInfo.InvariantCulture)));
                    }
                }
            }
        }
    }
}
