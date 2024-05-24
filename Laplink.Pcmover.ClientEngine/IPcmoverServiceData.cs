using System;
using System.Collections.Generic;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000007 RID: 7
	public interface IPcmoverServiceData
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003B RID: 59
		string HostName { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003C RID: 60
		PcmoverStatusInfo PcmoverInfo { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003D RID: 61
		DownloadStatusInfo DownloadInfo { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003E RID: 62
		IEnumerable<ActivityInfo> Activities { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003F RID: 63
		IEnumerable<MachineData> Machines { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000040 RID: 64
		IEnumerable<PcmTaskData> Tasks { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000041 RID: 65
		IEnumerable<TransferMethodData> TransferMethods { get; }

		// Token: 0x06000042 RID: 66
		string GetPublicProperty(string key);

		// Token: 0x06000043 RID: 67
		TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle);

		// Token: 0x06000044 RID: 68
		TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly);

		// Token: 0x06000045 RID: 69
		int GetActivityTaskHandle(int taskActivityHandle);

		// Token: 0x06000046 RID: 70
		int GetActivityTransferMethodHandle(int transferMethodActivityHandle);

		// Token: 0x06000047 RID: 71
		int GetActivityMachineHandle(int machineActivityHandle);

		// Token: 0x06000048 RID: 72
		NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle);
	}
}
