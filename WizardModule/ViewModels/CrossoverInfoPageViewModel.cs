using System;
using System.Diagnostics;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200007B RID: 123
	public class CrossoverInfoPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060006C7 RID: 1735 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
		public CrossoverInfoPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnGetCable = new DelegateCommand(new Action(this.OnGetCableCommand), new Func<bool>(this.CanOnGetCableCommand));
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x0000F54F File Offset: 0x0000D74F
		// (set) Token: 0x060006C9 RID: 1737 RVA: 0x0000F557 File Offset: 0x0000D757
		public string OtherPC
		{
			get
			{
				return this._OtherPC;
			}
			set
			{
				this.SetProperty<string>(ref this._OtherPC, value, "OtherPC");
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x0000F56C File Offset: 0x0000D76C
		// (set) Token: 0x060006CB RID: 1739 RVA: 0x0000F574 File Offset: 0x0000D774
		public string ThisPC
		{
			get
			{
				return this._ThisPC;
			}
			set
			{
				this.SetProperty<string>(ref this._ThisPC, value, "ThisPC");
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x0000F589 File Offset: 0x0000D789
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x0000F591 File Offset: 0x0000D791
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x060006CE RID: 1742 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0000F59A File Offset: 0x0000D79A
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x0000F5A8 File Offset: 0x0000D7A8
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060006D2 RID: 1746 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextCommand()
		{
			return true;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0000F5BC File Offset: 0x0000D7BC
		private void OnNextCommand()
		{
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("IsConnected", false);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), navigationParameters);
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x0000F5FC File Offset: 0x0000D7FC
		// (set) Token: 0x060006D5 RID: 1749 RVA: 0x0000F604 File Offset: 0x0000D804
		public DelegateCommand OnGetCable { get; private set; }

		// Token: 0x060006D6 RID: 1750 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnGetCableCommand()
		{
			return true;
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0000F610 File Offset: 0x0000D810
		private void OnGetCableCommand()
		{
			try
			{
				Process.Start(PcmBrandUI.Properties.Resources.URL_UsbCable);
			}
			catch
			{
			}
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0000F640 File Offset: 0x0000D840
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			if (activityInfo.Type == ActivityType.Listen && activityInfo.Phase == 2)
			{
				NavigationParameters parameters = new NavigationParameters();
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.pcmoverEngine.Ts.TraceInformation("CrossoverInfoPageViewModel.OnActivityInfo: Set ThisMachineIsOld = true");
					this.pcmoverEngine.ThisMachineIsOld = true;
					parameters.Add("IsConnected", true);
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), parameters);
				}, "OnActivityInfo");
			}
			this.OnNext.RaiseCanExecuteChanged();
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0000F6A0 File Offset: 0x0000D8A0
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_CrossoverInfoPage);
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.CrossoverInfo);
			this.OtherPC = this.migrationDefinition.PCName2;
			this.ThisPC = this.migrationDefinition.PCName1;
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0000F71A File Offset: 0x0000D91A
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
		}

		// Token: 0x040001AB RID: 427
		private readonly IRegionManager regionManager;

		// Token: 0x040001AC RID: 428
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040001AD RID: 429
		private NavigationContext navigationContext;

		// Token: 0x040001AE RID: 430
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040001AF RID: 431
		private string _OtherPC;

		// Token: 0x040001B0 RID: 432
		private string _ThisPC;
	}
}
