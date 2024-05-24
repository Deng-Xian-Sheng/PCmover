using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200007A RID: 122
	public class ConnectionPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x0600069D RID: 1693 RVA: 0x0000EC88 File Offset: 0x0000CE88
		public ConnectionPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, LlTraceSource ts) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._ts = ts;
			this._wizardModuleModule = wizardModuleModule;
			this.OnRequestHost = new DelegateCommand(new Action(this.OnRequestHostCommand), new Func<bool>(this.CanOnRequestHostCommand));
			this.OnCancelRequestHost = new DelegateCommand(new Action(this.OnCancelRequestHostCommand), new Func<bool>(this.CanOnCancelRequestHostCommand));
			eventAggregator.GetEvent<Events.EngineInitializedEvent>().Subscribe(new Action<PcmoverServiceData>(this.OnEngineInitialized), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Subscribe(new Action<ConnectableMachine>(this.OnMachineStatus), ThreadOption.UIThread);
			eventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Subscribe(new Action<ConnectableMachine>(this.OnSetDirection), ThreadOption.UIThread);
			this.ConnectionStatus = Resources.CP_Status_Initial;
			this.RequestHostSpinnerActive = true;
			this._listenActivityRunning = false;
			this._newMachine = null;
			this._cts = new CancellationTokenSource();
			this.ShowCertWarning = false;
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0000EDB2 File Offset: 0x0000CFB2
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x0000EDBA File Offset: 0x0000CFBA
		public string ConnectionStatus
		{
			get
			{
				return this._ConnectionStatus;
			}
			set
			{
				this.SetProperty<string>(ref this._ConnectionStatus, value, "ConnectionStatus");
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0000EDCF File Offset: 0x0000CFCF
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0000EDD7 File Offset: 0x0000CFD7
		public bool ShowRequestHost
		{
			get
			{
				return this._ShowRequestHost;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowRequestHost, value, "ShowRequestHost");
				this.SetDefaultCertName();
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0000EDF2 File Offset: 0x0000CFF2
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x0000EDFA File Offset: 0x0000CFFA
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

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x0000EE0F File Offset: 0x0000D00F
		// (set) Token: 0x060006A5 RID: 1701 RVA: 0x0000EE17 File Offset: 0x0000D017
		public bool IsRequestedHostOld
		{
			get
			{
				return this._IsRequestedHostOld;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsRequestedHostOld, value, "IsRequestedHostOld");
				this.SetDefaultCertName();
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x0000EE32 File Offset: 0x0000D032
		// (set) Token: 0x060006A7 RID: 1703 RVA: 0x0000EE3A File Offset: 0x0000D03A
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

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x0000EE4F File Offset: 0x0000D04F
		// (set) Token: 0x060006A9 RID: 1705 RVA: 0x0000EE57 File Offset: 0x0000D057
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

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x060006AA RID: 1706 RVA: 0x0000EE6C File Offset: 0x0000D06C
		// (set) Token: 0x060006AB RID: 1707 RVA: 0x0000EE74 File Offset: 0x0000D074
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

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x060006AC RID: 1708 RVA: 0x0000EE94 File Offset: 0x0000D094
		// (set) Token: 0x060006AD RID: 1709 RVA: 0x0000EE9C File Offset: 0x0000D09C
		public string OldPC
		{
			get
			{
				return this._OldPC;
			}
			set
			{
				this.SetProperty<string>(ref this._OldPC, value, "OldPC");
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x060006AE RID: 1710 RVA: 0x0000EEB1 File Offset: 0x0000D0B1
		// (set) Token: 0x060006AF RID: 1711 RVA: 0x0000EEB9 File Offset: 0x0000D0B9
		public string NewPC
		{
			get
			{
				return this._NewPC;
			}
			set
			{
				this.SetProperty<string>(ref this._NewPC, value, "NewPC");
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0000EECE File Offset: 0x0000D0CE
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0000EED6 File Offset: 0x0000D0D6
		public bool ShowCertWarning
		{
			get
			{
				return this._ShowCertWarning;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowCertWarning, value, "ShowCertWarning");
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0000EEEB File Offset: 0x0000D0EB
		// (set) Token: 0x060006B3 RID: 1715 RVA: 0x0000EEF3 File Offset: 0x0000D0F3
		public string CertErrorText
		{
			get
			{
				return this._CertErrorText;
			}
			set
			{
				this.SetProperty<string>(ref this._CertErrorText, value, "CertErrorText");
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x0000EF08 File Offset: 0x0000D108
		// (set) Token: 0x060006B5 RID: 1717 RVA: 0x0000EF10 File Offset: 0x0000D110
		public DelegateCommand OnRequestHost { get; private set; }

		// Token: 0x060006B6 RID: 1718 RVA: 0x0000EF19 File Offset: 0x0000D119
		private bool CanOnRequestHostCommand()
		{
			return !this.RequestHostSpinnerActive;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0000EF24 File Offset: 0x0000D124
		private void OnRequestHostCommand()
		{
			ConnectionPageViewModel.<OnRequestHostCommand>d__66 <OnRequestHostCommand>d__;
			<OnRequestHostCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnRequestHostCommand>d__.<>4__this = this;
			<OnRequestHostCommand>d__.<>1__state = -1;
			<OnRequestHostCommand>d__.<>t__builder.Start<ConnectionPageViewModel.<OnRequestHostCommand>d__66>(ref <OnRequestHostCommand>d__);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0000EF5C File Offset: 0x0000D15C
		private void SetTargetMachine(ConnectableMachine foundMachine, string name)
		{
			base.pcmoverEngine.SetControllerProperty(this.activeCertificate, foundMachine.CertificateName ?? "");
			base.pcmoverEngine.SetControllerProperty(this.activeConnectionName, foundMachine.NetName ?? "");
			base.pcmoverEngine.SetControllerProperty(this.activeConnection, string.Format("{0}", foundMachine.TransferMethodHandle));
			base.pcmoverEngine.TargetMachine = foundMachine;
			this.migrationDefinition.IsPCName1Old = true;
			this.migrationDefinition.PCName1 = name;
			this.migrationDefinition.PCName2 = base.pcmoverEngine.ThisMachine.NetName;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0000F010 File Offset: 0x0000D210
		private Task<bool> ReverseConnect()
		{
			ConnectionPageViewModel.<ReverseConnect>d__68 <ReverseConnect>d__;
			<ReverseConnect>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ReverseConnect>d__.<>4__this = this;
			<ReverseConnect>d__.<>1__state = -1;
			<ReverseConnect>d__.<>t__builder.Start<ConnectionPageViewModel.<ReverseConnect>d__68>(ref <ReverseConnect>d__);
			return <ReverseConnect>d__.<>t__builder.Task;
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x0000F053 File Offset: 0x0000D253
		// (set) Token: 0x060006BB RID: 1723 RVA: 0x0000F05B File Offset: 0x0000D25B
		public DelegateCommand OnCancelRequestHost { get; private set; }

		// Token: 0x060006BC RID: 1724 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelRequestHostCommand()
		{
			return true;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0000F064 File Offset: 0x0000D264
		private void OnCancelRequestHostCommand()
		{
			ConnectionPageViewModel.<OnCancelRequestHostCommand>d__74 <OnCancelRequestHostCommand>d__;
			<OnCancelRequestHostCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCancelRequestHostCommand>d__.<>4__this = this;
			<OnCancelRequestHostCommand>d__.<>1__state = -1;
			<OnCancelRequestHostCommand>d__.<>t__builder.Start<ConnectionPageViewModel.<OnCancelRequestHostCommand>d__74>(ref <OnCancelRequestHostCommand>d__);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0000F09C File Offset: 0x0000D29C
		private void OnMachineStatus(ConnectableMachine machine)
		{
			this._ts.TraceInformation(string.Format("OnMachineStatus: {0} for {1}", machine.Status, machine.NetName));
			if (machine.SerialNumber != this._connectionId)
			{
				this._ts.TraceInformation("OnMachineStatus: Invalid connection Id, expected " + this._connectionId + ", got " + machine.SerialNumber);
				return;
			}
			switch (machine.Status)
			{
			case DiscoveredMachineStatus.AddressSpecified:
			case DiscoveredMachineStatus.Connecting:
			case DiscoveredMachineStatus.GetUserData:
			case DiscoveredMachineStatus.DataReceived:
				this.ConnectionStatus = Resources.FPP_Status_Connecting;
				return;
			case DiscoveredMachineStatus.SettingDirection:
				this.ConnectionStatus = Resources.FPP_Status_SettingDirection;
				return;
			case DiscoveredMachineStatus.DirectionSet:
				break;
			case DiscoveredMachineStatus.ManualConnection:
			{
				TaskCompletionSource<ConnectableMachine> newTcs = this._newTcs;
				if (newTcs == null)
				{
					return;
				}
				newTcs.TrySetResult(machine);
				return;
			}
			case DiscoveredMachineStatus.RemoteManualConnection:
			{
				TaskCompletionSource<ConnectableMachine> oldTcs = this._oldTcs;
				if (oldTcs == null)
				{
					return;
				}
				oldTcs.TrySetResult(machine);
				return;
			}
			case DiscoveredMachineStatus.ConnectFailed:
			case DiscoveredMachineStatus.CommunicationError:
			case DiscoveredMachineStatus.Exception:
			case DiscoveredMachineStatus.MachineNotFound:
			{
				this.ConnectionStatus = string.Format(Resources.Error_HostNotFound, machine.NetName);
				TaskCompletionSource<ConnectableMachine> newTcs2 = this._newTcs;
				if (newTcs2 == null)
				{
					return;
				}
				newTcs2.TrySetResult(machine);
				return;
			}
			case DiscoveredMachineStatus.FindingRemoteComputer:
				this.ConnectionStatus = Resources.FPP_Status_FindingRemoteComputer;
				break;
			default:
				return;
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0000F1C0 File Offset: 0x0000D3C0
		private void OnSetDirection(ConnectableMachine machine)
		{
			if (machine.SerialNumber != this._connectionId)
			{
				this._ts.TraceInformation("OnSetDirection: Invalid connection Id, expected " + this._connectionId + ", got " + machine.SerialNumber);
				return;
			}
			if (machine.IsOld)
			{
				TaskCompletionSource<ConnectableMachine> reverseTcs = this._reverseTcs;
				machine.Status = DiscoveredMachineStatus.DirectionSet;
				if (reverseTcs != null && reverseTcs.TrySetResult(machine))
				{
					return;
				}
			}
			if (machine.TransferMethodHandle != 0)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.pcmoverEngine.DeleteTransferMethod(machine.TransferMethodHandle);
				}, "OnSetDirection");
				machine.TransferMethodHandle = 0;
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0000F290 File Offset: 0x0000D490
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			ConnectionPageViewModel.<OnActivityInfo>d__77 <OnActivityInfo>d__;
			<OnActivityInfo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnActivityInfo>d__.<>4__this = this;
			<OnActivityInfo>d__.activityInfo = activityInfo;
			<OnActivityInfo>d__.<>1__state = -1;
			<OnActivityInfo>d__.<>t__builder.Start<ConnectionPageViewModel.<OnActivityInfo>d__77>(ref <OnActivityInfo>d__);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0000F2D0 File Offset: 0x0000D4D0
		private void OnEngineInitialized(PcmoverServiceData serviceData)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (serviceData == null)
				{
					return;
				}
				SSLFlags sslFlags = this.pcmoverEngine.Policy.Connection.Network.SslFlags;
				this.CertNameRequired = (sslFlags.HasFlag(SSLFlags.EnforceCertificateName) || sslFlags.HasFlag(SSLFlags.DisallowLaplinkCA) || sslFlags.HasFlag(SSLFlags.RequireCustomerCA));
				if (!this.pcmoverEngine.IsRemoteUI)
				{
					return;
				}
				this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
				this.migrationDefinition.ServiceData = serviceData;
				IWizardParameters wizardParameters = this.container.Resolve(Array.Empty<ResolverOverride>());
				this._connectionId = wizardParameters.ConnectionId;
				if (serviceData.IsIdle)
				{
					this.pcmoverEngine.ThisMachineAppInventoryRequirement = AppInventoryAmount.NewComputer;
				}
				else
				{
					try
					{
						string text = wizardParameters.SourceAddress ?? wizardParameters.Source;
						ConnectableMachine connectableMachine = null;
						IEnumerable<ConnectableMachine> connectableMachines = this.pcmoverEngine.GetConnectableMachines();
						if (connectableMachines != null)
						{
							foreach (ConnectableMachine connectableMachine2 in connectableMachines)
							{
								if (connectableMachine2.NetName == wizardParameters.Source)
								{
									if (connectableMachine2.Status == DiscoveredMachineStatus.ManualConnection)
									{
										connectableMachine = connectableMachine2;
										connectableMachine.NetName = text;
										break;
									}
									if (connectableMachine2.Status == DiscoveredMachineStatus.RemoteManualConnection)
									{
										connectableMachine = connectableMachine2;
									}
								}
							}
						}
						if (connectableMachine == null)
						{
							string controllerProperty = this.pcmoverEngine.GetControllerProperty(this.activeConnection);
							if (controllerProperty != null)
							{
								int transferMethodHandle = Convert.ToInt32(controllerProperty);
								connectableMachine = new ConnectableMachine
								{
									NetName = (this.pcmoverEngine.GetControllerProperty(this.activeConnectionName) ?? text),
									FriendlyName = wizardParameters.Source,
									CertificateName = (this.pcmoverEngine.GetControllerProperty(this.activeCertificate) ?? wizardParameters.SourceCertificate),
									Method = TransferMethodType.Network,
									TransferMethodHandle = transferMethodHandle
								};
							}
						}
						if (connectableMachine != null)
						{
							this.migrationDefinition.IsResuming = true;
							this.SetTargetMachine(connectableMachine, connectableMachine.NetName);
							this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("AnalyzePCPage", UriKind.Relative));
							return;
						}
					}
					catch (Exception ex)
					{
						this._ts.TraceException(ex, "OnEngineInitialized");
						return;
					}
				}
				if (string.IsNullOrEmpty(wizardParameters.SourceCertificate) || string.IsNullOrEmpty(this.pcmoverEngine.DefaultCertificateName))
				{
					this.ShowCertWarning = true;
					string arg = string.IsNullOrEmpty(wizardParameters.SourceCertificate) ? this.pcmoverEngine.OtherMachine.FriendlyName : this.pcmoverEngine.ThisMachine.FriendlyName;
					this.CertErrorText = string.Format(Resources.CP_CertError, arg);
				}
				this.RequestHostSpinnerActive = true;
				this.ConnectionStatus = Resources.FPP_Status_Connecting;
				this.OldPC = string.Format(Resources.CP_OldPC, wizardParameters.Source);
				this.NewPC = string.Format(Resources.CP_NewPC, this.pcmoverEngine.ThisMachine.FriendlyName);
				this._UseSSL = this.pcmoverEngine.UseSSL;
				this._newMachine = new ConnectableMachine
				{
					NetName = (wizardParameters.DestAddress ?? this.pcmoverEngine.ThisMachine.NetName),
					FriendlyName = this.pcmoverEngine.ThisMachine.FriendlyName,
					CertificateName = this.pcmoverEngine.DefaultCertificateName,
					Method = TransferMethodType.Network,
					IsOld = false,
					SerialNumber = this._connectionId
				};
				this.pcmoverEngine.StartListenActivity(this._connectionId, "");
			}, "OnEngineInitialized");
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0000F310 File Offset: 0x0000D510
		private Task<bool> Connect(string SourceName, string Certificate, string sourceAddress = null)
		{
			ConnectionPageViewModel.<Connect>d__79 <Connect>d__;
			<Connect>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<Connect>d__.<>4__this = this;
			<Connect>d__.SourceName = SourceName;
			<Connect>d__.Certificate = Certificate;
			<Connect>d__.sourceAddress = sourceAddress;
			<Connect>d__.<>1__state = -1;
			<Connect>d__.<>t__builder.Start<ConnectionPageViewModel.<Connect>d__79>(ref <Connect>d__);
			return <Connect>d__.<>t__builder.Task;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0000F36C File Offset: 0x0000D56C
		private void SetDefaultCertName()
		{
			if (this._ShowRequestHost && this.CertNameRequired)
			{
				string sourceCertificate = this.container.Resolve(Array.Empty<ResolverOverride>()).SourceCertificate;
				string newCertName = string.Empty;
				base.pcmoverEngine.CatchCommEx(delegate
				{
					newCertName = this.pcmoverEngine.DefaultCertificateName;
				}, "SetDefaultCertName");
				if (this.IsRequestedHostOld && !string.IsNullOrEmpty(this.OldPC) && (string.IsNullOrWhiteSpace(this.CertName) || this.CertName == newCertName))
				{
					this.CertName = sourceCertificate;
					return;
				}
				if (!this.IsRequestedHostOld && !string.IsNullOrEmpty(this.NewPC) && (string.IsNullOrWhiteSpace(this.CertName) || this.CertName == sourceCertificate))
				{
					this.CertName = newCertName;
				}
			}
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0000F454 File Offset: 0x0000D654
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Unsubscribe(new Action<ConnectableMachine>(this.OnMachineStatus));
			this.eventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Unsubscribe(new Action<ConnectableMachine>(this.OnSetDirection));
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
		}

		// Token: 0x0400018E RID: 398
		private readonly IRegionManager regionManager;

		// Token: 0x0400018F RID: 399
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000190 RID: 400
		private readonly DefaultPolicy policy;

		// Token: 0x04000191 RID: 401
		private readonly LlTraceSource _ts;

		// Token: 0x04000192 RID: 402
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x04000193 RID: 403
		private TaskCompletionSource<ConnectableMachine> _newTcs;

		// Token: 0x04000194 RID: 404
		private TaskCompletionSource<ConnectableMachine> _oldTcs;

		// Token: 0x04000195 RID: 405
		private TaskCompletionSource<ConnectableMachine> _reverseTcs;

		// Token: 0x04000196 RID: 406
		private bool _listenActivityRunning;

		// Token: 0x04000197 RID: 407
		private string _connectionId;

		// Token: 0x04000198 RID: 408
		private ConnectableMachine _newMachine;

		// Token: 0x04000199 RID: 409
		private bool _UseSSL = true;

		// Token: 0x0400019A RID: 410
		private string activeConnection = "ActiveConnection";

		// Token: 0x0400019B RID: 411
		private string activeConnectionName = "ActiveConnectionName";

		// Token: 0x0400019C RID: 412
		private string activeCertificate = "ActiveCertificate";

		// Token: 0x0400019D RID: 413
		private CancellationTokenSource _cts;

		// Token: 0x0400019E RID: 414
		private string _ConnectionStatus;

		// Token: 0x0400019F RID: 415
		private bool _ShowRequestHost;

		// Token: 0x040001A0 RID: 416
		private string _RequestedHost;

		// Token: 0x040001A1 RID: 417
		private bool _IsRequestedHostOld;

		// Token: 0x040001A2 RID: 418
		private string _CertName;

		// Token: 0x040001A3 RID: 419
		private bool _CertNameRequired;

		// Token: 0x040001A4 RID: 420
		private bool _RequestHostSpinnerActive;

		// Token: 0x040001A5 RID: 421
		private string _OldPC;

		// Token: 0x040001A6 RID: 422
		private string _NewPC;

		// Token: 0x040001A7 RID: 423
		private bool _ShowCertWarning;

		// Token: 0x040001A8 RID: 424
		private string _CertErrorText;
	}
}
