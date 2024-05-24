using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ClientEngineModule.Mock.Properties;
using Laplink.Download.Contracts;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Win32;
using PCmover.Infrastructure;
using Prism.Events;

namespace ClientEngineModule.Mock
{
	// Token: 0x02000003 RID: 3
	public class PCmoverEngineMock : IPCmoverEngine
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002084 File Offset: 0x00000284
		public IEventAggregator EventAggregator { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000208C File Offset: 0x0000028C
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002094 File Offset: 0x00000294
		public MachineData ThisMachine { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000209D File Offset: 0x0000029D
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020A5 File Offset: 0x000002A5
		public IEnumerable<DriveSpaceData> ThisMachineDriveSpace { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020AE File Offset: 0x000002AE
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020B6 File Offset: 0x000002B6
		public bool ThisMachineIsOld { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020BF File Offset: 0x000002BF
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020C7 File Offset: 0x000002C7
		public AppInventoryAmount ThisMachineAppInventoryRequirement { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020D0 File Offset: 0x000002D0
		public bool IsThisMachineAppInventoryComplete
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000020D3 File Offset: 0x000002D3
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000020DB File Offset: 0x000002DB
		public bool UseSSL { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000020E4 File Offset: 0x000002E4
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000020EC File Offset: 0x000002EC
		public string CertificateName { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000020F5 File Offset: 0x000002F5
		public IEnumerable<NetworkInfo> NetworkInfos
		{
			get
			{
				return new List<NetworkInfo>();
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000020FC File Offset: 0x000002FC
		public RebootPendingReasons RebootPending
		{
			get
			{
				return RebootPendingReasons.None;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000020FF File Offset: 0x000002FF
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002107 File Offset: 0x00000307
		public bool IsResuming { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002110 File Offset: 0x00000310
		public bool IsConnected
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002113 File Offset: 0x00000313
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000211B File Offset: 0x0000031B
		public TaskAlertData InteractiveDoneAlert { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002124 File Offset: 0x00000324
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000212C File Offset: 0x0000032C
		public PolicyData Policy { get; private set; } = new PolicyData();

		// Token: 0x0600001C RID: 28 RVA: 0x00002138 File Offset: 0x00000338
		public PCmoverEngineMock(IEventAggregator eventAggregator, LlTraceSource ts)
		{
			this.EventAggregator = eventAggregator;
			this.Ts = ts;
			this.ThisMachine = new MachineData
			{
				FriendlyName = Resources.SIM_NewMachine,
				WindowsVersion = new WindowsVersionData
				{
					Version = new Version(10, 0, 0)
				},
				IsEngineRunningAsAdmin = true,
				JoinedDomain = "TRAVSOFT",
				Age = DateTime.Now
			};
			this.OtherMachine = new MachineData
			{
				IsEngineRunningAsAdmin = true,
				Age = MachineAge.GetMyCreationTime()
			};
			this.IsLive = false;
			this.UseSSL = true;
			this.MigrationItems = MigrationItemsOption.All;
			this.Settings["IsFilesBasedEnabled"] = true;
			this.Settings["IsIAEnabled"] = true;
			this.Settings["IsUAEnabled"] = false;
			this.FileFilters = new List<FileFilter>();
			Task.Run<bool>(() => this.ConnectToPcmoverServiceAsync());
			ulong num = 1000000000000UL;
			List<DriveSpaceData> thisMachineDriveSpace = new List<DriveSpaceData>
			{
				new DriveSpaceData
				{
					Drive = "C:\\",
					TotalBytes = 2UL * num,
					FreeBytes = num
				}
			};
			this.ThisMachineDriveSpace = thisMachineDriveSpace;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002354 File Offset: 0x00000554
		public Task<bool> ConnectToPcmoverServiceAsync()
		{
			PCmoverEngineMock.<ConnectToPcmoverServiceAsync>d__48 <ConnectToPcmoverServiceAsync>d__;
			<ConnectToPcmoverServiceAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ConnectToPcmoverServiceAsync>d__.<>4__this = this;
			<ConnectToPcmoverServiceAsync>d__.<>1__state = -1;
			<ConnectToPcmoverServiceAsync>d__.<>t__builder.Start<PCmoverEngineMock.<ConnectToPcmoverServiceAsync>d__48>(ref <ConnectToPcmoverServiceAsync>d__);
			return <ConnectToPcmoverServiceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002397 File Offset: 0x00000597
		public Task<FindResponse> FindServiceHostsAsync()
		{
			return null;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000239A File Offset: 0x0000059A
		public FindResponse FindServiceHosts()
		{
			return null;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023A0 File Offset: 0x000005A0
		public Task ShutdownPcmoverAppAsync(bool terminateService)
		{
			PCmoverEngineMock.<ShutdownPcmoverAppAsync>d__51 <ShutdownPcmoverAppAsync>d__;
			<ShutdownPcmoverAppAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShutdownPcmoverAppAsync>d__.<>1__state = -1;
			<ShutdownPcmoverAppAsync>d__.<>t__builder.Start<PCmoverEngineMock.<ShutdownPcmoverAppAsync>d__51>(ref <ShutdownPcmoverAppAsync>d__);
			return <ShutdownPcmoverAppAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023DB File Offset: 0x000005DB
		public void DisconnectFromPcmoverService()
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000023DD File Offset: 0x000005DD
		public ActivityClient StartReadSnapshot()
		{
			return this.StartReadSnapshot(this.TargetMachine);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000023EB File Offset: 0x000005EB
		public bool ApplyDataUpdate()
		{
			return true;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000023EE File Offset: 0x000005EE
		public ActivityClient StartReadSnapshot(ConnectableMachine targetMachine)
		{
			Task.Run(delegate()
			{
				PCmoverEngineMock.<<StartReadSnapshot>b__55_0>d <<StartReadSnapshot>b__55_0>d;
				<<StartReadSnapshot>b__55_0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<StartReadSnapshot>b__55_0>d.<>4__this = this;
				<<StartReadSnapshot>b__55_0>d.<>1__state = -1;
				<<StartReadSnapshot>b__55_0>d.<>t__builder.Start<PCmoverEngineMock.<<StartReadSnapshot>b__55_0>d>(ref <<StartReadSnapshot>b__55_0>d);
				return <<StartReadSnapshot>b__55_0>d.<>t__builder.Task;
			});
			return new ActivityClient(null, ActivityType.GetSnapshot, 1);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000240C File Offset: 0x0000060C
		public Task PrepareCustomizationAsync()
		{
			PCmoverEngineMock.<PrepareCustomizationAsync>d__56 <PrepareCustomizationAsync>d__;
			<PrepareCustomizationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PrepareCustomizationAsync>d__.<>4__this = this;
			<PrepareCustomizationAsync>d__.<>1__state = -1;
			<PrepareCustomizationAsync>d__.<>t__builder.Start<PCmoverEngineMock.<PrepareCustomizationAsync>d__56>(ref <PrepareCustomizationAsync>d__);
			return <PrepareCustomizationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002450 File Offset: 0x00000650
		public Task CancelPrepareCustomizationAsync()
		{
			PCmoverEngineMock.<CancelPrepareCustomizationAsync>d__57 <CancelPrepareCustomizationAsync>d__;
			<CancelPrepareCustomizationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CancelPrepareCustomizationAsync>d__.<>1__state = -1;
			<CancelPrepareCustomizationAsync>d__.<>t__builder.Start<PCmoverEngineMock.<CancelPrepareCustomizationAsync>d__57>(ref <CancelPrepareCustomizationAsync>d__);
			return <CancelPrepareCustomizationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000248B File Offset: 0x0000068B
		public ActivityClient StartBuildChangeLists()
		{
			Task.Run(delegate()
			{
				ProgressInfo progressInfo = new ProgressInfo();
				float num = 0f;
				if (!this.Settings.ContainsKey("QuickSimulations"))
				{
					for (int i = 0; i < 30; i++)
					{
						num += 3.33f;
						progressInfo.Percentage = (ushort)num;
						Thread.Sleep(500);
						this.EventAggregator.GetEvent<EngineEvents.AnalysisProgressChanged>().Publish(progressInfo);
					}
				}
				TaskStats payload = new TaskStats
				{
					Disk = new ContainerStats
					{
						TotalSize = (ulong)this.TotalTransferSize
					}
				};
				this.TotalTransferTime = TimeSpan.Zero;
				this.TargetMachine.LinkSpeed = 100000000UL;
				this.EventAggregator.GetEvent<EngineEvents.AnalyzeComputerEvent>().Publish(payload);
			});
			return new ActivityClient(null, ActivityType.BuildChangeLists, 1);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024A8 File Offset: 0x000006A8
		public Task<ActivityClient> StartFindComputerAsync()
		{
			PCmoverEngineMock.<StartFindComputerAsync>d__59 <StartFindComputerAsync>d__;
			<StartFindComputerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ActivityClient>.Create();
			<StartFindComputerAsync>d__.<>4__this = this;
			<StartFindComputerAsync>d__.<>1__state = -1;
			<StartFindComputerAsync>d__.<>t__builder.Start<PCmoverEngineMock.<StartFindComputerAsync>d__59>(ref <StartFindComputerAsync>d__);
			return <StartFindComputerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000024EB File Offset: 0x000006EB
		public IEnumerable<ConnectableMachine> GetConnectableMachines()
		{
			return null;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000024EE File Offset: 0x000006EE
		public DateTime UndoTime
		{
			get
			{
				return DateTime.Now;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000024F5 File Offset: 0x000006F5
		public string WindowsOldFolder
		{
			get
			{
				return "C:\\Windows.old";
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000024FC File Offset: 0x000006FC
		public SecurityProductsData SecurityProducts
		{
			get
			{
				return new SecurityProductsData
				{
					AntivirusProduct = "",
					FirewallProduct = ""
				};
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002519 File Offset: 0x00000719
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002521 File Offset: 0x00000721
		public TimeSpan TotalTransferTime { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000252A File Offset: 0x0000072A
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002532 File Offset: 0x00000732
		public double TotalTransferSize { get; set; }

		// Token: 0x06000031 RID: 49 RVA: 0x0000253B File Offset: 0x0000073B
		public Version GetLatestVersion()
		{
			return new Version(11, 0, 999, 0);
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000254B File Offset: 0x0000074B
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002553 File Offset: 0x00000753
		public ConnectableMachine TargetMachine { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000034 RID: 52 RVA: 0x0000255C File Offset: 0x0000075C
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002564 File Offset: 0x00000764
		public MigrationItemsOption MigrationItemsSelection { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000256D File Offset: 0x0000076D
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002575 File Offset: 0x00000775
		public MigrationItemsOption MigrationItems
		{
			get
			{
				return this.MigrationItemsSelection;
			}
			private set
			{
				this.MigrationItemsSelection = value;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000257E File Offset: 0x0000077E
		public CustomizationData ChangeMigrationItems(MigrationItemsOption migItems)
		{
			this.MigrationItems = migItems;
			return this._mockCd;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000258D File Offset: 0x0000078D
		public void RetrieveMigrationItems()
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002590 File Offset: 0x00000790
		private void AddApplication(string name, string bitmapName, TransferSafety safety = TransferSafety.High, bool selected = true)
		{
			ApplicationInfo item = new ApplicationInfo(new ApplicationData
			{
				Selected = selected,
				Name = name,
				Safety = safety,
				IsModifiable = true,
				AppId = Guid.NewGuid().ToString(),
				IsDisplayable = true
			})
			{
				AppImage = new BitmapImage(new Uri(bitmapName, UriKind.Relative))
			};
			this._ApplicationList.Add(item);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002604 File Offset: 0x00000804
		private string GetOsName(OperatingSystem os_info)
		{
			string text = os_info.Version.Major.ToString() + "." + os_info.Version.Minor.ToString();
			string str = (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))) ? ",W64" : ",W32";
			uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
			if (num <= 3236114161U)
			{
				if (num != 2793341610U)
				{
					if (num != 3185781304U)
					{
						if (num == 3236114161U)
						{
							if (text == "5.1")
							{
								return "OS: XP";
							}
						}
					}
					else if (text == "5.2")
					{
						return "OS: XP";
					}
				}
				else if (text == "10.0")
				{
					return "OS: Win10";
				}
			}
			else if (num <= 4235161167U)
			{
				if (num != 4218383548U)
				{
					if (num == 4235161167U)
					{
						if (text == "6.0")
						{
							return "OS: Vista";
						}
					}
				}
				else if (text == "6.1")
				{
					return "OS: Win7";
				}
			}
			else if (num != 4251938786U)
			{
				if (num == 4268716405U)
				{
					if (text == "6.2")
					{
						return "OS: Win8" + str;
					}
				}
			}
			else if (text == "6.3")
			{
				return "OS: Win8.1";
			}
			return "Unknown";
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002768 File Offset: 0x00000968
		private void GetApplications()
		{
			if (this._ApplicationList == null)
			{
				List<ApplicationData> applications = this.GetApplications(0, null);
				this._ApplicationList = new List<ApplicationInfo>();
				foreach (ApplicationData applicationData in applications)
				{
					ApplicationInfo applicationInfo = new ApplicationInfo(applicationData);
					if (applicationData.Bitmap != null)
					{
						MemoryStream memoryStream = new MemoryStream();
						applicationData.Bitmap.Save(memoryStream, ImageFormat.Png);
						applicationInfo.AppImage = BitmapFrame.Create(memoryStream);
					}
					this._ApplicationList.Add(applicationInfo);
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002808 File Offset: 0x00000A08
		public IEnumerable<ApplicationInfo> ApplicationList
		{
			get
			{
				if (this._ApplicationList == null)
				{
					this.GetApplications();
				}
				return this._ApplicationList;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002820 File Offset: 0x00000A20
		public Task RetrieveApplicationListAsync()
		{
			PCmoverEngineMock.<RetrieveApplicationListAsync>d__96 <RetrieveApplicationListAsync>d__;
			<RetrieveApplicationListAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RetrieveApplicationListAsync>d__.<>4__this = this;
			<RetrieveApplicationListAsync>d__.<>1__state = -1;
			<RetrieveApplicationListAsync>d__.<>t__builder.Start<PCmoverEngineMock.<RetrieveApplicationListAsync>d__96>(ref <RetrieveApplicationListAsync>d__);
			return <RetrieveApplicationListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002863 File Offset: 0x00000A63
		public CustomizationData ChangeApplicationSelection(ApplicationInfo appInfo)
		{
			return this.ChangeApplicationInfo(appInfo);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000286C File Offset: 0x00000A6C
		public CustomizationData ChangeApplicationInfo(ApplicationInfo appInfo)
		{
			return this._mockCd;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002874 File Offset: 0x00000A74
		public static void DirectorySearch(string dir, GroupInfo group)
		{
			ulong num = 0UL;
			ulong num2 = 0UL;
			try
			{
				foreach (FileInfo fileInfo in new DirectoryInfo(dir).EnumerateFiles("*"))
				{
					try
					{
						num += (ulong)fileInfo.Length;
						num2 += 1UL;
					}
					catch (UnauthorizedAccessException)
					{
					}
				}
				group.AddCategory(new TransferrableCategoryDefinition
				{
					FullPath = dir,
					NumContainers = (ulong)((long)Directory.GetDirectories(dir).Count<string>()),
					NumItems = num2,
					TotalSize = num,
					Transferrable = Transferrable.Transfer
				}, true);
				string[] directories = Directory.GetDirectories(dir);
				for (int i = 0; i < directories.Length; i++)
				{
					PCmoverEngineMock.DirectorySearch(directories[i], group);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000295C File Offset: 0x00000B5C
		private void GetDocumentsGroup()
		{
			if (this._documentsGroup == null)
			{
				this._documentsGroup = new GroupInfo("Documents", this, false);
				PCmoverEngineMock.DirectorySearch(Environment.GetFolderPath(Environment.SpecialFolder.Personal), this._documentsGroup);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002989 File Offset: 0x00000B89
		public GroupInfo DocumentsGroup
		{
			get
			{
				this.GetDocumentsGroup();
				return this._documentsGroup;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002997 File Offset: 0x00000B97
		private void GetPicturesGroup()
		{
			if (this._picturesGroup == null)
			{
				this._picturesGroup = new GroupInfo("Pictures", this, false);
				PCmoverEngineMock.DirectorySearch(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), this._picturesGroup);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000029C5 File Offset: 0x00000BC5
		public GroupInfo PicturesGroup
		{
			get
			{
				this.GetPicturesGroup();
				return this._picturesGroup;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000029D3 File Offset: 0x00000BD3
		private void GetMusicGroup()
		{
			if (this._musicGroup == null)
			{
				this._musicGroup = new GroupInfo("Music", this, false);
				PCmoverEngineMock.DirectorySearch(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), this._musicGroup);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002A01 File Offset: 0x00000C01
		public GroupInfo MusicGroup
		{
			get
			{
				this.GetMusicGroup();
				return this._musicGroup;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002A0F File Offset: 0x00000C0F
		private void GetVideoGroup()
		{
			if (this._videoGroup == null)
			{
				this._videoGroup = new GroupInfo("Video", this, false);
				PCmoverEngineMock.DirectorySearch(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), this._videoGroup);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002A3D File Offset: 0x00000C3D
		public GroupInfo VideoGroup
		{
			get
			{
				this.GetVideoGroup();
				return this._videoGroup;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002A4C File Offset: 0x00000C4C
		public GroupInfo OtherGroup
		{
			get
			{
				if (this._otherGroup == null)
				{
					this._otherGroup = new GroupInfo("Other", this, true);
					this._otherGroup.AddCategory(new TransferrableCategoryDefinition
					{
						FullPath = "C:\\",
						NumContainers = 2UL,
						NumItems = 3UL,
						TotalSize = 342523UL,
						Transferrable = Transferrable.Transfer
					}, true);
					this._otherGroup.AddCategory(new TransferrableCategoryDefinition
					{
						FullPath = "C:\\Users\\jack.wilson\\OneDrive\\Pictures",
						NumContainers = 2UL,
						NumItems = 3UL,
						TotalSize = 342523UL,
						Transferrable = Transferrable.Transfer
					}, true);
					this._otherGroup.AddCategory(new TransferrableCategoryDefinition
					{
						FullPath = "C:\\Files\\Test1",
						NumContainers = 1UL,
						NumItems = 3UL,
						TotalSize = 4342523UL,
						Transferrable = Transferrable.Transfer
					}, true);
					this._otherGroup.AddCategory(new TransferrableCategoryDefinition
					{
						FullPath = "C:\\Files\\Test2",
						NumContainers = 1UL,
						NumItems = 3UL,
						TotalSize = 4342523UL,
						Transferrable = Transferrable.Transfer
					}, true);
					this._otherGroup.AddCategory(new TransferrableCategoryDefinition
					{
						FullPath = "C:\\More Files",
						NumContainers = 1UL,
						NumItems = 3UL,
						TotalSize = 4342523UL,
						Transferrable = Transferrable.Transfer
					}, true);
					this._otherGroup.AddCategory(new TransferrableCategoryDefinition
					{
						FullPath = "C:\\More Files\\Test1",
						NumContainers = 1UL,
						NumItems = 3UL,
						TotalSize = 4342523UL,
						Transferrable = Transferrable.Transfer
					}, true);
				}
				return this._otherGroup;
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002BF6 File Offset: 0x00000DF6
		private TransferrableItemDefinition CreateItem(string name, ulong size, Transferrable transferrable = Transferrable.Transfer, string target = "")
		{
			return new TransferrableItemDefinition
			{
				Name = name,
				Size = size,
				Transferrable = transferrable,
				Target = target
			};
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002C1C File Offset: 0x00000E1C
		public TransferrableContainerData GetFolderData(string path, bool withinBranch, bool onlyRoot)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			List<TransferrableItemDefinition> list = new List<TransferrableItemDefinition>();
			try
			{
				foreach (FileInfo fileInfo in directoryInfo.EnumerateFiles())
				{
					try
					{
						list.Add(this.CreateItem(fileInfo.FullName, (ulong)fileInfo.Length, Transferrable.Transfer, ""));
					}
					catch (UnauthorizedAccessException)
					{
					}
				}
			}
			catch (Exception)
			{
			}
			if (list.Count > 0)
			{
				return new TransferrableContainerData
				{
					Transferrable = Transferrable.Transfer,
					FullPath = path,
					Items = list,
					Containers = new List<TransferrableContainerInfo>()
				};
			}
			return null;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002CE0 File Offset: 0x00000EE0
		public CustomizationData ChangeDiskData(string path, string fileName, bool isFolder, bool? isFiltered, string target)
		{
			return this._mockCd;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002CE8 File Offset: 0x00000EE8
		public void RetrieveDrives()
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002CEA File Offset: 0x00000EEA
		public CustomizationData ChangeDriveMapping(DrivePair drivePair)
		{
			return this._mockCd;
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public DriveData Drives
		{
			get
			{
				if (this._Drives == null)
				{
					List<DrivePair> list = new List<DrivePair>();
					List<string> list2 = new List<string>();
					this._Drives = new DriveData
					{
						Matches = list,
						OldDrives = list2,
						NewDrives = new List<string>
						{
							"C:\\"
						}
					};
					string pathRoot = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
					foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
					{
						if (driveInfo.DriveType == DriveType.Fixed)
						{
							list2.Add(driveInfo.Name);
							if (string.Compare(pathRoot, driveInfo.Name) == 0)
							{
								list.Add(new DrivePair
								{
									OldDrive = driveInfo.Name,
									NewDrive = driveInfo.Name
								});
							}
							else
							{
								string newDrive = pathRoot + driveInfo.Name.Substring(0, 1) + Resources.MOCK_drive;
								list.Add(new DrivePair
								{
									OldDrive = driveInfo.Name,
									NewDrive = newDrive
								});
							}
						}
						bool isReady = driveInfo.IsReady;
					}
				}
				return this._Drives;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002E10 File Offset: 0x00001010
		public MiscSettingsData MiscSettingsData
		{
			get
			{
				if (this._MiscSettingsData == null)
				{
					this._MiscSettingsData = new MiscSettingsData
					{
						Groups = new List<MiscSettingsGroupData>
						{
							new MiscSettingsGroupData
							{
								DisplayName = "Main",
								Settings = new List<MiscSettingData>
								{
									new MiscSettingData
									{
										Name = "a",
										Text = "Transfer Wallpaper and Screen Saver",
										Selected = true
									},
									new MiscSettingData
									{
										Name = "b",
										Text = "Transfer Control Panel Icons",
										Help = "Transfer wallpaper and screensaver",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "c",
										Text = "Merge Ini files",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "d",
										Text = "Transfer printer files",
										Selected = false
									}
								}
							},
							new MiscSettingsGroupData
							{
								DisplayName = "E-mail",
								Settings = new List<MiscSettingData>
								{
									new MiscSettingData
									{
										Name = "e",
										Text = "Transfer the default setting for mail, calendar, and contacts",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "f",
										Text = "Change Outlook profile",
										Help = "Transfer wallpaper and screensaver",
										Selected = true
									},
									new MiscSettingData
									{
										Name = "g",
										Text = "Transfer default Outlook Express Identity",
										Selected = true
									},
									new MiscSettingData
									{
										Name = "h",
										Text = "Import Outlook Express rules in WinMail",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "i",
										Text = "Change default address book",
										Selected = true
									},
									new MiscSettingData
									{
										Name = "j",
										Text = "Force all Outlook mail files to transfer",
										Selected = false
									}
								}
							},
							new MiscSettingsGroupData
							{
								DisplayName = "System Hooks",
								Settings = new List<MiscSettingData>
								{
									new MiscSettingData
									{
										Name = "k",
										Text = "Do not transfer IE toolbars. BHOs and other potential spyware settings",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "l",
										Text = "Use Start-up This",
										Help = "Transfer wallpaper and screensaver",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "m",
										Text = "Disable auto-strat programs without using StartUp This",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "n",
										Text = "Transfer all file associations",
										Selected = false
									}
								}
							},
							new MiscSettingsGroupData
							{
								DisplayName = "Application Settings",
								Settings = new List<MiscSettingData>
								{
									new MiscSettingData
									{
										Name = "o",
										Text = "Transfer the Internet Explorer Home Page setting",
										Selected = true
									},
									new MiscSettingData
									{
										Name = "p",
										Text = "Transfer Internet Explorer options",
										Help = "Transfer wallpaper and screensaver",
										Selected = true
									},
									new MiscSettingData
									{
										Name = "q",
										Text = "Always transfer MS Word settings",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "r",
										Text = "Overwrite Notes.ini",
										Selected = false
									}
								}
							},
							new MiscSettingsGroupData
							{
								DisplayName = "Troubleshooting",
								Settings = new List<MiscSettingData>
								{
									new MiscSettingData
									{
										Name = "s",
										Text = "Do not transfer application files in the Windows directories",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "t",
										Text = "Move Nothing",
										Help = "Transfer wallpaper and screensaver",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "u",
										Text = "Transfer empty folders",
										Help = "Transfer wallpaper and screensaver",
										Selected = false
									},
									new MiscSettingData
									{
										Name = "v",
										Text = "Allow Quantum Sync",
										Selected = false
									}
								}
							}
						}
					};
				}
				return this._MiscSettingsData;
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000329B File Offset: 0x0000149B
		public void RetrieveMiscSettings()
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000329D File Offset: 0x0000149D
		public CustomizationData ChangeMiscSetting(MiscSettingData miscSettingData)
		{
			return this._mockCd;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000032A5 File Offset: 0x000014A5
		public UserMappings Users
		{
			get
			{
				if (this._users == null)
				{
					this.RetrieveUsers();
				}
				return this._users;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000032BC File Offset: 0x000014BC
		public List<string> Categories
		{
			get
			{
				if (this._Categories == null)
				{
					this._Categories = new List<string>
					{
						"Applications",
						"Users",
						"Groups",
						"Disk Items",
						"Registry Items",
						"Files",
						"Music",
						"Videos",
						"User Profiles",
						"Application Data",
						"Completed"
					};
				}
				return this._Categories;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000335E File Offset: 0x0000155E
		public void RetrieveUsers()
		{
			if (this._users == null)
			{
				this._users = this.TaskGetUserMappings(0, true);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003376 File Offset: 0x00001576
		public CustomizationData ChangeUserMapping(UserMapping userMapping)
		{
			return this._mockCd;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000337E File Offset: 0x0000157E
		public CustomizationData SetUserPassword(string accountName, string password)
		{
			return this._mockCd;
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003386 File Offset: 0x00001586
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000033C3 File Offset: 0x000015C3
		public LicenseInfo License
		{
			get
			{
				if (this._License == null)
				{
					this._License = new LicenseInfo
					{
						SerialNumber = this.GetLastSerialNumber(),
						Email = "tester@laplink.com",
						User = "tester"
					};
				}
				return this._License;
			}
			set
			{
				this._License = value;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000033CC File Offset: 0x000015CC
		public void SetProductCulture(string language, string country)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000033CE File Offset: 0x000015CE
		public string GetLastSerialNumber()
		{
			return "0123456789";
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000033D8 File Offset: 0x000015D8
		public Task<SerialNumberInfo> GetSerialNumberInfoAsync(string serialNumber)
		{
			return Task.FromResult<SerialNumberInfo>(new SerialNumberInfo
			{
				NormalizedKey = serialNumber,
				NumLicenses = 1,
				NumUsed = 0,
				LicenseType = 1,
				MatchedType = 1,
				EndDate = "0000-00-00",
				Expired = false,
				Result = SerialNumberInfoResult.ValidSerialNumber
			});
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000342B File Offset: 0x0000162B
		public uint CreateCertificate(string serialNumber, string email, string caServer)
		{
			return 200U;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003432 File Offset: 0x00001632
		public string DefaultCertificateName
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003435 File Offset: 0x00001635
		public AuthorizationInfo TaskGetAuthorizationInfo()
		{
			return new AuthorizationInfo
			{
				SerialNumber = "0123456789",
				IsAuthorized = true
			};
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000344E File Offset: 0x0000164E
		public bool TaskPrepareAuthorization(LicenseInfo license)
		{
			return true;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003451 File Offset: 0x00001651
		public bool IsRegistered()
		{
			return false;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003454 File Offset: 0x00001654
		public bool ValidateLicense(LicenseInfo license, out string errorMessage)
		{
			errorMessage = "";
			return true;
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000345E File Offset: 0x0000165E
		public VersionInfo Version
		{
			get
			{
				if (this._Version == null)
				{
					this._Version = new VersionInfo(new Version(11, 0, 998, 0), new AppUpdateData
					{
						AppUpdateAvailable = true,
						AppUpdateUrl = "http://laplink.com/mockupdate"
					});
				}
				return this._Version;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000349E File Offset: 0x0000169E
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000034C4 File Offset: 0x000016C4
		public TransferProgressInfo TransferInfo
		{
			get
			{
				if (this._TransferInfo == null)
				{
					this._TransferInfo = new TransferProgressInfo
					{
						ProgressInfo = new ProgressInfo()
					};
				}
				return this._TransferInfo;
			}
			set
			{
				this._TransferInfo = value;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000034D0 File Offset: 0x000016D0
		public ActivityClient StartTransfer()
		{
			if (this._TransferInProgress)
			{
				return null;
			}
			this._TransferInProgress = true;
			this.TransferInfo = null;
			int counter = 0;
			int category = 0;
			this.TransferInfo.TotalItems = 200;
			this.TransferInfo.ItemsRemaining = this.TransferInfo.TotalItems;
			DispatcherTimer timer;
			if (this.Settings.ContainsKey("QuickSimulations"))
			{
				this.TransferInfo.ElapsedTime = new TimeSpan(12, 43, 0);
				timer = new DispatcherTimer
				{
					Interval = TimeSpan.FromSeconds(0.01)
				};
			}
			else
			{
				timer = new DispatcherTimer
				{
					Interval = TimeSpan.FromSeconds(0.1)
				};
			}
			timer.Tick += delegate(object sender, EventArgs args)
			{
				int num = counter;
				counter = num + 1;
				this.TransferInfo.CurrentCategory = this.Categories[category];
				this.TransferInfo.CurrentItem = "Item " + counter.ToString();
				TransferProgressInfo transferInfo = this.TransferInfo;
				num = transferInfo.ItemsRemaining;
				transferInfo.ItemsRemaining = num - 1;
				this.TransferInfo.ProgressInfo.Percentage = (ushort)((this.TransferInfo.TotalItems - this.TransferInfo.ItemsRemaining + 1) * 100 / this.TransferInfo.TotalItems);
				this.TransferInfo.ProgressInfo.ActionCode = UiCallbackCode.Action_UnloadProgressDisk;
				this.TransferInfo.ProgressInfo.Action = "Completing transfer: disk";
				this.TransferInfo.ElapsedTime = new TimeSpan(0, 0, 0, 0, counter * 100);
				this.TransferInfo.CurrentCategory = this.Categories[(int)(this.TransferInfo.ProgressInfo.Percentage / 10)];
				this.TransferInfo.EstimatedTimeRemaining = TimeSpan.FromSeconds((double)Convert.ToInt16(20.0 - (double)counter * 0.1));
				ActivityInfo activityInfo = new ActivityInfo();
				activityInfo.Type = ActivityType.Transfer;
				this.TransferInfo.ActivityInfo = activityInfo;
				if (this.TransferInfo.Progress >= 100.0)
				{
					timer.Stop();
					this.TransferInfo.ElapsedTime = this.TotalTransferTime;
					this._TransferInProgress = false;
					activityInfo.State = ActivityState.Success;
					this.EventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Publish(activityInfo);
				}
				else
				{
					activityInfo.State = ActivityState.Active;
				}
				this.EventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Publish(this.TransferInfo);
				if (activityInfo.State == ActivityState.Success)
				{
					TransferCompleteInfo payload = new TransferCompleteInfo
					{
						ActivityInfo = activityInfo,
						Stats = this.TaskGetStats(0, true),
						TransferResult = TransferProcessResult.Success
					};
					this.EventAggregator.GetEvent<EngineEvents.TransferComplete>().Publish(payload);
				}
			};
			timer.Start();
			return new ActivityClient(null, ActivityType.Transfer, 1);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000035C8 File Offset: 0x000017C8
		public ActivityClient StartUndoActivity()
		{
			this.StartTransfer();
			this.TransferInfo.ElapsedTime = this.TotalTransferTime;
			this._TransferInProgress = false;
			ActivityInfo activityInfo = new ActivityInfo();
			activityInfo.State = ActivityState.Success;
			activityInfo.Type = ActivityType.Undo;
			this.TransferInfo.ActivityInfo = activityInfo;
			this.EventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Publish(activityInfo);
			return new ActivityClient(null, ActivityType.Undo, 1);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000362F File Offset: 0x0000182F
		public ActivityClient StartListenActivity(string discoveryId, string password)
		{
			return new ActivityClient(null, ActivityType.Listen, 1);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000363C File Offset: 0x0000183C
		public Task StopActivityAsync(ActivityClient client, bool waitUntilDone = true)
		{
			PCmoverEngineMock.<StopActivityAsync>d__168 <StopActivityAsync>d__;
			<StopActivityAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StopActivityAsync>d__.waitUntilDone = waitUntilDone;
			<StopActivityAsync>d__.<>1__state = -1;
			<StopActivityAsync>d__.<>t__builder.Start<PCmoverEngineMock.<StopActivityAsync>d__168>(ref <StopActivityAsync>d__);
			return <StopActivityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000367F File Offset: 0x0000187F
		public Task StopActivityAsync(ActivityType type, bool waitUntilDone = true)
		{
			return this.StopActivityAsync(null, waitUntilDone);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003689 File Offset: 0x00001889
		public ActivityClient GetActivityClient(ActivityType type)
		{
			return new ActivityClient(null, type, 1);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003693 File Offset: 0x00001893
		public ActivityClient GetActivityClient(int handle)
		{
			return new ActivityClient(null, ActivityType.Transfer, handle);
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000369D File Offset: 0x0000189D
		// (set) Token: 0x0600006F RID: 111 RVA: 0x000036A5 File Offset: 0x000018A5
		public bool GodMode { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000036AE File Offset: 0x000018AE
		// (set) Token: 0x06000071 RID: 113 RVA: 0x000036B6 File Offset: 0x000018B6
		public bool IsLive { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000036BF File Offset: 0x000018BF
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000036C7 File Offset: 0x000018C7
		public bool IsScript { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000036D0 File Offset: 0x000018D0
		public bool IsRemoteUI { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000036D8 File Offset: 0x000018D8
		public bool IsRebooting
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000036DB File Offset: 0x000018DB
		// (set) Token: 0x06000077 RID: 119 RVA: 0x000036E3 File Offset: 0x000018E3
		public List<ConnectableMachine> ConnectableMachines { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000036EC File Offset: 0x000018EC
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00003707 File Offset: 0x00001907
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

		// Token: 0x0600007A RID: 122 RVA: 0x00003710 File Offset: 0x00001910
		public ActivityClient StartCreateImageMachine(ImageMapData imageMachineData)
		{
			return this.StartReadSnapshot();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003718 File Offset: 0x00001918
		public ActivityClient StartCreateWinUpgradeMachine(string windowsOld)
		{
			return this.StartReadSnapshot();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003720 File Offset: 0x00001920
		public ActivityClient StartCreateAnyMachine()
		{
			return this.StartReadSnapshot();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003728 File Offset: 0x00001928
		public bool AddSelf()
		{
			return false;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000372B File Offset: 0x0000192B
		public ActivityClient StartSaveMovingVan(string fileName, ulong? spanSize, bool? canSpan, bool? notifySpan)
		{
			return this.StartTransfer();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003733 File Offset: 0x00001933
		public ActivityClient StartTransferMovingVan(string fileName)
		{
			return this.StartTransfer();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000373B File Offset: 0x0000193B
		public void SetEngineLogData(EngineLogData data)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000373D File Offset: 0x0000193D
		public EngineLogData GetEngineLogData()
		{
			return new EngineLogData();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003744 File Offset: 0x00001944
		public Task<bool> CleanupAsync(uint timeout)
		{
			PCmoverEngineMock.<CleanupAsync>d__205 <CleanupAsync>d__;
			<CleanupAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<CleanupAsync>d__.<>1__state = -1;
			<CleanupAsync>d__.<>t__builder.Start<PCmoverEngineMock.<CleanupAsync>d__205>(ref <CleanupAsync>d__);
			return <CleanupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003780 File Offset: 0x00001980
		public Task ShutdownAndRestartPcmoverAsync()
		{
			PCmoverEngineMock.<ShutdownAndRestartPcmoverAsync>d__206 <ShutdownAndRestartPcmoverAsync>d__;
			<ShutdownAndRestartPcmoverAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShutdownAndRestartPcmoverAsync>d__.<>1__state = -1;
			<ShutdownAndRestartPcmoverAsync>d__.<>t__builder.Start<PCmoverEngineMock.<ShutdownAndRestartPcmoverAsync>d__206>(ref <ShutdownAndRestartPcmoverAsync>d__);
			return <ShutdownAndRestartPcmoverAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000037BB File Offset: 0x000019BB
		public IEnumerable<string> GetRedistributables()
		{
			return new List<string>
			{
				"Visual Studio VC 2005",
				"Visual Studio VC 2005 SP1"
			};
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000037D8 File Offset: 0x000019D8
		public bool UploadApplicationReport()
		{
			return true;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000037DB File Offset: 0x000019DB
		public FinishTransferData PerformPostTransferActions(bool dlmgrReboot)
		{
			return new FinishTransferData
			{
				Succeeded = true,
				Rebooting = dlmgrReboot,
				Arguments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Laplink\\PCmover\\DlMgr 0.xml")
			};
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003807 File Offset: 0x00001A07
		public bool Reboot(uint delay)
		{
			return true;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000380C File Offset: 0x00001A0C
		public Task StopReadSnapshotAsync(bool waitUntilDone = true)
		{
			PCmoverEngineMock.<StopReadSnapshotAsync>d__211 <StopReadSnapshotAsync>d__;
			<StopReadSnapshotAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StopReadSnapshotAsync>d__.<>4__this = this;
			<StopReadSnapshotAsync>d__.waitUntilDone = waitUntilDone;
			<StopReadSnapshotAsync>d__.<>1__state = -1;
			<StopReadSnapshotAsync>d__.<>t__builder.Start<PCmoverEngineMock.<StopReadSnapshotAsync>d__211>(ref <StopReadSnapshotAsync>d__);
			return <StopReadSnapshotAsync>d__.<>t__builder.Task;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003857 File Offset: 0x00001A57
		// (set) Token: 0x0600008A RID: 138 RVA: 0x0000385F File Offset: 0x00001A5F
		public List<FileFilter> FileFilters { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00003868 File Offset: 0x00001A68
		public NetworkStatsData NetworkStats
		{
			get
			{
				PCmoverEngineMock.Errors += PCmoverEngineMock.direction;
				if (PCmoverEngineMock.Errors > 110L)
				{
					PCmoverEngineMock.direction = -5L;
				}
				if (PCmoverEngineMock.Errors <= -10L)
				{
					PCmoverEngineMock.direction = 5L;
				}
				PCmoverEngineMock.FakePackets += 234UL;
				PCmoverEngineMock.FakeTries = PCmoverEngineMock.FakePackets + (ulong)PCmoverEngineMock.Errors;
				return new NetworkStatsData
				{
					TotalUDPBytes = 1234UL,
					TotalUDPPackets = PCmoverEngineMock.FakePackets,
					TotalUDPTries = PCmoverEngineMock.FakeTries,
					TotalUDPErrors = 0UL,
					Ieee80211 = 1,
					Hardwired = 1,
					USBState = USBState.PluggedIn
				};
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000390D File Offset: 0x00001B0D
		public void RetrieveFileFilters()
		{
			if (this.FileFilters == null)
			{
				this.FileFilters = new List<FileFilter>();
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003922 File Offset: 0x00001B22
		public CustomizationData ChangeFileFilter(int index, FileFilter filter)
		{
			this.FileFilters[index] = filter;
			return this._mockCd;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003937 File Offset: 0x00001B37
		public CustomizationData AddFileFilter(FileFilter filter)
		{
			this.FileFilters.Add(filter);
			return this._mockCd;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000394B File Offset: 0x00001B4B
		public CustomizationData DeleteFileFilter(int index)
		{
			this.FileFilters.RemoveAt(index);
			return this._mockCd;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003960 File Offset: 0x00001B60
		public CustomizationData SwapFileFilters(int index1, int index2)
		{
			FileFilter value = this.FileFilters[index1];
			this.FileFilters[index1] = this.FileFilters[index2];
			this.FileFilters[index2] = value;
			return this._mockCd;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000039A5 File Offset: 0x00001BA5
		public IEnumerable<DriveSpaceAndNeeded> DetermineInsufficientDiskSpace(IEnumerable<DriveSpaceRequired> requiredList)
		{
			return new List<DriveSpaceAndNeeded>();
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000039AC File Offset: 0x00001BAC
		// (set) Token: 0x06000093 RID: 147 RVA: 0x000039B4 File Offset: 0x00001BB4
		public List<ReportData> Reports { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000039BD File Offset: 0x00001BBD
		// (set) Token: 0x06000095 RID: 149 RVA: 0x000039C5 File Offset: 0x00001BC5
		public bool AllowUndo { get; set; } = true;

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000039CE File Offset: 0x00001BCE
		public MachineData OtherMachine { get; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000039D6 File Offset: 0x00001BD6
		public CommunicationState ControlProxyState
		{
			get
			{
				return CommunicationState.Opened;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000039D9 File Offset: 0x00001BD9
		public LlTraceSource Ts { get; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000039E1 File Offset: 0x00001BE1
		public IEnumerable<CategoryDefinition> CloudCategories { get; } = new List<CategoryDefinition>();

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000039E9 File Offset: 0x00001BE9
		// (set) Token: 0x0600009B RID: 155 RVA: 0x000039F1 File Offset: 0x00001BF1
		public string CloudToken { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000039FA File Offset: 0x00001BFA
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003A02 File Offset: 0x00001C02
		public bool ShouldCreatePdfReports { get; set; } = true;

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00003A0B File Offset: 0x00001C0B
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00003A13 File Offset: 0x00001C13
		public bool ShouldCreateCsvReports { get; set; } = true;

		// Token: 0x060000A0 RID: 160 RVA: 0x00003A1C File Offset: 0x00001C1C
		public bool SetVanPassword(string password)
		{
			return true;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003A1F File Offset: 0x00001C1F
		public bool RetrieveDiskData()
		{
			return true;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003A22 File Offset: 0x00001C22
		public IDownloadControl GetDownloadManager()
		{
			return null;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003A25 File Offset: 0x00001C25
		public bool SuspendSleep(bool suspend)
		{
			return true;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003A28 File Offset: 0x00001C28
		public TransferSpeeds GetTransferSpeeds(ActivityClient transferClient)
		{
			return new TransferSpeeds
			{
				RemoteSpeed = 8000000UL,
				LocalSpeed = 4000000UL
			};
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003A47 File Offset: 0x00001C47
		public int CreateNetworkTransferMethod(string networkTarget)
		{
			return 1;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003A4A File Offset: 0x00001C4A
		public int CreateTransferMethod(TransferMethodType tm, string networkTarget)
		{
			return 1;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003A4D File Offset: 0x00001C4D
		public int CreateTransferMethod(TransferMethodType tm)
		{
			return 1;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003A50 File Offset: 0x00001C50
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			if (transferMethodHandle == 0)
			{
				return null;
			}
			return new TransferMethodData
			{
				Handle = transferMethodHandle,
				TransferMethodType = TransferMethodType.Network
			};
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003A6B File Offset: 0x00001C6B
		public bool DeleteTransferMethod(int transferMethodHandle)
		{
			return true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003A6E File Offset: 0x00001C6E
		public bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info)
		{
			return true;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003A71 File Offset: 0x00001C71
		public SslInfo GetSslInfo()
		{
			if (this.TargetMachine == null || this.TargetMachine.Method != TransferMethodType.Network)
			{
				return null;
			}
			return new SslInfo
			{
				IsSecure = true,
				IsCertificateValid = true,
				State = SSLState.ConnectedTrusted
			};
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003AA6 File Offset: 0x00001CA6
		public SslInfo GetLocalSslInfo()
		{
			return new SslInfo
			{
				IsSecure = true,
				IsCertificateValid = true,
				State = SSLState.ConnectedTrusted
			};
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003AC2 File Offset: 0x00001CC2
		public bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData)
		{
			return true;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003AC5 File Offset: 0x00001CC5
		public bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info)
		{
			return true;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public bool RefreshNetworkAdapters()
		{
			return true;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003ACB File Offset: 0x00001CCB
		public uint GetValidNetworkAdapterCount()
		{
			return 1U;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003ACE File Offset: 0x00001CCE
		public ActivityClient StartLoadMovingJournal(string fileName)
		{
			return null;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003AD1 File Offset: 0x00001CD1
		public bool SetProxyAuth(string proxy, string username, string password)
		{
			return false;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003AD4 File Offset: 0x00001CD4
		public MachineDriveInfo GetMachineDriveInfo()
		{
			return new MachineDriveInfo
			{
				HardDrives = string.Empty,
				UsbDrives = string.Empty,
				VirtualDrives = string.Empty
			};
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003AFC File Offset: 0x00001CFC
		public bool MarkUserDeferredComplete(string userName, string userSid)
		{
			return true;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003B00 File Offset: 0x00001D00
		public bool CatchCommEx(Action func, [CallerMemberName] string caller = "")
		{
			bool result;
			try
			{
				func();
				result = true;
			}
			catch (CommunicationException payload)
			{
				this.EventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Publish(payload);
				result = false;
			}
			return result;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003B40 File Offset: 0x00001D40
		public Task<bool> CatchCommExAsync(Func<Task> func, [CallerMemberName] string caller = "")
		{
			PCmoverEngineMock.<CatchCommExAsync>d__281 <CatchCommExAsync>d__;
			<CatchCommExAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<CatchCommExAsync>d__.<>4__this = this;
			<CatchCommExAsync>d__.func = func;
			<CatchCommExAsync>d__.<>1__state = -1;
			<CatchCommExAsync>d__.<>t__builder.Start<PCmoverEngineMock.<CatchCommExAsync>d__281>(ref <CatchCommExAsync>d__);
			return <CatchCommExAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003B8B File Offset: 0x00001D8B
		public FileTransferMethodInfo GetFileTransferMethodInfo()
		{
			return new FileTransferMethodInfo();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003B92 File Offset: 0x00001D92
		public ImageMapData GetImageTransferMethodInfo()
		{
			return new ImageMapData();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003B99 File Offset: 0x00001D99
		public void SetControllerProperty(string property, string value)
		{
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003B9B File Offset: 0x00001D9B
		public string GetControllerProperty(string property)
		{
			return null;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003B9E File Offset: 0x00001D9E
		public void SetPublicProperty(string property, string value)
		{
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003BA0 File Offset: 0x00001DA0
		public string GetPublicProperty(string property)
		{
			return null;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003BA3 File Offset: 0x00001DA3
		public bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003BAA File Offset: 0x00001DAA
		public bool SetDirection(ConnectableMachine remoteMachine)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003BB4 File Offset: 0x00001DB4
		public List<ApplicationData> GetApplications(int taskHandle, GetApplicationsParameters parameters)
		{
			int num = 0;
			List<ApplicationData> list = new List<ApplicationData>();
			ZipArchive zipArchive = null;
			string archiveFileName = AppDomain.CurrentDomain.BaseDirectory + "AppProfiles\\AppProfiles.zip";
			try
			{
				zipArchive = ZipFile.OpenRead(archiveFileName);
			}
			catch (Exception)
			{
			}
			string name = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
			OperatingSystem osversion = Environment.OSVersion;
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name))
			{
				foreach (string text in registryKey.GetSubKeyNames())
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
					{
						try
						{
							object value = registryKey2.GetValue("DisplayName");
							object value2 = registryKey2.GetValue("SystemComponent");
							object value3 = registryKey2.GetValue("IsMinorUpgrade");
							object value4 = registryKey2.GetValue("ParentDisplayName");
							object value5 = registryKey2.GetValue("DisplayIcon");
							object obj = (registryKey2.GetValue("EstimatedSize") == null) ? "0" : registryKey2.GetValue("EstimatedSize");
							TransferSafety safety = TransferSafety.MediumLikely;
							if (value != null && value2 == null && value3 == null && value4 == null)
							{
								if (zipArchive != null)
								{
									string fileToFind = text.ToString() + ".txt";
									ZipArchiveEntry zipArchiveEntry = (from e in zipArchive.Entries
									where string.Compare(e.FullName, fileToFind, true) == 0
									select e).FirstOrDefault<ZipArchiveEntry>();
									if (zipArchiveEntry == null)
									{
										fileToFind = "DB/" + text.ToString() + ".txt";
										zipArchiveEntry = (from e in zipArchive.Entries
										where string.Compare(e.FullName, fileToFind, true) == 0
										select e).FirstOrDefault<ZipArchiveEntry>();
									}
									if (zipArchiveEntry != null)
									{
										using (Stream stream = zipArchiveEntry.Open())
										{
											if (stream != null)
											{
												string text2 = new StreamReader(stream).ReadToEnd();
												int startIndex = text2.IndexOf(this.GetOsName(osversion));
												int num2 = text2.IndexOf("OS :");
												string text3 = (num2 == -1) ? text2.Substring(startIndex) : text2.Substring(startIndex, num2);
												if (text3.Contains("CompatibleOs: Win10,W64"))
												{
													safety = TransferSafety.High;
												}
												if (text3.Contains("IncompatibleOs: Win10,W64"))
												{
													safety = TransferSafety.Low;
												}
											}
										}
									}
								}
								ulong appDiskSpace = 0UL;
								ulong.TryParse(obj.ToString(), out appDiskSpace);
								ApplicationData applicationData = new ApplicationData
								{
									Selected = true,
									Name = value.ToString(),
									Safety = safety,
									IsModifiable = true,
									AppId = Guid.NewGuid().ToString(),
									IsDisplayable = true,
									AppDiskSpace = appDiskSpace
								};
								if (num == 0)
								{
									applicationData.IsDisplayable = false;
								}
								if (num == 1)
								{
									applicationData.IsMatching = true;
								}
								Icon icon = SystemIcons.WinLogo;
								if (value5 != null)
								{
									icon = Icon.ExtractAssociatedIcon(value5.ToString());
									applicationData.Bitmap = icon.ToBitmap();
								}
								list.Add(applicationData);
								num++;
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003F20 File Offset: 0x00002120
		public UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly)
		{
			string text = (string)new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem").Get().Cast<ManagementBaseObject>().First<ManagementBaseObject>()["UserName"];
			if (text == null)
			{
				foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_Process").Get())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (managementObject["ExecutablePath"] != null && Path.GetFileName(managementObject["ExecutablePath"].ToString()).ToLower() == "explorer.exe")
					{
						string[] array = new string[2];
						ManagementObject managementObject2 = managementObject;
						string methodName = "GetOwner";
						object[] args = array;
						managementObject2.InvokeMethod(methodName, args);
						if (array.Count<string>() == 2)
						{
							text = array[1] + "\\" + array[0];
							break;
						}
						text = array[0];
						break;
					}
				}
			}
			if (text == null)
			{
				text = UserPrincipal.Current.DisplayName;
			}
			return new UserMappings
			{
				Mappings = new List<UserMapping>
				{
					new UserMapping
					{
						Old = new UserDetail
						{
							AccountName = text,
							FriendlyName = text,
							IsCurrentUser = true,
							UserType = UserType.Administrator
						},
						New = new UserDetail
						{
							AccountName = text,
							FriendlyName = text,
							IsCurrentUser = true,
							UserType = UserType.Administrator
						},
						Create = false
					}
				},
				UnusedOnNew = new List<UserDetail>
				{
					new UserDetail
					{
						AccountName = text,
						FriendlyName = text,
						IsCurrentUser = true,
						UserType = UserType.Administrator
					}
				}
			};
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000040C4 File Offset: 0x000022C4
		public TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace)
		{
			return new TaskStats
			{
				Disk = new ContainerStats
				{
					NumContainers = 1788UL,
					NumItems = 567890UL,
					TotalSize = 98765432UL
				},
				Registry = new ContainerStats
				{
					NumContainers = 788UL,
					NumItems = 67890UL,
					TotalSize = 8765432UL
				}
			};
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004134 File Offset: 0x00002334
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			return new TaskSummaryData();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000413B File Offset: 0x0000233B
		public void SendCallbackReply(int replyHandle, int reply)
		{
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000413D File Offset: 0x0000233D
		public bool SendAlerts(TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, TransferProcessResult status)
		{
			return true;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004140 File Offset: 0x00002340
		public bool SetAuthorizationData(AuthorizationRequestData authRequest)
		{
			return true;
		}

		// Token: 0x04000010 RID: 16
		private List<ApplicationInfo> _ApplicationList;

		// Token: 0x04000011 RID: 17
		private CustomizationData _mockCd = new CustomizationData
		{
			Result = CustomizationResult.Success
		};

		// Token: 0x04000012 RID: 18
		private string[] songs = new string[]
		{
			"Bohemian Rhapsody.mp3",
			"Hotel California.mp3",
			"Back in Black.mp3",
			"Tiny Dancer.mp3",
			"Stairway to Heaven.mp3",
			"Hey Jude.mp3",
			"Sweet Home Alabama.mp3",
			"All Along the Watchtower.mp3",
			"Dream On.mp3"
		};

		// Token: 0x04000013 RID: 19
		private string[] pictureFolders = new string[]
		{
			"Aruba - 2016",
			"Kids",
			"Camera Roll",
			"Screenshots",
			"Wildwood - 2015",
			"Antartic - 2014",
			"Beyonne, New Jersey - 2013",
			"Detroit - 2012"
		};

		// Token: 0x04000014 RID: 20
		private GroupInfo _documentsGroup;

		// Token: 0x04000015 RID: 21
		private GroupInfo _picturesGroup;

		// Token: 0x04000016 RID: 22
		private GroupInfo _musicGroup;

		// Token: 0x04000017 RID: 23
		private GroupInfo _videoGroup;

		// Token: 0x04000018 RID: 24
		private GroupInfo _otherGroup;

		// Token: 0x04000019 RID: 25
		private DriveData _Drives;

		// Token: 0x0400001A RID: 26
		private MiscSettingsData _MiscSettingsData;

		// Token: 0x0400001B RID: 27
		private UserMappings _users;

		// Token: 0x0400001C RID: 28
		private List<string> _Categories;

		// Token: 0x0400001D RID: 29
		private LicenseInfo _License;

		// Token: 0x0400001E RID: 30
		private VersionInfo _Version;

		// Token: 0x0400001F RID: 31
		private TransferProgressInfo _TransferInfo;

		// Token: 0x04000020 RID: 32
		private bool _TransferInProgress;

		// Token: 0x04000026 RID: 38
		private Settings _Settings;

		// Token: 0x04000028 RID: 40
		private static ulong FakePackets = 100UL;

		// Token: 0x04000029 RID: 41
		private static ulong FakeTries = 100UL;

		// Token: 0x0400002A RID: 42
		private static long Errors = 0L;

		// Token: 0x0400002B RID: 43
		private static long direction = 5L;
	}
}
