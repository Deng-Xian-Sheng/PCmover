using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;
using WizardModule.Views.Popups;

namespace WizardModule.ViewModels
{
	// Token: 0x02000099 RID: 153
	public class TransferEverythingPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000CE9 RID: 3305 RVA: 0x00022FE8 File Offset: 0x000211E8
		public TransferEverythingPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnViewDetails = new DelegateCommand(new Action(this.OnViewDetailsCommand), new Func<bool>(this.CanOnViewDetailsCommand));
			this.OnViewNextSteps = new DelegateCommand(new Action(this.OnViewNextStepsCommand), new Func<bool>(this.CanOnViewNextStepsCommand));
			this.OnPreviousTipSelected = new DelegateCommand(new Action(this.OnPreviousTipSelectedCommand), new Func<bool>(this.CanOnPreviousTipSelectedCommand));
			this.OnNextTipSelected = new DelegateCommand(new Action(this.OnNextTipSelectedCommand), new Func<bool>(this.CanOnNextTipSelectedCommand));
			this.OnShowAlertsPopup = new DelegateCommand(new Action(this.OnShowAlertsPopupCommand), new Func<bool>(this.CanOnShowAlertsPopupCommand));
			this.OnCustomize = new DelegateCommand<string>(new Action<string>(this.OnCustomizeCommand), new Func<string, bool>(this.CanOnCustomizeCommand));
			this.OnDrivespaceInfo = new DelegateCommand<string>(new Action<string>(this.OnDrivespaceInfoCommand), new Func<string, bool>(this.CanOnDrivespaceInfoCommand));
			eventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Subscribe(new Action<TaskStats>(this.OnAnalyzeComputer), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.AnalysisProgressChanged>().Subscribe(new Action<ProgressInfo>(this.OnAnalysisProgressChanged));
			this.IsBusy = true;
			this.TipIndex = 0;
			this.PercentDone = 0;
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

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00023200 File Offset: 0x00021400
		// (set) Token: 0x06000CEB RID: 3307 RVA: 0x00023208 File Offset: 0x00021408
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

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06000CEC RID: 3308 RVA: 0x0002321D File Offset: 0x0002141D
		// (set) Token: 0x06000CED RID: 3309 RVA: 0x00023225 File Offset: 0x00021425
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

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06000CEE RID: 3310 RVA: 0x0002323A File Offset: 0x0002143A
		// (set) Token: 0x06000CEF RID: 3311 RVA: 0x00023242 File Offset: 0x00021442
		public int PercentDone
		{
			get
			{
				return this._PercentDone;
			}
			set
			{
				this.SetProperty<int>(ref this._PercentDone, value, "PercentDone");
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x00023257 File Offset: 0x00021457
		// (set) Token: 0x06000CF1 RID: 3313 RVA: 0x0002325F File Offset: 0x0002145F
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

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x00023274 File Offset: 0x00021474
		// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x0002327C File Offset: 0x0002147C
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

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x000232D5 File Offset: 0x000214D5
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x000232DD File Offset: 0x000214DD
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
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x000232FD File Offset: 0x000214FD
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00023305 File Offset: 0x00021505
		public List<string> Tips { get; set; }

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x0002330E File Offset: 0x0002150E
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x00023316 File Offset: 0x00021516
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

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0002333C File Offset: 0x0002153C
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00023344 File Offset: 0x00021544
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

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x00023359 File Offset: 0x00021559
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x00023361 File Offset: 0x00021561
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

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00023376 File Offset: 0x00021576
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x0002337E File Offset: 0x0002157E
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

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x00023393 File Offset: 0x00021593
		// (set) Token: 0x06000D01 RID: 3329 RVA: 0x0002339B File Offset: 0x0002159B
		public string ReadyText
		{
			get
			{
				return this._ReadyText;
			}
			private set
			{
				this.SetProperty<string>(ref this._ReadyText, value, "ReadyText");
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x000233B0 File Offset: 0x000215B0
		// (set) Token: 0x06000D03 RID: 3331 RVA: 0x000233B8 File Offset: 0x000215B8
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

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x000233CD File Offset: 0x000215CD
		// (set) Token: 0x06000D05 RID: 3333 RVA: 0x000233D5 File Offset: 0x000215D5
		public bool IsBackButtonEnabled
		{
			get
			{
				return this._IsBackButtonEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBackButtonEnabled, value, "IsBackButtonEnabled");
				this.OnBack.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x000233F5 File Offset: 0x000215F5
		// (set) Token: 0x06000D07 RID: 3335 RVA: 0x000233FD File Offset: 0x000215FD
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

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00023412 File Offset: 0x00021612
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x0002341A File Offset: 0x0002161A
		public bool IsAlertEnabled
		{
			get
			{
				return this._IsAlertEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsAlertEnabled, value, "IsAlertEnabled");
				this.OnShowAlertsPopup.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x0002343A File Offset: 0x0002163A
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x00023442 File Offset: 0x00021642
		public bool ShowViewDetails
		{
			get
			{
				return this._ShowViewDetails;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowViewDetails, value, "ShowViewDetails");
			}
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x00023457 File Offset: 0x00021657
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x0002345F File Offset: 0x0002165F
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000D0E RID: 3342 RVA: 0x00023468 File Offset: 0x00021668
		private bool CanOnBackCommand()
		{
			return this.IsBackButtonEnabled;
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00023470 File Offset: 0x00021670
		private void OnBackCommand()
		{
			TransferEverythingPageViewModel.<OnBackCommand>d__80 <OnBackCommand>d__;
			<OnBackCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnBackCommand>d__.<>4__this = this;
			<OnBackCommand>d__.<>1__state = -1;
			<OnBackCommand>d__.<>t__builder.Start<TransferEverythingPageViewModel.<OnBackCommand>d__80>(ref <OnBackCommand>d__);
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x000234A7 File Offset: 0x000216A7
		// (set) Token: 0x06000D11 RID: 3345 RVA: 0x000234AF File Offset: 0x000216AF
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000D12 RID: 3346 RVA: 0x000234B8 File Offset: 0x000216B8
		private bool CanOnNextCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x000234C3 File Offset: 0x000216C3
		private void OnNextCommand()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				AuthorizationInfo authorizationInfo = base.pcmoverEngine.TaskGetAuthorizationInfo();
				if ((!authorizationInfo.IsAuthorized && authorizationInfo.IsPreValidated) || (!authorizationInfo.IsAuthorized && base.pcmoverEngine.Policy.Engine.GetSerialNumberFromServer))
				{
					NavigationParameters navigationParameters = new NavigationParameters();
					navigationParameters.Add("NextPage", "TransferEverythingProgressPage");
					navigationParameters.Add("ActivationRequired", true);
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LicensePage", UriKind.Relative), navigationParameters);
					return;
				}
				if (!authorizationInfo.IsAuthorized && !authorizationInfo.IsPreValidated)
				{
					base.pcmoverEngine.TaskPrepareAuthorization(base.pcmoverEngine.License);
				}
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferEverythingProgressPage", UriKind.Relative));
			}, "OnNextCommand");
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x000234E2 File Offset: 0x000216E2
		// (set) Token: 0x06000D15 RID: 3349 RVA: 0x000234EA File Offset: 0x000216EA
		public DelegateCommand OnViewDetails { get; private set; }

		// Token: 0x06000D16 RID: 3350 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnViewDetailsCommand()
		{
			return true;
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x000234F3 File Offset: 0x000216F3
		private void OnViewDetailsCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferSummaryPage", UriKind.Relative));
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00023510 File Offset: 0x00021710
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x00023518 File Offset: 0x00021718
		public DelegateCommand OnViewNextSteps { get; private set; }

		// Token: 0x06000D1A RID: 3354 RVA: 0x00023521 File Offset: 0x00021721
		private bool CanOnViewNextStepsCommand()
		{
			return false;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00023524 File Offset: 0x00021724
		private void OnViewNextStepsCommand()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x0002352B File Offset: 0x0002172B
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x00023533 File Offset: 0x00021733
		public DelegateCommand OnPreviousTipSelected { get; private set; }

		// Token: 0x06000D1E RID: 3358 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnPreviousTipSelectedCommand()
		{
			return true;
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0002353C File Offset: 0x0002173C
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

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x000235BC File Offset: 0x000217BC
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x000235C4 File Offset: 0x000217C4
		public DelegateCommand OnNextTipSelected { get; private set; }

		// Token: 0x06000D22 RID: 3362 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextTipSelectedCommand()
		{
			return true;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x000235D0 File Offset: 0x000217D0
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

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06000D24 RID: 3364 RVA: 0x0002364C File Offset: 0x0002184C
		// (set) Token: 0x06000D25 RID: 3365 RVA: 0x00023654 File Offset: 0x00021854
		public DelegateCommand OnShowAlertsPopup { get; private set; }

		// Token: 0x06000D26 RID: 3366 RVA: 0x0002365D File Offset: 0x0002185D
		private bool CanOnShowAlertsPopupCommand()
		{
			return this.IsAlertEnabled;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x0001345E File Offset: 0x0001165E
		private void OnShowAlertsPopupCommand()
		{
			this.eventAggregator.GetEvent<PopupEvents.ShowPopup>().Publish(new PopupEvents.ResolveInfo(typeof(InteractiveAlert), null));
		}

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06000D28 RID: 3368 RVA: 0x00023665 File Offset: 0x00021865
		public DelegateCommand<string> OnCustomize { get; }

		// Token: 0x06000D29 RID: 3369 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCustomizeCommand(string arg)
		{
			return true;
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0002366D File Offset: 0x0002186D
		private void OnCustomizeCommand(string customize)
		{
			if (Convert.ToBoolean(customize))
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LetMeChoosePage", UriKind.Relative));
			}
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00023692 File Offset: 0x00021892
		public DelegateCommand<string> OnDrivespaceInfo { get; }

		// Token: 0x06000D2C RID: 3372 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDrivespaceInfoCommand(string arg)
		{
			return true;
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x0002369C File Offset: 0x0002189C
		private void OnDrivespaceInfoCommand(string url)
		{
			try
			{
				Process.Start(new ProcessStartInfo(url));
			}
			catch
			{
			}
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x000236CC File Offset: 0x000218CC
		private void OnAnalysisProgressChanged(ProgressInfo progressInfo)
		{
			if (progressInfo.Percentage == 0)
			{
				this.PercentDone++;
			}
			this.PercentDone = Math.Max(this.PercentDone, (int)progressInfo.Percentage);
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x000236FC File Offset: 0x000218FC
		private void OnAnalyzeComputer(TaskStats stats)
		{
			TransferEverythingPageViewModel.<OnAnalyzeComputer>d__128 <OnAnalyzeComputer>d__;
			<OnAnalyzeComputer>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAnalyzeComputer>d__.<>4__this = this;
			<OnAnalyzeComputer>d__.stats = stats;
			<OnAnalyzeComputer>d__.<>1__state = -1;
			<OnAnalyzeComputer>d__.<>t__builder.Start<TransferEverythingPageViewModel.<OnAnalyzeComputer>d__128>(ref <OnAnalyzeComputer>d__);
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x0002373C File Offset: 0x0002193C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.transferEverythingPagePolicy.IsPageDisplayed && this.CanOnBackCommand())
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.TransferProgress);
			this.navigationContext = navigationContext;
			this.Update();
			if (this.migrationDefinition.IsResuming)
			{
				this.Resume();
				return;
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.SetControllerProperty(ControllerProperties.CustomizationScreen, CustomizationScreen.StartTransfer.ToString());
			}, "OnNavigatedTo");
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x000237CC File Offset: 0x000219CC
		private void Update()
		{
			try
			{
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_TransferEverythingPage);
				if (base.pcmoverEngine.MigrationItemsSelection == MigrationItemsOption.FilesAndSettings)
				{
					this.ReadyText = WizardModule.Properties.Resources.TEP_Ready1_FilesAndSettings;
				}
				else if (base.pcmoverEngine.MigrationItemsSelection == MigrationItemsOption.FilesOnly)
				{
					this.ReadyText = WizardModule.Properties.Resources.TEP_Ready1_Files;
				}
				else if (PcmBrandUI.Properties.Resources.Edition.ToLower() == "express" || PcmBrandUI.Properties.Resources.OEM.ToLower() == "nec")
				{
					this.ReadyText = WizardModule.Properties.Resources.TEP_Ready1_FilesAndSettings;
				}
				else
				{
					this.ReadyText = WizardModule.Properties.Resources.TEP_Ready1_Full;
				}
				this.IsImageAssistMigration = (this.migrationDefinition.MigrationType == TransferMethodType.Image);
				this.IsProfileMigrator = this.migrationDefinition.IsSelfTransfer;
				this.ThisPC = (this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName2 : this.migrationDefinition.PCName1);
				this.IsAlertEnabled = (base.pcmoverEngine.InteractiveDoneAlert != null);
				if (this.IsImageAssistMigration)
				{
					this.OtherPC = WizardModule.Properties.Resources.APCO_Image;
				}
				else
				{
					this.OtherPC = (this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName1 : this.migrationDefinition.PCName2);
				}
				if (!this.container.Resolve(Array.Empty<ResolverOverride>()).CompactUI)
				{
					this.TipText = this.Tips[0];
					this.tipTimer.Tick += new EventHandler(this.tipTimer_Tick);
					this.tipTimer.Start();
				}
				this.IsBackButtonEnabled = true;
				if (this.migrationDefinition.IsSelfTransfer || base.pcmoverEngine.IsScript)
				{
					this.ShowViewDetails = false;
				}
				else
				{
					this.ShowViewDetails = !this.policy.transferEverythingPagePolicy.HideViewDetails;
				}
				if (base.pcmoverEngine.Users != null)
				{
					if (base.pcmoverEngine.Users.Mappings.Any((UserMapping x) => x.MoveFiles))
					{
						this.SetMoveUsers(false);
						this.migrationDefinition.BuildChangelistsRequired = true;
					}
				}
				if (this.migrationDefinition.BuildChangelistsRequired || this.migrationDefinition.IsResuming)
				{
					this.IsBusy = true;
					this.PercentDone = 0;
					base.pcmoverEngine.Ts.TraceInformation("Calling StartBuildChangeLists");
					base.pcmoverEngine.StartBuildChangeLists();
					this.migrationDefinition.BuildChangelistsRequired = false;
				}
			}
			catch (SystemException ex) when (ex is CommunicationException || ex is TimeoutException)
			{
				base.pcmoverEngine.Ts.TraceException(ex, "Update");
				this.eventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Publish(ex);
			}
			catch (Exception ex2)
			{
				base.pcmoverEngine.Ts.TraceException(ex2, "Update");
				MessageBox.Show(ex2.Message + Environment.NewLine + ex2.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00023B0C File Offset: 0x00021D0C
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.tipTimer.Stop();
			this.policy.WriteProfile();
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00023B24 File Offset: 0x00021D24
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

		// Token: 0x06000D35 RID: 3381 RVA: 0x00023B70 File Offset: 0x00021D70
		private void SetMoveUsers(bool move)
		{
			Func<UserMapping, bool> <>9__1;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.AllowUndo = !move;
				this.pcmoverEngine.Ts.TraceInformation(string.Format("TransferEverythingPageViewModel: Setting AllowUndo to {0}", this.pcmoverEngine.AllowUndo));
				IEnumerable<UserMapping> mappings = this.pcmoverEngine.Users.Mappings;
				Func<UserMapping, bool> predicate;
				if ((predicate = <>9__1) == null)
				{
					predicate = (<>9__1 = ((UserMapping x) => x.MoveFiles != move));
				}
				foreach (UserMapping userMapping in mappings.Where(predicate))
				{
					userMapping.MoveFiles = move;
					this.pcmoverEngine.ChangeUserMapping(userMapping);
				}
			}, "SetMoveUsers");
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00023BB0 File Offset: 0x00021DB0
		private void Resume()
		{
			if (this.migrationDefinition.ServiceData.Step != PcmoverTransferState.TransferStep.Transferring && this.migrationDefinition.ServiceData.Step != PcmoverTransferState.TransferStep.Done)
			{
				this.migrationDefinition.IsResuming = false;
				base.pcmoverEngine.Ts.TraceInformation("TransferEverythingPageViewModel.Resume: Turning off IsResuming because the step is not Transferring");
				base.pcmoverEngine.IsResuming = false;
			}
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00023C10 File Offset: 0x00021E10
		private Task<bool> ShowInsufficientDriveSpacePopup(IEnumerable<DriveSpaceAndNeeded> drives, TaskStats stats)
		{
			TransferEverythingPageViewModel.<ShowInsufficientDriveSpacePopup>d__136 <ShowInsufficientDriveSpacePopup>d__;
			<ShowInsufficientDriveSpacePopup>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ShowInsufficientDriveSpacePopup>d__.<>4__this = this;
			<ShowInsufficientDriveSpacePopup>d__.drives = drives;
			<ShowInsufficientDriveSpacePopup>d__.stats = stats;
			<ShowInsufficientDriveSpacePopup>d__.<>1__state = -1;
			<ShowInsufficientDriveSpacePopup>d__.<>t__builder.Start<TransferEverythingPageViewModel.<ShowInsufficientDriveSpacePopup>d__136>(ref <ShowInsufficientDriveSpacePopup>d__);
			return <ShowInsufficientDriveSpacePopup>d__.<>t__builder.Task;
		}

		// Token: 0x04000425 RID: 1061
		private readonly IRegionManager regionManager;

		// Token: 0x04000426 RID: 1062
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000427 RID: 1063
		private NavigationContext navigationContext;

		// Token: 0x04000428 RID: 1064
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000429 RID: 1065
		private readonly DispatcherTimer tipTimer = new DispatcherTimer();

		// Token: 0x0400042A RID: 1066
		private readonly DefaultPolicy policy;

		// Token: 0x0400042B RID: 1067
		private string _OtherPC;

		// Token: 0x0400042C RID: 1068
		private string _ThisPC;

		// Token: 0x0400042D RID: 1069
		private int _PercentDone;

		// Token: 0x0400042E RID: 1070
		private string _TipText;

		// Token: 0x0400042F RID: 1071
		private int _TipIndex;

		// Token: 0x04000430 RID: 1072
		private bool _IsBusy;

		// Token: 0x04000432 RID: 1074
		private double _TransferSize;

		// Token: 0x04000433 RID: 1075
		private string _FormattedTransferSize;

		// Token: 0x04000434 RID: 1076
		private string _TransferTime;

		// Token: 0x04000435 RID: 1077
		private BitmapImage _TipImage;

		// Token: 0x04000436 RID: 1078
		private string _ReadyText;

		// Token: 0x04000437 RID: 1079
		private bool _IsImageAssistMigration;

		// Token: 0x04000438 RID: 1080
		private bool _IsBackButtonEnabled;

		// Token: 0x04000439 RID: 1081
		private bool _IsProfileMigrator;

		// Token: 0x0400043A RID: 1082
		private bool _IsAlertEnabled;

		// Token: 0x0400043B RID: 1083
		private bool _ShowViewDetails;
	}
}
