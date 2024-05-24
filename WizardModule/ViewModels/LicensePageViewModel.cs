using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using PCmover.Tools;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using QRCoder;
using WizardModule.Engine;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200008C RID: 140
	public class LicensePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000A7F RID: 2687 RVA: 0x00019D68 File Offset: 0x00017F68
		public LicensePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, IWizardParameters wizardParameters, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._wizardParameters = wizardParameters;
			this._navigationHelper = navigationHelper;
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnPurchase = new DelegateCommand(new Action(this.OnPurchaseCommand), new Func<bool>(this.CanOnPurchaseCommand));
			this.OnShowOAActivation = new DelegateCommand(new Action(this.OnShowOAActivationCommand), new Func<bool>(this.CanOnShowOAActivationCommand));
			this.OnCloseOAPopup = new DelegateCommand(new Action(this.OnCloseOAPopupCommand), new Func<bool>(this.CanOnCloseOAPopupCommand));
			this.OnOAActivate = new DelegateCommand(new Action(this.OnOAActivateCommand), new Func<bool>(this.CanOnOAActivateCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand), new Func<bool>(this.CanOnCancelCommand));
			this.nextPage = "GetInstalledPage";
			this.OAShowOldMachine = (PcmBrandUI.Properties.Resources.Edition != "ProfileMigrator");
			this.ShowQrCode = (PcmBrandUI.Properties.Resources.Edition == "Pro");
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x00019ED8 File Offset: 0x000180D8
		// (set) Token: 0x06000A81 RID: 2689 RVA: 0x00019EE0 File Offset: 0x000180E0
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this.SetProperty<string>(ref this._Email, value, "Email");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00019F00 File Offset: 0x00018100
		// (set) Token: 0x06000A83 RID: 2691 RVA: 0x00019F08 File Offset: 0x00018108
		public string SerialNumber
		{
			get
			{
				return this._SerialNumber;
			}
			set
			{
				this.SetProperty<string>(ref this._SerialNumber, value, "SerialNumber");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06000A84 RID: 2692 RVA: 0x00019F28 File Offset: 0x00018128
		// (set) Token: 0x06000A85 RID: 2693 RVA: 0x00019F30 File Offset: 0x00018130
		public bool ShowOfflineActivation
		{
			get
			{
				return this._ShowOfflineActivation;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowOfflineActivation, value, "ShowOfflineActivation");
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06000A86 RID: 2694 RVA: 0x00019F45 File Offset: 0x00018145
		// (set) Token: 0x06000A87 RID: 2695 RVA: 0x00019F4D File Offset: 0x0001814D
		public bool IsOAPopupOpen
		{
			get
			{
				return this._IsOAPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsOAPopupOpen, value, "IsOAPopupOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06000A88 RID: 2696 RVA: 0x00019F73 File Offset: 0x00018173
		// (set) Token: 0x06000A89 RID: 2697 RVA: 0x00019F7B File Offset: 0x0001817B
		public string User
		{
			get
			{
				return this._User;
			}
			set
			{
				this.SetProperty<string>(ref this._User, value, "User");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06000A8A RID: 2698 RVA: 0x00019F9B File Offset: 0x0001819B
		// (set) Token: 0x06000A8B RID: 2699 RVA: 0x00019FA3 File Offset: 0x000181A3
		public string ValidationCode
		{
			get
			{
				return this._ValidationCode;
			}
			set
			{
				this.SetProperty<string>(ref this._ValidationCode, value, "ValidationCode");
				this.OnOAActivate.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06000A8C RID: 2700 RVA: 0x00019FC3 File Offset: 0x000181C3
		// (set) Token: 0x06000A8D RID: 2701 RVA: 0x00019FCB File Offset: 0x000181CB
		public string OldMachineName
		{
			get
			{
				return this._OldMachineName;
			}
			set
			{
				this.SetProperty<string>(ref this._OldMachineName, value, "OldMachineName");
			}
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06000A8E RID: 2702 RVA: 0x00019FE0 File Offset: 0x000181E0
		// (set) Token: 0x06000A8F RID: 2703 RVA: 0x00019FE8 File Offset: 0x000181E8
		public string NewMachineName
		{
			get
			{
				return this._NewMachineName;
			}
			set
			{
				this.SetProperty<string>(ref this._NewMachineName, value, "NewMachineName");
			}
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06000A90 RID: 2704 RVA: 0x00019FFD File Offset: 0x000181FD
		// (set) Token: 0x06000A91 RID: 2705 RVA: 0x0001A005 File Offset: 0x00018205
		public string SessionCode
		{
			get
			{
				return this._SessionCode;
			}
			set
			{
				this.SetProperty<string>(ref this._SessionCode, value, "SessionCode");
			}
		}

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0001A01A File Offset: 0x0001821A
		// (set) Token: 0x06000A93 RID: 2707 RVA: 0x0001A022 File Offset: 0x00018222
		public bool IsCancelVisible
		{
			get
			{
				return this._IsCancelVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCancelVisible, value, "IsCancelVisible");
			}
		}

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0001A037 File Offset: 0x00018237
		// (set) Token: 0x06000A95 RID: 2709 RVA: 0x0001A03F File Offset: 0x0001823F
		public bool IsSerialNumberVisible
		{
			get
			{
				return this._IsSerialNumberVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsSerialNumberVisible, value, "IsSerialNumberVisible");
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0001A054 File Offset: 0x00018254
		// (set) Token: 0x06000A97 RID: 2711 RVA: 0x0001A05C File Offset: 0x0001825C
		public bool IsBuyLinkVisible
		{
			get
			{
				return this._IsBuyLinkVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBuyLinkVisible, value, "IsBuyLinkVisible");
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06000A98 RID: 2712 RVA: 0x0001A071 File Offset: 0x00018271
		// (set) Token: 0x06000A99 RID: 2713 RVA: 0x0001A079 File Offset: 0x00018279
		public bool OAShowOldMachine
		{
			get
			{
				return this._OAShowOldMachine;
			}
			set
			{
				this.SetProperty<bool>(ref this._OAShowOldMachine, value, "OAShowOldMachine");
			}
		}

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0001A08E File Offset: 0x0001828E
		// (set) Token: 0x06000A9B RID: 2715 RVA: 0x0001A096 File Offset: 0x00018296
		public string TopDescription
		{
			get
			{
				return this._TopDescription;
			}
			set
			{
				this.SetProperty<string>(ref this._TopDescription, value, "TopDescription");
			}
		}

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0001A0AB File Offset: 0x000182AB
		// (set) Token: 0x06000A9D RID: 2717 RVA: 0x0001A0B3 File Offset: 0x000182B3
		public string SerialNumberExample
		{
			get
			{
				return this._SerialNumberExample;
			}
			set
			{
				this.SetProperty<string>(ref this._SerialNumberExample, value, "SerialNumberExample");
			}
		}

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0001A0C8 File Offset: 0x000182C8
		// (set) Token: 0x06000A9F RID: 2719 RVA: 0x0001A0D0 File Offset: 0x000182D0
		public BitmapImage QRImage
		{
			get
			{
				return this._QRImage;
			}
			set
			{
				this.SetProperty<BitmapImage>(ref this._QRImage, value, "QRImage");
			}
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x0001A0E5 File Offset: 0x000182E5
		// (set) Token: 0x06000AA1 RID: 2721 RVA: 0x0001A0ED File Offset: 0x000182ED
		public bool ShowQrCode
		{
			get
			{
				return this._ShowQrCode;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowQrCode, value, "ShowQrCode");
			}
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0001A104 File Offset: 0x00018304
		private void SaveFields()
		{
			this.policy.enginePolicy.Registration.Name = this.User;
			this.policy.enginePolicy.Registration.Email = this.Email;
			this.policy.enginePolicy.Registration.SerialNumber.Value = (PcmBrandUI.Properties.Resources.Edition.StartsWith("Enterprise") ? Encryptor.Encrypt(this._SerialNumber, this.policy.enginePolicy.UseFips) : this._SerialNumber);
			if (!base.pcmoverEngine.License.IsSerialNumberFromPolicy)
			{
				this.policy.licensePagePolicy.AllowReentryOnError = true;
			}
			this.policy.WriteProfile();
			if (!base.pcmoverEngine.IsRemoteUI)
			{
				Tools.SetUsername(this.User);
				Tools.SetEmailAddress(this.Email);
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0001A1E6 File Offset: 0x000183E6
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x0001A1EE File Offset: 0x000183EE
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0001A1F7 File Offset: 0x000183F7
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x0001A205 File Offset: 0x00018405
		// (set) Token: 0x06000AA8 RID: 2728 RVA: 0x0001A20D File Offset: 0x0001840D
		public DelegateCommand OnPurchase { get; private set; }

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnPurchaseCommand()
		{
			return true;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0001A218 File Offset: 0x00018418
		private void OnPurchaseCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.URL_Contact));
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06000AAB RID: 2731 RVA: 0x0001A24C File Offset: 0x0001844C
		// (set) Token: 0x06000AAC RID: 2732 RVA: 0x0001A254 File Offset: 0x00018454
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000AAD RID: 2733 RVA: 0x0001A260 File Offset: 0x00018460
		private bool CanOnNextCommand()
		{
			if (string.IsNullOrEmpty(this.User) || string.IsNullOrEmpty(this.Email))
			{
				return false;
			}
			if (!this.IsSerialNumberVisible)
			{
				return true;
			}
			AuthorizationInfo info = null;
			return base.pcmoverEngine.CatchCommEx(delegate
			{
				info = this.pcmoverEngine.TaskGetAuthorizationInfo();
			}, "CanOnNextCommand") && (base.pcmoverEngine.Policy.Engine.GetSerialNumberFromServer || !string.IsNullOrWhiteSpace(Tools.NormalizeSerialNumber(this._SerialNumber)));
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0001A2F4 File Offset: 0x000184F4
		private void OnNextCommand()
		{
			LicensePageViewModel.<OnNextCommand>d__98 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<LicensePageViewModel.<OnNextCommand>d__98>(ref <OnNextCommand>d__);
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06000AAF RID: 2735 RVA: 0x0001A32B File Offset: 0x0001852B
		// (set) Token: 0x06000AB0 RID: 2736 RVA: 0x0001A333 File Offset: 0x00018533
		public DelegateCommand OnShowOAActivation { get; private set; }

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnShowOAActivationCommand()
		{
			return true;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0001A33C File Offset: 0x0001853C
		private void OnShowOAActivationCommand()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				AuthorizationInfo authorizationInfo = base.pcmoverEngine.TaskGetAuthorizationInfo();
				MachineData thisMachine = base.pcmoverEngine.ThisMachine;
				this.NewMachineName = ((thisMachine != null) ? thisMachine.NetName : null);
				MachineData otherMachine = base.pcmoverEngine.OtherMachine;
				this.OldMachineName = ((otherMachine != null) ? otherMachine.NetName : null);
				this.SessionCode = authorizationInfo.SessionCode;
				this.SetQRCodeImage(authorizationInfo.WebValidatorQrCodeUrl);
				this.IsOAPopupOpen = true;
			}, "OnShowOAActivationCommand");
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x0001A35B File Offset: 0x0001855B
		// (set) Token: 0x06000AB4 RID: 2740 RVA: 0x0001A363 File Offset: 0x00018563
		public DelegateCommand OnOAActivate { get; private set; }

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0001A36C File Offset: 0x0001856C
		private bool CanOnOAActivateCommand()
		{
			return !string.IsNullOrWhiteSpace(this.ValidationCode);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0001A37C File Offset: 0x0001857C
		private void OnOAActivateCommand()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.IsOAPopupOpen = false;
				base.pcmoverEngine.License.ValidationCode = this.ValidationCode;
				base.pcmoverEngine.Ts.TraceInformation("Calling TaskPrepareAuthorization");
				base.pcmoverEngine.TaskPrepareAuthorization(base.pcmoverEngine.License);
				Action<bool> action = this.activationCallbackHandler;
				if (action != null)
				{
					action(true);
				}
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri(this.nextPage, UriKind.Relative));
			}, "OnOAActivateCommand");
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0001A39B File Offset: 0x0001859B
		// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x0001A3A3 File Offset: 0x000185A3
		public DelegateCommand OnCloseOAPopup { get; private set; }

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseOAPopupCommand()
		{
			return true;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0001A3AC File Offset: 0x000185AC
		private void OnCloseOAPopupCommand()
		{
			this.IsOAPopupOpen = false;
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0001A3B5 File Offset: 0x000185B5
		// (set) Token: 0x06000ABC RID: 2748 RVA: 0x0001A3BD File Offset: 0x000185BD
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000ABD RID: 2749 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelCommand()
		{
			return true;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0001A3C8 File Offset: 0x000185C8
		private void OnCancelCommand()
		{
			LicensePageViewModel.<OnCancelCommand>d__122 <OnCancelCommand>d__;
			<OnCancelCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCancelCommand>d__.<>4__this = this;
			<OnCancelCommand>d__.<>1__state = -1;
			<OnCancelCommand>d__.<>t__builder.Start<LicensePageViewModel.<OnCancelCommand>d__122>(ref <OnCancelCommand>d__);
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0001A400 File Offset: 0x00018600
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			LicensePageViewModel.<OnNavigatedTo>d__125 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.navigationContext = navigationContext;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<LicensePageViewModel.<OnNavigatedTo>d__125>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0001A440 File Offset: 0x00018640
		private void Update()
		{
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_LicensePage);
			if (!string.IsNullOrEmpty(base.pcmoverEngine.License.User))
			{
				Name name = NameParser.Parse(base.pcmoverEngine.License.User);
				this.User = ((((name != null) ? name.First : null) == ((name != null) ? name.Last : null)) ? name.First : base.pcmoverEngine.License.User);
			}
			if (string.IsNullOrEmpty(this.User) && !base.pcmoverEngine.IsRemoteUI)
			{
				this.User = Tools.GetUsername();
			}
			IWizardParameters wizardParameters = this.container.Resolve(Array.Empty<ResolverOverride>());
			if (!string.IsNullOrEmpty(wizardParameters.Email))
			{
				this.Email = wizardParameters.Email;
			}
			else if (!string.IsNullOrEmpty(base.pcmoverEngine.License.Email))
			{
				this.Email = base.pcmoverEngine.License.Email;
			}
			if (string.IsNullOrEmpty(this.Email) && !base.pcmoverEngine.IsRemoteUI)
			{
				this.Email = Tools.GetEmailAddress();
			}
			this.SerialNumberExample = WizardModule.Properties.Resources.LP_Example;
			this.SerialNumber = base.pcmoverEngine.License.SerialNumber;
			if (PcmBrandUI.Properties.Resources.Edition.StartsWith("Enterprise") && !string.IsNullOrEmpty(this._SerialNumber))
			{
				this.SerialNumberExample = "•••••••-••••••-•••";
			}
			if (PcmBrandUI.Properties.Resources.Edition.ToLower().StartsWith("enterprise"))
			{
				this.ShowOfflineActivation = (this.activationRequired && !this.isInternetConnected && !base.pcmoverEngine.Version.UpdateData.Checked && Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowOfflineActivation));
			}
			else
			{
				this.ShowOfflineActivation = (this.activationRequired && !Tools.IsInternetConnected() && Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowOfflineActivation));
			}
			if (base.pcmoverEngine.Settings.ContainsKey("SimulateComputerNotOnInternet"))
			{
				this.ShowOfflineActivation = true;
			}
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0001A64C File Offset: 0x0001884C
		private void SetQRCodeImage(string url)
		{
			if (!this.ShowQrCode)
			{
				return;
			}
			Bitmap graphic = new QRCode(new QRCodeGenerator().CreateQrCode(url, QRCodeGenerator.ECCLevel.Q, false, false, QRCodeGenerator.EciMode.Default, -1)).GetGraphic(20);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				graphic.Save(memoryStream, ImageFormat.Png);
				memoryStream.Position = 0L;
				BitmapImage bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memoryStream;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				bitmapImage.Freeze();
				this.QRImage = bitmapImage;
			}
		}

		// Token: 0x04000334 RID: 820
		private readonly IRegionManager regionManager;

		// Token: 0x04000335 RID: 821
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000336 RID: 822
		private string nextPage;

		// Token: 0x04000337 RID: 823
		private Action<bool> activationCallbackHandler;

		// Token: 0x04000338 RID: 824
		private bool activationRequired;

		// Token: 0x04000339 RID: 825
		private DefaultPolicy policy;

		// Token: 0x0400033A RID: 826
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x0400033B RID: 827
		private bool isInternetConnected;

		// Token: 0x0400033C RID: 828
		private NavigationContext navigationContext;

		// Token: 0x0400033D RID: 829
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x0400033E RID: 830
		private NavigationHelper _navigationHelper;

		// Token: 0x0400033F RID: 831
		private string _Email;

		// Token: 0x04000340 RID: 832
		private string _SerialNumber;

		// Token: 0x04000341 RID: 833
		private bool _ShowOfflineActivation;

		// Token: 0x04000342 RID: 834
		private bool _IsOAPopupOpen;

		// Token: 0x04000343 RID: 835
		private string _User;

		// Token: 0x04000344 RID: 836
		private string _ValidationCode;

		// Token: 0x04000345 RID: 837
		private string _OldMachineName;

		// Token: 0x04000346 RID: 838
		private string _NewMachineName;

		// Token: 0x04000347 RID: 839
		private string _SessionCode;

		// Token: 0x04000348 RID: 840
		private bool _IsCancelVisible;

		// Token: 0x04000349 RID: 841
		private bool _IsSerialNumberVisible;

		// Token: 0x0400034A RID: 842
		private bool _IsBuyLinkVisible;

		// Token: 0x0400034B RID: 843
		private bool _OAShowOldMachine;

		// Token: 0x0400034C RID: 844
		private string _TopDescription;

		// Token: 0x0400034D RID: 845
		private string _SerialNumberExample;

		// Token: 0x0400034E RID: 846
		private BitmapImage _QRImage;

		// Token: 0x0400034F RID: 847
		private bool _ShowQrCode;
	}
}
