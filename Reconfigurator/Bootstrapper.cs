using System;
using System.Windows;
using Laplink.Tools.Helpers;
using MainUI;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using Reconfigurator.Views;

namespace Reconfigurator
{
	// Token: 0x02000002 RID: 2
	public class Bootstrapper : UnityBootstrapper
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Bootstrapper(LlTraceSource ts)
		{
			this._ts = ts;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205F File Offset: 0x0000025F
		protected override DependencyObject CreateShell()
		{
			return base.Container.Resolve(Array.Empty<ResolverOverride>());
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002071 File Offset: 0x00000271
		protected override void InitializeShell()
		{
			Application.Current.MainWindow.Show();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002082 File Offset: 0x00000282
		protected override void ConfigureModuleCatalog()
		{
			((ModuleCatalog)base.ModuleCatalog).AddModule(typeof(MainUIModule), Array.Empty<string>());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A4 File Offset: 0x000002A4
		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
			base.Container.RegisterInstance(this._ts, new ContainerControlledLifetimeManager());
		}

		// Token: 0x04000001 RID: 1
		private readonly LlTraceSource _ts;
	}
}
