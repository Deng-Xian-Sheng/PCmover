using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Prism.Unity
{
	// Token: 0x02000006 RID: 6
	public class UnityServiceLocatorAdapter : ServiceLocatorImplBase
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002650 File Offset: 0x00000850
		public UnityServiceLocatorAdapter(IUnityContainer unityContainer)
		{
			this._unityContainer = unityContainer;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000265F File Offset: 0x0000085F
		protected override object DoGetInstance(Type serviceType, string key)
		{
			return this._unityContainer.Resolve(serviceType, key, new ResolverOverride[0]);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002674 File Offset: 0x00000874
		protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
		{
			return this._unityContainer.ResolveAll(serviceType, new ResolverOverride[0]);
		}

		// Token: 0x04000003 RID: 3
		private readonly IUnityContainer _unityContainer;
	}
}
