using System;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Modularity;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000003 RID: 3
	public class ClientEngineWcf : IClientEngineWcfModule, IClientEngineLiveModule, IClientEngineModule, IPcmoverModule, IModule
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002244 File Offset: 0x00000444
		public ClientEngineWcf(IUnityContainer container)
		{
			this._originalContainer = container;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002253 File Offset: 0x00000453
		public void Initialize()
		{
			this._originalContainer.RegisterInstance(this);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002262 File Offset: 0x00000462
		public bool DeferredInitialize(IUnityContainer container)
		{
			return true;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002265 File Offset: 0x00000465
		public void RegisterPcmoverEngine(IUnityContainer container)
		{
			container.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
		}

		// Token: 0x04000001 RID: 1
		private readonly IUnityContainer _originalContainer;
	}
}
