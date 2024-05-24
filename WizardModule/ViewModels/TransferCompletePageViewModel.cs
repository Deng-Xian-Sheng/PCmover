using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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
	// Token: 0x02000097 RID: 151
	public class TransferCompletePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000C90 RID: 3216 RVA: 0x000222BC File Offset: 0x000204BC
		public TransferCompletePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IReportGenerator reportGenerator, IMigrationDefinition migration, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this._reportGenerator = reportGenerator;
			this.migrationDefinition = migration;
			this.policy = policy;
			this.OnFinish = new DelegateCommand(new Action(this.OnFinishCommand), new Func<bool>(this.CanOnFinishCommand));
			this.OnFinishPopup = new DelegateCommand(new Action(this.OnFinishPopupCommand), new Func<bool>(this.CanOnFinishPopupCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
			this.OnViewDetails = new DelegateCommand(new Action(this.OnViewDetailsCommand), new Func<bool>(this.CanOnViewDetailsCommand));
			this.OnNextSteps = new DelegateCommand(new Action(this.OnNextStepsCommand), new Func<bool>(this.CanOnNextStepsCommand));
			this.OnOpenReport = new DelegateCommand(new Action(this.OnOpenReportCommand), new Func<bool>(this.CanOnOpenReportCommand));
			this.OnCancelReportList = new DelegateCommand(new Action(this.OnCancelReportListCommand), new Func<bool>(this.CanOnCancelReportListCommand));
			this.DeleteVan = new DelegateCommand(new Action(this.OnDeleteVan), new Func<bool>(this.CanOnDeleteVan));
			this.ReportsList = new ObservableCollection<Reports>();
			this.IsProfileMigrator = this.migrationDefinition.IsSelfTransfer;
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x00022426 File Offset: 0x00020626
		// (set) Token: 0x06000C92 RID: 3218 RVA: 0x0002242E File Offset: 0x0002062E
		public double FormattedTransferSize
		{
			get
			{
				return this._FormattedTransferSize;
			}
			set
			{
				this.SetProperty<double>(ref this._FormattedTransferSize, value, "FormattedTransferSize");
			}
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06000C93 RID: 3219 RVA: 0x00022443 File Offset: 0x00020643
		// (set) Token: 0x06000C94 RID: 3220 RVA: 0x0002244B File Offset: 0x0002064B
		public string TransferTime
		{
			get
			{
				return this._TransferTime;
			}
			set
			{
				this.SetProperty<string>(ref this._TransferTime, value, "TransferTime");
			}
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x00022460 File Offset: 0x00020660
		// (set) Token: 0x06000C96 RID: 3222 RVA: 0x00022468 File Offset: 0x00020668
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

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x0002247D File Offset: 0x0002067D
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x00022485 File Offset: 0x00020685
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

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0002249A File Offset: 0x0002069A
		// (set) Token: 0x06000C9A RID: 3226 RVA: 0x000224A2 File Offset: 0x000206A2
		public bool IsFinishPopupOpen
		{
			get
			{
				return this._IsFinishPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsFinishPopupOpen, value, "IsFinishPopupOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x000224C8 File Offset: 0x000206C8
		// (set) Token: 0x06000C9C RID: 3228 RVA: 0x000224D0 File Offset: 0x000206D0
		public bool IsRestartEnabled
		{
			get
			{
				return this._IsRestartEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsRestartEnabled, value, "IsRestartEnabled");
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x000224E5 File Offset: 0x000206E5
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x000224ED File Offset: 0x000206ED
		public bool IsUploadAppDataEnabled
		{
			get
			{
				return this._IsUploadAppDataEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsUploadAppDataEnabled, value, "IsUploadAppDataEnabled");
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00022502 File Offset: 0x00020702
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x0002250A File Offset: 0x0002070A
		public bool ShowUploadAppData
		{
			get
			{
				return this._ShowUploadAppData;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowUploadAppData, value, "ShowUploadAppData");
			}
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0002251F File Offset: 0x0002071F
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x00022527 File Offset: 0x00020727
		public bool IsOld
		{
			get
			{
				return this._IsOld;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsOld, value, "IsOld");
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0002253C File Offset: 0x0002073C
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x00022544 File Offset: 0x00020744
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

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x00022559 File Offset: 0x00020759
		// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x00022561 File Offset: 0x00020761
		public bool IsFilesBasedMigration
		{
			get
			{
				return this._IsFilesBasedMigration;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsFilesBasedMigration, value, "IsFilesBasedMigration");
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x00022576 File Offset: 0x00020776
		// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x0002257E File Offset: 0x0002077E
		public bool IsPartialMigration
		{
			get
			{
				return this._IsPartialMigration;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsPartialMigration, value, "IsPartialMigration");
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00022593 File Offset: 0x00020793
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x0002259B File Offset: 0x0002079B
		public ObservableCollection<Reports> ReportsList
		{
			get
			{
				return this._ReportsList;
			}
			private set
			{
				this.SetProperty<ObservableCollection<Reports>>(ref this._ReportsList, value, "ReportsList");
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x000225B0 File Offset: 0x000207B0
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x000225B8 File Offset: 0x000207B8
		public Reports CurrentSelectedReport
		{
			get
			{
				return this._CurrentSelectedReport;
			}
			set
			{
				this.SetProperty<Reports>(ref this._CurrentSelectedReport, value, "CurrentSelectedReport");
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x000225CD File Offset: 0x000207CD
		// (set) Token: 0x06000CAE RID: 3246 RVA: 0x000225D5 File Offset: 0x000207D5
		public bool ShowReportList
		{
			get
			{
				return this.showReportList;
			}
			set
			{
				this.SetProperty<bool>(ref this.showReportList, value, "ShowReportList");
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x000225EA File Offset: 0x000207EA
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x000225F2 File Offset: 0x000207F2
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

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00022607 File Offset: 0x00020807
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x0002260F File Offset: 0x0002080F
		public bool ShowDeleteVan
		{
			get
			{
				return this._ShowDeleteVan;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowDeleteVan, value, "ShowDeleteVan");
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x00022624 File Offset: 0x00020824
		// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x0002262C File Offset: 0x0002082C
		public bool ShowViewReports
		{
			get
			{
				return this._ShowViewReports;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowViewReports, value, "ShowViewReports");
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x00022641 File Offset: 0x00020841
		// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x00022649 File Offset: 0x00020849
		public DelegateCommand OnFinish { get; private set; }

		// Token: 0x06000CB7 RID: 3255 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnFinishCommand()
		{
			return true;
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x00022654 File Offset: 0x00020854
		private void OnFinishCommand()
		{
			if (this._IsCloseInProgress)
			{
				return;
			}
			this._IsCloseInProgress = true;
			this.policy.enginePolicy.DoneMigration.Reboot.Value = new bool?(this.IsRestartEnabled);
			this.policy.enginePolicy.DoneMigration.UploadReport.Value = new bool?(this.IsUploadAppDataEnabled);
			this.policy.IsComplete = DefaultPolicy.Tristate.True;
			this.policy.WriteProfile();
			if (!base.pcmoverEngine.IsRemoteUI)
			{
				Tools.RemovePCmoverPopupFromRunKey();
			}
			if (this.IsOld)
			{
				this.CloseApp(0);
				return;
			}
			if (this.IsUploadAppDataEnabled)
			{
				try
				{
					base.pcmoverEngine.UploadApplicationReport();
				}
				catch
				{
				}
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (base.pcmoverEngine.GetDownloadManager() != null && !Tools.WillDownloadManagerRunAfterReboot() && !this.policy.SupressOffers)
				{
					Tools.Init3rdPartyApps();
				}
				if (this.IsRestartEnabled && !DefaultPolicy.InDebugMode)
				{
					base.pcmoverEngine.Reboot(2U);
					this.CloseApp(3);
					return;
				}
				this.CloseApp(0);
			}, "OnFinishCommand");
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x0002273C File Offset: 0x0002093C
		// (set) Token: 0x06000CBA RID: 3258 RVA: 0x00022744 File Offset: 0x00020944
		public DelegateCommand OnViewDetails { get; private set; }

		// Token: 0x06000CBB RID: 3259 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnViewDetailsCommand()
		{
			return true;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x00022750 File Offset: 0x00020950
		private void OnViewDetailsCommand()
		{
			try
			{
				this.ReportsList.Clear();
				List<string> list = new List<string>();
				if (this._reportGenerator.ShouldCreatePdfReports)
				{
					list.Add("*.pdf");
				}
				if (PcmBrandUI.Properties.Resources.Edition.StartsWith("Enterprise") || PcmBrandUI.Properties.Resources.Edition.ToLower() == "business")
				{
					if (this._reportGenerator.ShouldCreateCsvReports)
					{
						list.Add("*.csv");
					}
				}
				else if (list.Count == 0 && this._reportGenerator.ShouldCreateCsvReports)
				{
					list.Add("*.csv");
				}
				foreach (string path in list.ToArray().SelectMany((string f) => Directory.GetFiles(this.container.Resolve(Array.Empty<ResolverOverride>()).ReportFolder, f)).ToArray<string>())
				{
					this.ReportsList.Add(new Reports(path));
				}
				this.ShowReportList = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00022844 File Offset: 0x00020A44
		// (set) Token: 0x06000CBE RID: 3262 RVA: 0x0002284C File Offset: 0x00020A4C
		public DelegateCommand OnOpenReport { get; private set; }

		// Token: 0x06000CBF RID: 3263 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnOpenReportCommand()
		{
			return true;
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00022855 File Offset: 0x00020A55
		private void OnOpenReportCommand()
		{
			Reports currentSelectedReport = this.CurrentSelectedReport;
			if (currentSelectedReport != null)
			{
				currentSelectedReport.Open();
			}
			this.ShowReportList = false;
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x0002286F File Offset: 0x00020A6F
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x00022877 File Offset: 0x00020A77
		public DelegateCommand OnCancelReportList { get; private set; }

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelReportListCommand()
		{
			return true;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00022880 File Offset: 0x00020A80
		private void OnCancelReportListCommand()
		{
			this.ShowReportList = false;
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x00022889 File Offset: 0x00020A89
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x00022891 File Offset: 0x00020A91
		public DelegateCommand OnNextSteps { get; private set; }

		// Token: 0x06000CC7 RID: 3271 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextStepsCommand()
		{
			return true;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x0002289A File Offset: 0x00020A9A
		private void OnNextStepsCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("NextStepsPage", UriKind.Relative));
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x000228B7 File Offset: 0x00020AB7
		// (set) Token: 0x06000CCA RID: 3274 RVA: 0x000228BF File Offset: 0x00020ABF
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000CCB RID: 3275 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000228C8 File Offset: 0x00020AC8
		private void OnCancelCommand()
		{
			this.IsFinishPopupOpen = false;
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x000228D1 File Offset: 0x00020AD1
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x000228D9 File Offset: 0x00020AD9
		public DelegateCommand OnFinishPopup { get; private set; }

		// Token: 0x06000CCF RID: 3279 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnFinishPopupCommand()
		{
			return true;
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000228E2 File Offset: 0x00020AE2
		private void OnFinishPopupCommand()
		{
			bool isUploadAppDataEnabled = this.IsUploadAppDataEnabled;
			bool isRestartEnabled = this.IsRestartEnabled;
			this.CloseApp(0);
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x000228F9 File Offset: 0x00020AF9
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x00022901 File Offset: 0x00020B01
		public DelegateCommand DeleteVan { get; private set; }

		// Token: 0x06000CD3 RID: 3283 RVA: 0x0002290A File Offset: 0x00020B0A
		private bool CanOnDeleteVan()
		{
			return !this._VanDeleted;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00022918 File Offset: 0x00020B18
		private void OnDeleteVan()
		{
			TransferCompletePageViewModel.<OnDeleteVan>d__127 <OnDeleteVan>d__;
			<OnDeleteVan>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnDeleteVan>d__.<>4__this = this;
			<OnDeleteVan>d__.<>1__state = -1;
			<OnDeleteVan>d__.<>t__builder.Start<TransferCompletePageViewModel.<OnDeleteVan>d__127>(ref <OnDeleteVan>d__);
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00022950 File Offset: 0x00020B50
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.TransferComplete);
			object obj = navigationContext.Parameters["IsPartial"];
			if (obj is bool)
			{
				bool isPartialMigration = (bool)obj;
				this.IsPartialMigration = isPartialMigration;
			}
			else
			{
				this.IsPartialMigration = false;
			}
			this.eventAggregator.GetEvent<Events.TransferStateChanged>().Publish(this.IsPartialMigration ? Events.TransferStateEnum.CompleteFailure : Events.TransferStateEnum.CompleteSuccess);
			this.Update();
			if (!base.pcmoverEngine.IsRemoteUI)
			{
				Tools.PlayAudio(Tools.Sounds.Notification);
			}
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x000229D4 File Offset: 0x00020BD4
		private void Update()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_TransferCompletePage);
				this.eventAggregator.GetEvent<Events.ShowSSLIcon>().Publish(false);
				if (this.migrationDefinition.IsResuming)
				{
					int handle = this.migrationDefinition.ServiceData.GetTask(PcmTaskType.Unload).Handle;
					TaskSummaryData taskSummaryData = base.pcmoverEngine.GetTaskSummaryData(handle, true);
					this.SetTransferTime(taskSummaryData.FinishTime - taskSummaryData.StartTime);
					TaskStats taskStats = base.pcmoverEngine.TaskGetStats(handle, true);
					this.FormattedTransferSize = taskStats.Disk.TotalSize;
				}
				else
				{
					this.FormattedTransferSize = base.pcmoverEngine.TotalTransferSize;
					this.SetTransferTime(base.pcmoverEngine.TransferInfo.ElapsedTime);
				}
				this.IsImageAssistMigration = (this.migrationDefinition.MigrationType == TransferMethodType.Image);
				this.IsFilesBasedMigration = (this.migrationDefinition.MigrationType == TransferMethodType.File);
				this.ThisPC = (this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName2 : this.migrationDefinition.PCName1);
				if (this.IsImageAssistMigration)
				{
					this.OtherPC = WizardModule.Properties.Resources.APCO_Image;
				}
				else
				{
					this.OtherPC = (this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName1 : this.migrationDefinition.PCName2);
				}
				this.IsRestartEnabled = base.pcmoverEngine.Policy.TransferComplete.Reboot;
				this.ShowUploadAppData = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_UploadAppReport);
				this.IsUploadAppDataEnabled = (this.ShowUploadAppData && base.pcmoverEngine.Policy.TransferComplete.UploadReport);
				this.IsOld = base.pcmoverEngine.ThisMachineIsOld;
				if (this.IsOld)
				{
					base.pcmoverEngine.PerformPostTransferActions(false);
				}
				if (!base.pcmoverEngine.Policy.Interactive.TransferComplete && this.CanOnFinishCommand())
				{
					this.OnFinishCommand();
				}
				this.ShowDeleteVan = (!this.IsOld && this.migrationDefinition.MigrationType == TransferMethodType.File && this.policy.ShowDelete && this.policy.enginePolicy.Connection.File.Settings.CloudBased != "Local");
				this.ShowViewReports = (!this.IsOld && this.policy.ShowReportsButton != DefaultPolicy.Tristate.False);
			}, "Update");
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x000229F4 File Offset: 0x00020BF4
		private void CloseApp(int Timeout = 0)
		{
			TransferCompletePageViewModel.<CloseApp>d__132 <CloseApp>d__;
			<CloseApp>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<CloseApp>d__.<>4__this = this;
			<CloseApp>d__.Timeout = Timeout;
			<CloseApp>d__.<>1__state = -1;
			<CloseApp>d__.<>t__builder.Start<TransferCompletePageViewModel.<CloseApp>d__132>(ref <CloseApp>d__);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00022A34 File Offset: 0x00020C34
		private void SetTransferTime(TimeSpan transferTime)
		{
			int num = transferTime.Days * 24 + transferTime.Hours;
			int minutes = transferTime.Minutes;
			int seconds = transferTime.Seconds;
			if (num > 0 || minutes > 0)
			{
				this.TransferTime = string.Concat(new string[]
				{
					num.ToString(),
					" ",
					WizardModule.Properties.Resources.strHours,
					", ",
					minutes.ToString(),
					" ",
					WizardModule.Properties.Resources.strMinutes
				});
				return;
			}
			this.TransferTime = seconds.ToString() + " " + WizardModule.Properties.Resources.strSeconds;
		}

		// Token: 0x040003FD RID: 1021
		private readonly IRegionManager regionManager;

		// Token: 0x040003FE RID: 1022
		private readonly IReportGenerator _reportGenerator;

		// Token: 0x040003FF RID: 1023
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000400 RID: 1024
		private bool _IsCloseInProgress;

		// Token: 0x04000401 RID: 1025
		private readonly DefaultPolicy policy;

		// Token: 0x04000402 RID: 1026
		private CancellationToken _CancellationToken;

		// Token: 0x04000403 RID: 1027
		private bool _VanDeleted;

		// Token: 0x04000404 RID: 1028
		private double _FormattedTransferSize;

		// Token: 0x04000405 RID: 1029
		private string _TransferTime;

		// Token: 0x04000406 RID: 1030
		private string _OtherPC;

		// Token: 0x04000407 RID: 1031
		private string _ThisPC;

		// Token: 0x04000408 RID: 1032
		private bool _IsFinishPopupOpen;

		// Token: 0x04000409 RID: 1033
		private bool _IsRestartEnabled;

		// Token: 0x0400040A RID: 1034
		private bool _IsUploadAppDataEnabled;

		// Token: 0x0400040B RID: 1035
		private bool _ShowUploadAppData;

		// Token: 0x0400040C RID: 1036
		private bool _IsOld;

		// Token: 0x0400040D RID: 1037
		private bool _IsImageAssistMigration;

		// Token: 0x0400040E RID: 1038
		private bool _IsFilesBasedMigration;

		// Token: 0x0400040F RID: 1039
		private bool _IsPartialMigration;

		// Token: 0x04000410 RID: 1040
		private ObservableCollection<Reports> _ReportsList;

		// Token: 0x04000411 RID: 1041
		private Reports _CurrentSelectedReport;

		// Token: 0x04000412 RID: 1042
		private bool showReportList;

		// Token: 0x04000413 RID: 1043
		private bool _IsProfileMigrator;

		// Token: 0x04000414 RID: 1044
		private bool _ShowDeleteVan;

		// Token: 0x04000415 RID: 1045
		private bool _ShowViewReports;
	}
}
