using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
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
	// Token: 0x0200009F RID: 159
	public class WelcomePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x0000C4B3 File Offset: 0x0000A6B3
		private bool displayWarning
		{
			get
			{
				return Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowWarningPage);
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x000261D8 File Offset: 0x000243D8
		public WelcomePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IReportGenerator reportGenerator, NavigationHelper navigationHelper, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this._reportGenerator = reportGenerator;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._wizardParameters = container.Resolve(Array.Empty<ResolverOverride>());
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnAdvanced = new DelegateCommand(new Action(this.OnAdvancedCommand), new Func<bool>(this.CanOnAdvancedCommand));
			this.OnGodMode = new DelegateCommand(new Action(this.OnGodModeCommand), new Func<bool>(this.CanOnGodModeCommand));
			this.OnUndo = new DelegateCommand(new Action(this.OnUndoCommand), new Func<bool>(this.CanOnUndoCommand));
			this.OnReports = new DelegateCommand(new Action(this.OnReportsCommand), new Func<bool>(this.CanOnReportsCommand));
			this.OnOpenReport = new DelegateCommand(new Action(this.OnOpenReportCommand), new Func<bool>(this.CanOnOpenReportCommand));
			this.OnCancelReportList = new DelegateCommand(new Action(this.OnCancelReportListCommand), new Func<bool>(this.CanOnCancelReportListCommand));
			this.OnUpsell = new DelegateCommand(new Action(this.OnUpsellCommand), new Func<bool>(this.CanOnUpsellCommand));
			this.OnInfoHyperlink = new DelegateCommand(new Action(this.OnInfoHyperlinkCommand), new Func<bool>(this.CanOnInfoHyperlinkCommand));
			eventAggregator.GetEvent<Events.UpdateTitle>().Publish(PcmBrandUI.Properties.Resources.Title_WelcomePage);
			eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Subscribe(new Action<bool>(this.OnMigrationDefinitionChange));
			eventAggregator.GetEvent<Events.EngineChanged>().Subscribe(new Action(this.OnEngineChanged));
			if (string.IsNullOrWhiteSpace(this._wizardParameters.Source))
			{
				eventAggregator.GetEvent<Events.EngineInitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnEngineInitialized), ThreadOption.UIThread);
			}
			this.migrationDefinition.ShowReports = false;
			this.nextEnabled = false;
			this.ReportsList = new ObservableCollection<Reports>();
			this.IsPro = true;
			this.IsUndoVisible = false;
			this.IsImageAssist = (PcmBrandUI.Properties.Resources.Edition.ToLower() == PcmoverEdition.ImageAssistant.ToString().ToLower());
			this.IsProfileMigrator = this.migrationDefinition.IsSelfTransfer;
			if (this.IsProfileMigrator || this.IsImageAssist)
			{
				this.IsPro = false;
			}
			if (this.IsProfileMigrator)
			{
				this.NextButtonText = WizardModule.Properties.Resources.NEXT;
			}
			else if (this.IsImageAssist)
			{
				this.NextButtonText = WizardModule.Properties.Resources.START;
			}
			else
			{
				this.NextButtonText = WizardModule.Properties.Resources.WP_TransferBetweenPC;
			}
			this.WelcomeText = PcmBrandUI.Properties.Resources.WP_Welcome;
			this.IsSeparatorVisible = (this.ShowAdvanced || this.ShowUpsell || this.IsReportsVisible);
		}

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x000264B2 File Offset: 0x000246B2
		// (set) Token: 0x06000E1C RID: 3612 RVA: 0x000264BA File Offset: 0x000246BA
		public bool IsReportsVisible
		{
			get
			{
				return this.isReportsVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this.isReportsVisible, value, "IsReportsVisible");
			}
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x000264CF File Offset: 0x000246CF
		// (set) Token: 0x06000E1E RID: 3614 RVA: 0x000264D7 File Offset: 0x000246D7
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

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x000264EC File Offset: 0x000246EC
		// (set) Token: 0x06000E20 RID: 3616 RVA: 0x000264F4 File Offset: 0x000246F4
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

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00026509 File Offset: 0x00024709
		// (set) Token: 0x06000E22 RID: 3618 RVA: 0x00026511 File Offset: 0x00024711
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

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x00026528 File Offset: 0x00024728
		public bool ShowAdvanced
		{
			get
			{
				bool result;
				try
				{
					result = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowAdvanced);
				}
				catch (FormatException)
				{
					result = true;
				}
				return result;
			}
		}

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00026558 File Offset: 0x00024758
		public bool ShowUpsell
		{
			get
			{
				bool result;
				try
				{
					result = (PcmBrandUI.Properties.Resources.Edition.ToLower() == "express" || PcmBrandUI.Properties.Resources.Edition.ToLower() == "home");
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x000265AC File Offset: 0x000247AC
		// (set) Token: 0x06000E26 RID: 3622 RVA: 0x000265B4 File Offset: 0x000247B4
		public bool IsPro
		{
			get
			{
				return this._IsPro;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsPro, value, "IsPro");
			}
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x000265C9 File Offset: 0x000247C9
		// (set) Token: 0x06000E28 RID: 3624 RVA: 0x000265D1 File Offset: 0x000247D1
		public bool IsImageAssist
		{
			get
			{
				return this._IsImageAssist;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsImageAssist, value, "IsImageAssist");
			}
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06000E29 RID: 3625 RVA: 0x000265E6 File Offset: 0x000247E6
		// (set) Token: 0x06000E2A RID: 3626 RVA: 0x000265EE File Offset: 0x000247EE
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

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06000E2B RID: 3627 RVA: 0x00026603 File Offset: 0x00024803
		// (set) Token: 0x06000E2C RID: 3628 RVA: 0x0002660B File Offset: 0x0002480B
		public bool IsSeparatorVisible
		{
			get
			{
				return this._IsSeparatorVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsSeparatorVisible, value, "IsSeparatorVisible");
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06000E2D RID: 3629 RVA: 0x00026620 File Offset: 0x00024820
		// (set) Token: 0x06000E2E RID: 3630 RVA: 0x00026628 File Offset: 0x00024828
		public string NextButtonText
		{
			get
			{
				return this._NextButtonText;
			}
			set
			{
				this.SetProperty<string>(ref this._NextButtonText, value, "NextButtonText");
			}
		}

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06000E2F RID: 3631 RVA: 0x0002663D File Offset: 0x0002483D
		// (set) Token: 0x06000E30 RID: 3632 RVA: 0x00026645 File Offset: 0x00024845
		public string WelcomeText
		{
			get
			{
				return this._WelcomeText;
			}
			set
			{
				this.SetProperty<string>(ref this._WelcomeText, value, "WelcomeText");
			}
		}

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06000E31 RID: 3633 RVA: 0x0002665A File Offset: 0x0002485A
		// (set) Token: 0x06000E32 RID: 3634 RVA: 0x00026662 File Offset: 0x00024862
		public bool IsUndoVisible
		{
			get
			{
				return this._IsUndoVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsUndoVisible, value, "IsUndoVisible");
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06000E33 RID: 3635 RVA: 0x00026677 File Offset: 0x00024877
		// (set) Token: 0x06000E34 RID: 3636 RVA: 0x0002667F File Offset: 0x0002487F
		public bool IsInfoPopupOpen
		{
			get
			{
				return this._IsInfoPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsInfoPopupOpen, value, "IsInfoPopupOpen");
			}
		}

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x00026694 File Offset: 0x00024894
		// (set) Token: 0x06000E36 RID: 3638 RVA: 0x0002669C File Offset: 0x0002489C
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000E37 RID: 3639 RVA: 0x000266A5 File Offset: 0x000248A5
		private bool CanOnNextCommand()
		{
			return this.nextEnabled;
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x000266B0 File Offset: 0x000248B0
		private void OnNextCommand()
		{
			WelcomePageViewModel.<OnNextCommand>d__68 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<WelcomePageViewModel.<OnNextCommand>d__68>(ref <OnNextCommand>d__);
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06000E39 RID: 3641 RVA: 0x000266E7 File Offset: 0x000248E7
		// (set) Token: 0x06000E3A RID: 3642 RVA: 0x000266EF File Offset: 0x000248EF
		public DelegateCommand OnAdvanced { get; private set; }

		// Token: 0x06000E3B RID: 3643 RVA: 0x000266A5 File Offset: 0x000248A5
		private bool CanOnAdvancedCommand()
		{
			return this.nextEnabled;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x000266F8 File Offset: 0x000248F8
		private void OnAdvancedCommand()
		{
			this.policy.welcomePagePolicy.WpAdvancedClicked = true;
			this.policy.welcomePagePolicy.WpNextClicked = false;
			this.policy.WriteProfile();
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("AdvancedOptions", UriKind.Relative));
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06000E3D RID: 3645 RVA: 0x0002674D File Offset: 0x0002494D
		// (set) Token: 0x06000E3E RID: 3646 RVA: 0x00026755 File Offset: 0x00024955
		public DelegateCommand OnUndo { get; private set; }

		// Token: 0x06000E3F RID: 3647 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnUndoCommand()
		{
			return true;
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x0002675E File Offset: 0x0002495E
		private void OnUndoCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("UndoPage", UriKind.Relative));
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06000E41 RID: 3649 RVA: 0x0002677B File Offset: 0x0002497B
		// (set) Token: 0x06000E42 RID: 3650 RVA: 0x00026783 File Offset: 0x00024983
		public DelegateCommand OnReports { get; private set; }

		// Token: 0x06000E43 RID: 3651 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnReportsCommand()
		{
			return true;
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x0002678C File Offset: 0x0002498C
		private void OnReportsCommand()
		{
			try
			{
				this.ReportsList.Clear();
				foreach (string path in this.GetFilters().SelectMany((string f) => Directory.GetFiles(this._wizardParameters.ReportFolder, f)).ToArray<string>())
				{
					this.ReportsList.Add(new Reports(path));
				}
				this.ShowReportList = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00026800 File Offset: 0x00024A00
		private string[] GetFilters()
		{
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
			list.Add("*.abc");
			return list.ToArray();
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06000E46 RID: 3654 RVA: 0x0002689D File Offset: 0x00024A9D
		// (set) Token: 0x06000E47 RID: 3655 RVA: 0x000268A5 File Offset: 0x00024AA5
		public DelegateCommand OnOpenReport { get; private set; }

		// Token: 0x06000E48 RID: 3656 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnOpenReportCommand()
		{
			return true;
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x000268AE File Offset: 0x00024AAE
		private void OnOpenReportCommand()
		{
			Reports currentSelectedReport = this.CurrentSelectedReport;
			if (currentSelectedReport != null)
			{
				currentSelectedReport.Open();
			}
			this.ShowReportList = false;
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06000E4A RID: 3658 RVA: 0x000268C8 File Offset: 0x00024AC8
		// (set) Token: 0x06000E4B RID: 3659 RVA: 0x000268D0 File Offset: 0x00024AD0
		public DelegateCommand OnCancelReportList { get; private set; }

		// Token: 0x06000E4C RID: 3660 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelReportListCommand()
		{
			return true;
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x000268D9 File Offset: 0x00024AD9
		private void OnCancelReportListCommand()
		{
			this.ShowReportList = false;
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06000E4E RID: 3662 RVA: 0x000268E2 File Offset: 0x00024AE2
		// (set) Token: 0x06000E4F RID: 3663 RVA: 0x000268EA File Offset: 0x00024AEA
		public DelegateCommand OnGodMode { get; private set; }

		// Token: 0x06000E50 RID: 3664 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnGodModeCommand()
		{
			return true;
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x000268F4 File Offset: 0x00024AF4
		private void OnGodModeCommand()
		{
			if ((Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
			{
				base.pcmoverEngine.GodMode = true;
				this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(true);
				this.regionManager.RequestNavigate("GodModeRegion", "GodMode");
				return;
			}
			base.pcmoverEngine.GodMode = false;
			this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(false);
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x0002695B File Offset: 0x00024B5B
		// (set) Token: 0x06000E53 RID: 3667 RVA: 0x00026963 File Offset: 0x00024B63
		public DelegateCommand OnUpsell { get; private set; }

		// Token: 0x06000E54 RID: 3668 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnUpsellCommand()
		{
			return true;
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x0002696C File Offset: 0x00024B6C
		private void OnUpsellCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.WP_UpsellURL));
			}
			catch
			{
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06000E56 RID: 3670 RVA: 0x000269A0 File Offset: 0x00024BA0
		// (set) Token: 0x06000E57 RID: 3671 RVA: 0x000269A8 File Offset: 0x00024BA8
		public DelegateCommand OnInfoHyperlink { get; private set; }

		// Token: 0x06000E58 RID: 3672 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnInfoHyperlinkCommand()
		{
			return true;
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x000269B4 File Offset: 0x00024BB4
		private void OnInfoHyperlinkCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.WP_InfoPopupURL));
				this.IsInfoPopupOpen = false;
			}
			catch
			{
			}
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x000269F0 File Offset: 0x00024BF0
		private void OnEngineInitialized(PcmoverServiceData serviceData)
		{
			WelcomePageViewModel.<OnEngineInitialized>d__118 <OnEngineInitialized>d__;
			<OnEngineInitialized>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnEngineInitialized>d__.<>4__this = this;
			<OnEngineInitialized>d__.serviceData = serviceData;
			<OnEngineInitialized>d__.<>1__state = -1;
			<OnEngineInitialized>d__.<>t__builder.Start<WelcomePageViewModel.<OnEngineInitialized>d__118>(ref <OnEngineInitialized>d__);
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00026A30 File Offset: 0x00024C30
		private void Resume()
		{
			switch (this.migrationDefinition.ServiceData.TransferType)
			{
			case PcmoverTransferState.TransferTypeEnum.Unknown:
				this.migrationDefinition.IsResuming = false;
				return;
			case PcmoverTransferState.TransferTypeEnum.PcToPc:
				this.OnNext.Execute();
				return;
			case PcmoverTransferState.TransferTypeEnum.Image:
			case PcmoverTransferState.TransferTypeEnum.Profile:
			case PcmoverTransferState.TransferTypeEnum.File:
				this.OnAdvanced.Execute();
				return;
			case PcmoverTransferState.TransferTypeEnum.Undo:
				this.OnUndo.Execute();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x00026A9D File Offset: 0x00024C9D
		private void OnMigrationDefinitionChange(bool obj)
		{
			this.IsReportsVisible = this.migrationDefinition.ShowReports;
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00026AB0 File Offset: 0x00024CB0
		private void OnEngineChanged()
		{
			WelcomePageViewModel.<OnEngineChanged>d__121 <OnEngineChanged>d__;
			<OnEngineChanged>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnEngineChanged>d__.<>4__this = this;
			<OnEngineChanged>d__.<>1__state = -1;
			<OnEngineChanged>d__.<>t__builder.Start<WelcomePageViewModel.<OnEngineChanged>d__121>(ref <OnEngineChanged>d__);
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x00026AE7 File Offset: 0x00024CE7
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.policy.WriteProfile();
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x00026AF4 File Offset: 0x00024CF4
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && this._navigationHelper.PreviousPage == null)
			{
				this._navigationHelper.IsNavigatingBack = false;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.Welcome);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(PcmBrandUI.Properties.Resources.Title_WelcomePage);
			this.migrationDefinition.MigrationType = TransferMethodType.None;
			this.ShowReportList = false;
			this.migrationDefinition.IsSelfTransfer = (PcmBrandUI.Properties.Resources.Edition == "ProfileMigrator");
			this.policy.welcomePagePolicy.WpNextClicked = false;
			this.policy.welcomePagePolicy.WpAdvancedClicked = false;
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00026BA4 File Offset: 0x00024DA4
		private bool ReportsExist()
		{
			bool result;
			try
			{
				result = (this.GetFilters().SelectMany((string f) => Directory.GetFiles(this._wizardParameters.ReportFolder, f)).ToArray<string>().Length != 0);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x00026BEC File Offset: 0x00024DEC
		private Task<bool> ShowPendingReboot(RebootPendingReasons reasons)
		{
			WelcomePageViewModel.<ShowPendingReboot>d__126 <ShowPendingReboot>d__;
			<ShowPendingReboot>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ShowPendingReboot>d__.<>4__this = this;
			<ShowPendingReboot>d__.reasons = reasons;
			<ShowPendingReboot>d__.<>1__state = -1;
			<ShowPendingReboot>d__.<>t__builder.Start<WelcomePageViewModel.<ShowPendingReboot>d__126>(ref <ShowPendingReboot>d__);
			return <ShowPendingReboot>d__.<>t__builder.Task;
		}

		// Token: 0x040004BC RID: 1212
		private readonly IRegionManager regionManager;

		// Token: 0x040004BD RID: 1213
		private readonly IReportGenerator _reportGenerator;

		// Token: 0x040004BE RID: 1214
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040004BF RID: 1215
		private DefaultPolicy policy;

		// Token: 0x040004C0 RID: 1216
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x040004C1 RID: 1217
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x040004C2 RID: 1218
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040004C3 RID: 1219
		private bool nextEnabled;

		// Token: 0x040004C4 RID: 1220
		private bool isReportsVisible;

		// Token: 0x040004C5 RID: 1221
		private bool showReportList;

		// Token: 0x040004C6 RID: 1222
		private ObservableCollection<Reports> _ReportsList;

		// Token: 0x040004C7 RID: 1223
		private Reports _CurrentSelectedReport;

		// Token: 0x040004C8 RID: 1224
		private bool _IsPro;

		// Token: 0x040004C9 RID: 1225
		private bool _IsImageAssist;

		// Token: 0x040004CA RID: 1226
		private bool _IsProfileMigrator;

		// Token: 0x040004CB RID: 1227
		private bool _IsSeparatorVisible;

		// Token: 0x040004CC RID: 1228
		private string _NextButtonText;

		// Token: 0x040004CD RID: 1229
		private string _WelcomeText;

		// Token: 0x040004CE RID: 1230
		private bool _IsUndoVisible;

		// Token: 0x040004CF RID: 1231
		private bool _IsInfoPopupOpen;
	}
}
