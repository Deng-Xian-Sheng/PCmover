using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using ThankYou.Views;

namespace ThankYou
{
	// Token: 0x02000003 RID: 3
	public class ContentModule : IModule
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002094 File Offset: 0x00000294
		public ContentModule(IUnityContainer container, RegionManager regionManager)
		{
			this.container = container;
			this.regionManager = regionManager;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020AA File Offset: 0x000002AA
		public void Initialize()
		{
			this.regionManager.RegisterViewWithRegion("ContentRegion", () => this.container.Resolve(Array.Empty<ResolverOverride>()));
			this.regionManager.RegisterViewWithRegion("ContentRegion", () => this.container.Resolve(Array.Empty<ResolverOverride>()));
		}

		// Token: 0x04000001 RID: 1
		private readonly IUnityContainer container;

		// Token: 0x04000002 RID: 2
		private readonly IRegionManager regionManager;
	}
}
