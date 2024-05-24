using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.ClientEngine;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000083 RID: 131
	public class FilesBasedCustomizePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x0600088A RID: 2186 RVA: 0x00013BC8 File Offset: 0x00011DC8
		public FilesBasedCustomizePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextTransfer));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommandAsync), new Func<bool>(this.CanOnBackCommand));
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00013C44 File Offset: 0x00011E44
		// (set) Token: 0x0600088C RID: 2188 RVA: 0x00013C4C File Offset: 0x00011E4C
		public bool IsDoneVisible
		{
			get
			{
				return this._IsDoneVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsDoneVisible, value, "IsDoneVisible");
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x00013C61 File Offset: 0x00011E61
		// (set) Token: 0x0600088E RID: 2190 RVA: 0x00013C69 File Offset: 0x00011E69
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x0600088F RID: 2191 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00013C74 File Offset: 0x00011E74
		private void OnBackCommandAsync()
		{
			FilesBasedCustomizePageViewModel.<OnBackCommandAsync>d__16 <OnBackCommandAsync>d__;
			<OnBackCommandAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnBackCommandAsync>d__.<>4__this = this;
			<OnBackCommandAsync>d__.<>1__state = -1;
			<OnBackCommandAsync>d__.<>t__builder.Start<FilesBasedCustomizePageViewModel.<OnBackCommandAsync>d__16>(ref <OnBackCommandAsync>d__);
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x00013CAB File Offset: 0x00011EAB
		// (set) Token: 0x06000892 RID: 2194 RVA: 0x00013CB3 File Offset: 0x00011EB3
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000893 RID: 2195 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextTransfer()
		{
			return true;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00013CBC File Offset: 0x00011EBC
		private void OnNextCommand()
		{
			this.migrationDefinition.FilesBasedParameters.SaveVan = true;
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FilesBasedAnalyzePage", UriKind.Relative));
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00013CEC File Offset: 0x00011EEC
		private void OnSelectionChanged(NavigationParameters parameters)
		{
			this.selectedIndex = (int)parameters["Index"];
			this.regionManager.RequestNavigate(RegionNames.FilesBasedCustomizeDetailButtons, new Uri((string)parameters["Region"], UriKind.Relative), parameters);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish((string)parameters["Title"]);
			this.IsDoneVisible = (this.selectedIndex != 0);
			this.migrationDefinition.FilesBasedParameters.BuildChangelistsRequired = true;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00013D78 File Offset: 0x00011F78
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.detailButtonListPolicy.IsPageDisplayed)
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.FileCustomize);
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.FBCP_Title);
			this.eventAggregator.GetEvent<SelectionChanged>().Subscribe(new Action<NavigationParameters>(this.OnSelectionChanged), ThreadOption.UIThread);
			this.regionManager.RequestNavigate(RegionNames.FilesBasedCustomizeDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
			this.selectedIndex = 0;
			this.IsDoneVisible = false;
			if (this.migrationDefinition.IsResuming)
			{
				if (this.migrationDefinition.CustomizeScreen == CustomizationScreen.StartTransfer)
				{
					this.OnNext.Execute();
				}
				else
				{
					this.migrationDefinition.IsResuming = false;
				}
			}
			else
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.SetControllerProperty(ControllerProperties.CustomizationScreen, CustomizationScreen.LetMeChoose.ToString());
				}, "OnNavigatedTo");
			}
			if (!this.policy.detailButtonListPolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy)
			{
				this.OnNextCommand();
			}
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00013E9C File Offset: 0x0001209C
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<SelectionChanged>().Unsubscribe(new Action<NavigationParameters>(this.OnSelectionChanged));
			this.policy.WriteProfile();
		}

		// Token: 0x04000263 RID: 611
		private readonly IRegionManager regionManager;

		// Token: 0x04000264 RID: 612
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000265 RID: 613
		private NavigationContext navigationContext;

		// Token: 0x04000266 RID: 614
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000267 RID: 615
		private int selectedIndex;

		// Token: 0x04000268 RID: 616
		private readonly DefaultPolicy policy;

		// Token: 0x04000269 RID: 617
		private bool _IsDoneVisible;
	}
}
