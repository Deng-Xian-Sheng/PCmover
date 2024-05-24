using System;
using MenuModule.Views;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Modularity;
using Prism.Regions;

namespace MenuModule
{
	// Token: 0x02000002 RID: 2
	public class MenuModuleModule : IPcmoverModule, IModule
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public MenuModuleModule(IUnityContainer container)
		{
			this._originalContainer = container;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205F File Offset: 0x0000025F
		public void Initialize()
		{
			this._originalContainer.RegisterInstance(this);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
		public bool DeferredInitialize(IUnityContainer container)
		{
			IRegionViewRegistry regionViewRegistry = container.Resolve(Array.Empty<ResolverOverride>());
			regionViewRegistry.RegisterViewWithRegion(RegionNames.GodModeRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			regionViewRegistry.RegisterViewWithRegion(RegionNames.GodModeRegion, () => container.Resolve(Array.Empty<ResolverOverride>()));
			container.RegisterType("MockConfig", Array.Empty<InjectionMember>());
			return true;
		}

		// Token: 0x04000001 RID: 1
		private readonly IUnityContainer _originalContainer;
	}
}
