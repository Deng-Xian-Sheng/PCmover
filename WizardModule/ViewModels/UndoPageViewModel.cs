using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;
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
	// Token: 0x0200009C RID: 156
	public class UndoPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000DA1 RID: 3489 RVA: 0x00025014 File Offset: 0x00023214
		public UndoPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this._wizardModuleModule = wizardModuleModule;
			this.policy = policy;
			this.IsProgressVisible = true;
			this.OnFinish = new DelegateCommand(new Action(this.OnFinishCommand), new Func<bool>(this.CanOnFinishCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand));
			this.OnClosePopup = new DelegateCommand(new Action(this.OnClosePopupCommand));
			this.OnStart = new DelegateCommand(new Action(this.OnStartCommand));
			this.OnStopUndo = new DelegateCommand(new Action(this.OnStopUndoCommand), new Func<bool>(this.CanOnStopUndoCommand));
			this.ShowEstimateTime = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowEstimatedTime);
			this.progressTimer.Tick += delegate(object sender, EventArgs args)
			{
				this.UpdateTimeRemaining();
			};
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x00025127 File Offset: 0x00023327
		// (set) Token: 0x06000DA3 RID: 3491 RVA: 0x0002512F File Offset: 0x0002332F
		public bool IsFinishEnabled
		{
			get
			{
				return this._IsFinishEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsFinishEnabled, value, "IsFinishEnabled");
				this.OnFinish.RaiseCanExecuteChanged();
				this.OnBack.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x0002515A File Offset: 0x0002335A
		// (set) Token: 0x06000DA5 RID: 3493 RVA: 0x00025162 File Offset: 0x00023362
		public string OtherPC
		{
			get
			{
				return this._OtherPC;
			}
			private set
			{
				this.SetProperty<string>(ref this._OtherPC, value, "OtherPC");
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06000DA6 RID: 3494 RVA: 0x00025177 File Offset: 0x00023377
		// (set) Token: 0x06000DA7 RID: 3495 RVA: 0x0002517F File Offset: 0x0002337F
		public string ThisPC
		{
			get
			{
				return this._ThisPC;
			}
			private set
			{
				this.SetProperty<string>(ref this._ThisPC, value, "ThisPC");
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06000DA8 RID: 3496 RVA: 0x00025194 File Offset: 0x00023394
		// (set) Token: 0x06000DA9 RID: 3497 RVA: 0x0002519C File Offset: 0x0002339C
		public double Progress
		{
			get
			{
				return this._Progress;
			}
			private set
			{
				this.SetProperty<double>(ref this._Progress, value, "Progress");
			}
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06000DAA RID: 3498 RVA: 0x000251B1 File Offset: 0x000233B1
		// (set) Token: 0x06000DAB RID: 3499 RVA: 0x000251B9 File Offset: 0x000233B9
		public string CurrentItem
		{
			get
			{
				return this._CurrentItem;
			}
			private set
			{
				this.SetProperty<string>(ref this._CurrentItem, value, "CurrentItem");
			}
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06000DAC RID: 3500 RVA: 0x000251CE File Offset: 0x000233CE
		// (set) Token: 0x06000DAD RID: 3501 RVA: 0x000251D6 File Offset: 0x000233D6
		public string TimeRemaining
		{
			get
			{
				return this._TimeRemaining;
			}
			private set
			{
				this.SetProperty<string>(ref this._TimeRemaining, value, "TimeRemaining");
			}
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x000251EB File Offset: 0x000233EB
		// (set) Token: 0x06000DAF RID: 3503 RVA: 0x000251F3 File Offset: 0x000233F3
		public string CurrentCategory
		{
			get
			{
				return this._CurrentCategory;
			}
			private set
			{
				this.SetProperty<string>(ref this._CurrentCategory, value, "CurrentCategory");
			}
		}

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06000DB0 RID: 3504 RVA: 0x00025208 File Offset: 0x00023408
		// (set) Token: 0x06000DB1 RID: 3505 RVA: 0x00025210 File Offset: 0x00023410
		public bool IsProgressVisible
		{
			get
			{
				return this.isProgressVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this.isProgressVisible, value, "IsProgressVisible");
			}
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x00025225 File Offset: 0x00023425
		// (set) Token: 0x06000DB3 RID: 3507 RVA: 0x0002522D File Offset: 0x0002342D
		public bool IsBackButtonVisible
		{
			get
			{
				return this._IsBackButtonVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsBackButtonVisible, value, "IsBackButtonVisible");
			}
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x00025242 File Offset: 0x00023442
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x0002524A File Offset: 0x0002344A
		public bool IsStopEnabled
		{
			get
			{
				return this._IsStopEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsStopEnabled, value, "IsStopEnabled");
				this.OnStopUndo.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x0002526A File Offset: 0x0002346A
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00025272 File Offset: 0x00023472
		public bool ShowEstimateTime
		{
			get
			{
				return this._ShowEstimateTime;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowEstimateTime, value, "ShowEstimateTime");
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x00025287 File Offset: 0x00023487
		// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x0002528F File Offset: 0x0002348F
		public bool IsProgressSpinnerVisible
		{
			get
			{
				return this._IsProgressSpinnerVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsProgressSpinnerVisible, value, "IsProgressSpinnerVisible");
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06000DBA RID: 3514 RVA: 0x000252A4 File Offset: 0x000234A4
		// (set) Token: 0x06000DBB RID: 3515 RVA: 0x000252AC File Offset: 0x000234AC
		public DelegateCommand OnFinish { get; private set; }

		// Token: 0x06000DBC RID: 3516 RVA: 0x000252B5 File Offset: 0x000234B5
		private bool CanOnFinishCommand()
		{
			return this.IsFinishEnabled;
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x000252C0 File Offset: 0x000234C0
		private void OnFinishCommand()
		{
			UndoPageViewModel.<OnFinishCommand>d__64 <OnFinishCommand>d__;
			<OnFinishCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnFinishCommand>d__.<>4__this = this;
			<OnFinishCommand>d__.<>1__state = -1;
			<OnFinishCommand>d__.<>t__builder.Start<UndoPageViewModel.<OnFinishCommand>d__64>(ref <OnFinishCommand>d__);
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000252F7 File Offset: 0x000234F7
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x000252FF File Offset: 0x000234FF
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00025308 File Offset: 0x00023508
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, this._wizardModuleModule.WelcomeUri);
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00025325 File Offset: 0x00023525
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x0002532D File Offset: 0x0002352D
		public DelegateCommand OnClosePopup { get; private set; }

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00025308 File Offset: 0x00023508
		private void OnClosePopupCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, this._wizardModuleModule.WelcomeUri);
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00025336 File Offset: 0x00023536
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x0002533E File Offset: 0x0002353E
		public DelegateCommand OnStart { get; private set; }

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00025348 File Offset: 0x00023548
		private void OnStartCommand()
		{
			this.IsBackButtonVisible = false;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.ThisMachineAppInventoryRequirement = AppInventoryAmount.Minimum;
			}, "OnStartCommand"))
			{
				return;
			}
			this.CurrentCategory = WizardModule.Properties.Resources.UP_Initializing;
			this.CurrentItem = "";
			this._StartTime = DateTime.Now;
			this.eventAggregator.GetEvent<Events.CloseConfirmationRequiredChanged>().Publish(true);
			Tools.Disable3rdPartyApps();
			new Task(delegate()
			{
				UndoPageViewModel.<<OnStartCommand>b__79_1>d <<OnStartCommand>b__79_1>d;
				<<OnStartCommand>b__79_1>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<OnStartCommand>b__79_1>d.<>4__this = this;
				<<OnStartCommand>b__79_1>d.<>1__state = -1;
				<<OnStartCommand>b__79_1>d.<>t__builder.Start<UndoPageViewModel.<<OnStartCommand>b__79_1>d>(ref <<OnStartCommand>b__79_1>d);
			}).Start();
			this.progressTimer.Start();
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x000253D3 File Offset: 0x000235D3
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x000253DB File Offset: 0x000235DB
		public DelegateCommand OnStopUndo { get; private set; }

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00025242 File Offset: 0x00023442
		private bool CanOnStopUndoCommand()
		{
			return this._IsStopEnabled;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x000253E4 File Offset: 0x000235E4
		private void OnStopUndoCommand()
		{
			UndoPageViewModel.<OnStopUndoCommand>d__85 <OnStopUndoCommand>d__;
			<OnStopUndoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnStopUndoCommand>d__.<>4__this = this;
			<OnStopUndoCommand>d__.<>1__state = -1;
			<OnStopUndoCommand>d__.<>t__builder.Start<UndoPageViewModel.<OnStopUndoCommand>d__85>(ref <OnStopUndoCommand>d__);
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x0002541C File Offset: 0x0002361C
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			UndoPageViewModel.<OnActivityInfo>d__86 <OnActivityInfo>d__;
			<OnActivityInfo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnActivityInfo>d__.<>4__this = this;
			<OnActivityInfo>d__.activityInfo = activityInfo;
			<OnActivityInfo>d__.<>1__state = -1;
			<OnActivityInfo>d__.<>t__builder.Start<UndoPageViewModel.<OnActivityInfo>d__86>(ref <OnActivityInfo>d__);
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x0002545C File Offset: 0x0002365C
		private void OnProgressChanged(TransferProgressInfo progress)
		{
			double estimatedlUndoProgress = Tools.GetEstimatedlUndoProgress(this.Progress, progress.ProgressInfo.ActionCode);
			if (estimatedlUndoProgress > this.Progress)
			{
				this.Progress = estimatedlUndoProgress;
			}
			UiCallbackCode uiCallbackCode = progress.ProgressInfo.ActionCode;
			if (uiCallbackCode != UiCallbackCode.Empty)
			{
				if (uiCallbackCode == UiCallbackCode.Custom)
				{
					this.CurrentCategory = progress.ProgressInfo.Action;
				}
				else
				{
					this.CurrentCategory = Tools.TranslateUICallback(progress.ProgressInfo.ActionCode, progress.ProgressInfo.Action);
				}
			}
			uiCallbackCode = progress.ProgressInfo.ItemCode;
			if (uiCallbackCode != UiCallbackCode.Empty)
			{
				if (uiCallbackCode == UiCallbackCode.Custom)
				{
					this.CurrentItem = progress.ProgressInfo.Item;
					return;
				}
				this.CurrentItem = Tools.TranslateUICallback(progress.ProgressInfo.ItemCode, progress.ProgressInfo.Item);
			}
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00025520 File Offset: 0x00023720
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			UndoPageViewModel.<OnNavigatedTo>d__88 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<UndoPageViewModel.<OnNavigatedTo>d__88>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00025558 File Offset: 0x00023758
		private Task Update()
		{
			UndoPageViewModel.<Update>d__89 <Update>d__;
			<Update>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<UndoPageViewModel.<Update>d__89>(ref <Update>d__);
			return <Update>d__.<>t__builder.Task;
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x0002559B File Offset: 0x0002379B
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			if (this.progressSubscriptionToken != null)
			{
				this.eventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Unsubscribe(this.progressSubscriptionToken);
			}
			if (this.activitySubscriptionToken != null)
			{
				this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(this.activitySubscriptionToken);
			}
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x000255DC File Offset: 0x000237DC
		private Task<bool> ShowUndoWarningPopup()
		{
			UndoPageViewModel.<ShowUndoWarningPopup>d__92 <ShowUndoWarningPopup>d__;
			<ShowUndoWarningPopup>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ShowUndoWarningPopup>d__.<>4__this = this;
			<ShowUndoWarningPopup>d__.<>1__state = -1;
			<ShowUndoWarningPopup>d__.<>t__builder.Start<UndoPageViewModel.<ShowUndoWarningPopup>d__92>(ref <ShowUndoWarningPopup>d__);
			return <ShowUndoWarningPopup>d__.<>t__builder.Task;
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00025620 File Offset: 0x00023820
		private void UpdateTimeRemaining()
		{
			this.IsProgressSpinnerVisible = (this.Progress <= 3.0);
			if (this.Progress <= 3.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strCalculating;
				return;
			}
			if (this.Progress >= 98.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strTimeRemainingAlmostFinished;
				return;
			}
			if (this.Progress > 90.0 && this._DisplayedSecondsRemaining < 61.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strTimeRemainingAlmostFinished;
				return;
			}
			TimeSpan timeSpan = DateTime.Now - this._StartTime;
			double num = this.Progress / 100.0;
			double num2 = timeSpan.TotalSeconds / num - timeSpan.TotalSeconds;
			if (Math.Abs(num2 - this._DisplayedSecondsRemaining) > 90.0)
			{
				this._DisplayedSecondsRemaining = num2;
			}
			else if (this._DisplayedSecondsRemaining > 1.0)
			{
				this._DisplayedSecondsRemaining -= 1.0;
			}
			else
			{
				this._DisplayedSecondsRemaining += (double)this.random.Next(25, 45);
			}
			this.TimeRemaining = new TimeSpan(0, 0, (int)this._DisplayedSecondsRemaining).ToString("hh\\:mm\\:ss");
		}

		// Token: 0x04000483 RID: 1155
		private readonly IRegionManager regionManager;

		// Token: 0x04000484 RID: 1156
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000485 RID: 1157
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x04000486 RID: 1158
		private SubscriptionToken progressSubscriptionToken;

		// Token: 0x04000487 RID: 1159
		private SubscriptionToken activitySubscriptionToken;

		// Token: 0x04000488 RID: 1160
		private double _DisplayedSecondsRemaining;

		// Token: 0x04000489 RID: 1161
		private DateTime _StartTime;

		// Token: 0x0400048A RID: 1162
		private readonly DispatcherTimer progressTimer = new DispatcherTimer
		{
			Interval = new TimeSpan(0, 0, 1)
		};

		// Token: 0x0400048B RID: 1163
		private readonly Random random = new Random();

		// Token: 0x0400048C RID: 1164
		private DefaultPolicy policy;

		// Token: 0x0400048D RID: 1165
		private bool _IsFinishEnabled;

		// Token: 0x0400048E RID: 1166
		private string _OtherPC;

		// Token: 0x0400048F RID: 1167
		private string _ThisPC;

		// Token: 0x04000490 RID: 1168
		private double _Progress;

		// Token: 0x04000491 RID: 1169
		private string _CurrentItem;

		// Token: 0x04000492 RID: 1170
		private string _TimeRemaining;

		// Token: 0x04000493 RID: 1171
		private string _CurrentCategory;

		// Token: 0x04000494 RID: 1172
		private bool isProgressVisible;

		// Token: 0x04000495 RID: 1173
		private bool _IsBackButtonVisible;

		// Token: 0x04000496 RID: 1174
		private bool _IsStopEnabled;

		// Token: 0x04000497 RID: 1175
		private bool _ShowEstimateTime;

		// Token: 0x04000498 RID: 1176
		private bool _IsProgressSpinnerVisible;
	}
}
