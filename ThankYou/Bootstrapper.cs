using System;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using ThankYou.Views;

namespace ThankYou
{
	// Token: 0x02000002 RID: 2
	internal class Bootstrapper : UnityBootstrapper
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override DependencyObject CreateShell()
		{
			return base.Container.Resolve(Array.Empty<ResolverOverride>());
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002062 File Offset: 0x00000262
		protected override void InitializeShell()
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();
			((ModuleCatalog)base.ModuleCatalog).AddModule(typeof(ContentModule), Array.Empty<string>());
		}
	}
}
