using System;
using System.Collections.Generic;
using System.ServiceModel;
using Laplink.Service.Contracts;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200003B RID: 59
	[ServiceContract(Namespace = "http://laplink.com/services/contracts/v2.0056")]
	public interface IPcmoverQuery
	{
		// Token: 0x0600013B RID: 315
		[OperationContract]
		Version GetPcmoverVersion();

		// Token: 0x0600013C RID: 316
		[OperationContract]
		InitPcmoverData GetInitPcmoverData();

		// Token: 0x0600013D RID: 317
		[OperationContract]
		IDictionary<string, string> GetAllPublicProperties();

		// Token: 0x0600013E RID: 318
		[OperationContract]
		string GetPublicProperty(string key);

		// Token: 0x0600013F RID: 319
		[OperationContract]
		PcmoverStatusInfo GetPcmoverStatus();

		// Token: 0x06000140 RID: 320
		[OperationContract]
		IEnumerable<ActivityInfo> GetAllActivityInfo();

		// Token: 0x06000141 RID: 321
		[OperationContract]
		ActivityInfo GetActivityInfo(int activityHandle);

		// Token: 0x06000142 RID: 322
		[OperationContract]
		ProgressInfo GetActivityProgressInfo(int activityHandle);

		// Token: 0x06000143 RID: 323
		[OperationContract]
		int GetActivityTaskHandle(int taskActivityHandle);

		// Token: 0x06000144 RID: 324
		[OperationContract]
		int GetActivityMachineHandle(int machineActivityHandle);

		// Token: 0x06000145 RID: 325
		[OperationContract]
		int GetActivityTransferMethodHandle(int transferMethodActivityHandle);

		// Token: 0x06000146 RID: 326
		[OperationContract]
		IEnumerable<int> GetActivityTransferMethodHandles(int transferMethodsActivityHandle);

		// Token: 0x06000147 RID: 327
		[OperationContract]
		AppInventoryStatus GetAppInventoryActivityStatus(int appInventoryActivityHandle);

		// Token: 0x06000148 RID: 328
		[OperationContract]
		TransferActivityParameters GetTransferActivityParameters(int transferActivityHandle);

		// Token: 0x06000149 RID: 329
		[OperationContract]
		ExpandSnapshotActivityParameters GetExpandSnapshotActivityParameters(int expandSnapshotActivityHandle);

		// Token: 0x0600014A RID: 330
		[OperationContract]
		IEnumerable<ReportData> GetGenerateReportsActivityData(int generateReportsActivityHandle);

		// Token: 0x0600014B RID: 331
		[OperationContract]
		TransferSpeeds GetTransferSpeeds(int transferActivityHandle);

		// Token: 0x0600014C RID: 332
		[OperationContract]
		IEnumerable<MachineData> GetAllMachineData();

		// Token: 0x0600014D RID: 333
		[OperationContract]
		MachineData GetThisMachine();

		// Token: 0x0600014E RID: 334
		[OperationContract]
		MachineData GetMachineData(int machineHandle);

		// Token: 0x0600014F RID: 335
		[OperationContract]
		IEnumerable<UserDetail> GetMachineUsers(int machineHandle);

		// Token: 0x06000150 RID: 336
		[OperationContract]
		AppInventoryAmount? GetMachineAppInventoryAmount(int machineHandle);

		// Token: 0x06000151 RID: 337
		[OperationContract]
		IEnumerable<PcmTaskData> GetAllTaskData();

		// Token: 0x06000152 RID: 338
		[OperationContract]
		PcmTaskData GetTaskData(int taskHandle);

		// Token: 0x06000153 RID: 339
		[OperationContract]
		TransferProcessResult GetTaskTransferResult(int taskHandle);

		// Token: 0x06000154 RID: 340
		[OperationContract]
		TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly);

		// Token: 0x06000155 RID: 341
		[OperationContract]
		IEnumerable<TransferMethodData> GetAllTransferMethodData();

		// Token: 0x06000156 RID: 342
		[OperationContract]
		TransferMethodData GetTransferMethodData(int transferMethodHandle);

		// Token: 0x06000157 RID: 343
		[OperationContract]
		NetworkTransferMethodInfo GetNetworkTransferMethodInfo(int networkTransferMethodHandle);

		// Token: 0x06000158 RID: 344
		[OperationContract]
		ImageMapData GetImageTransferMethodInfo(int imageTransferMethodHandle);

		// Token: 0x06000159 RID: 345
		[OperationContract]
		WinUpgradeTransferMethodInfo GetWinUpgradeTransferMethodInfo(int winUpgradeTransferMethodHandle);

		// Token: 0x0600015A RID: 346
		[OperationContract]
		FileTransferMethodInfo GetFileTransferMethodInfo(int fileTransferMethodHandle);

		// Token: 0x0600015B RID: 347
		[OperationContract]
		NetworkStatsData GetNetworkStats();

		// Token: 0x0600015C RID: 348
		[OperationContract]
		string GetDownloadManagerEndpointAddress(ServiceType serviceType);
	}
}
