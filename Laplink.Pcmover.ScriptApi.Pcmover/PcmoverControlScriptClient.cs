using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.ScriptApi.Pcmover
{
	// Token: 0x02000004 RID: 4
	public class PcmoverControlScriptClient : PcmoverScriptClientBase, IPcmoverControl, IPcmoverMonitor, IPcmoverQuery
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000027F7 File Offset: 0x000009F7
		public IScriptChannel Connection
		{
			get
			{
				return base.Channel;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000027FF File Offset: 0x000009FF
		public PcmoverControlScriptClient(Uri uri, IPcmoverClientEngine client, IPcmoverMonitorCallback monitorCallback, IPcmoverControlCallback controlCallback, LlTraceSource ts) : base(uri, client, monitorCallback, controlCallback, ts)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000280E File Offset: 0x00000A0E
		public PcmoverControlScriptClient(ScriptChannelBase channelBase, Uri uri, IPcmoverClientEngine client, IPcmoverMonitorCallback monitorCallback, IPcmoverControlCallback controlCallback, LlTraceSource ts) : base(channelBase, uri, client, monitorCallback, controlCallback, ts)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000281F File Offset: 0x00000A1F
		public bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002826 File Offset: 0x00000A26
		public bool ApplyDataUpdate()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000282D File Offset: 0x00000A2D
		public bool BecomeController(CallbackState controlCallbackState)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002834 File Offset: 0x00000A34
		public AppUpdateData CheckForUpdate()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000283B File Offset: 0x00000A3B
		public RebootPendingReasons CheckRebootPending()
		{
			return RebootPendingReasons.None;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000283E File Offset: 0x00000A3E
		public void ClearAllProperties()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002845 File Offset: 0x00000A45
		public bool ConfigureAppInventoryActivity(int appInventoryActivityHandle, AppInventoryAmount amount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000284C File Offset: 0x00000A4C
		public void ConfigureControlCallbacks(CallbackState controlCallbackState)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002853 File Offset: 0x00000A53
		public void ConfigureMonitorCallbacks(CallbackState monitorCallbackState)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000285A File Offset: 0x00000A5A
		public ActivityInfo CreateAppInventoryActivity(int machineHandle, AppInventoryAmount amount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002861 File Offset: 0x00000A61
		public ActivityInfo CreateBuildChangeListsActivity(int fillTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002868 File Offset: 0x00000A68
		public uint CreateCertificate(string serialNumber, string email, string caServer)
		{
			try
			{
				return Convert.ToUInt32(this.Connection.InvokeScript(string.Concat(new string[]
				{
					"iPcmover.CreateCertificate(",
					ScriptClientBase.CreateScriptString(serialNumber),
					", ",
					ScriptClientBase.CreateScriptString(email),
					", ",
					ScriptClientBase.CreateScriptString(caServer),
					");"
				})));
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CreateCertificate");
			}
			return 0U;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000028F8 File Offset: 0x00000AF8
		public ActivityInfo CreateDiscoveryActivity(IEnumerable<int> transferMethodHandles, int timeout, string discoveryId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000028FF File Offset: 0x00000AFF
		public ActivityInfo CreateExpandSnapshotActivity(ExpandSnapshotActivityParameters esaParameters)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002906 File Offset: 0x00000B06
		public FillTaskData CreateFillTask(int oldMachineHandle, int newMachineHandle, int transferMethodHandle, string selectionRoots)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000290D File Offset: 0x00000B0D
		public ActivityInfo CreateGenerateReportsActivity(int taskHandle, IEnumerable<ReportData> reports)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002914 File Offset: 0x00000B14
		public ActivityInfo CreateGetSnapshotActivity(int transferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000291B File Offset: 0x00000B1B
		public ActivityInfo CreateListenActivity(IEnumerable<int> transferMethodHandles, string discoveryId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002922 File Offset: 0x00000B22
		public ActivityInfo CreateLoadMovingJournalActivity(int transferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002929 File Offset: 0x00000B29
		public ActivityInfo CreateSaveMovingVanActivity(int fileTransferMethodHandle, int fillTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002930 File Offset: 0x00000B30
		public ActivityInfo CreateSaveSnapshotActivity(int fileTransferMethodHandle, int machineHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002937 File Offset: 0x00000B37
		public ActivityInfo CreateTransferActivity(TransferActivityParameters transferActivityParameters)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000293E File Offset: 0x00000B3E
		public int CreateTransferMethod(TransferMethodType tm)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002945 File Offset: 0x00000B45
		public ActivityInfo CreateUndoActivity()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000294C File Offset: 0x00000B4C
		public bool DeleteActivity(int activityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002953 File Offset: 0x00000B53
		public bool DeleteMachine(int machineHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000295A File Offset: 0x00000B5A
		public bool DeleteTask(int taskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002961 File Offset: 0x00000B61
		public bool DeleteTransferMethod(int transferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002968 File Offset: 0x00000B68
		public ActivityInfo GetActivityInfo(int activityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000296F File Offset: 0x00000B6F
		public int GetActivityMachineHandle(int machineActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002976 File Offset: 0x00000B76
		public ProgressInfo GetActivityProgressInfo(int activityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000297D File Offset: 0x00000B7D
		public int GetActivityTaskHandle(int taskActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002984 File Offset: 0x00000B84
		public int GetActivityTransferMethodHandle(int transferMethodActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000298B File Offset: 0x00000B8B
		public IEnumerable<int> GetActivityTransferMethodHandles(int transferMethodsActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002992 File Offset: 0x00000B92
		public IEnumerable<ActivityInfo> GetAllActivityInfo()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002999 File Offset: 0x00000B99
		public IDictionary<string, string> GetAllControllerProperties()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000029A0 File Offset: 0x00000BA0
		public IEnumerable<MachineData> GetAllMachineData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000029A7 File Offset: 0x00000BA7
		public IDictionary<string, string> GetAllPublicProperties()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000029AE File Offset: 0x00000BAE
		public IEnumerable<PcmTaskData> GetAllTaskData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000029B5 File Offset: 0x00000BB5
		public IEnumerable<TransferMethodData> GetAllTransferMethodData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000029BC File Offset: 0x00000BBC
		public AppInventoryStatus GetAppInventoryActivityStatus(int appInventoryActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000029C4 File Offset: 0x00000BC4
		public AuthorizationRequestData GetAuthorizationData()
		{
			string[] data = this.Connection.InvokeScript("GetAuthorizationData;").Split(new string[]
			{
				"\n"
			}, StringSplitOptions.None);
			return new AuthorizationRequestData
			{
				Email = ScriptClientBase.ParseValue(data, "Email"),
				SerialNumber = ScriptClientBase.ParseValue(data, "SerialNumber"),
				User = ScriptClientBase.ParseValue(data, "User"),
				ValidationCode = ScriptClientBase.ParseValue(data, "ValidationCode")
			};
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002A3F File Offset: 0x00000C3F
		public IEnumerable<ConnectableMachine> GetConnectableMachines(int discoveryActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002A46 File Offset: 0x00000C46
		public ConnectionPolicyMethods GetConnectionPolicyMethods()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002A4D File Offset: 0x00000C4D
		public string GetControllerProperty(string key)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002A54 File Offset: 0x00000C54
		public string GetDefaultCertificateName()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002A5B File Offset: 0x00000C5B
		public IEnumerable<TransferMethodType> GetDiscoveryTransferMethods()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002A62 File Offset: 0x00000C62
		public string GetDownloadManagerEndpointAddress(ServiceType serviceType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002A69 File Offset: 0x00000C69
		public EngineLogData GetEngineLogData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002A70 File Offset: 0x00000C70
		public PolicyData GetPolicyData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002A77 File Offset: 0x00000C77
		public ExpandSnapshotActivityParameters GetExpandSnapshotActivityParameters(int expandSnapshotActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002A7E File Offset: 0x00000C7E
		public FileTransferMethodInfo GetFileTransferMethodInfo(int fileTransferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002A85 File Offset: 0x00000C85
		public IEnumerable<ReportData> GetGenerateReportsActivityData(int generateReportsActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A8C File Offset: 0x00000C8C
		public ImageMapData GetImageTransferMethodInfo(int imageTransferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A93 File Offset: 0x00000C93
		public InitPcmoverData GetInitPcmoverData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002A9A File Offset: 0x00000C9A
		public SslInfo GetLocalSslInfo()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002AA1 File Offset: 0x00000CA1
		public AppInventoryAmount? GetMachineAppInventoryAmount(int machineHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public MachineData GetMachineData(int machineHandle)
		{
			MachineData result;
			try
			{
				string[] data = this.Connection.InvokeScript(string.Format("iPcmover.GetMachineData({0});", machineHandle)).Split(new string[]
				{
					"\n"
				}, StringSplitOptions.None);
				MachineType type;
				Enum.TryParse<MachineType>(ScriptClientBase.ParseValue(data, "Type"), out type);
				ProductType productType;
				Enum.TryParse<ProductType>(ScriptClientBase.ParseValue(data, "ProductType"), out productType);
				result = new MachineData
				{
					Handle = Convert.ToInt32(ScriptClientBase.ParseValue(data, "Handle")),
					Type = type,
					NetName = ScriptClientBase.ParseValue(data, "NetName"),
					FriendlyName = ScriptClientBase.ParseValue(data, "FriendlyName"),
					MachineId = ScriptClientBase.ParseValue(data, "MachineId"),
					Manufacturer = ScriptClientBase.ParseValue(data, "Manufacturer"),
					JoinedDomain = ScriptClientBase.ParseValue(data, "JoinedDomain"),
					IsJoinedToAzureAd = Convert.ToBoolean(ScriptClientBase.ParseValue(data, "IsJoinedToAzureAd")),
					IsEngineRunningAsAdmin = Convert.ToBoolean(ScriptClientBase.ParseValue(data, "IsEngineRunningAsAdmin")),
					Age = Convert.ToDateTime(ScriptClientBase.ParseValue(data, "Age")),
					OemId = Convert.ToUInt32(ScriptClientBase.ParseValue(data, "$OemId")),
					WindowsVersion = new WindowsVersionData
					{
						Platform = (int)Convert.ToInt16(ScriptClientBase.ParseValue(data, "Platform")),
						ServicePack = ScriptClientBase.ParseValue(data, "ServicePack"),
						Version = new Version(ScriptClientBase.ParseValue(data, "Version")),
						VersionString = ScriptClientBase.ParseValue(data, "VersionString"),
						Is64Bit = Convert.ToBoolean(ScriptClientBase.ParseValue(data, "Is64Bit")),
						ProductType = productType,
						EnablePreviewBuilds = Convert.ToUInt32(ScriptClientBase.ParseValue(data, "EnablePreviewBuilds")),
						WindowsEdition = Convert.ToUInt32(ScriptClientBase.ParseValue(data, "WindowsEdition"))
					}
				};
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetMachineData");
				result = null;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public IEnumerable<UserDetail> GetMachineUsers(int machineHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002CBC File Offset: 0x00000EBC
		public IEnumerable<NetworkInfo> GetNetworkInfos()
		{
			List<NetworkInfo> list = new List<NetworkInfo>();
			try
			{
				string[] array = this.Connection.InvokeScript("GetNetworkInfos();").Split(new string[]
				{
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string[] data = array[i].Split(new string[]
					{
						";"
					}, StringSplitOptions.None);
					NetworkInterfaceType networkInterfaceTypeInteger;
					Enum.TryParse<NetworkInterfaceType>(ScriptClientBase.ParseValue(data, "NetworkInterfaceTypeInteger"), out networkInterfaceTypeInteger);
					OperationalStatus operationalStatusInteger;
					Enum.TryParse<OperationalStatus>(ScriptClientBase.ParseValue(data, "OperationalStatusInteger"), out operationalStatusInteger);
					NetworkInfo item = new NetworkInfo
					{
						Description = ScriptClientBase.ParseValue(data, "Description"),
						SupportsMulticast = Convert.ToBoolean(Convert.ToInt16(ScriptClientBase.ParseValue(data, "SupportsMulticast"))),
						Id = ScriptClientBase.ParseValue(data, "Id"),
						Name = ScriptClientBase.ParseValue(data, "Name"),
						IsReceiveOnly = Convert.ToBoolean(Convert.ToInt16(ScriptClientBase.ParseValue(data, "IsReceiveOnly"))),
						NetworkInterfaceTypeInteger = (int)networkInterfaceTypeInteger,
						OperationalStatusInteger = (int)operationalStatusInteger,
						Speed = Convert.ToInt64(ScriptClientBase.ParseValue(data, "Speed"))
					};
					list.Add(item);
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetNetworkInfos");
			}
			return list;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002E1C File Offset: 0x0000101C
		public NetworkStatsData GetNetworkStats()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002E23 File Offset: 0x00001023
		public NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002E2C File Offset: 0x0000102C
		public PcmoverStatusInfo GetPcmoverStatus()
		{
			PcmoverStatusInfo result;
			try
			{
				string[] data = this.Connection.InvokeScript("GetPcmoverStatus();").Split(new string[]
				{
					","
				}, StringSplitOptions.RemoveEmptyEntries);
				PcmoverState state;
				Enum.TryParse<PcmoverState>(ScriptClientBase.ParseValue(data, "State"), out state);
				result = new PcmoverStatusInfo
				{
					State = state,
					HasController = Convert.ToBoolean(ScriptClientBase.ParseValue(data, "HasController")),
					NumCallbacksPending = Convert.ToInt32(ScriptClientBase.ParseValue(data, "Callbacks"))
				};
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetPcmoverStatus");
				result = null;
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002ED4 File Offset: 0x000010D4
		public Version GetPcmoverVersion()
		{
			return Assembly.GetEntryAssembly().GetName().Version;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002EE5 File Offset: 0x000010E5
		public string GetPolicy(RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002EEC File Offset: 0x000010EC
		public string GetPublicProperty(string key)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002EF3 File Offset: 0x000010F3
		public SecurityProductsData GetSecurityProducts()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002EFA File Offset: 0x000010FA
		public SerialNumberInfo GetSerialNumberInfo(string serialNumber)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002F01 File Offset: 0x00001101
		public SslInfo GetSslInfo(int networkTransferMethodHandle)
		{
			return null;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002F04 File Offset: 0x00001104
		public PcmTaskData GetTaskData(int taskHandle)
		{
			this.Connection.InvokeScript(string.Format("GetPcmTaskData({0});", taskHandle));
			string[] data = this.Connection.InvokeScript("strPcmTaskData;").Split(new string[]
			{
				"\n"
			}, StringSplitOptions.None);
			PcmTaskType taskType;
			Enum.TryParse<PcmTaskType>(ScriptClientBase.ParseValue(data, "TaskType"), out taskType);
			return new PcmTaskData
			{
				Handle = (int)Convert.ToInt16(ScriptClientBase.ParseValue(data, "Handle")),
				SourceMachineHandle = Convert.ToInt32(ScriptClientBase.ParseValue(data, "SourceMachineHandle")),
				DestMachineHandle = Convert.ToInt32(ScriptClientBase.ParseValue(data, "DestMachineHandle")),
				IsReady = Convert.ToBoolean(Convert.ToInt32(ScriptClientBase.ParseValue(data, "IsReady"))),
				TaskType = taskType
			};
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002FCE File Offset: 0x000011CE
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002FD5 File Offset: 0x000011D5
		public TransferProcessResult GetTaskTransferResult(int taskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002FDC File Offset: 0x000011DC
		public MachineData GetThisMachine()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002FE3 File Offset: 0x000011E3
		public TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002FEA File Offset: 0x000011EA
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002FF1 File Offset: 0x000011F1
		public TransferSpeeds GetTransferSpeeds(int transferActivityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002FF8 File Offset: 0x000011F8
		public DateTime GetUndoTime()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002FFF File Offset: 0x000011FF
		public uint GetValidNetworkAdapterCount()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003006 File Offset: 0x00001206
		public string GetWindowsOld()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000300D File Offset: 0x0000120D
		public WinUpgradeTransferMethodInfo GetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003014 File Offset: 0x00001214
		public PcmoverState InitPcmoverApp(InitPcmoverData data)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000301B File Offset: 0x0000121B
		public bool LaunchStartupAutoRun()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003022 File Offset: 0x00001222
		public IEnumerable<ApplicationData> MachineGetApplications(int machineHandle, GetApplicationsParameters parameters, RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003029 File Offset: 0x00001229
		public IEnumerable<CategoryDefinition> MachineGetCategories(int machineHandle, CategoryParameters categoryParameters, RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003030 File Offset: 0x00001230
		public MachineDriveInfo MachineGetDriveInfo(int machineHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003038 File Offset: 0x00001238
		public IEnumerable<DriveSpaceData> MachineGetDriveSpace(int machineHandle)
		{
			List<DriveSpaceData> list = new List<DriveSpaceData>();
			try
			{
				string[] array = this.Connection.InvokeScript(string.Format("MachineGetDriveSpace({0});", machineHandle)).Split(new string[]
				{
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string[] data = array[i].Split(new string[]
					{
						";"
					}, StringSplitOptions.RemoveEmptyEntries);
					DriveSpaceData item = new DriveSpaceData
					{
						Drive = ScriptClientBase.ParseValue(data, "Drive"),
						FreeBytes = Convert.ToUInt64(ScriptClientBase.ParseValue(data, "FreeBytes")),
						TotalBytes = Convert.ToUInt64(ScriptClientBase.ParseValue(data, "TotalBytes"))
					};
					list.Add(item);
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "MachineGetDriveSpace");
			}
			return list;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003118 File Offset: 0x00001318
		public IEnumerable<ApplicationData> MachineGetMicrosoftOfficeTrialApps(int machineHandle, GetApplicationsParameters parameters)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000311F File Offset: 0x0000131F
		public bool MarkUserDeferredComplete(string userName, string userSid)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003126 File Offset: 0x00001326
		public bool Reboot(uint delay)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000312D File Offset: 0x0000132D
		public bool RefreshNetworkAdapters()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003134 File Offset: 0x00001334
		public TestResultData RunTest(TestParameterData p)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000313B File Offset: 0x0000133B
		public void SendCallbackReply(int replyHandle, int reply)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003142 File Offset: 0x00001342
		public bool SetAuthorizationData(AuthorizationRequestData authRequest)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003149 File Offset: 0x00001349
		public void SetControllerProperty(string key, string value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003150 File Offset: 0x00001350
		public bool SetDirection(ConnectableMachine remoteMachine)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003157 File Offset: 0x00001357
		public void SetEngineLogData(EngineLogData data)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000315E File Offset: 0x0000135E
		public bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003165 File Offset: 0x00001365
		public bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000316C File Offset: 0x0000136C
		public bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003173 File Offset: 0x00001373
		public bool SetPolicy(string p, int fullSize, bool firstPage, bool lastPage)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000317A File Offset: 0x0000137A
		public void SetProductCulture(string language, string country)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003181 File Offset: 0x00001381
		public bool SetProxyAuth(string proxy, string username, string Password)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003188 File Offset: 0x00001388
		public void SetPublicProperty(string key, string value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000318F File Offset: 0x0000138F
		public bool SetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle, WinUpgradeTransferMethodInfo info)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003196 File Offset: 0x00001396
		public PcmoverState ShutdownPcmoverApp(bool terminateService)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000319D File Offset: 0x0000139D
		public ActivityInfo StartActivity(int activityHandle)
		{
			this.Connection.InvokeScript(string.Format("StartActivity({0});", activityHandle));
			return new ActivityInfo();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000031C0 File Offset: 0x000013C0
		public ActivityInfo StopActivity(int activityHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000031C7 File Offset: 0x000013C7
		public void StopBeingController()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000031CE File Offset: 0x000013CE
		public bool SuspendSleep(bool suspend)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000031D5 File Offset: 0x000013D5
		public CustomizationData TaskChangeApplicationData(int taskHandle, ApplicationData data)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000031DC File Offset: 0x000013DC
		public CustomizationData TaskChangeContainerData(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool? userSelected, string target, bool containerAllAppsOnly)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000031E3 File Offset: 0x000013E3
		public CustomizationData TaskChangeDriveMapping(int taskHandle, DrivePair drivePair)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000031EA File Offset: 0x000013EA
		public CustomizationData TaskChangeItemFilter(int taskHandle, ItemType type, int index, ItemFilterData filter)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000031F1 File Offset: 0x000013F1
		public CustomizationData TaskChangeMigrationItems(int fillTaskHandle, MigrationItemsOption items)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000031F8 File Offset: 0x000013F8
		public CustomizationData TaskChangeMiscSetting(int fillTaskHandle, MiscSettingData setting)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000031FF File Offset: 0x000013FF
		public CustomizationData TaskChangeUserMapping(int taskHandle, UserMapping userMapping)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003206 File Offset: 0x00001406
		public ApplicationData TaskGetApplicationData(int taskHandle, ulong applicationId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000320D File Offset: 0x0000140D
		public IEnumerable<ApplicationData> TaskGetApplications(int taskHandle, GetApplicationsParameters parameters, RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003214 File Offset: 0x00001414
		public AuthorizationInfo TaskGetAuthorizationInfo(int taskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000321B File Offset: 0x0000141B
		public IEnumerable<TransferrableCategoryDefinition> TaskGetCategories(int taskHandle, CategoryParameters categoryParameters, RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003222 File Offset: 0x00001422
		public DriveData TaskGetDriveData(int taskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003229 File Offset: 0x00001429
		public IEnumerable<ItemFilterData> TaskGetItemFilters(int taskHandle, ItemType type)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003230 File Offset: 0x00001430
		public MigrationItemsOption? TaskGetMigrationItems(int fillTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003237 File Offset: 0x00001437
		public MiscSettingsData TaskGetMiscSettings(int fillTaskHandle, string uiCultureName)
		{
			return new MiscSettingsData();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000323E File Offset: 0x0000143E
		public IEnumerable<string> TaskGetRedistPackages(int unloadTaskHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003248 File Offset: 0x00001448
		public TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace)
		{
			return new TaskStats
			{
				Disk = new ContainerStats
				{
					NumContainers = 0UL,
					NumItems = 0UL,
					TotalSize = 0UL
				},
				DriveSpaceRequired = new List<DriveSpaceRequired>(),
				Registry = new ContainerStats
				{
					NumContainers = 0UL,
					NumItems = 0UL,
					TotalSize = 0UL
				}
			};
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000032AB File Offset: 0x000014AB
		public TransferContainerData TaskGetTransferContainerData(int taskHandle, ItemType type, CategoryDefinition category, string path, CountDetail countDetail, RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000032B2 File Offset: 0x000014B2
		public TransferrableContainerData TaskGetTransferrableContainerData(int taskHandle, ItemType type, string path, bool withinBranch, CountDetail countDetail, bool includeTargets, bool allAppsOnly, RequestedPage page)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000032B9 File Offset: 0x000014B9
		public UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000032C0 File Offset: 0x000014C0
		public FinishTransferData TaskPerformPostTransferActions(int taskHandle, bool dlmgrReboot)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000032C7 File Offset: 0x000014C7
		public bool TaskPrepareAuthorization(int taskHandle, AuthorizationRequestData authRequest)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000032CE File Offset: 0x000014CE
		public CustomizationData TaskRemoveRedirection(int taskHandle, ItemType type, string containerPath, string itemName, bool isContainer, bool containerAllAppsOnly)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000032D5 File Offset: 0x000014D5
		public TaskAlertData PolicyGetInteractiveAlert(TaskAlertData.AlertType alertType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000032DC File Offset: 0x000014DC
		public bool TaskPostAlerts(int taskHandle, TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, string statusMessage)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000032E3 File Offset: 0x000014E3
		public CustomizationData TaskSetUserPassword(int taskHandle, UserDetail user, string password)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000032EA File Offset: 0x000014EA
		public bool TaskSetVanPassword(int taskHandle, string password)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000032F1 File Offset: 0x000014F1
		public CustomizationData TaskSwapItemFilters(int taskHandle, ItemType type, int index1, int index2)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000032F8 File Offset: 0x000014F8
		public bool TaskUploadApplicationReport(int taskHandle)
		{
			throw new NotImplementedException();
		}
	}
}
