using System;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200009B RID: 155
	public class TransferSummaryPageViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000D8E RID: 3470 RVA: 0x00024D24 File Offset: 0x00022F24
		public TransferSummaryPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IMigrationDefinition migration, DefaultPolicy policy, NavigationHelper navigationHelper)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this.OnStartTransfer = new DelegateCommand(new Action(this.OnStartTransferCommand), new Func<bool>(this.CanOnStartTransfer));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnLetMeChoose = new DelegateCommand(new Action(this.OnLetMeChooseCommand), new Func<bool>(this.CanOnLetMeChooseCommand));
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x00024DC5 File Offset: 0x00022FC5
		// (set) Token: 0x06000D90 RID: 3472 RVA: 0x00024DCD File Offset: 0x00022FCD
		public bool IsViewSelectorVisible
		{
			get
			{
				return this._IsViewSelectorVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsViewSelectorVisible, value, "IsViewSelectorVisible");
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x00024DE2 File Offset: 0x00022FE2
		// (set) Token: 0x06000D92 RID: 3474 RVA: 0x00024DEA File Offset: 0x00022FEA
		public DelegateCommand OnLetMeChoose { get; private set; }

		// Token: 0x06000D93 RID: 3475 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnLetMeChooseCommand()
		{
			return true;
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00024DF3 File Offset: 0x00022FF3
		private void OnLetMeChooseCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LetMeChoosePage", UriKind.Relative));
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00024E10 File Offset: 0x00023010
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x00024E18 File Offset: 0x00023018
		public DelegateCommand OnStartTransfer { get; private set; }

		// Token: 0x06000D97 RID: 3479 RVA: 0x00024E21 File Offset: 0x00023021
		private void OnStartTransferCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferEverythingProgressPage", UriKind.Relative));
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnStartTransfer()
		{
			return true;
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x00024E3E File Offset: 0x0002303E
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x00024E46 File Offset: 0x00023046
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000D9B RID: 3483 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00024E50 File Offset: 0x00023050
		private void OnBackCommand()
		{
			if (this.selectedIndex != 0)
			{
				this.regionManager.RequestNavigate(RegionNames.SummaryDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_LetMeChoosePage);
				this.selectedIndex = 0;
			}
			else
			{
				this._navigationHelper.GoBack(null);
			}
			this.IsViewSelectorVisible = false;
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x00024EB4 File Offset: 0x000230B4
		private void OnSelectionChanged(NavigationParameters parameters)
		{
			this.selectedIndex = (int)parameters["Index"];
			this.regionManager.RequestNavigate(RegionNames.SummaryDetailButtons, new Uri((string)parameters["Region"], UriKind.Relative), parameters);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish((string)parameters["Title"]);
			this.IsViewSelectorVisible = (this.selectedIndex != 0);
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00024F30 File Offset: 0x00023130
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.TransferProgress);
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_TransferSummary);
			this.subscriptionToken = this.eventAggregator.GetEvent<SelectionChanged>().Subscribe(new Action<NavigationParameters>(this.OnSelectionChanged), ThreadOption.UIThread);
			if (this.migrationDefinition.IsSelfTransfer)
			{
				NavigationParameters navigationParameters = new NavigationParameters();
				navigationParameters.Add("PPMCustomizationMode", true);
				this.regionManager.RequestNavigate(RegionNames.SummaryDetailButtons, new Uri("DetailButtonList", UriKind.Relative), navigationParameters);
			}
			else
			{
				this.regionManager.RequestNavigate(RegionNames.SummaryDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
			}
			this.selectedIndex = 0;
			this.IsViewSelectorVisible = false;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x00024FF9 File Offset: 0x000231F9
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<SelectionChanged>().Unsubscribe(this.subscriptionToken);
		}

		// Token: 0x04000477 RID: 1143
		private readonly IRegionManager regionManager;

		// Token: 0x04000478 RID: 1144
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000479 RID: 1145
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x0400047A RID: 1146
		private NavigationContext navigationContext;

		// Token: 0x0400047B RID: 1147
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x0400047C RID: 1148
		private readonly DefaultPolicy policy;

		// Token: 0x0400047D RID: 1149
		private SubscriptionToken subscriptionToken;

		// Token: 0x0400047E RID: 1150
		private int selectedIndex;

		// Token: 0x0400047F RID: 1151
		private bool _IsViewSelectorVisible;
	}
}
