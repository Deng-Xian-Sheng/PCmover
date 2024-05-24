using System;

namespace System.Threading
{
	// Token: 0x0200053E RID: 1342
	internal static class LazyHelpers<T>
	{
		// Token: 0x06003EE1 RID: 16097 RVA: 0x000E9F24 File Offset: 0x000E8124
		private static T ActivatorFactorySelector()
		{
			T result;
			try
			{
				result = (T)((object)Activator.CreateInstance(typeof(T)));
			}
			catch (MissingMethodException)
			{
				throw new MissingMemberException(Environment.GetResourceString("Lazy_CreateValue_NoParameterlessCtorForT"));
			}
			return result;
		}

		// Token: 0x04001A6F RID: 6767
		internal static Func<T> s_activatorFactorySelector = new Func<T>(LazyHelpers<T>.ActivatorFactorySelector);
	}
}
