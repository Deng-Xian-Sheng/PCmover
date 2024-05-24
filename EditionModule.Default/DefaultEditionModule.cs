using System;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Modularity;

namespace EditionModule.Default
{
	// Token: 0x02000002 RID: 2
	public class DefaultEditionModule : BaseEditionData, IModule, IEditionModule, IPcmoverModule
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public IEditionData Data
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002053 File Offset: 0x00000253
		public DefaultEditionModule(IUnityContainer container)
		{
			this._originalContainer = container;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002062 File Offset: 0x00000262
		public void Initialize()
		{
			this._originalContainer.RegisterInstance(this, new ContainerControlledLifetimeManager());
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002076 File Offset: 0x00000276
		public bool DeferredInitialize(IUnityContainer container)
		{
			return true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002079 File Offset: 0x00000279
		public void InitData(DefaultPolicy policy)
		{
		}

		// Token: 0x04000001 RID: 1
		private readonly IUnityContainer _originalContainer;
	}
}
