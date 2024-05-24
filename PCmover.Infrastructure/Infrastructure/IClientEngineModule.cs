using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace PCmover.Infrastructure
{
	// Token: 0x0200001F RID: 31
	public interface IClientEngineModule : IPcmoverModule, IModule
	{
		// Token: 0x060001C5 RID: 453
		void RegisterPcmoverEngine(IUnityContainer container);
	}
}
