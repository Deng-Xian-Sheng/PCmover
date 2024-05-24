using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
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
	// Token: 0x02000073 RID: 115
	public class AnalyzePCPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060005D3 RID: 1491 RVA: 0x0000D62C File Offset: 0x0000B82C
		public AnalyzePCPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._ts = ts;
			this._wizardModuleModule = wizardModuleModule;
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnCustomTransfer = new DelegateCommand(new Action(this.OnCustomTransferCommand), new Func<bool>(this.CanOnCustomTransferCommand));
			this.OnPreviousTipSelected = new DelegateCommand(new Action(this.OnPreviousTipSelectedCommand), new Func<bool>(this.CanOnPreviousTipSelectedCommand));
			this.OnNextTipSelected = new DelegateCommand(new Action(this.OnNextTipSelectedCommand), new Func<bool>(this.CanOnNextTipSelectedCommand));
			this.OnDownloadPCmover = new DelegateCommand(new Action(this.OnDownloadPCmoverCommand), new Func<bool>(this.CanOnDownloadPCmoverCommand));
			this.OnSupport = new DelegateCommand(new Action(this.OnSupportCommand), new Func<bool>(this.CanOnSupportCommand));
			eventAggregator.GetEvent<EngineEvents.SnapshotProgressChanged>().Subscribe(new Action<ProgressInfo>(this.OnSnapshotProgressChanged), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
			this.IsBusy = true;
			this._wizardParameters = container.Resolve(Array.Empty<ResolverOverride>());
			this.TipIndex = 0;
			this.tipTimer.Interval = new TimeSpan(0, 0, 15);
			this.Tips = new List<string>
			{
				WizardModule.Properties.Resources.strTip1,
				WizardModule.Properties.Resources.strTip2,
				WizardModule.Properties.Resources.strTip3,
				WizardModule.Properties.Resources.strTip4,
				WizardModule.Properties.Resources.strTip5
			};
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0000D824 File Offset: 0x0000BA24
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x0000D82C File Offset: 0x0000BA2C
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

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x0000D841 File Offset: 0x0000BA41
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x0000D849 File Offset: 0x0000BA49
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

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x0000D85E File Offset: 0x0000BA5E
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x0000D866 File Offset: 0x0000BA66
		public string TipText
		{
			get
			{
				return this._TipText;
			}
			set
			{
				this.SetProperty<string>(ref this._TipText, value, "TipText");
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x0000D87B File Offset: 0x0000BA7B
		// (set) Token: 0x060005DB RID: 1499 RVA: 0x0000D884 File Offset: 0x0000BA84
		public int TipIndex
		{
			get
			{
				return this._TipIndex;
			}
			set
			{
				this.SetProperty<int>(ref this._TipIndex, value, "TipIndex");
				if (this._TipIndex < 5)
				{
					this.TipImage = new BitmapImage(new Uri("/WizardModule;component/Assets/Tip" + (this._TipIndex + 1).ToString() + ".png", UriKind.RelativeOrAbsolute));
				}
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x0000D8DD File Offset: 0x0000BADD
		// (set) Token: 0x060005DD RID: 1501 RVA: 0x0000D8E5 File Offset: 0x0000BAE5
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBusy, value, "IsBusy");
				this.OnNext.RaiseCanExecuteChanged();
				this.OnCustomTransfer.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x0000D910 File Offset: 0x0000BB10
		// (set) Token: 0x060005DF RID: 1503 RVA: 0x0000D918 File Offset: 0x0000BB18
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsActive, value, "IsActive");
				this.OnBack.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x0000D938 File Offset: 0x0000BB38
		// (set) Token: 0x060005E1 RID: 1505 RVA: 0x0000D940 File Offset: 0x0000BB40
		public int NumItems
		{
			get
			{
				return this._NumItems;
			}
			set
			{
				this.SetProperty<int>(ref this._NumItems, value, "NumItems");
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0000D955 File Offset: 0x0000BB55
		public string APCO_Determining
		{
			get
			{
				return PcmBrandUI.Properties.Resources.APCO_Determining;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x0000D95C File Offset: 0x0000BB5C
		// (set) Token: 0x060005E4 RID: 1508 RVA: 0x0000D964 File Offset: 0x0000BB64
		public List<string> Tips { get; set; }

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0000D96D File Offset: 0x0000BB6D
		// (set) Token: 0x060005E6 RID: 1510 RVA: 0x0000D975 File Offset: 0x0000BB75
		public double TransferSize
		{
			get
			{
				return this._TransferSize;
			}
			set
			{
				this.SetProperty<double>(ref this._TransferSize, value, "TransferSize");
				this.FormattedTransferSize = Tools.GetDisplaySize(this._TransferSize);
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000D99B File Offset: 0x0000BB9B
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000D9A3 File Offset: 0x0000BBA3
		public string FormattedTransferSize
		{
			get
			{
				return this._FormattedTransferSize;
			}
			private set
			{
				this.SetProperty<string>(ref this._FormattedTransferSize, value, "FormattedTransferSize");
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0000D9B8 File Offset: 0x0000BBB8
		// (set) Token: 0x060005EA RID: 1514 RVA: 0x0000D9C0 File Offset: 0x0000BBC0
		public string TransferTime
		{
			get
			{
				return this._TransferTime;
			}
			private set
			{
				this.SetProperty<string>(ref this._TransferTime, value, "TransferTime");
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0000D9D5 File Offset: 0x0000BBD5
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x0000D9DD File Offset: 0x0000BBDD
		public BitmapImage TipImage
		{
			get
			{
				return this._TipImage;
			}
			private set
			{
				this.SetProperty<BitmapImage>(ref this._TipImage, value, "TipImage");
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0000D9F2 File Offset: 0x0000BBF2
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x0000D9FA File Offset: 0x0000BBFA
		public string IAProgress
		{
			get
			{
				return this._IAProgress;
			}
			set
			{
				this.SetProperty<string>(ref this._IAProgress, value, "IAProgress");
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0000DA0F File Offset: 0x0000BC0F
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x0000DA17 File Offset: 0x0000BC17
		public bool IsImageAssistMigration
		{
			get
			{
				return this._IsImageAssistMigration;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsImageAssistMigration, value, "IsImageAssistMigration");
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		// (set) Token: 0x060005F2 RID: 1522 RVA: 0x0000DA34 File Offset: 0x0000BC34
		public bool IsVersionMismatchPopupOpen
		{
			get
			{
				return this._IsVersionMismatchPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVersionMismatchPopupOpen, value, "IsVersionMismatchPopupOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0000DA5A File Offset: 0x0000BC5A
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0000DA62 File Offset: 0x0000BC62
		public string VersionMismatchError
		{
			get
			{
				return this._VersionMismatchError;
			}
			set
			{
				this.SetProperty<string>(ref this._VersionMismatchError, value, "VersionMismatchError");
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000DA77 File Offset: 0x0000BC77
		public bool CanCustomize
		{
			get
			{
				return !base.pcmoverEngine.IsScript;
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0000DA87 File Offset: 0x0000BC87
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x0000DA8F File Offset: 0x0000BC8F
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000DA98 File Offset: 0x0000BC98
		private bool CanOnBackCommand()
		{
			bool flag = !string.IsNullOrWhiteSpace(this._wizardParameters.Source);
			return (!base.pcmoverEngine.IsRemoteUI || !flag) && this.IsActive && this.navigationContext != null;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000DAE0 File Offset: 0x0000BCE0
		private void OnBackCommand()
		{
			AnalyzePCPageViewModel.<OnBackCommand>d__87 <OnBackCommand>d__;
			<OnBackCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnBackCommand>d__.<>4__this = this;
			<OnBackCommand>d__.<>1__state = -1;
			<OnBackCommand>d__.<>t__builder.Start<AnalyzePCPageViewModel.<OnBackCommand>d__87>(ref <OnBackCommand>d__);
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x0000DB17 File Offset: 0x0000BD17
		// (set) Token: 0x060005FB RID: 1531 RVA: 0x0000DB1F File Offset: 0x0000BD1F
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060005FC RID: 1532 RVA: 0x0000DB28 File Offset: 0x0000BD28
		private bool CanOnNextCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0000DB33 File Offset: 0x0000BD33
		private void OnNextCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferEverythingPage", UriKind.Relative));
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x0000DB50 File Offset: 0x0000BD50
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x0000DB58 File Offset: 0x0000BD58
		public DelegateCommand OnPreviousTipSelected { get; private set; }

		// Token: 0x06000600 RID: 1536 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnPreviousTipSelectedCommand()
		{
			return true;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0000DB64 File Offset: 0x0000BD64
		private void OnPreviousTipSelectedCommand()
		{
			this.tipTimer.Stop();
			try
			{
				int num = this.TipIndex - 1;
				this.TipIndex = num;
				if (num < 0)
				{
					this.TipIndex = this.Tips.Count - 1;
				}
				this.TipText = this.Tips[this.TipIndex];
			}
			catch
			{
				this.TipIndex = 0;
			}
			this.tipTimer.Start();
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0000DBE4 File Offset: 0x0000BDE4
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x0000DBEC File Offset: 0x0000BDEC
		public DelegateCommand OnNextTipSelected { get; private set; }

		// Token: 0x06000604 RID: 1540 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextTipSelectedCommand()
		{
			return true;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000DBF8 File Offset: 0x0000BDF8
		private void OnNextTipSelectedCommand()
		{
			this.tipTimer.Stop();
			try
			{
				int num = this.TipIndex + 1;
				this.TipIndex = num;
				if (num >= this.Tips.Count)
				{
					this.TipIndex = 0;
				}
				this.TipText = this.Tips[this.TipIndex];
			}
			catch
			{
				this.TipIndex = 0;
			}
			this.tipTimer.Start();
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x0000DC74 File Offset: 0x0000BE74
		// (set) Token: 0x06000607 RID: 1543 RVA: 0x0000DC7C File Offset: 0x0000BE7C
		public DelegateCommand OnCustomTransfer { get; private set; }

		// Token: 0x06000608 RID: 1544 RVA: 0x0000DB28 File Offset: 0x0000BD28
		private bool CanOnCustomTransferCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0000DC85 File Offset: 0x0000BE85
		private void OnCustomTransferCommand()
		{
			this.policy.analyzePCPagePolicy.CustomTransfer = true;
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("CustomTransferPage", UriKind.Relative));
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x0000DCB3 File Offset: 0x0000BEB3
		// (set) Token: 0x0600060B RID: 1547 RVA: 0x0000DCBB File Offset: 0x0000BEBB
		public DelegateCommand OnDownloadPCmover { get; private set; }

		// Token: 0x0600060C RID: 1548 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDownloadPCmoverCommand()
		{
			return true;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0000DCC4 File Offset: 0x0000BEC4
		private void OnDownloadPCmoverCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.FPP_Download));
			}
			catch
			{
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x0000DCF8 File Offset: 0x0000BEF8
		// (set) Token: 0x0600060F RID: 1551 RVA: 0x0000DD00 File Offset: 0x0000BF00
		public DelegateCommand OnSupport { get; private set; }

		// Token: 0x06000610 RID: 1552 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSupportCommand()
		{
			return true;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0000DD09 File Offset: 0x0000BF09
		private void OnSupportCommand()
		{
			Tools.OpenSupport(this.policy);
			this.IsVersionMismatchPopupOpen = false;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0000DD20 File Offset: 0x0000BF20
		private void FillTaskCompleted(FillTaskData obj)
		{
			base.pcmoverEngine.Ts.TraceInformation(string.Format("FillTaskCompleted fired ({0})", obj.Result));
			this._fillTaskResult = obj.Result;
			if (obj.Result == FillTaskResult.DomainsDoNotMatch)
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, string.Format(WizardModule.Properties.Resources.ERROR_DomainsDoNotMatch, this.policy.SupportEmail), WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, this._wizardModuleModule.WelcomeUri);
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0000DDB8 File Offset: 0x0000BFB8
		private void ReadyForCustomization()
		{
			AnalyzePCPageViewModel.<ReadyForCustomization>d__125 <ReadyForCustomization>d__;
			<ReadyForCustomization>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ReadyForCustomization>d__.<>4__this = this;
			<ReadyForCustomization>d__.<>1__state = -1;
			<ReadyForCustomization>d__.<>t__builder.Start<AnalyzePCPageViewModel.<ReadyForCustomization>d__125>(ref <ReadyForCustomization>d__);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0000DDF0 File Offset: 0x0000BFF0
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			AnalyzePCPageViewModel.<OnActivityInfo>d__126 <OnActivityInfo>d__;
			<OnActivityInfo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnActivityInfo>d__.<>4__this = this;
			<OnActivityInfo>d__.activityInfo = activityInfo;
			<OnActivityInfo>d__.<>1__state = -1;
			<OnActivityInfo>d__.<>t__builder.Start<AnalyzePCPageViewModel.<OnActivityInfo>d__126>(ref <OnActivityInfo>d__);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0000DE2F File Offset: 0x0000C02F
		private void OnSnapshotProgressChanged(ProgressInfo progressInfo)
		{
			this.NumItems = Math.Max((int)progressInfo.BytesProcessed, this.NumItems);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0000DE4C File Offset: 0x0000C04C
		private void OnImageAppInventoryProgressChanged(ProgressInfo progress)
		{
			if (!this._IsImageAssistMigration)
			{
				return;
			}
			int num = 0;
			if (progress.Task.ToLower().StartsWith("step 1"))
			{
				num = Math.Max((int)Convert.ToInt16((double)progress.Percentage * 0.05), num);
			}
			else if (progress.Task.ToLower().StartsWith("step 2"))
			{
				num = Math.Max((int)(5 + Convert.ToInt16((double)progress.Percentage * 0.2)), num);
			}
			else if (progress.Task.ToLower().StartsWith("step 3"))
			{
				num = Math.Max((int)(25 + Convert.ToInt16((double)progress.Percentage * 0.05)), num);
			}
			else
			{
				num = Math.Max((int)(30 + Convert.ToInt16((double)progress.Percentage * 0.7)), num);
			}
			if (num == 0)
			{
				num = 1;
			}
			this.IAProgress = string.Format(WizardModule.Properties.Resources.APCO_Complete, num);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0000DF4C File Offset: 0x0000C14C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			AnalyzePCPageViewModel.<OnNavigatedTo>d__129 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.navigationContext = navigationContext;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<AnalyzePCPageViewModel.<OnNavigatedTo>d__129>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0000DF8C File Offset: 0x0000C18C
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.IsActive = false;
			this.tipTimer.Stop();
			this.eventAggregator.GetEvent<EngineEvents.ThisMachineAppInventoryProgressChanged>().Unsubscribe(new Action<ProgressInfo>(this.OnImageAppInventoryProgressChanged));
			this.eventAggregator.GetEvent<EngineEvents.CreateFillTaskEvent>().Unsubscribe(new Action<FillTaskData>(this.FillTaskCompleted));
			this.eventAggregator.GetEvent<EngineEvents.ReadyForCustomizationEvent>().Unsubscribe(new Action(this.ReadyForCustomization));
			this.policy.WriteProfile();
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0000E00C File Offset: 0x0000C20C
		private void tipTimer_Tick(object sender, object e)
		{
			int num = this.TipIndex + 1;
			this.TipIndex = num;
			if (num >= this.Tips.Count)
			{
				this.TipIndex = 0;
			}
			this.TipText = this.Tips[this.TipIndex];
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0000E058 File Offset: 0x0000C258
		private void Resume()
		{
			if (this.migrationDefinition.ServiceData.TransferType == PcmoverTransferState.TransferTypeEnum.PcToPc)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.StartReadSnapshot();
				}, "Resume");
				this.migrationDefinition.PCName1 = this.migrationDefinition.ServiceData.ThisMachine.NetName;
				this.migrationDefinition.PCName2 = this.migrationDefinition.ServiceData.OtherComputerMachineName;
				this.migrationDefinition.IsPCName1Old = false;
				this.OtherPC = this.migrationDefinition.PCName2;
				this.eventAggregator.GetEvent<Events.ShowSSLIcon>().Publish(true);
			}
			switch (this.migrationDefinition.ServiceData.Step)
			{
			case PcmoverTransferState.TransferStep.NotStarted:
			case PcmoverTransferState.TransferStep.Preparing:
				break;
			case PcmoverTransferState.TransferStep.Customizing:
			case PcmoverTransferState.TransferStep.Transferring:
			case PcmoverTransferState.TransferStep.Done:
				base.pcmoverEngine.CatchCommEx(delegate
				{
					CustomizationScreen customizeScreen;
					Enum.TryParse<CustomizationScreen>(base.pcmoverEngine.GetControllerProperty(ControllerProperties.CustomizationScreen), out customizeScreen);
					this.migrationDefinition.CustomizeScreen = customizeScreen;
				}, "Resume");
				return;
			case PcmoverTransferState.TransferStep.Downloading:
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("DownloadManagerPage", UriKind.Relative));
				break;
			default:
				return;
			}
		}

		// Token: 0x0400013D RID: 317
		private readonly IRegionManager regionManager;

		// Token: 0x0400013E RID: 318
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x0400013F RID: 319
		private NavigationContext navigationContext;

		// Token: 0x04000140 RID: 320
		private bool bGetSnapshotRunning;

		// Token: 0x04000141 RID: 321
		private bool bWaitingForSnapshotReady;

		// Token: 0x04000142 RID: 322
		private readonly DispatcherTimer tipTimer = new DispatcherTimer();

		// Token: 0x04000143 RID: 323
		private readonly Random random = new Random();

		// Token: 0x04000144 RID: 324
		private readonly DefaultPolicy policy;

		// Token: 0x04000145 RID: 325
		private readonly LlTraceSource _ts;

		// Token: 0x04000146 RID: 326
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x04000147 RID: 327
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x04000148 RID: 328
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000149 RID: 329
		private FillTaskResult _fillTaskResult;

		// Token: 0x0400014A RID: 330
		private string _OtherPC;

		// Token: 0x0400014B RID: 331
		private string _ThisPC;

		// Token: 0x0400014C RID: 332
		private string _TipText;

		// Token: 0x0400014D RID: 333
		private int _TipIndex;

		// Token: 0x0400014E RID: 334
		private bool _IsBusy;

		// Token: 0x0400014F RID: 335
		private bool _IsActive;

		// Token: 0x04000150 RID: 336
		private int _NumItems;

		// Token: 0x04000152 RID: 338
		private double _TransferSize;

		// Token: 0x04000153 RID: 339
		private string _FormattedTransferSize;

		// Token: 0x04000154 RID: 340
		private string _TransferTime;

		// Token: 0x04000155 RID: 341
		private BitmapImage _TipImage;

		// Token: 0x04000156 RID: 342
		private string _IAProgress;

		// Token: 0x04000157 RID: 343
		private bool _IsImageAssistMigration;

		// Token: 0x04000158 RID: 344
		private bool _IsVersionMismatchPopupOpen;

		// Token: 0x04000159 RID: 345
		private string _VersionMismatchError;
	}
}
