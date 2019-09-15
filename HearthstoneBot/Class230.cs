using System.Reflection;

namespace HearthstoneBot
{
    class Class230
    {
        public string string_0;

        internal bool method_0(Assembly assembly_0)
        {
            return assembly_0.GetName().Name.Contains(this.string_0.Replace(".dll", string.Empty));
        }
    }
}
