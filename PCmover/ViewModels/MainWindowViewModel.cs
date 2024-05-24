using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.NativeMethods;
using Laplink.Tools.Popups;
using Laplink.Tools.Ui.Styles;
using MenuModule.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using PCmover.Properties;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.ViewModels;
using WizardModule.Views.Popups;

namespace PCmover.ViewModels
{
	// Token: 0x0200000E RID: 14
	public class MainWindowViewModel : PopupContainerViewModelBase
	{
		// Token: 0x06000090 RID: 144 RVA: 0x000035EC File Offset: 0x000017EC
		[Obsolete("Design time only", false)]
		public MainWindowViewModel()
		{
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000360C File Offset: 0x0000180C
		public MainWindowViewModel(IUnityContainer container, IEventAggregator eventAggregator, LlTraceSource ts) : base(container, eventAggregator)
		{
			LaplinkStyles.InitResources();
			this._ts = ts;
			eventAggregator.GetEvent<Events.UpdateTitle>().Subscribe(new Action<string>(this.OnUpdateTitle));
			eventAggregator.GetEvent<Events.UpdateProgramTitle>().Subscribe(new Action<string>(this.OnUpdateProgramTitle));
			eventAggregator.GetEvent<Events.IsLatestVersionEvent>().Subscribe(new Action<VersionInfo>(this.OnLatestVersion), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Subscribe(new Action<bool>(this.OnMigrationDefinitionChange));
			eventAggregator.GetEvent<Events.BlackoutWindow>().Subscribe(new Action<bool>(this.OnWindowBlackoutChange));
			eventAggregator.GetEvent<Events.CloseConfirmationRequiredChanged>().Subscribe(new Action<bool>(this.OnCloseConfirmationChanged));
			eventAggregator.GetEvent<Events.CloseConfirmationPromptChanged>().Subscribe(new Action<string>(this.OnCloseConfirmationPromptChanged));
			eventAggregator.GetEvent<Events.ShutdownEvent>().Subscribe(new Action(this.Shutdown), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<EngineEvents.ThisMachineAppInventoryProgressChanged>().Subscribe(new Action<ProgressInfo>(this.OnProgressChanged), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.ThisMachineAppInventoryCompleteEvent>().Subscribe(new Action(this.OnProgressFinished), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.ShowOverlayPopup>().Subscribe(new Action<Events.OverlayPopupArgs>(this.OnShowOverlayPopup), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.CloseOverlayPopup>().Subscribe(new Action(this.OnCloseOverlayPopup), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.ShowOverlayPopupResolve>().Subscribe(new Action<Events.OverlayPopupResolveArgs>(this.OnShowOverlayPopupResolve), ThreadOption.UIThread);
			eventAggregator.GetEvent<Events.PolicyChangeSimMode>().Subscribe(new Action<bool>(this.OnPolicyChangeSimMode), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.CheckUserModeRestrictions>().Subscribe(new Action(this.OnCheckUserModeRestrictions), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.EngineInitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnEngineInitialized), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.NoLocalEvent>().Subscribe(new Action(this.OnNoLocalEvent), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.PreviousInstanceShuttingDown>().Subscribe(new Action(this.OnPreviousInstanceShuttingDown), ThreadOption.UIThread);
			eventAggregator.GetEvent<Events.PolicyInitialized>().Subscribe(new Action<DefaultPolicy>(this.OnPolicyInitialized), ThreadOption.UIThread);
			this.OnAbout = new DelegateCommand(new Action(this.OnAboutCommand), new Func<bool>(this.CanOnAboutCommand));
			this.OnNewVersion = new DelegateCommand(new Action(this.OnNewVersionCommand), new Func<bool>(this.CanOnNewVersionCommand));
			this.OnCloseAbout = new DelegateCommand(new Action(this.OnCloseAboutCommand), new Func<bool>(this.CanOnCloseAboutCommand));
			this.OnSupportLink = new DelegateCommand(new Action(this.OnSupportLinkCommand), new Func<bool>(this.CanOnSupportLinkCommand));
			this.WindowClosing = new DelegateCommand(new Action(this.OnWindowClosingCommand), new Func<bool>(this.CanOnWindowClosingCommand));
			this.GodMode = new DelegateCommand(new Action(this.OnGodModeCommand), new Func<bool>(this.CanOnGodModeCommand));
			this.LoggingMenu = new DelegateCommand(new Action(this.OnLoggingMenuCommand), new Func<bool>(this.CanOnLoggingMenuCommand));
			this.RemoteMenu = new DelegateCommand(new Action(this.OnRemoteMenuCommand), new Func<bool>(this.CanOnRemoteMenuCommand));
			this.ModMenu = new DelegateCommand(new Action(this.OnModMenuCommand), new Func<bool>(this.CanOnModMenuCommand));
			this.SimMode = new DelegateCommand(new Action(this.OnSimModeCommand), new Func<bool>(this.CanOnSimModeCommand));
			this.OnCloseOverlay = new DelegateCommand(new Action(this.OnCloseOverlayPopup), new Func<bool>(this.CanOnCloseOverlayPopup));
			this.NetworkStats = new DelegateCommand(new Action(this.OnNetworkStatsCommand), new Func<bool>(this.CanOnNetworkStatsCommand));
			this.OnShowLimitedUser = new DelegateCommand(new Action(this.OnShowLimitedUserCommand), new Func<bool>(this.CanOnShowLimitedUserCommand));
			this.OnShowUserGuide = new DelegateCommand(new Action(this.OnShowUserGuideCommand), new Func<bool>(this.CanOnShowUserGuideCommand));
			this.OnNoLocal = new DelegateCommand(new Action(this.OnNoLocalCommand), new Func<bool>(this.CanOnNoLocalCommand));
			this.OnShowQuicksteps = new DelegateCommand(new Action(this.OnShowQuickstepsCommand), new Func<bool>(this.CanOnShowQuickstepsCommand));
			this._interactionRequest = new InteractionRequest<Notification>();
			this.IsMenuVisable = false;
			this.IsAboutOpen = false;
			this.IsNoLocalOpen = false;
			this.OnFTAClick = new DelegateCommand(new Action(this.OnFTAClickCommand), new Func<bool>(this.CanOnFTAClickCommand));
			this.Title = PcmBrandUI.Properties.Resources.ProgramName;
			this.LatestVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
			this.IsLatestVersion = true;
			this._CloseConfirmationRequired = false;
			this.IsClosing = false;
			this.ShowAppInvProgress = true;
			this.IsSimMode = false;
			this.ISOverlayPopupOpen = false;
			this.ISNetworkStatsVisible = false;
			this.IsQuickstepsEnabled = false;
			this.fPreviousExecutionState = Kernel32.SetThreadExecutionState(2147483650U);
			if (!container.IsRegistered(typeof(IMigrationDefinition)))
			{
				container.RegisterType(new ContainerControlledLifetimeManager(), Array.Empty<InjectionMember>());
			}
			IMigrationDefinition migrationDefinition = container.Resolve(Array.Empty<ResolverOverride>());
			if (AuthenticationViewModel.ShouldAuthenticate(this._ts))
			{
				this.Authenticate().ConfigureAwait(false);
			}
			else
			{
				migrationDefinition.IsAuthenticated = true;
			}
			this.SetRecordedPolicy(migrationDefinition).ConfigureAwait(false);
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00003B62 File Offset: 0x00001D62
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00003B6A File Offset: 0x00001D6A
		public bool IsLatestVersion
		{
			get
			{
				return this._IsLatestVersion;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsLatestVersion, value, "IsLatestVersion");
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00003B7F File Offset: 0x00001D7F
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00003B87 File Offset: 0x00001D87
		public string ATitle
		{
			get
			{
				return this._ATitle;
			}
			set
			{
				this.SetProperty<string>(ref this._ATitle, value, "ATitle");
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00003B9C File Offset: 0x00001D9C
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00003BA4 File Offset: 0x00001DA4
		public string Title
		{
			get
			{
				return this._Title;
			}
			private set
			{
				this.SetProperty<string>(ref this._Title, value, "Title");
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003BB9 File Offset: 0x00001DB9
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00003BC1 File Offset: 0x00001DC1
		public bool IsClosing
		{
			get
			{
				return this._IsClosing;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsClosing, value, "IsClosing");
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003BD6 File Offset: 0x00001DD6
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00003BDE File Offset: 0x00001DDE
		public bool IsMenuVisable
		{
			get
			{
				return this._IsMenuVisable;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsMenuVisable, value, "IsMenuVisable");
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003BF3 File Offset: 0x00001DF3
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003BFB File Offset: 0x00001DFB
		public Brush BorderBrush
		{
			get
			{
				return this._BorderBrush;
			}
			private set
			{
				this.SetProperty<Brush>(ref this._BorderBrush, value, "BorderBrush");
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00003C10 File Offset: 0x00001E10
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00003C18 File Offset: 0x00001E18
		public string MBIcon
		{
			get
			{
				return this._mbIcon;
			}
			private set
			{
				this.SetProperty<string>(ref this._mbIcon, value, "MBIcon");
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003C2D File Offset: 0x00001E2D
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00003C35 File Offset: 0x00001E35
		public bool ShowAppInvProgress
		{
			get
			{
				return this.showAppInvProgress;
			}
			private set
			{
				this.SetProperty<bool>(ref this.showAppInvProgress, value, "ShowAppInvProgress");
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00003C4A File Offset: 0x00001E4A
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003C54 File Offset: 0x00001E54
		public bool IsAboutOpen
		{
			get
			{
				return this.isAboutOpen;
			}
			set
			{
				if (!string.IsNullOrEmpty(PcmBrandUI.Properties.Resources.URL_OnlineSupport))
				{
					this.OnlineSupport = PcmBrandUI.Properties.Resources.URL_OnlineSupport;
				}
				else
				{
					DefaultPolicy defaultPolicy = this.policy;
					this.OnlineSupport = ((defaultPolicy != null) ? defaultPolicy.SupportEmail : null);
				}
				this.SetProperty<bool>(ref this.isAboutOpen, value, "IsAboutOpen");
				base.IsBlackout = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00003CAC File Offset: 0x00001EAC
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00003CB4 File Offset: 0x00001EB4
		private bool IsSimMode { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00003CBD File Offset: 0x00001EBD
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00003CC5 File Offset: 0x00001EC5
		public string LatestVersion
		{
			get
			{
				return this.latestVersion;
			}
			private set
			{
				this.SetProperty<string>(ref this.latestVersion, value, "LatestVersion");
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00003CDA File Offset: 0x00001EDA
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00003CE2 File Offset: 0x00001EE2
		public string WindowsVersion
		{
			get
			{
				return this._WindowsVersion;
			}
			private set
			{
				this.SetProperty<string>(ref this._WindowsVersion, value, "WindowsVersion");
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003CF7 File Offset: 0x00001EF7
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00003CFF File Offset: 0x00001EFF
		public double Progress
		{
			get
			{
				return this._Progress;
			}
			set
			{
				this.SetProperty<double>(ref this._Progress, value, "Progress");
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003D14 File Offset: 0x00001F14
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003D1C File Offset: 0x00001F1C
		public string UpgradeURL
		{
			get
			{
				return this._UpgradeURL;
			}
			private set
			{
				this.SetProperty<string>(ref this._UpgradeURL, value, "UpgradeURL");
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003D31 File Offset: 0x00001F31
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00003D39 File Offset: 0x00001F39
		public bool IsUpdating
		{
			get
			{
				return this._IsUpdating;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsUpdating, value, "IsUpdating");
				base.IsBlackout = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003D55 File Offset: 0x00001F55
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00003D5D File Offset: 0x00001F5D
		public string OverlayPopupTitle
		{
			get
			{
				return this._OverlayPopupTitle;
			}
			private set
			{
				this.SetProperty<string>(ref this._OverlayPopupTitle, value, "OverlayPopupTitle");
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00003D72 File Offset: 0x00001F72
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00003D7A File Offset: 0x00001F7A
		public bool ISOverlayPopupOpen
		{
			get
			{
				return this._ISOverlayPopupOpen;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ISOverlayPopupOpen, value, "ISOverlayPopupOpen");
				base.IsBlackout = this._ISOverlayPopupOpen;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00003D9B File Offset: 0x00001F9B
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00003DA3 File Offset: 0x00001FA3
		public NetworkStatsData NetworkData
		{
			get
			{
				return this._NetworkData;
			}
			private set
			{
				this.SetProperty<NetworkStatsData>(ref this._NetworkData, value, "NetworkData");
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00003DB8 File Offset: 0x00001FB8
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public bool ISNetworkStatsVisible
		{
			get
			{
				return this._ISNetworkStatsVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ISNetworkStatsVisible, value, "ISNetworkStatsVisible");
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00003DD5 File Offset: 0x00001FD5
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00003DDD File Offset: 0x00001FDD
		public string FTADisplayUrl
		{
			get
			{
				return this._FTADisplayUrl;
			}
			private set
			{
				this.SetProperty<string>(ref this._FTADisplayUrl, value, "FTADisplayUrl");
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003DF2 File Offset: 0x00001FF2
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00003DFA File Offset: 0x00001FFA
		public bool IsFTAVisible
		{
			get
			{
				return this._IsFTAVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsFTAVisible, value, "IsFTAVisible");
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00003E0F File Offset: 0x0000200F
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00003E17 File Offset: 0x00002017
		public string FTATopText
		{
			get
			{
				return this._FTATopText;
			}
			private set
			{
				this.SetProperty<string>(ref this._FTATopText, value, "FTATopText");
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003E2C File Offset: 0x0000202C
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00003E34 File Offset: 0x00002034
		public string FTABottomText
		{
			get
			{
				return this._FTABottomText;
			}
			private set
			{
				this.SetProperty<string>(ref this._FTABottomText, value, "FTABottomText");
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003E49 File Offset: 0x00002049
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00003E51 File Offset: 0x00002051
		public string FTAImagePath
		{
			get
			{
				return this._FTAImagePath;
			}
			private set
			{
				this.SetProperty<string>(ref this._FTAImagePath, value, "FTAImagePath");
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003E66 File Offset: 0x00002066
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00003E6E File Offset: 0x0000206E
		public bool IsLimitedUserPopupOpen
		{
			get
			{
				return this._IsLimitedUserPopupOpen;
			}
			set
			{
				if (this.policy != null && !this.policy.SuppressMessageBoxes)
				{
					this.SetProperty<bool>(ref this._IsLimitedUserPopupOpen, value, "IsLimitedUserPopupOpen");
					base.IsBlackout = value;
				}
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00003E9F File Offset: 0x0000209F
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00003EA7 File Offset: 0x000020A7
		public bool IsLimitedUser
		{
			get
			{
				return this._IsLimitedUser;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsLimitedUser, value, "IsLimitedUser");
				this.IsLimitedUserPopupOpen = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00003EC3 File Offset: 0x000020C3
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00003ECB File Offset: 0x000020CB
		public string LimitedUserText
		{
			get
			{
				return this._LimitedUserText;
			}
			private set
			{
				this.SetProperty<string>(ref this._LimitedUserText, value, "LimitedUserText");
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00003EE0 File Offset: 0x000020E0
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00003EE8 File Offset: 0x000020E8
		public string LicenseInfoText
		{
			get
			{
				return this._LicenseInfoText;
			}
			private set
			{
				this.SetProperty<string>(ref this._LicenseInfoText, value, "LicenseInfoText");
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00003EFD File Offset: 0x000020FD
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00003F05 File Offset: 0x00002105
		public bool IsAnimationEnabled
		{
			get
			{
				return this._IsAnimationEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsAnimationEnabled, value, "IsAnimationEnabled");
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00003F1A File Offset: 0x0000211A
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00003F22 File Offset: 0x00002122
		public bool ShowUserGuideButton
		{
			get
			{
				return this.showUserGuideButton;
			}
			private set
			{
				this.SetProperty<bool>(ref this.showUserGuideButton, value, "ShowUserGuideButton");
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00003F37 File Offset: 0x00002137
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00003F3F File Offset: 0x0000213F
		public bool IsNoLocalOpen
		{
			get
			{
				return this._IsNoLocalOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsNoLocalOpen, value, "IsNoLocalOpen");
				base.IsBlackout = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00003F5B File Offset: 0x0000215B
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00003F63 File Offset: 0x00002163
		public bool IsEngineInitInProgressPopupOpen
		{
			get
			{
				return this._IsEngineInitInProgressPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsEngineInitInProgressPopupOpen, value, "IsEngineInitInProgressPopupOpen");
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00003F78 File Offset: 0x00002178
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x00003F80 File Offset: 0x00002180
		public bool IsCompactUI
		{
			get
			{
				return this._IsCompactUI;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCompactUI, value, "IsCompactUI");
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00003F95 File Offset: 0x00002195
		public IInteractionRequest InteractionRequest
		{
			get
			{
				return this._interactionRequest;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00003F9D File Offset: 0x0000219D
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00003FA5 File Offset: 0x000021A5
		public bool IsQuickstepsEnabled
		{
			get
			{
				return this._IsQuickstepsEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsQuickstepsEnabled, value, "IsQuickstepsEnabled");
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00003FBA File Offset: 0x000021BA
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00003FC2 File Offset: 0x000021C2
		public string OnlineSupport
		{
			get
			{
				return this._OnlineSupport;
			}
			set
			{
				this.SetProperty<string>(ref this._OnlineSupport, value, "OnlineSupport");
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00003FD7 File Offset: 0x000021D7
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00003FDF File Offset: 0x000021DF
		public string CopyrightText
		{
			get
			{
				return this._CopyrightText;
			}
			private set
			{
				this.SetProperty<string>(ref this._CopyrightText, value, "CopyrightText");
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003FF4 File Offset: 0x000021F4
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00003FFC File Offset: 0x000021FC
		public DelegateCommand OnAbout { get; private set; }

		// Token: 0x060000DD RID: 221 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnAboutCommand()
		{
			return true;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004008 File Offset: 0x00002208
		private void OnAboutCommand()
		{
			MainWindowViewModel.<OnAboutCommand>d__159 <OnAboutCommand>d__;
			<OnAboutCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAboutCommand>d__.<>4__this = this;
			<OnAboutCommand>d__.<>1__state = -1;
			<OnAboutCommand>d__.<>t__builder.Start<MainWindowViewModel.<OnAboutCommand>d__159>(ref <OnAboutCommand>d__);
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000403F File Offset: 0x0000223F
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00004047 File Offset: 0x00002247
		public DelegateCommand GodMode { get; private set; }

		// Token: 0x060000E1 RID: 225 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnGodModeCommand()
		{
			return true;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004050 File Offset: 0x00002250
		private void OnGodModeCommand()
		{
			IPCmoverEngine ipcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
			if (ipcmoverEngine != null)
			{
				ipcmoverEngine.GodMode = true;
				this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(true);
				IRegionManager regionManager = (IRegionManager)ServiceLocator.Current.GetService(typeof(IRegionManager));
				if (regionManager != null)
				{
					regionManager.RequestNavigate("GodModeRegion", "GodMode");
				}
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x000040B6 File Offset: 0x000022B6
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x000040BE File Offset: 0x000022BE
		public DelegateCommand LoggingMenu { get; private set; }

		// Token: 0x060000E5 RID: 229 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnLoggingMenuCommand()
		{
			return true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000040C8 File Offset: 0x000022C8
		private void OnLoggingMenuCommand()
		{
			IPCmoverEngine pcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
			if (pcmoverEngine != null)
			{
				pcmoverEngine.CatchCommEx(delegate
				{
					MachineData thisMachine = pcmoverEngine.ThisMachine;
					if (thisMachine != null && thisMachine.IsEngineRunningAsAdmin)
					{
						Events.OverlayPopupResolveArgs payload = new Events.OverlayPopupResolveArgs
						{
							Title = "Logging",
							Type = typeof(LogMenu),
							UseOverlay = true
						};
						this.eventAggregator.GetEvent<Events.ShowOverlayPopupResolve>().Publish(payload);
					}
				}, "OnLoggingMenuCommand");
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000411D File Offset: 0x0000231D
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00004125 File Offset: 0x00002325
		public DelegateCommand RemoteMenu { get; private set; }

		// Token: 0x060000E9 RID: 233 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnRemoteMenuCommand()
		{
			return true;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004130 File Offset: 0x00002330
		private void OnRemoteMenuCommand()
		{
			if (this.container.Resolve(Array.Empty<ResolverOverride>()) != null)
			{
				this.eventAggregator.GetEvent<Events.MigrationDefinitionChange>().Publish(true);
				IRegionManager regionManager = this.container.Resolve(Array.Empty<ResolverOverride>());
				if (regionManager != null)
				{
					regionManager.RequestNavigate("GodModeRegion", "RemoteMenu");
				}
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00004184 File Offset: 0x00002384
		// (set) Token: 0x060000EC RID: 236 RVA: 0x0000418C File Offset: 0x0000238C
		public DelegateCommand NetworkStats { get; private set; }

		// Token: 0x060000ED RID: 237 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnNetworkStatsCommand()
		{
			return true;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004198 File Offset: 0x00002398
		private void OnNetworkStatsCommand()
		{
			this.ISNetworkStatsVisible = !this.ISNetworkStatsVisible;
			IPCmoverEngine pcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
			if (pcmoverEngine == null)
			{
				return;
			}
			DispatcherTimer timer = new DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(2.0)
			};
			Action <>9__1;
			timer.Tick += delegate(object sender, EventArgs args)
			{
				if (!this.ISNetworkStatsVisible)
				{
					timer.Stop();
					return;
				}
				IPCmoverEngine pcmoverEngine = pcmoverEngine;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this.NetworkData = pcmoverEngine.NetworkStats;
					});
				}
				if (!pcmoverEngine.CatchCommEx(func, "OnNetworkStatsCommand"))
				{
					timer.Stop();
					return;
				}
			};
			timer.Start();
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00004221 File Offset: 0x00002421
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00004229 File Offset: 0x00002429
		public DelegateCommand ModMenu { get; private set; }

		// Token: 0x060000F1 RID: 241 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnModMenuCommand()
		{
			return true;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004232 File Offset: 0x00002432
		private void OnModMenuCommand()
		{
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00004234 File Offset: 0x00002434
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000423C File Offset: 0x0000243C
		public DelegateCommand SimMode { get; private set; }

		// Token: 0x060000F5 RID: 245 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnSimModeCommand()
		{
			return true;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004248 File Offset: 0x00002448
		private void OnSimModeCommand()
		{
			MainWindowViewModel.<OnSimModeCommand>d__195 <OnSimModeCommand>d__;
			<OnSimModeCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnSimModeCommand>d__.<>4__this = this;
			<OnSimModeCommand>d__.<>1__state = -1;
			<OnSimModeCommand>d__.<>t__builder.Start<MainWindowViewModel.<OnSimModeCommand>d__195>(ref <OnSimModeCommand>d__);
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000427F File Offset: 0x0000247F
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00004287 File Offset: 0x00002487
		public DelegateCommand OnNewVersion { get; private set; }

		// Token: 0x060000F9 RID: 249 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnNewVersionCommand()
		{
			return true;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004290 File Offset: 0x00002490
		private void OnNewVersionCommand()
		{
			MainWindowViewModel.<OnNewVersionCommand>d__201 <OnNewVersionCommand>d__;
			<OnNewVersionCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNewVersionCommand>d__.<>4__this = this;
			<OnNewVersionCommand>d__.<>1__state = -1;
			<OnNewVersionCommand>d__.<>t__builder.Start<MainWindowViewModel.<OnNewVersionCommand>d__201>(ref <OnNewVersionCommand>d__);
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000042C7 File Offset: 0x000024C7
		// (set) Token: 0x060000FC RID: 252 RVA: 0x000042CF File Offset: 0x000024CF
		public DelegateCommand OnCloseAbout { get; private set; }

		// Token: 0x060000FD RID: 253 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnCloseAboutCommand()
		{
			return true;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000042D8 File Offset: 0x000024D8
		private void OnCloseAboutCommand()
		{
			this.IsAboutOpen = false;
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060000FF RID: 255 RVA: 0x000042E1 File Offset: 0x000024E1
		// (set) Token: 0x06000100 RID: 256 RVA: 0x000042E9 File Offset: 0x000024E9
		public DelegateCommand OnSupportLink { get; private set; }

		// Token: 0x06000101 RID: 257 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnSupportLinkCommand()
		{
			return true;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000042F2 File Offset: 0x000024F2
		private void OnSupportLinkCommand()
		{
			Tools.OpenSupport(this.policy);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000042FF File Offset: 0x000024FF
		private void OnCloseConfirmationChanged(bool confirmationRequired)
		{
			this._CloseConfirmationRequired = confirmationRequired;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004308 File Offset: 0x00002508
		private void OnCloseConfirmationPromptChanged(string obj)
		{
			this._CloseConfirmationPrompt = obj;
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00004311 File Offset: 0x00002511
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00004319 File Offset: 0x00002519
		public DelegateCommand WindowClosing { get; private set; }

		// Token: 0x06000107 RID: 263 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnWindowClosingCommand()
		{
			return true;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004324 File Offset: 0x00002524
		private void OnWindowClosingCommand()
		{
			MainWindowViewModel.<>c__DisplayClass223_0 CS$<>8__locals1 = new MainWindowViewModel.<>c__DisplayClass223_0();
			CS$<>8__locals1.<>4__this = this;
			if (!this.IsClosing)
			{
				this.IsClosing = true;
				this._ts.TraceCaller(null, "OnWindowClosingCommand");
				CS$<>8__locals1.result = MessageBoxResult.No;
				new Task(delegate()
				{
					MainWindowViewModel.<>c__DisplayClass223_0.<<OnWindowClosingCommand>b__0>d <<OnWindowClosingCommand>b__0>d;
					<<OnWindowClosingCommand>b__0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<OnWindowClosingCommand>b__0>d.<>4__this = CS$<>8__locals1;
					<<OnWindowClosingCommand>b__0>d.<>1__state = -1;
					<<OnWindowClosingCommand>b__0>d.<>t__builder.Start<MainWindowViewModel.<>c__DisplayClass223_0.<<OnWindowClosingCommand>b__0>d>(ref <<OnWindowClosingCommand>b__0>d);
				}).Start();
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000437B File Offset: 0x0000257B
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00004383 File Offset: 0x00002583
		public DelegateCommand OnCloseOverlay { get; set; }

		// Token: 0x0600010B RID: 267 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnCloseOverlayPopup()
		{
			return true;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000438C File Offset: 0x0000258C
		private void OnCloseOverlayPopup()
		{
			this.ISOverlayPopupOpen = false;
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00004395 File Offset: 0x00002595
		// (set) Token: 0x0600010E RID: 270 RVA: 0x0000439D File Offset: 0x0000259D
		public DelegateCommand OnFTAClick { get; private set; }

		// Token: 0x0600010F RID: 271 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnFTAClickCommand()
		{
			return true;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000043A8 File Offset: 0x000025A8
		private void OnFTAClickCommand()
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTAURL) && !string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTADisplayURL))
				{
					Process.Start(new ProcessStartInfo(this.policy.CustomUIPagePolicy.FTAURL));
				}
				else
				{
					Uri uri = new Uri(PcmBrandUI.Properties.Resources.FTAURL);
					if (!string.IsNullOrWhiteSpace(uri.AbsoluteUri))
					{
						Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
					}
				}
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "OnFTAClickCommand");
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004450 File Offset: 0x00002650
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00004458 File Offset: 0x00002658
		public DelegateCommand OnShowLimitedUser { get; set; }

		// Token: 0x06000113 RID: 275 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnShowLimitedUserCommand()
		{
			return true;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00004461 File Offset: 0x00002661
		private void OnShowLimitedUserCommand()
		{
			this.IsLimitedUserPopupOpen = true;
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000115 RID: 277 RVA: 0x0000446A File Offset: 0x0000266A
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00004472 File Offset: 0x00002672
		public DelegateCommand OnShowUserGuide { get; private set; }

		// Token: 0x06000117 RID: 279 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnShowUserGuideCommand()
		{
			return true;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000447C File Offset: 0x0000267C
		private void OnShowUserGuideCommand()
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.UserGuideUrl))
				{
					Process.Start(new ProcessStartInfo(this.policy.CustomUIPagePolicy.UserGuideUrl));
				}
				else if (!string.IsNullOrWhiteSpace(PcmBrandUI.Properties.Resources.URL_Guide))
				{
					Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.URL_Guide));
				}
				else if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "PCmover.chm"))
				{
					Process.Start(new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "PCmover.chm"));
				}
				else
				{
					Process.Start(new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "UserGuideInstall.exe"));
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000119 RID: 281 RVA: 0x0000454C File Offset: 0x0000274C
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00004554 File Offset: 0x00002754
		public DelegateCommand OnNoLocal { get; private set; }

		// Token: 0x0600011B RID: 283 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnNoLocalCommand()
		{
			return true;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000455D File Offset: 0x0000275D
		private void OnNoLocalCommand()
		{
			this._ts.TraceCaller(null, "OnNoLocalCommand");
			this.Shutdown();
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00004576 File Offset: 0x00002776
		// (set) Token: 0x0600011E RID: 286 RVA: 0x0000457E File Offset: 0x0000277E
		public DelegateCommand OnShowQuicksteps { get; private set; }

		// Token: 0x0600011F RID: 287 RVA: 0x00003025 File Offset: 0x00001225
		private bool CanOnShowQuickstepsCommand()
		{
			return true;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004587 File Offset: 0x00002787
		private void OnShowQuickstepsCommand()
		{
			this._interactionRequest.Raise(new Notification());
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000459C File Offset: 0x0000279C
		private Task SetRecordedPolicy(IMigrationDefinition migrationDefinition)
		{
			MainWindowViewModel.<SetRecordedPolicy>d__260 <SetRecordedPolicy>d__;
			<SetRecordedPolicy>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SetRecordedPolicy>d__.<>4__this = this;
			<SetRecordedPolicy>d__.migrationDefinition = migrationDefinition;
			<SetRecordedPolicy>d__.<>1__state = -1;
			<SetRecordedPolicy>d__.<>t__builder.Start<MainWindowViewModel.<SetRecordedPolicy>d__260>(ref <SetRecordedPolicy>d__);
			return <SetRecordedPolicy>d__.<>t__builder.Task;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000045E8 File Offset: 0x000027E8
		private Task Authenticate()
		{
			MainWindowViewModel.<Authenticate>d__261 <Authenticate>d__;
			<Authenticate>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Authenticate>d__.<>4__this = this;
			<Authenticate>d__.<>1__state = -1;
			<Authenticate>d__.<>t__builder.Start<MainWindowViewModel.<Authenticate>d__261>(ref <Authenticate>d__);
			return <Authenticate>d__.<>t__builder.Task;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000462B File Offset: 0x0000282B
		private void OnPolicyChangeSimMode(bool doSimMode)
		{
			if (doSimMode)
			{
				if (!this.IsSimMode)
				{
					this.SimMode.Execute();
					return;
				}
			}
			else if (this.IsSimMode)
			{
				this.SimMode.Execute();
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004657 File Offset: 0x00002857
		private void OnProgressFinished()
		{
			this.Progress = 100.0;
			this.ShowAppInvProgress = false;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000466F File Offset: 0x0000286F
		private void OnProgressChanged(ProgressInfo progress)
		{
			this.Progress = (double)progress.Percentage;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004680 File Offset: 0x00002880
		private void Shutdown()
		{
			IPCmoverEngine ipcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
			if (ipcmoverEngine != null && this.policy != null && ipcmoverEngine.ControlProxyState != CommunicationState.Faulted)
			{
				if (ipcmoverEngine.Settings.ContainsKey("IgnoreIsComplete"))
				{
					this.policy.IsComplete = (((bool)ipcmoverEngine.Settings["IgnoreIsComplete"]) ? DefaultPolicy.Tristate.Null : DefaultPolicy.Tristate.True);
				}
				else
				{
					this.policy.IsComplete = DefaultPolicy.Tristate.True;
				}
				this.policy.WriteProfile();
				ipcmoverEngine.ShutdownPcmoverAppAsync(true);
			}
			else if (this.policy != null)
			{
				this.policy.IsComplete = DefaultPolicy.Tristate.True;
				DefaultPolicy defaultPolicy = this.policy;
				if (defaultPolicy != null)
				{
					defaultPolicy.WriteProfile();
				}
			}
			Kernel32.SetThreadExecutionState(this.fPreviousExecutionState);
			this._ts.TraceCaller("Requesting application shutdown", "Shutdown");
			System.Windows.Application.Current.Shutdown();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004760 File Offset: 0x00002960
		private void OnShowOverlayPopup(Events.OverlayPopupArgs obj)
		{
			this.OverlayPopupTitle = obj.Title;
			obj.ClosePopupCallback = new Action(this.OnCloseOverlayPopup);
			((IRegionManager)ServiceLocator.Current.GetService(typeof(IRegionManager))).RequestNavigate(RegionNames.RegionOverlayPopup, obj.ContentRegion, new NavigationParameters
			{
				{
					"Param",
					obj
				}
			});
			this.ISOverlayPopupOpen = true;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000047CC File Offset: 0x000029CC
		private void OnShowOverlayPopupResolve(Events.OverlayPopupResolveArgs overlayArgs)
		{
			base.OnShowPopup(overlayArgs.GetResolveInfo(typeof(OverlayPopup)));
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000047E4 File Offset: 0x000029E4
		private void OnLatestVersion(VersionInfo versionInfo)
		{
			MainWindowViewModel.<OnLatestVersion>d__268 <OnLatestVersion>d__;
			<OnLatestVersion>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnLatestVersion>d__.<>4__this = this;
			<OnLatestVersion>d__.versionInfo = versionInfo;
			<OnLatestVersion>d__.<>1__state = -1;
			<OnLatestVersion>d__.<>t__builder.Start<MainWindowViewModel.<OnLatestVersion>d__268>(ref <OnLatestVersion>d__);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004823 File Offset: 0x00002A23
		private void OnEngineReInitialized(PcmoverServiceData obj)
		{
			this.eventAggregator.GetEvent<Events.EngineReinitializedEvent>().Unsubscribe(new Action<PcmoverServiceData>(this.OnEngineReInitialized));
			this.eventAggregator.GetEvent<Events.EngineInitializedEvent>().Publish(obj);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004854 File Offset: 0x00002A54
		private void OnServiceStateChanged(PcmoverState state)
		{
			MainWindowViewModel.<OnServiceStateChanged>d__270 <OnServiceStateChanged>d__;
			<OnServiceStateChanged>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnServiceStateChanged>d__.<>4__this = this;
			<OnServiceStateChanged>d__.state = state;
			<OnServiceStateChanged>d__.<>1__state = -1;
			<OnServiceStateChanged>d__.<>t__builder.Start<MainWindowViewModel.<OnServiceStateChanged>d__270>(ref <OnServiceStateChanged>d__);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004893 File Offset: 0x00002A93
		private void OnMigrationDefinitionChange(bool godMode)
		{
			IMigrationDefinition migrationDefinition = (IMigrationDefinition)ServiceLocator.Current.GetService(typeof(IMigrationDefinition));
			this.IsMenuVisable = godMode;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000048B6 File Offset: 0x00002AB6
		private void OnUpdateTitle(string title)
		{
			if (DefaultPolicy.InDebugMode)
			{
				string str = "   <";
				DefaultPolicy defaultPolicy = this.policy;
				this.ATitle = title + str + ((defaultPolicy != null) ? defaultPolicy.CurrentPage : null) + ">";
				return;
			}
			this.ATitle = title;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000048EF File Offset: 0x00002AEF
		private void OnUpdateProgramTitle(string title)
		{
			this.Title = PcmBrandUI.Properties.Resources.ProgramName + " - " + title;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004907 File Offset: 0x00002B07
		private void OnWindowBlackoutChange(bool obj)
		{
			base.IsBlackout = obj;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004910 File Offset: 0x00002B10
		private void OnEngineInitialized(PcmoverServiceData serviceData)
		{
			MainWindowViewModel.<OnEngineInitialized>d__275 <OnEngineInitialized>d__;
			<OnEngineInitialized>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnEngineInitialized>d__.<>4__this = this;
			<OnEngineInitialized>d__.serviceData = serviceData;
			<OnEngineInitialized>d__.<>1__state = -1;
			<OnEngineInitialized>d__.<>t__builder.Start<MainWindowViewModel.<OnEngineInitialized>d__275>(ref <OnEngineInitialized>d__);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004950 File Offset: 0x00002B50
		private bool IsQuickStepsAvailable()
		{
			try
			{
				string text = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\QuickSteps.dll";
				if (!File.Exists(text))
				{
					this._ts.TraceInformation("QuickSteps disabled (not installed).");
					return false;
				}
				Assembly.LoadFrom(text);
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "IsQuickStepsAvailable");
				return false;
			}
			return true;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000049CC File Offset: 0x00002BCC
		private void OnPolicyInitialized(DefaultPolicy defaultPolicy)
		{
			this.policy = defaultPolicy;
			if (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTATopText))
			{
				this.FTATopText = this.policy.CustomUIPagePolicy.FTATopText;
			}
			else
			{
				this.FTATopText = PcmBrandUI.Properties.Resources.FTATopText;
			}
			if (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTABottomText))
			{
				this.FTABottomText = this.policy.CustomUIPagePolicy.FTABottomText;
			}
			else
			{
				this.FTABottomText = PcmBrandUI.Properties.Resources.FTABottomText;
			}
			if (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTAImagePath))
			{
				this.FTAImagePath = this.policy.CustomUIPagePolicy.FTAImagePath;
			}
			else
			{
				this.FTAImagePath = "/PcmBrandUI;Component/Resources/chaticon.png";
			}
			if (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTAURL) && !string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTADisplayURL))
			{
				this.FTADisplayUrl = this.policy.CustomUIPagePolicy.FTADisplayURL;
			}
			else
			{
				this.FTADisplayUrl = PcmBrandUI.Properties.Resources.FTADisplayURL;
			}
			this.IsFTAVisible = (!string.IsNullOrWhiteSpace(PcmBrandUI.Properties.Resources.FTAURL) || (!string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTADisplayURL) && !string.IsNullOrWhiteSpace(this.policy.CustomUIPagePolicy.FTAURL)));
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004B28 File Offset: 0x00002D28
		private void OnCheckUserModeRestrictions()
		{
			IPCmoverEngine pcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
			bool doReturn = false;
			try
			{
				if (!pcmoverEngine.CatchCommEx(delegate
				{
					if (pcmoverEngine.OtherMachine != null && !pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin && !pcmoverEngine.OtherMachine.IsEngineRunningAsAdmin)
					{
						this.LimitedUserText = PCmover.Properties.Resources.LU_LimitedToLimited;
						this.IsLimitedUser = true;
						doReturn = true;
					}
				}, "OnCheckUserModeRestrictions"))
				{
					return;
				}
				if (doReturn)
				{
					return;
				}
			}
			catch
			{
			}
			try
			{
				if (!pcmoverEngine.CatchCommEx(delegate
				{
					if (pcmoverEngine.OtherMachine != null && !pcmoverEngine.OtherMachine.IsEngineRunningAsAdmin)
					{
						this.LimitedUserText = PCmover.Properties.Resources.LU_LimitedToAdmin;
						this.IsLimitedUser = true;
						doReturn = true;
					}
				}, "OnCheckUserModeRestrictions"))
				{
					return;
				}
				if (doReturn)
				{
					return;
				}
			}
			catch
			{
			}
			try
			{
				if (!pcmoverEngine.CatchCommEx(delegate
				{
					if (pcmoverEngine.ThisMachine != null && !pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin)
					{
						this.LimitedUserText = PCmover.Properties.Resources.LU_AdminToLimited;
						if (!this.IsLimitedUser)
						{
							this.IsLimitedUser = true;
						}
						doReturn = true;
					}
				}, "OnCheckUserModeRestrictions"))
				{
					return;
				}
				if (doReturn)
				{
					return;
				}
			}
			catch
			{
			}
			this.IsLimitedUser = false;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004C20 File Offset: 0x00002E20
		private void OnPreviousInstanceShuttingDown()
		{
			this.IsEngineInitInProgressPopupOpen = true;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00004C29 File Offset: 0x00002E29
		private void OnNoLocalEvent()
		{
			this.IsNoLocalOpen = true;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00004C34 File Offset: 0x00002E34
		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			System.Windows.Application.Current.MainWindow.Show();
			System.Windows.Application.Current.MainWindow.ShowInTaskbar = true;
			if (this.notifyIcon != null)
			{
				this.notifyIcon.Visible = false;
				this.notifyIcon.DoubleClick -= this.notifyIcon_DoubleClick;
				this.notifyIcon = null;
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00004C92 File Offset: 0x00002E92
		private void OnWindowClosed(Notification notification)
		{
			object content = notification.Content;
		}

		// Token: 0x04000024 RID: 36
		private readonly uint fPreviousExecutionState;

		// Token: 0x04000025 RID: 37
		private DefaultPolicy policy;

		// Token: 0x04000026 RID: 38
		private NotifyIcon notifyIcon;

		// Token: 0x04000027 RID: 39
		private readonly LlTraceSource _ts;

		// Token: 0x04000028 RID: 40
		private bool _engineInitialized;

		// Token: 0x04000029 RID: 41
		private bool _IsLatestVersion;

		// Token: 0x0400002A RID: 42
		private string _ATitle;

		// Token: 0x0400002B RID: 43
		private string _Title;

		// Token: 0x0400002C RID: 44
		private bool _IsClosing;

		// Token: 0x0400002D RID: 45
		private bool _IsMenuVisable;

		// Token: 0x0400002E RID: 46
		private Brush _BorderBrush = Brushes.Silver;

		// Token: 0x0400002F RID: 47
		private string _mbIcon = "/Laplink.Tools.Popups;component/Assets/NoneIcon.png";

		// Token: 0x04000030 RID: 48
		private bool showAppInvProgress;

		// Token: 0x04000031 RID: 49
		private bool isAboutOpen;

		// Token: 0x04000033 RID: 51
		private string latestVersion;

		// Token: 0x04000034 RID: 52
		private string _WindowsVersion;

		// Token: 0x04000035 RID: 53
		private double _Progress;

		// Token: 0x04000036 RID: 54
		private string _UpgradeURL;

		// Token: 0x04000037 RID: 55
		private bool _IsUpdating;

		// Token: 0x04000038 RID: 56
		private string _OverlayPopupTitle;

		// Token: 0x04000039 RID: 57
		private bool _ISOverlayPopupOpen;

		// Token: 0x0400003A RID: 58
		private NetworkStatsData _NetworkData;

		// Token: 0x0400003B RID: 59
		private bool _ISNetworkStatsVisible;

		// Token: 0x0400003C RID: 60
		private string _FTADisplayUrl;

		// Token: 0x0400003D RID: 61
		private bool _IsFTAVisible;

		// Token: 0x0400003E RID: 62
		private string _FTATopText;

		// Token: 0x0400003F RID: 63
		private string _FTABottomText;

		// Token: 0x04000040 RID: 64
		private string _FTAImagePath;

		// Token: 0x04000041 RID: 65
		private bool _IsLimitedUserPopupOpen;

		// Token: 0x04000042 RID: 66
		private bool _IsLimitedUser;

		// Token: 0x04000043 RID: 67
		private string _LimitedUserText;

		// Token: 0x04000044 RID: 68
		private string _LicenseInfoText;

		// Token: 0x04000045 RID: 69
		private bool _IsAnimationEnabled;

		// Token: 0x04000046 RID: 70
		private bool showUserGuideButton;

		// Token: 0x04000047 RID: 71
		private bool _IsNoLocalOpen;

		// Token: 0x04000048 RID: 72
		private bool _IsEngineInitInProgressPopupOpen;

		// Token: 0x04000049 RID: 73
		private bool _IsCompactUI;

		// Token: 0x0400004A RID: 74
		private readonly InteractionRequest<Notification> _interactionRequest;

		// Token: 0x0400004B RID: 75
		private bool _IsQuickstepsEnabled;

		// Token: 0x0400004C RID: 76
		private string _OnlineSupport;

		// Token: 0x0400004D RID: 77
		private string _CopyrightText;

		// Token: 0x04000058 RID: 88
		private bool _CloseConfirmationRequired;

		// Token: 0x04000059 RID: 89
		private string _CloseConfirmationPrompt;
	}
}
