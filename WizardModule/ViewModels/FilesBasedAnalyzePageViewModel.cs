using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;
using WizardModule.Views.Popups;

namespace WizardModule.ViewModels
{
	// Token: 0x02000082 RID: 130
	public class FilesBasedAnalyzePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x0600083A RID: 2106 RVA: 0x00012ED4 File Offset: 0x000110D4
		public FilesBasedAnalyzePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this._ts = ts;
			this.m_cts = new CancellationTokenSource();
			this._wizardModuleModule = wizardModuleModule;
			eventAggregator.GetEvent<Events.EngineInitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnEngineInitialized), ThreadOption.UIThread, false);
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnCustomize = new DelegateCommand(new Action(this.OnCustomizeCommand), new Func<bool>(this.CanOnCustomizeCommand));
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnSavePassword = new DelegateCommand<object>(new Action<object>(this.OnSavePasswordCommand), new Func<object, bool>(this.CanOnSavePasswordCommand));
			this.OnCancelPassword = new DelegateCommand(new Action(this.OnCancelPasswordCommand), new Func<bool>(this.CanOnCancelPasswordCommand));
			this.OnShowAlertsPopup = new DelegateCommand(new Action(this.OnShowAlertsPopupCommand), new Func<bool>(this.CanOnShowAlertsPopupCommand));
			this.OnSetAWSCognitoCredentials = new DelegateCommand<object>(new Action<object>(this.OnSetAWSCognitoCredentialsCommand), new Func<object, bool>(this.CanOnSetAWSCognitoCredentialsCommand));
			this.OnVanSelected = new DelegateCommand(new Action(this.OnVanSelectedCommand), new Func<bool>(this.CanOnVanSelectedCommand));
			this.IsBusy = true;
			this._wizardParameters = container.Resolve(Array.Empty<ResolverOverride>());
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0001306F File Offset: 0x0001126F
		private void OnEngineInitialized(PcmoverServiceData psd)
		{
			if (psd != null)
			{
				this._hasPassword = base.pcmoverEngine.Policy.Connection.File.VanPassword.HasPassword;
				this.OnCancelPassword.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x000130A4 File Offset: 0x000112A4
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x000130AC File Offset: 0x000112AC
		public bool IsOld
		{
			get
			{
				return this._IsOld;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsOld, value, "IsOld");
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x000130C1 File Offset: 0x000112C1
		// (set) Token: 0x0600083F RID: 2111 RVA: 0x000130C9 File Offset: 0x000112C9
		public string TransferFile
		{
			get
			{
				return this._TransferFile;
			}
			set
			{
				this.SetProperty<string>(ref this._TransferFile, value, "TransferFile");
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x000130DE File Offset: 0x000112DE
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x000130E6 File Offset: 0x000112E6
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBusy, value, "IsBusy");
				this.OnCustomize.RaiseCanExecuteChanged();
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x00013111 File Offset: 0x00011311
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x00013119 File Offset: 0x00011319
		public bool IsVanPasswordPopupOpen
		{
			get
			{
				return this._IsVanPasswordPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVanPasswordPopupOpen, value, "IsVanPasswordPopupOpen");
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0001312E File Offset: 0x0001132E
		// (set) Token: 0x06000845 RID: 2117 RVA: 0x00013136 File Offset: 0x00011336
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

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0001314B File Offset: 0x0001134B
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x00013153 File Offset: 0x00011353
		public string PasswordDialogTitle
		{
			get
			{
				return this._PasswordDialogTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._PasswordDialogTitle, value, "PasswordDialogTitle");
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x00013168 File Offset: 0x00011368
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x00013170 File Offset: 0x00011370
		public string PasswordDialogText
		{
			get
			{
				return this._PasswordDialogText;
			}
			set
			{
				this.SetProperty<string>(ref this._PasswordDialogText, value, "PasswordDialogText");
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x00013185 File Offset: 0x00011385
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x0001318D File Offset: 0x0001138D
		public string PasswordMismatchText
		{
			get
			{
				return this._PasswordMismatchText;
			}
			set
			{
				this.SetProperty<string>(ref this._PasswordMismatchText, value, "PasswordMismatchText");
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x000131A2 File Offset: 0x000113A2
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x000131AA File Offset: 0x000113AA
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

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x000131CA File Offset: 0x000113CA
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x000131D2 File Offset: 0x000113D2
		public bool IsAWSCognitoCredentialsPopupOpen
		{
			get
			{
				return this._IsAWSCognitoCredentialsPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsAWSCognitoCredentialsPopupOpen, value, "IsAWSCognitoCredentialsPopupOpen");
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x000131E7 File Offset: 0x000113E7
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x000131EF File Offset: 0x000113EF
		public ObservableCollection<string> CloudVans
		{
			get
			{
				return this._CloudVans;
			}
			set
			{
				this.SetProperty<ObservableCollection<string>>(ref this._CloudVans, value, "CloudVans");
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x00013204 File Offset: 0x00011404
		// (set) Token: 0x06000853 RID: 2131 RVA: 0x0001320C File Offset: 0x0001140C
		public bool IsSelectVanPopupOpen
		{
			get
			{
				return this._IsSelectVanPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsSelectVanPopupOpen, value, "IsSelectVanPopupOpen");
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00013221 File Offset: 0x00011421
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x00013229 File Offset: 0x00011429
		public string SelectedCloudVan
		{
			get
			{
				return this._SelectedCloudVan;
			}
			set
			{
				this.SetProperty<string>(ref this._SelectedCloudVan, value, "SelectedCloudVan");
				this.OnVanSelected.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0000DA77 File Offset: 0x0000BC77
		public bool CanCustomize
		{
			get
			{
				return !base.pcmoverEngine.IsScript;
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x00013249 File Offset: 0x00011449
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x00013254 File Offset: 0x00011454
		public bool IsVanEncrypted
		{
			get
			{
				return this._IsVanEncrypted;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVanEncrypted, value, "IsVanEncrypted");
				if (value)
				{
					this.policy.enginePolicy.Connection.File.Settings.Encrypt = true;
					this.IsVanPasswordPopupOpen = true;
					return;
				}
				this.policy.enginePolicy.Connection.File.Settings.Encrypt = false;
				this.policy.enginePolicy.Connection.File.VanPassword.Value = null;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x000132DF File Offset: 0x000114DF
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x000132E7 File Offset: 0x000114E7
		public bool IsEncryptCheckboxDisplayed
		{
			get
			{
				return this._IsEncryptCheckboxDisplayed;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsEncryptCheckboxDisplayed, value, "IsEncryptCheckboxDisplayed");
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x000132FC File Offset: 0x000114FC
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x00013304 File Offset: 0x00011504
		public DelegateCommand OnCustomize { get; private set; }

		// Token: 0x0600085D RID: 2141 RVA: 0x0001330D File Offset: 0x0001150D
		private bool CanOnCustomizeCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00013318 File Offset: 0x00011518
		private void OnCustomizeCommand()
		{
			this.policy.analyzePCPagePolicy.CustomTransfer = true;
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("CustomTransferPage", UriKind.Relative));
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x00013346 File Offset: 0x00011546
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x0001334E File Offset: 0x0001154E
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000861 RID: 2145 RVA: 0x0001330D File Offset: 0x0001150D
		private bool CanOnNextCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00013357 File Offset: 0x00011557
		private void OnNextCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FilesBasedTransferProgressPage", UriKind.Relative));
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x00013374 File Offset: 0x00011574
		// (set) Token: 0x06000864 RID: 2148 RVA: 0x0001337C File Offset: 0x0001157C
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000865 RID: 2149 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00013385 File Offset: 0x00011585
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x00013393 File Offset: 0x00011593
		// (set) Token: 0x06000868 RID: 2152 RVA: 0x0001339B File Offset: 0x0001159B
		public DelegateCommand<object> OnSavePassword { get; private set; }

		// Token: 0x06000869 RID: 2153 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSavePasswordCommand(object parameter)
		{
			return true;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x000133A4 File Offset: 0x000115A4
		private void OnSavePasswordCommand(object parameter)
		{
			FilesBasedAnalyzePageViewModel.<OnSavePasswordCommand>d__99 <OnSavePasswordCommand>d__;
			<OnSavePasswordCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSavePasswordCommand>d__.<>4__this = this;
			<OnSavePasswordCommand>d__.parameter = parameter;
			<OnSavePasswordCommand>d__.<>1__state = -1;
			<OnSavePasswordCommand>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<OnSavePasswordCommand>d__99>(ref <OnSavePasswordCommand>d__);
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x000133E3 File Offset: 0x000115E3
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x000133EB File Offset: 0x000115EB
		public DelegateCommand OnCancelPassword { get; private set; }

		// Token: 0x0600086D RID: 2157 RVA: 0x000133F4 File Offset: 0x000115F4
		private bool CanOnCancelPasswordCommand()
		{
			PolicyData policyData = base.pcmoverEngine.Policy;
			VanPasswordPolicyData vanPasswordPolicyData = (policyData != null) ? policyData.Connection.File.VanPassword : null;
			return vanPasswordPolicyData == null || !vanPasswordPolicyData.IsRequired || vanPasswordPolicyData.HasPassword;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00013436 File Offset: 0x00011636
		private void OnCancelPasswordCommand()
		{
			this.IsVanPasswordPopupOpen = false;
			this.ContinueAfterPassword();
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x00013445 File Offset: 0x00011645
		// (set) Token: 0x06000870 RID: 2160 RVA: 0x0001344D File Offset: 0x0001164D
		public DelegateCommand OnShowAlertsPopup { get; private set; }

		// Token: 0x06000871 RID: 2161 RVA: 0x00013456 File Offset: 0x00011656
		private bool CanOnShowAlertsPopupCommand()
		{
			return this.IsAlertEnabled;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0001345E File Offset: 0x0001165E
		private void OnShowAlertsPopupCommand()
		{
			this.eventAggregator.GetEvent<PopupEvents.ShowPopup>().Publish(new PopupEvents.ResolveInfo(typeof(InteractiveAlert), null));
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x00013480 File Offset: 0x00011680
		// (set) Token: 0x06000874 RID: 2164 RVA: 0x00013488 File Offset: 0x00011688
		public DelegateCommand<object> OnSetAWSCognitoCredentials { get; private set; }

		// Token: 0x06000875 RID: 2165 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSetAWSCognitoCredentialsCommand(object parameter)
		{
			return true;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00013494 File Offset: 0x00011694
		private void OnSetAWSCognitoCredentialsCommand(object parameter)
		{
			FilesBasedAnalyzePageViewModel.<OnSetAWSCognitoCredentialsCommand>d__117 <OnSetAWSCognitoCredentialsCommand>d__;
			<OnSetAWSCognitoCredentialsCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSetAWSCognitoCredentialsCommand>d__.<>4__this = this;
			<OnSetAWSCognitoCredentialsCommand>d__.parameter = parameter;
			<OnSetAWSCognitoCredentialsCommand>d__.<>1__state = -1;
			<OnSetAWSCognitoCredentialsCommand>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<OnSetAWSCognitoCredentialsCommand>d__117>(ref <OnSetAWSCognitoCredentialsCommand>d__);
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x000134D3 File Offset: 0x000116D3
		// (set) Token: 0x06000878 RID: 2168 RVA: 0x000134DB File Offset: 0x000116DB
		public DelegateCommand OnVanSelected { get; private set; }

		// Token: 0x06000879 RID: 2169 RVA: 0x000134E4 File Offset: 0x000116E4
		private bool CanOnVanSelectedCommand()
		{
			return !string.IsNullOrEmpty(this.SelectedCloudVan);
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000134F4 File Offset: 0x000116F4
		private void OnVanSelectedCommand()
		{
			base.pcmoverEngine.Ts.TraceInformation("Selected cloud van: " + this.SelectedCloudVan);
			this.migrationDefinition.FilesBasedParameters.TransferFile = this.SelectedCloudVan;
			this.IsSelectVanPopupOpen = false;
			if (base.pcmoverEngine.IsThisMachineAppInventoryComplete)
			{
				this.IsBusy = false;
				this.AfterCloudAuthentication();
			}
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00013558 File Offset: 0x00011758
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			FilesBasedAnalyzePageViewModel.<OnActivityInfo>d__124 <OnActivityInfo>d__;
			<OnActivityInfo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnActivityInfo>d__.<>4__this = this;
			<OnActivityInfo>d__.activityInfo = activityInfo;
			<OnActivityInfo>d__.<>1__state = -1;
			<OnActivityInfo>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<OnActivityInfo>d__124>(ref <OnActivityInfo>d__);
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00013598 File Offset: 0x00011798
		private bool SetPassword(string password)
		{
			bool success = false;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				success = this.pcmoverEngine.SetVanPassword(password);
			}, "SetPassword");
			return success;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000135E4 File Offset: 0x000117E4
		private void FillTaskCompleted(FillTaskData obj)
		{
			base.pcmoverEngine.Ts.TraceInformation(string.Format("FillTaskCompleted fired ({0})", obj.Result));
			this._fillTaskResult = obj.Result;
			if (obj.Result == FillTaskResult.DomainsDoNotMatch)
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, string.Format(Resources.ERROR_DomainsDoNotMatch, this.policy.SupportEmail), Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, this._wizardModuleModule.WelcomeUri);
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0001367C File Offset: 0x0001187C
		private void ReadyForCustomization()
		{
			if (this._fillTaskResult != FillTaskResult.Success)
			{
				return;
			}
			if (this.migrationDefinition.IsResuming && this.migrationDefinition.ServiceData.Step == PcmoverTransferState.TransferStep.Customizing && this.migrationDefinition.CustomizeScreen != CustomizationScreen.Unknown)
			{
				this.IsBusy = false;
				this.OnCustomize.Execute();
				return;
			}
			if (this.migrationDefinition.IsResuming && this.migrationDefinition.ServiceData.Step == PcmoverTransferState.TransferStep.Transferring)
			{
				this.IsBusy = false;
				this.OnNext.Execute();
				return;
			}
			if (this.policy.enginePolicy.Connection.File.Settings.CloudBased != "Local" && !string.IsNullOrEmpty(this.SelectedCloudVan))
			{
				this.IsBusy = false;
				this.AfterCloudAuthentication();
				return;
			}
			if (base.pcmoverEngine.Policy.Connection.File.VanPassword.CanModify)
			{
				this.PasswordDialogText = ((!base.pcmoverEngine.Policy.Connection.File.VanPassword.HasPassword) ? Resources.FBAP_PwDescNotSet : Resources.FBAP_PwDescSet);
				this.PasswordDialogTitle = ((!base.pcmoverEngine.Policy.Connection.File.VanPassword.HasPassword) ? Resources.FBTPP_CreatePassword : Resources.FBAP_ChangePassword);
				this.IsVanPasswordPopupOpen = true;
				return;
			}
			if (this.policy.enginePolicy.Connection.File.Settings.Encrypt && !base.pcmoverEngine.Policy.Connection.File.VanPassword.HasPassword)
			{
				this.PasswordDialogText = Resources.FBAP_PwDescNotSet;
				this.PasswordDialogTitle = Resources.FBTPP_CreatePassword;
				this.IsVanPasswordPopupOpen = true;
				return;
			}
			this.migrationDefinition.IsResuming = false;
			this.ContinueAfterPassword();
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0001384C File Offset: 0x00011A4C
		private void ContinueAfterPassword()
		{
			if (base.pcmoverEngine.Policy.Connection.File.VanPassword.IsRequired && !this._hasPassword)
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, Resources.FBAP_PasswordNotSet, Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				return;
			}
			this.IsBusy = false;
			if (!string.IsNullOrWhiteSpace(this._wizardParameters.VanFile))
			{
				this.OnNext.Execute();
				return;
			}
			if (this.policy.analyzePCPagePolicy.IsPageDisplayed && !this._navigationHelper.IsPlayingBackRecordedPolicy)
			{
				if (!this.CanCustomize)
				{
					this.OnNext.Execute();
				}
				return;
			}
			if (this.policy.analyzePCPagePolicy.CustomTransfer && this.CanOnCustomizeCommand())
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("CustomTransferPage", UriKind.Relative));
				return;
			}
			this.OnNext.Execute();
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00013941 File Offset: 0x00011B41
		private void AfterCloudAuthentication()
		{
			if (!this.IsBusy)
			{
				this.ContinueAfterPassword();
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00013954 File Offset: 0x00011B54
		private Task DoCloudAuthentication(bool bShowVans)
		{
			FilesBasedAnalyzePageViewModel.<DoCloudAuthentication>d__130 <DoCloudAuthentication>d__;
			<DoCloudAuthentication>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DoCloudAuthentication>d__.<>4__this = this;
			<DoCloudAuthentication>d__.bShowVans = bShowVans;
			<DoCloudAuthentication>d__.<>1__state = -1;
			<DoCloudAuthentication>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<DoCloudAuthentication>d__130>(ref <DoCloudAuthentication>d__);
			return <DoCloudAuthentication>d__.<>t__builder.Task;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000139A0 File Offset: 0x00011BA0
		private void OnAppInventoryComplete()
		{
			FilesBasedAnalyzePageViewModel.<OnAppInventoryComplete>d__131 <OnAppInventoryComplete>d__;
			<OnAppInventoryComplete>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAppInventoryComplete>d__.<>4__this = this;
			<OnAppInventoryComplete>d__.<>1__state = -1;
			<OnAppInventoryComplete>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<OnAppInventoryComplete>d__131>(ref <OnAppInventoryComplete>d__);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x000139D8 File Offset: 0x00011BD8
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			FilesBasedAnalyzePageViewModel.<OnNavigatedTo>d__132 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.navigationContext = navigationContext;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<OnNavigatedTo>d__132>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00013A18 File Offset: 0x00011C18
		private Task Update()
		{
			FilesBasedAnalyzePageViewModel.<Update>d__133 <Update>d__;
			<Update>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<Update>d__133>(ref <Update>d__);
			return <Update>d__.<>t__builder.Task;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00013A5C File Offset: 0x00011C5C
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
			this.eventAggregator.GetEvent<Events.ThisMachineAppInventoryCompleteEvent>().Unsubscribe(new Action(this.OnAppInventoryComplete));
			this.eventAggregator.GetEvent<EngineEvents.CreateFillTaskEvent>().Unsubscribe(new Action<FillTaskData>(this.FillTaskCompleted));
			this.eventAggregator.GetEvent<EngineEvents.ReadyForCustomizationEvent>().Unsubscribe(new Action(this.ReadyForCustomization));
			this.policy.WriteProfile();
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00013AE4 File Offset: 0x00011CE4
		public Task ShowVans(ICloudStorageCommon aws, string container, string prefix)
		{
			FilesBasedAnalyzePageViewModel.<ShowVans>d__136 <ShowVans>d__;
			<ShowVans>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShowVans>d__.<>4__this = this;
			<ShowVans>d__.aws = aws;
			<ShowVans>d__.container = container;
			<ShowVans>d__.prefix = prefix;
			<ShowVans>d__.<>1__state = -1;
			<ShowVans>d__.<>t__builder.Start<FilesBasedAnalyzePageViewModel.<ShowVans>d__136>(ref <ShowVans>d__);
			return <ShowVans>d__.<>t__builder.Task;
		}

		// Token: 0x04000240 RID: 576
		private readonly IRegionManager regionManager;

		// Token: 0x04000241 RID: 577
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000242 RID: 578
		private NavigationContext navigationContext;

		// Token: 0x04000243 RID: 579
		private readonly DefaultPolicy policy;

		// Token: 0x04000244 RID: 580
		private readonly LlTraceSource _ts;

		// Token: 0x04000245 RID: 581
		private readonly CancellationTokenSource m_cts;

		// Token: 0x04000246 RID: 582
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x04000247 RID: 583
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x04000248 RID: 584
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000249 RID: 585
		private FillTaskResult _fillTaskResult;

		// Token: 0x0400024A RID: 586
		private bool _hasPassword;

		// Token: 0x0400024B RID: 587
		private bool? _OriginalEncryptionSetting;

		// Token: 0x0400024C RID: 588
		private bool _IsOld;

		// Token: 0x0400024D RID: 589
		private string _TransferFile;

		// Token: 0x0400024E RID: 590
		private bool _IsBusy;

		// Token: 0x0400024F RID: 591
		private bool _IsVanPasswordPopupOpen;

		// Token: 0x04000250 RID: 592
		private bool _IsPasswordMismatch;

		// Token: 0x04000251 RID: 593
		private string _PasswordDialogTitle;

		// Token: 0x04000252 RID: 594
		private string _PasswordDialogText;

		// Token: 0x04000253 RID: 595
		private string _PasswordMismatchText;

		// Token: 0x04000254 RID: 596
		private bool _IsAlertEnabled;

		// Token: 0x04000255 RID: 597
		private bool _IsAWSCognitoCredentialsPopupOpen;

		// Token: 0x04000256 RID: 598
		private ObservableCollection<string> _CloudVans;

		// Token: 0x04000257 RID: 599
		private bool _IsSelectVanPopupOpen;

		// Token: 0x04000258 RID: 600
		private string _SelectedCloudVan;

		// Token: 0x04000259 RID: 601
		private bool _IsVanEncrypted;

		// Token: 0x0400025A RID: 602
		private bool _IsEncryptCheckboxDisplayed;
	}
}
