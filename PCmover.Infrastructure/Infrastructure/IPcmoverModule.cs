using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace PCmover.Infrastructure
{
	// Token: 0x02000029 RID: 41
	public interface IPcmoverModule : IModule
	{
		// Token: 0x0600027D RID: 637
		bool DeferredInitialize(IUnityContainer unityContainer);
	}
}
