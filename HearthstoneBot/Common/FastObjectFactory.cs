using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneBot.Common
{
    public static class FastObjectFactory
    {
        // Token: 0x0600158B RID: 5515 RVA: 0x0000F99B File Offset: 0x0000DB9B
        public static T CreateObjectInstance<T>(IntPtr ptr)
        {
            return (T)((object)FastObjectFactory.CreateObjectFactory<T>()(ptr));
        }

        // Token: 0x0600158C RID: 5516 RVA: 0x0000F9AD File Offset: 0x0000DBAD
        public static FastObjectFactory.CreateObject CreateObjectFactory<T>()
        {
            return FastObjectFactory.CreateObjectFactory(typeof(T));
        }

        // Token: 0x0600158D RID: 5517 RVA: 0x000CFDB0 File Offset: 0x000CDFB0
        public static FastObjectFactory.CreateObject CreateObjectFactory(Type t)
        {
            FastObjectFactory.CreateObject createObject = FastObjectFactory.hashtable_0[t] as FastObjectFactory.CreateObject;
            if (createObject == null)
            {
                object syncRoot = FastObjectFactory.hashtable_0.SyncRoot;
                FastObjectFactory.CreateObject result;
                lock (syncRoot)
                {
                    createObject = (FastObjectFactory.hashtable_0[t] as FastObjectFactory.CreateObject);
                    if (createObject != null)
                    {
                        result = createObject;
                    }
                    else
                    {
                        DynamicMethod dynamicMethod = new DynamicMethod("DM$OBJ_FACTORY_" + t.Name, t, new Type[]
                        {
                            typeof(IntPtr)
                        }, true);
                        ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
                        ilgenerator.Emit(OpCodes.Ldarg_0);
                        ConstructorInfo constructor = t.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[]
                        {
                            typeof(IntPtr)
                        }, null);
                        if (!(constructor == null))
                        {
                            ilgenerator.Emit(OpCodes.Newobj, constructor);
                            ilgenerator.Emit(OpCodes.Ret);
                            createObject = (FastObjectFactory.CreateObject)dynamicMethod.CreateDelegate(FastObjectFactory.type_0);
                            FastObjectFactory.hashtable_0.Add(t, createObject);
                            return createObject;
                        }
                        result = null;
                    }
                }
                return result;
            }
            return createObject;
        }

        // Token: 0x0600158E RID: 5518 RVA: 0x0000F9BE File Offset: 0x0000DBBE
        // Note: this type is marked as 'beforefieldinit'.
        static FastObjectFactory()
        {
        }

        // Token: 0x04000B1D RID: 2845
        private static readonly Hashtable hashtable_0 = Hashtable.Synchronized(new Hashtable());

        // Token: 0x04000B1E RID: 2846
        private static readonly Type type_0 = typeof(FastObjectFactory.CreateObject);

        // Token: 0x020002D5 RID: 725
        // (Invoke) Token: 0x06001590 RID: 5520
        public delegate object CreateObject(IntPtr ptr);
    }
}
