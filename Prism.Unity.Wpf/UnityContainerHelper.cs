using System;
using Microsoft.Practices.Unity;

namespace Prism.Unity
{
	// Token: 0x02000005 RID: 5
	public static class UnityContainerHelper
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000025DE File Offset: 0x000007DE
		public static bool IsTypeRegistered(this IUnityContainer container, Type type)
		{
			return UnityBootstrapperExtension.IsTypeRegistered(container, type);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000025E8 File Offset: 0x000007E8
		public static T TryResolve<T>(this IUnityContainer container)
		{
			object obj = container.TryResolve(typeof(T));
			if (obj != null)
			{
				return (T)((object)obj);
			}
			return default(T);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000261C File Offset: 0x0000081C
		public static object TryResolve(this IUnityContainer container, Type typeToResolve)
		{
			object result;
			try
			{
				result = container.Resolve(typeToResolve, new ResolverOverride[0]);
			}
			catch
			{
				result = null;
			}
			return result;
		}
	}
}
