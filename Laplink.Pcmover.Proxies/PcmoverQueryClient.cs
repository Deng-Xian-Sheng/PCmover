using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Laplink.Pcmover.Contracts;
using Laplink.Service.Contracts;

namespace Laplink.Pcmover.Proxies
{
	// Token: 0x02000004 RID: 4
	public class PcmoverQueryClient : ClientBase<IPcmoverQuery>, IPcmoverQuery
	{
		// Token: 0x0600008E RID: 142 RVA: 0x00002917 File Offset: 0x00000B17
		public PcmoverQueryClient()
		{
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000291F File Offset: 0x00000B1F
		public void CloseOrAbort()
		{
			if (base.State == CommunicationState.Faulted)
			{
				base.Abort();
				return;
			}
			base.Close();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002937 File Offset: 0x00000B37
		public PcmoverQueryClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002941 File Offset: 0x00000B41
		public PcmoverStatusInfo GetPcmoverStatus()
		{
			return base.Channel.GetPcmoverStatus();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000294E File Offset: 0x00000B4E
		public Version GetPcmoverVersion()
		{
			return base.Channel.GetPcmoverVersion();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000295B File Offset: 0x00000B5B
		public InitPcmoverData GetInitPcmoverData()
		{
			return base.Channel.GetInitPcmoverData();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002968 File Offset: 0x00000B68
		public IDictionary<string, string> GetAllPublicProperties()
		{
			return base.Channel.GetAllPublicProperties();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002975 File Offset: 0x00000B75
		public string GetPublicProperty(string key)
		{
			return base.Channel.GetPublicProperty(key);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002983 File Offset: 0x00000B83
		public IEnumerable<ActivityInfo> GetAllActivityInfo()
		{
			return base.Channel.GetAllActivityInfo();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002990 File Offset: 0x00000B90
		public ActivityInfo GetActivityInfo(int activityHandle)
		{
			return base.Channel.GetActivityInfo(activityHandle);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000299E File Offset: 0x00000B9E
		public ProgressInfo GetActivityProgressInfo(int activityHandle)
		{
			return base.Channel.GetActivityProgressInfo(activityHandle);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000029AC File Offset: 0x00000BAC
		public int GetActivityTaskHandle(int taskActivityHandle)
		{
			return base.Channel.GetActivityTaskHandle(taskActivityHandle);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000029BA File Offset: 0x00000BBA
		public int GetActivityMachineHandle(int machineActivityHandle)
		{
			return base.Channel.GetActivityMachineHandle(machineActivityHandle);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000029C8 File Offset: 0x00000BC8
		public int GetActivityTransferMethodHandle(int transferMethodActivityHandle)
		{
			return base.Channel.GetActivityTransferMethodHandle(transferMethodActivityHandle);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000029D6 File Offset: 0x00000BD6
		public IEnumerable<int> GetActivityTransferMethodHandles(int transferMethodsActivityHandle)
		{
			return base.Channel.GetActivityTransferMethodHandles(transferMethodsActivityHandle);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000029E4 File Offset: 0x00000BE4
		public AppInventoryStatus GetAppInventoryActivityStatus(int appInventoryActivityHandle)
		{
			return base.Channel.GetAppInventoryActivityStatus(appInventoryActivityHandle);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000029F2 File Offset: 0x00000BF2
		public TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle)
		{
			return base.Channel.GetTransferActivityParameters(transferActivityHandle);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00002A00 File Offset: 0x00000C00
		public ExpandSnapshotActivityParameters GetExpandSnapshotActivityParameters(int expandSnapshotActivityHandle)
		{
			return base.Channel.GetExpandSnapshotActivityParameters(expandSnapshotActivityHandle);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002A0E File Offset: 0x00000C0E
		public IEnumerable<ReportData> GetGenerateReportsActivityData(int generateReportsActivityHandle)
		{
			return base.Channel.GetGenerateReportsActivityData(generateReportsActivityHandle);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002A1C File Offset: 0x00000C1C
		public TransferSpeeds GetTransferSpeeds(int transferActivityHandle)
		{
			return base.Channel.GetTransferSpeeds(transferActivityHandle);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002A2A File Offset: 0x00000C2A
		public MachineData GetThisMachine()
		{
			return base.Channel.GetThisMachine();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002A37 File Offset: 0x00000C37
		public MachineData GetMachineData(int machineHandle)
		{
			return base.Channel.GetMachineData(machineHandle);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002A45 File Offset: 0x00000C45
		public IEnumerable<MachineData> GetAllMachineData()
		{
			return base.Channel.GetAllMachineData();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002A52 File Offset: 0x00000C52
		public IEnumerable<UserDetail> GetMachineUsers(int machineHandle)
		{
			return base.Channel.GetMachineUsers(machineHandle);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002A60 File Offset: 0x00000C60
		public AppInventoryAmount? GetMachineAppInventoryAmount(int machineHandle)
		{
			return base.Channel.GetMachineAppInventoryAmount(machineHandle);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002A6E File Offset: 0x00000C6E
		public IEnumerable<PcmTaskData> GetAllTaskData()
		{
			return base.Channel.GetAllTaskData();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002A7B File Offset: 0x00000C7B
		public PcmTaskData GetTaskData(int taskHandle)
		{
			return base.Channel.GetTaskData(taskHandle);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00002A89 File Offset: 0x00000C89
		public TransferProcessResult GetTaskTransferResult(int taskHandle)
		{
			return base.Channel.GetTaskTransferResult(taskHandle);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002A97 File Offset: 0x00000C97
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			return base.Channel.GetTaskSummaryData(taskHandle, regularUsersOnly);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00002AA6 File Offset: 0x00000CA6
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			return base.Channel.GetTransferMethodData(transferMethodHandle);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002AB4 File Offset: 0x00000CB4
		public IEnumerable<TransferMethodData> GetAllTransferMethodData()
		{
			return base.Channel.GetAllTransferMethodData();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002AC1 File Offset: 0x00000CC1
		public NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle)
		{
			return base.Channel.GetNetworkTransferMethodInfo(networkTransferMethodHandle);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002ACF File Offset: 0x00000CCF
		public ImageMapData GetImageTransferMethodInfo(int imageTransferMethodHandle)
		{
			return base.Channel.GetImageTransferMethodInfo(imageTransferMethodHandle);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002ADD File Offset: 0x00000CDD
		public WinUpgradeTransferMethodInfo GetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle)
		{
			return base.Channel.GetWinUpgradeTransferMethodInfo(winUpgradeTransferMethodHandle);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002AEB File Offset: 0x00000CEB
		public FileTransferMethodInfo GetFileTransferMethodInfo(int fileTransferMethodHandle)
		{
			return base.Channel.GetFileTransferMethodInfo(fileTransferMethodHandle);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00002AF9 File Offset: 0x00000CF9
		public NetworkStatsData GetNetworkStats()
		{
			return base.Channel.GetNetworkStats();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002B06 File Offset: 0x00000D06
		public string GetDownloadManagerEndpointAddress(ServiceType serviceType)
		{
			return base.Channel.GetDownloadManagerEndpointAddress(serviceType);
		}
	}
}
