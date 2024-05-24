using System;
using System.Collections.Generic;

namespace Microsoft.Practices.ServiceLocation
{
	// Token: 0x02000003 RID: 3
	public interface IServiceLocator : IServiceProvider
	{
		// Token: 0x06000004 RID: 4
		object GetInstance(Type serviceType);

		// Token: 0x06000005 RID: 5
		object GetInstance(Type serviceType, string key);

		// Token: 0x06000006 RID: 6
		IEnumerable<object> GetAllInstances(Type serviceType);

		// Token: 0x06000007 RID: 7
		TService GetInstance<TService>();

		// Token: 0x06000008 RID: 8
		TService GetInstance<TService>(string key);

		// Token: 0x06000009 RID: 9
		IEnumerable<TService> GetAllInstances<TService>();
	}
}
