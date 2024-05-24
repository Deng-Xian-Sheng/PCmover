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
	// Token: 0x02000084 RID: 132
	public class FilesBasedSummaryPageViewModel : BindableBase, INavigationAware
	{
		// Token: 0x0600089A RID: 2202 RVA: 0x00013EF4 File Offset: 0x000120F4
		public FilesBasedSummaryPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IMigrationDefinition migration, NavigationHelper navigationHelper)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnLetMeChoose = new DelegateCommand(new Action(this.OnLetMeChooseCommand), new Func<bool>(this.CanOnLetMeChooseCommand));
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00013F6A File Offset: 0x0001216A
		// (set) Token: 0x0600089C RID: 2204 RVA: 0x00013F72 File Offset: 0x00012172
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x0600089D RID: 2205 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00013F7C File Offset: 0x0001217C
		private void OnBackCommand()
		{
			if (this.selectedIndex != 0)
			{
				this.regionManager.RequestNavigate(RegionNames.FilesBasedSummaryDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_FilesBasedSummaryPage);
				this.selectedIndex = 0;
				return;
			}
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x00013FD5 File Offset: 0x000121D5
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x00013FDD File Offset: 0x000121DD
		public DelegateCommand OnLetMeChoose { get; private set; }

		// Token: 0x060008A1 RID: 2209 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnLetMeChooseCommand()
		{
			return true;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00013FE6 File Offset: 0x000121E6
		private void OnLetMeChooseCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FilesBasedCustomizePage", UriKind.Relative));
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00014004 File Offset: 0x00012204
		private void OnSelectionChanged(NavigationParameters parameters)
		{
			this.selectedIndex = (int)parameters["Index"];
			this.regionManager.RequestNavigate(RegionNames.FilesBasedSummaryDetailButtons, new Uri((string)parameters["Region"], UriKind.Relative), parameters);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish((string)parameters["Title"]);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00014070 File Offset: 0x00012270
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.FileSummary);
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_FilesBasedSummaryPage);
			this.eventAggregator.GetEvent<SelectionChanged>().Subscribe(new Action<NavigationParameters>(this.OnSelectionChanged), ThreadOption.UIThread);
			this.regionManager.RequestNavigate(RegionNames.FilesBasedSummaryDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
			this.selectedIndex = 0;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x000140EB File Offset: 0x000122EB
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<SelectionChanged>().Unsubscribe(new Action<NavigationParameters>(this.OnSelectionChanged));
		}

		// Token: 0x0400026C RID: 620
		private readonly IRegionManager regionManager;

		// Token: 0x0400026D RID: 621
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400026E RID: 622
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x0400026F RID: 623
		private NavigationContext navigationContext;

		// Token: 0x04000270 RID: 624
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000271 RID: 625
		private int selectedIndex;
	}
}
