using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ClientEngineModule.Infrastructure.Properties;
using Laplink.Download.Contracts;
using Laplink.Download.Proxies;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Pcmover.Proxies;
using Laplink.PcmoverService.Infrastructure;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Events;

namespace ClientEngineModule.Wcf
{
	// Token: 0x0200000A RID: 10
	public class PCmoverEngineLive : PcmoverClientEngineWcf, IPCmoverEngine
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002C62 File Offset: 0x00000E62
		internal IUnityContainer Container { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002C6A File Offset: 0x00000E6A
		private ThisMachineAppInvActivityClient ThisMachineAppInvActivityClient
		{
			get
			{
				return base.ActivityClients.FindByType<ThisMachineAppInvActivityClient>();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002C77 File Offset: 0x00000E77
		private ActivityClient DiscoveryActivityClient
		{
			get
			{
				return base.ActivityClients.FindByActivityType(ActivityType.Discovery);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002C88 File Offset: 0x00000E88
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002CDF File Offset: 0x00000EDF
		private int FileTransferMethodHandle
		{
			get
			{
				if (this._ftmh == 0 && base.IsResuming)
				{
					TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.File);
					if (transferMethodData == null)
					{
						base.Ts.TraceCaller("Cannot find file transfer method", "FileTransferMethodHandle");
					}
					else
					{
						this._ftmh = transferMethodData.Handle;
					}
				}
				return this._ftmh;
			}
			set
			{
				this._ftmh = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002CE8 File Offset: 0x00000EE8
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002D3F File Offset: 0x00000F3F
		private int ImageTransferMethodHandle
		{
			get
			{
				if (this._itmh == 0 && base.IsResuming)
				{
					TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.Image);
					if (transferMethodData == null)
					{
						base.Ts.TraceCaller("Cannot find image transfer method", "ImageTransferMethodHandle");
					}
					else
					{
						this._itmh = transferMethodData.Handle;
					}
				}
				return this._itmh;
			}
			set
			{
				this._itmh = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002D48 File Offset: 0x00000F48
		public IEventAggregator EventAggregator { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002D50 File Offset: 0x00000F50
		public bool IsConnected
		{
			get
			{
				return this.HasControlInterface;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002D58 File Offset: 0x00000F58
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002D60 File Offset: 0x00000F60
		public DateTime UndoTime { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002D69 File Offset: 0x00000F69
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002D71 File Offset: 0x00000F71
		public string WindowsOldFolder { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002D7A File Offset: 0x00000F7A
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002D82 File Offset: 0x00000F82
		public SecurityProductsData SecurityProducts { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002D8B File Offset: 0x00000F8B
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002D93 File Offset: 0x00000F93
		public IEnumerable<DriveSpaceData> ThisMachineDriveSpace { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002D9C File Offset: 0x00000F9C
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002DA4 File Offset: 0x00000FA4
		public MachineData OtherMachine { get; internal set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002DAD File Offset: 0x00000FAD
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002DB5 File Offset: 0x00000FB5
		public ConnectableMachine TargetMachine { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002DBE File Offset: 0x00000FBE
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002DC6 File Offset: 0x00000FC6
		public bool UseSSL { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002DCF File Offset: 0x00000FCF
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002DD7 File Offset: 0x00000FD7
		public string CertificateName { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002DE0 File Offset: 0x00000FE0
		public IEnumerable<NetworkInfo> NetworkInfos
		{
			get
			{
				if (this._networkInfos == null && this.HasControlInterface)
				{
					this._networkInfos = this.ControlInterface.GetNetworkInfos();
				}
				return this._networkInfos;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002E09 File Offset: 0x00001009
		public RebootPendingReasons RebootPending
		{
			get
			{
				if (this.HasControlInterface)
				{
					return this.ControlInterface.CheckRebootPending();
				}
				return RebootPendingReasons.None;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002E20 File Offset: 0x00001020
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002E28 File Offset: 0x00001028
		public bool ThisMachineIsOld
		{
			get
			{
				return this._thisMachineIsOld;
			}
			set
			{
				if (this._thisMachineIsOld == value)
				{
					base.Ts.TraceInformation(string.Format("Keeping ThisMachineIsOld as {0}", value));
					return;
				}
				base.Ts.TraceInformation(string.Format("Changing ThisMachineIsOld to {0}", value));
				this._thisMachineIsOld = value;
				if (value)
				{
					this.ThisMachineAppInventoryRequirement = AppInventoryAmount.OldComputer;
					return;
				}
				if (this.OtherMachine != null && base.ThisMachine != null && this.OtherMachine.Handle == base.ThisMachine.Handle)
				{
					this.ThisMachineAppInventoryRequirement = AppInventoryAmount.OldComputer;
					return;
				}
				this.ThisMachineAppInventoryRequirement = AppInventoryAmount.NewComputer;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002EBE File Offset: 0x000010BE
		public bool IsThisMachineAppInventoryComplete
		{
			get
			{
				return this.ThisMachineAppInvActivityClient == null && this.HasThisMachineAppInvMetRequirement;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002ED0 File Offset: 0x000010D0
		private bool HasThisMachineAppInvMetRequirement
		{
			get
			{
				return this.AppInventoryAmountAtLeast(this.ThisMachineAppInventoryRequirement, this._thisAppInvStatus.Completed);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002EE9 File Offset: 0x000010E9
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002EF4 File Offset: 0x000010F4
		public AppInventoryAmount ThisMachineAppInventoryRequirement
		{
			get
			{
				return this._thisAppInvAmountRequirement;
			}
			set
			{
				if (this._thisAppInvAmountRequirement != value)
				{
					base.Ts.TraceInformation(string.Format("Changing ThisMachineAppInventoryRequirement from {0} to {1}", this._thisAppInvAmountRequirement, value));
					this._thisAppInvAmountRequirement = value;
					this.RunThisMachineAppInventory();
					return;
				}
				base.Ts.TraceInformation(string.Format("Keeping ThisMachineAppInventoryRequirement as {0}", value));
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002F59 File Offset: 0x00001159
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002F61 File Offset: 0x00001161
		public TimeSpan TotalTransferTime { get; private set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002F6A File Offset: 0x0000116A
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002F72 File Offset: 0x00001172
		public double TotalTransferSize { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002F7B File Offset: 0x0000117B
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002F83 File Offset: 0x00001183
		public ComputersInfo Computers { get; private set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002F8C File Offset: 0x0000118C
		public IEnumerable<ApplicationInfo> ApplicationList
		{
			get
			{
				return this._applicationList;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002F94 File Offset: 0x00001194
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002F9C File Offset: 0x0000119C
		private IEnumerable<TransferrableCategoryDefinition> DiskCategories { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002FA5 File Offset: 0x000011A5
		public GroupInfo DocumentsGroup
		{
			get
			{
				Dictionary<PCmoverEngineLive.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineLive.GroupType.Documents];
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002FB9 File Offset: 0x000011B9
		public GroupInfo PicturesGroup
		{
			get
			{
				Dictionary<PCmoverEngineLive.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineLive.GroupType.Pictures];
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002FCD File Offset: 0x000011CD
		public GroupInfo MusicGroup
		{
			get
			{
				Dictionary<PCmoverEngineLive.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineLive.GroupType.Music];
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002FE1 File Offset: 0x000011E1
		public GroupInfo VideoGroup
		{
			get
			{
				Dictionary<PCmoverEngineLive.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineLive.GroupType.Video];
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002FF5 File Offset: 0x000011F5
		public GroupInfo OtherGroup
		{
			get
			{
				Dictionary<PCmoverEngineLive.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineLive.GroupType.Other];
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003009 File Offset: 0x00001209
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00003011 File Offset: 0x00001211
		public IEnumerable<CategoryDefinition> CloudCategories { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000301A File Offset: 0x0000121A
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00003022 File Offset: 0x00001222
		public DriveData Drives { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000302B File Offset: 0x0000122B
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00003033 File Offset: 0x00001233
		public MiscSettingsData MiscSettingsData { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000303C File Offset: 0x0000123C
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00003044 File Offset: 0x00001244
		public UserMappings Users { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000304D File Offset: 0x0000124D
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003068 File Offset: 0x00001268
		public LicenseInfo License
		{
			get
			{
				if (this._license == null)
				{
					this._license = new LicenseInfo();
				}
				return this._license;
			}
			set
			{
				this._license = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003071 File Offset: 0x00001271
		public string ConnectionId
		{
			get
			{
				if (!string.IsNullOrEmpty(this._engineParameters.ConnectionId))
				{
					return this._engineParameters.ConnectionId;
				}
				return this.License.SerialNumber ?? "";
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000079 RID: 121 RVA: 0x000030A5 File Offset: 0x000012A5
		// (set) Token: 0x0600007A RID: 122 RVA: 0x000030AD File Offset: 0x000012AD
		public VersionInfo Version { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000030B6 File Offset: 0x000012B6
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000030BE File Offset: 0x000012BE
		public bool GodMode { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000030C7 File Offset: 0x000012C7
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000030CF File Offset: 0x000012CF
		public bool IsLive { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000030D8 File Offset: 0x000012D8
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000030E0 File Offset: 0x000012E0
		public bool IsScript { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000030E9 File Offset: 0x000012E9
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00003104 File Offset: 0x00001304
		public TransferProgressInfo TransferInfo
		{
			get
			{
				if (this._TransferInfo == null)
				{
					this._TransferInfo = new TransferProgressInfo();
				}
				return this._TransferInfo;
			}
			set
			{
				this._TransferInfo = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000310D File Offset: 0x0000130D
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00003128 File Offset: 0x00001328
		public Settings Settings
		{
			get
			{
				if (this._Settings == null)
				{
					this._Settings = new Settings();
				}
				return this._Settings;
			}
			set
			{
				this._Settings = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00003131 File Offset: 0x00001331
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00003139 File Offset: 0x00001339
		public List<FileFilter> FileFilters { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003142 File Offset: 0x00001342
		// (set) Token: 0x06000088 RID: 136 RVA: 0x0000314A File Offset: 0x0000134A
		public bool AllowUndo { get; set; } = true;

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003154 File Offset: 0x00001354
		public CommunicationState ControlProxyState
		{
			get
			{
				PcmoverControlClient pcmoverControlProxy = this.PcmoverControlProxy;
				if (pcmoverControlProxy != null)
				{
					return pcmoverControlProxy.State;
				}
				if (!this.HasControlInterface)
				{
					return CommunicationState.Faulted;
				}
				return CommunicationState.Opened;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000317D File Offset: 0x0000137D
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00003185 File Offset: 0x00001385
		public bool IsRebooting { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000318E File Offset: 0x0000138E
		// (set) Token: 0x0600008D RID: 141 RVA: 0x00003196 File Offset: 0x00001396
		public TaskAlertData InteractiveDoneAlert { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600008E RID: 142 RVA: 0x0000319F File Offset: 0x0000139F
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000031A7 File Offset: 0x000013A7
		public PolicyData Policy { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000090 RID: 144 RVA: 0x000031B0 File Offset: 0x000013B0
		// (set) Token: 0x06000091 RID: 145 RVA: 0x000031B8 File Offset: 0x000013B8
		private DownloadControlCallback DownloadControlCallback { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000031C1 File Offset: 0x000013C1
		// (set) Token: 0x06000093 RID: 147 RVA: 0x000031C9 File Offset: 0x000013C9
		private DownloadControlClient DownloadControlProxy
		{
			get
			{
				return this._downloadControlProxy;
			}
			set
			{
				this._downloadControlProxy = value;
				base.DownloadControlInterface = value;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000031DC File Offset: 0x000013DC
		public PCmoverEngineLive(IUnityContainer container, IEventAggregator eventAggregator, IEngineParameters engineParameters, LlTraceSource ts) : base(ts)
		{
			this.Container = container;
			this._engineParameters = engineParameters;
			this.EventAggregator = eventAggregator;
			this.GodMode = false;
			this.IsLive = true;
			if (this._engineParameters.PcmoverServiceAddress == null)
			{
				this.IsRemoteUI = 0;
			}
			else
			{
				this.IsRemoteUI = (this._engineParameters.PcmoverServiceAddress.Uri.Scheme != Uri.UriSchemeNetPipe);
			}
			this.UseSSL = ConfigHelper.GetBoolSetting("UseSSL", true);
			this.CertificateName = ConfigHelper.GetStringSetting("CertificateName", string.Empty);
			this._applicationList = new List<ApplicationInfo>();
			this.Settings["IsFilesBasedEnabled"] = true;
			this.Settings["IsIAEnabled"] = true;
			this.Settings["IsUAEnabled"] = false;
			this.FileFilters = new List<FileFilter>();
			this._networkStatsLock = new object();
			eventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Subscribe(new Action<Exception>(this.OnCommunicationExceptionEvent));
			this.EventAggregator.GetEvent<Events.ProcessShutdownRequest>().Subscribe(new Action<Events.ShutdownEventArgs>(this.ProcessShutdown), ThreadOption.UIThread);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000336C File Offset: 0x0000156C
		private void ProcessShutdown(Events.ShutdownEventArgs obj)
		{
			PCmoverEngineLive.<ProcessShutdown>d__200 <ProcessShutdown>d__;
			<ProcessShutdown>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ProcessShutdown>d__.<>4__this = this;
			<ProcessShutdown>d__.obj = obj;
			<ProcessShutdown>d__.<>1__state = -1;
			<ProcessShutdown>d__.<>t__builder.Start<PCmoverEngineLive.<ProcessShutdown>d__200>(ref <ProcessShutdown>d__);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000033AB File Offset: 0x000015AB
		public override void OnCommunicationException(Exception ex)
		{
			this.EventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Publish(ex);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000033C0 File Offset: 0x000015C0
		private void OnCommunicationExceptionEvent(Exception ex)
		{
			PCmoverEngineLive.<OnCommunicationExceptionEvent>d__203 <OnCommunicationExceptionEvent>d__;
			<OnCommunicationExceptionEvent>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCommunicationExceptionEvent>d__.<>4__this = this;
			<OnCommunicationExceptionEvent>d__.<>1__state = -1;
			<OnCommunicationExceptionEvent>d__.<>t__builder.Start<PCmoverEngineLive.<OnCommunicationExceptionEvent>d__203>(ref <OnCommunicationExceptionEvent>d__);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000033F7 File Offset: 0x000015F7
		protected override IEnumerable<BindingFactory> GetStandardBindingFactories()
		{
			return new ServiceBindingFactories_Framework();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003400 File Offset: 0x00001600
		private Task<bool> MakeConnectionAsync()
		{
			PCmoverEngineLive.<MakeConnectionAsync>d__205 <MakeConnectionAsync>d__;
			<MakeConnectionAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<MakeConnectionAsync>d__.<>4__this = this;
			<MakeConnectionAsync>d__.<>1__state = -1;
			<MakeConnectionAsync>d__.<>t__builder.Start<PCmoverEngineLive.<MakeConnectionAsync>d__205>(ref <MakeConnectionAsync>d__);
			return <MakeConnectionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003443 File Offset: 0x00001643
		private void CreatePcmoverControlCallback()
		{
			if (this.PcmoverControlCallback == null)
			{
				this.PcmoverControlCallback = new PcmoverControlCallback(this);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000345C File Offset: 0x0000165C
		public Task<bool> ConnectToPcmoverServiceAsync()
		{
			PCmoverEngineLive.<ConnectToPcmoverServiceAsync>d__208 <ConnectToPcmoverServiceAsync>d__;
			<ConnectToPcmoverServiceAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ConnectToPcmoverServiceAsync>d__.<>4__this = this;
			<ConnectToPcmoverServiceAsync>d__.<>1__state = -1;
			<ConnectToPcmoverServiceAsync>d__.<>t__builder.Start<PCmoverEngineLive.<ConnectToPcmoverServiceAsync>d__208>(ref <ConnectToPcmoverServiceAsync>d__);
			return <ConnectToPcmoverServiceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000034A0 File Offset: 0x000016A0
		protected override bool ConnectToPcmoverControl(EndpointAddress endpointAddress)
		{
			if (this._engineParameters.ConnectToService != null)
			{
				base.Ts.TraceInformation("Trying the ConnectToService interface");
				this.ControlInterface = this._engineParameters.ConnectToService.ConnectToPcmoverControl(endpointAddress, this.PcmoverControlCallback);
				if (this.HasControlInterface)
				{
					base.Ts.TraceInformation("ConnectToService interface connection succeeded.");
					return true;
				}
				base.Ts.TraceInformation("ConnectToService failed.");
			}
			return base.ConnectToPcmoverControl(endpointAddress);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003518 File Offset: 0x00001718
		public FindResponse FindServiceHosts()
		{
			return PCmoverEngineLive.FindServiceHostsStatic();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003520 File Offset: 0x00001720
		public Task<FindResponse> FindServiceHostsAsync()
		{
			PCmoverEngineLive.<FindServiceHostsAsync>d__211 <FindServiceHostsAsync>d__;
			<FindServiceHostsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<FindResponse>.Create();
			<FindServiceHostsAsync>d__.<>1__state = -1;
			<FindServiceHostsAsync>d__.<>t__builder.Start<PCmoverEngineLive.<FindServiceHostsAsync>d__211>(ref <FindServiceHostsAsync>d__);
			return <FindServiceHostsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000355C File Offset: 0x0000175C
		public static Task<FindResponse> FindServiceHostsStaticAsync()
		{
			PCmoverEngineLive.<FindServiceHostsStaticAsync>d__212 <FindServiceHostsStaticAsync>d__;
			<FindServiceHostsStaticAsync>d__.<>t__builder = AsyncTaskMethodBuilder<FindResponse>.Create();
			<FindServiceHostsStaticAsync>d__.<>1__state = -1;
			<FindServiceHostsStaticAsync>d__.<>t__builder.Start<PCmoverEngineLive.<FindServiceHostsStaticAsync>d__212>(ref <FindServiceHostsStaticAsync>d__);
			return <FindServiceHostsStaticAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003598 File Offset: 0x00001798
		private static FindResponse FindServiceHostsStatic()
		{
			DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
			FindCriteria criteria = new FindCriteria(typeof(IPcmoverControl))
			{
				Duration = new TimeSpan(0, 0, 2)
			};
			return discoveryClient.Find(criteria);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000035D4 File Offset: 0x000017D4
		internal void NewPcmoverState(PcmoverState newState)
		{
			if (newState == this._lastState)
			{
				return;
			}
			base.Ts.TraceCaller(newState.ToString(), "NewPcmoverState");
			if (this._shuttingDown && newState == PcmoverState.idle)
			{
				bool flag = false;
				object shutdownLock = this._shutdownLock;
				lock (shutdownLock)
				{
					if (this._shuttingDown)
					{
						flag = true;
						this._shuttingDown = false;
					}
				}
				if (flag)
				{
					Task.Run(new Action(this.FinishShutdown));
				}
			}
			this.EventAggregator.GetEvent<EngineEvents.ServiceStateChanged>().Publish(newState);
			if (this._lastState == PcmoverState.initInProgress)
			{
				TaskCompletionSource<PcmoverState> initComplete = this._initComplete;
				if (initComplete != null)
				{
					initComplete.TrySetResult(newState);
				}
			}
			this._lastState = newState;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000369C File Offset: 0x0000189C
		private void RetrieveInitialData()
		{
			base.Ts.TraceCaller("Starting", "RetrieveInitialData");
			Version pcmoverVersion = this.ControlInterface.GetPcmoverVersion();
			base.Ts.TraceCaller("Engine version: " + ((pcmoverVersion != null) ? pcmoverVersion.ToString() : null), "RetrieveInitialData");
			this.Policy = this.ControlInterface.GetPolicyData();
			base.Ts.TraceCaller("Have policy data", "RetrieveInitialData");
			this.Container.Resolve(Array.Empty<ResolverOverride>()).InitializeReports(this.Policy.ClientReports);
			AppUpdateData appUpdateData = this.ControlInterface.CheckForUpdate();
			base.Ts.TraceCaller(string.Format("Update: {0}", appUpdateData != null && appUpdateData.AppUpdateAvailable), "RetrieveInitialData");
			this.Version = new VersionInfo(pcmoverVersion, appUpdateData);
			try
			{
				this.UndoTime = this.ControlInterface.GetUndoTime();
				base.Ts.TraceCaller("Undo time: " + ((this.UndoTime != default(DateTime)) ? this.UndoTime.ToString() : "none"), "RetrieveInitialData");
			}
			catch (Exception ex)
			{
				base.Ts.TraceCaller("Exception getting Undo time: " + ex.Message, "RetrieveInitialData");
			}
			this.WindowsOldFolder = this.ControlInterface.GetWindowsOld();
			base.Ts.TraceCaller("WindowsOld folder: " + this.WindowsOldFolder, "RetrieveInitialData");
			this.SecurityProducts = this.ControlInterface.GetSecurityProducts();
			if (this.SecurityProducts == null)
			{
				base.Ts.TraceCaller("Null SecurityProducts", "RetrieveInitialData");
			}
			else
			{
				string str = string.IsNullOrWhiteSpace(this.SecurityProducts.AntivirusProduct) ? "No Antivirus" : this.SecurityProducts.AntivirusProduct;
				string str2 = string.IsNullOrWhiteSpace(this.SecurityProducts.FirewallProduct) ? "No Firewall" : this.SecurityProducts.FirewallProduct;
				base.Ts.TraceCaller("Security Products: " + str + " and " + str2, "RetrieveInitialData");
			}
			base.ThisMachine = this.ControlInterface.GetThisMachine();
			LlTraceSource ts = base.Ts;
			string str3 = "ThisMachine: ";
			MachineData thisMachine = base.ThisMachine;
			ts.TraceCaller(str3 + ((thisMachine != null) ? thisMachine.NetName : null), "RetrieveInitialData");
			this.CloudCategories = (this.FindCloudCategories(base.ThisMachine) ?? new List<CategoryDefinition>());
			base.Ts.TraceCaller(string.Format("Cloud categories: {0}", this.CloudCategories.Count<CategoryDefinition>()), "RetrieveInitialData");
			this.ThisMachineDriveSpace = this.ControlInterface.MachineGetDriveSpace(base.ThisMachine.Handle);
			base.Ts.TraceCaller(string.Format("{0} drives", (this.ThisMachineDriveSpace == null) ? 0 : this.ThisMachineDriveSpace.Count<DriveSpaceData>()), "RetrieveInitialData");
			this.InteractiveDoneAlert = this.ControlInterface.PolicyGetInteractiveAlert(TaskAlertData.AlertType.Done);
			if (this.InteractiveDoneAlert == null)
			{
				base.Ts.TraceCaller("Interactive Done Alerts disabled", "RetrieveInitialData");
			}
			else if (string.IsNullOrWhiteSpace(this.InteractiveDoneAlert.Email))
			{
				base.Ts.TraceCaller("Interactive Done Alerts enabled but not pre-defined", "RetrieveInitialData");
			}
			else
			{
				base.Ts.TraceCaller("InteractiveDoneAlert going to " + this.InteractiveDoneAlert.Email, "RetrieveInitialData");
			}
			this.GetLicense();
			if (this.License.IsSerialNumberFromPolicy)
			{
				base.Ts.TraceCaller("License info retrieved from policy", "RetrieveInitialData");
			}
			else
			{
				base.Ts.TraceCaller("License info retrieved from policy", "RetrieveInitialData");
			}
			base.Ts.TraceCaller("Complete", "RetrieveInitialData");
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003A7C File Offset: 0x00001C7C
		private void ResumeAppInventory()
		{
			if (base.ServiceData.Role == PcmoverTransferState.TransferRole.Destination)
			{
				this._thisMachineIsOld = false;
				if (base.ServiceData.TransferType == PcmoverTransferState.TransferTypeEnum.Profile || base.ServiceData.TransferType == PcmoverTransferState.TransferTypeEnum.Undo)
				{
					this._thisAppInvAmountRequirement = AppInventoryAmount.Minimum;
				}
				else
				{
					this._thisAppInvAmountRequirement = AppInventoryAmount.NewComputer;
				}
			}
			else
			{
				this._thisAppInvAmountRequirement = AppInventoryAmount.OldComputer;
			}
			this._thisAppInvStatus.Configuration = this._thisAppInvAmountRequirement;
			new ThisMachineAppInvActivityClient(this).ResumeOrStart(base.ThisMachine.Handle, ref this._thisAppInvStatus);
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00003B00 File Offset: 0x00001D00
		private PcmoverEdition Edition
		{
			get
			{
				PcmoverEdition result;
				if (!Enum.TryParse<PcmoverEdition>(PcmBrandUI.Properties.Resources.Edition, out result))
				{
					result = PcmoverEdition.Pro;
				}
				return result;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003B20 File Offset: 0x00001D20
		private void SetEngineParametersFromProperties()
		{
			if (this._engineParameters.Source == null)
			{
				this._engineParameters.Source = this.GetPublicProperty(PublicProperties.ConfiguredTargetProperty);
			}
			if (this._engineParameters.SingleMachineMode == null)
			{
				string publicProperty = this.GetPublicProperty(PublicProperties.IsSingleMachineModeProperty);
				this._engineParameters.SingleMachineMode = PcmoverProperties.GetNullableBool(publicProperty);
			}
			if (this._engineParameters.ConnectionId == null)
			{
				this._engineParameters.ConnectionId = this.GetPublicProperty(PublicProperties.TransferIdProperty);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003BA8 File Offset: 0x00001DA8
		private Task<bool> DoInitialize()
		{
			PCmoverEngineLive.<DoInitialize>d__224 <DoInitialize>d__;
			<DoInitialize>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<DoInitialize>d__.<>4__this = this;
			<DoInitialize>d__.<>1__state = -1;
			<DoInitialize>d__.<>t__builder.Start<PCmoverEngineLive.<DoInitialize>d__224>(ref <DoInitialize>d__);
			return <DoInitialize>d__.<>t__builder.Task;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003BEC File Offset: 0x00001DEC
		private void GetLicense()
		{
			AuthorizationRequestData authorizationData = this.ControlInterface.GetAuthorizationData();
			base.Ts.TraceCaller(authorizationData.ToString(), "GetLicense");
			this.License = new LicenseInfo(authorizationData);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003C28 File Offset: 0x00001E28
		private bool InitializeResume()
		{
			base.Ts.TraceCaller("Not idle, so we must resume", "InitializeResume");
			InitPcmoverData initPcmoverData = this.ControlInterface.GetInitPcmoverData();
			if (initPcmoverData == null)
			{
				string text = string.Format("State is {0}, and can't get InitPcmoverData", base.ServiceData.PcmoverInfo.State);
				base.Ts.TraceCaller(text, "InitializeResume");
				this._initErrorMessage = text;
				return false;
			}
			if (initPcmoverData.Edition != this.Edition)
			{
				string text2 = string.Format("Mismatched edition resuming transfer. Engine is {0}, but client is {1}", initPcmoverData.Edition, this.Edition);
				base.Ts.TraceCaller(text2, "InitializeResume");
				this._initErrorMessage = this.LookupMessage(UiCallbackCode.InitError_EngineWrongEditionId, initPcmoverData.Edition.ToString(), text2);
				return false;
			}
			if ((initPcmoverData.Oem ?? string.Empty) != (PcmBrandUI.Properties.Resources.OEM ?? string.Empty))
			{
				string text3 = "Mismatched OEM resuming transfer. Engine is " + initPcmoverData.Oem + ", but client is " + PcmBrandUI.Properties.Resources.OEM;
				base.Ts.TraceCaller(text3, "InitializeResume");
				this._initErrorMessage = this.LookupMessage(UiCallbackCode.InitError_EngineWrongOem, initPcmoverData.Oem, text3);
				return false;
			}
			this.SetEngineParametersFromProperties();
			this.ControlInterface.SetProductCulture(ClientEngineModule.Infrastructure.Properties.Resources.Language3Char, ClientEngineModule.Infrastructure.Properties.Resources.Country2Char);
			RequestedPage requestedPage = new RequestedPage(30000);
			DefaultPolicy defaultPolicy = this.Container.Resolve(Array.Empty<ResolverOverride>());
			string text4 = "";
			for (;;)
			{
				string policy = this.ControlInterface.GetPolicy(requestedPage);
				if (string.IsNullOrWhiteSpace(policy))
				{
					break;
				}
				text4 += policy;
				if (policy.Length < requestedPage.MaxCount)
				{
					break;
				}
				requestedPage.NextPage();
			}
			if (text4.Length > 0)
			{
				defaultPolicy.ResetString(text4);
			}
			this.RetrieveInitialData();
			base.IsResuming = true;
			this.ResumeAppInventory();
			this.RunConnectionMonitor();
			return true;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003E0D File Offset: 0x0000200D
		private void RunConnectionMonitor()
		{
			this._stopMonitorEvent = new AutoResetEvent(false);
			this._monitorConnection = true;
			this._connectionMonitorThread = new Thread(new ThreadStart(this.ConnectionMonitorThread));
			this._connectionMonitorThread.Start();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003E44 File Offset: 0x00002044
		private void ConnectionMonitorThread()
		{
			base.Ts.TraceCaller("Started", "ConnectionMonitorThread");
			while (this._monitorConnection)
			{
				PcmoverControlClient pcmoverControlProxy = this.PcmoverControlProxy;
				if (pcmoverControlProxy == null)
				{
					break;
				}
				CommunicationState state = pcmoverControlProxy.State;
				if (state != CommunicationState.Opened)
				{
					base.Ts.TraceCaller(state.ToString(), "ConnectionMonitorThread");
					if (state == CommunicationState.Faulted)
					{
						this.OnCommunicationException(new CommunicationException("MonitorConnection detected Faulted state for ControlProxy"));
						break;
					}
				}
				if (this._stopMonitorEvent.WaitOne(10000))
				{
					break;
				}
			}
			base.Ts.TraceCaller("Ended", "ConnectionMonitorThread");
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003EDF File Offset: 0x000020DF
		private void StopConnectionMonitor()
		{
			this._monitorConnection = false;
			AutoResetEvent stopMonitorEvent = this._stopMonitorEvent;
			if (stopMonitorEvent == null)
			{
				return;
			}
			stopMonitorEvent.Set();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003EFC File Offset: 0x000020FC
		private Task<int> DisplayMessageAsync(string v)
		{
			PCmoverEngineLive.<DisplayMessageAsync>d__233 <DisplayMessageAsync>d__;
			<DisplayMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<DisplayMessageAsync>d__.<>4__this = this;
			<DisplayMessageAsync>d__.v = v;
			<DisplayMessageAsync>d__.<>1__state = -1;
			<DisplayMessageAsync>d__.<>t__builder.Start<PCmoverEngineLive.<DisplayMessageAsync>d__233>(ref <DisplayMessageAsync>d__);
			return <DisplayMessageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003F48 File Offset: 0x00002148
		private Task DisconnectServiceAsync(string message = null)
		{
			PCmoverEngineLive.<DisconnectServiceAsync>d__234 <DisconnectServiceAsync>d__;
			<DisconnectServiceAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DisconnectServiceAsync>d__.<>4__this = this;
			<DisconnectServiceAsync>d__.message = message;
			<DisconnectServiceAsync>d__.<>1__state = -1;
			<DisconnectServiceAsync>d__.<>t__builder.Start<PCmoverEngineLive.<DisconnectServiceAsync>d__234>(ref <DisconnectServiceAsync>d__);
			return <DisconnectServiceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003F94 File Offset: 0x00002194
		public Task ShutdownPcmoverAppAsync(bool terminateService)
		{
			PCmoverEngineLive.<ShutdownPcmoverAppAsync>d__235 <ShutdownPcmoverAppAsync>d__;
			<ShutdownPcmoverAppAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShutdownPcmoverAppAsync>d__.<>4__this = this;
			<ShutdownPcmoverAppAsync>d__.terminateService = terminateService;
			<ShutdownPcmoverAppAsync>d__.<>1__state = -1;
			<ShutdownPcmoverAppAsync>d__.<>t__builder.Start<PCmoverEngineLive.<ShutdownPcmoverAppAsync>d__235>(ref <ShutdownPcmoverAppAsync>d__);
			return <ShutdownPcmoverAppAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003FDF File Offset: 0x000021DF
		private void DisableCallbacks()
		{
			this.ControlInterface.ConfigureControlCallbacks(CallbackState.Inactive);
			this.ControlInterface.ConfigureMonitorCallbacks(CallbackState.Inactive);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003FFC File Offset: 0x000021FC
		public void DisconnectFromPcmoverService()
		{
			if (this.ControlInterface != null)
			{
				try
				{
					base.Ts.TraceCaller(null, "DisconnectFromPcmoverService");
					this.StopConnectionMonitor();
					this.ControlInterface.StopBeingController();
					this.ControlInterface.ConfigureMonitorCallbacks(CallbackState.Inactive);
					IDownloadControl downloadControlInterface = base.DownloadControlInterface;
					if (downloadControlInterface != null)
					{
						downloadControlInterface.StopBeingController();
					}
					IDownloadControl downloadControlInterface2 = base.DownloadControlInterface;
					if (downloadControlInterface2 != null)
					{
						downloadControlInterface2.ConfigureMonitorCallbacks(CallbackState.Inactive);
					}
					this.CloseDownloadConnection();
					this.ClosePcmoverConnection();
				}
				catch (Exception e)
				{
					this.HandleException(e, "DisconnectFromPcmoverService");
					this.PcmoverControlProxy = null;
				}
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004098 File Offset: 0x00002298
		private void ClosePcmoverConnection()
		{
			if (this.PcmoverControlProxy != null)
			{
				this.PcmoverControlProxy.CloseOrAbort();
				this.PcmoverControlProxy = null;
			}
			else
			{
				IDisposable disposable = this.ControlInterface as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
				this.ControlInterface = null;
			}
			this.PcmoverControlCallback = null;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000040E4 File Offset: 0x000022E4
		private void CloseDownloadConnection()
		{
			if (this.DownloadControlProxy != null)
			{
				this.DownloadControlProxy.CloseOrAbort();
				this.DownloadControlProxy = null;
			}
			else
			{
				IDisposable disposable = base.DownloadControlInterface as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
				base.DownloadControlInterface = null;
			}
			this.DownloadControlCallback = null;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004130 File Offset: 0x00002330
		private void FinishShutdown()
		{
			try
			{
				if (this._restarting)
				{
					this._restarting = false;
					base.Ts.TraceCaller("Connect to PCmover service for restart", "FinishShutdown");
					Task.Run<bool>(() => this.ConnectToPcmoverServiceAsync());
				}
				else
				{
					this.DisconnectFromPcmoverService();
				}
			}
			catch (Exception e)
			{
				this.HandleException(e, "FinishShutdown");
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000419C File Offset: 0x0000239C
		public Task ShutdownAndRestartPcmoverAsync()
		{
			PCmoverEngineLive.<ShutdownAndRestartPcmoverAsync>d__241 <ShutdownAndRestartPcmoverAsync>d__;
			<ShutdownAndRestartPcmoverAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShutdownAndRestartPcmoverAsync>d__.<>4__this = this;
			<ShutdownAndRestartPcmoverAsync>d__.<>1__state = -1;
			<ShutdownAndRestartPcmoverAsync>d__.<>t__builder.Start<PCmoverEngineLive.<ShutdownAndRestartPcmoverAsync>d__241>(ref <ShutdownAndRestartPcmoverAsync>d__);
			return <ShutdownAndRestartPcmoverAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000041E0 File Offset: 0x000023E0
		private void ResetState()
		{
			base.ActivityClients.Clear();
			base.ThisMachine = null;
			this._discoveryTransferMethodHandles = null;
			this._listenTransferMethodHandles = null;
			this._transferTaskHandle = 0;
			this._fillTaskHandle = 0;
			this._srcMachineHandle = 0;
			this._dstMachineHandle = 0;
			this._ftmh = 0;
			this._fileAnyTransferMethodHandle = 0;
			this._itmh = 0;
			this._winUpgradeTransferMethodHandle = 0;
			this._selfTransferMethodHandle = 0;
			this._customizeTaskHandle = 0;
			this.OtherMachine = null;
			this.TargetMachine = null;
			this._thisMachineIsOld = true;
			this._thisAppInvAmountRequirement = AppInventoryAmount.None;
			this._applicationList = new List<ApplicationInfo>();
			this.DiskCategories = null;
			this._groups = null;
			this.Drives = null;
			this.MiscSettingsData = null;
			this.Users = null;
			this._license = null;
			this._TransferInfo = null;
			this.FileFilters = new List<FileFilter>();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000042B8 File Offset: 0x000024B8
		private void DeleteTransferMethodHandles(IEnumerable<int> transferMethodHandles)
		{
			if (transferMethodHandles != null)
			{
				foreach (int transferMethodHandle in transferMethodHandles)
				{
					this.ControlInterface.DeleteTransferMethod(transferMethodHandle);
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000430C File Offset: 0x0000250C
		private void HandleException(Exception e, [CallerMemberName] string caller = "")
		{
			PCmoverEngineLive.<HandleException>d__244 <HandleException>d__;
			<HandleException>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<HandleException>d__.<>4__this = this;
			<HandleException>d__.e = e;
			<HandleException>d__.caller = caller;
			<HandleException>d__.<>1__state = -1;
			<HandleException>d__.<>t__builder.Start<PCmoverEngineLive.<HandleException>d__244>(ref <HandleException>d__);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004354 File Offset: 0x00002554
		public IDownloadControl GetDownloadManager()
		{
			IDownloadControl downloadControl = this.ConnectToDownloadControl();
			if (downloadControl != null)
			{
				try
				{
					if (downloadControl.BecomeController(CallbackState.Active))
					{
						return downloadControl;
					}
					base.Ts.TraceError("Cannot become controller of DownloadManager");
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "GetDownloadManager");
					this.CloseDownloadConnection();
				}
			}
			return null;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000043B8 File Offset: 0x000025B8
		private IDownloadControl ConnectToDownloadControl()
		{
			if (base.HasDownloadControlInterface)
			{
				try
				{
					base.DownloadControlInterface.GetDownloadVersion();
					return base.DownloadControlInterface;
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "ConnectToDownloadControl");
					this.DownloadControlProxy = null;
				}
			}
			try
			{
				this.DownloadControlCallback = new DownloadControlCallback(this);
				if (this._engineParameters.ConnectToService != null)
				{
					base.DownloadControlInterface = this._engineParameters.ConnectToService.ConnectToDownloadControl(this.DownloadControlCallback);
					if (base.HasDownloadControlInterface)
					{
						return base.DownloadControlInterface;
					}
				}
				InstanceContext callbackInstance = new InstanceContext(this.DownloadControlCallback);
				DownloadControlEndpoint downloadControlEndpoint = new DownloadControlEndpoint(this.GetStandardBindingFactories())
				{
					Uri = new Uri(this.ControlInterface.GetDownloadManagerEndpointAddress(ServiceType.Control))
				};
				this.DownloadControlProxy = new DownloadControlClient(callbackInstance, downloadControlEndpoint.Binding, downloadControlEndpoint.EndpointAddress);
				base.DownloadInterfaces.ControlInterface = this.DownloadControlProxy;
			}
			catch (Exception ex2)
			{
				base.Ts.TraceException(ex2, "ConnectToDownloadControl");
				this.DownloadControlProxy = null;
			}
			return base.DownloadInterfaces.ControlInterfaceValue;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000044EC File Offset: 0x000026EC
		public bool SuspendSleep(bool suspend)
		{
			return this.ControlInterface.SuspendSleep(suspend);
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000044FA File Offset: 0x000026FA
		public bool IsRemoteUI { get; }

		// Token: 0x060000BC RID: 188 RVA: 0x00004502 File Offset: 0x00002702
		internal bool AppInventoryAmountAtLeast(AppInventoryAmount target, AppInventoryAmount candidate)
		{
			return target <= candidate;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000450C File Offset: 0x0000270C
		internal void RunThisMachineAppInventory()
		{
			base.Ts.TraceCaller(this.ThisMachineAppInventoryRequirement.ToString(), "RunThisMachineAppInventory");
			object thisAppInvLock = this._thisAppInvLock;
			lock (thisAppInvLock)
			{
				ThisMachineAppInvActivityClient thisMachineAppInvActivityClient = this.ThisMachineAppInvActivityClient;
				if (this.HasThisMachineAppInvMetRequirement)
				{
					base.Ts.TraceCaller("We've done enough, stop the client", "RunThisMachineAppInventory");
					if (thisMachineAppInvActivityClient != null)
					{
						thisMachineAppInvActivityClient.Stop(null);
					}
				}
				else if (thisMachineAppInvActivityClient != null)
				{
					base.Ts.TraceCaller("We need to do more, and it's already going", "RunThisMachineAppInventory");
					if (this._thisAppInvStatus.Configuration != this.ThisMachineAppInventoryRequirement)
					{
						base.Ts.TraceCaller("Reconfigure it", "RunThisMachineAppInventory");
						this._thisAppInvStatus.Configuration = this.ThisMachineAppInventoryRequirement;
						this.ControlInterface.ConfigureAppInventoryActivity(thisMachineAppInvActivityClient.Handle, this._thisAppInvStatus.Configuration);
					}
					else
					{
						base.Ts.TraceCaller("It's already configured for what we need", "RunThisMachineAppInventory");
					}
				}
				else
				{
					base.Ts.TraceCaller("It's not running and we need more. Create a new activity.", "RunThisMachineAppInventory");
					this._thisAppInvStatus.Configuration = this.ThisMachineAppInventoryRequirement;
					thisMachineAppInvActivityClient = new ThisMachineAppInvActivityClient(this);
					thisMachineAppInvActivityClient.ResumeOrStart(base.ThisMachine.Handle, ref this._thisAppInvStatus);
				}
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000467C File Offset: 0x0000287C
		public void SetProductCulture(string language, string country)
		{
			this.ControlInterface.SetProductCulture(language, country);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000468B File Offset: 0x0000288B
		public AuthorizationRequestData GetAuthorizationRequestData(LicenseInfo license)
		{
			return new AuthorizationRequestData(license);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004694 File Offset: 0x00002894
		public Task<SerialNumberInfo> GetSerialNumberInfoAsync(string serialNumber)
		{
			PCmoverEngineLive.<GetSerialNumberInfoAsync>d__255 <GetSerialNumberInfoAsync>d__;
			<GetSerialNumberInfoAsync>d__.<>t__builder = AsyncTaskMethodBuilder<SerialNumberInfo>.Create();
			<GetSerialNumberInfoAsync>d__.<>4__this = this;
			<GetSerialNumberInfoAsync>d__.serialNumber = serialNumber;
			<GetSerialNumberInfoAsync>d__.<>1__state = -1;
			<GetSerialNumberInfoAsync>d__.<>t__builder.Start<PCmoverEngineLive.<GetSerialNumberInfoAsync>d__255>(ref <GetSerialNumberInfoAsync>d__);
			return <GetSerialNumberInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000046E0 File Offset: 0x000028E0
		public AuthorizationInfo TaskGetAuthorizationInfo()
		{
			AuthorizationInfo authorizationInfo = null;
			if (this._customizeTaskHandle != 0)
			{
				authorizationInfo = this.ControlInterface.TaskGetAuthorizationInfo(this._customizeTaskHandle);
			}
			if (authorizationInfo == null)
			{
				authorizationInfo = new AuthorizationInfo();
			}
			return authorizationInfo;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004713 File Offset: 0x00002913
		public bool TaskPrepareAuthorization(LicenseInfo license)
		{
			return this.ControlInterface.TaskPrepareAuthorization(this._customizeTaskHandle, this.GetAuthorizationRequestData(license));
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000472D File Offset: 0x0000292D
		public bool ApplyDataUpdate()
		{
			return this.ControlInterface.ApplyDataUpdate();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000473C File Offset: 0x0000293C
		public ActivityClient StartBuildChangeLists()
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.BuildChangeLists);
			if (activityClient == null)
			{
				activityClient = new ActivityClient(this);
				ActivityClient activityClient2 = activityClient;
				activityClient2.OnProgressCallback = (ActivityClient.ProgressDelegate)Delegate.Combine(activityClient2.OnProgressCallback, new ActivityClient.ProgressDelegate(delegate(ActivityInfo activityInfo, ProgressInfo progressInfo)
				{
					this.EventAggregator.GetEvent<EngineEvents.AnalysisProgressChanged>().Publish(progressInfo);
				}));
				ActivityClient activityClient3 = activityClient;
				activityClient3.OnSucceededCallback = (ActivityClient.ActivityInfoDelegate)Delegate.Combine(activityClient3.OnSucceededCallback, new ActivityClient.ActivityInfoDelegate(delegate(ActivityInfo info)
				{
					this.EventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Publish(this.ControlInterface.TaskGetStats(this._fillTaskHandle, true));
				}));
				if (this._fillTaskHandle != 0)
				{
					if (base.IsResuming)
					{
						activityClient.Resume(ActivityType.BuildChangeLists);
					}
					else
					{
						activityClient.Start(this.ControlInterface.CreateBuildChangeListsActivity(this._fillTaskHandle));
					}
				}
			}
			return activityClient;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000047D8 File Offset: 0x000029D8
		public ActivityClient StartLoadMovingJournal(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				return null;
			}
			int fileTransferMethod = this.ControlInterface.CreateTransferMethod(TransferMethodType.File);
			this.ControlInterface.SetFileTransferMethodInfo(fileTransferMethod, new FileTransferMethodInfo
			{
				FileName = fileName
			});
			ActivityClient client = new ActivityClient(this);
			ActivityClient client2 = client;
			Action <>9__1;
			client2.OnDoneCallback = (ActivityClient.ActivityInfoDelegate)Delegate.Combine(client2.OnDoneCallback, new ActivityClient.ActivityInfoDelegate(delegate(ActivityInfo info)
			{
				PcmoverClientEngine<PcmoverControlClient> <>4__this = this;
				Action func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate()
					{
						this._transferTaskHandle = this.ControlInterface.GetActivityTaskHandle(client.Handle);
						this.GenerateTransferReports();
						this.ControlInterface.DeleteTransferMethod(fileTransferMethod);
					});
				}
				<>4__this.CatchCommEx(func, "StartLoadMovingJournal");
			}));
			client.Start(this.ControlInterface.CreateLoadMovingJournalActivity(fileTransferMethod));
			return client;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004884 File Offset: 0x00002A84
		public Task<ActivityClient> StartFindComputerAsync()
		{
			PCmoverEngineLive.<StartFindComputerAsync>d__261 <StartFindComputerAsync>d__;
			<StartFindComputerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ActivityClient>.Create();
			<StartFindComputerAsync>d__.<>4__this = this;
			<StartFindComputerAsync>d__.<>1__state = -1;
			<StartFindComputerAsync>d__.<>t__builder.Start<PCmoverEngineLive.<StartFindComputerAsync>d__261>(ref <StartFindComputerAsync>d__);
			return <StartFindComputerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000048C8 File Offset: 0x00002AC8
		public IEnumerable<ConnectableMachine> GetConnectableMachines()
		{
			base.Ts.TraceCaller(string.Format("IsResuming={0}", base.IsResuming), "GetConnectableMachines");
			IPcmoverControl controlInterface = this.ControlInterface;
			ActivityClient discoveryActivityClient = this.DiscoveryActivityClient;
			return controlInterface.GetConnectableMachines((discoveryActivityClient != null) ? discoveryActivityClient.Handle : 0);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004917 File Offset: 0x00002B17
		public bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure)
		{
			return this.ControlInterface.AddRemoteMachine(machine, discoveryId, bSecure);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004927 File Offset: 0x00002B27
		public bool SetDirection(ConnectableMachine remoteMachine)
		{
			base.Ts.TraceCaller((remoteMachine != null) ? remoteMachine.NetName : null, "SetDirection");
			if (!this.UseSSL && remoteMachine != null)
			{
				remoteMachine.CertificateName = string.Empty;
			}
			return this.ControlInterface.SetDirection(remoteMachine);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004967 File Offset: 0x00002B67
		public ActivityClient StartTransfer()
		{
			if (this._fillTaskHandle == 0)
			{
				return null;
			}
			return this.StartTransfer(this._otherMachineTransferMethodHandle);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004980 File Offset: 0x00002B80
		private ActivityClient StartTransfer(int transferMethodHandle)
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.Transfer);
			if (activityClient == null)
			{
				this.DeleteTask(ref this._transferTaskHandle);
				activityClient = new TransferActivityClient(this);
				if (base.IsResuming)
				{
					activityClient.Resume(ActivityType.Transfer);
				}
				else
				{
					activityClient.Start(this.ControlInterface.CreateTransferActivity(new TransferActivityParameters(transferMethodHandle, this._fillTaskHandle, this.AllowUndo)));
				}
			}
			return activityClient;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000049E8 File Offset: 0x00002BE8
		public ActivityClient StartTransferMovingVan(string fileName)
		{
			if (!this.IsThisMachineAppInventoryComplete)
			{
				return null;
			}
			this._srcMachineHandle = 0;
			if (this.FileTransferMethodHandle == 0)
			{
				this.FileTransferMethodHandle = this.GetFileTransferMethodHandle(fileName, null, null, null);
				if (this.FileTransferMethodHandle == 0)
				{
					return null;
				}
			}
			return this.StartTransfer(this.FileTransferMethodHandle);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004A4C File Offset: 0x00002C4C
		public TransferSpeeds GetTransferSpeeds(ActivityClient transferClient)
		{
			if (transferClient == null)
			{
				return null;
			}
			return this.ControlInterface.GetTransferSpeeds(transferClient.Handle);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004A64 File Offset: 0x00002C64
		internal void DeleteListenTransferMethodHandles()
		{
			if (this._listenTransferMethodHandles == null)
			{
				return;
			}
			foreach (int transferMethodHandle in this._listenTransferMethodHandles)
			{
				this.ControlInterface.DeleteTransferMethod(transferMethodHandle);
			}
			this._listenTransferMethodHandles = null;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public ActivityClient StartListenActivity(string discoveryId, string password)
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.Listen);
			if (activityClient == null)
			{
				this.DeleteListenTransferMethodHandles();
				if (base.IsResuming)
				{
					ActivityInfo activity = base.ServiceData.GetActivity(ActivityType.Listen);
					if (activity == null)
					{
						return null;
					}
					this._listenTransferMethodHandles = this.ControlInterface.GetActivityTransferMethodHandles(activity.Handle);
					activityClient = new ActivityClient(this);
					activityClient.Resume(ActivityType.Listen, activity);
					this._transferTaskHandle = this.ControlInterface.GetActivityTaskHandle(activity.Handle);
					return activityClient;
				}
				else
				{
					List<TransferMethodType> list = new List<TransferMethodType>();
					if ((this.Policy.Connection.EnabledMethods & ConnectionPolicyMethods.TcpOrUdp) != ConnectionPolicyMethods.None)
					{
						list.Add(TransferMethodType.Network);
						list.Add(TransferMethodType.SSL);
					}
					if (this.Policy.Connection.EnabledMethods.HasFlag(ConnectionPolicyMethods.Usb))
					{
						list.Add(TransferMethodType.Usb);
					}
					this._listenTransferMethodHandles = base.CreateTransferMethods(list, password);
					activityClient = new ActivityClient(this);
					ActivityClient activityClient2 = activityClient;
					activityClient2.OnProgressCallback = (ActivityClient.ProgressDelegate)Delegate.Combine(activityClient2.OnProgressCallback, new ActivityClient.ProgressDelegate(delegate(ActivityInfo activityInfo, ProgressInfo progressInfo)
					{
						this.EventAggregator.GetEvent<EngineEvents.ListenProgressChanged>().Publish(progressInfo);
					}));
					ActivityClient activityClient3 = activityClient;
					activityClient3.OnDoneCallback = (ActivityClient.ActivityInfoDelegate)Delegate.Combine(activityClient3.OnDoneCallback, new ActivityClient.ActivityInfoDelegate(delegate(ActivityInfo activityInfo)
					{
						base.CatchCommEx(delegate
						{
							this._transferTaskHandle = this.ControlInterface.GetActivityTaskHandle(activityInfo.Handle);
						}, "StartListenActivity");
					}));
					activityClient.Start(this.ControlInterface.CreateListenActivity(this._listenTransferMethodHandles, discoveryId ?? this.ConnectionId));
				}
			}
			return activityClient;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004C18 File Offset: 0x00002E18
		public ActivityClient StartUndoActivity()
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.Undo);
			if (activityClient == null)
			{
				if (!this.IsThisMachineAppInventoryComplete)
				{
					return null;
				}
				this.DeleteTask(ref this._transferTaskHandle);
				activityClient = new TransferActivityClient(this);
				if (base.IsResuming)
				{
					activityClient.Resume(ActivityType.Undo);
				}
				else
				{
					activityClient.Start(this.ControlInterface.CreateUndoActivity());
				}
			}
			return activityClient;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004C78 File Offset: 0x00002E78
		public Task StopActivityAsync(ActivityClient client, bool waitUntilDone = true)
		{
			PCmoverEngineLive.<StopActivityAsync>d__272 <StopActivityAsync>d__;
			<StopActivityAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StopActivityAsync>d__.<>4__this = this;
			<StopActivityAsync>d__.client = client;
			<StopActivityAsync>d__.waitUntilDone = waitUntilDone;
			<StopActivityAsync>d__.<>1__state = -1;
			<StopActivityAsync>d__.<>t__builder.Start<PCmoverEngineLive.<StopActivityAsync>d__272>(ref <StopActivityAsync>d__);
			return <StopActivityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004CCC File Offset: 0x00002ECC
		public Task StopActivityAsync(ActivityType type, bool waitUntilDone = true)
		{
			ActivityClient activityClient = this.GetActivityClient(type);
			if (activityClient != null)
			{
				return this.StopActivityAsync(activityClient, waitUntilDone);
			}
			return Task.CompletedTask;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004CF2 File Offset: 0x00002EF2
		public ActivityClient GetActivityClient(ActivityType type)
		{
			return base.ActivityClients.FindByActivityType(type);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004D00 File Offset: 0x00002F00
		public ActivityClient GetActivityClient(int handle)
		{
			return base.ActivityClients.FindByHandle(handle);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004D10 File Offset: 0x00002F10
		internal void DeleteTask(ref int taskHandle)
		{
			try
			{
				if (taskHandle != 0 && this.HasControlInterface)
				{
					this.ControlInterface.DeleteTask(taskHandle);
				}
				if (taskHandle == this._customizeTaskHandle)
				{
					this._customizeTaskHandle = 0;
				}
				taskHandle = 0;
			}
			catch (SystemException ex) when (ex is CommunicationException || ex is TimeoutException)
			{
				base.Ts.TraceException(ex, "DeleteTask");
				throw;
			}
			catch (Exception ex2)
			{
				base.Ts.TraceException(ex2, "DeleteTask");
				this.HandleException(ex2, "DeleteTask");
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004DC4 File Offset: 0x00002FC4
		private void DeleteMachine(ref int machineHandle)
		{
			try
			{
				if (machineHandle != 0 && this.HasControlInterface)
				{
					this.ControlInterface.DeleteMachine(machineHandle);
				}
				machineHandle = 0;
			}
			catch (SystemException ex) when (ex is CommunicationException || ex is TimeoutException)
			{
				base.Ts.TraceException(ex, "DeleteMachine");
				throw;
			}
			catch (Exception ex2)
			{
				base.Ts.TraceException(ex2, "DeleteMachine");
				this.HandleException(ex2, "DeleteMachine");
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004E68 File Offset: 0x00003068
		internal void DeleteTransferMethod(ref int transferMethodHandle)
		{
			try
			{
				if (transferMethodHandle != 0 && this.HasControlInterface)
				{
					this.ControlInterface.DeleteTransferMethod(transferMethodHandle);
				}
				transferMethodHandle = 0;
			}
			catch (SystemException ex) when (ex is CommunicationException || ex is TimeoutException)
			{
				base.Ts.TraceException(ex, "DeleteTransferMethod");
				throw;
			}
			catch (Exception ex2)
			{
				base.Ts.TraceException(ex2, "DeleteTransferMethod");
				this.HandleException(ex2, "DeleteTransferMethod");
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004F0C File Offset: 0x0000310C
		public ActivityClient StartReadSnapshot()
		{
			return this.StartReadSnapshot(this.TargetMachine);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004F1C File Offset: 0x0000311C
		public ActivityClient StartReadSnapshot(ConnectableMachine targetMachine)
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.GetSnapshot);
			if (activityClient == null)
			{
				base.Ts.TraceCaller("Set ThisMachineIsOld = false", "StartReadSnapshot");
				this.ThisMachineIsOld = false;
				if (targetMachine == null)
				{
					base.Ts.TraceCaller("Possible problem, no targetMachine parameter", "StartReadSnapshot");
				}
				if (base.IsResuming && base.ServiceData.GetActivity(ActivityType.GetSnapshot) == null && base.ServiceData.Machines.Count<MachineData>() < 2)
				{
					base.Ts.TraceCaller("Turning off IsResuming because there are fewer than 2 machines", "StartReadSnapshot");
					base.IsResuming = false;
				}
				GetSnapshotActivityClient getSnapshotActivityClient = new GetSnapshotActivityClient(this);
				activityClient = getSnapshotActivityClient;
				if (!base.IsResuming && !getSnapshotActivityClient.ConfigureTransferMethod(targetMachine, this.UseSSL))
				{
					base.OnActivityChanged(new ActivityInfo
					{
						Type = ActivityType.GetSnapshot,
						State = ActivityState.Failure,
						FailureReason = 12
					}, MonitorChangeType.Changed);
					return null;
				}
				getSnapshotActivityClient.Start((targetMachine == null) ? 0 : targetMachine.TransferMethodHandle);
				this.StopResumingIfNoFillTask("StartReadSnapshot");
			}
			return activityClient;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005017 File Offset: 0x00003217
		public Task StopReadSnapshotAsync(bool waitUntilDone = true)
		{
			return this.StopActivityAsync(ActivityType.GetSnapshot, waitUntilDone);
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00005021 File Offset: 0x00003221
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00005029 File Offset: 0x00003229
		public MigrationItemsOption MigrationItemsSelection
		{
			get
			{
				return this.MigrationItems;
			}
			set
			{
				this.ChangeMigrationItems(value);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00005033 File Offset: 0x00003233
		// (set) Token: 0x060000DE RID: 222 RVA: 0x0000503B File Offset: 0x0000323B
		public MigrationItemsOption MigrationItems { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00005044 File Offset: 0x00003244
		public NetworkStatsData NetworkStats
		{
			get
			{
				object networkStatsLock = this._networkStatsLock;
				NetworkStatsData networkStats;
				lock (networkStatsLock)
				{
					networkStats = this.ControlInterface.GetNetworkStats();
				}
				return networkStats;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000508C File Offset: 0x0000328C
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00005094 File Offset: 0x00003294
		public string CloudToken { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000509D File Offset: 0x0000329D
		public string DefaultCertificateName
		{
			get
			{
				return this.ControlInterface.GetDefaultCertificateName();
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000050AC File Offset: 0x000032AC
		public CustomizationData ChangeMigrationItems(MigrationItemsOption migItems)
		{
			CustomizationData customizationData = this.ControlInterface.TaskChangeMigrationItems(this._customizeTaskHandle, migItems);
			if (customizationData != null && customizationData.Result == CustomizationResult.Success)
			{
				this.MigrationItems = migItems;
			}
			return customizationData;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000050E0 File Offset: 0x000032E0
		public void RetrieveMigrationItems()
		{
			if (this._customizeTaskHandle == 0)
			{
				return;
			}
			MigrationItemsOption? migrationItemsOption = this.ControlInterface.TaskGetMigrationItems(this._customizeTaskHandle);
			if (migrationItemsOption != null)
			{
				this.MigrationItems = migrationItemsOption.Value;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00005120 File Offset: 0x00003320
		private void ProcessApplicationDataList(List<ApplicationData> applicationDataList)
		{
			this._applicationList = new List<ApplicationInfo>();
			if (applicationDataList != null)
			{
				foreach (ApplicationData applicationData in applicationDataList)
				{
					ApplicationInfo applicationInfo = new ApplicationInfo(applicationData);
					if (applicationData.Bitmap != null)
					{
						IntPtr hbitmap = applicationData.Bitmap.GetHbitmap();
						BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
						applicationInfo.AppImage = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
						applicationData.Bitmap.Dispose();
						applicationData.Bitmap = null;
					}
					this._applicationList.Add(applicationInfo);
				}
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000051D0 File Offset: 0x000033D0
		private List<ApplicationData> GetApplicationDataList()
		{
			return this.GetApplications(this._customizeTaskHandle, new GetApplicationsParameters
			{
				IncludeBitmap = true,
				ModifiableOnly = true
			});
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000051F4 File Offset: 0x000033F4
		public List<ApplicationData> GetApplications(int taskHandle, GetApplicationsParameters parameters)
		{
			RequestedPage requestedPage = new RequestedPage(10);
			List<ApplicationData> list = null;
			int num = 0;
			for (;;)
			{
				base.Ts.TraceCaller(string.Format("Getting {0} starting at {1}", requestedPage.MaxCount, requestedPage.StartIndex), "GetApplications");
				IEnumerable<ApplicationData> enumerable;
				try
				{
					enumerable = this.ControlInterface.TaskGetApplications(taskHandle, parameters, requestedPage);
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "GetApplications");
					enumerable = null;
				}
				if (enumerable == null)
				{
					break;
				}
				num += enumerable.Count<ApplicationData>();
				ulong bitmapSizes = this.GetBitmapSizes(enumerable);
				int num2 = (from app in enumerable
				where app.Bitmap != null
				select app).Count<ApplicationData>();
				base.Ts.TraceCaller(string.Format("Got {0} applications with {1} bitmaps totalling {2}", enumerable.Count<ApplicationData>(), num2, bitmapSizes), "GetApplications");
				IEnumerable<ApplicationData> enumerable2 = from app in enumerable
				where app.Selected || app.Reason != SelectedReason.Unavailable
				select app;
				if (list == null)
				{
					list = enumerable2.ToList<ApplicationData>();
				}
				else
				{
					list.AddRange(enumerable2);
				}
				if (num < requestedPage.ExpectedEnd)
				{
					break;
				}
				requestedPage.NextPage();
			}
			base.Ts.TraceCaller(string.Format("Retrieved {0}, using {1}", num, list.Count), "GetApplications");
			return list;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000536C File Offset: 0x0000356C
		private ulong GetBitmapSizes(IEnumerable<ApplicationData> page)
		{
			ulong num = 0UL;
			foreach (ApplicationData applicationData in page)
			{
				num += this.GetBitmapSize(applicationData.Bitmap);
			}
			return num;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000053C0 File Offset: 0x000035C0
		private ulong GetBitmapSize(Bitmap bitmap)
		{
			if (bitmap == null)
			{
				return 0UL;
			}
			int pixelFormatSize = Image.GetPixelFormatSize(bitmap.PixelFormat);
			return (ulong)((long)(bitmap.Width * bitmap.Height * pixelFormatSize));
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000053F0 File Offset: 0x000035F0
		public Task RetrieveApplicationListAsync()
		{
			PCmoverEngineLive.<RetrieveApplicationListAsync>d__304 <RetrieveApplicationListAsync>d__;
			<RetrieveApplicationListAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RetrieveApplicationListAsync>d__.<>4__this = this;
			<RetrieveApplicationListAsync>d__.<>1__state = -1;
			<RetrieveApplicationListAsync>d__.<>t__builder.Start<PCmoverEngineLive.<RetrieveApplicationListAsync>d__304>(ref <RetrieveApplicationListAsync>d__);
			return <RetrieveApplicationListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005433 File Offset: 0x00003633
		public CustomizationData ChangeApplicationSelection(ApplicationInfo appInfo)
		{
			return this.ChangeApplicationInfo(appInfo);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000543C File Offset: 0x0000363C
		public CustomizationData ChangeApplicationInfo(ApplicationInfo appInfo)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			return this.ControlInterface.TaskChangeApplicationData(this._customizeTaskHandle, appInfo.Data);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005460 File Offset: 0x00003660
		public Task<int> CreateFillTask(int srcMachine, int dstMachine)
		{
			PCmoverEngineLive.<CreateFillTask>d__307 <CreateFillTask>d__;
			<CreateFillTask>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<CreateFillTask>d__.<>4__this = this;
			<CreateFillTask>d__.srcMachine = srcMachine;
			<CreateFillTask>d__.dstMachine = dstMachine;
			<CreateFillTask>d__.<>1__state = -1;
			<CreateFillTask>d__.<>t__builder.Start<PCmoverEngineLive.<CreateFillTask>d__307>(ref <CreateFillTask>d__);
			return <CreateFillTask>d__.<>t__builder.Task;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000054B4 File Offset: 0x000036B4
		public Task PrepareCustomizationAsync()
		{
			PCmoverEngineLive.<PrepareCustomizationAsync>d__310 <PrepareCustomizationAsync>d__;
			<PrepareCustomizationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PrepareCustomizationAsync>d__.<>4__this = this;
			<PrepareCustomizationAsync>d__.<>1__state = -1;
			<PrepareCustomizationAsync>d__.<>t__builder.Start<PCmoverEngineLive.<PrepareCustomizationAsync>d__310>(ref <PrepareCustomizationAsync>d__);
			return <PrepareCustomizationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000054F8 File Offset: 0x000036F8
		private Task RunCustomizationTask()
		{
			PCmoverEngineLive.<RunCustomizationTask>d__311 <RunCustomizationTask>d__;
			<RunCustomizationTask>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RunCustomizationTask>d__.<>4__this = this;
			<RunCustomizationTask>d__.<>1__state = -1;
			<RunCustomizationTask>d__.<>t__builder.Start<PCmoverEngineLive.<RunCustomizationTask>d__311>(ref <RunCustomizationTask>d__);
			return <RunCustomizationTask>d__.<>t__builder.Task;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000553C File Offset: 0x0000373C
		public Task CancelPrepareCustomizationAsync()
		{
			PCmoverEngineLive.<CancelPrepareCustomizationAsync>d__312 <CancelPrepareCustomizationAsync>d__;
			<CancelPrepareCustomizationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CancelPrepareCustomizationAsync>d__.<>4__this = this;
			<CancelPrepareCustomizationAsync>d__.<>1__state = -1;
			<CancelPrepareCustomizationAsync>d__.<>t__builder.Start<PCmoverEngineLive.<CancelPrepareCustomizationAsync>d__312>(ref <CancelPrepareCustomizationAsync>d__);
			return <CancelPrepareCustomizationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005580 File Offset: 0x00003780
		private Task ExpandSnapshotAsync()
		{
			PCmoverEngineLive.<ExpandSnapshotAsync>d__313 <ExpandSnapshotAsync>d__;
			<ExpandSnapshotAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ExpandSnapshotAsync>d__.<>4__this = this;
			<ExpandSnapshotAsync>d__.<>1__state = -1;
			<ExpandSnapshotAsync>d__.<>t__builder.Start<PCmoverEngineLive.<ExpandSnapshotAsync>d__313>(ref <ExpandSnapshotAsync>d__);
			return <ExpandSnapshotAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000055C4 File Offset: 0x000037C4
		internal Task SetupFillTask()
		{
			PCmoverEngineLive.<SetupFillTask>d__314 <SetupFillTask>d__;
			<SetupFillTask>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SetupFillTask>d__.<>4__this = this;
			<SetupFillTask>d__.<>1__state = -1;
			<SetupFillTask>d__.<>t__builder.Start<PCmoverEngineLive.<SetupFillTask>d__314>(ref <SetupFillTask>d__);
			return <SetupFillTask>d__.<>t__builder.Task;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005607 File Offset: 0x00003807
		public void RetrieveMiscSettings()
		{
			this.MiscSettingsData = this.ControlInterface.TaskGetMiscSettings(this._customizeTaskHandle, CultureInfo.CurrentUICulture.Name);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000562A File Offset: 0x0000382A
		public CustomizationData ChangeMiscSetting(MiscSettingData miscSetting)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			return this.ControlInterface.TaskChangeMiscSetting(this._customizeTaskHandle, miscSetting);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005648 File Offset: 0x00003848
		public void RetrieveDrives()
		{
			this.Drives = this.ControlInterface.TaskGetDriveData(this._customizeTaskHandle);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00005661 File Offset: 0x00003861
		public CustomizationData ChangeDriveMapping(DrivePair drivePair)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			return this.ControlInterface.TaskChangeDriveMapping(this._customizeTaskHandle, drivePair);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000567F File Offset: 0x0000387F
		private string NameForLogging(UserDetail user)
		{
			if (user == null)
			{
				return "null";
			}
			return user.AccountName + " (" + user.FriendlyName + ")";
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000056A8 File Offset: 0x000038A8
		public void RetrieveUsers()
		{
			this.Users = this.TaskGetUserMappings(this._customizeTaskHandle, true);
			if (this.Users != null)
			{
				if (this._srcMachineHandle == 0 || this._dstMachineHandle == 0)
				{
					PcmTaskData taskData = this.ControlInterface.GetTaskData(this._customizeTaskHandle);
					if (taskData != null)
					{
						this._srcMachineHandle = taskData.SourceMachineHandle;
						this._dstMachineHandle = taskData.DestMachineHandle;
					}
				}
				if (this.Users.Mappings != null)
				{
					base.Ts.TraceVerbose(string.Format("{0} user mappings:", this.Users.Mappings.Count<UserMapping>()));
					foreach (UserMapping userMapping in this.Users.Mappings)
					{
						if (userMapping.Old != null)
						{
							base.Ts.TraceVerbose(this.NameForLogging(userMapping.Old) + " => " + this.NameForLogging(userMapping.New));
						}
					}
				}
				if (this.Users.UnusedOnNew != null)
				{
					int num = this.Users.UnusedOnNew.Count<UserDetail>();
					if (num > 0)
					{
						base.Ts.TraceVerbose(string.Format("{0} unused on new", num));
						foreach (UserDetail user in this.Users.UnusedOnNew)
						{
							base.Ts.TraceVerbose(this.NameForLogging(user));
						}
					}
				}
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00005850 File Offset: 0x00003A50
		public UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly)
		{
			return this.ControlInterface.TaskGetUserMappings(taskHandle, regularUsersOnly);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000585F File Offset: 0x00003A5F
		public CustomizationData ChangeUserMapping(UserMapping userMapping)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			return this.ControlInterface.TaskChangeUserMapping(this._customizeTaskHandle, userMapping);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000587D File Offset: 0x00003A7D
		public TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace)
		{
			return this.ControlInterface.TaskGetStats(taskHandle, includeDriveSpace);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000588C File Offset: 0x00003A8C
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			return this.ControlInterface.GetTaskSummaryData(taskHandle, regularUsersOnly);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000589B File Offset: 0x00003A9B
		public void SendCallbackReply(int replyHandle, int reply)
		{
			this.ControlInterface.SendCallbackReply(replyHandle, reply);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000058AA File Offset: 0x00003AAA
		public CustomizationData SetUserPassword(string accountName, string password)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			return this.ControlInterface.TaskSetUserPassword(this._customizeTaskHandle, new UserDetail
			{
				AccountName = accountName
			}, password);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000058D4 File Offset: 0x00003AD4
		public void RetrieveFileFilters()
		{
			this.FileFilters = null;
			IEnumerable<ItemFilterData> enumerable = this.ControlInterface.TaskGetItemFilters(this._customizeTaskHandle, ItemType.Disk);
			if (enumerable == null)
			{
				return;
			}
			this.FileFilters = new List<FileFilter>();
			foreach (ItemFilterData itemFilterData in enumerable)
			{
				this.FileFilters.Add(new FileFilter(itemFilterData.SourceMask, itemFilterData.Transfer, itemFilterData.Target));
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005960 File Offset: 0x00003B60
		private ItemFilterData CreateItemFilterData(FileFilter filter)
		{
			return new ItemFilterData
			{
				SourceMask = filter.filter,
				Target = filter.target,
				Transfer = filter.transfer
			};
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000598B File Offset: 0x00003B8B
		public CustomizationData ChangeFileFilter(int index, FileFilter filter)
		{
			return this.ControlInterface.TaskChangeItemFilter(this._customizeTaskHandle, ItemType.Disk, index, this.CreateItemFilterData(filter));
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000059A7 File Offset: 0x00003BA7
		public CustomizationData AddFileFilter(FileFilter filter)
		{
			return this.ControlInterface.TaskChangeItemFilter(this._customizeTaskHandle, ItemType.Disk, -1, this.CreateItemFilterData(filter));
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000059C3 File Offset: 0x00003BC3
		public CustomizationData DeleteFileFilter(int index)
		{
			return this.ControlInterface.TaskChangeItemFilter(this._customizeTaskHandle, ItemType.Disk, index, null);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000059D9 File Offset: 0x00003BD9
		public CustomizationData SwapFileFilters(int index1, int index2)
		{
			return this.ControlInterface.TaskSwapItemFilters(this._customizeTaskHandle, ItemType.Disk, index1, index2);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000059F0 File Offset: 0x00003BF0
		public TransferrableContainerData GetFolderData(string path, bool withinBranch, bool onlyRoot)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			RequestedPage requestedPage = new RequestedPage(onlyRoot ? 0 : 100);
			List<TransferrableContainerInfo> list = new List<TransferrableContainerInfo>();
			List<TransferrableItemDefinition> list2 = new List<TransferrableItemDefinition>();
			TransferrableContainerData transferrableContainerData = new TransferrableContainerData
			{
				Containers = list,
				Items = list2
			};
			for (;;)
			{
				TransferrableContainerData transferrableContainerData2 = this.ControlInterface.TaskGetTransferrableContainerData(this._customizeTaskHandle, ItemType.Disk, path, withinBranch, CountDetail.All, true, true, requestedPage);
				if (transferrableContainerData2 == null)
				{
					break;
				}
				if (requestedPage.StartIndex == 0)
				{
					transferrableContainerData.FullPath = transferrableContainerData2.FullPath;
					transferrableContainerData.NumContainers = transferrableContainerData2.NumContainers;
					transferrableContainerData.NumItems = transferrableContainerData2.NumItems;
					transferrableContainerData.Target = transferrableContainerData2.Target;
					transferrableContainerData.Transferrable = transferrableContainerData2.Transferrable;
				}
				foreach (TransferrableContainerInfo transferrableContainerInfo in transferrableContainerData2.Containers)
				{
					if (transferrableContainerInfo.NumItems > 0UL)
					{
						list.Add(transferrableContainerInfo);
					}
				}
				list2.AddRange(transferrableContainerData2.Items);
				if (requestedPage.MaxCount == 0 || transferrableContainerData2.Containers.Count<TransferrableContainerInfo>() + transferrableContainerData2.Items.Count<TransferrableItemDefinition>() < requestedPage.MaxCount)
				{
					break;
				}
				requestedPage.NextPage();
			}
			base.Ts.TraceCaller(TraceEventType.Verbose, string.Format("{0} Within: {1}", path, withinBranch), "GetFolderData");
			return transferrableContainerData;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005B58 File Offset: 0x00003D58
		private List<CategoryDefinition> FindCloudCategories(MachineData machine)
		{
			CategoryParameters categoryParameters = new CategoryParameters
			{
				Type = ItemType.Disk,
				RegularUsersOnly = true,
				IncludeCounts = false
			};
			RequestedPage requestedPage = new RequestedPage(50);
			List<CategoryDefinition> list = null;
			for (;;)
			{
				IEnumerable<CategoryDefinition> enumerable;
				try
				{
					enumerable = this.ControlInterface.MachineGetCategories(base.ThisMachine.Handle, categoryParameters, requestedPage);
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "FindCloudCategories");
					list = null;
					break;
				}
				if (enumerable == null)
				{
					break;
				}
				if (list == null)
				{
					list = enumerable.ToList<CategoryDefinition>();
				}
				else
				{
					list.AddRange(enumerable);
				}
				if (list.Count < requestedPage.ExpectedEnd)
				{
					break;
				}
				requestedPage.NextPage();
			}
			if (list == null)
			{
				return null;
			}
			base.Ts.TraceInformation(string.Format("Received {0} categories", list.Count));
			return this.FindCloudCategories(list);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005C28 File Offset: 0x00003E28
		private List<CategoryDefinition> FindCloudCategories(List<CategoryDefinition> categories)
		{
			List<CategoryDefinition> list = new List<CategoryDefinition>();
			foreach (CategoryDefinition categoryDefinition in categories)
			{
				if (this.GetGroupType(categoryDefinition.Name) != PCmoverEngineLive.GroupType.Other && categoryDefinition.IsCloud)
				{
					list.Add(categoryDefinition);
				}
			}
			return list;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005C94 File Offset: 0x00003E94
		public bool RetrieveDiskData()
		{
			CategoryParameters categoryParameters = new CategoryParameters
			{
				Type = ItemType.Disk,
				RegularUsersOnly = true,
				IncludeCounts = true,
				AllAppsOnly = true
			};
			RequestedPage requestedPage = new RequestedPage(50);
			List<TransferrableCategoryDefinition> list = null;
			for (;;)
			{
				IEnumerable<TransferrableCategoryDefinition> enumerable;
				try
				{
					enumerable = this.ControlInterface.TaskGetCategories(this._fillTaskHandle, categoryParameters, requestedPage);
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "RetrieveDiskData");
					list = null;
					break;
				}
				if (enumerable == null)
				{
					break;
				}
				if (list == null)
				{
					list = enumerable.ToList<TransferrableCategoryDefinition>();
				}
				else
				{
					list.AddRange(enumerable);
				}
				if (list.Count < requestedPage.ExpectedEnd)
				{
					break;
				}
				requestedPage.NextPage();
			}
			this.DiskCategories = list;
			if (this.DiskCategories == null)
			{
				return false;
			}
			base.Ts.TraceCaller(string.Format("Received {0} categories", list.Count), "RetrieveDiskData");
			return this.CreateFolderList();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005D74 File Offset: 0x00003F74
		private bool CreateFolderList()
		{
			bool result;
			try
			{
				this._groups = new Dictionary<PCmoverEngineLive.GroupType, GroupInfo>
				{
					{
						PCmoverEngineLive.GroupType.Documents,
						new GroupInfo("Documents", this, false)
					},
					{
						PCmoverEngineLive.GroupType.Pictures,
						new GroupInfo("Pictures", this, false)
					},
					{
						PCmoverEngineLive.GroupType.Music,
						new GroupInfo("Music", this, false)
					},
					{
						PCmoverEngineLive.GroupType.Video,
						new GroupInfo("Video", this, false)
					},
					{
						PCmoverEngineLive.GroupType.Other,
						new GroupInfo("Other", this, false)
					},
					{
						PCmoverEngineLive.GroupType.None,
						new GroupInfo("None", this, false)
					}
				};
				foreach (TransferrableCategoryDefinition transferrableCategoryDefinition in this.DiskCategories)
				{
					PCmoverEngineLive.GroupType groupType = this.GetGroupType(transferrableCategoryDefinition.Name);
					bool canRedirect = true;
					if (groupType == PCmoverEngineLive.GroupType.Other && transferrableCategoryDefinition.FullPath.Length > 3)
					{
						canRedirect = false;
					}
					this._groups[groupType].AddCategory(transferrableCategoryDefinition, canRedirect);
				}
				result = true;
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CreateFolderList");
				result = false;
			}
			return result;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005E9C File Offset: 0x0000409C
		private PCmoverEngineLive.GroupType GetGroupType(string name)
		{
			if (name == "Personal" || name == "Common Documents")
			{
				return PCmoverEngineLive.GroupType.Documents;
			}
			if (name == "My Music" || name == "CommonMusic")
			{
				return PCmoverEngineLive.GroupType.Music;
			}
			if (name == "My Pictures" || name == "CommonPictures")
			{
				return PCmoverEngineLive.GroupType.Pictures;
			}
			if (name == "My Video" || name == "CommonVideo")
			{
				return PCmoverEngineLive.GroupType.Video;
			}
			if (name == "{F42EE2D3-909F-4907-8871-4C22FC0BF756}" || name == "{A0C69A99-21C8-4671-8703-7934162FCF1D}" || name == "{0DDD015D-B06C-45D5-8C4C-F59713854639}" || name == "{35286A68-3C57-41A1-BBB1-0EAE73d76C95}" || name == "{7D83EE9B-2244-4E70-B1F5-5393042AF1E4}")
			{
				return PCmoverEngineLive.GroupType.None;
			}
			return PCmoverEngineLive.GroupType.Other;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005F60 File Offset: 0x00004160
		public CustomizationData ChangeDiskData(string path, string fileName, bool isFolder, bool? userSelected, string target)
		{
			if (userSelected == null && string.IsNullOrEmpty(target))
			{
				return this.ControlInterface.TaskRemoveRedirection(this._customizeTaskHandle, ItemType.Disk, path, fileName, isFolder, true);
			}
			base.Ts.TraceInformation(string.Format("ChangeContainerData {0} Selected: {1}", fileName, userSelected));
			return this.ControlInterface.TaskChangeContainerData(this._customizeTaskHandle, ItemType.Disk, path, fileName, isFolder, userSelected, target, true);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005FD0 File Offset: 0x000041D0
		public ActivityClient StartCreateImageMachine(ImageMapData imageMachineData)
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.GetSnapshot);
			if (activityClient == null)
			{
				base.Ts.TraceCaller("Set ThisMachineIsOld = false", "StartCreateImageMachine");
				this.ThisMachineIsOld = false;
				GetImageSnapshotActivityClient getImageSnapshotActivityClient = new GetImageSnapshotActivityClient(this);
				activityClient = getImageSnapshotActivityClient;
				if (base.IsResuming)
				{
					TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.Image);
					if (transferMethodData == null)
					{
						base.Ts.TraceCaller("Cannot find image transfer method", "StartCreateImageMachine");
						return null;
					}
					this.ImageTransferMethodHandle = transferMethodData.Handle;
				}
				else
				{
					this.ImageTransferMethodHandle = getImageSnapshotActivityClient.GetImageTransferMethodHandle(imageMachineData, this.ImageTransferMethodHandle);
				}
				getImageSnapshotActivityClient.Start(this.ImageTransferMethodHandle);
			}
			return activityClient;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006074 File Offset: 0x00004274
		public ActivityClient StartCreateWinUpgradeMachine(string windowsOld)
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.GetSnapshot);
			if (activityClient == null)
			{
				base.Ts.TraceCaller("Set ThisMachineIsOld = false", "StartCreateWinUpgradeMachine");
				this.ThisMachineIsOld = false;
				GetImageSnapshotActivityClient getImageSnapshotActivityClient = new GetImageSnapshotActivityClient(this);
				activityClient = getImageSnapshotActivityClient;
				this._winUpgradeTransferMethodHandle = getImageSnapshotActivityClient.GetWinUpgradeTransferMethodHandle(windowsOld, this._winUpgradeTransferMethodHandle);
				getImageSnapshotActivityClient.Start(this._winUpgradeTransferMethodHandle);
				this.StopResumingIfNoFillTask("StartCreateWinUpgradeMachine");
			}
			return activityClient;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000060E1 File Offset: 0x000042E1
		public void StopResumingIfNoFillTask([CallerMemberName] string caller = "")
		{
			if (base.IsResuming && base.ServiceData.GetTask(PcmTaskType.Fill) == null)
			{
				base.Ts.TraceCaller("StopResumingIfNoFillTask", caller);
				base.IsResuming = false;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00006114 File Offset: 0x00004314
		public ActivityClient StartCreateAnyMachine()
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.GetSnapshot);
			if (activityClient == null)
			{
				base.Ts.TraceCaller("Set ThisMachineIsOld = true", "StartCreateAnyMachine");
				this.ThisMachineIsOld = true;
				GetSnapshotActivityClient getSnapshotActivityClient = new GetSnapshotActivityClient(this);
				activityClient = getSnapshotActivityClient;
				if (base.IsResuming)
				{
					TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.File);
					if (transferMethodData == null)
					{
						base.Ts.TraceCaller("Cannot find file transfer method", "StartCreateAnyMachine");
						return null;
					}
					this._fileAnyTransferMethodHandle = transferMethodData.Handle;
				}
				else
				{
					this._fileAnyTransferMethodHandle = getSnapshotActivityClient.GetFileAnyTransferMethodHandle(this._fileAnyTransferMethodHandle);
				}
				getSnapshotActivityClient.Start(this._fileAnyTransferMethodHandle);
				this.StopResumingIfNoFillTask("StartCreateAnyMachine");
			}
			return activityClient;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000061C4 File Offset: 0x000043C4
		public bool AddSelf()
		{
			if (base.ActivityClients.FindByActivityType(ActivityType.GetSnapshot) != null)
			{
				return false;
			}
			if (this.OtherMachine != null)
			{
				if (this.OtherMachine.Handle != base.ThisMachine.Handle)
				{
					return false;
				}
			}
			else
			{
				if (this._selfTransferMethodHandle == 0)
				{
					if (base.IsResuming)
					{
						TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.Image);
						if (transferMethodData == null)
						{
							base.Ts.TraceCaller("Cannot find self transfer method", "AddSelf");
							return false;
						}
						this._selfTransferMethodHandle = transferMethodData.Handle;
					}
					else
					{
						this._selfTransferMethodHandle = this.ControlInterface.CreateTransferMethod(TransferMethodType.Image);
					}
				}
				this.OtherMachine = base.ThisMachine;
				this._otherMachineTransferMethodHandle = this._selfTransferMethodHandle;
				this._otherMachineReady = true;
				this.ThisMachineAppInventoryRequirement = AppInventoryAmount.Minimum;
			}
			this.StopResumingIfNoFillTask("AddSelf");
			Task.Run(() => this.SetupFillTask());
			return true;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000062A4 File Offset: 0x000044A4
		private int GetFileTransferMethodHandle(string fileName, ulong? spanSize = null, bool? canSpan = null, bool? notifySpan = null)
		{
			if (!base.IsResuming)
			{
				int num = this.ControlInterface.CreateTransferMethod(TransferMethodType.File);
				if (num != 0)
				{
					FileTransferMethodInfo fileTransferMethodInfo = this.ControlInterface.GetFileTransferMethodInfo(num);
					bool flag = false;
					if (fileName != null && fileTransferMethodInfo.FileName != fileName)
					{
						fileTransferMethodInfo.FileName = fileName;
						flag = true;
					}
					if (spanSize != null)
					{
						ulong spanSize2 = fileTransferMethodInfo.SpanSize;
						ulong? num2 = spanSize;
						if (!(spanSize2 == num2.GetValueOrDefault() & num2 != null))
						{
							fileTransferMethodInfo.SpanSize = spanSize.Value;
							flag = true;
						}
					}
					if (canSpan != null)
					{
						bool canSpan2 = fileTransferMethodInfo.CanSpan;
						bool? flag2 = canSpan;
						if (!(canSpan2 == flag2.GetValueOrDefault() & flag2 != null))
						{
							fileTransferMethodInfo.CanSpan = canSpan.Value;
							flag = true;
						}
					}
					if (notifySpan != null)
					{
						bool notifySpan2 = fileTransferMethodInfo.NotifySpan;
						bool? flag2 = notifySpan;
						if (!(notifySpan2 == flag2.GetValueOrDefault() & flag2 != null))
						{
							fileTransferMethodInfo.NotifySpan = notifySpan.Value;
							flag = true;
						}
					}
					if (this.CloudToken != null && fileTransferMethodInfo.CloudToken != this.CloudToken)
					{
						fileTransferMethodInfo.CloudToken = this.CloudToken;
						flag = true;
					}
					if (flag)
					{
						this.ControlInterface.SetFileTransferMethodInfo(num, fileTransferMethodInfo);
					}
				}
				return num;
			}
			TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.File);
			if (transferMethodData == null)
			{
				base.Ts.TraceCaller("Cannot find file transfer method", "GetFileTransferMethodHandle");
				return 0;
			}
			return transferMethodData.Handle;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00006400 File Offset: 0x00004600
		public ActivityClient StartSaveMovingVan(string fileName, ulong? spanSize, bool? canSpan, bool? notifySpan)
		{
			ActivityClient activityClient = base.ActivityClients.FindByActivityType(ActivityType.SaveMovingVan);
			if (activityClient == null)
			{
				if (this._fillTaskHandle == 0)
				{
					base.Ts.TraceCaller("No Fill task handle", "StartSaveMovingVan");
					return null;
				}
				if (this.FileTransferMethodHandle == 0)
				{
					this.FileTransferMethodHandle = this.GetFileTransferMethodHandle(fileName, spanSize, canSpan, notifySpan);
					if (this.FileTransferMethodHandle == 0)
					{
						return null;
					}
				}
				this.DeleteTask(ref this._transferTaskHandle);
				activityClient = new TransferActivityClient(this);
				if (base.IsResuming)
				{
					activityClient.Resume(ActivityType.SaveMovingVan);
				}
				else
				{
					activityClient.Start(this.ControlInterface.CreateSaveMovingVanActivity(this.FileTransferMethodHandle, this._fillTaskHandle));
				}
			}
			return activityClient;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000064A4 File Offset: 0x000046A4
		internal bool CheckControllerProperty(string prop)
		{
			return this.GetControllerProperty(prop) != null;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000064B0 File Offset: 0x000046B0
		internal void SetControllerDateProperty(string prop)
		{
			this.SetControllerProperty(prop, PcmoverProperties.NowValue);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000064BE File Offset: 0x000046BE
		public void SetControllerProperty(string property, string value)
		{
			this.ControlInterface.SetControllerProperty(property, value);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000064CD File Offset: 0x000046CD
		public string GetControllerProperty(string property)
		{
			return this.ControlInterface.GetControllerProperty(property);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000064DB File Offset: 0x000046DB
		public void SetPublicProperty(string property, string value)
		{
			this.ControlInterface.SetPublicProperty(property, value);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000064EA File Offset: 0x000046EA
		public string GetPublicProperty(string property)
		{
			return this.ControlInterface.GetPublicProperty(property);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000064F8 File Offset: 0x000046F8
		public void GenerateTransferReports()
		{
			if (this.CheckControllerProperty(ControllerProperties.GenerateTransferReports))
			{
				return;
			}
			this.Container.Resolve(Array.Empty<ResolverOverride>()).GenerateReports(this._transferTaskHandle);
			this.SetControllerDateProperty(ControllerProperties.GenerateTransferReports);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000652E File Offset: 0x0000472E
		public void SetEngineLogData(EngineLogData data)
		{
			this.ControlInterface.SetEngineLogData(data);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000653C File Offset: 0x0000473C
		public EngineLogData GetEngineLogData()
		{
			return this.ControlInterface.GetEngineLogData();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000654C File Offset: 0x0000474C
		private bool AnyCleanupActivities()
		{
			ActivityClients activityClients = base.ActivityClients;
			bool result;
			lock (activityClients)
			{
				result = base.ActivityClients.Any((ActivityClient client) => this.StopInCleanup(client));
			}
			return result;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000065A0 File Offset: 0x000047A0
		internal void DeleteOtherMachine()
		{
			if (this._otherMachineReady && this.OtherMachine != null)
			{
				this._otherMachineReady = false;
				int handle = this.OtherMachine.Handle;
				if (base.ThisMachine == null || handle != base.ThisMachine.Handle)
				{
					this.DeleteMachine(ref handle);
				}
				this.OtherMachine = null;
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000065F5 File Offset: 0x000047F5
		private bool StopInCleanup(ActivityClient client)
		{
			return client.Type != ActivityType.Discovery && (client.Type != ActivityType.AppInventory || !(client is ThisMachineAppInvActivityClient));
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00006618 File Offset: 0x00004818
		public Task<bool> CleanupAsync(uint timeout)
		{
			PCmoverEngineLive.<CleanupAsync>d__360 <CleanupAsync>d__;
			<CleanupAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<CleanupAsync>d__.<>4__this = this;
			<CleanupAsync>d__.timeout = timeout;
			<CleanupAsync>d__.<>1__state = -1;
			<CleanupAsync>d__.<>t__builder.Start<PCmoverEngineLive.<CleanupAsync>d__360>(ref <CleanupAsync>d__);
			return <CleanupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00006663 File Offset: 0x00004863
		public IEnumerable<string> GetRedistributables()
		{
			if (this._transferTaskHandle == 0)
			{
				return null;
			}
			return this.ControlInterface.TaskGetRedistPackages(this._transferTaskHandle);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006680 File Offset: 0x00004880
		public bool UploadApplicationReport()
		{
			if (this._transferTaskHandle == 0)
			{
				return false;
			}
			if (this.CheckControllerProperty(ControllerProperties.UploadApplicationReport))
			{
				return true;
			}
			bool result = this.ControlInterface.TaskUploadApplicationReport(this._transferTaskHandle);
			this.SetControllerDateProperty(ControllerProperties.UploadApplicationReport);
			return result;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000066B8 File Offset: 0x000048B8
		public FinishTransferData PerformPostTransferActions(bool dlmgrReboot)
		{
			if (this._transferTaskHandle == 0)
			{
				return new FinishTransferData
				{
					Succeeded = false,
					FailureReason = "No transfer task"
				};
			}
			if (this.CheckControllerProperty(ControllerProperties.PerformPostTransferActions))
			{
				return new FinishTransferData
				{
					LaunchExe = PcmoverProperties.GetBool(this.GetControllerProperty(ControllerProperties.PTA_LaunchExe), false),
					Arguments = this.GetControllerProperty(ControllerProperties.PTA_Arguments)
				};
			}
			FinishTransferData finishTransferData = this.ControlInterface.TaskPerformPostTransferActions(this._transferTaskHandle, dlmgrReboot);
			if (finishTransferData != null)
			{
				this.SetControllerProperty(ControllerProperties.PTA_LaunchExe, PcmoverProperties.TrueFalseValue(finishTransferData.LaunchExe));
				this.SetControllerProperty(ControllerProperties.PTA_Arguments, finishTransferData.Arguments);
			}
			this.SetControllerDateProperty(ControllerProperties.PerformPostTransferActions);
			return finishTransferData;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006769 File Offset: 0x00004969
		public bool Reboot(uint delay)
		{
			this.DisableCallbacks();
			this.IsRebooting = true;
			this.ControlInterface.Reboot(delay);
			this.StopConnectionMonitor();
			this.ClosePcmoverConnection();
			this.ResetState();
			return true;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006798 File Offset: 0x00004998
		public IEnumerable<DriveSpaceAndNeeded> DetermineInsufficientDiskSpace(IEnumerable<DriveSpaceRequired> requiredList)
		{
			List<DriveSpaceAndNeeded> list = new List<DriveSpaceAndNeeded>();
			ulong num = (ulong)Math.Pow(1024.0, 3.0) * 10UL;
			using (IEnumerator<DriveSpaceRequired> enumerator = requiredList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DriveSpaceRequired required = enumerator.Current;
					DriveSpaceData driveSpaceData = this.ThisMachineDriveSpace.FirstOrDefault((DriveSpaceData d) => string.Compare(d.Drive, required.Drive, true) == 0);
					if (driveSpaceData != null)
					{
						ulong num2 = required.Required + num;
						if (required.Required > 0UL && num2 > driveSpaceData.FreeBytes)
						{
							list.Add(new DriveSpaceAndNeeded
							{
								Drive = required.Drive,
								Required = required.Required,
								Available = driveSpaceData.FreeBytes
							});
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006890 File Offset: 0x00004A90
		public bool SetVanPassword(string password)
		{
			return this.ControlInterface.TaskSetVanPassword(this._customizeTaskHandle, password);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000068A4 File Offset: 0x00004AA4
		public int CreateNetworkTransferMethod(string networkTarget)
		{
			if (base.IsResuming)
			{
				TransferMethodData networkTransferMethodData = base.ServiceData.GetNetworkTransferMethodData(networkTarget);
				int num = (networkTransferMethodData == null) ? 0 : networkTransferMethodData.Handle;
				base.Ts.TraceCaller(string.Format("Resuming {0} using {1}", networkTarget, num), "CreateNetworkTransferMethod");
				return num;
			}
			base.Ts.TraceCaller(networkTarget, "CreateNetworkTransferMethod");
			return this.ControlInterface.CreateTransferMethod(TransferMethodType.Network);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00006914 File Offset: 0x00004B14
		public int CreateTransferMethod(TransferMethodType tm, string networkTarget)
		{
			string arg = networkTarget ?? "no networkTarget";
			if (base.IsResuming)
			{
				TransferMethodData transferMethodData;
				if (tm == TransferMethodType.Network || tm == TransferMethodType.SSL)
				{
					transferMethodData = base.ServiceData.GetNetworkTransferMethodData(tm, networkTarget);
				}
				else
				{
					transferMethodData = base.ServiceData.GetTransferMethodData(tm);
				}
				int num = (transferMethodData == null) ? 0 : transferMethodData.Handle;
				base.Ts.TraceCaller(string.Format("Resuming {0} to {1} using {2}", tm, arg, num), "CreateTransferMethod");
				return num;
			}
			base.Ts.TraceCaller(string.Format("{0} {1}", tm, arg), "CreateTransferMethod");
			return this.ControlInterface.CreateTransferMethod(tm);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000069C0 File Offset: 0x00004BC0
		public int CreateTransferMethod(TransferMethodType tm)
		{
			if (base.IsResuming)
			{
				TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(tm);
				int num = (transferMethodData == null) ? 0 : transferMethodData.Handle;
				base.Ts.TraceCaller(string.Format("Resuming {0} using {1}", tm, num), "CreateTransferMethod");
				return num;
			}
			base.Ts.TraceCaller(tm.ToString(), "CreateTransferMethod");
			return this.ControlInterface.CreateTransferMethod(tm);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00006A40 File Offset: 0x00004C40
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			return this.ControlInterface.GetTransferMethodData(transferMethodHandle);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006A4E File Offset: 0x00004C4E
		public bool DeleteTransferMethod(int transferMethodHandle)
		{
			return this.ControlInterface.DeleteTransferMethod(transferMethodHandle);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006A5C File Offset: 0x00004C5C
		public bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info)
		{
			return this.ControlInterface.SetNetworkTransferMethodInfo(networkTransferMethodHandle, info);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006A6B File Offset: 0x00004C6B
		public SslInfo GetSslInfo()
		{
			if (this.TargetMachine == null || (this.TargetMachine.Method != TransferMethodType.Network && this.TargetMachine.Method != TransferMethodType.Usb))
			{
				return null;
			}
			return this.ControlInterface.GetSslInfo(this.TargetMachine.TransferMethodHandle);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006AAB File Offset: 0x00004CAB
		public SslInfo GetLocalSslInfo()
		{
			return this.ControlInterface.GetLocalSslInfo();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006AB8 File Offset: 0x00004CB8
		public bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData)
		{
			return this.ControlInterface.SetImageTransferMethodInfo(imageTransferMethodHandle, imageMapData);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00006AC7 File Offset: 0x00004CC7
		public bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info)
		{
			return this.ControlInterface.SetFileTransferMethodInfo(fileTransferMethodHandle, info);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00006AD6 File Offset: 0x00004CD6
		public FileTransferMethodInfo GetFileTransferMethodInfo()
		{
			return this.ControlInterface.GetFileTransferMethodInfo(this.FileTransferMethodHandle);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006AE9 File Offset: 0x00004CE9
		public ImageMapData GetImageTransferMethodInfo()
		{
			return this.ControlInterface.GetImageTransferMethodInfo(this.ImageTransferMethodHandle);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00006AFC File Offset: 0x00004CFC
		public bool RefreshNetworkAdapters()
		{
			return this.ControlInterface.RefreshNetworkAdapters();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00006B09 File Offset: 0x00004D09
		public uint GetValidNetworkAdapterCount()
		{
			return this.ControlInterface.GetValidNetworkAdapterCount();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00006B16 File Offset: 0x00004D16
		public bool SetProxyAuth(string proxy, string username, string password)
		{
			return this.ControlInterface.SetProxyAuth(proxy, username, password);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00006B28 File Offset: 0x00004D28
		public bool SendAlerts(TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, TransferProcessResult status)
		{
			if (alertType == TaskAlertData.AlertType.Done && this.CheckControllerProperty(ControllerProperties.SendDoneAlerts))
			{
				return true;
			}
			string statusMessage;
			try
			{
				statusMessage = ClientEngineModule.Infrastructure.Properties.Resources.ResourceManager.GetString("Alert_" + status.ToString());
			}
			catch (Exception ex)
			{
				base.Ts.TraceCaller(string.Format("Error getting Alert status ({0}): {1}", status, ex.Message), "SendAlerts");
				statusMessage = status.ToString();
			}
			this.ControlInterface.TaskPostAlerts(this._transferTaskHandle, alertType, interactiveAlert, statusMessage);
			base.Ts.TraceInformation(string.Format("{0} alerts posted", alertType));
			if (alertType == TaskAlertData.AlertType.Done)
			{
				this.SetControllerDateProperty(ControllerProperties.SendDoneAlerts);
			}
			return true;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00006BF4 File Offset: 0x00004DF4
		public MachineDriveInfo GetMachineDriveInfo()
		{
			return this.ControlInterface.MachineGetDriveInfo(base.ThisMachine.Handle);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00006C0C File Offset: 0x00004E0C
		public bool MarkUserDeferredComplete(string userName, string userSid)
		{
			return this.ControlInterface.MarkUserDeferredComplete(userName, userSid);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00006C1C File Offset: 0x00004E1C
		internal Task<MessageBoxResult> DisplayEarlierVersionMessageAsync(string formatString, WindowsVersionData srcWindowsVersion, WindowsVersionData destWindowsVersion)
		{
			PCmoverEngineLive.<DisplayEarlierVersionMessageAsync>d__385 <DisplayEarlierVersionMessageAsync>d__;
			<DisplayEarlierVersionMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder<MessageBoxResult>.Create();
			<DisplayEarlierVersionMessageAsync>d__.<>4__this = this;
			<DisplayEarlierVersionMessageAsync>d__.formatString = formatString;
			<DisplayEarlierVersionMessageAsync>d__.srcWindowsVersion = srcWindowsVersion;
			<DisplayEarlierVersionMessageAsync>d__.destWindowsVersion = destWindowsVersion;
			<DisplayEarlierVersionMessageAsync>d__.<>1__state = -1;
			<DisplayEarlierVersionMessageAsync>d__.<>t__builder.Start<PCmoverEngineLive.<DisplayEarlierVersionMessageAsync>d__385>(ref <DisplayEarlierVersionMessageAsync>d__);
			return <DisplayEarlierVersionMessageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00006C78 File Offset: 0x00004E78
		internal string LookupMessage(UiCallbackCode code, string param, string defaultMsg)
		{
			string resourceString = this.GetResourceString(code.ToString());
			if (!string.IsNullOrEmpty(resourceString))
			{
				return string.Format(resourceString, param);
			}
			return defaultMsg;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00006CAC File Offset: 0x00004EAC
		internal string GetResourceString(string Id)
		{
			string @string = PcmBrandUI.Properties.Resources.ResourceManager.GetString(Id);
			if (string.IsNullOrEmpty(@string))
			{
				@string = ClientEngineModule.Infrastructure.Properties.Resources.ResourceManager.GetString(Id);
			}
			return @string;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00006CDA File Offset: 0x00004EDA
		public bool SetAuthorizationData(AuthorizationRequestData authRequest)
		{
			return this.ControlInterface.SetAuthorizationData(authRequest);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00006CE8 File Offset: 0x00004EE8
		public override void FireActivityInfoEvent(ActivityInfo info)
		{
			this.EventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Publish(info);
			base.FireActivityInfoEvent(info);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00006D02 File Offset: 0x00004F02
		MachineData IPCmoverEngine.get_ThisMachine()
		{
			return base.ThisMachine;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00006D0A File Offset: 0x00004F0A
		Task<bool> IPCmoverEngine.CatchCommExAsync(Func<Task> func, string caller)
		{
			return base.CatchCommExAsync(func, caller);
		}

		// Token: 0x04000007 RID: 7
		internal AppInventoryStatus _thisAppInvStatus = new AppInventoryStatus();

		// Token: 0x04000008 RID: 8
		internal AppInventoryStatus _imageAppInvStatus = new AppInventoryStatus();

		// Token: 0x04000009 RID: 9
		private readonly object _thisAppInvLock = new object();

		// Token: 0x0400000A RID: 10
		internal bool _thisAppInvHasCheckedForOffice;

		// Token: 0x0400000B RID: 11
		internal bool _otherMachineReady;

		// Token: 0x0400000C RID: 12
		private IEngineParameters _engineParameters;

		// Token: 0x0400000D RID: 13
		private int _fillTaskHandle;

		// Token: 0x0400000E RID: 14
		internal int _transferTaskHandle;

		// Token: 0x0400000F RID: 15
		private int _srcMachineHandle;

		// Token: 0x04000010 RID: 16
		private int _dstMachineHandle;

		// Token: 0x04000011 RID: 17
		internal IEnumerable<int> _discoveryTransferMethodHandles;

		// Token: 0x04000012 RID: 18
		private int _ftmh;

		// Token: 0x04000013 RID: 19
		internal int _fileAnyTransferMethodHandle;

		// Token: 0x04000014 RID: 20
		internal IEnumerable<int> _listenTransferMethodHandles;

		// Token: 0x04000015 RID: 21
		internal int _itmh;

		// Token: 0x04000016 RID: 22
		internal int _winUpgradeTransferMethodHandle;

		// Token: 0x04000017 RID: 23
		internal int _selfTransferMethodHandle;

		// Token: 0x04000018 RID: 24
		internal int _otherMachineTransferMethodHandle;

		// Token: 0x04000019 RID: 25
		public int _customizeTaskHandle;

		// Token: 0x0400001A RID: 26
		private object _shutdownLock = new object();

		// Token: 0x0400001B RID: 27
		public bool _shuttingDown;

		// Token: 0x0400001C RID: 28
		private bool _restarting;

		// Token: 0x0400001D RID: 29
		private readonly object _networkStatsLock;

		// Token: 0x04000027 RID: 39
		private IEnumerable<NetworkInfo> _networkInfos;

		// Token: 0x04000028 RID: 40
		private bool _thisMachineIsOld = true;

		// Token: 0x04000029 RID: 41
		private AppInventoryAmount _thisAppInvAmountRequirement;

		// Token: 0x0400002D RID: 45
		private List<ApplicationInfo> _applicationList;

		// Token: 0x0400002F RID: 47
		private Dictionary<PCmoverEngineLive.GroupType, GroupInfo> _groups;

		// Token: 0x04000034 RID: 52
		private LicenseInfo _license;

		// Token: 0x04000039 RID: 57
		private TransferProgressInfo _TransferInfo;

		// Token: 0x0400003A RID: 58
		private Settings _Settings;

		// Token: 0x04000041 RID: 65
		private DownloadControlClient _downloadControlProxy;

		// Token: 0x04000042 RID: 66
		private bool _receivedShutdownRequest;

		// Token: 0x04000043 RID: 67
		private object _shutdownRequestLock = new object();

		// Token: 0x04000044 RID: 68
		private bool _handledCommEx;

		// Token: 0x04000045 RID: 69
		private bool _firstConnection = true;

		// Token: 0x04000046 RID: 70
		private bool _retryInitialization;

		// Token: 0x04000047 RID: 71
		private string _initErrorMessage;

		// Token: 0x04000048 RID: 72
		private TaskCompletionSource<PcmoverState> _initComplete;

		// Token: 0x04000049 RID: 73
		private PcmoverState _lastState;

		// Token: 0x0400004A RID: 74
		private bool _monitorConnection;

		// Token: 0x0400004B RID: 75
		private Thread _connectionMonitorThread;

		// Token: 0x0400004C RID: 76
		private AutoResetEvent _stopMonitorEvent;

		// Token: 0x04000050 RID: 80
		private Task _customizationTask;

		// Token: 0x04000051 RID: 81
		private CancellationTokenSource _customizationTokenSource;

		// Token: 0x04000052 RID: 82
		private readonly string _selectionRoots = "Personal;Common Documents;My Music;CommonMusic;My Pictures;CommonPictures;My Video;CommonVideo";

		// Token: 0x02000028 RID: 40
		private enum GroupType
		{
			// Token: 0x040000B8 RID: 184
			Documents,
			// Token: 0x040000B9 RID: 185
			Pictures,
			// Token: 0x040000BA RID: 186
			Music,
			// Token: 0x040000BB RID: 187
			Video,
			// Token: 0x040000BC RID: 188
			Other,
			// Token: 0x040000BD RID: 189
			None
		}
	}
}
