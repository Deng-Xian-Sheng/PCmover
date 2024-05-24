using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using ClientEngineModule.Mock;
using ClientEngineModule.Scr;
using ClientEngineModule.Wcf;
using Laplink.Tools.Helpers;
using MenuModule;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using PCmover.Views;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using WizardModule;

namespace PCmover
{
	// Token: 0x02000003 RID: 3
	internal class Bootstrapper : UnityBootstrapper
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000021EC File Offset: 0x000003EC
		public Bootstrapper(WizardParameters wizardParameters)
		{
			this._wizardParameters = wizardParameters;
			this._ts = new LlTraceSource("PCmover")
			{
				EnabledSettingName = "PCmoverLoggingEnabled"
			};
			this._ts.InitLogging(Path.Combine(this._wizardParameters.LogFolder, "PCmover.log"), null);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002242 File Offset: 0x00000442
		protected override ILoggerFacade CreateLogger()
		{
			return new PrismLogger(this._ts);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000224F File Offset: 0x0000044F
		protected override DependencyObject CreateShell()
		{
			return base.Container.Resolve(Array.Empty<ResolverOverride>());
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002261 File Offset: 0x00000461
		protected override void InitializeShell()
		{
			Application.Current.MainWindow.Show();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002274 File Offset: 0x00000474
		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();
			this.AddEditionModule(Resources.Edition);
			ModuleCatalog moduleCatalog = (ModuleCatalog)base.ModuleCatalog;
			moduleCatalog.AddModule(typeof(ClientEngineMock), Array.Empty<string>());
			if (this._wizardParameters.UseScriptEngine)
			{
				moduleCatalog.AddModule(typeof(ClientEngineScr), Array.Empty<string>());
			}
			else
			{
				moduleCatalog.AddModule(typeof(ClientEngineWcf), Array.Empty<string>());
			}
			moduleCatalog.AddModule(typeof(WizardModuleModule), Array.Empty<string>());
			moduleCatalog.AddModule(typeof(MenuModuleModule), Array.Empty<string>());
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000231C File Offset: 0x0000051C
		private void AddEditionModule(string editionName)
		{
			if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EditionModule." + editionName + ".dll")))
			{
				editionName = "Default";
			}
			string str = "EditionModule." + editionName;
			string text = editionName + "EditionModule";
			string str2 = "EditionModule." + editionName + "." + text;
			ModuleInfo moduleInfo = new ModuleInfo
			{
				ModuleName = text,
				ModuleType = str2 + "," + str
			};
			base.ModuleCatalog.AddModule(moduleInfo);
			this._ts.TraceInformation("Edition module " + moduleInfo.ModuleName + " " + moduleInfo.ModuleType);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000023D4 File Offset: 0x000005D4
		protected override void InitializeModules()
		{
			Bootstrapper.<InitializeModules>d__8 <InitializeModules>d__;
			<InitializeModules>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<InitializeModules>d__.<>4__this = this;
			<InitializeModules>d__.<>1__state = -1;
			<InitializeModules>d__.<>t__builder.Start<Bootstrapper.<InitializeModules>d__8>(ref <InitializeModules>d__);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000240B File Offset: 0x0000060B
		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
			base.Container.RegisterInstance(this._ts);
			base.Container.RegisterInstance(this._wizardParameters);
			base.Container.RegisterInstance(this._wizardParameters);
		}

		// Token: 0x04000003 RID: 3
		private readonly WizardParameters _wizardParameters;

		// Token: 0x04000004 RID: 4
		private readonly LlTraceSource _ts;
	}
}
