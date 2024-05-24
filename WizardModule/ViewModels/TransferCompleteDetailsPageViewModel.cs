using System;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000098 RID: 152
	public class TransferCompleteDetailsPageViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000CDE RID: 3294 RVA: 0x00022DC3 File Offset: 0x00020FC3
		public TransferCompleteDetailsPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00022DFC File Offset: 0x00020FFC
		// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x00022E04 File Offset: 0x00021004
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

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00022E19 File Offset: 0x00021019
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x00022E21 File Offset: 0x00021021
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00022E2C File Offset: 0x0002102C
		private void OnBackCommand()
		{
			if (this.selectedIndex != 0)
			{
				this.regionManager.RequestNavigate(RegionNames.TransferCompleteDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.TCDP_TransferDetails);
				this.selectedIndex = 0;
			}
			else if (this.navigationContext.NavigationService.Journal.CanGoBack)
			{
				this.navigationContext.NavigationService.Journal.GoBack();
			}
			else
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferCompletePage", UriKind.Relative));
			}
			this.IsViewSelectorVisible = false;
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00022ECC File Offset: 0x000210CC
		private void OnSelectionChanged(NavigationParameters parameters)
		{
			this.selectedIndex = (int)parameters["Index"];
			this.regionManager.RequestNavigate(RegionNames.TransferCompleteDetailButtons, new Uri((string)parameters["Region"], UriKind.Relative), parameters);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish((string)parameters["Title"]);
			this.IsViewSelectorVisible = (this.selectedIndex != 0);
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00022F48 File Offset: 0x00021148
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.TransferComplete);
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.TCDP_TransferDetails);
			this.subscriptionToken = this.eventAggregator.GetEvent<SelectionChanged>().Subscribe(new Action<NavigationParameters>(this.OnSelectionChanged), ThreadOption.UIThread);
			this.regionManager.RequestNavigate(RegionNames.TransferCompleteDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
			this.selectedIndex = 0;
			this.IsViewSelectorVisible = false;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00022FCF File Offset: 0x000211CF
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<SelectionChanged>().Unsubscribe(this.subscriptionToken);
		}

		// Token: 0x0400041E RID: 1054
		private readonly IRegionManager regionManager;

		// Token: 0x0400041F RID: 1055
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000420 RID: 1056
		private NavigationContext navigationContext;

		// Token: 0x04000421 RID: 1057
		private SubscriptionToken subscriptionToken;

		// Token: 0x04000422 RID: 1058
		private int selectedIndex;

		// Token: 0x04000423 RID: 1059
		private bool _IsViewSelectorVisible;
	}
}
