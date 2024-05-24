using System;
using Microsoft.Practices.Unity;

namespace Prism.Unity
{
	// Token: 0x02000004 RID: 4
	public static class UnityExtensions
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000259C File Offset: 0x0000079C
		public static IUnityContainer RegisterTypeForNavigation<T>(this IUnityContainer container, string name = null)
		{
			Type typeFromHandle = typeof(T);
			string name2 = string.IsNullOrWhiteSpace(name) ? typeFromHandle.Name : name;
			return container.RegisterType(typeof(object), typeFromHandle, name2, new InjectionMember[0]);
		}
	}
}
