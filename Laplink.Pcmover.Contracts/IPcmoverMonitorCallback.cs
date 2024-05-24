using System;
using System.ServiceModel;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000044 RID: 68
	public interface IPcmoverMonitorCallback
	{
		// Token: 0x060001EA RID: 490
		[OperationContract(IsOneWay = true)]
		void PcmoverStatusChanged(PcmoverStatusInfo statusInfo);

		// Token: 0x060001EB RID: 491
		[OperationContract(IsOneWay = true)]
		void ActivityProgress(ActivityInfo activityInfo, ProgressInfo progressInfo);

		// Token: 0x060001EC RID: 492
		[OperationContract(IsOneWay = true)]
		void ActivityChanged(ActivityInfo activityInfo, MonitorChangeType change);

		// Token: 0x060001ED RID: 493
		[OperationContract(IsOneWay = true)]
		void MachineChanged(MachineData machineData, MonitorChangeType change);

		// Token: 0x060001EE RID: 494
		[OperationContract(IsOneWay = true)]
		void TaskChanged(PcmTaskData taskData, MonitorChangeType change);

		// Token: 0x060001EF RID: 495
		[OperationContract(IsOneWay = true)]
		void TransferMethodChanged(TransferMethodData transferMethodData, MonitorChangeType change);

		// Token: 0x060001F0 RID: 496
		[OperationContract(IsOneWay = true)]
		void PublicPropertyChanged(string key, string value);
	}
}
