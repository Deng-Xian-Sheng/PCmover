using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;

namespace Laplink.Pcmover.Proxies
{
	// Token: 0x02000003 RID: 3
	public class PcmoverMonitorClient<TChannel> : DuplexClientBase<TChannel>, IPcmoverMonitor, IPcmoverQuery where TChannel : class, IPcmoverMonitor
	{
		// Token: 0x06000068 RID: 104 RVA: 0x0000265A File Offset: 0x0000085A
		public PcmoverMonitorClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress) : base(callbackInstance, binding, remoteAddress)
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002665 File Offset: 0x00000865
		public PcmoverMonitorClient(InstanceContext callbackInstance, string endpointConfigurationName) : base(callbackInstance, endpointConfigurationName)
		{
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000266F File Offset: 0x0000086F
		public void CloseOrAbort()
		{
			if (base.State == CommunicationState.Faulted)
			{
				base.Abort();
				return;
			}
			base.Close();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002687 File Offset: 0x00000887
		public void ConfigureMonitorCallbacks(CallbackState monitorCallbackState)
		{
			base.Channel.ConfigureMonitorCallbacks(monitorCallbackState);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000269A File Offset: 0x0000089A
		public PcmoverStatusInfo GetPcmoverStatus()
		{
			return base.Channel.GetPcmoverStatus();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000026AC File Offset: 0x000008AC
		public Version GetPcmoverVersion()
		{
			return base.Channel.GetPcmoverVersion();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000026BE File Offset: 0x000008BE
		public InitPcmoverData GetInitPcmoverData()
		{
			return base.Channel.GetInitPcmoverData();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000026D0 File Offset: 0x000008D0
		public IDictionary<string, string> GetAllPublicProperties()
		{
			return base.Channel.GetAllPublicProperties();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000026E2 File Offset: 0x000008E2
		public string GetPublicProperty(string key)
		{
			return base.Channel.GetPublicProperty(key);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000026F5 File Offset: 0x000008F5
		public IEnumerable<ActivityInfo> GetAllActivityInfo()
		{
			return base.Channel.GetAllActivityInfo();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002707 File Offset: 0x00000907
		public ActivityInfo GetActivityInfo(int activityHandle)
		{
			return base.Channel.GetActivityInfo(activityHandle);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000271A File Offset: 0x0000091A
		public ProgressInfo GetActivityProgressInfo(int activityHandle)
		{
			return base.Channel.GetActivityProgressInfo(activityHandle);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000272D File Offset: 0x0000092D
		public int GetActivityTaskHandle(int taskActivityHandle)
		{
			return base.Channel.GetActivityTaskHandle(taskActivityHandle);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002740 File Offset: 0x00000940
		public int GetActivityMachineHandle(int machineActivityHandle)
		{
			return base.Channel.GetActivityMachineHandle(machineActivityHandle);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002753 File Offset: 0x00000953
		public int GetActivityTransferMethodHandle(int transferMethodActivityHandle)
		{
			return base.Channel.GetActivityTransferMethodHandle(transferMethodActivityHandle);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002766 File Offset: 0x00000966
		public IEnumerable<int> GetActivityTransferMethodHandles(int transferMethodsActivityHandle)
		{
			return base.Channel.GetActivityTransferMethodHandles(transferMethodsActivityHandle);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002779 File Offset: 0x00000979
		public AppInventoryStatus GetAppInventoryActivityStatus(int appInventoryActivityHandle)
		{
			return base.Channel.GetAppInventoryActivityStatus(appInventoryActivityHandle);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000278C File Offset: 0x0000098C
		public TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle)
		{
			return base.Channel.GetTransferActivityParameters(transferActivityHandle);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000279F File Offset: 0x0000099F
		public ExpandSnapshotActivityParameters GetExpandSnapshotActivityParameters(int expandSnapshotActivityHandle)
		{
			return base.Channel.GetExpandSnapshotActivityParameters(expandSnapshotActivityHandle);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000027B2 File Offset: 0x000009B2
		public IEnumerable<ReportData> GetGenerateReportsActivityData(int generateReportsActivityHandle)
		{
			return base.Channel.GetGenerateReportsActivityData(generateReportsActivityHandle);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000027C5 File Offset: 0x000009C5
		public TransferSpeeds GetTransferSpeeds(int transferActivityHandle)
		{
			return base.Channel.GetTransferSpeeds(transferActivityHandle);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000027D8 File Offset: 0x000009D8
		public MachineData GetThisMachine()
		{
			return base.Channel.GetThisMachine();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000027EA File Offset: 0x000009EA
		public MachineData GetMachineData(int machineHandle)
		{
			return base.Channel.GetMachineData(machineHandle);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000027FD File Offset: 0x000009FD
		public IEnumerable<MachineData> GetAllMachineData()
		{
			return base.Channel.GetAllMachineData();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000280F File Offset: 0x00000A0F
		public IEnumerable<UserDetail> GetMachineUsers(int machineHandle)
		{
			return base.Channel.GetMachineUsers(machineHandle);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002822 File Offset: 0x00000A22
		public AppInventoryAmount? GetMachineAppInventoryAmount(int machineHandle)
		{
			return base.Channel.GetMachineAppInventoryAmount(machineHandle);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002835 File Offset: 0x00000A35
		public IEnumerable<PcmTaskData> GetAllTaskData()
		{
			return base.Channel.GetAllTaskData();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002847 File Offset: 0x00000A47
		public PcmTaskData GetTaskData(int taskHandle)
		{
			return base.Channel.GetTaskData(taskHandle);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000285A File Offset: 0x00000A5A
		public TransferProcessResult GetTaskTransferResult(int taskHandle)
		{
			return base.Channel.GetTaskTransferResult(taskHandle);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000286D File Offset: 0x00000A6D
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			return base.Channel.GetTaskSummaryData(taskHandle, regularUsersOnly);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002881 File Offset: 0x00000A81
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			return base.Channel.GetTransferMethodData(transferMethodHandle);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002894 File Offset: 0x00000A94
		public IEnumerable<TransferMethodData> GetAllTransferMethodData()
		{
			return base.Channel.GetAllTransferMethodData();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000028A6 File Offset: 0x00000AA6
		public NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle)
		{
			return base.Channel.GetNetworkTransferMethodInfo(networkTransferMethodHandle);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000028B9 File Offset: 0x00000AB9
		public ImageMapData GetImageTransferMethodInfo(int imageTransferMethodHandle)
		{
			return base.Channel.GetImageTransferMethodInfo(imageTransferMethodHandle);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000028CC File Offset: 0x00000ACC
		public WinUpgradeTransferMethodInfo GetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle)
		{
			return base.Channel.GetWinUpgradeTransferMethodInfo(winUpgradeTransferMethodHandle);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000028DF File Offset: 0x00000ADF
		public FileTransferMethodInfo GetFileTransferMethodInfo(int fileTransferMethodHandle)
		{
			return base.Channel.GetFileTransferMethodInfo(fileTransferMethodHandle);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000028F2 File Offset: 0x00000AF2
		public NetworkStatsData GetNetworkStats()
		{
			return base.Channel.GetNetworkStats();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002904 File Offset: 0x00000B04
		public string GetDownloadManagerEndpointAddress(ServiceType serviceType)
		{
			return base.Channel.GetDownloadManagerEndpointAddress(serviceType);
		}
	}
}
