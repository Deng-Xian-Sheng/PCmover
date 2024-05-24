using System;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Modularity;

namespace ClientEngineModule.Scr
{
	// Token: 0x02000002 RID: 2
	public class ClientEngineScr : IClientEngineScrModule, IClientEngineLiveModule, IClientEngineModule, IPcmoverModule, IModule
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ClientEngineScr(IUnityContainer container)
		{
			this._originalContainer = container;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205F File Offset: 0x0000025F
		public void Initialize()
		{
			this._originalContainer.RegisterInstance(this);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000206E File Offset: 0x0000026E
		public bool DeferredInitialize(IUnityContainer unityContainer)
		{
			return true;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002071 File Offset: 0x00000271
		public void RegisterPcmoverEngine(IUnityContainer container)
		{
			container.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
		}

		// Token: 0x04000001 RID: 1
		private readonly IUnityContainer _originalContainer;
	}
}
