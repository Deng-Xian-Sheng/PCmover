using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
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
	// Token: 0x02000089 RID: 137
	public class FindPCPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x0600096D RID: 2413 RVA: 0x00016820 File Offset: 0x00014A20
		public FindPCPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, IEditionModule editionModule, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			FindPCPageViewModel <>4__this = this;
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this._editionData = ((editionModule != null) ? editionModule.Data : null);
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.ScanAgain = new DelegateCommand(new Action(this.OnScanAgainCommand), new Func<bool>(this.CanOnScanAgainCommand));
			this.OnChangeConnectionMethod = new DelegateCommand(new Action(this.OnOnChangeConnectionMethodCommand), new Func<bool>(this.CanOnOnChangeConnectionMethodCommand));
			this.OnHowLong = new DelegateCommand(new Action(this.OnHowLongCommand), new Func<bool>(this.CanOnHowLongCommand));
			this.OnReverse = new DelegateCommand(new Action(this.OnReverseCommand), new Func<bool>(this.CanOnReverseCommand));
			this.DoInfo = new DelegateCommand(new Action(this.DoInfoCommand), new Func<bool>(this.CanDoInfoCommand));
			this.CloseInfo = new DelegateCommand(new Action(this.OnCloseInfoCommand), new Func<bool>(this.CanOnCloseInfoCommand));
			this.CloseDisplayHowLong = new DelegateCommand(new Action(this.OnCloseDisplayHowLongCommand), new Func<bool>(this.CanOnCloseDisplayHowLongCommand));
			this.OnStopFind = new DelegateCommand(new Action(this.OnStopFindCommand));
			this.OnSerialNumber = new DelegateCommand(new Action(this.OnSerialNumberCommand), new Func<bool>(this.CanOnSerialNumberCommand));
			this.OnDownloadPCmover = new DelegateCommand(new Action(this.OnDownloadPCmoverCommand), new Func<bool>(this.CanOnDownloadPCmoverCommand));
			this.OnSupport = new DelegateCommand(new Action(this.OnSupportCommand), new Func<bool>(this.CanOnSupportCommand));
			this.OnShowRequestHost = new DelegateCommand(new Action(this.OnShowRequestHostCommand), new Func<bool>(this.CanOnShowRequestHostCommand));
			this.OnRequestHost = new DelegateCommand(new Action(this.OnRequestHostCommand), new Func<bool>(this.CanOnRequestHostCommand));
			this.OnCancelRequestHost = new DelegateCommand(new Action(this.OnCancelRequestHostCommand), new Func<bool>(this.CanOnCancelRequestHostCommand));
			this.OnVPro = new DelegateCommand(new Action(this.OnVProCommand), new Func<bool>(this.CanOnVProCommand));
			eventAggregator.GetEvent<Events.ConnectionReceived>().Subscribe(new Action<ConnectionReceivedInfo>(this.OnConnectionReceived));
			eventAggregator.GetEvent<Events.ShutdownEvent>().Subscribe(new Action(this.Shutdown), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnPeekActivityInfo), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Subscribe(new Action<ConnectableMachine>(this.OnPeekSetDirection), ThreadOption.UIThread);
			pcmoverEngine.CatchCommEx(delegate
			{
				<>4__this.IsThisTheOldPC = pcmoverEngine.ThisMachineIsOld;
			}, ".ctor");
			this.isShowAttemptingWiFi = false;
			this.Machines = new ObservableCollection<ConnectableMachine>();
			this.OtherMachines = new ObservableCollection<ConnectableMachine>();
			this.findTimer.Tick += this.FindTimer_Tick;
			this._ConnectionIcon = "/WizardModule;component/Assets/file.png";
			this._ConnectionMethod = "File Based";
			this._DisplayConnection = false;
			this.ReverseDisabled = false;
			this.IsChangeConnectionMethodVisible = ((!(PcmBrandUI.Properties.Resources.Edition == "Express") || !(PcmBrandUI.Properties.Resources.OEM == "Intel")) && !PcmBrandUI.Properties.Resources.Edition.StartsWith("Enterprise"));
			this.IsRequestHostVisible = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowRequestHostLink);
			this.RequestedHost = string.Empty;
			this.CertName = string.Empty;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00016C1C File Offset: 0x00014E1C
		private void Stop()
		{
			this.findTimer.Stop();
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00016C2C File Offset: 0x00014E2C
		private bool matchSerialNumber(ConnectableMachine machine)
		{
			IWizardParameters wizardParameters = this.container.Resolve(Array.Empty<ResolverOverride>());
			if (!string.IsNullOrEmpty(wizardParameters.ConnectionId))
			{
				return machine.SerialNumber.ToLower() == wizardParameters.ConnectionId.ToLower();
			}
			return machine.XPVersion || (string.IsNullOrWhiteSpace(machine.SerialNumber) && string.IsNullOrWhiteSpace(this.SerialNumber)) || Tools.NormalizeSerialNumber(machine.SerialNumber) == this.SerialNumber;
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x00016CAF File Offset: 0x00014EAF
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x00016CB7 File Offset: 0x00014EB7
		public ObservableCollection<ConnectableMachine> Machines
		{
			get
			{
				return this._Machines;
			}
			private set
			{
				this.SetProperty<ObservableCollection<ConnectableMachine>>(ref this._Machines, value, "Machines");
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x00016CCC File Offset: 0x00014ECC
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x00016CD4 File Offset: 0x00014ED4
		public ObservableCollection<ConnectableMachine> OtherMachines
		{
			get
			{
				return this._OtherMachines;
			}
			private set
			{
				this.SetProperty<ObservableCollection<ConnectableMachine>>(ref this._OtherMachines, value, "OtherMachines");
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00016CE9 File Offset: 0x00014EE9
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x00016CF1 File Offset: 0x00014EF1
		public string OldPC
		{
			get
			{
				return this._OldPC;
			}
			private set
			{
				this.SetProperty<string>(ref this._OldPC, value, "OldPC");
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x00016D06 File Offset: 0x00014F06
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x00016D0E File Offset: 0x00014F0E
		public string NewPC
		{
			get
			{
				return this._NewPC;
			}
			private set
			{
				this.SetProperty<string>(ref this._NewPC, value, "NewPC");
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x00016D23 File Offset: 0x00014F23
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x00016D2B File Offset: 0x00014F2B
		public string OtherPC
		{
			get
			{
				return this._OtherPC;
			}
			private set
			{
				if (this._OtherPC != value)
				{
					this.SetProperty<string>(ref this._OtherPC, value, "OtherPC");
					this.CheckOSReversal();
				}
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x00016D55 File Offset: 0x00014F55
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x00016D5D File Offset: 0x00014F5D
		public string NetworkName
		{
			get
			{
				return this._NetworkName;
			}
			private set
			{
				this.SetProperty<string>(ref this._NetworkName, value, "NetworkName");
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00016D72 File Offset: 0x00014F72
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00016D7A File Offset: 0x00014F7A
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsBusy, value, "IsBusy");
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00016D8F File Offset: 0x00014F8F
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00016D97 File Offset: 0x00014F97
		public bool ShowSidePanel
		{
			get
			{
				return this._ShowSidePanel;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowSidePanel, value, "ShowSidePanel");
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00016DAC File Offset: 0x00014FAC
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x00016DB4 File Offset: 0x00014FB4
		public bool IsFound
		{
			get
			{
				return this._IsFound;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsFound, value, "IsFound");
				if (!this._IsFound && this._IsThisTheOldPC)
				{
					this.IsThisTheOldPC = false;
				}
				this.OnReverse.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00016DEB File Offset: 0x00014FEB
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00016DFD File Offset: 0x00014FFD
		public bool ReverseDisabled
		{
			get
			{
				return this._ReverseDisabled || this._reverseInProgress;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ReverseDisabled, value, "ReverseDisabled");
				this.OnReverse.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x00016E1D File Offset: 0x0001501D
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x00016E25 File Offset: 0x00015025
		public bool IsAnalyzeButtonEnabled
		{
			get
			{
				return this._IsAnalyzeButtonEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsAnalyzeButtonEnabled, value, "IsAnalyzeButtonEnabled");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00016E45 File Offset: 0x00015045
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00016E4D File Offset: 0x0001504D
		public bool IsScanAgainButtonEnabled
		{
			get
			{
				return this._IsScanAgainButtonEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsScanAgainButtonEnabled, value, "IsScanAgainButtonEnabled");
				this.ScanAgain.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x00016E6D File Offset: 0x0001506D
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00016E75 File Offset: 0x00015075
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

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00016E8A File Offset: 0x0001508A
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x00016E92 File Offset: 0x00015092
		public int NumItems
		{
			get
			{
				return this._NumItems;
			}
			private set
			{
				this.SetProperty<int>(ref this._NumItems, value, "NumItems");
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x00016EA7 File Offset: 0x000150A7
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x00016EB0 File Offset: 0x000150B0
		public bool IsThisTheOldPC
		{
			get
			{
				return this._IsThisTheOldPC;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsThisTheOldPC, value, "IsThisTheOldPC");
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.ThisMachineIsOld = this._IsThisTheOldPC;
					this.IsScanAgainButtonEnabled = !this._IsThisTheOldPC;
					if (this._IsThisTheOldPC)
					{
						this.IsAnalyzeButtonEnabled = false;
						return;
					}
					ConnectableMachine targetMachine = base.pcmoverEngine.TargetMachine;
					this.IsAnalyzeButtonEnabled = !string.IsNullOrEmpty((targetMachine != null) ? targetMachine.FriendlyName : null);
				}, "IsThisTheOldPC");
				if (!this._IsFound && this._IsThisTheOldPC)
				{
					this.IsFound = true;
				}
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x00016F04 File Offset: 0x00015104
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x00016F0C File Offset: 0x0001510C
		public bool IsLicenseMismatch
		{
			get
			{
				return this._IsLicenseMismatch;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsLicenseMismatch, value, "IsLicenseMismatch");
				if (this._IsLicenseMismatch)
				{
					this.ArrowUri = "/WizardModule;component/Assets/LicenseMismatch.png";
				}
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x00016F34 File Offset: 0x00015134
		// (set) Token: 0x06000991 RID: 2449 RVA: 0x00016F3C File Offset: 0x0001513C
		public ConnectableMachine CurrentSelectedMachine
		{
			get
			{
				return this._CurrentSelectedMachine;
			}
			set
			{
				if (value != null)
				{
					this.SetProperty<ConnectableMachine>(ref this._CurrentSelectedMachine, value, "CurrentSelectedMachine");
				}
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x00016F54 File Offset: 0x00015154
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x00016F5C File Offset: 0x0001515C
		public string ConnectionMethod
		{
			get
			{
				return this._ConnectionMethod;
			}
			private set
			{
				this.SetProperty<string>(ref this._ConnectionMethod, value, "ConnectionMethod");
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x00016F71 File Offset: 0x00015171
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x00016F79 File Offset: 0x00015179
		public string ConnectionIcon
		{
			get
			{
				return this._ConnectionIcon;
			}
			private set
			{
				this.SetProperty<string>(ref this._ConnectionIcon, value, "ConnectionIcon");
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x00016F8E File Offset: 0x0001518E
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x00016F96 File Offset: 0x00015196
		public bool DisplayConnection
		{
			get
			{
				return this._DisplayConnection;
			}
			private set
			{
				this.SetProperty<bool>(ref this._DisplayConnection, value, "DisplayConnection");
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x00016FAB File Offset: 0x000151AB
		// (set) Token: 0x06000999 RID: 2457 RVA: 0x00016FB3 File Offset: 0x000151B3
		public bool DisplayInfo
		{
			get
			{
				return this._DisplayInfo;
			}
			set
			{
				this.SetProperty<bool>(ref this._DisplayInfo, value, "DisplayInfo");
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x00016FC8 File Offset: 0x000151C8
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x00016FD0 File Offset: 0x000151D0
		public bool DisplayHowLong
		{
			get
			{
				return this._DisplayHowLong;
			}
			set
			{
				this.SetProperty<bool>(ref this._DisplayHowLong, value, "DisplayHowLong");
			}
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x00016FE5 File Offset: 0x000151E5
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x00016FED File Offset: 0x000151ED
		public string SerialNumber
		{
			get
			{
				return this._SerialNumber;
			}
			private set
			{
				this.SetProperty<string>(ref this._SerialNumber, Tools.NormalizeSerialNumber(value), "SerialNumber");
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x00017007 File Offset: 0x00015207
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x0001700F File Offset: 0x0001520F
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

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x00017024 File Offset: 0x00015224
		public string FPP_HowLong2
		{
			get
			{
				return PcmBrandUI.Properties.Resources.FPP_HowLong2;
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0001702B File Offset: 0x0001522B
		// (set) Token: 0x060009A2 RID: 2466 RVA: 0x00017034 File Offset: 0x00015234
		public bool UseSSL
		{
			get
			{
				return this._UseSSL;
			}
			set
			{
				if (this.NetworkName != null && this.SSLCommittedMachines.ContainsKey(this.NetworkName) && this.SSLCommittedMachines[this.NetworkName] != value)
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, WizardModule.Properties.Resources.FPP_SSLCommittedError, PcmBrandUI.Properties.Resources.ProgramName, PopupEvents.MBType.MB_OK, MessageBoxImage.Asterisk, MessageBoxResult.None).ConfigureAwait(false);
					return;
				}
				this.SetProperty<bool>(ref this._UseSSL, value, "UseSSL");
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.UseSSL = this._UseSSL;
				}, "UseSSL");
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x000170C7 File Offset: 0x000152C7
		// (set) Token: 0x060009A4 RID: 2468 RVA: 0x000170CF File Offset: 0x000152CF
		public bool ShowSSL
		{
			get
			{
				return this._ShowSSL;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowSSL, value, "ShowSSL");
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000170E4 File Offset: 0x000152E4
		// (set) Token: 0x060009A6 RID: 2470 RVA: 0x000170EC File Offset: 0x000152EC
		public bool IsVersionMismatchPopupOpen
		{
			get
			{
				return this._IsVersionMismatchPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVersionMismatchPopupOpen, value, "IsVersionMismatchPopupOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x00017112 File Offset: 0x00015312
		// (set) Token: 0x060009A8 RID: 2472 RVA: 0x0001711A File Offset: 0x0001531A
		public string VersionMismatchError
		{
			get
			{
				return this._VersionMismatchError;
			}
			set
			{
				this.SetProperty<string>(ref this._VersionMismatchError, value, "VersionMismatchError");
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x0001712F File Offset: 0x0001532F
		// (set) Token: 0x060009AA RID: 2474 RVA: 0x00017137 File Offset: 0x00015337
		public bool IsChangeConnectionMethodVisible
		{
			get
			{
				return this._IsChangeConnectionMethodVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsChangeConnectionMethodVisible, value, "IsChangeConnectionMethodVisible");
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x0001714C File Offset: 0x0001534C
		// (set) Token: 0x060009AC RID: 2476 RVA: 0x00017154 File Offset: 0x00015354
		public bool IsRequestHostPopupOpen
		{
			get
			{
				return this._IsRequestHostPopupOpen;
			}
			set
			{
				if (value)
				{
					this.resetScreen();
				}
				this.SetProperty<bool>(ref this._IsRequestHostPopupOpen, value, "IsRequestHostPopupOpen");
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x00017172 File Offset: 0x00015372
		// (set) Token: 0x060009AE RID: 2478 RVA: 0x0001717A File Offset: 0x0001537A
		public bool IsRequestHostVisible
		{
			get
			{
				return this._IsRequestHostVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsRequestHostVisible, value, "IsRequestHostVisible");
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0001718F File Offset: 0x0001538F
		// (set) Token: 0x060009B0 RID: 2480 RVA: 0x00017197 File Offset: 0x00015397
		public string RequestedHost
		{
			get
			{
				return this._RequestedHost;
			}
			set
			{
				this.SetProperty<string>(ref this._RequestedHost, value, "RequestedHost");
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x000171AC File Offset: 0x000153AC
		// (set) Token: 0x060009B2 RID: 2482 RVA: 0x000171B4 File Offset: 0x000153B4
		public string CertName
		{
			get
			{
				return this._CertName;
			}
			set
			{
				this.SetProperty<string>(ref this._CertName, value, "CertName");
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x000171C9 File Offset: 0x000153C9
		// (set) Token: 0x060009B4 RID: 2484 RVA: 0x000171D1 File Offset: 0x000153D1
		public bool CertNameRequired
		{
			get
			{
				return this._CertNameRequired;
			}
			set
			{
				this.SetProperty<bool>(ref this._CertNameRequired, value, "CertNameRequired");
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x000171E6 File Offset: 0x000153E6
		// (set) Token: 0x060009B6 RID: 2486 RVA: 0x000171EE File Offset: 0x000153EE
		public string RequestHostStatus
		{
			get
			{
				return this._RequestHostStatus;
			}
			set
			{
				this.SetProperty<string>(ref this._RequestHostStatus, value, "RequestHostStatus");
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x00017203 File Offset: 0x00015403
		// (set) Token: 0x060009B8 RID: 2488 RVA: 0x0001720B File Offset: 0x0001540B
		public bool RequestHostSpinnerActive
		{
			get
			{
				return this._RequestHostSpinnerActive;
			}
			set
			{
				this.SetProperty<bool>(ref this._RequestHostSpinnerActive, value, "RequestHostSpinnerActive");
				this.OnRequestHost.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0001722B File Offset: 0x0001542B
		// (set) Token: 0x060009BA RID: 2490 RVA: 0x00017233 File Offset: 0x00015433
		public bool IsVproVisible
		{
			get
			{
				return this._IsVproVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsVproVisible, value, "IsVproVisible");
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x00017248 File Offset: 0x00015448
		// (set) Token: 0x060009BC RID: 2492 RVA: 0x00017250 File Offset: 0x00015450
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060009BD RID: 2493 RVA: 0x00017259 File Offset: 0x00015459
		private bool CanOnNextCommand()
		{
			return this.IsAnalyzeButtonEnabled && !this.IsBusy && !this.IsLicenseMismatch;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00017278 File Offset: 0x00015478
		private void OnNextCommand()
		{
			if (!this.IsValidMachinePair())
			{
				return;
			}
			if (!this.VerifyCertName())
			{
				return;
			}
			if (!this.SSLCommittedMachines.ContainsKey(this.NetworkName))
			{
				this.SSLCommittedMachines.Add(this.NetworkName, this._UseSSL);
			}
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("AnalyzePCPage", UriKind.Relative));
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.policy.enginePolicy.Connection.Network.SetDefaultTarget(base.pcmoverEngine.TargetMachine.NetName);
				this.policy.WriteProfile();
			}, "OnNextCommand");
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x000172F9 File Offset: 0x000154F9
		// (set) Token: 0x060009C0 RID: 2496 RVA: 0x00017301 File Offset: 0x00015501
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x060009C1 RID: 2497 RVA: 0x0001730A File Offset: 0x0001550A
		private bool CanOnBackCommand()
		{
			return !this._reverseInProgress;
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00017315 File Offset: 0x00015515
		private void OnBackCommand()
		{
			this.policy.enginePolicy.Connection.Network.SetDefaultTarget(null);
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00017340 File Offset: 0x00015540
		private Task StartFindingComputers()
		{
			FindPCPageViewModel.<StartFindingComputers>d__185 <StartFindingComputers>d__;
			<StartFindingComputers>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StartFindingComputers>d__.<>4__this = this;
			<StartFindingComputers>d__.<>1__state = -1;
			<StartFindingComputers>d__.<>t__builder.Start<FindPCPageViewModel.<StartFindingComputers>d__185>(ref <StartFindingComputers>d__);
			return <StartFindingComputers>d__.<>t__builder.Task;
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x00017383 File Offset: 0x00015583
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x0001738B File Offset: 0x0001558B
		public DelegateCommand ScanAgain { get; private set; }

		// Token: 0x060009C6 RID: 2502 RVA: 0x00017394 File Offset: 0x00015594
		private bool CanOnScanAgainCommand()
		{
			return this.IsScanAgainButtonEnabled && !this.container.Resolve(Array.Empty<ResolverOverride>()).IsOld;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x000173B8 File Offset: 0x000155B8
		private void OnScanAgainCommand()
		{
			FindPCPageViewModel.<OnScanAgainCommand>d__191 <OnScanAgainCommand>d__;
			<OnScanAgainCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnScanAgainCommand>d__.<>4__this = this;
			<OnScanAgainCommand>d__.<>1__state = -1;
			<OnScanAgainCommand>d__.<>t__builder.Start<FindPCPageViewModel.<OnScanAgainCommand>d__191>(ref <OnScanAgainCommand>d__);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x000173F0 File Offset: 0x000155F0
		private Task OnScanAgainCommandAsync()
		{
			FindPCPageViewModel.<OnScanAgainCommandAsync>d__192 <OnScanAgainCommandAsync>d__;
			<OnScanAgainCommandAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<OnScanAgainCommandAsync>d__.<>4__this = this;
			<OnScanAgainCommandAsync>d__.<>1__state = -1;
			<OnScanAgainCommandAsync>d__.<>t__builder.Start<FindPCPageViewModel.<OnScanAgainCommandAsync>d__192>(ref <OnScanAgainCommandAsync>d__);
			return <OnScanAgainCommandAsync>d__.<>t__builder.Task;
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x00017433 File Offset: 0x00015633
		// (set) Token: 0x060009CA RID: 2506 RVA: 0x0001743B File Offset: 0x0001563B
		public DelegateCommand OnChangeConnectionMethod { get; private set; }

		// Token: 0x060009CB RID: 2507 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnOnChangeConnectionMethodCommand()
		{
			return true;
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00017444 File Offset: 0x00015644
		private void OnOnChangeConnectionMethodCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindFastestTransferType", UriKind.Relative));
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x00017461 File Offset: 0x00015661
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x00017469 File Offset: 0x00015669
		public DelegateCommand OnHowLong { get; private set; }

		// Token: 0x060009CF RID: 2511 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnHowLongCommand()
		{
			return true;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00017472 File Offset: 0x00015672
		private void OnHowLongCommand()
		{
			this.DisplayHowLong = true;
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0001747B File Offset: 0x0001567B
		// (set) Token: 0x060009D2 RID: 2514 RVA: 0x00017483 File Offset: 0x00015683
		public DelegateCommand OnReverse { get; private set; }

		// Token: 0x060009D3 RID: 2515 RVA: 0x0001748C File Offset: 0x0001568C
		private bool CanOnReverseCommand()
		{
			return this.IsFound && !this.IsLicenseMismatch && !this.ReverseDisabled;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000174AC File Offset: 0x000156AC
		private void OnReverseCommand()
		{
			if (!this.VerifyCertName())
			{
				return;
			}
			ConnectableMachine otherPC = base.pcmoverEngine.TargetMachine;
			if (otherPC.Status == DiscoveredMachineStatus.ManualConnection || otherPC.Status == DiscoveredMachineStatus.RemoteManualConnection || otherPC.Status == DiscoveredMachineStatus.MachineFound)
			{
				this.findTimer.Stop();
				this._reverseInProgress = true;
				otherPC.IsOld = this.IsThisTheOldPC;
				base.pcmoverEngine.CatchCommEx(delegate
				{
					if (!this.pcmoverEngine.SetDirection(otherPC))
					{
						this._reverseInProgress = false;
					}
				}, "OnReverseCommand");
				return;
			}
			this.OnCompleteReverse();
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00017554 File Offset: 0x00015754
		private void OnCompleteReverse()
		{
			this.findTimer.Stop();
			string oldPC = this.OldPC;
			this.OldPC = this.NewPC;
			this.NewPC = oldPC;
			this.IsThisTheOldPC = !this.IsThisTheOldPC;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.TargetMachine.IsOld = !base.pcmoverEngine.TargetMachine.IsOld;
				this.migrationDefinition.IsPCName1Old = true;
				this.migrationDefinition.PCName1 = this.OldPC;
				this.migrationDefinition.PCName2 = this.NewPC;
				this.ReverseDisabled = (this.IsThisTheOldPC && base.pcmoverEngine.TargetMachine.Status == DiscoveredMachineStatus.RemoteManualConnection);
				this.CheckOSReversal();
			}, "OnCompleteReverse");
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x000175B4 File Offset: 0x000157B4
		private void OnSetDirection(ConnectableMachine machine)
		{
			base.pcmoverEngine.Ts.TraceInformation(string.Format("OnSetDirection: {0}, {1}, {2}", machine.NetName, machine.Status, machine.Method));
			if (machine.Status == DiscoveredMachineStatus.DirectionNotification)
			{
				ConnectableMachine connectableMachine;
				if (base.pcmoverEngine.TargetMachine != null && base.pcmoverEngine.TargetMachine.SameMachine(machine))
				{
					connectableMachine = base.pcmoverEngine.TargetMachine;
				}
				else
				{
					connectableMachine = this.Machines.FirstOrDefault((ConnectableMachine x) => x.SameMachine(machine));
				}
				if (connectableMachine == null)
				{
					return;
				}
				connectableMachine.IsOld = machine.IsOld;
				machine = connectableMachine;
			}
			this.findTimer.Stop();
			string thisPC = string.Empty;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				IPCmoverEngine pcmoverEngine = this.pcmoverEngine;
				string text;
				if (pcmoverEngine == null)
				{
					text = null;
				}
				else
				{
					MachineData thisMachine = pcmoverEngine.ThisMachine;
					text = ((thisMachine != null) ? thisMachine.FriendlyName : null);
				}
				thisPC = (text ?? string.Empty);
			}, "OnSetDirection");
			if (machine.IsOld)
			{
				this.IsThisTheOldPC = false;
				this.OldPC = machine.FriendlyName;
				this.NewPC = thisPC;
				this.ReverseDisabled = false;
			}
			else
			{
				this.IsThisTheOldPC = true;
				this.OldPC = thisPC;
				this.NewPC = machine.FriendlyName;
				this.ReverseDisabled = (machine.Status == DiscoveredMachineStatus.RemoteManualConnection);
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.TargetMachine = machine;
				this.migrationDefinition.IsPCName1Old = true;
				this.migrationDefinition.PCName1 = this.OldPC;
				this.migrationDefinition.PCName2 = this.NewPC;
			}, "OnSetDirection");
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x00017755 File Offset: 0x00015955
		// (set) Token: 0x060009D8 RID: 2520 RVA: 0x0001775D File Offset: 0x0001595D
		public DelegateCommand DoInfo { get; private set; }

		// Token: 0x060009D9 RID: 2521 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanDoInfoCommand()
		{
			return true;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00017766 File Offset: 0x00015966
		private void DoInfoCommand()
		{
			this.DisplayInfo = true;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0000CE65 File Offset: 0x0000B065
		private void ResponseCallback(uint confirmed)
		{
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x0001776F File Offset: 0x0001596F
		// (set) Token: 0x060009DD RID: 2525 RVA: 0x00017777 File Offset: 0x00015977
		public DelegateCommand CloseInfo { get; private set; }

		// Token: 0x060009DE RID: 2526 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseInfoCommand()
		{
			return true;
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00017780 File Offset: 0x00015980
		private void OnCloseInfoCommand()
		{
			this.DisplayInfo = false;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x00017789 File Offset: 0x00015989
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x00017791 File Offset: 0x00015991
		public DelegateCommand CloseDisplayHowLong { get; private set; }

		// Token: 0x060009E2 RID: 2530 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCloseDisplayHowLongCommand()
		{
			return true;
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0001779A File Offset: 0x0001599A
		private void OnCloseDisplayHowLongCommand()
		{
			this.DisplayHowLong = false;
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x000177A3 File Offset: 0x000159A3
		// (set) Token: 0x060009E5 RID: 2533 RVA: 0x000177AB File Offset: 0x000159AB
		public DelegateCommand OnStopFind { get; private set; }

		// Token: 0x060009E6 RID: 2534 RVA: 0x000177B4 File Offset: 0x000159B4
		private void OnStopFindCommand()
		{
			if (this.policy.findPCPagePolicy.FindPcTimeout == 0)
			{
				this.policy.findPCPagePolicy.FindPcTimeout = 60;
			}
			this.NoComputersFoundPopupDelay = 1;
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x000177E1 File Offset: 0x000159E1
		// (set) Token: 0x060009E8 RID: 2536 RVA: 0x000177E9 File Offset: 0x000159E9
		public DelegateCommand OnSerialNumber { get; private set; }

		// Token: 0x060009E9 RID: 2537 RVA: 0x000177F2 File Offset: 0x000159F2
		private bool CanOnSerialNumberCommand()
		{
			return !base.pcmoverEngine.License.IsSerialNumberFromPolicy || (base.pcmoverEngine.License.IsSerialNumberFromPolicy && this.policy.licensePagePolicy.AllowReentryOnError);
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0001782C File Offset: 0x00015A2C
		private void OnSerialNumberCommand()
		{
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("NextPage", "FindPCPage");
			navigationParameters.Add("AutoNavigate", false);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LicensePage", UriKind.Relative), navigationParameters);
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x0001787C File Offset: 0x00015A7C
		// (set) Token: 0x060009EC RID: 2540 RVA: 0x00017884 File Offset: 0x00015A84
		public DelegateCommand OnDownloadPCmover { get; private set; }

		// Token: 0x060009ED RID: 2541 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDownloadPCmoverCommand()
		{
			return true;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x00017890 File Offset: 0x00015A90
		private void OnDownloadPCmoverCommand()
		{
			try
			{
				Process.Start(new ProcessStartInfo(PcmBrandUI.Properties.Resources.FPP_Download));
			}
			catch
			{
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x000178C4 File Offset: 0x00015AC4
		// (set) Token: 0x060009F0 RID: 2544 RVA: 0x000178CC File Offset: 0x00015ACC
		public DelegateCommand OnSupport { get; private set; }

		// Token: 0x060009F1 RID: 2545 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSupportCommand()
		{
			return true;
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x000178D5 File Offset: 0x00015AD5
		private void OnSupportCommand()
		{
			Tools.OpenSupport(this.policy);
			this.IsVersionMismatchPopupOpen = false;
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x000178E9 File Offset: 0x00015AE9
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x000178F1 File Offset: 0x00015AF1
		public DelegateCommand OnShowRequestHost { get; private set; }

		// Token: 0x060009F5 RID: 2549 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnShowRequestHostCommand()
		{
			return true;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x000178FC File Offset: 0x00015AFC
		private void OnShowRequestHostCommand()
		{
			if (this.IsRequestHostPopupOpen)
			{
				return;
			}
			this.RequestHostStatus = string.Empty;
			this.RequestHostSpinnerActive = false;
			SSLFlags sslFlags = base.pcmoverEngine.Policy.Connection.Network.SslFlags;
			this.CertNameRequired = sslFlags.HasFlag(SSLFlags.EnforceCertificateName);
			this.findTimer.Stop();
			this.Machines.Clear();
			this.IsBusy = false;
			this.IsRequestHostPopupOpen = true;
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x0001797A File Offset: 0x00015B7A
		// (set) Token: 0x060009F8 RID: 2552 RVA: 0x00017982 File Offset: 0x00015B82
		public DelegateCommand OnRequestHost { get; private set; }

		// Token: 0x060009F9 RID: 2553 RVA: 0x0001798B File Offset: 0x00015B8B
		private bool CanOnRequestHostCommand()
		{
			return !this.RequestHostSpinnerActive;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00017998 File Offset: 0x00015B98
		private void OnRequestHostCommand()
		{
			FindPCPageViewModel.<OnRequestHostCommand>d__266 <OnRequestHostCommand>d__;
			<OnRequestHostCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnRequestHostCommand>d__.<>4__this = this;
			<OnRequestHostCommand>d__.<>1__state = -1;
			<OnRequestHostCommand>d__.<>t__builder.Start<FindPCPageViewModel.<OnRequestHostCommand>d__266>(ref <OnRequestHostCommand>d__);
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x000179CF File Offset: 0x00015BCF
		// (set) Token: 0x060009FC RID: 2556 RVA: 0x000179D7 File Offset: 0x00015BD7
		public DelegateCommand OnCancelRequestHost { get; private set; }

		// Token: 0x060009FD RID: 2557 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelRequestHostCommand()
		{
			return true;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000179E0 File Offset: 0x00015BE0
		private void OnCancelRequestHostCommand()
		{
			this.IsRequestHostPopupOpen = false;
			this.RequestHostSpinnerActive = false;
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x000179F0 File Offset: 0x00015BF0
		// (set) Token: 0x06000A00 RID: 2560 RVA: 0x000179F8 File Offset: 0x00015BF8
		public DelegateCommand OnVPro { get; set; }

		// Token: 0x06000A01 RID: 2561 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnVProCommand()
		{
			return true;
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00017A04 File Offset: 0x00015C04
		private void OnVProCommand()
		{
			FindPCPageViewModel.<OnVProCommand>d__278 <OnVProCommand>d__;
			<OnVProCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnVProCommand>d__.<>4__this = this;
			<OnVProCommand>d__.<>1__state = -1;
			<OnVProCommand>d__.<>t__builder.Start<FindPCPageViewModel.<OnVProCommand>d__278>(ref <OnVProCommand>d__);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00017A3B File Offset: 0x00015C3B
		private void resetScreen()
		{
			IPCmoverEngine pcmoverEngine = base.pcmoverEngine;
			if (pcmoverEngine == null)
			{
				return;
			}
			pcmoverEngine.CatchCommEx(delegate
			{
				IPCmoverEngine pcmoverEngine2 = base.pcmoverEngine;
				string newPC;
				if (pcmoverEngine2 == null)
				{
					newPC = null;
				}
				else
				{
					MachineData thisMachine = pcmoverEngine2.ThisMachine;
					newPC = ((thisMachine != null) ? thisMachine.FriendlyName : null);
				}
				this.NewPC = newPC;
				this.OldPC = string.Empty;
				this.IsThisTheOldPC = false;
				this.NetworkName = WizardModule.Properties.Resources.strUnknown;
				this.IsFound = false;
				this.IsLicenseMismatch = false;
				this.ReverseDisabled = this.sourceSpecified;
				this.eventAggregator.GetEvent<Events.CloseOverlayPopup>().Publish();
			}, "resetScreen");
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00017A5F File Offset: 0x00015C5F
		private void OnConnectionReceived(ConnectionReceivedInfo obj)
		{
			base.pcmoverEngine.Ts.TraceInformation("FindPCPageViewModel.OnConnectionReceived: Set ThisMachineIsOld = true");
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.ThisMachineIsOld = true;
			}, "OnConnectionReceived");
			this.ReverseDisabled = true;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00017A9C File Offset: 0x00015C9C
		private void OnMachineStatus(ConnectableMachine machine)
		{
			FindPCPageViewModel.<OnMachineStatus>d__281 <OnMachineStatus>d__;
			<OnMachineStatus>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnMachineStatus>d__.<>4__this = this;
			<OnMachineStatus>d__.machine = machine;
			<OnMachineStatus>d__.<>1__state = -1;
			<OnMachineStatus>d__.<>t__builder.Start<FindPCPageViewModel.<OnMachineStatus>d__281>(ref <OnMachineStatus>d__);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00017ADC File Offset: 0x00015CDC
		private Task OnMachineStatusAsync(ConnectableMachine machine)
		{
			FindPCPageViewModel.<OnMachineStatusAsync>d__282 <OnMachineStatusAsync>d__;
			<OnMachineStatusAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<OnMachineStatusAsync>d__.<>4__this = this;
			<OnMachineStatusAsync>d__.machine = machine;
			<OnMachineStatusAsync>d__.<>1__state = -1;
			<OnMachineStatusAsync>d__.<>t__builder.Start<FindPCPageViewModel.<OnMachineStatusAsync>d__282>(ref <OnMachineStatusAsync>d__);
			return <OnMachineStatusAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00017B28 File Offset: 0x00015D28
		private bool OnFoundTargetComputer(ConnectableMachine newConnectableMachine)
		{
			if (newConnectableMachine == null || newConnectableMachine.NetName == null)
			{
				return false;
			}
			if (this.matchSerialNumber(newConnectableMachine))
			{
				this.Machines.AddOrUpdateMachine(newConnectableMachine);
				this.eventAggregator.GetEvent<Events.CloseOverlayPopup>().Publish();
			}
			else
			{
				this.OtherMachines.AddOrUpdateMachine(newConnectableMachine);
			}
			return true;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00017B78 File Offset: 0x00015D78
		private void OnLostTargetComputer(ConnectableMachine lostConnectableMachine)
		{
			this.migrationDefinition.UIConnectableMachines.RemoveMachine(lostConnectableMachine);
			this.Machines.RemoveMachine(lostConnectableMachine);
			this.OtherMachines.RemoveMachine(lostConnectableMachine);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00017BA6 File Offset: 0x00015DA6
		private void OnNoComputerFound()
		{
			this.IsBusy = false;
			this.ShowSidePanel = false;
			this.IsScanAgainButtonEnabled = true;
			this.ShowNotConnecting();
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00017BC4 File Offset: 0x00015DC4
		private void OnPeekActivityInfo(ActivityInfo activityInfo)
		{
			if (activityInfo.Type == ActivityType.Listen)
			{
				if (activityInfo.Phase == 2)
				{
					this.remoteMachineName = null;
					this.versionError = false;
					return;
				}
				if (activityInfo.Phase == 19)
				{
					this.remoteMachineName = activityInfo.Message;
					return;
				}
				if (activityInfo.Phase == 13)
				{
					this.versionError = true;
				}
			}
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00017C1A File Offset: 0x00015E1A
		private void OnPeekSetDirection(ConnectableMachine machine)
		{
			if (!this.findTimer.IsEnabled && machine.IsOld)
			{
				this.remoteMachineName = machine.NetName;
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00017C3D File Offset: 0x00015E3D
		private void OnVersionError()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (base.pcmoverEngine.Version.AppUpdateAvailable)
				{
					this.VersionMismatchError = PcmBrandUI.Properties.Resources.APCO_VersionMismatchError1;
				}
				else
				{
					this.VersionMismatchError = PcmBrandUI.Properties.Resources.APCO_VersionMismatchError3;
				}
				this.IsVersionMismatchPopupOpen = true;
			}, "OnVersionError");
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00017C5C File Offset: 0x00015E5C
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			if (activityInfo.Type == ActivityType.Listen)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					ListenActivityPhase phase = (ListenActivityPhase)activityInfo.Phase;
					if (activityInfo.State == ActivityState.Success || activityInfo.State == ActivityState.Failure || phase == ListenActivityPhase.EndReceived)
					{
						if (!this.discoveryStopped)
						{
							this.discoveryStopped = true;
							this.pcmoverEngine.StopActivityAsync(ActivityType.Discovery, false);
						}
						if (activityInfo.State == ActivityState.Success)
						{
							this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("TransferCompletePage", UriKind.Relative));
							return;
						}
					}
					else
					{
						if (phase == ListenActivityPhase.ConnectedOn)
						{
							this.findTimer.Stop();
							this.IsFound = true;
							this.IsThisTheOldPC = true;
							this.OldPC = this.pcmoverEngine.ThisMachine.FriendlyName;
							this.ReverseDisabled = true;
							this.eventAggregator.GetEvent<Events.ShowSSLIcon>().Publish(true);
							this.eventAggregator.GetEvent<Events.SSLInfoChanged>().Publish();
							return;
						}
						if (phase == ListenActivityPhase.RemoteMachineNameReceived)
						{
							this.NewPC = activityInfo.Message;
							this.migrationDefinition.PCName2 = this.NewPC;
							this.migrationDefinition.PCName1 = this.OldPC;
							this.migrationDefinition.IsPCName1Old = true;
							return;
						}
						if (phase == ListenActivityPhase.VersionError)
						{
							this.OnVersionError();
						}
					}
				}, "OnActivityInfo");
			}
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00017CA8 File Offset: 0x00015EA8
		private void FindTimer_Tick(object sender, EventArgs e)
		{
			FindPCPageViewModel.<>c__DisplayClass290_0 CS$<>8__locals1 = new FindPCPageViewModel.<>c__DisplayClass290_0();
			CS$<>8__locals1.<>4__this = this;
			if (sender != this && !this.findTimer.IsEnabled)
			{
				return;
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				CS$<>8__locals1.<>4__this.NewPC = CS$<>8__locals1.<>4__this.pcmoverEngine.ThisMachine.FriendlyName;
			}, "FindTimer_Tick");
			FindPCPageViewModel.<>c__DisplayClass290_0 CS$<>8__locals2 = CS$<>8__locals1;
			List<EnginePolicy.ConnectionPolicy.NetworkTargetItem> targets = this.policy.enginePolicy.Connection.Network.Targets;
			CS$<>8__locals2.oldPolicyMachine = ((targets != null) ? targets.FirstOrDefault((EnginePolicy.ConnectionPolicy.NetworkTargetItem x) => x.New.ToUpper() == CS$<>8__locals1.<>4__this.pcmoverEngine.ThisMachine.NetName.ToUpper()) : null);
			if (CS$<>8__locals1.oldPolicyMachine != null)
			{
				base.pcmoverEngine.Ts.TraceInformation(string.Concat(new string[]
				{
					"This machine (",
					base.pcmoverEngine.ThisMachine.NetName,
					") has a designated old machine - ",
					CS$<>8__locals1.oldPolicyMachine.Target,
					"."
				}));
				if (string.IsNullOrEmpty(CS$<>8__locals1.oldPolicyMachine.Target))
				{
					throw new ApplicationException("Policy Error - This machines designated target is null");
				}
				ConnectableMachine connectableMachine = this.Machines.FirstOrDefault((ConnectableMachine x) => x.NetName == CS$<>8__locals1.oldPolicyMachine.Target);
				if (connectableMachine == null)
				{
					base.pcmoverEngine.Ts.TraceInformation("Designated old machine (" + CS$<>8__locals1.oldPolicyMachine.Target + ") not found.");
					return;
				}
				base.pcmoverEngine.Ts.TraceInformation("Designated old machine (" + connectableMachine.NetName + ") found.");
				connectableMachine.IsOld = true;
				this.SetTargetMachine(connectableMachine);
				this.resetScreen();
				if (this.CanOnNextCommand() && (!this.policy.findPCPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy))
				{
					this.OnNextCommand();
					return;
				}
			}
			else
			{
				FindPCPageViewModel.<>c__DisplayClass290_1 CS$<>8__locals3 = new FindPCPageViewModel.<>c__DisplayClass290_1();
				base.pcmoverEngine.Ts.TraceInformation("This machine (" + base.pcmoverEngine.ThisMachine.NetName + ") does not have a designated old machine.");
				FindPCPageViewModel.<>c__DisplayClass290_1 CS$<>8__locals4 = CS$<>8__locals3;
				string target = base.pcmoverEngine.Policy.Connection.Network.Target;
				CS$<>8__locals4.oldMachineName = ((target != null) ? target.ToUpper() : null);
				if (!string.IsNullOrEmpty(CS$<>8__locals3.oldMachineName))
				{
					base.pcmoverEngine.Ts.TraceInformation("Default old machine is set (" + CS$<>8__locals3.oldMachineName + ").");
					ConnectableMachine connectableMachine2 = this.Machines.FirstOrDefault((ConnectableMachine x) => x.NetName.ToUpper() == CS$<>8__locals3.oldMachineName);
					if (connectableMachine2 != null)
					{
						base.pcmoverEngine.Ts.TraceInformation("Default old machine found.");
						this.SetTargetMachine(connectableMachine2);
						this.resetScreen();
						if (this.CanOnNextCommand() && (!this.policy.findPCPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy))
						{
							this.OnNextCommand();
							return;
						}
					}
					else
					{
						base.pcmoverEngine.Ts.TraceInformation("Default old machine not found.");
					}
				}
			}
			if (this.CanOnNextCommand() && (!this.policy.findPCPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy))
			{
				ConnectableMachine currentSelectedMachine = this.CurrentSelectedMachine;
				if (currentSelectedMachine != null && currentSelectedMachine.Method == TransferMethodType.Usb)
				{
					this.OnNextCommand();
					return;
				}
			}
			bool? isMachineOld = base.pcmoverEngine.Policy.Connection.Network.IsMachineOld;
			bool flag = false;
			if ((isMachineOld.GetValueOrDefault() == flag & isMachineOld != null) && this.CanOnNextCommand() && (!this.policy.findPCPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy))
			{
				this.OnNextCommand();
				return;
			}
			using (IEnumerator<ConnectableMachine> enumerator = this.migrationDefinition.UIConnectableMachines.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ConnectableMachine uiMachine = enumerator.Current;
					if (uiMachine != null && !string.IsNullOrEmpty(uiMachine.FriendlyName))
					{
						if (this.matchSerialNumber(uiMachine))
						{
							if (!this.Machines.Any((ConnectableMachine x) => x.SameMachine(uiMachine)))
							{
								this.Machines.Add(uiMachine);
							}
						}
						else if (!this.OtherMachines.Any((ConnectableMachine x) => x.SameMachine(uiMachine)))
						{
							this.OtherMachines.Add(uiMachine);
						}
					}
				}
			}
			if (this.Machines.Count >= 1)
			{
				ConnectableMachine connectableMachine3 = null;
				FindPCTimerEventArgs args = e as FindPCTimerEventArgs;
				if (args != null)
				{
					connectableMachine3 = this.Machines.FirstOrDefault((ConnectableMachine m) => m.SameMachine(args.Machine));
					connectableMachine3.IsOld = args.Machine.IsOld;
				}
				else if (this.Machines.Any((ConnectableMachine x) => x.ConnectionName == "Thunderbolt"))
				{
					connectableMachine3 = this.Machines.FirstOrDefault((ConnectableMachine m) => m.ConnectionName == "Thunderbolt");
				}
				else if (this.Machines.Any((ConnectableMachine m) => m.Method == TransferMethodType.Usb) && !base.pcmoverEngine.Policy.Connection.EnabledMethods.HasFlag(ConnectionPolicyMethods.Network))
				{
					connectableMachine3 = this.Machines.FirstOrDefault((ConnectableMachine m) => m.Method == TransferMethodType.Usb);
					this.CurrentSelectedMachine = connectableMachine3;
				}
				if (connectableMachine3 != null)
				{
					if (this.isShowMultiple)
					{
						this.OnCloseShowMultiple(connectableMachine3);
					}
					else
					{
						this.SetTargetMachine(connectableMachine3);
					}
				}
				else
				{
					this.SetTargetMachine(this.Machines[0]);
				}
				if (this.isShowOthers)
				{
					this.isShowOthers = false;
					this.eventAggregator.GetEvent<Events.CloseOverlayPopup>().Publish();
				}
				if (!this.isShowMultiple && this.Machines.Count > 1 && connectableMachine3 == null)
				{
					this.CurrentSelectedMachine = this.Machines[0];
					this.ShowMultiple();
				}
			}
			else if (this.OtherMachines.Count >= 1 && !this.isShowMultiple && !this.isShowOthers)
			{
				this.ShowOthers();
			}
			if (this.policy.findPCPagePolicy.FindPcTimeout == 0)
			{
				this.NoComputersFoundPopupDelay = 2;
			}
			int noComputersFoundPopupDelay = this.NoComputersFoundPopupDelay;
			this.NoComputersFoundPopupDelay = noComputersFoundPopupDelay - 1;
			if (noComputersFoundPopupDelay <= 0)
			{
				bool isOld = false;
				if (!base.pcmoverEngine.CatchCommEx(delegate
				{
					isOld = CS$<>8__locals1.<>4__this.pcmoverEngine.ThisMachineIsOld;
				}, "FindTimer_Tick"))
				{
					return;
				}
				if (this.Machines.Count == 0 && !isOld)
				{
					if (this.policy.findPCPagePolicy.AllowDirectWifi)
					{
						if (!this.triedWifiDirect)
						{
							this.OnNoComputerFound();
							return;
						}
						this.ShowNoComputersFound();
						return;
					}
					else
					{
						this.ShowNoComputersFound();
					}
				}
			}
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00018394 File Offset: 0x00016594
		private void ShowMultiple()
		{
			if (!this.isShowMultipleAllowed)
			{
				return;
			}
			Events.OverlayPopupArgs payload = new Events.OverlayPopupArgs
			{
				Title = WizardModule.Properties.Resources.FPP_MultipleFound,
				Parameter = this.Machines,
				ContentRegion = "MultipleComputersFound",
				PopupResultCallback = new Action<object>(this.OnCloseShowMultiple)
			};
			this.eventAggregator.GetEvent<Events.ShowOverlayPopup>().Publish(payload);
			this.isShowMultiple = true;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x000183FC File Offset: 0x000165FC
		private void OnCloseShowMultiple(object obj)
		{
			this.isShowMultiple = false;
			this.Stop();
			if (obj == null)
			{
				this.IsBusy = false;
				this.ShowSidePanel = false;
				this.resetScreen();
				this.IsScanAgainButtonEnabled = true;
				this.IsAnalyzeButtonEnabled = false;
				return;
			}
			this.CurrentSelectedMachine = (ConnectableMachine)obj;
			this.SetTargetMachine(this.CurrentSelectedMachine);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00018454 File Offset: 0x00016654
		private void ShowOthers()
		{
			Events.OverlayPopupArgs payload = new Events.OverlayPopupArgs
			{
				Title = WizardModule.Properties.Resources.FPP_OthersFound,
				Parameter = this.OtherMachines,
				ContentRegion = "OtherComputersFound",
				PopupResultCallback = new Action<object>(this.OnCloseShowOthers)
			};
			this.eventAggregator.GetEvent<Events.ShowOverlayPopup>().Publish(payload);
			this.isShowOthers = true;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x000184B3 File Offset: 0x000166B3
		private void OnCloseShowOthers(object obj)
		{
			this.IsBusy = false;
			this.ShowSidePanel = false;
			this.resetScreen();
			this.IsScanAgainButtonEnabled = true;
			this.IsAnalyzeButtonEnabled = false;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x000184D8 File Offset: 0x000166D8
		private void ShowNoComputersFound()
		{
			if (this.isShowOthers || this.isShowMultiple)
			{
				return;
			}
			this.IsBusy = false;
			this.ShowSidePanel = false;
			this.IsScanAgainButtonEnabled = true;
			Events.OverlayPopupArgs payload = new Events.OverlayPopupArgs
			{
				Title = WizardModule.Properties.Resources.FPP_Oops,
				ContentRegion = "NoComputersFound",
				PopupResultCallback = new Action<object>(this.OnCloseShowNoComputersFound)
			};
			this.eventAggregator.GetEvent<Events.ShowOverlayPopup>().Publish(payload);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0001854A File Offset: 0x0001674A
		private void OnCloseShowNoComputersFound(object obj)
		{
			this.isShowNoComputersFound = false;
			this.resetScreen();
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00018559 File Offset: 0x00016759
		private void ShowNotConnecting()
		{
			this.ShowNoComputersFound();
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00018561 File Offset: 0x00016761
		private void OnCloseShowNotConnecting(object obj)
		{
			this.isShowNotConnecting = false;
			this.resetScreen();
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00018570 File Offset: 0x00016770
		private void SetTargetMachine(ConnectableMachine machine)
		{
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				this.pcmoverEngine.TargetMachine = machine;
				this.ReverseDisabled = (machine.XPVersion || this.sourceSpecified);
				this.IsThisTheOldPC = !machine.IsOld;
				if (this.container.Resolve(Array.Empty<ResolverOverride>()).IsNew || this.sourceSpecified)
				{
					this.IsThisTheOldPC = false;
				}
				this.OldPC = (this.IsThisTheOldPC ? this.pcmoverEngine.ThisMachine.FriendlyName : machine.FriendlyName);
				this.NewPC = (this.IsThisTheOldPC ? machine.FriendlyName : this.pcmoverEngine.ThisMachine.FriendlyName);
				this.OtherPC = machine.FriendlyName;
			}, "SetTargetMachine"))
			{
				return;
			}
			this.migrationDefinition.IsPCName1Old = true;
			this.migrationDefinition.PCName1 = this.OldPC;
			this.migrationDefinition.PCName2 = this.NewPC;
			this.IsScanAgainButtonEnabled = true;
			if (this.Machines.Count <= 0)
			{
				this.IsBusy = false;
				this.ShowSidePanel = false;
				this.IsScanAgainButtonEnabled = true;
				this.ShowNotConnecting();
				return;
			}
			this.NetworkName = machine.NetName;
			if (string.IsNullOrEmpty(machine.CertificateName))
			{
				this.UseSSL = false;
			}
			else if (this.SSLCommittedMachines.ContainsKey(this.NetworkName))
			{
				this.UseSSL = this.SSLCommittedMachines[this.NetworkName];
			}
			this.IsBusy = false;
			this.ShowSidePanel = true;
			this.IsFound = true;
			if (this.isShowNoComputersFound || this.isShowNotConnecting || this.isShowAttemptingWiFi)
			{
				this.eventAggregator.GetEvent<Events.CloseOverlayPopup>().Publish();
			}
			this.DisplayConnection = false;
			this.ShowSSL = false;
			if (machine.ConnectionName == "Thunderbolt")
			{
				this.migrationDefinition.IsThunderbolt = true;
				this.ArrowUri = "/WizardModule;component/Assets/RightArrowLargeTB.png";
				this.ConnectionIcon = "/WizardModule;component/Assets/tb-logo48.png";
				this.ConnectionMethod = WizardModule.Properties.Resources.FPP_Thunderbolt;
				this.DisplayConnection = true;
				return;
			}
			this.ArrowUri = "/WizardModule;component/Assets/RightArrowLarge.png";
			TransferMethodType method = machine.Method;
			if (method <= TransferMethodType.Image)
			{
				if (method == TransferMethodType.File)
				{
					this.ConnectionIcon = "/WizardModule;component/Assets/file.png";
					this.ConnectionMethod = WizardModule.Properties.Resources.FPP_File;
					return;
				}
				if (method != TransferMethodType.Image)
				{
					return;
				}
				this.ConnectionIcon = "/WizardModule;component/Assets/disk.png";
				this.ConnectionMethod = WizardModule.Properties.Resources.FPP_Image;
				return;
			}
			else if (method != TransferMethodType.Network)
			{
				if (method != TransferMethodType.Usb)
				{
					return;
				}
				this.ConnectionIcon = "/WizardModule;component/Assets/usb.png";
				this.ConnectionMethod = WizardModule.Properties.Resources.FPP_USB;
				return;
			}
			else
			{
				this.DisplayConnection = true;
				this.ShowSSL = true;
				if (string.IsNullOrEmpty(Tools.GetWiFiName(base.pcmoverEngine)))
				{
					this.ConnectionIcon = "/WizardModule;component/Assets/lan.png";
					this.ConnectionMethod = WizardModule.Properties.Resources.FPP_LAN;
					return;
				}
				this.ConnectionIcon = "/WizardModule;component/Assets/WiFiSmall.png";
				this.ConnectionMethod = WizardModule.Properties.Resources.FPP_Wireless;
				return;
			}
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x000187C4 File Offset: 0x000169C4
		private Task CheckOSReversal()
		{
			FindPCPageViewModel.<CheckOSReversal>d__300 <CheckOSReversal>d__;
			<CheckOSReversal>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CheckOSReversal>d__.<>4__this = this;
			<CheckOSReversal>d__.<>1__state = -1;
			<CheckOSReversal>d__.<>t__builder.Start<FindPCPageViewModel.<CheckOSReversal>d__300>(ref <CheckOSReversal>d__);
			return <CheckOSReversal>d__.<>t__builder.Task;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00018808 File Offset: 0x00016A08
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			FindPCPageViewModel.<OnNavigatedTo>d__301 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.navigationContext = navigationContext;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<FindPCPageViewModel.<OnNavigatedTo>d__301>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00018848 File Offset: 0x00016A48
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Unsubscribe(new Action<ConnectableMachine>(this.OnMachineStatus));
			this.eventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Unsubscribe(new Action<ConnectableMachine>(this.OnSetDirection));
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
			this.Stop();
			this.IsBusy = false;
			this.remoteMachineName = null;
			this.versionError = false;
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0000CE65 File Offset: 0x0000B065
		private void Shutdown()
		{
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x000188C4 File Offset: 0x00016AC4
		private void Resume()
		{
			if (this.migrationDefinition.ServiceData.Role == PcmoverTransferState.TransferRole.Destination)
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("AnalyzePCPage", UriKind.Relative));
				return;
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000188F8 File Offset: 0x00016AF8
		private bool IsValidMachinePair()
		{
			if (PcmBrandUI.Properties.Resources.Edition == "Express" && PcmBrandUI.Properties.Resources.OEM == "Intel")
			{
				try
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
							goto IL_197;
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
				catch
				{
				}
			}
			IL_197:
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
			}
			return true;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00018B48 File Offset: 0x00016D48
		private bool VerifyCertName()
		{
			if (base.pcmoverEngine.TargetMachine.ConnectionName == "Thunderbolt")
			{
				return true;
			}
			SSLFlags sslFlags = base.pcmoverEngine.Policy.Connection.Network.SslFlags;
			if (base.pcmoverEngine.TargetMachine.Method == TransferMethodType.Usb && !sslFlags.HasFlag(SSLFlags.SecureCableConnections))
			{
				return true;
			}
			SSLFlags sslflags = SSLFlags.DisallowLaplinkCA | SSLFlags.DisallowSelfSigned | SSLFlags.EnforceCertificateName | SSLFlags.RequireCustomerCA | SSLFlags.RequireClientCertificate | SSLFlags.NetBIOSCertificateName;
			if ((sslFlags & sslflags) != (SSLFlags)0 && string.IsNullOrEmpty(base.pcmoverEngine.TargetMachine.CertificateName))
			{
				string message = string.Format(WizardModule.Properties.Resources.FPP_SSLCantConnectError, base.pcmoverEngine.TargetMachine.FriendlyName, this.policy.SupportEmail);
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, message, WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.Exclamation, MessageBoxResult.None).ConfigureAwait(false);
				return false;
			}
			return true;
		}

		// Token: 0x040002C7 RID: 711
		private readonly IRegionManager regionManager;

		// Token: 0x040002C8 RID: 712
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040002C9 RID: 713
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040002CA RID: 714
		private readonly DispatcherTimer findTimer = new DispatcherTimer();

		// Token: 0x040002CB RID: 715
		private int NoComputersFoundPopupDelay;

		// Token: 0x040002CC RID: 716
		private bool isShowMultiple;

		// Token: 0x040002CD RID: 717
		private bool isShowMultipleAllowed;

		// Token: 0x040002CE RID: 718
		private bool isShowOthers;

		// Token: 0x040002CF RID: 719
		private bool isShowNoComputersFound;

		// Token: 0x040002D0 RID: 720
		private bool isShowNotConnecting;

		// Token: 0x040002D1 RID: 721
		private bool isShowAttemptingWiFi;

		// Token: 0x040002D2 RID: 722
		private bool triedWifiDirect;

		// Token: 0x040002D3 RID: 723
		private bool sourceSpecified;

		// Token: 0x040002D4 RID: 724
		private Dictionary<string, bool> SSLCommittedMachines = new Dictionary<string, bool>();

		// Token: 0x040002D5 RID: 725
		private DefaultPolicy policy;

		// Token: 0x040002D6 RID: 726
		private IEditionData _editionData;

		// Token: 0x040002D7 RID: 727
		private string remoteMachineName;

		// Token: 0x040002D8 RID: 728
		private bool versionError;

		// Token: 0x040002D9 RID: 729
		private bool discoveryStopped;

		// Token: 0x040002DA RID: 730
		private ObservableCollection<ConnectableMachine> _Machines;

		// Token: 0x040002DB RID: 731
		private ObservableCollection<ConnectableMachine> _OtherMachines;

		// Token: 0x040002DC RID: 732
		private string _OldPC;

		// Token: 0x040002DD RID: 733
		private string _NewPC;

		// Token: 0x040002DE RID: 734
		private string _OtherPC;

		// Token: 0x040002DF RID: 735
		private string _NetworkName;

		// Token: 0x040002E0 RID: 736
		private bool _IsBusy;

		// Token: 0x040002E1 RID: 737
		private bool _ShowSidePanel;

		// Token: 0x040002E2 RID: 738
		private bool _IsFound;

		// Token: 0x040002E3 RID: 739
		private bool _ReverseDisabled;

		// Token: 0x040002E4 RID: 740
		private bool _reverseInProgress;

		// Token: 0x040002E5 RID: 741
		private bool _IsAnalyzeButtonEnabled;

		// Token: 0x040002E6 RID: 742
		private bool _IsScanAgainButtonEnabled;

		// Token: 0x040002E7 RID: 743
		private string _ArrowUri;

		// Token: 0x040002E8 RID: 744
		private int _NumItems;

		// Token: 0x040002E9 RID: 745
		private bool _IsThisTheOldPC;

		// Token: 0x040002EA RID: 746
		private bool _IsLicenseMismatch;

		// Token: 0x040002EB RID: 747
		private ConnectableMachine _CurrentSelectedMachine;

		// Token: 0x040002EC RID: 748
		private string _ConnectionMethod;

		// Token: 0x040002ED RID: 749
		private string _ConnectionIcon;

		// Token: 0x040002EE RID: 750
		private bool _DisplayConnection;

		// Token: 0x040002EF RID: 751
		private bool _DisplayInfo;

		// Token: 0x040002F0 RID: 752
		private bool _DisplayHowLong;

		// Token: 0x040002F1 RID: 753
		private string _SerialNumber;

		// Token: 0x040002F2 RID: 754
		private bool _IsSerialNumberVisible;

		// Token: 0x040002F3 RID: 755
		private bool _UseSSL;

		// Token: 0x040002F4 RID: 756
		private bool _ShowSSL;

		// Token: 0x040002F5 RID: 757
		private bool _IsVersionMismatchPopupOpen;

		// Token: 0x040002F6 RID: 758
		private string _VersionMismatchError;

		// Token: 0x040002F7 RID: 759
		private bool _IsChangeConnectionMethodVisible;

		// Token: 0x040002F8 RID: 760
		private bool _IsRequestHostPopupOpen;

		// Token: 0x040002F9 RID: 761
		private bool _IsRequestHostVisible;

		// Token: 0x040002FA RID: 762
		private string _RequestedHost;

		// Token: 0x040002FB RID: 763
		private string _CertName;

		// Token: 0x040002FC RID: 764
		private bool _CertNameRequired;

		// Token: 0x040002FD RID: 765
		private string _RequestHostStatus;

		// Token: 0x040002FE RID: 766
		private bool _RequestHostSpinnerActive;

		// Token: 0x040002FF RID: 767
		private bool _IsVproVisible;
	}
}
