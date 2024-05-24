using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
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
	// Token: 0x0200009A RID: 154
	public class TransferEverythingProgressPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000D3B RID: 3387 RVA: 0x00023DA4 File Offset: 0x00021FA4
		public TransferEverythingProgressPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, NavigationHelper navigationHelper, IMigrationDefinition migration, DefaultPolicy policy, LlTraceSource ts) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this._navigationHelper = navigationHelper;
			this.policy = policy;
			this._ts = ts;
			this.OnStop = new DelegateCommand(new Action(this.OnStopCommand), new Func<bool>(this.CanOnStopCommand));
			this.OnClosePopup = new DelegateCommand(new Action(this.OnClosePopupCommand), new Func<bool>(this.CanOnClosePopupCommand));
			this.OnCloseNetworkProblem = new DelegateCommand(new Action(this.OnCloseNetworkProblemCommand), new Func<bool>(this.CanOnCloseNetworkProblemCommand));
			this.OnNetworkProblem = new DelegateCommand(new Action(this.OnNetworkProblemCommand), new Func<bool>(this.CanOnNetworkProblemCommand));
			this.OnSavePassword = new DelegateCommand<object>(new Action<object>(this.OnSavePasswordCommand), new Func<object, bool>(this.CanOnSavePasswordCommand));
			this.NetworkQualityTimer.Interval = new TimeSpan(0, 0, 1);
			this.NetworkQualityTimer.Tick += new EventHandler(this.NetworkQualityTimer_Tick);
			this.IsNetworkProblemOpen = false;
			this.ShowNetworkErrorLink = false;
			this.ShowEstimateTime = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowEstimatedTime);
			eventAggregator.GetEvent<EngineEvents.AuthorizationError>().Subscribe(new Action<Events.AuthorizationErrorEventArgs>(this.OnAuthorizationErrorAsync), ThreadOption.UIThread);
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x00023F13 File Offset: 0x00022113
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x00023F1B File Offset: 0x0002211B
		public bool IsNetworkProblemOpen
		{
			get
			{
				return this._IsNetworkProblemOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsNetworkProblemOpen, value, "IsNetworkProblemOpen");
			}
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x06000D3E RID: 3390 RVA: 0x00023F30 File Offset: 0x00022130
		// (set) Token: 0x06000D3F RID: 3391 RVA: 0x00023F38 File Offset: 0x00022138
		public bool IsPopupOpen
		{
			get
			{
				return this._IsPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsPopupOpen, value, "IsPopupOpen");
			}
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x00023F4D File Offset: 0x0002214D
		// (set) Token: 0x06000D41 RID: 3393 RVA: 0x00023F55 File Offset: 0x00022155
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

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x00023F6A File Offset: 0x0002216A
		// (set) Token: 0x06000D43 RID: 3395 RVA: 0x00023F72 File Offset: 0x00022172
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

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06000D44 RID: 3396 RVA: 0x00023F87 File Offset: 0x00022187
		// (set) Token: 0x06000D45 RID: 3397 RVA: 0x00023F8F File Offset: 0x0002218F
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

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06000D46 RID: 3398 RVA: 0x00023FA4 File Offset: 0x000221A4
		// (set) Token: 0x06000D47 RID: 3399 RVA: 0x00023FAC File Offset: 0x000221AC
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

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x00023FC1 File Offset: 0x000221C1
		// (set) Token: 0x06000D49 RID: 3401 RVA: 0x00023FC9 File Offset: 0x000221C9
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

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x00023FDE File Offset: 0x000221DE
		// (set) Token: 0x06000D4B RID: 3403 RVA: 0x00023FE6 File Offset: 0x000221E6
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

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06000D4C RID: 3404 RVA: 0x00023FFB File Offset: 0x000221FB
		// (set) Token: 0x06000D4D RID: 3405 RVA: 0x00024003 File Offset: 0x00022203
		public bool IsPasswordMismatch
		{
			get
			{
				return this._IsPasswordMismatch;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsPasswordMismatch, value, "IsPasswordMismatch");
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06000D4E RID: 3406 RVA: 0x00024018 File Offset: 0x00022218
		// (set) Token: 0x06000D4F RID: 3407 RVA: 0x00024020 File Offset: 0x00022220
		public bool IsPasswordPopupOpen
		{
			get
			{
				return this._IsPasswordPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsPasswordPopupOpen, value, "IsPasswordPopupOpen");
			}
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x00024035 File Offset: 0x00022235
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x0002403D File Offset: 0x0002223D
		public string MissingPasswordAccount
		{
			get
			{
				return this._MissingPasswordAccount;
			}
			set
			{
				this.SetProperty<string>(ref this._MissingPasswordAccount, value, "MissingPasswordAccount");
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x00024052 File Offset: 0x00022252
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x0002405A File Offset: 0x0002225A
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

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x0002406F File Offset: 0x0002226F
		// (set) Token: 0x06000D55 RID: 3413 RVA: 0x00024077 File Offset: 0x00022277
		public bool IsStopEnabled
		{
			get
			{
				return this._IsStopEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsStopEnabled, value, "IsStopEnabled");
				this.OnStop.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x00024097 File Offset: 0x00022297
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x0002409F File Offset: 0x0002229F
		public bool ShowNetworkQuality
		{
			get
			{
				return this._ShowNetworkQuality;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowNetworkQuality, value, "ShowNetworkQuality");
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x000240B4 File Offset: 0x000222B4
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x000240BC File Offset: 0x000222BC
		public bool ShowNetworkErrorLink
		{
			get
			{
				return this._ShowNetworkErrorLink;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowNetworkErrorLink, value, "ShowNetworkErrorLink");
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x000240D1 File Offset: 0x000222D1
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x000240D9 File Offset: 0x000222D9
		public double ErrorRatio
		{
			get
			{
				return this._ErrorRatio;
			}
			set
			{
				this.SetProperty<double>(ref this._ErrorRatio, value, "ErrorRatio");
				base.RaisePropertyChanged("ProgressPoints");
				this.OnStop.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x00024104 File Offset: 0x00022304
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x0002410C File Offset: 0x0002230C
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

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x00024124 File Offset: 0x00022324
		// (set) Token: 0x06000D5F RID: 3423 RVA: 0x0000CE65 File Offset: 0x0000B065
		public PointCollection ProgressPoints
		{
			get
			{
				return new PointCollection
				{
					new Point(0.0, 15.0),
					new Point(0.0, 10.0),
					new Point(this.ErrorRatio, 10.0 - this.ErrorRatio / 100.0 * 10.0),
					new Point(this.ErrorRatio, 15.0),
					new Point(0.0, 15.0)
				};
			}
			set
			{
			}
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06000D60 RID: 3424 RVA: 0x000241DC File Offset: 0x000223DC
		// (set) Token: 0x06000D61 RID: 3425 RVA: 0x0000CE65 File Offset: 0x0000B065
		public PointCollection BackgroundPoints
		{
			get
			{
				return new PointCollection
				{
					new Point(0.0, 15.0),
					new Point(0.0, 10.0),
					new Point(98.0, 0.0),
					new Point(98.0, 15.0),
					new Point(0.0, 15.0)
				};
			}
			set
			{
			}
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x0002427F File Offset: 0x0002247F
		// (set) Token: 0x06000D63 RID: 3427 RVA: 0x00024287 File Offset: 0x00022487
		public string TimeRemainingString
		{
			get
			{
				return this._TimeRemainingString;
			}
			set
			{
				this.SetProperty<string>(ref this._TimeRemainingString, value, "TimeRemainingString");
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x0002429C File Offset: 0x0002249C
		// (set) Token: 0x06000D65 RID: 3429 RVA: 0x000242A4 File Offset: 0x000224A4
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

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06000D66 RID: 3430 RVA: 0x000242B9 File Offset: 0x000224B9
		// (set) Token: 0x06000D67 RID: 3431 RVA: 0x000242C1 File Offset: 0x000224C1
		public SslInfo SSLInfo
		{
			get
			{
				return this._SSLInfo;
			}
			set
			{
				this.SetProperty<SslInfo>(ref this._SSLInfo, value, "SSLInfo");
			}
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06000D68 RID: 3432 RVA: 0x000242D6 File Offset: 0x000224D6
		// (set) Token: 0x06000D69 RID: 3433 RVA: 0x000242DE File Offset: 0x000224DE
		public bool IsProfileMigrator
		{
			get
			{
				return this._IsProfileMigrator;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsProfileMigrator, value, "IsProfileMigrator");
			}
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06000D6A RID: 3434 RVA: 0x000242F3 File Offset: 0x000224F3
		// (set) Token: 0x06000D6B RID: 3435 RVA: 0x000242FB File Offset: 0x000224FB
		public string ArrowUri
		{
			get
			{
				return this._ArrowUri;
			}
			set
			{
				this.SetProperty<string>(ref this._ArrowUri, value, "ArrowUri");
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x00024310 File Offset: 0x00022510
		// (set) Token: 0x06000D6D RID: 3437 RVA: 0x00024318 File Offset: 0x00022518
		public DelegateCommand OnStop { get; private set; }

		// Token: 0x06000D6E RID: 3438 RVA: 0x00024321 File Offset: 0x00022521
		private bool CanOnStopCommand()
		{
			return this.IsStopEnabled;
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0002432C File Offset: 0x0002252C
		private void OnStopCommand()
		{
			TransferEverythingProgressPageViewModel.<OnStopCommand>d__123 <OnStopCommand>d__;
			<OnStopCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnStopCommand>d__.<>4__this = this;
			<OnStopCommand>d__.<>1__state = -1;
			<OnStopCommand>d__.<>t__builder.Start<TransferEverythingProgressPageViewModel.<OnStopCommand>d__123>(ref <OnStopCommand>d__);
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06000D70 RID: 3440 RVA: 0x00024363 File Offset: 0x00022563
		// (set) Token: 0x06000D71 RID: 3441 RVA: 0x0002436B File Offset: 0x0002256B
		public DelegateCommand OnClosePopup { get; private set; }

		// Token: 0x06000D72 RID: 3442 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnClosePopupCommand()
		{
			return true;
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00024374 File Offset: 0x00022574
		private void OnClosePopupCommand()
		{
			this.IsPopupOpen = false;
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06000D74 RID: 3444 RVA: 0x0002437D File Offset: 0x0002257D
		// (set) Token: 0x06000D75 RID: 3445 RVA: 0x00024385 File Offset: 0x00022585
		public DelegateCommand OnCloseNetworkProblem { get; private set; }

		// Token: 0x06000D76 RID: 3446 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseNetworkProblemCommand()
		{
			return true;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0002438E File Offset: 0x0002258E
		private void OnCloseNetworkProblemCommand()
		{
			this.IsNetworkProblemOpen = false;
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06000D78 RID: 3448 RVA: 0x00024397 File Offset: 0x00022597
		// (set) Token: 0x06000D79 RID: 3449 RVA: 0x0002439F File Offset: 0x0002259F
		public DelegateCommand OnNetworkProblem { get; private set; }

		// Token: 0x06000D7A RID: 3450 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNetworkProblemCommand()
		{
			return true;
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x000243A8 File Offset: 0x000225A8
		private void OnNetworkProblemCommand()
		{
			this.IsNetworkProblemOpen = true;
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06000D7C RID: 3452 RVA: 0x000243B1 File Offset: 0x000225B1
		// (set) Token: 0x06000D7D RID: 3453 RVA: 0x000243B9 File Offset: 0x000225B9
		public DelegateCommand<object> OnSavePassword { get; private set; }

		// Token: 0x06000D7E RID: 3454 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSavePasswordCommand(object parameter)
		{
			return true;
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x000243C4 File Offset: 0x000225C4
		private void OnSavePasswordCommand(object parameter)
		{
			TransferEverythingProgressPageViewModel.<OnSavePasswordCommand>d__147 <OnSavePasswordCommand>d__;
			<OnSavePasswordCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSavePasswordCommand>d__.<>4__this = this;
			<OnSavePasswordCommand>d__.parameter = parameter;
			<OnSavePasswordCommand>d__.<>1__state = -1;
			<OnSavePasswordCommand>d__.<>t__builder.Start<TransferEverythingProgressPageViewModel.<OnSavePasswordCommand>d__147>(ref <OnSavePasswordCommand>d__);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x00024404 File Offset: 0x00022604
		private void OnProgressChanged(TransferProgressInfo progress)
		{
			if (!this._PopupDisplayed && this.policy.transferEverythingProgressPagePolicy.IsPageDisplayed && !this._navigationHelper.IsPlayingBackRecordedPolicy && !this.policy.SuppressMessageBoxes && !base.pcmoverEngine.IsRemoteUI)
			{
				this.IsPopupOpen = true;
				this._PopupDisplayed = true;
			}
			this.Progress = Tools.GetTotalUnloadProgress(this.Progress, progress);
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
				}
				else
				{
					this.CurrentItem = Tools.TranslateUICallback(progress.ProgressInfo.ItemCode, progress.ProgressInfo.Item);
				}
			}
			this._CalculatedSecondsRemaining = Tools.GetTimeRemaining(this.Progress, progress, this.migrationDefinition);
			this.UpdateTimeRemaining();
			this.migrationDefinition.TotalElapsedTransferTime = progress.ElapsedTime;
			if (this.SSLInfo == null)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					if (this.migrationDefinition.MigrationType == TransferMethodType.Image)
					{
						this.SSLInfo = base.pcmoverEngine.GetLocalSslInfo();
					}
					else
					{
						this.SSLInfo = base.pcmoverEngine.GetSslInfo();
					}
					this.eventAggregator.GetEvent<Events.SSLInfoChanged>().Publish();
				}, "OnProgressChanged");
			}
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x00024554 File Offset: 0x00022754
		private void OnTransferComplete(TransferCompleteInfo info)
		{
			TransferEverythingProgressPageViewModel.<OnTransferComplete>d__149 <OnTransferComplete>d__;
			<OnTransferComplete>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnTransferComplete>d__.<>4__this = this;
			<OnTransferComplete>d__.info = info;
			<OnTransferComplete>d__.<>1__state = -1;
			<OnTransferComplete>d__.<>t__builder.Start<TransferEverythingProgressPageViewModel.<OnTransferComplete>d__149>(ref <OnTransferComplete>d__);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x00024594 File Offset: 0x00022794
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.TransferProgress);
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_TransferEverythingProgressPage);
			this.progressSubscriptionToken = this.eventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Subscribe(new Action<TransferProgressInfo>(this.OnProgressChanged), ThreadOption.UIThread);
			this.transferCompleteSubscriptionToken = this.eventAggregator.GetEvent<EngineEvents.TransferComplete>().Subscribe(new Action<TransferCompleteInfo>(this.OnTransferComplete), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.AssignMissingPassword>().Subscribe(new Action<Events.MissingPasswordEventArgs>(this.OnAssignMissingPassword), ThreadOption.UIThread);
			this.ErrorRatio = 25.0;
			this._DisplayedSecondsRemaining = this._CalculatedSecondsRemaining;
			this.NetworkQualityTimer.Start();
			this.Update();
			if (!this._TransferInProgress)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this._ts.TraceInformation("Calling pcmoverEngine.StartTransfer");
					base.pcmoverEngine.StartTransfer();
					this._TransferInProgress = true;
					this.IsStopEnabled = true;
				}, "OnNavigatedTo");
			}
			if (this.migrationDefinition.IsResuming)
			{
				this.Resume();
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x00024698 File Offset: 0x00022898
		private void Update()
		{
			this.IsImageAssistMigration = (this.migrationDefinition.MigrationType == TransferMethodType.Image);
			this.IsProfileMigrator = this.migrationDefinition.IsSelfTransfer;
			this.ThisPC = (this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName2 : this.migrationDefinition.PCName1);
			this.TimeRemainingString = WizardModule.Properties.Resources.TEPP_TimeRemaining;
			this.ArrowUri = (this.migrationDefinition.IsThunderbolt ? "/WizardModule;component/Assets/tb-logo48.png" : "/WizardModule;component/Assets/RightArrow.png");
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (PcmBrandUI.Properties.Resources.Edition.ToLower().StartsWith("enterprise") || this.migrationDefinition.IsThunderbolt)
				{
					this.ShowNetworkQuality = false;
					return;
				}
				ConnectableMachine targetMachine = base.pcmoverEngine.TargetMachine;
				bool showNetworkQuality;
				if (targetMachine == null || targetMachine.Method != TransferMethodType.Network)
				{
					ConnectableMachine targetMachine2 = base.pcmoverEngine.TargetMachine;
					showNetworkQuality = (targetMachine2 != null && targetMachine2.Method == TransferMethodType.SSL);
				}
				else
				{
					showNetworkQuality = true;
				}
				this.ShowNetworkQuality = showNetworkQuality;
			}, "Update");
			if (this.IsImageAssistMigration)
			{
				this.OtherPC = WizardModule.Properties.Resources.APCO_Image;
				return;
			}
			this.OtherPC = (this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName1 : this.migrationDefinition.PCName2);
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x0002477C File Offset: 0x0002297C
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.NetworkQualityTimer.Stop();
			if (this.progressSubscriptionToken != null)
			{
				this.eventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Unsubscribe(this.progressSubscriptionToken);
			}
			if (this.transferCompleteSubscriptionToken != null)
			{
				this.eventAggregator.GetEvent<EngineEvents.TransferComplete>().Unsubscribe(this.transferCompleteSubscriptionToken);
			}
			this.eventAggregator.GetEvent<EngineEvents.AssignMissingPassword>().Unsubscribe(new Action<Events.MissingPasswordEventArgs>(this.OnAssignMissingPassword));
			this.policy.WriteProfile();
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x000247F8 File Offset: 0x000229F8
		private void OnAssignMissingPassword(Events.MissingPasswordEventArgs obj)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this._callbackHandler = obj.ResumeAction;
				this.MissingPasswordAccount = obj.User.AccountName;
				this.IsPasswordMismatch = false;
				this.IsPasswordPopupOpen = true;
			}, "OnAssignMissingPassword");
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00024838 File Offset: 0x00022A38
		private void OnAuthorizationErrorAsync(Events.AuthorizationErrorEventArgs args)
		{
			TransferEverythingProgressPageViewModel.<OnAuthorizationErrorAsync>d__155 <OnAuthorizationErrorAsync>d__;
			<OnAuthorizationErrorAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAuthorizationErrorAsync>d__.<>4__this = this;
			<OnAuthorizationErrorAsync>d__.args = args;
			<OnAuthorizationErrorAsync>d__.<>1__state = -1;
			<OnAuthorizationErrorAsync>d__.<>t__builder.Start<TransferEverythingProgressPageViewModel.<OnAuthorizationErrorAsync>d__155>(ref <OnAuthorizationErrorAsync>d__);
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00024878 File Offset: 0x00022A78
		private void NetworkQualityTimer_Tick(object sender, object e)
		{
			if (!this.ShowNetworkQuality)
			{
				return;
			}
			try
			{
				NetworkStatsData networkData = null;
				if (!base.pcmoverEngine.CatchCommEx(delegate
				{
					networkData = this.pcmoverEngine.NetworkStats;
				}, "NetworkQualityTimer_Tick"))
				{
					this.NetworkQualityTimer.Stop();
				}
				else if (networkData.TotalUDPBytes == 0UL)
				{
					this.ShowNetworkQuality = false;
				}
				else
				{
					int num = this.tickCount + 1;
					this.tickCount = num;
					if (num > 180)
					{
						this.lastTotalTries = networkData.TotalUDPTries;
						this.lastTotalPackets = networkData.TotalUDPPackets;
						this.tickCount = 0;
					}
					ulong num2 = networkData.TotalUDPTries - this.lastTotalTries;
					ulong num3 = networkData.TotalUDPPackets - this.lastTotalPackets;
					if (num3 > 0UL)
					{
						this.ErrorRatio = 97.0 - (num2 - num3);
						if (this.ErrorRatio < 2.0)
						{
							this.ErrorRatio = 2.0;
						}
						if (this.ErrorRatio > 97.0)
						{
							this.ErrorRatio = 2.0;
						}
						if (this.ShowNetworkQuality)
						{
							this.ShowNetworkErrorLink = (this.ErrorRatio <= 25.0);
						}
					}
					this.UpdateTimeRemaining();
				}
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "NetworkQualityTimer_Tick");
			}
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00024A0C File Offset: 0x00022C0C
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
				this.TimeRemainingString = string.Empty;
				return;
			}
			if (this.Progress > 50.0 && this._DisplayedSecondsRemaining < 121.0)
			{
				this.TimeRemaining = WizardModule.Properties.Resources.strTimeRemainingAlmostFinished;
				this.TimeRemainingString = string.Empty;
				return;
			}
			TimeSpan timeSpan = DateTime.Now - this._TimeRemainingChanged;
			if (Math.Abs(this._CalculatedSecondsRemaining - this._DisplayedSecondsRemaining) > 150.0)
			{
				this._DisplayedSecondsRemaining = this._CalculatedSecondsRemaining;
				this._TimeRemainingChanged = DateTime.Now;
			}
			else if (this._DisplayedSecondsRemaining > 10.0 && timeSpan.TotalMilliseconds > 1000.0)
			{
				this._DisplayedSecondsRemaining -= 1.0;
				this._TimeRemainingChanged = DateTime.Now;
			}
			else if (timeSpan.TotalMilliseconds > 4000.0)
			{
				if (this._DisplayedSecondsRemaining > 1.0)
				{
					this._DisplayedSecondsRemaining -= 1.0;
					this._TimeRemainingChanged = DateTime.Now;
				}
				else
				{
					this._DisplayedSecondsRemaining += 29.0;
					this._TimeRemainingChanged = DateTime.Now;
				}
			}
			this.TimeRemaining = new TimeSpan(0, 0, (int)this._DisplayedSecondsRemaining).ToString("hh\\:mm\\:ss");
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00024BCC File Offset: 0x00022DCC
		private void Resume()
		{
			this._ts.TraceInformation("Resuming on Transfer Progress Page");
			this._PopupDisplayed = true;
			if (this.migrationDefinition.ServiceData.Step != PcmoverTransferState.TransferStep.Done)
			{
				this.migrationDefinition.IsResuming = false;
				this._ts.TraceInformation("Transfer is still in progress. Turning off IsResuming.");
				base.pcmoverEngine.IsResuming = false;
			}
		}

		// Token: 0x04000445 RID: 1093
		private readonly IRegionManager regionManager;

		// Token: 0x04000446 RID: 1094
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000447 RID: 1095
		private NavigationContext navigationContext;

		// Token: 0x04000448 RID: 1096
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000449 RID: 1097
		private Action _callbackHandler;

		// Token: 0x0400044A RID: 1098
		private Action<bool> _activationCallbackHandler;

		// Token: 0x0400044B RID: 1099
		private SubscriptionToken progressSubscriptionToken;

		// Token: 0x0400044C RID: 1100
		private SubscriptionToken transferCompleteSubscriptionToken;

		// Token: 0x0400044D RID: 1101
		private readonly DispatcherTimer NetworkQualityTimer = new DispatcherTimer();

		// Token: 0x0400044E RID: 1102
		private double _DisplayedSecondsRemaining;

		// Token: 0x0400044F RID: 1103
		private double _CalculatedSecondsRemaining;

		// Token: 0x04000450 RID: 1104
		private DateTime _TimeRemainingChanged = DateTime.Now;

		// Token: 0x04000451 RID: 1105
		private const int tickWindow = 180;

		// Token: 0x04000452 RID: 1106
		private int tickCount = 180;

		// Token: 0x04000453 RID: 1107
		private ulong lastTotalPackets;

		// Token: 0x04000454 RID: 1108
		private ulong lastTotalTries;

		// Token: 0x04000455 RID: 1109
		private bool _TransferInProgress;

		// Token: 0x04000456 RID: 1110
		private bool _PopupDisplayed;

		// Token: 0x04000457 RID: 1111
		private readonly DefaultPolicy policy;

		// Token: 0x04000458 RID: 1112
		private readonly LlTraceSource _ts;

		// Token: 0x04000459 RID: 1113
		private bool _IsNetworkProblemOpen;

		// Token: 0x0400045A RID: 1114
		private bool _IsPopupOpen;

		// Token: 0x0400045B RID: 1115
		private string _OtherPC;

		// Token: 0x0400045C RID: 1116
		private string _ThisPC;

		// Token: 0x0400045D RID: 1117
		private string _CurrentCategory;

		// Token: 0x0400045E RID: 1118
		private string _CurrentItem;

		// Token: 0x0400045F RID: 1119
		private double _Progress;

		// Token: 0x04000460 RID: 1120
		private string _TimeRemaining;

		// Token: 0x04000461 RID: 1121
		private bool _IsPasswordMismatch;

		// Token: 0x04000462 RID: 1122
		private bool _IsPasswordPopupOpen;

		// Token: 0x04000463 RID: 1123
		private string _MissingPasswordAccount;

		// Token: 0x04000464 RID: 1124
		private bool _IsImageAssistMigration;

		// Token: 0x04000465 RID: 1125
		private bool _IsStopEnabled;

		// Token: 0x04000466 RID: 1126
		private bool _ShowNetworkQuality;

		// Token: 0x04000467 RID: 1127
		private bool _ShowNetworkErrorLink;

		// Token: 0x04000468 RID: 1128
		private double _ErrorRatio;

		// Token: 0x04000469 RID: 1129
		private bool _ShowEstimateTime;

		// Token: 0x0400046A RID: 1130
		private const int height = 15;

		// Token: 0x0400046B RID: 1131
		private const int beginHeight = 5;

		// Token: 0x0400046C RID: 1132
		private const int overWidth = 98;

		// Token: 0x0400046D RID: 1133
		private string _TimeRemainingString;

		// Token: 0x0400046E RID: 1134
		private bool _IsProgressSpinnerVisible;

		// Token: 0x0400046F RID: 1135
		private SslInfo _SSLInfo;

		// Token: 0x04000470 RID: 1136
		private bool _IsProfileMigrator;

		// Token: 0x04000471 RID: 1137
		private string _ArrowUri;
	}
}
