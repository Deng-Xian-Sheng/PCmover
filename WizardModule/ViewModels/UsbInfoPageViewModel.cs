using System;
using System.Diagnostics;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200009D RID: 157
	public class UsbInfoPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000DDA RID: 3546 RVA: 0x00025854 File Offset: 0x00023A54
		public UsbInfoPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnGetCable = new DelegateCommand(new Action(this.OnGetCableCommand), new Func<bool>(this.CanOnGetCableCommand));
			eventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Subscribe(new Action<ConnectableMachine>(this.OnMachineStatus), ThreadOption.UIThread);
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x000258F4 File Offset: 0x00023AF4
		// (set) Token: 0x06000DDC RID: 3548 RVA: 0x000258FC File Offset: 0x00023AFC
		public string OldPC
		{
			get
			{
				return this._OldPC;
			}
			set
			{
				this.SetProperty<string>(ref this._OldPC, value, "OldPC");
			}
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00025911 File Offset: 0x00023B11
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00025919 File Offset: 0x00023B19
		public string NewPC
		{
			get
			{
				return this._NewPC;
			}
			set
			{
				this.SetProperty<string>(ref this._NewPC, value, "NewPC");
			}
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x0002592E File Offset: 0x00023B2E
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x00025936 File Offset: 0x00023B36
		public bool IsNextEnabled
		{
			get
			{
				return this._IsNextEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsNextEnabled, value, "IsNextEnabled");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00025956 File Offset: 0x00023B56
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x0002595E File Offset: 0x00023B5E
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00025968 File Offset: 0x00023B68
		private void OnBackCommand()
		{
			if (this.navigationContext.NavigationService.Journal.CanGoBack)
			{
				this.navigationContext.NavigationService.Journal.GoBack();
				return;
			}
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindFastestTransferType", UriKind.Relative));
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x000259BD File Offset: 0x00023BBD
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x000259C5 File Offset: 0x00023BC5
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0002592E File Offset: 0x00023B2E
		private bool CanOnNextCommand()
		{
			return this._IsNextEnabled;
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x000259D0 File Offset: 0x00023BD0
		private void OnNextCommand()
		{
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("IsConnected", false);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), navigationParameters);
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x00025A10 File Offset: 0x00023C10
		// (set) Token: 0x06000DEA RID: 3562 RVA: 0x00025A18 File Offset: 0x00023C18
		public DelegateCommand OnGetCable { get; private set; }

		// Token: 0x06000DEB RID: 3563 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnGetCableCommand()
		{
			return true;
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x00025A24 File Offset: 0x00023C24
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

		// Token: 0x06000DED RID: 3565 RVA: 0x00025A54 File Offset: 0x00023C54
		private void OnMachineStatus(ConnectableMachine machine)
		{
			if (machine != null && machine.Status == DiscoveredMachineStatus.MachineFound)
			{
				this.OnFoundTargetComputer(machine);
				return;
			}
			if (machine != null && machine.Status == DiscoveredMachineStatus.MachineLost)
			{
				this.OnLostTargetComputer(machine);
			}
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00025A7C File Offset: 0x00023C7C
		private void OnLostTargetComputer(ConnectableMachine obj)
		{
			this.IsNextEnabled = false;
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00025A88 File Offset: 0x00023C88
		private void OnFoundTargetComputer(ConnectableMachine machine)
		{
			if (machine.Method == TransferMethodType.Usb)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.NewPC = (machine.IsOld ? this.pcmoverEngine.ThisMachine.FriendlyName : machine.FriendlyName);
					this.OldPC = (machine.IsOld ? machine.FriendlyName : this.pcmoverEngine.ThisMachine.FriendlyName);
					this.IsNextEnabled = true;
				}, "OnFoundTargetComputer");
			}
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00025AD8 File Offset: 0x00023CD8
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			if (activityInfo.Type == ActivityType.Listen && activityInfo.Phase == 2)
			{
				NavigationParameters parameters = new NavigationParameters();
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.pcmoverEngine.Ts.TraceInformation("UsbInfoPageViewModel.OnActivityInfo: Set ThisMachineIsOld = true");
					this.pcmoverEngine.ThisMachineIsOld = true;
					parameters.Add("IsConnected", true);
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), parameters);
				}, "OnActivityInfo");
			}
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00025B2C File Offset: 0x00023D2C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.UsbInfo);
				this.navigationContext = navigationContext;
				this.NewPC = this.pcmoverEngine.ThisMachine.FriendlyName;
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_UsbInfoPage);
				this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
			}, "OnNavigatedTo");
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x00025B6A File Offset: 0x00023D6A
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
		}

		// Token: 0x0400049E RID: 1182
		private readonly IRegionManager regionManager;

		// Token: 0x0400049F RID: 1183
		private NavigationContext navigationContext;

		// Token: 0x040004A0 RID: 1184
		private string _OldPC;

		// Token: 0x040004A1 RID: 1185
		private string _NewPC;

		// Token: 0x040004A2 RID: 1186
		private bool _IsNextEnabled;
	}
}
