using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
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
	// Token: 0x02000070 RID: 112
	public class AdvancedOptionsViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x0000C4B3 File Offset: 0x0000A6B3
		private bool displayWarning
		{
			get
			{
				return Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowWarningPage);
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0000C4BF File Offset: 0x0000A6BF
		public AdvancedOptionsViewModel() : base(null, null, null)
		{
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0000C4E0 File Offset: 0x0000A6E0
		public AdvancedOptionsViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IReportGenerator reportGenerator, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this._reportGenerator = reportGenerator;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._wizardParameters = container.Resolve(Array.Empty<ResolverOverride>());
			this._navigationHelper = navigationHelper;
			if (!Enum.TryParse<Visibility>(ConfigHelper.GetStringSetting("RebootVisibility", "Collapsed"), true, out this._controlledRebootVisibility))
			{
				this._controlledRebootVisibility = Visibility.Collapsed;
			}
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand));
			this.OnAccept = new DelegateCommand(new Action(this.OnAcceptCommand));
			this.OnDecline = new DelegateCommand(new Action(this.OnDeclineCommand));
			this.OnReports = new DelegateCommand(new Action(this.OnReportsCommand));
			this.OnOpenReport = new DelegateCommand(new Action(this.OnOpenReportCommand));
			this.OnCancelReportList = new DelegateCommand(new Action(this.OnCancelReportListCommand));
			this.OnUndo = new DelegateCommand(new Action(this.OnUndoCommand));
			this.TestPopupCommand = new DelegateCommand(delegate()
			{
				this.IsTestPopupOpen = true;
			});
			this.ClosePopupCommand = new DelegateCommand(delegate()
			{
				this.IsTestPopupOpen = false;
			});
			this.TestWpfPopupCommand = new DelegateCommand(delegate()
			{
				this.IsTestWpfPopupOpen = true;
			});
			this.CloseWpfPopupCommand = new DelegateCommand(delegate()
			{
				this.IsTestWpfPopupOpen = false;
			});
			this.TestAppPopupCommand = new DelegateCommand(delegate()
			{
				this.IsTestAppPopupOpen = true;
			});
			this.CloseAppPopupCommand = new DelegateCommand(delegate()
			{
				this.IsTestAppPopupOpen = false;
			});
			this.TestMessageBoxCommand = new DelegateCommand(new Action(this.TestMessageBoxExecute));
			this.TestWpfMessageBoxCommand = new DelegateCommand(new Action(this.TestWpfMessageBoxExecute));
			this.ControlledRebootCommand = new DelegateCommand(new Action(this.ControlledRebootExecute));
			eventAggregator.GetEvent<Events.ChangedOptionSelections>().Subscribe(new Action<MigrationTypeOption>(this.OnSelectionChanged));
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000C71B File Offset: 0x0000A91B
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000C723 File Offset: 0x0000A923
		public MigrationTypeOption OptionSelection { get; set; }

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x0000C72C File Offset: 0x0000A92C
		// (set) Token: 0x06000558 RID: 1368 RVA: 0x0000C734 File Offset: 0x0000A934
		public bool IsFilesBasedEnabled
		{
			get
			{
				return this._IsFilesBasedEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsFilesBasedEnabled, value, "IsFilesBasedEnabled");
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0000C749 File Offset: 0x0000A949
		// (set) Token: 0x0600055A RID: 1370 RVA: 0x0000C751 File Offset: 0x0000A951
		public bool IsImageAssistEnabled
		{
			get
			{
				return this._IsImageAssistEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsImageAssistEnabled, value, "IsImageAssistEnabled");
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0000C766 File Offset: 0x0000A966
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x0000C76E File Offset: 0x0000A96E
		public bool IsUpgradeAssistEnabled
		{
			get
			{
				return this._IsUpgradeAssistEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsUpgradeAssistEnabled, value, "IsUpgradeAssistEnabled");
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0000C783 File Offset: 0x0000A983
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool IsProfileEnabled
		{
			get
			{
				return this._IsProfileEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsProfileEnabled, value, "IsProfileEnabled");
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0000C7A0 File Offset: 0x0000A9A0
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x0000C7A8 File Offset: 0x0000A9A8
		public bool IsTransferEnabled
		{
			get
			{
				return this._IsTransferEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsTransferEnabled, value, "IsTransferEnabled");
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0000C7BD File Offset: 0x0000A9BD
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x0000C7C5 File Offset: 0x0000A9C5
		public bool IsEULAOpen
		{
			get
			{
				return this._IsEULAOpen;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsEULAOpen, value, "IsEULAOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0000C7EB File Offset: 0x0000A9EB
		// (set) Token: 0x06000564 RID: 1380 RVA: 0x0000C7F3 File Offset: 0x0000A9F3
		public bool IsEULAAccepted
		{
			get
			{
				return this._IsEULAAccepted;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsEULAAccepted, value, "IsEULAAccepted");
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0000C808 File Offset: 0x0000AA08
		// (set) Token: 0x06000566 RID: 1382 RVA: 0x0000C810 File Offset: 0x0000AA10
		public bool IsReportsVisible
		{
			get
			{
				return this._IsReportsVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsReportsVisible, value, "IsReportsVisible");
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0000C825 File Offset: 0x0000AA25
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x0000C82D File Offset: 0x0000AA2D
		public bool IsUndoVisible
		{
			get
			{
				return this._IsUndoVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsUndoVisible, value, "IsUndoVisible");
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0000C842 File Offset: 0x0000AA42
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x0000C84A File Offset: 0x0000AA4A
		public bool IsSidebarVisible
		{
			get
			{
				return this._IsSidebarVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsSidebarVisible, value, "IsSidebarVisible");
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000C85F File Offset: 0x0000AA5F
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x0000C867 File Offset: 0x0000AA67
		public bool IsBackVisible
		{
			get
			{
				return this._IsBackVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsBackVisible, value, "IsBackVisible");
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x0000C87C File Offset: 0x0000AA7C
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x0000C884 File Offset: 0x0000AA84
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

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x0000C899 File Offset: 0x0000AA99
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x0000C8A1 File Offset: 0x0000AAA1
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

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000C8B6 File Offset: 0x0000AAB6
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x0000C8BE File Offset: 0x0000AABE
		public bool ShowReportList
		{
			get
			{
				return this.showReportList;
			}
			private set
			{
				this.SetProperty<bool>(ref this.showReportList, value, "ShowReportList");
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000C8D3 File Offset: 0x0000AAD3
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x0000C8DB File Offset: 0x0000AADB
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000575 RID: 1397 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, this._wizardModuleModule.WelcomeUri);
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0000C901 File Offset: 0x0000AB01
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x0000C909 File Offset: 0x0000AB09
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000578 RID: 1400 RVA: 0x0000C914 File Offset: 0x0000AB14
		private bool CanOnNextCommand()
		{
			if (this.selectionMade)
			{
				switch (this.OptionSelection)
				{
				case MigrationTypeOption.Migration:
					return this.IsTransferEnabled;
				case MigrationTypeOption.WinUpgrade:
					return this.IsUpgradeAssistEnabled;
				case MigrationTypeOption.Image:
					return this.IsImageAssistEnabled;
				case MigrationTypeOption.Profile:
					return this.IsProfileEnabled;
				case MigrationTypeOption.FileBased:
					return this.IsFilesBasedEnabled;
				}
			}
			return false;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000C974 File Offset: 0x0000AB74
		private void OnNextCommand()
		{
			AdvancedOptionsViewModel.<OnNextCommand>d__82 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<AdvancedOptionsViewModel.<OnNextCommand>d__82>(ref <OnNextCommand>d__);
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0000C9AB File Offset: 0x0000ABAB
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0000C9B3 File Offset: 0x0000ABB3
		public DelegateCommand OnAccept { get; private set; }

		// Token: 0x0600057C RID: 1404 RVA: 0x0000C9BC File Offset: 0x0000ABBC
		private void OnAcceptCommand()
		{
			this.IsEULAAccepted = true;
			Tools.SetEULAAccepted(true);
			this.IsEULAOpen = false;
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000C9D2 File Offset: 0x0000ABD2
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x0000C9DA File Offset: 0x0000ABDA
		public DelegateCommand OnDecline { get; private set; }

		// Token: 0x0600057F RID: 1407 RVA: 0x0000C9E4 File Offset: 0x0000ABE4
		private void OnDeclineCommand()
		{
			AdvancedOptionsViewModel.<OnDeclineCommand>d__92 <OnDeclineCommand>d__;
			<OnDeclineCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnDeclineCommand>d__.<>4__this = this;
			<OnDeclineCommand>d__.<>1__state = -1;
			<OnDeclineCommand>d__.<>t__builder.Start<AdvancedOptionsViewModel.<OnDeclineCommand>d__92>(ref <OnDeclineCommand>d__);
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x0000CA1B File Offset: 0x0000AC1B
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x0000CA23 File Offset: 0x0000AC23
		public DelegateCommand OnReports { get; private set; }

		// Token: 0x06000582 RID: 1410 RVA: 0x0000CA2C File Offset: 0x0000AC2C
		private void OnReportsCommand()
		{
			try
			{
				this.ReportsList = new ObservableCollection<Reports>();
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
				foreach (string path in list.ToArray().SelectMany((string f) => Directory.GetFiles(this._wizardParameters.ReportFolder, f)).ToArray<string>())
				{
					this.ReportsList.Add(new Reports(path));
				}
				this.ShowReportList = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0000CB20 File Offset: 0x0000AD20
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x0000CB28 File Offset: 0x0000AD28
		public DelegateCommand OnOpenReport { get; private set; }

		// Token: 0x06000585 RID: 1413 RVA: 0x0000CB31 File Offset: 0x0000AD31
		private void OnOpenReportCommand()
		{
			Reports currentSelectedReport = this.CurrentSelectedReport;
			if (currentSelectedReport != null)
			{
				currentSelectedReport.Open();
			}
			this.ShowReportList = false;
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x0000CB4B File Offset: 0x0000AD4B
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x0000CB53 File Offset: 0x0000AD53
		public DelegateCommand OnCancelReportList { get; private set; }

		// Token: 0x06000588 RID: 1416 RVA: 0x0000CB5C File Offset: 0x0000AD5C
		private void OnCancelReportListCommand()
		{
			this.ShowReportList = false;
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000CB65 File Offset: 0x0000AD65
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x0000CB6D File Offset: 0x0000AD6D
		public DelegateCommand OnUndo { get; private set; }

		// Token: 0x0600058B RID: 1419 RVA: 0x0000CB76 File Offset: 0x0000AD76
		private void OnUndoCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("UndoPage", UriKind.Relative));
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0000CB93 File Offset: 0x0000AD93
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x0000CB9B File Offset: 0x0000AD9B
		public bool IsTestPopupOpen
		{
			get
			{
				return this._isTestPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._isTestPopupOpen, value, "IsTestPopupOpen");
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0000CBB0 File Offset: 0x0000ADB0
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
		public DelegateCommand TestPopupCommand { get; set; }

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0000CBC1 File Offset: 0x0000ADC1
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x0000CBC9 File Offset: 0x0000ADC9
		public DelegateCommand ClosePopupCommand { get; set; }

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0000CBD2 File Offset: 0x0000ADD2
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x0000CBDA File Offset: 0x0000ADDA
		public bool IsTestWpfPopupOpen
		{
			get
			{
				return this._isTestWpfPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._isTestWpfPopupOpen, value, "IsTestWpfPopupOpen");
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x0000CBEF File Offset: 0x0000ADEF
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x0000CBF7 File Offset: 0x0000ADF7
		public DelegateCommand TestWpfPopupCommand { get; set; }

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0000CC00 File Offset: 0x0000AE00
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x0000CC08 File Offset: 0x0000AE08
		public DelegateCommand CloseWpfPopupCommand { get; set; }

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x0000CC11 File Offset: 0x0000AE11
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0000CC19 File Offset: 0x0000AE19
		public bool IsTestAppPopupOpen
		{
			get
			{
				return this._isTestAppPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._isTestAppPopupOpen, value, "IsTestAppPopupOpen");
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0000CC2E File Offset: 0x0000AE2E
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x0000CC36 File Offset: 0x0000AE36
		public DelegateCommand TestAppPopupCommand { get; set; }

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0000CC3F File Offset: 0x0000AE3F
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0000CC47 File Offset: 0x0000AE47
		public DelegateCommand CloseAppPopupCommand { get; set; }

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x0000CC50 File Offset: 0x0000AE50
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x0000CC58 File Offset: 0x0000AE58
		public DelegateCommand TestMessageBoxCommand { get; set; }

		// Token: 0x060005A0 RID: 1440 RVA: 0x0000CC61 File Offset: 0x0000AE61
		private void TestMessageBoxExecute()
		{
			MessageBox.Show("Message Box");
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000CC6E File Offset: 0x0000AE6E
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0000CC76 File Offset: 0x0000AE76
		public DelegateCommand TestWpfMessageBoxCommand { get; set; }

		// Token: 0x060005A3 RID: 1443 RVA: 0x0000CC7F File Offset: 0x0000AE7F
		private void TestWpfMessageBoxExecute()
		{
			WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, "WPF Message Box", "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None);
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x0000CCA8 File Offset: 0x0000AEA8
		public Visibility ControlledRebootVisibility
		{
			get
			{
				return this._controlledRebootVisibility;
			}
			set
			{
				this.SetProperty<Visibility>(ref this._controlledRebootVisibility, value, "ControlledRebootVisibility");
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0000CCBD File Offset: 0x0000AEBD
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0000CCC5 File Offset: 0x0000AEC5
		public Visibility ReconnectedVisibility
		{
			get
			{
				return this._reconnectedVisibility;
			}
			set
			{
				this.SetProperty<Visibility>(ref this._reconnectedVisibility, value, "ReconnectedVisibility");
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0000CCDA File Offset: 0x0000AEDA
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x0000CCE2 File Offset: 0x0000AEE2
		public Visibility WaitingVisibility
		{
			get
			{
				return this._waitingVisibility;
			}
			set
			{
				this.SetProperty<Visibility>(ref this._waitingVisibility, value, "WaitingVisibility");
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0000CCF7 File Offset: 0x0000AEF7
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x0000CCFF File Offset: 0x0000AEFF
		public DelegateCommand ControlledRebootCommand { get; set; }

		// Token: 0x060005AC RID: 1452 RVA: 0x0000CD08 File Offset: 0x0000AF08
		private void ControlledRebootExecute()
		{
			this.ReconnectedVisibility = Visibility.Collapsed;
			this.ControlledRebootVisibility = Visibility.Collapsed;
			this.eventAggregator.GetEvent<Events.EngineReinitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnMachineAppeared));
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.Reboot(1000U);
			}, "ControlledRebootExecute");
			this.WaitingVisibility = Visibility.Visible;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0000CD64 File Offset: 0x0000AF64
		private void OnMachineAppeared(PcmoverServiceData data)
		{
			this.eventAggregator.GetEvent<Events.EngineReinitializedEvent>().Unsubscribe(new Action<PcmoverServiceData>(this.OnMachineAppeared));
			this.ReconnectedVisibility = Visibility.Visible;
			this.ControlledRebootVisibility = Visibility.Visible;
			this.WaitingVisibility = Visibility.Collapsed;
			if (data == null)
			{
				WPFMessageBox.ShowDialogAsyncNoSuppress(this.container, this.eventAggregator, "PCmover reinitialization failed", "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None);
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0000CDC4 File Offset: 0x0000AFC4
		private void OnSelectionChanged(MigrationTypeOption selection)
		{
			this.selectionMade = true;
			this.OptionSelection = selection;
			this.OnNext.RaiseCanExecuteChanged();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0000CDE0 File Offset: 0x0000AFE0
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && this._navigationHelper.PreviousPage == null)
			{
				this._navigationHelper.IsNavigatingBack = false;
			}
			else if (this._navigationHelper.IsNavigatingBack && !this.policy.advancedOptionsPagePolicy.IsPageDisplayed)
			{
				this.OnBack.Execute();
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.AdvancedOptions);
				if (!this.policy.StartOnAdvancedOptionsPage)
				{
					bool? singleMachineMode = this._wizardParameters.SingleMachineMode;
					bool flag = true;
					if (!(singleMachineMode.GetValueOrDefault() == flag & singleMachineMode != null))
					{
						this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_AdvancedOptionsPage);
						goto IL_6C;
					}
				}
				this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(PcmBrandUI.Properties.Resources.Title_WelcomePage);
				IL_6C:
				this.migrationDefinition.MigrationType = TransferMethodType.None;
				this.IsFilesBasedEnabled = ((bool)base.pcmoverEngine.Settings["IsFilesBasedEnabled"] && base.pcmoverEngine.Policy.Connection.EnabledMethods.HasFlag(ConnectionPolicyMethods.File));
				this.IsUpgradeAssistEnabled = (bool)base.pcmoverEngine.Settings["IsUAEnabled"];
				bool isProfileEnabled;
				if (Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowProfileMigrator))
				{
					MachineData thisMachine = base.pcmoverEngine.ThisMachine;
					if (thisMachine != null && thisMachine.IsEngineRunningAsAdmin)
					{
						isProfileEnabled = base.pcmoverEngine.Policy.Connection.EnabledMethods.HasFlag(ConnectionPolicyMethods.Self);
						goto IL_131;
					}
				}
				isProfileEnabled = false;
				IL_131:
				this.IsProfileEnabled = isProfileEnabled;
				bool flag2 = (base.pcmoverEngine.Policy.Connection.EnabledMethods & (ConnectionPolicyMethods.Network | ConnectionPolicyMethods.Udp | ConnectionPolicyMethods.Usb)) > ConnectionPolicyMethods.None;
				bool isTransferEnabled;
				if (flag2)
				{
					bool? singleMachineMode = this._wizardParameters.SingleMachineMode;
					bool flag = true;
					isTransferEnabled = !(singleMachineMode.GetValueOrDefault() == flag & singleMachineMode != null);
				}
				else
				{
					isTransferEnabled = false;
				}
				this.IsTransferEnabled = isTransferEnabled;
				try
				{
					this.IsImageAssistEnabled = (Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowImageDriveAsst) && base.pcmoverEngine.Policy.Connection.EnabledMethods.HasFlag(ConnectionPolicyMethods.Image) && base.pcmoverEngine.ThisMachine != null && base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin);
				}
				catch (FormatException)
				{
					this.IsImageAssistEnabled = ((bool)base.pcmoverEngine.Settings["IsIAEnabled"] && base.pcmoverEngine.Policy.Connection.EnabledMethods.HasFlag(ConnectionPolicyMethods.Image));
				}
				if (this.policy.getInstalledPagePolicy.GiIsEULAAccepted != DefaultPolicy.Tristate.Null)
				{
					this.IsEULAAccepted = (this.policy.getInstalledPagePolicy.GiIsEULAAccepted == DefaultPolicy.Tristate.True);
				}
				else
				{
					this.IsEULAAccepted = Tools.IsEULAAccepted();
				}
				this.IsBackVisible = !this.policy.StartOnAdvancedOptionsPage;
				this.IsUndoVisible = ((DateTime.Now - base.pcmoverEngine.UndoTime).Days < 30);
				if (this.policy.ShowReportsButton != DefaultPolicy.Tristate.Null)
				{
					this.IsReportsVisible = (this.policy.ShowReportsButton == DefaultPolicy.Tristate.True);
				}
				else
				{
					this.IsReportsVisible = this.migrationDefinition.ShowReports;
				}
				this.IsSidebarVisible = (this.policy.StartOnAdvancedOptionsPage && (this.IsReportsVisible || this.IsUndoVisible));
				this.OnNext.RaiseCanExecuteChanged();
				if (this.migrationDefinition.IsResuming)
				{
					this.Resume();
					return;
				}
				if (!string.IsNullOrWhiteSpace(this._wizardParameters.VanFile) && this.IsFilesBasedEnabled)
				{
					this.OptionSelection = MigrationTypeOption.FileBased;
					this.OnNext.Execute();
					return;
				}
				if (base.pcmoverEngine.Policy.MigrationType.DefaultOption != MigrationTypeOption.Nothing)
				{
					this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(base.pcmoverEngine.Policy.MigrationType.DefaultOption);
					if ((this._navigationHelper.IsPlayingBackRecordedPolicy || !this.policy.advancedOptionsPagePolicy.IsPageDisplayed) && this.OnNext.CanExecute())
					{
						this.OnNext.Execute();
					}
				}
			}, "OnNavigatedTo");
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000CE68 File Offset: 0x0000B068
		public bool IsValidOption()
		{
			if (PcmBrandUI.Properties.Resources.Edition == "Pro" && PcmBrandUI.Properties.Resources.OEM == "LG")
			{
				try
				{
					if (!Tools.IsLG(base.pcmoverEngine))
					{
						base.pcmoverEngine.Ts.TraceInformation("Transfer requirements for LG not met.");
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, PcmBrandUI.Properties.Resources.FPP_InvalidMachinePair, PcmBrandUI.Properties.Resources.FPP_InvalidMachinePairCaption, PopupEvents.MBType.MB_OK, MessageBoxImage.Exclamation, MessageBoxResult.None).ConfigureAwait(false);
						return false;
					}
				}
				catch
				{
				}
				return true;
			}
			return true;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0000CEFC File Offset: 0x0000B0FC
		private void Resume()
		{
			switch (this.migrationDefinition.ServiceData.TransferType)
			{
			case PcmoverTransferState.TransferTypeEnum.Unknown:
				return;
			case PcmoverTransferState.TransferTypeEnum.Image:
				this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.Image);
				break;
			case PcmoverTransferState.TransferTypeEnum.Profile:
				this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.Profile);
				break;
			case PcmoverTransferState.TransferTypeEnum.File:
				this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.FileBased);
				break;
			}
			this.OnNext.Execute();
		}

		// Token: 0x04000105 RID: 261
		private readonly IRegionManager regionManager;

		// Token: 0x04000106 RID: 262
		private readonly IReportGenerator _reportGenerator;

		// Token: 0x04000107 RID: 263
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000108 RID: 264
		private readonly DefaultPolicy policy;

		// Token: 0x04000109 RID: 265
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x0400010A RID: 266
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x0400010B RID: 267
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x0400010C RID: 268
		private bool selectionMade;

		// Token: 0x0400010E RID: 270
		private bool _IsFilesBasedEnabled;

		// Token: 0x0400010F RID: 271
		private bool _IsImageAssistEnabled;

		// Token: 0x04000110 RID: 272
		private bool _IsUpgradeAssistEnabled;

		// Token: 0x04000111 RID: 273
		private bool _IsProfileEnabled;

		// Token: 0x04000112 RID: 274
		private bool _IsTransferEnabled;

		// Token: 0x04000113 RID: 275
		private bool _IsEULAOpen;

		// Token: 0x04000114 RID: 276
		private bool _IsEULAAccepted;

		// Token: 0x04000115 RID: 277
		private bool _IsReportsVisible;

		// Token: 0x04000116 RID: 278
		private bool _IsUndoVisible;

		// Token: 0x04000117 RID: 279
		private bool _IsSidebarVisible;

		// Token: 0x04000118 RID: 280
		private bool _IsBackVisible;

		// Token: 0x04000119 RID: 281
		private ObservableCollection<Reports> _ReportsList;

		// Token: 0x0400011A RID: 282
		private Reports _CurrentSelectedReport;

		// Token: 0x0400011B RID: 283
		private bool showReportList;

		// Token: 0x04000124 RID: 292
		private bool _isTestPopupOpen;

		// Token: 0x04000127 RID: 295
		private bool _isTestWpfPopupOpen;

		// Token: 0x0400012A RID: 298
		private bool _isTestAppPopupOpen;

		// Token: 0x0400012F RID: 303
		private Visibility _controlledRebootVisibility = Visibility.Collapsed;

		// Token: 0x04000130 RID: 304
		private Visibility _reconnectedVisibility = Visibility.Collapsed;

		// Token: 0x04000131 RID: 305
		private Visibility _waitingVisibility = Visibility.Collapsed;
	}
}
