using System;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using WizardModule.Migration;

namespace MenuModule.ViewModels
{
	// Token: 0x02000009 RID: 9
	public class MockConfigViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000057 RID: 87 RVA: 0x00002D54 File Offset: 0x00000F54
		public MockConfigViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.pcmoverEngine = pcmoverEngine;
			this.migrationDefinition = migration;
			this.container = container;
			this.IsLatest = true;
			this.Title = "Simulation Configuration";
			pcmoverEngine.ThisMachineIsOld = (this.IsOld = false);
			this.IsLive = pcmoverEngine.IsLive;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002DBC File Offset: 0x00000FBC
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002DC4 File Offset: 0x00000FC4
		public string Title
		{
			get
			{
				return this.title;
			}
			private set
			{
				this.SetProperty<string>(ref this.title, value, "Title");
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002DD9 File Offset: 0x00000FD9
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002DF4 File Offset: 0x00000FF4
		public bool IsOld
		{
			get
			{
				this.isOld = this.pcmoverEngine.ThisMachineIsOld;
				return this.isOld;
			}
			set
			{
				this.SetProperty<bool>(ref this.isOld, value, "IsOld");
				this.pcmoverEngine.ThisMachineIsOld = value;
				if (value)
				{
					this.pcmoverEngine.Settings["IsOld"] = value;
					return;
				}
				this.pcmoverEngine.Settings.Remove("IsOld");
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002E54 File Offset: 0x00001054
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002E5C File Offset: 0x0000105C
		public bool IsLive
		{
			get
			{
				return this._IsLive;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsLive, value, "IsLive");
				if (this._IsLive != this.pcmoverEngine.IsLive)
				{
					foreach (ContainerRegistration containerRegistration in this.container.Registrations)
					{
						if (containerRegistration.RegisteredType == typeof(IPCmoverEngine) && containerRegistration.LifetimeManagerType == typeof(ContainerControlledLifetimeManager))
						{
							containerRegistration.LifetimeManager.RemoveValue();
						}
					}
					if (this._IsLive)
					{
						this.container.Resolve(Array.Empty<ResolverOverride>()).RegisterPcmoverEngine(this.container);
					}
					else
					{
						this.container.Resolve(Array.Empty<ResolverOverride>()).RegisterPcmoverEngine(this.container);
						this.LimitedOnOld = false;
						this.LimitedOnNew = false;
					}
					this.pcmoverEngine = this.container.Resolve(Array.Empty<ResolverOverride>());
					this.pcmoverEngine.Ts.TraceInformation("Connect to PCmover service from MockConfigViewModel.IsLive setter");
					Task.Run<bool>(() => this.pcmoverEngine.ConnectToPcmoverServiceAsync());
					this.eventAggregator.GetEvent<Events.EngineChanged>().Publish();
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002FA4 File Offset: 0x000011A4
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002FAC File Offset: 0x000011AC
		public bool IsLatest
		{
			get
			{
				return this.isLatest;
			}
			set
			{
				this.SetProperty<bool>(ref this.isLatest, value, "IsLatest");
				Version version = new Version(11, 2, 0, 0);
				AppUpdateData updateData = new AppUpdateData
				{
					AppUpdateAvailable = !value,
					AppUpdateUrl = "http://www.google.com/"
				};
				VersionInfo payload = new VersionInfo(version, updateData);
				this.eventAggregator.GetEvent<Events.IsLatestVersionEvent>().Publish(payload);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00003009 File Offset: 0x00001209
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00003022 File Offset: 0x00001222
		public bool ShowReports
		{
			get
			{
				this.showReports = this.migrationDefinition.ShowReports;
				return this.showReports;
			}
			set
			{
				this.SetProperty<bool>(ref this.showReports, value, "ShowReports");
				this.migrationDefinition.ShowReports = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00003043 File Offset: 0x00001243
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000306C File Offset: 0x0000126C
		public bool SimulateOtherComputerNotFound
		{
			get
			{
				this.simulateOtherComputerNotFound = this.migrationDefinition.SimulateOtherComputerNotFound;
				return this.pcmoverEngine.Settings.ContainsKey("SimulateOtherComputerNotFound");
			}
			set
			{
				this.SetProperty<bool>(ref this.simulateOtherComputerNotFound, value, "SimulateOtherComputerNotFound");
				this.migrationDefinition.SimulateOtherComputerNotFound = value;
				if (value)
				{
					this.pcmoverEngine.Settings["SimulateOtherComputerNotFound"] = value;
					return;
				}
				this.pcmoverEngine.Settings.Remove("SimulateOtherComputerNotFound");
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000030CC File Offset: 0x000012CC
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000030F4 File Offset: 0x000012F4
		public bool SimulateComputerNotOnInternet
		{
			get
			{
				this.simulateComputerNotOnInternet = this.migrationDefinition.SimulateComputerNotOnInternet;
				return this.pcmoverEngine.Settings.ContainsKey("SimulateComputerNotOnInternet");
			}
			set
			{
				this.SetProperty<bool>(ref this.simulateComputerNotOnInternet, value, "SimulateComputerNotOnInternet");
				this.migrationDefinition.SimulateComputerNotOnInternet = value;
				if (value)
				{
					this.pcmoverEngine.Settings["SimulateComputerNotOnInternet"] = value;
					return;
				}
				this.pcmoverEngine.Settings.Remove("SimulateComputerNotOnInternet");
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003154 File Offset: 0x00001354
		// (set) Token: 0x06000067 RID: 103 RVA: 0x0000318D File Offset: 0x0000138D
		public string TargetNetName
		{
			get
			{
				if (this.pcmoverEngine.Settings.ContainsKey("TargetNetName"))
				{
					return (string)this.pcmoverEngine.Settings["TargetNetName"];
				}
				return string.Empty;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.pcmoverEngine.Settings.Remove("TargetNetName");
					return;
				}
				this.pcmoverEngine.Settings["TargetNetName"] = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000031C3 File Offset: 0x000013C3
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000031FC File Offset: 0x000013FC
		public string TargetFriendlyName
		{
			get
			{
				if (this.pcmoverEngine.Settings.ContainsKey("TargetFriendlyName"))
				{
					return (string)this.pcmoverEngine.Settings["TargetFriendlyName"];
				}
				return string.Empty;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.pcmoverEngine.Settings.Remove("TargetFriendlyName");
					return;
				}
				this.pcmoverEngine.Settings["TargetFriendlyName"] = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003232 File Offset: 0x00001432
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00003249 File Offset: 0x00001449
		public bool QuickSimulations
		{
			get
			{
				return this.pcmoverEngine.Settings.ContainsKey("QuickSimulations");
			}
			set
			{
				if (value)
				{
					this.pcmoverEngine.Settings["QuickSimulations"] = value;
					return;
				}
				this.pcmoverEngine.Settings.Remove("QuickSimulations");
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000327F File Offset: 0x0000147F
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000032B8 File Offset: 0x000014B8
		public string EstimatedSize
		{
			get
			{
				if (this.pcmoverEngine.Settings.ContainsKey("EstimatedSize"))
				{
					return (string)this.pcmoverEngine.Settings["EstimatedSize"];
				}
				return string.Empty;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.pcmoverEngine.Settings.Remove("EstimatedSize");
					return;
				}
				this.pcmoverEngine.Settings["EstimatedSize"] = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000032EE File Offset: 0x000014EE
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00003327 File Offset: 0x00001527
		public string CompletionTime
		{
			get
			{
				if (this.pcmoverEngine.Settings.ContainsKey("CompletionTime"))
				{
					return (string)this.pcmoverEngine.Settings["CompletionTime"];
				}
				return string.Empty;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.pcmoverEngine.Settings.Remove("CompletionTime");
					return;
				}
				this.pcmoverEngine.Settings["CompletionTime"] = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000335D File Offset: 0x0000155D
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00003392 File Offset: 0x00001592
		public bool IsFilesBasedEnabled
		{
			get
			{
				return this.pcmoverEngine.Settings.ContainsKey("IsFilesBasedEnabled") && (bool)this.pcmoverEngine.Settings["IsFilesBasedEnabled"];
			}
			set
			{
				this.pcmoverEngine.Settings["IsFilesBasedEnabled"] = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000033AF File Offset: 0x000015AF
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000033E4 File Offset: 0x000015E4
		public bool IsIAEnabled
		{
			get
			{
				return this.pcmoverEngine.Settings.ContainsKey("IsIAEnabled") && (bool)this.pcmoverEngine.Settings["IsIAEnabled"];
			}
			set
			{
				this.pcmoverEngine.Settings["IsIAEnabled"] = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003401 File Offset: 0x00001601
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00003436 File Offset: 0x00001636
		public bool IsUAEnabled
		{
			get
			{
				return this.pcmoverEngine.Settings.ContainsKey("IsUAEnabled") && (bool)this.pcmoverEngine.Settings["IsUAEnabled"];
			}
			set
			{
				this.pcmoverEngine.Settings["IsUAEnabled"] = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003453 File Offset: 0x00001653
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003488 File Offset: 0x00001688
		public bool IgnoreIsComplete
		{
			get
			{
				return this.pcmoverEngine.Settings.ContainsKey("IgnoreIsComplete") && (bool)this.pcmoverEngine.Settings["IgnoreIsComplete"];
			}
			set
			{
				this.pcmoverEngine.Settings["IgnoreIsComplete"] = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000034A5 File Offset: 0x000016A5
		// (set) Token: 0x06000079 RID: 121 RVA: 0x000034AD File Offset: 0x000016AD
		public bool LimitedOnOld
		{
			get
			{
				return this._LimitedOnOld;
			}
			set
			{
				this.SetProperty<bool>(ref this._LimitedOnOld, value, "LimitedOnOld");
				if (this.pcmoverEngine.OtherMachine != null)
				{
					this.pcmoverEngine.OtherMachine.IsEngineRunningAsAdmin = !value;
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000034E3 File Offset: 0x000016E3
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000034EC File Offset: 0x000016EC
		public bool LimitedOnNew
		{
			get
			{
				return this._LimitedOnNew;
			}
			set
			{
				this.SetProperty<bool>(ref this._LimitedOnNew, value, "LimitedOnNew");
				if (this.pcmoverEngine.ThisMachine != null)
				{
					this.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin = !value;
				}
				this.eventAggregator.GetEvent<Events.CheckUserModeRestrictions>().Publish();
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000024AF File Offset: 0x000006AF
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000024AC File Offset: 0x000006AC
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000024AF File Offset: 0x000006AF
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000042 RID: 66
		private readonly IRegionManager regionManager;

		// Token: 0x04000043 RID: 67
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000044 RID: 68
		private IPCmoverEngine pcmoverEngine;

		// Token: 0x04000045 RID: 69
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000046 RID: 70
		private readonly IUnityContainer container;

		// Token: 0x04000047 RID: 71
		private string title;

		// Token: 0x04000048 RID: 72
		private bool isOld;

		// Token: 0x04000049 RID: 73
		private bool _IsLive;

		// Token: 0x0400004A RID: 74
		private bool isLatest;

		// Token: 0x0400004B RID: 75
		private bool showReports;

		// Token: 0x0400004C RID: 76
		private bool simulateOtherComputerNotFound;

		// Token: 0x0400004D RID: 77
		private bool simulateComputerNotOnInternet;

		// Token: 0x0400004E RID: 78
		private bool _LimitedOnOld;

		// Token: 0x0400004F RID: 79
		private bool _LimitedOnNew;
	}
}
