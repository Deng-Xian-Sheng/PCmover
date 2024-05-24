using System;
using Microsoft.Practices.ServiceLocation.Properties;

namespace Microsoft.Practices.ServiceLocation
{
	// Token: 0x02000004 RID: 4
	public static class ServiceLocator
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020EB File Offset: 0x000002EB
		public static IServiceLocator Current
		{
			get
			{
				if (!ServiceLocator.IsLocationProviderSet)
				{
					throw new InvalidOperationException(Resources.ServiceLocationProviderNotSetMessage);
				}
				return ServiceLocator.currentProvider();
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002109 File Offset: 0x00000309
		public static void SetLocatorProvider(ServiceLocatorProvider newProvider)
		{
			ServiceLocator.currentProvider = newProvider;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002111 File Offset: 0x00000311
		public static bool IsLocationProviderSet
		{
			get
			{
				return ServiceLocator.currentProvider != null;
			}
		}

		// Token: 0x04000001 RID: 1
		private static ServiceLocatorProvider currentProvider;
	}
}
