using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Laplink.Download.Contracts
{
	// Token: 0x0200000A RID: 10
	public interface IDownloadControlCallback : IDownloadMonitorCallback
	{
		// Token: 0x06000032 RID: 50
		[OperationContract(IsOneWay = true)]
		void TimeToReboot();

		// Token: 0x06000033 RID: 51
		[OperationContract(IsOneWay = true)]
		void PackageUpdated(DownloadPackage package);

		// Token: 0x06000034 RID: 52
		[OperationContract(IsOneWay = true)]
		void DownloadCompleted(bool restart);

		// Token: 0x06000035 RID: 53
		[OperationContract(IsOneWay = true)]
		void DisplayDownloadError(IEnumerable<string> FailedPackages);
	}
}
