using System;
using Laplink.Pcmover.Configurator.FolderTools;
using MainUI.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace MainUI
{
	// Token: 0x02000004 RID: 4
	public class MainUIModule : IModule
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000022D7 File Offset: 0x000004D7
		public MainUIModule(IUnityContainer container, IRegionManager regionManager)
		{
			this._regionManager = regionManager;
			this._unityContainer = container;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000022F0 File Offset: 0x000004F0
		public void Initialize()
		{
			this._unityContainer.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
			this._unityContainer.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
			this._regionManager.RegisterViewWithRegion("MainRegion", typeof(MainUserControl));
			this._regionManager.RegisterViewWithRegion("HeaderRegion", typeof(HeaderUserControl));
			this._regionManager.RegisterViewWithRegion("FooterRegion", typeof(FooterUserControl));
			this._regionManager.RegisterViewWithRegion("MainRegion", typeof(RegistrationUserControl));
			this._regionManager.RegisterViewWithRegion("MainRegion", typeof(PickUserControl));
			this._regionManager.RegisterViewWithRegion("MainRegion", typeof(FoldersUserControl));
			this._regionManager.RegisterViewWithRegion("MainRegion", typeof(ProgramsUserControl));
			this._regionManager.RegisterViewWithRegion("MainRegion", typeof(SummaryUserControl));
			this._regionManager.RegisterViewWithRegion("PickFolders", typeof(PickFoldersUserControl));
			this._regionManager.RegisterViewWithRegion("PickPrograms", typeof(PickProgramsUserControl));
		}

		// Token: 0x0400000E RID: 14
		private readonly IRegionManager _regionManager;

		// Token: 0x0400000F RID: 15
		private readonly IUnityContainer _unityContainer;
	}
}
