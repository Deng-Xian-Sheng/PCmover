using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Practices.ServiceLocation;
using Prism.Logging;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace Prism
{
	// Token: 0x02000005 RID: 5
	public abstract class Bootstrapper
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000021D8 File Offset: 0x000003D8
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000021E0 File Offset: 0x000003E0
		protected ILoggerFacade Logger { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000021E9 File Offset: 0x000003E9
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000021F1 File Offset: 0x000003F1
		protected IModuleCatalog ModuleCatalog { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021FA File Offset: 0x000003FA
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002202 File Offset: 0x00000402
		protected DependencyObject Shell { get; set; }

		// Token: 0x0600000F RID: 15 RVA: 0x0000220B File Offset: 0x0000040B
		protected virtual ILoggerFacade CreateLogger()
		{
			return new TextLogger();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002212 File Offset: 0x00000412
		public void Run()
		{
			this.Run(true);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000221B File Offset: 0x0000041B
		protected virtual IModuleCatalog CreateModuleCatalog()
		{
			return new ModuleCatalog();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002222 File Offset: 0x00000422
		protected virtual void ConfigureModuleCatalog()
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002224 File Offset: 0x00000424
		protected virtual void ConfigureViewModelLocator()
		{
			ViewModelLocationProvider.SetDefaultViewModelFactory((Type type) => ServiceLocator.Current.GetInstance(type));
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000224A File Offset: 0x0000044A
		protected virtual void RegisterFrameworkExceptionTypes()
		{
			ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ActivationException));
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000225B File Offset: 0x0000045B
		protected virtual void InitializeModules()
		{
			ServiceLocator.Current.GetInstance<IModuleManager>().Run();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000226C File Offset: 0x0000046C
		protected virtual RegionAdapterMappings ConfigureRegionAdapterMappings()
		{
			RegionAdapterMappings instance = ServiceLocator.Current.GetInstance<RegionAdapterMappings>();
			if (instance != null)
			{
				instance.RegisterMapping(typeof(Selector), ServiceLocator.Current.GetInstance<SelectorRegionAdapter>());
				instance.RegisterMapping(typeof(ItemsControl), ServiceLocator.Current.GetInstance<ItemsControlRegionAdapter>());
				instance.RegisterMapping(typeof(ContentControl), ServiceLocator.Current.GetInstance<ContentControlRegionAdapter>());
			}
			return instance;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022D8 File Offset: 0x000004D8
		protected virtual IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
		{
			IRegionBehaviorFactory instance = ServiceLocator.Current.GetInstance<IRegionBehaviorFactory>();
			if (instance != null)
			{
				instance.AddIfMissing("ContextToDependencyObject", typeof(BindRegionContextToDependencyObjectBehavior));
				instance.AddIfMissing("ActiveAware", typeof(RegionActiveAwareBehavior));
				instance.AddIfMissing(SyncRegionContextWithHostBehavior.BehaviorKey, typeof(SyncRegionContextWithHostBehavior));
				instance.AddIfMissing(RegionManagerRegistrationBehavior.BehaviorKey, typeof(RegionManagerRegistrationBehavior));
				instance.AddIfMissing("RegionMemberLifetimeBehavior", typeof(RegionMemberLifetimeBehavior));
				instance.AddIfMissing("ClearChildViews", typeof(ClearChildViewsRegionBehavior));
				instance.AddIfMissing("AutoPopulate", typeof(AutoPopulateRegionBehavior));
			}
			return instance;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000238A File Offset: 0x0000058A
		protected virtual DependencyObject CreateShell()
		{
			return null;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002222 File Offset: 0x00000422
		protected virtual void InitializeShell()
		{
		}

		// Token: 0x0600001A RID: 26
		public abstract void Run(bool runWithDefaultConfiguration);

		// Token: 0x0600001B RID: 27
		protected abstract void ConfigureServiceLocator();
	}
}
