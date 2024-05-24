using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
	// Token: 0x02000085 RID: 133
	public class FilesBasedTransferPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060008A7 RID: 2215 RVA: 0x0001410C File Offset: 0x0001230C
		public FilesBasedTransferPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, IWizardParameters wizardParameters, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardParameters = wizardParameters;
			this._navigationHelper = navigationHelper;
			this.EnableNextButtonTimer = new DispatcherTimer
			{
				Interval = new TimeSpan(0, 0, 1)
			};
			this.EnableNextButtonTimer.Tick += delegate(object s, EventArgs e)
			{
				this.OnNext.RaiseCanExecuteChanged();
			};
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnBrowseOld = new DelegateCommand(new Action(this.OnBrowseOldCommand), new Func<bool>(this.CanOnBrowseOldCommand));
			this.OnBrowseNew = new DelegateCommand(new Action(this.OnBrowseNewCommand), new Func<bool>(this.CanOnBrowseNewCommand));
			this.CancelCloudVerification = new DelegateCommand(new Action(this.OnCancelCloudVerification), new Func<bool>(this.CanOnCancelCloudVerification));
			this.BrowseTextOld = (this._wizardParameters.CompactUI ? WizardModule.Properties.Resources.FBTP_WhereOld_Compact : WizardModule.Properties.Resources.FBTP_WhereOld);
			this.BrowseTextNew = WizardModule.Properties.Resources.FBTP_WhereNew;
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x00014253 File Offset: 0x00012453
		// (set) Token: 0x060008A9 RID: 2217 RVA: 0x0001425B File Offset: 0x0001245B
		public string TransferFile
		{
			get
			{
				return this._TransferFile;
			}
			set
			{
				this.SetProperty<string>(ref this._TransferFile, value, "TransferFile");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x0001427B File Offset: 0x0001247B
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x00014283 File Offset: 0x00012483
		public bool OldSelected
		{
			get
			{
				return this._OldSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._OldSelected, value, "OldSelected");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x000142A3 File Offset: 0x000124A3
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x000142AB File Offset: 0x000124AB
		public string BrowseTextOld
		{
			get
			{
				return this._BrowseTextOld;
			}
			set
			{
				this.SetProperty<string>(ref this._BrowseTextOld, value, "BrowseTextOld");
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x000142C0 File Offset: 0x000124C0
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x000142C8 File Offset: 0x000124C8
		public string BrowseTextNew
		{
			get
			{
				return this._BrowseTextNew;
			}
			set
			{
				this.SetProperty<string>(ref this._BrowseTextNew, value, "BrowseTextNew");
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x000142DD File Offset: 0x000124DD
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x000142E5 File Offset: 0x000124E5
		public bool IsCloudBased
		{
			get
			{
				return this._IsCloudBased;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCloudBased, value, "IsCloudBased");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00014305 File Offset: 0x00012505
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x0001430D File Offset: 0x0001250D
		public bool IsCloudVerificationPopupOpen
		{
			get
			{
				return this._IsCloudVerificationPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCloudVerificationPopupOpen, value, "IsCloudVerificationPopupOpen");
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00014322 File Offset: 0x00012522
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x0001432A File Offset: 0x0001252A
		public DelegateCommand CancelCloudVerification { get; private set; }

		// Token: 0x060008B6 RID: 2230 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCloudVerification()
		{
			return true;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00014333 File Offset: 0x00012533
		private void OnCancelCloudVerification()
		{
			CancellationTokenSource cancellationToken = this._CancellationToken;
			if (cancellationToken != null)
			{
				cancellationToken.Cancel();
			}
			this.IsCloudVerificationPopupOpen = false;
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x0001434D File Offset: 0x0001254D
		// (set) Token: 0x060008B9 RID: 2233 RVA: 0x00014355 File Offset: 0x00012555
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x060008BA RID: 2234 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0001435E File Offset: 0x0001255E
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("AdvancedOptions", UriKind.Relative));
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x0001437B File Offset: 0x0001257B
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x00014383 File Offset: 0x00012583
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060008BE RID: 2238 RVA: 0x0001438C File Offset: 0x0001258C
		private bool CanOnNextCommand()
		{
			if (this.IsCloudBased)
			{
				return true;
			}
			if (string.IsNullOrEmpty(this.TransferFile))
			{
				return false;
			}
			if (this.OldSelected)
			{
				return true;
			}
			if (!this._wizardParameters.CompactUI)
			{
				try
				{
					return File.Exists(Tools.ExpandEnvironmentPlusDateTime(this.TransferFile, this._wizardParameters.ServiceEnvironment));
				}
				catch (Exception ex)
				{
					this.EnableNextButtonTimer.Stop();
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, ex.Message, WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					return false;
				}
				return true;
			}
			return true;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00014430 File Offset: 0x00012630
		private void OnNextCommand()
		{
			FilesBasedTransferPageViewModel.<OnNextCommand>d__50 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<FilesBasedTransferPageViewModel.<OnNextCommand>d__50>(ref <OnNextCommand>d__);
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00014467 File Offset: 0x00012667
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0001446F File Offset: 0x0001266F
		public DelegateCommand OnBrowseOld { get; private set; }

		// Token: 0x060008C2 RID: 2242 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBrowseOldCommand()
		{
			return true;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00014478 File Offset: 0x00012678
		private void OnBrowseOldCommand()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.AddExtension = true;
			saveFileDialog.Filter = WizardModule.Properties.Resources.strVanFilter;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.TransferFile = saveFileDialog.FileName;
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x000144B2 File Offset: 0x000126B2
		// (set) Token: 0x060008C5 RID: 2245 RVA: 0x000144BA File Offset: 0x000126BA
		public DelegateCommand OnBrowseNew { get; private set; }

		// Token: 0x060008C6 RID: 2246 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBrowseNewCommand()
		{
			return true;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000144C4 File Offset: 0x000126C4
		private void OnBrowseNewCommand()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.AddExtension = false;
			openFileDialog.Filter = WizardModule.Properties.Resources.strVanFilter;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.TransferFile = openFileDialog.FileName;
			}
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00014500 File Offset: 0x00012700
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.filesBasedTransferPagePolicy.IsPageDisplayed)
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.FileTransfer);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_FilesBasedTransferPage);
			this.Update();
			if (this.migrationDefinition.IsResuming)
			{
				this.Resume();
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00014578 File Offset: 0x00012778
		private Task<bool> VerifyCloudSettings()
		{
			FilesBasedTransferPageViewModel.<VerifyCloudSettings>d__64 <VerifyCloudSettings>d__;
			<VerifyCloudSettings>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<VerifyCloudSettings>d__.<>4__this = this;
			<VerifyCloudSettings>d__.<>1__state = -1;
			<VerifyCloudSettings>d__.<>t__builder.Start<FilesBasedTransferPageViewModel.<VerifyCloudSettings>d__64>(ref <VerifyCloudSettings>d__);
			return <VerifyCloudSettings>d__.<>t__builder.Task;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000145BC File Offset: 0x000127BC
		private void Update()
		{
			string thisMachineName = null;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				thisMachineName = this.pcmoverEngine.ThisMachine.NetName.ToLower();
			}, "Update"))
			{
				return;
			}
			if (!(this.policy.enginePolicy.Connection.File.Settings.CloudBased == "Local"))
			{
				this.IsCloudBased = true;
				this.BrowseTextOld = WizardModule.Properties.Resources.FBTP_CloudBrowseOld;
				this.BrowseTextNew = WizardModule.Properties.Resources.FBTP_CloudBrowseNew;
			}
			else
			{
				this.IsCloudBased = false;
			}
			this.EnableNextButtonTimer.Start();
			this.migrationDefinition.MigrationType = TransferMethodType.File;
			this.ExpandEnvVariables();
			bool oldSelected = false;
			if (!this._wizardParameters.IsNew)
			{
				bool? isMachineOld = base.pcmoverEngine.Policy.Connection.File.IsMachineOld;
				bool flag = false;
				oldSelected = !(isMachineOld.GetValueOrDefault() == flag & isMachineOld != null);
			}
			if (!string.IsNullOrWhiteSpace(this._wizardParameters.VanFile))
			{
				this.TransferFile = this._wizardParameters.VanFile;
			}
			else if (!string.IsNullOrWhiteSpace(base.pcmoverEngine.Policy.Connection.File.Van))
			{
				this.TransferFile = base.pcmoverEngine.Policy.Connection.File.Van;
			}
			this.OldSelected = oldSelected;
			if (!this.policy.filesBasedTransferPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy)
			{
				if (!this.OldSelected)
				{
					this.vanWaitTimer = new DispatcherTimer
					{
						Interval = new TimeSpan(0, 0, 1)
					};
					this.vanWaitTimer.Tick += delegate(object s, EventArgs e)
					{
						if (this.CanOnNextCommand())
						{
							this.vanWaitTimer.Stop();
							this.OnNext.Execute();
						}
					};
					this.vanWaitTimer.Start();
					return;
				}
				if (this.CanOnNextCommand())
				{
					this.OnNext.Execute();
				}
			}
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00014790 File Offset: 0x00012990
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.EnableNextButtonTimer.Stop();
			if (this.vanWaitTimer != null)
			{
				this.vanWaitTimer.Stop();
			}
			this.policy.WriteProfile();
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x000147BB File Offset: 0x000129BB
		private void Resume()
		{
			this.OldSelected = (this.migrationDefinition.ServiceData.Role != PcmoverTransferState.TransferRole.Destination);
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.TransferFile = base.pcmoverEngine.GetControllerProperty(ControllerProperties.VanPath);
				switch (this.migrationDefinition.ServiceData.Step)
				{
				case PcmoverTransferState.TransferStep.Preparing:
					this.OnNext.Execute();
					return;
				case PcmoverTransferState.TransferStep.Customizing:
				{
					CustomizationScreen customizeScreen;
					Enum.TryParse<CustomizationScreen>(base.pcmoverEngine.GetControllerProperty(ControllerProperties.CustomizationScreen), out customizeScreen);
					this.migrationDefinition.CustomizeScreen = customizeScreen;
					this.migrationDefinition.IsResuming = true;
					this.OnNext.Execute();
					return;
				}
				case PcmoverTransferState.TransferStep.Transferring:
				case PcmoverTransferState.TransferStep.Done:
					this.OnNext.Execute();
					return;
				case PcmoverTransferState.TransferStep.Downloading:
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("DownloadManagerPage", UriKind.Relative));
					return;
				default:
					return;
				}
			}, "Resume");
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x000147F8 File Offset: 0x000129F8
		private bool IsValidMachine()
		{
			if (PcmBrandUI.Properties.Resources.Edition == "Express" && PcmBrandUI.Properties.Resources.OEM == "Intel")
			{
				try
				{
					if (!this.OldSelected)
					{
						if (Tools.IsIntelProcessor(base.pcmoverEngine))
						{
							MachineData thisMachine = base.pcmoverEngine.ThisMachine;
							bool flag;
							if (thisMachine == null)
							{
								flag = true;
							}
							else
							{
								WindowsVersionData windowsVersion = thisMachine.WindowsVersion;
								int? num;
								if (windowsVersion == null)
								{
									num = null;
								}
								else
								{
									Version version = windowsVersion.Version;
									num = ((version != null) ? new int?(version.Major) : null);
								}
								int? num2 = num;
								int num3 = 10;
								flag = !(num2.GetValueOrDefault() == num3 & num2 != null);
							}
							if (!flag)
							{
								goto IL_1A0;
							}
						}
						base.pcmoverEngine.Ts.TraceInformation("Transfer requirements not met.");
						LlTraceSource ts = base.pcmoverEngine.Ts;
						string format = "Windows version (new): {0}.{1}";
						MachineData thisMachine2 = base.pcmoverEngine.ThisMachine;
						int? num4;
						if (thisMachine2 == null)
						{
							num4 = null;
						}
						else
						{
							WindowsVersionData windowsVersion2 = thisMachine2.WindowsVersion;
							if (windowsVersion2 == null)
							{
								num4 = null;
							}
							else
							{
								Version version2 = windowsVersion2.Version;
								num4 = ((version2 != null) ? new int?(version2.Major) : null);
							}
						}
						object arg = num4;
						MachineData thisMachine3 = base.pcmoverEngine.ThisMachine;
						int? num5;
						if (thisMachine3 == null)
						{
							num5 = null;
						}
						else
						{
							WindowsVersionData windowsVersion3 = thisMachine3.WindowsVersion;
							if (windowsVersion3 == null)
							{
								num5 = null;
							}
							else
							{
								Version version3 = windowsVersion3.Version;
								num5 = ((version3 != null) ? new int?(version3.Minor) : null);
							}
						}
						ts.TraceInformation(string.Format(format, arg, num5));
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, PcmBrandUI.Properties.Resources.FPP_InvalidMachinePair, WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.Exclamation, MessageBoxResult.None).ConfigureAwait(false);
						return false;
					}
					IL_1A0:;
				}
				catch
				{
				}
			}
			if (PcmBrandUI.Properties.Resources.Edition == "Pro" && PcmBrandUI.Properties.Resources.OEM == "LG")
			{
				try
				{
					if (!this.OldSelected && !Tools.IsLG(base.pcmoverEngine))
					{
						base.pcmoverEngine.Ts.TraceInformation("Transfer requirements for LG not met.");
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, PcmBrandUI.Properties.Resources.FPP_InvalidMachinePair, PcmBrandUI.Properties.Resources.FPP_InvalidMachinePairCaption, PopupEvents.MBType.MB_OK, MessageBoxImage.Exclamation, MessageBoxResult.None).ConfigureAwait(false);
						return false;
					}
				}
				catch
				{
				}
			}
			return true;
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00014A5C File Offset: 0x00012C5C
		private void ExpandEnvVariables()
		{
			this.policy.WriteProfile();
		}

		// Token: 0x04000274 RID: 628
		private readonly IRegionManager regionManager;

		// Token: 0x04000275 RID: 629
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000276 RID: 630
		private readonly DefaultPolicy policy;

		// Token: 0x04000277 RID: 631
		private DispatcherTimer vanWaitTimer;

		// Token: 0x04000278 RID: 632
		private readonly DispatcherTimer EnableNextButtonTimer;

		// Token: 0x04000279 RID: 633
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x0400027A RID: 634
		private CancellationTokenSource _CancellationToken;

		// Token: 0x0400027B RID: 635
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x0400027C RID: 636
		private string _TransferFile;

		// Token: 0x0400027D RID: 637
		private bool _OldSelected;

		// Token: 0x0400027E RID: 638
		private string _BrowseTextOld;

		// Token: 0x0400027F RID: 639
		private string _BrowseTextNew;

		// Token: 0x04000280 RID: 640
		private bool _IsCloudBased;

		// Token: 0x04000281 RID: 641
		private bool _IsCloudVerificationPopupOpen;
	}
}
