using System;
using System.Globalization;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity.Properties;
using Prism.Unity.Regions;

namespace Prism.Unity
{
	// Token: 0x02000002 RID: 2
	public abstract class UnityBootstrapper : Bootstrapper
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public IUnityContainer Container { get; protected set; }

		// Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
		public override void Run(bool runWithDefaultConfiguration)
		{
			this.useDefaultConfiguration = runWithDefaultConfiguration;
			base.Logger = this.CreateLogger();
			if (base.Logger == null)
			{
				throw new InvalidOperationException(Resources.NullLoggerFacadeException);
			}
			base.Logger.Log(Resources.LoggerCreatedSuccessfully, Category.Debug, Priority.Low);
			base.Logger.Log(Resources.CreatingModuleCatalog, Category.Debug, Priority.Low);
			base.ModuleCatalog = this.CreateModuleCatalog();
			if (base.ModuleCatalog == null)
			{
				throw new InvalidOperationException(Resources.NullModuleCatalogException);
			}
			base.Logger.Log(Resources.ConfiguringModuleCatalog, Category.Debug, Priority.Low);
			this.ConfigureModuleCatalog();
			base.Logger.Log(Resources.CreatingUnityContainer, Category.Debug, Priority.Low);
			this.Container = this.CreateContainer();
			if (this.Container == null)
			{
				throw new InvalidOperationException(Resources.NullUnityContainerException);
			}
			base.Logger.Log(Resources.ConfiguringUnityContainer, Category.Debug, Priority.Low);
			this.ConfigureContainer();
			base.Logger.Log(Resources.ConfiguringServiceLocatorSingleton, Category.Debug, Priority.Low);
			this.ConfigureServiceLocator();
			base.Logger.Log(Resources.ConfiguringViewModelLocator, Category.Debug, Priority.Low);
			this.ConfigureViewModelLocator();
			base.Logger.Log(Resources.ConfiguringRegionAdapters, Category.Debug, Priority.Low);
			this.ConfigureRegionAdapterMappings();
			base.Logger.Log(Resources.ConfiguringDefaultRegionBehaviors, Category.Debug, Priority.Low);
			this.ConfigureDefaultRegionBehaviors();
			base.Logger.Log(Resources.RegisteringFrameworkExceptionTypes, Category.Debug, Priority.Low);
			this.RegisterFrameworkExceptionTypes();
			base.Logger.Log(Resources.CreatingShell, Category.Debug, Priority.Low);
			base.Shell = this.CreateShell();
			if (base.Shell != null)
			{
				base.Logger.Log(Resources.SettingTheRegionManager, Category.Debug, Priority.Low);
				RegionManager.SetRegionManager(base.Shell, this.Container.Resolve(new ResolverOverride[0]));
				base.Logger.Log(Resources.UpdatingRegions, Category.Debug, Priority.Low);
				RegionManager.UpdateRegions();
				base.Logger.Log(Resources.InitializingShell, Category.Debug, Priority.Low);
				this.InitializeShell();
			}
			if (this.Container.IsRegistered<IModuleManager>())
			{
				base.Logger.Log(Resources.InitializingModules, Category.Debug, Priority.Low);
				this.InitializeModules();
			}
			base.Logger.Log(Resources.BootstrapperSequenceCompleted, Category.Debug, Priority.Low);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000226F File Offset: 0x0000046F
		protected override void ConfigureServiceLocator()
		{
			ServiceLocator.SetLocatorProvider(() => this.Container.Resolve(new ResolverOverride[0]));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002282 File Offset: 0x00000482
		protected override void RegisterFrameworkExceptionTypes()
		{
			base.RegisterFrameworkExceptionTypes();
			ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ResolutionFailedException));
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000229C File Offset: 0x0000049C
		protected virtual void ConfigureContainer()
		{
			base.Logger.Log(Resources.AddingUnityBootstrapperExtensionToContainer, Category.Debug, Priority.Low);
			this.Container.AddNewExtension<UnityBootstrapperExtension>();
			this.Container.RegisterInstance(base.Logger);
			this.Container.RegisterInstance(base.ModuleCatalog);
			if (this.useDefaultConfiguration)
			{
				this.RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);
				this.RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true);
				this.RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true);
				this.RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true);
				this.RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
				this.RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
				this.RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true);
				this.RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true);
				this.RegisterTypeIfMissing(typeof(IRegionNavigationJournalEntry), typeof(RegionNavigationJournalEntry), false);
				this.RegisterTypeIfMissing(typeof(IRegionNavigationJournal), typeof(RegionNavigationJournal), false);
				this.RegisterTypeIfMissing(typeof(IRegionNavigationService), typeof(RegionNavigationService), false);
				this.RegisterTypeIfMissing(typeof(IRegionNavigationContentLoader), typeof(UnityRegionNavigationContentLoader), true);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000243C File Offset: 0x0000063C
		protected override void InitializeModules()
		{
			IModuleManager moduleManager;
			try
			{
				moduleManager = this.Container.Resolve(new ResolverOverride[0]);
			}
			catch (ResolutionFailedException ex)
			{
				if (ex.Message.Contains("IModuleCatalog"))
				{
					throw new InvalidOperationException(Resources.NullModuleCatalogException);
				}
				throw;
			}
			moduleManager.Run();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002494 File Offset: 0x00000694
		protected virtual IUnityContainer CreateContainer()
		{
			return new UnityContainer();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000249C File Offset: 0x0000069C
		protected void RegisterTypeIfMissing(Type fromType, Type toType, bool registerAsSingleton)
		{
			if (fromType == null)
			{
				throw new ArgumentNullException("fromType");
			}
			if (toType == null)
			{
				throw new ArgumentNullException("toType");
			}
			if (this.Container.IsTypeRegistered(fromType))
			{
				base.Logger.Log(string.Format(CultureInfo.CurrentCulture, Resources.TypeMappingAlreadyRegistered, new object[]
				{
					fromType.Name
				}), Category.Debug, Priority.Low);
				return;
			}
			if (registerAsSingleton)
			{
				this.Container.RegisterType(fromType, toType, new ContainerControlledLifetimeManager(), new InjectionMember[0]);
				return;
			}
			this.Container.RegisterType(fromType, toType, new InjectionMember[0]);
		}

		// Token: 0x04000001 RID: 1
		private bool useDefaultConfiguration = true;
	}
}
