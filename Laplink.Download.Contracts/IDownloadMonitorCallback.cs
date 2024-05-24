using System;
using System.ServiceModel;

namespace Laplink.Download.Contracts
{
	// Token: 0x0200000C RID: 12
	public interface IDownloadMonitorCallback
	{
		// Token: 0x06000037 RID: 55
		[OperationContract(IsOneWay = true)]
		void DownloadStatusChanged(DownloadStatusInfo statusInfo);
	}
}
